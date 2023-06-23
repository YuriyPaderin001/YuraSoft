using System;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Queries
{
    public class DeleteTests : TestsBase
    {
        [Fact]
        public void Constructor_TableName_Success()
        {
            // Arrange
            const string tableName = "test_table";

            // Act
            Delete query = new Delete(tableName);

            // Assert
            Assert.NotNull(query.Source);

            Table table = Assert.IsType<Table>(query.Source);
            Assert.Equal(tableName, table.Name);
            Assert.Null(table.Alias);
            Assert.Null(table.Schema);

            Assert.Null(query.Condition);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("test_schema")]
        public void Constructor_TableNameAndSchema_Success(string? tableSchema)
        {
            // Arrange
            const string tableName = "test_table";

            // Act
            Delete query = new Delete(tableName, tableSchema);

            // Assert
            Assert.NotNull(query.Source);

            Table table = Assert.IsType<Table>(query.Source);
            Assert.Equal(tableName, table.Name);
            Assert.Null(table.Alias);

            if (string.IsNullOrEmpty(tableSchema))
            {
                Assert.Null(table.Schema);
            }
            else
            {
                Assert.Equal(tableSchema, table.Schema);
            }

            Assert.Null(query.Condition);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData(null, "test_schema")]
        [InlineData("", null)]
        [InlineData("", "")]
        [InlineData("", "test_schema")]
        [InlineData("test_alias", null)]
        [InlineData("test_alias", "")]
        [InlineData("test_alias", "test_schema")]
        public void Constructor_TableNameAndAliasAndSchema_Success(string? tableAlias, string? tableSchema)
        {
            // Arrange
            const string tableName = "test_table";

            // Act
            Delete query = new Delete(tableName, tableAlias, tableSchema);

            // Assert
            Assert.NotNull(query.Source);

            Table table = Assert.IsType<Table>(query.Source);
            Assert.Equal(tableName, table.Name);
            
            if (string.IsNullOrEmpty(tableAlias))
            {
                Assert.Null(table.Alias);
            }
            else
            {
                Assert.Equal(tableAlias, table.Alias);
            }

            if (string.IsNullOrEmpty(tableSchema))
            {
                Assert.Null(table.Schema);
            }
            else
            {
                Assert.Equal(tableSchema, table.Schema);
            }

            Assert.Null(query.Condition);
        }

        [Fact]
        public void Constructor_Source_Success()
        {
            // Arrange
            Table source = new Table("test_name", "test_alias", "test_schema");

            // Act
            Delete query = new Delete(source);

            // Assert
            Assert.NotNull(query.Source);

            Table table = Assert.IsType<Table>(query.Source);
            Assert.Equal(source, table);

            Assert.Null(query.Condition);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_NullOrEmptyTableName_ThrowsArgumentException(string? tableName) =>
            Assert.Throws<ArgumentException>(() => new Delete(tableName!));

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData(null, "table_schema")]
        [InlineData("", null)]
        [InlineData("", "")]
        [InlineData("", "table_schema")]
        public void Constructor_NullOrEmptyTableNameAndSchema_ThrowsArgumentException(string? tableName, string? tableSchema) =>
            Assert.Throws<ArgumentException>(() => new Delete(tableName!, tableSchema));

        [Theory]
        [InlineData(null, null, null)]
        [InlineData(null, null, "")]
        [InlineData(null, null, "test_schema")]
        [InlineData(null, "", null)]
        [InlineData(null, "", "")]
        [InlineData(null, "", "test_schema")]
        [InlineData(null, "test_alias", null)]
        [InlineData(null, "test_alias", "")]
        [InlineData(null, "test_alias", "test_schema")]
        [InlineData("", null, null)]
        [InlineData("", null, "")]
        [InlineData("", null, "test_schema")]
        [InlineData("", "", null)]
        [InlineData("", "", "")]
        [InlineData("", "", "test_schema")]
        [InlineData("", "test_alias", null)]
        [InlineData("", "test_alias", "")]
        [InlineData("", "test_alias", "test_schema")]
        public void Constructor_NullOrEmptyTableNameAndAliasAndSchema_ThrowsArgumentException(string? tableName, string? tableAlias, string? tableSchema) =>
            Assert.Throws<ArgumentException>(() => new Delete(tableName!, tableAlias, tableSchema));

        [Fact]
        public void Constructor_NullTable_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Delete(table: null!));

        [Fact]
        public void Where_Condition_SetCondition()
        {
            // Arrange
            Table table = new Table("test_name", "test_alias", "test_schema");
            Delete query = new Delete(table);

            ICondition condition = new Mock<ICondition>().Object;

            // Act
            query.Where(condition);

            // Assert
            Assert.Equal(table, query.Source);
            Assert.Equal(condition, query.Condition);
        }

        [Fact]
        public void Where_NullCondition_SetCondition()
        {
            // Arrange
            Table table = new Table("test_name", "test_alias", "test_schema");
            Delete query = new Delete(table);
            query.Where(new Mock<ICondition>().Object);

            // Act
            query.Where(condition: null);

            // Assert
            Assert.Equal(table, query.Source);
            Assert.Null(query.Condition);
        }

        [Fact]
        public void Where_ConditionAction_SetCondition()
        {
            // Arrange
            Table table = new Table("test_name", "test_alias", "test_schema");
            Delete query = new Delete(table);

            ICondition condition = new Mock<ICondition>().Object;
            Action<ConditionBuilder> conditionAction = (cb) => cb.Condition(condition);

            // Act
            query.Where(conditionAction);

            // Assert
            Assert.Equal(table, query.Source);
            Assert.Equal(condition, query.Condition);
        }

        [Fact]
        public void Where_NullConditionAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Delete("test_name").Where(conditionAction: null!));

        [Fact]
        public void RenderQuery_RendererAndSql_WritesSqlToSql()
        {
            // Arrange
            Delete query = new Delete("test_name");

            const string expectedSql = "test_sql";

            Mock<IRenderer> rendererMock = new Mock<IRenderer>();
            rendererMock.Setup(ca => ca.RenderQuery(It.IsAny<Delete>(), It.IsAny<StringBuilder>()))
                .Callback((Delete query, StringBuilder sql) => sql.Append(expectedSql));

            IRenderer renderer = rendererMock.Object;
            StringBuilder sql = new StringBuilder();

            // Act
            query.RenderQuery(renderer, sql);

            // Assert
            Assert.Equal(expectedSql, sql.ToString());
        }

        [Fact]
        public void RenderQuery_Renderer_ReturnsSql()
        {
            // Arrange
            Delete query = new Delete("test_name");

            const string expectedSql = "test_sql";

            Mock<IRenderer> rendererMock = new Mock<IRenderer>();
            rendererMock.Setup(ca => ca.RenderQuery(It.IsAny<Delete>(), It.IsAny<StringBuilder>()))
                .Callback((Delete query, StringBuilder sql) => sql.Append(expectedSql));

            IRenderer renderer = rendererMock.Object;

            // Act
            string sql = query.RenderQuery(renderer);

            // Assert
            Assert.Equal(expectedSql, sql.ToString());
        }
    }
}
