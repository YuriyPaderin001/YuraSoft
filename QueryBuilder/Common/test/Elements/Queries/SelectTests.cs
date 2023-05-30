using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Queries
{
	public class SelectTests : TestsBase
	{
		[Fact]
		public void Constructor_StringAndISource_Success() =>
			Constructor_StringAndISource_Success_Base(name: "test_name", source: NewSource());

		[Fact]
		public void Constructor_StringAndNullISource_Success() =>
			Constructor_StringAndISource_Success_Base(name: "test_name", source: null);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Constructor_NullOrEmptyStringAndISource_ThrowsArgumentException(string? name) =>
			Constructor_StringAndISource_ThrowsArgumentException(name, source: NewSource());

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_NullOrEmptyStringAndNullISource_ThrowsArgumentException(string? name) =>
            Constructor_StringAndISource_ThrowsArgumentException(name, source: null);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("test_alias")]
		public void Constructor_StringAndStringAndISource_Success(string? alias) =>
			Constructor_StringAndStringAndISource_Success_Base(name: "test_name", alias, source: NewSource());

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("test_alias")]
        public void Constructor_StringAndStringAndNullISource_Success(string? alias) =>
            Constructor_StringAndStringAndISource_Success_Base(name: "test_name", alias, source: null);

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData(null, "test_alias")]
        [InlineData("", null)]
        [InlineData("", "")]
        [InlineData("", "test_alias")]
        public void Constructor_NullOrEmptyStringAndStringAndISource_ThrowsArgumentException(string? name, string? alias) =>
            Constructor_StringAndStringAndISource_ThrowsArgumentException(name, alias, source: NewSource());

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData(null, "test_alias")]
        [InlineData("", null)]
        [InlineData("", "")]
        [InlineData("", "test_alias")]
        public void Constructor_NullOrEmptyStringAndStringAndNullISource_ThrowsArgumentException(string? name, string? alias) =>
            Constructor_StringAndStringAndISource_ThrowsArgumentException(name, alias, source: null);

		[Fact]
		public void Constructor_ColumnBuilderAction_Success()
		{
			// Arrange
			IColumn column1 = NewColumn();
			IColumn column2 = NewColumn();

			Action<ColumnBuilder> action = (ColumnBuilder c) => c
				.Column(column1)
				.Column(column2);

			// Act
			Select select = new Select(action);

			// Assert
			Assert.Equal(2, select.ColumnCollection.Count);
			Assert.Equal(column1, select.ColumnCollection[0]);
			Assert.Equal(column2, select.ColumnCollection[1]);
            
            Assert.Null(select.DistinctValue);
            Assert.Empty(select.SourceCollection);
            Assert.Null(select.WhereCondition);
            Assert.Empty(select.JoinCollection);
            Assert.Null(select.HavingCondition);
            Assert.Empty(select.OrderByCollection);
            Assert.Empty(select.GroupByCollection);
            Assert.False(select.OffsetValue.HasValue);
            Assert.False(select.LimitValue.HasValue);
        }

		[Fact]
		public void Constructor_NullColumnBuilderAction_ThrowsArgumentNullException()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new Select(columnAction: null!));
		}

		[Fact]
		public void Constructor_StringParams_Success()
		{
			// Arrange
			string column1 = "test_column1";
			string column2 = "test_column2";

			// Act
			Select select = new Select(column1, column2);

            // Assert
            Assert.Equal(2, select.ColumnCollection.Count);
			SourceColumn sourceColumn1 = Assert.IsType<SourceColumn>(select.ColumnCollection[0]);
			SourceColumn sourceColumn2 = Assert.IsType<SourceColumn>(select.ColumnCollection[1]);

            Assert.Equal(column1, sourceColumn1.Name);
            Assert.Equal(column2, sourceColumn2.Name);

            Assert.Null(select.DistinctValue);
            Assert.Empty(select.SourceCollection);
            Assert.Null(select.WhereCondition);
            Assert.Empty(select.JoinCollection);
            Assert.Null(select.HavingCondition);
            Assert.Empty(select.OrderByCollection);
            Assert.Empty(select.GroupByCollection);
            Assert.False(select.OffsetValue.HasValue);
            Assert.False(select.LimitValue.HasValue);
        }

		[Fact]
		public void Constructor_EmptyStringParams_Success()
		{
			// Act
			Select select = new Select(Array.Empty<string>());

            // Assert
            Assert.Empty(select.ColumnCollection);
            Assert.Null(select.DistinctValue);
            Assert.Empty(select.SourceCollection);
            Assert.Null(select.WhereCondition);
            Assert.Empty(select.JoinCollection);
            Assert.Null(select.HavingCondition);
            Assert.Empty(select.OrderByCollection);
            Assert.Empty(select.GroupByCollection);
            Assert.False(select.OffsetValue.HasValue);
            Assert.False(select.LimitValue.HasValue);
        }

		[Fact]
		public void Constructor_NullStringParams_ThrowsArgumentNullException()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new Select((IColumn[])null!));
		}

        [Fact]
		public void Constructor_StringEnumerable_Success()
		{
            // Arrange
            string column1 = "test_column1";
            string column2 = "test_column2";

            // Act
            Select select = new Select((IEnumerable<string>)new string[] { column1, column2 });

            // Assert
            Assert.Equal(2, select.ColumnCollection.Count);
            SourceColumn sourceColumn1 = Assert.IsType<SourceColumn>(select.ColumnCollection[0]);
            SourceColumn sourceColumn2 = Assert.IsType<SourceColumn>(select.ColumnCollection[1]);

            Assert.Equal(column1, sourceColumn1.Name);
            Assert.Equal(column2, sourceColumn2.Name);

            Assert.Null(select.DistinctValue);
            Assert.Empty(select.SourceCollection);
            Assert.Null(select.WhereCondition);
            Assert.Empty(select.JoinCollection);
            Assert.Null(select.HavingCondition);
            Assert.Empty(select.OrderByCollection);
            Assert.Empty(select.GroupByCollection);
            Assert.False(select.OffsetValue.HasValue);
            Assert.False(select.LimitValue.HasValue);
        }

        [Fact]
        public void Constructor_EmptyStringEnumerable_Success()
        {
            // Act
            Select select = new Select((IEnumerable<string>)Array.Empty<string>());

            // Assert
            Assert.Empty(select.ColumnCollection);
            Assert.Null(select.DistinctValue);
            Assert.Empty(select.SourceCollection);
            Assert.Null(select.WhereCondition);
            Assert.Empty(select.JoinCollection);
            Assert.Null(select.HavingCondition);
            Assert.Empty(select.OrderByCollection);
            Assert.Empty(select.GroupByCollection);
            Assert.False(select.OffsetValue.HasValue);
            Assert.False(select.LimitValue.HasValue);
        }

        [Fact]
        public void Constructor_NullStringEnumerable_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Select((IEnumerable<string>)null!));
        }

        [Fact]
        public void Constructor_IColumnParams_Success()
        {
            // Arrange
            IColumn column1 = NewColumn();
            IColumn column2 = NewColumn();

            // Act
            Select select = new Select(column1, column2);

            // Assert
            Assert.Equal(2, select.ColumnCollection.Count);
            Assert.Equal(column1, select.ColumnCollection[0]);
            Assert.Equal(column2, select.ColumnCollection[1]);

            Assert.Null(select.DistinctValue);
            Assert.Empty(select.SourceCollection);
            Assert.Null(select.WhereCondition);
            Assert.Empty(select.JoinCollection);
            Assert.Null(select.HavingCondition);
            Assert.Empty(select.OrderByCollection);
            Assert.Empty(select.GroupByCollection);
            Assert.False(select.OffsetValue.HasValue);
            Assert.False(select.LimitValue.HasValue);
        }

        [Fact]
        public void Constructor_EmptyIColumnParams_Success()
        {
            // Act
            Select select = new Select(Array.Empty<IColumn>());

            // Assert
            Assert.Empty(select.ColumnCollection);
            Assert.Null(select.DistinctValue);
            Assert.Empty(select.SourceCollection);
            Assert.Null(select.WhereCondition);
            Assert.Empty(select.JoinCollection);
            Assert.Null(select.HavingCondition);
            Assert.Empty(select.OrderByCollection);
            Assert.Empty(select.GroupByCollection);
            Assert.False(select.OffsetValue.HasValue);
            Assert.False(select.LimitValue.HasValue);
        }

        [Fact]
        public void Constructor_NullIColumnParams_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Select((IColumn[])null!));
        }

        [Fact]
        public void Constructor_IColumnEnumerable_Success()
        {
            // Arrange
            List<IColumn> columns = NewColumns(length: 2);
            
            // Act
            Select select = new Select(columns);

            // Assert
            Assert.Equal(columns, select.ColumnCollection);
            Assert.Null(select.DistinctValue);
            Assert.Empty(select.SourceCollection);
            Assert.Null(select.WhereCondition);
            Assert.Empty(select.JoinCollection);
            Assert.Null(select.HavingCondition);
            Assert.Empty(select.OrderByCollection);
            Assert.Empty(select.GroupByCollection);
            Assert.False(select.OffsetValue.HasValue);
            Assert.False(select.LimitValue.HasValue);
        }

        [Fact]
        public void Constructor_EmptyIColumnEnumerable_Success()
        {
            // Act
            Select select = new Select((IEnumerable<IColumn>)Array.Empty<IColumn>());

            // Assert
            Assert.Empty(select.ColumnCollection);
            Assert.Null(select.DistinctValue);
            Assert.Empty(select.SourceCollection);
            Assert.Null(select.WhereCondition);
            Assert.Empty(select.JoinCollection);
            Assert.Null(select.HavingCondition);
            Assert.Empty(select.OrderByCollection);
            Assert.Empty(select.GroupByCollection);
            Assert.False(select.OffsetValue.HasValue);
            Assert.False(select.LimitValue.HasValue);
        }

        [Fact]
        public void Constructor_NullIColumnEnumerable_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Select((IEnumerable<IColumn>)null!));
        }

        [Fact]
		public void Distinct_SetDistinctValue()
        {
            // Arrange
            Select select = new Select(NewColumns(3));

            // Act
            select.Distinct();

            // Assert
            Assert.NotNull(select.DistinctValue);
            Assert.IsType<Distinct>(select.DistinctValue);
        }

        [Fact]
        public void Distinct_IDistinct_SetDistinctValue() =>
            Distinct_IDistinct_SetDistinctValue_Base(NewDistinct());

        [Fact]
        public void Distinct_NullIDistinct_SetDistinctValue() =>
            Distinct_IDistinct_SetDistinctValue_Base(distinct: null);

        private void Constructor_StringAndISource_Success_Base(string name, ISource? source)
        {
            // Act
            Select select = new Select(name, source);

            // Assert
            IColumn column = Assert.Single(select.ColumnCollection);
            SourceColumn sourceColumn = Assert.IsType<SourceColumn>(column);
            Assert.Equal(name, sourceColumn.Name);
            Assert.Null(sourceColumn.Alias);

			if (source == null)
			{
				Assert.Null(sourceColumn.Source);
			}
			else
			{
				Assert.Equal(source, sourceColumn.Source);
			}

            Assert.Null(select.DistinctValue);
            Assert.Empty(select.SourceCollection);
            Assert.Null(select.WhereCondition);
            Assert.Empty(select.JoinCollection);
            Assert.Null(select.HavingCondition);
            Assert.Empty(select.OrderByCollection);
            Assert.Empty(select.GroupByCollection);
            Assert.False(select.OffsetValue.HasValue);
            Assert.False(select.LimitValue.HasValue);
        }

        private void Constructor_StringAndISource_ThrowsArgumentException(string? name, ISource? source)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Select(name!, source));
        }

        private void Constructor_StringAndStringAndISource_Success_Base(string name, string? alias, ISource? source)
        {
            // Act
            Select select = new Select(name, alias, source);

            // Assert
            IColumn column = Assert.Single(select.ColumnCollection);
            SourceColumn sourceColumn = Assert.IsType<SourceColumn>(column);
            Assert.Equal(name, sourceColumn.Name);

			if (string.IsNullOrEmpty(alias))
			{
				Assert.Null(sourceColumn.Alias);
			}
			else
			{
				Assert.Equal(alias, sourceColumn.Alias);
			}

            if (source == null)
            {
                Assert.Null(sourceColumn.Source);
            }
            else
            {
                Assert.Equal(source, sourceColumn.Source);
            }

            Assert.Null(select.DistinctValue);
            Assert.Empty(select.SourceCollection);
            Assert.Null(select.WhereCondition);
            Assert.Empty(select.JoinCollection);
            Assert.Null(select.HavingCondition);
            Assert.Empty(select.OrderByCollection);
            Assert.Empty(select.GroupByCollection);
            Assert.False(select.OffsetValue.HasValue);
            Assert.False(select.LimitValue.HasValue);
        }

        private void Constructor_StringAndStringAndISource_ThrowsArgumentException(string? name, string? alias, ISource? source)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Select(name!, alias, source));
        }

        private void Distinct_IDistinct_SetDistinctValue_Base(IDistinct? distinct)
        {
            // Arrange
            Select select = new Select(NewColumns(3));

            // Act
            select.Distinct(distinct);

            // Assert
            if (distinct == null)
            {
                Assert.Null(select.DistinctValue);
            }
            else
            {
                Assert.Equal(distinct, select.DistinctValue);
            }
        }

        [Fact]
        public void RenderQuery_RendererAndSql_WritesSqlToSql()
        {
            // Arrange
            Select query = new Select("test_name");

            const string expectedSql = "test_sql";

            Mock<IRenderer> rendererMock = new Mock<IRenderer>();
            rendererMock.Setup(ca => ca.RenderQuery(It.IsAny<Select>(), It.IsAny<StringBuilder>()))
                .Callback((Select query, StringBuilder sql) => sql.Append(expectedSql));

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
            Select query = new Select("test_name");

            const string expectedSql = "test_sql";

            Mock<IRenderer> rendererMock = new Mock<IRenderer>();
            rendererMock.Setup(ca => ca.RenderQuery(It.IsAny<Select>(), It.IsAny<StringBuilder>()))
                .Callback((Select query, StringBuilder sql) => sql.Append(expectedSql));

            IRenderer renderer = rendererMock.Object;

            // Act
            string sql = query.RenderQuery(renderer);

            // Assert
            Assert.Equal(expectedSql, sql.ToString());
        }

        [Fact]
        public void RenderExpression_RendererAndSql_WritesSqlToSql()
        {
            // Arrange
            Select query = new Select("test_name");

            const string expectedSql = "test_sql";

            Mock<IRenderer> rendererMock = new Mock<IRenderer>();
            rendererMock.Setup(ca => ca.RenderExpression(It.IsAny<Select>(), It.IsAny<StringBuilder>()))
                .Callback((Select query, StringBuilder sql) => sql.Append(expectedSql));

            IRenderer renderer = rendererMock.Object;
            StringBuilder sql = new StringBuilder();

            // Act
            query.RenderExpression(renderer, sql);

            // Assert
            Assert.Equal(expectedSql, sql.ToString());
        }

        [Fact]
        public void RenderExpression_Renderer_ReturnsSql()
        {
            // Arrange
            Select query = new Select("test_name");

            const string expectedSql = "test_sql";

            Mock<IRenderer> rendererMock = new Mock<IRenderer>();
            rendererMock.Setup(ca => ca.RenderExpression(It.IsAny<Select>(), It.IsAny<StringBuilder>()))
                .Callback((Select query, StringBuilder sql) => sql.Append(expectedSql));

            IRenderer renderer = rendererMock.Object;

            // Act
            string sql = query.RenderExpression(renderer);

            // Assert
            Assert.Equal(expectedSql, sql.ToString());
        }
    }
}
