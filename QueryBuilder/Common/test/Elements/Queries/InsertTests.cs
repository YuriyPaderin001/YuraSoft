using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Queries
{
    public class InsertTests : TestsBase
    {
        [Fact]
        public void Constructor_TableName_Success()
        {
            // Arrange
            const string tableName = "test_table";

            // Act
            Insert query = new Insert(tableName);

            // Assert
            Assert.NotNull(query.Source);

            Table table = Assert.IsType<Table>(query.Source);
            Assert.Equal(tableName, table.Name);
            Assert.Null(table.Alias);
            Assert.Null(table.Schema);

            Assert.Empty(query.ColumnCollection);
            Assert.Empty(query.ValueCollection);
            Assert.Empty(query.ReturningColumnCollection);
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
            Insert query = new Insert(tableName, tableSchema);

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

            Assert.Empty(query.ColumnCollection);
            Assert.Empty(query.ValueCollection);
            Assert.Empty(query.ReturningColumnCollection);
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
            Insert query = new Insert(tableName, tableAlias, tableSchema);

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

            Assert.Empty(query.ColumnCollection);
            Assert.Empty(query.ValueCollection);
            Assert.Empty(query.ReturningColumnCollection);
        }

        [Fact]
        public void Constructor_Source_Success()
        {
            // Arrange
            Table source = new Table("test_name", "test_alias", "test_schema");

            // Act
            Insert query = new Insert(source);

            // Assert
            Assert.NotNull(query.Source);

            Table table = Assert.IsType<Table>(query.Source);
            Assert.Equal(source, table);

            Assert.Empty(query.ColumnCollection);
            Assert.Empty(query.ValueCollection);
            Assert.Empty(query.ReturningColumnCollection);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_NullOrEmptyTableName_ThrowsArgumentException(string? tableName) =>
            Assert.Throws<ArgumentException>(() => new Insert(tableName!));

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData(null, "table_schema")]
        [InlineData("", null)]
        [InlineData("", "")]
        [InlineData("", "table_schema")]
        public void Constructor_NullOrEmptyTableNameAndSchema_ThrowsArgumentException(string? tableName, string? tableSchema) =>
            Assert.Throws<ArgumentException>(() => new Insert(tableName!, tableSchema));

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
            Assert.Throws<ArgumentException>(() => new Insert(tableName!, tableAlias, tableSchema));

        [Fact]
        public void Constructor_NullTable_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Insert(table: null!));

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        public void Columns_ColumnsAsEnumerable_SetColumnCollection(int columnsCount)
        {
            // Arrange
            Table table = new Table("test_name", "test_alias", "test_schema");
            Insert query = new Insert(table);

            List<IColumn> columns = NewColumns(columnsCount);

            // Act
            query.Columns(columns);

            // Assert
            Assert.Equal(table, query.Source);
            Assert.Equal(columns, query.ColumnCollection);
            Assert.Empty(query.ValueCollection);
            Assert.Empty(query.ReturningColumnCollection);
        }

        [Fact]
        public void Columns_ColumnsAsParams_SetColumnCollection()
        {
            // Arrange
            Table table = new Table("test_name", "test_alias", "test_schema");
            Insert query = new Insert(table);

            IColumn column1 = NewColumn();
            IColumn column2 = NewColumn();

            // Act
            query.Columns(column1, column2);

            // Assert
            Assert.Equal(table, query.Source);
            Assert.Equal(2, query.ColumnCollection.Count);
            Assert.Equal(column1, query.ColumnCollection[0]);
            Assert.Equal(column2, query.ColumnCollection[1]);
            Assert.Empty(query.ValueCollection);
            Assert.Empty(query.ReturningColumnCollection);
        }

        [Fact]
        public void Columns_ColumnsAsEmptyParams_SetColumnCollection()
        {
            // Arrange
            Table table = new Table("test_name", "test_alias", "test_schema");
            Insert query = new Insert(table);

            IColumn[] columns = Array.Empty<IColumn>();

            // Act
            query.Columns(columns);

            // Assert
            Assert.Equal(table, query.Source);
            Assert.Equal(columns, query.ColumnCollection);
            Assert.Empty(query.ValueCollection);
            Assert.Empty(query.ReturningColumnCollection);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        public void Columns_ColumnNamesAsEnumerable_SetColumnCollection(int columnsCount)
        {
            // Arrange
            Table table = new Table("test_name", "test_alias", "test_schema");
            Insert query = new Insert(table);

            string[] columnNames = new string[columnsCount];
            for (int i = 0; i < columnsCount; i++)
            {
                columnNames[i] = $"test_column_{i + 1}_name";
            }

            // Act
            query.Columns((IEnumerable<string>)columnNames);

            // Assert
            Assert.Equal(table, query.Source);
            Assert.Equal(columnsCount, query.ColumnCollection.Count);

            for (int i = 0; i < columnsCount; i++)
            {
                SourceColumn column = Assert.IsType<SourceColumn>(query.ColumnCollection[i]);
                Assert.Equal(columnNames[i], column.Name);
            }

            Assert.Empty(query.ValueCollection);
            Assert.Empty(query.ReturningColumnCollection);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        public void Columns_ColumnNamesAsParams_SetColumnCollection(int columnsCount)
        {
            // Arrange
            Table table = new Table("test_name", "test_alias", "test_schema");
            Insert query = new Insert(table);

            string[] columnNames = new string[columnsCount];
            for (int i = 0; i < columnsCount; i++)
            {
                columnNames[i] = $"test_column_{i + 1}_name";
            }

            // Act
            query.Columns(columnNames);

            // Assert
            Assert.Equal(table, query.Source);
            Assert.Equal(columnsCount, query.ColumnCollection.Count);

            for (int i = 0; i < columnsCount; i++)
            {
                SourceColumn column = Assert.IsType<SourceColumn>(query.ColumnCollection[i]);
                Assert.Equal(columnNames[i], column.Name);
            }

            Assert.Empty(query.ValueCollection);
            Assert.Empty(query.ReturningColumnCollection);
        }

        [Fact]
        public void Columns_ColumnAction_SetColumnCollection()
        {
            // Arrange
            Table table = new Table("test_name", "test_alias", "test_schema");
            Insert query = new Insert(table);

            IColumn column = new Mock<IColumn>().Object;
            Action<ColumnBuilder> columnAction = (cb) => cb.Column(column);

            // Act
            query.Columns(columnAction);

            // Assert
            Assert.Equal(table, query.Source);
            Assert.Single(query.ColumnCollection);
            Assert.Equal(column, query.ColumnCollection[0]);
            Assert.Empty(query.ValueCollection);
            Assert.Empty(query.ReturningColumnCollection);
        }

        [Fact]
        public void Columns_NullColumnsAsEnumerable_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Insert("test_name").Columns((IEnumerable<IColumn>)null!));

        [Fact]
        public void Columns_NullColumnsAsParams_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Insert("test_name").Columns((IColumn[])null!));

        [Fact]
        public void Columns_NullColumnNamesAsEnumerable_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Insert("test_name").Columns((IEnumerable<string>)null!));

        [Fact]
        public void Columns_NullColumnNamesAsParams_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Insert("test_name").Columns((string[])null!));

        [Fact]
        public void Columns_NullColumnAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Insert("test_name").Columns(columnAction: null!));

        [Fact]
        public void Columns_ColumnsAsEnumerableWithNullItems_ThrowsArgumentException() =>
            Assert.Throws<ArgumentException>(() => new Insert("test_name").Columns(new List<IColumn> { NewColumn(), null!, NewColumn() }));

        [Fact]
        public void Columns_ColumnsAsParamsWithNullItems_ThrowsArgumentException() =>
            Assert.Throws<ArgumentException>(() => new Insert("test_name").Columns(new IColumn[] { NewColumn(), NewColumn(), null! }));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Columns_ColumnNamesAsEnumerableWithNullOrEmptyItems_ThrowsArgumentException(string? invalidColumnName) =>
            Assert.Throws<ArgumentException>(() => new Insert("test_name").Columns(new List<string> { "test_column_1_name", "test_column_2_name", invalidColumnName! }));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Columns_ColumnNamesAsParamsWithNullOrEmptyItems_ThrowsArgumentException(string? invalidColumnName) =>
            Assert.Throws<ArgumentException>(() => new Insert("test_name").Columns(new string[] { "test_column_1_name", "test_column_2_name", invalidColumnName! }));

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        public void Values_ValuesAsEnumerable_SetValueCollection(int valuesCount)
        {
            // Arrange
            Table table = new Table("test_name", "test_alias", "test_schema");
            Insert query = new Insert(table);

            List<IExpression> values = NewExpressionList(valuesCount);

            // Act
            query.Values(values);

            // Assert
            Assert.Equal(table, query.Source);
            Assert.Empty(query.ColumnCollection);
            Assert.Equal(values, query.ValueCollection);
            Assert.Empty(query.ReturningColumnCollection);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        public void Values_ValuesAsParams_SetValueCollection(int valuesCount)
        {
            // Arrange
            Table table = new Table("test_name", "test_alias", "test_schema");
            Insert query = new Insert(table);

            IExpression[] values = NewExpressionList(valuesCount).ToArray();

            // Act
            query.Values(values);

            // Assert
            Assert.Equal(table, query.Source);
            Assert.Empty(query.ColumnCollection);
            Assert.Equal(values, query.ValueCollection);
            Assert.Empty(query.ReturningColumnCollection);
        }

        [Fact]
        public void Values_ValueAction_SetValueCollection()
        {
            // Arrange
            Table table = new Table("test_name", "test_alias", "test_schema");
            Insert query = new Insert(table);

            IExpression value = new Mock<IExpression>().Object;
            Action<ExpressionBuilder> valueAction = (cb) => cb.Expression(value);

            // Act
            query.Values(valueAction);

            // Assert
            Assert.Equal(table, query.Source);
            Assert.Empty(query.ColumnCollection);

            Assert.Single(query.ValueCollection);
            Assert.Equal(value, query.ValueCollection[0]);

            Assert.Empty(query.ReturningColumnCollection);
        }

        [Fact]
        public void Values_NullValuesAsEnumerable_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Insert("test_name").Values((IEnumerable<IExpression>)null!));

        [Fact]
        public void Values_NullValuesAsParams_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Insert("test_name").Values((IExpression[])null!));

        [Fact]
        public void Values_NullValueAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Insert("test_name").Values(valueAction: null!));

        [Fact]
        public void Values_ValuesAsEnumerableWithNullItems_ThrowsArgumentException() =>
            Assert.Throws<ArgumentException>(() => new Insert("test_name").Values(new List<IExpression> { NewExpression(), null!, NewExpression() }));

        [Fact]
        public void Values_ValuesAsParamsWithNullItems_ThrowsArgumentException() =>
            Assert.Throws<ArgumentException>(() => new Insert("test_name").Values(new IExpression[] { NewExpression(), NewExpression(), null! }));

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        public void Returning_ColumnsAsEnumerable_SetReturningColumnCollection(int columnsCount)
        {
            // Arrange
            Table table = new Table("test_name", "test_alias", "test_schema");
            Insert query = new Insert(table);

            List<IColumn> columns = NewColumns(columnsCount);

            // Act
            query.Returning(columns);

            // Assert
            Assert.Equal(table, query.Source);
            Assert.Empty(query.ColumnCollection);
            Assert.Empty(query.ValueCollection);
            Assert.Equal(columns, query.ReturningColumnCollection);
        }

        [Fact]
        public void Returning_ColumnsAsParams_SetReturningColumnCollection()
        {
            // Arrange
            Table table = new Table("test_name", "test_alias", "test_schema");
            Insert query = new Insert(table);

            IColumn column1 = NewColumn();
            IColumn column2 = NewColumn();

            // Act
            query.Returning(column1, column2);

            // Assert
            Assert.Equal(table, query.Source);
            Assert.Empty(query.ColumnCollection);
            Assert.Empty(query.ValueCollection);
            Assert.Equal(2, query.ReturningColumnCollection.Count);
            Assert.Equal(column1, query.ReturningColumnCollection[0]);
            Assert.Equal(column2, query.ReturningColumnCollection[1]);
        }

        [Fact]
        public void Returning_ColumnsAsEmptyParams_SetReturningColumnCollection()
        {
            // Arrange
            Table table = new Table("test_name", "test_alias", "test_schema");
            Insert query = new Insert(table);

            IColumn[] columns = Array.Empty<IColumn>();

            // Act
            query.Returning(columns);

            // Assert
            Assert.Equal(table, query.Source);
            Assert.Empty(query.ColumnCollection);
            Assert.Empty(query.ValueCollection);
            Assert.Equal(columns, query.ReturningColumnCollection);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        public void Returning_ColumnNamesAsEnumerable_SetReturningColumnCollection(int columnsCount)
        {
            // Arrange
            Table table = new Table("test_name", "test_alias", "test_schema");
            Insert query = new Insert(table);

            string[] columnNames = new string[columnsCount];
            for (int i = 0; i < columnsCount; i++)
            {
                columnNames[i] = $"test_column_{i + 1}_name";
            }

            // Act
            query.Returning((IEnumerable<string>)columnNames);

            // Assert
            Assert.Equal(table, query.Source);
            Assert.Empty(query.ColumnCollection);
            Assert.Empty(query.ValueCollection);
            Assert.Equal(columnsCount, query.ReturningColumnCollection.Count);

            for (int i = 0; i < columnsCount; i++)
            {
                SourceColumn column = Assert.IsType<SourceColumn>(query.ReturningColumnCollection[i]);
                Assert.Equal(columnNames[i], column.Name);
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        public void Returning_ColumnNamesAsParams_SetReturningColumnCollection(int columnsCount)
        {
            // Arrange
            Table table = new Table("test_name", "test_alias", "test_schema");
            Insert query = new Insert(table);

            string[] columnNames = new string[columnsCount];
            for (int i = 0; i < columnsCount; i++)
            {
                columnNames[i] = $"test_column_{i + 1}_name";
            }

            // Act
            query.Returning(columnNames);

            // Assert
            Assert.Equal(table, query.Source);
            Assert.Empty(query.ColumnCollection);
            Assert.Empty(query.ValueCollection);
            Assert.Equal(columnsCount, query.ReturningColumnCollection.Count);

            for (int i = 0; i < columnsCount; i++)
            {
                SourceColumn column = Assert.IsType<SourceColumn>(query.ReturningColumnCollection[i]);
                Assert.Equal(columnNames[i], column.Name);
            }
        }

        [Fact]
        public void Returning_ColumnAction_SetReturningColumnCollection()
        {
            // Arrange
            Table table = new Table("test_name", "test_alias", "test_schema");
            Insert query = new Insert(table);

            IColumn column = new Mock<IColumn>().Object;
            Action<ColumnBuilder> columnAction = (cb) => cb.Column(column);

            // Act
            query.Returning(columnAction);

            // Assert
            Assert.Equal(table, query.Source);
            Assert.Empty(query.ColumnCollection);
            Assert.Empty(query.ValueCollection);
            Assert.Single(query.ReturningColumnCollection);
            Assert.Equal(column, query.ReturningColumnCollection[0]);

        }

        [Fact]
        public void Returning_NullColumnsAsEnumerable_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Insert("test_name").Returning((IEnumerable<IColumn>)null!));

        [Fact]
        public void Returning_NullColumnsAsParams_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Insert("test_name").Returning((IColumn[])null!));

        [Fact]
        public void Returning_NullColumnNamesAsEnumerable_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Insert("test_name").Returning((IEnumerable<string>)null!));

        [Fact]
        public void Returning_NullColumnNamesAsParams_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Insert("test_name").Returning((string[])null!));

        [Fact]
        public void Returning_NullColumnAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Insert("test_name").Returning(columnAction: null!));

        [Fact]
        public void Returning_ColumnsAsEnumerableWithNullItems_ThrowsArgumentException() =>
            Assert.Throws<ArgumentException>(() => new Insert("test_name").Returning(new List<IColumn> { NewColumn(), null!, NewColumn() }));

        [Fact]
        public void Returning_ColumnsAsParamsWithNullItems_ThrowsArgumentException() =>
            Assert.Throws<ArgumentException>(() => new Insert("test_name").Returning(new IColumn[] { NewColumn(), NewColumn(), null! }));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Returning_ColumnNamesAsEnumerableWithNullOrEmptyItems_ThrowsArgumentException(string? invalidColumnName) =>
            Assert.Throws<ArgumentException>(() => new Insert("test_name").Returning(new List<string> { "test_column_1_name", "test_column_2_name", invalidColumnName! }));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Returning_ColumnNamesAsParamsWithNullOrEmptyItems_ThrowsArgumentException(string? invalidColumnName) =>
            Assert.Throws<ArgumentException>(() => new Insert("test_name").Returning(new string[] { "test_column_1_name", "test_column_2_name", invalidColumnName! }));

        [Fact]
        public void RenderQuery_RendererAndSql_WritesSqlToSql()
        {
            // Arrange
            Insert query = new Insert("test_name");

            const string expectedSql = "test_sql";

            Mock<IRenderer> rendererMock = new Mock<IRenderer>();
            rendererMock.Setup(ca => ca.RenderQuery(It.IsAny<Insert>(), It.IsAny<StringBuilder>()))
                .Callback((Insert query, StringBuilder sql) => sql.Append(expectedSql));

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
            Insert query = new Insert("test_name");

            const string expectedSql = "test_sql";

            Mock<IRenderer> rendererMock = new Mock<IRenderer>();
            rendererMock.Setup(ca => ca.RenderQuery(It.IsAny<Insert>(), It.IsAny<StringBuilder>()))
                .Callback((Insert query, StringBuilder sql) => sql.Append(expectedSql));

            IRenderer renderer = rendererMock.Object;

            // Act
            string sql = query.RenderQuery(renderer);

            // Assert
            Assert.Equal(expectedSql, sql.ToString());
        }
    }
}
