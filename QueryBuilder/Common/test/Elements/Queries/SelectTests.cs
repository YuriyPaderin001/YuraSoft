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

        [Fact]
        public void From_Table_SetSourceCollection()
        {
            // Arrange
            const string tableName = "test_table";

            Select select = new Select(Array.Empty<IColumn>());

            // Act
            select.From(tableName);

            // Assert
            Assert.Empty(select.ColumnCollection);
            Assert.Null(select.DistinctValue);
            Assert.Single(select.SourceCollection);

            Table table = Assert.IsType<Table>(select.SourceCollection[0]);
            Assert.Equal(tableName, table.Name);

            Assert.Null(select.WhereCondition);
            Assert.Empty(select.JoinCollection);
            Assert.Null(select.HavingCondition);
            Assert.Empty(select.OrderByCollection);
            Assert.Empty(select.GroupByCollection);
            Assert.False(select.OffsetValue.HasValue);
            Assert.False(select.LimitValue.HasValue);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("test_schema")]
        public void From_TableAndSchema_SetSourceCollection(string? tableSchema)
        {
            // Arrange
            const string tableName = "test_table";

            Select query = new Select(Array.Empty<IColumn>());

            // Act
            query.From(tableName, tableSchema);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Single(query.SourceCollection);

            Table table = Assert.IsType<Table>(query.SourceCollection[0]);
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

            Assert.Null(query.WhereCondition);
            Assert.Empty(query.JoinCollection);
            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void From_SelectAndAlias_SetSourceCollection()
        {
            // Arrange
            Select subquery = new Select("test_column");
            const string alias = "test_subquery";

            Select query = new Select(Array.Empty<IColumn>());

            // Act
            query.From(subquery, alias);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Single(query.SourceCollection);

            Subquery source = Assert.IsType<Subquery>(query.SourceCollection[0]);
            Assert.Equal(subquery, source.Select);
            Assert.Equal(alias, source.Alias);

            Assert.Null(query.WhereCondition);
            Assert.Empty(query.JoinCollection);
            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        public void From_TablesAsParams_SetSourceCollection(int tablesCount)
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            string[] tables = new string[tablesCount];
            for (int i = 0; i < tablesCount; i++)
            {
                tables[i] = $"table_{i + 1}_name";
            }

            // Act
            query.From(tables);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);

            Assert.Equal(tablesCount, query.SourceCollection.Count);

            for (int i = 0; i < tablesCount; i++)
            {
                Table table = Assert.IsType<Table>(query.SourceCollection[i]);

                Assert.Equal(tables[i], table.Name);
            }

            Assert.Null(query.WhereCondition);
            Assert.Empty(query.JoinCollection);
            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        public void From_TablesAsEnumerable_SetSourceCollection(int tablesCount)
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());
            
            string[] tables = new string[tablesCount];
            for (int i = 0; i < tablesCount; i++)
            {
                tables[i] = $"table_{i + 1}_name";
            }

            // Act
            query.From((IEnumerable<string>)tables);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);

            Assert.Equal(tablesCount, query.SourceCollection.Count);

            for (int i = 0; i < tablesCount; i++)
            {
                Table table = Assert.IsType<Table>(query.SourceCollection[i]);

                Assert.Equal(tables[i], table.Name);
            }

            Assert.Null(query.WhereCondition);
            Assert.Empty(query.JoinCollection);
            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        public void From_SourcesAsParams_SetSourceCollection(int sourcesCount)
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());
            List<ISource> sources = NewSources(sourcesCount);

            // Act
            query.From(sources.ToArray());

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Equal(sources, query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Empty(query.JoinCollection);
            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        public void From_SourcesAsEnumerable_SetSourceCollection(int sourcesCount)
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());
            List<ISource> sources = NewSources(sourcesCount);

            // Act
            query.From(sources);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Equal(sources, query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Empty(query.JoinCollection);
            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void From_NullOrEmptyTable_ThrowsArgumentException(string? table) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).From(table!));

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData("", null)]
        [InlineData("", "")]
        public void From_NullOrEmptyTableAndSchema_ThrowsArgumentException(string? table, string? schema) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).From(table!, schema));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("test_alias")]
        public void From_NullSelectAndAlias_ThrowsArgumentNullException(string? alias) =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).From(select: null!, alias!));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void From_SelectAndNullOrEmptyAlias_ThrowsArgumentException(string? alias) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).From(new Select(Array.Empty<IColumn>()), alias!));

        [Fact]
        public void From_NullSource_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).From(source: null!));

        [Fact]
        public void From_NullTableNamesAsParams_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).From((string[])null!));

        [Fact]
        public void From_NullTableNamesAsEnumerable_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).From((IEnumerable<string>)null!));

        [Fact]
        public void From_NullTablesAsParams_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).From((ISource[])null!));

        [Fact]
        public void From_NullTablesAsEnumerable_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).From((IEnumerable<ISource>)null!));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void From_TableNamesAsParamsWithNullOrEmptyItems_ThrowsArgumentException(string? invalidTableName) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).From(new string[] { "test_table_1", "test_table_2", invalidTableName! }));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void From_TableNamesAsEnumerableWithNullOrEmptyItems_ThrowsArgumentException(string? invalidTableName) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).From(new List<string> { "test_table_1", invalidTableName!, "test_table_3" }));

        [Fact]
        public void From_TablesAsParamsWithNullItems_ThrowsArgumentException() =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).From(new ISource[] { NewSource(), NewSource(), null! }));

        [Fact]
        public void From_TablesAsEnumerableWithNullItems_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).From(new List<ISource> { NewSource(), NewSource(), null! }));

        [Fact]
        public void Where_Condition_SetWhereCondition()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());
            ICondition condition = new Mock<ICondition>().Object;

            // Act
            query.Where(condition);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Equal(condition, query.WhereCondition);
            Assert.Empty(query.JoinCollection);
            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void Where_NullCondition_SetWhereCondition()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>()).Where(new Mock<ICondition>().Object);

            // Act
            query.Where(condition: null);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Empty(query.JoinCollection);
            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void Where_ConditionAction_SetWhereCondition()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());
            ICondition condition = new Mock<ICondition>().Object;
            Action<ConditionBuilder> conditionAction = (cb) => cb.Condition(condition);

            // Act
            query.Where(conditionAction);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Equal(condition, query.WhereCondition);
            Assert.Empty(query.JoinCollection);
            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void Where_NullConditionAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).Where(conditionAction: null!));

        [Fact]
        public void LeftJoin_LeftTableAndRightTableAndJoinAction_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            const string leftTableName = "left_test_table";
            const string rightTableName = "right_test_table";

            const string leftColumnName = "left_test_column";
            const string rightColumnName = "right_test_column";

            Action<ConditionBuilder, ISource, ISource> action = (c, l, r) => c.Equal(leftColumnName, l, rightColumnName, r);

            // Act
            query.LeftJoin(leftTableName, rightTableName, action);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);

            Assert.Single(query.JoinCollection);
            LeftJoin join = Assert.IsType<LeftJoin>(query.JoinCollection[0]);
            Table table = Assert.IsType<Table>(join.Source);

            Assert.Equal(rightTableName, table.Name);
            Assert.Null(table.Alias);
            Assert.Null(table.Schema);

            EqualCondition condition = Assert.IsType<EqualCondition>(join.Condition);
            
            SourceColumn leftColumn = Assert.IsType<SourceColumn>(condition.LeftExpression);
            Assert.Equal(leftColumnName, leftColumn.Name);
            Assert.Null(leftColumn.Alias);

            Table leftColumnTable = Assert.IsType<Table>(leftColumn.Source);
            Assert.Equal(leftTableName, leftColumnTable.Name);
            Assert.Null(leftColumnTable.Alias);
            Assert.Null(leftColumnTable.Schema);

            SourceColumn rightColumn = Assert.IsType<SourceColumn>(condition.RightExpression);
            Assert.Equal(rightColumnName, rightColumn.Name);
            Assert.Null(rightColumn.Alias);

            Table rightColumnTable = Assert.IsType<Table>(rightColumn.Source);
            Assert.Equal(rightTableName, rightColumnTable.Name);
            Assert.Null(rightColumnTable.Alias);
            Assert.Null(rightColumnTable.Schema);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void LeftJoin_TableAndJoinAction_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            const string tableName = "right_test_table";
            Action<ConditionBuilder> joinAction = (cb) => cb.Equal("test_column1", "test_column2");

            // Act
            query.LeftJoin(tableName, joinAction);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);

            Assert.Single(query.JoinCollection);
            LeftJoin join = Assert.IsType<LeftJoin>(query.JoinCollection[0]);
            Table table = Assert.IsType<Table>(join.Source);

            Assert.Equal(tableName, table.Name);

            EqualCondition condition = Assert.IsType<EqualCondition>(join.Condition);
            
            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void LeftJoin_TableAndCondition_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            const string tableName = "right_test_table";
            ICondition condition = new Mock<ICondition>().Object;

            // Act
            query.LeftJoin(tableName, condition);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Single(query.JoinCollection);
            
            LeftJoin join = Assert.IsType<LeftJoin>(query.JoinCollection[0]);
            
            Table table = Assert.IsType<Table>(join.Source);
            Assert.Equal(tableName, table.Name);
            Assert.Null(table.Alias);
            Assert.Null(table.Schema);
            
            Assert.Equal(condition, join.Condition);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void LeftJoin_LeftSourceAndRightSourceAndJoinAction_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            ISource leftSource = NewSource();
            ISource rightSource = NewSource();

            const string leftColumnName = "left_test_column";
            const string rightColumnName = "right_test_column";

            Action<ConditionBuilder, ISource, ISource> joinAction = (c, l, r) => c.Equal(leftColumnName, l, rightColumnName, r);

            // Act
            query.LeftJoin(leftSource, rightSource, joinAction);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Single(query.JoinCollection);

            LeftJoin join = Assert.IsType<LeftJoin>(query.JoinCollection[0]);
            Assert.Equal(rightSource, join.Source);

            EqualCondition condition = Assert.IsType<EqualCondition>(join.Condition);

            SourceColumn leftColumn = Assert.IsType<SourceColumn>(condition.LeftExpression);
            Assert.Equal(leftColumnName, leftColumn.Name);
            Assert.Null(leftColumn.Alias);
            Assert.Equal(leftSource, leftColumn.Source);

            SourceColumn rightColumn = Assert.IsType<SourceColumn>(condition.RightExpression);
            Assert.Equal(rightColumnName, rightColumn.Name);
            Assert.Null(rightColumn.Alias);
            Assert.Equal(rightSource, rightColumn.Source);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void LeftJoin_SourceAndJoinAction_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            ISource source = NewSource();
            ICondition condition = NewCondition();

            // Act
            query.LeftJoin(source, c => c.Condition(condition));

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Single(query.JoinCollection);

            LeftJoin join = Assert.IsType<LeftJoin>(query.JoinCollection[0]);
            Assert.Equal(source, join.Source);
            Assert.Equal(condition, join.Condition);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void LeftJoin_SourceAndCondition_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            ISource source = NewSource();
            ICondition condition = NewCondition();

            // Act
            query.LeftJoin(source, condition);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Single(query.JoinCollection);

            LeftJoin join = Assert.IsType<LeftJoin>(query.JoinCollection[0]);
            Assert.Equal(source, join.Source);
            Assert.Equal(condition, join.Condition);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData(null, "right_table")]
        [InlineData("", null)]
        [InlineData("", "")]
        [InlineData("", "right_table")]
        [InlineData("left_table", null)]
        [InlineData("left_table", "")]
        public void LeftJoin_NullOrEmptyLeftTableOrNullOrEmptyRightTableAndJoinAction_ThrowsArgumentException(string? leftTable, string? rightTable) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).LeftJoin(leftTable!, rightTable!, (c, l, r) => c.Equal("left_column", l, "right_column", r)));

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData(null, "right_table")]
        [InlineData("", null)]
        [InlineData("", "")]
        [InlineData("", "right_table")]
        [InlineData("left_table", null)]
        [InlineData("left_table", "")]
        public void LeftJoin_NullOrEmptyLeftTableOrNullOrEmptyRightTableAndNullJoinAction_ThrowsArgumentException(string? leftTable, string? rightTable) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).LeftJoin(leftTable!, rightTable!, joinAction: null!));

        [Fact]
        public void LeftJoin_LeftTableAndRightTableAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).LeftJoin("left_table", "right_table", joinAction: null!));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void LeftJoin_NullOrEmptyTableAndJoinAction_ThrowsArgumentException(string? table) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).LeftJoin(table!, c => c.Condition(NewCondition())));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void LeftJoin_NullOrEmptyTableAndNullJoinAction_ThrowsArgumentNullException(string? table) =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).LeftJoin(table!, joinAction: null!));

        [Fact]
        public void LeftJoin_TableAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).LeftJoin("table", joinAction: null!));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void LeftJoin_NullOrEmptyTableAndCondition_ThrowsArgumentException(string? table) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).LeftJoin(table!, NewCondition()));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void LeftJoin_NullOrEmptyTableAndNullCondition_ThrowsArgumentException(string? table) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).LeftJoin(table!, condition: null!));

        [Fact]
        public void LeftJoin_NullLeftSourceAndNullRightSourceAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).LeftJoin(leftSource: null!, rightSource: null!, joinAction: null!));

        [Fact]
        public void LeftJoin_NullLeftSourceAndNullRightSourceAndJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).LeftJoin(leftSource: null!, rightSource: null!, (c, l, r) => c.Equal("left_column", l, "right_column", r)));

        [Fact]
        public void LeftJoin_NullLeftSourceAndRightSourceAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).LeftJoin(leftSource: null!, NewSource(), joinAction: null!));

        [Fact]
        public void LeftJoin_NullLeftSourceAndRightSourceAndJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).LeftJoin(leftSource: null!, NewSource(), (c, l, r) => c.Equal("left_column", l, "right_column", r)));

        [Fact]
        public void LeftJoin_LeftSourceAndNullRightSourceAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).LeftJoin(NewSource(), rightSource: null!, joinAction: null!));

        [Fact]
        public void LeftJoin_LeftSourceAndNullRightSourceAndJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).LeftJoin(NewSource(), rightSource: null!, (c, l, r) => c.Equal("left_column", l, "right_column", r)));

        [Fact]
        public void LeftJoin_LeftSourceAndRightSourceAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).LeftJoin(NewSource(), NewSource(), joinAction: null!));

        [Fact]
        public void RightJoin_LeftTableAndRightTableAndJoinAction_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            const string leftTableName = "left_test_table";
            const string rightTableName = "right_test_table";

            const string leftColumnName = "left_test_column";
            const string rightColumnName = "right_test_column";

            Action<ConditionBuilder, ISource, ISource> action = (c, l, r) => c.Equal(leftColumnName, l, rightColumnName, r);

            // Act
            query.RightJoin(leftTableName, rightTableName, action);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);

            Assert.Single(query.JoinCollection);
            RightJoin join = Assert.IsType<RightJoin>(query.JoinCollection[0]);
            Table table = Assert.IsType<Table>(join.Source);

            Assert.Equal(rightTableName, table.Name);
            Assert.Null(table.Alias);
            Assert.Null(table.Schema);

            EqualCondition condition = Assert.IsType<EqualCondition>(join.Condition);

            SourceColumn leftColumn = Assert.IsType<SourceColumn>(condition.LeftExpression);
            Assert.Equal(leftColumnName, leftColumn.Name);
            Assert.Null(leftColumn.Alias);

            Table leftColumnTable = Assert.IsType<Table>(leftColumn.Source);
            Assert.Equal(leftTableName, leftColumnTable.Name);
            Assert.Null(leftColumnTable.Alias);
            Assert.Null(leftColumnTable.Schema);

            SourceColumn rightColumn = Assert.IsType<SourceColumn>(condition.RightExpression);
            Assert.Equal(rightColumnName, rightColumn.Name);
            Assert.Null(rightColumn.Alias);

            Table rightColumnTable = Assert.IsType<Table>(rightColumn.Source);
            Assert.Equal(rightTableName, rightColumnTable.Name);
            Assert.Null(rightColumnTable.Alias);
            Assert.Null(rightColumnTable.Schema);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void RightJoin_TableAndJoinAction_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            const string tableName = "right_test_table";
            Action<ConditionBuilder> joinAction = (cb) => cb.Equal("test_column1", "test_column2");

            // Act
            query.RightJoin(tableName, joinAction);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);

            Assert.Single(query.JoinCollection);
            RightJoin join = Assert.IsType<RightJoin>(query.JoinCollection[0]);
            Table table = Assert.IsType<Table>(join.Source);

            Assert.Equal(tableName, table.Name);

            EqualCondition condition = Assert.IsType<EqualCondition>(join.Condition);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void RightJoin_TableAndCondition_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            const string tableName = "right_test_table";
            ICondition condition = new Mock<ICondition>().Object;

            // Act
            query.RightJoin(tableName, condition);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Single(query.JoinCollection);

            RightJoin join = Assert.IsType<RightJoin>(query.JoinCollection[0]);

            Table table = Assert.IsType<Table>(join.Source);
            Assert.Equal(tableName, table.Name);
            Assert.Null(table.Alias);
            Assert.Null(table.Schema);

            Assert.Equal(condition, join.Condition);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void RightJoin_LeftSourceAndRightSourceAndJoinAction_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            ISource leftSource = NewSource();
            ISource rightSource = NewSource();

            const string leftColumnName = "left_test_column";
            const string rightColumnName = "right_test_column";

            Action<ConditionBuilder, ISource, ISource> joinAction = (c, l, r) => c.Equal(leftColumnName, l, rightColumnName, r);

            // Act
            query.RightJoin(leftSource, rightSource, joinAction);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Single(query.JoinCollection);

            RightJoin join = Assert.IsType<RightJoin>(query.JoinCollection[0]);
            Assert.Equal(rightSource, join.Source);

            EqualCondition condition = Assert.IsType<EqualCondition>(join.Condition);

            SourceColumn leftColumn = Assert.IsType<SourceColumn>(condition.LeftExpression);
            Assert.Equal(leftColumnName, leftColumn.Name);
            Assert.Null(leftColumn.Alias);
            Assert.Equal(leftSource, leftColumn.Source);

            SourceColumn rightColumn = Assert.IsType<SourceColumn>(condition.RightExpression);
            Assert.Equal(rightColumnName, rightColumn.Name);
            Assert.Null(rightColumn.Alias);
            Assert.Equal(rightSource, rightColumn.Source);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void RightJoin_SourceAndJoinAction_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            ISource source = NewSource();
            ICondition condition = NewCondition();

            // Act
            query.RightJoin(source, c => c.Condition(condition));

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Single(query.JoinCollection);

            RightJoin join = Assert.IsType<RightJoin>(query.JoinCollection[0]);
            Assert.Equal(source, join.Source);
            Assert.Equal(condition, join.Condition);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void RightJoin_SourceAndCondition_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            ISource source = NewSource();
            ICondition condition = NewCondition();

            // Act
            query.RightJoin(source, condition);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Single(query.JoinCollection);

            RightJoin join = Assert.IsType<RightJoin>(query.JoinCollection[0]);
            Assert.Equal(source, join.Source);
            Assert.Equal(condition, join.Condition);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData(null, "right_table")]
        [InlineData("", null)]
        [InlineData("", "")]
        [InlineData("", "right_table")]
        [InlineData("left_table", null)]
        [InlineData("left_table", "")]
        public void RightJoin_NullOrEmptyLeftTableOrNullOrEmptyRightTableAndJoinAction_ThrowsArgumentException(string? leftTable, string? rightTable) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).RightJoin(leftTable!, rightTable!, (c, l, r) => c.Equal("left_column", l, "right_column", r)));

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData(null, "right_table")]
        [InlineData("", null)]
        [InlineData("", "")]
        [InlineData("", "right_table")]
        [InlineData("left_table", null)]
        [InlineData("left_table", "")]
        public void RightJoin_NullOrEmptyLeftTableOrNullOrEmptyRightTableAndNullJoinAction_ThrowsArgumentException(string? leftTable, string? rightTable) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).RightJoin(leftTable!, rightTable!, joinAction: null!));

        [Fact]
        public void RightJoin_LeftTableAndRightTableAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).RightJoin("left_table", "right_table", joinAction: null!));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void RightJoin_NullOrEmptyTableAndJoinAction_ThrowsArgumentException(string? table) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).RightJoin(table!, c => c.Condition(NewCondition())));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void RightJoin_NullOrEmptyTableAndNullJoinAction_ThrowsArgumentNullException(string? table) =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).RightJoin(table!, joinAction: null!));

        [Fact]
        public void RightJoin_TableAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).RightJoin("table", joinAction: null!));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void RightJoin_NullOrEmptyTableAndCondition_ThrowsArgumentException(string? table) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).RightJoin(table!, NewCondition()));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void RightJoin_NullOrEmptyTableAndNullCondition_ThrowsArgumentException(string? table) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).RightJoin(table!, condition: null!));

        [Fact]
        public void RightJoin_TableAndNullCondition_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).RightJoin("table", condition: null!));


        [Fact]
        public void RightJoin_NullLeftSourceAndNullRightSourceAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).RightJoin(leftSource: null!, rightSource: null!, joinAction: null!));

        [Fact]
        public void RightJoin_NullLeftSourceAndNullRightSourceAndJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).RightJoin(leftSource: null!, rightSource: null!, (c, l, r) => c.Equal("left_column", l, "right_column", r)));

        [Fact]
        public void RightJoin_NullLeftSourceAndRightSourceAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).RightJoin(leftSource: null!, NewSource(), joinAction: null!));

        [Fact]
        public void RightJoin_NullLeftSourceAndRightSourceAndJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).RightJoin(leftSource: null!, NewSource(), (c, l, r) => c.Equal("left_column", l, "right_column", r)));

        [Fact]
        public void RightJoin_LeftSourceAndNullRightSourceAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).RightJoin(NewSource(), rightSource: null!, joinAction: null!));

        [Fact]
        public void RightJoin_LeftSourceAndNullRightSourceAndJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).RightJoin(NewSource(), rightSource: null!, (c, l, r) => c.Equal("left_column", l, "right_column", r)));

        [Fact]
        public void RightJoin_LeftSourceAndRightSourceAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).RightJoin(NewSource(), NewSource(), joinAction: null!));

        [Fact]
        public void InnerJoin_LeftTableAndRightTableAndJoinAction_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            const string leftTableName = "left_test_table";
            const string rightTableName = "right_test_table";

            const string leftColumnName = "left_test_column";
            const string rightColumnName = "right_test_column";

            Action<ConditionBuilder, ISource, ISource> action = (c, l, r) => c.Equal(leftColumnName, l, rightColumnName, r);

            // Act
            query.InnerJoin(leftTableName, rightTableName, action);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);

            Assert.Single(query.JoinCollection);
            InnerJoin join = Assert.IsType<InnerJoin>(query.JoinCollection[0]);
            Table table = Assert.IsType<Table>(join.Source);

            Assert.Equal(rightTableName, table.Name);
            Assert.Null(table.Alias);
            Assert.Null(table.Schema);

            EqualCondition condition = Assert.IsType<EqualCondition>(join.Condition);

            SourceColumn leftColumn = Assert.IsType<SourceColumn>(condition.LeftExpression);
            Assert.Equal(leftColumnName, leftColumn.Name);
            Assert.Null(leftColumn.Alias);

            Table leftColumnTable = Assert.IsType<Table>(leftColumn.Source);
            Assert.Equal(leftTableName, leftColumnTable.Name);
            Assert.Null(leftColumnTable.Alias);
            Assert.Null(leftColumnTable.Schema);

            SourceColumn rightColumn = Assert.IsType<SourceColumn>(condition.RightExpression);
            Assert.Equal(rightColumnName, rightColumn.Name);
            Assert.Null(rightColumn.Alias);

            Table rightColumnTable = Assert.IsType<Table>(rightColumn.Source);
            Assert.Equal(rightTableName, rightColumnTable.Name);
            Assert.Null(rightColumnTable.Alias);
            Assert.Null(rightColumnTable.Schema);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void InnerJoin_TableAndJoinAction_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            const string tableName = "right_test_table";
            Action<ConditionBuilder> joinAction = (cb) => cb.Equal("test_column1", "test_column2");

            // Act
            query.InnerJoin(tableName, joinAction);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);

            Assert.Single(query.JoinCollection);
            InnerJoin join = Assert.IsType<InnerJoin>(query.JoinCollection[0]);
            Table table = Assert.IsType<Table>(join.Source);

            Assert.Equal(tableName, table.Name);

            EqualCondition condition = Assert.IsType<EqualCondition>(join.Condition);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void InnerJoin_TableAndCondition_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            const string tableName = "right_test_table";
            ICondition condition = new Mock<ICondition>().Object;

            // Act
            query.InnerJoin(tableName, condition);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Single(query.JoinCollection);

            InnerJoin join = Assert.IsType<InnerJoin>(query.JoinCollection[0]);

            Table table = Assert.IsType<Table>(join.Source);
            Assert.Equal(tableName, table.Name);
            Assert.Null(table.Alias);
            Assert.Null(table.Schema);

            Assert.Equal(condition, join.Condition);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void InnerJoin_LeftSourceAndRightSourceAndJoinAction_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            ISource leftSource = NewSource();
            ISource rightSource = NewSource();

            const string leftColumnName = "left_test_column";
            const string rightColumnName = "right_test_column";

            Action<ConditionBuilder, ISource, ISource> joinAction = (c, l, r) => c.Equal(leftColumnName, l, rightColumnName, r);

            // Act
            query.InnerJoin(leftSource, rightSource, joinAction);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Single(query.JoinCollection);

            InnerJoin join = Assert.IsType<InnerJoin>(query.JoinCollection[0]);
            Assert.Equal(rightSource, join.Source);

            EqualCondition condition = Assert.IsType<EqualCondition>(join.Condition);

            SourceColumn leftColumn = Assert.IsType<SourceColumn>(condition.LeftExpression);
            Assert.Equal(leftColumnName, leftColumn.Name);
            Assert.Null(leftColumn.Alias);
            Assert.Equal(leftSource, leftColumn.Source);

            SourceColumn rightColumn = Assert.IsType<SourceColumn>(condition.RightExpression);
            Assert.Equal(rightColumnName, rightColumn.Name);
            Assert.Null(rightColumn.Alias);
            Assert.Equal(rightSource, rightColumn.Source);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void InnerJoin_SourceAndJoinAction_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            ISource source = NewSource();
            ICondition condition = NewCondition();

            // Act
            query.InnerJoin(source, c => c.Condition(condition));

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Single(query.JoinCollection);

            InnerJoin join = Assert.IsType<InnerJoin>(query.JoinCollection[0]);
            Assert.Equal(source, join.Source);
            Assert.Equal(condition, join.Condition);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void InnerJoin_SourceAndCondition_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            ISource source = NewSource();
            ICondition condition = NewCondition();

            // Act
            query.InnerJoin(source, condition);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Single(query.JoinCollection);

            InnerJoin join = Assert.IsType<InnerJoin>(query.JoinCollection[0]);
            Assert.Equal(source, join.Source);
            Assert.Equal(condition, join.Condition);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData(null, "right_table")]
        [InlineData("", null)]
        [InlineData("", "")]
        [InlineData("", "right_table")]
        [InlineData("left_table", null)]
        [InlineData("left_table", "")]
        public void InnerJoin_NullOrEmptyLeftTableOrNullOrEmptyRightTableAndJoinAction_ThrowsArgumentException(string? leftTable, string? rightTable) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).InnerJoin(leftTable!, rightTable!, (c, l, r) => c.Equal("left_column", l, "right_column", r)));

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData(null, "right_table")]
        [InlineData("", null)]
        [InlineData("", "")]
        [InlineData("", "right_table")]
        [InlineData("left_table", null)]
        [InlineData("left_table", "")]
        public void InnerJoin_NullOrEmptyLeftTableOrNullOrEmptyRightTableAndNullJoinAction_ThrowsArgumentException(string? leftTable, string? rightTable) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).InnerJoin(leftTable!, rightTable!, joinAction: null!));

        [Fact]
        public void InnerJoin_LeftTableAndRightTableAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).InnerJoin("left_table", "right_table", joinAction: null!));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void InnerJoin_NullOrEmptyTableAndJoinAction_ThrowsArgumentException(string? table) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).InnerJoin(table!, c => c.Condition(NewCondition())));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void InnerJoin_NullOrEmptyTableAndNullJoinAction_ThrowsArgumentNullException(string? table) =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).InnerJoin(table!, joinAction: null!));

        [Fact]
        public void InnerJoin_TableAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).InnerJoin("table", joinAction: null!));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void InnerJoin_NullOrEmptyTableAndCondition_ThrowsArgumentException(string? table) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).InnerJoin(table!, NewCondition()));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void InnerJoin_NullOrEmptyTableAndNullCondition_ThrowsArgumentException(string? table) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).InnerJoin(table!, condition: null!));

        [Fact]
        public void InnerJoin_TableAndNullCondition_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).InnerJoin("table", condition: null!));


        [Fact]
        public void InnerJoin_NullLeftSourceAndNullRightSourceAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).InnerJoin(leftSource: null!, rightSource: null!, joinAction: null!));

        [Fact]
        public void InnerJoin_NullLeftSourceAndNullRightSourceAndJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).InnerJoin(leftSource: null!, rightSource: null!, (c, l, r) => c.Equal("left_column", l, "right_column", r)));

        [Fact]
        public void InnerJoin_NullLeftSourceAndRightSourceAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).InnerJoin(leftSource: null!, NewSource(), joinAction: null!));

        [Fact]
        public void InnerJoin_NullLeftSourceAndRightSourceAndJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).InnerJoin(leftSource: null!, NewSource(), (c, l, r) => c.Equal("left_column", l, "right_column", r)));

        [Fact]
        public void InnerJoin_LeftSourceAndNullRightSourceAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).InnerJoin(NewSource(), rightSource: null!, joinAction: null!));

        [Fact]
        public void InnerJoin_LeftSourceAndNullRightSourceAndJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).InnerJoin(NewSource(), rightSource: null!, (c, l, r) => c.Equal("left_column", l, "right_column", r)));

        [Fact]
        public void InnerJoin_LeftSourceAndRightSourceAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).InnerJoin(NewSource(), NewSource(), joinAction: null!));

        [Fact]
        public void FullJoin_LeftTableAndRightTableAndJoinAction_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            const string leftTableName = "left_test_table";
            const string rightTableName = "right_test_table";

            const string leftColumnName = "left_test_column";
            const string rightColumnName = "right_test_column";

            Action<ConditionBuilder, ISource, ISource> action = (c, l, r) => c.Equal(leftColumnName, l, rightColumnName, r);

            // Act
            query.FullJoin(leftTableName, rightTableName, action);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);

            Assert.Single(query.JoinCollection);
            FullJoin join = Assert.IsType<FullJoin>(query.JoinCollection[0]);
            Table table = Assert.IsType<Table>(join.Source);

            Assert.Equal(rightTableName, table.Name);
            Assert.Null(table.Alias);
            Assert.Null(table.Schema);

            EqualCondition condition = Assert.IsType<EqualCondition>(join.Condition);

            SourceColumn leftColumn = Assert.IsType<SourceColumn>(condition.LeftExpression);
            Assert.Equal(leftColumnName, leftColumn.Name);
            Assert.Null(leftColumn.Alias);

            Table leftColumnTable = Assert.IsType<Table>(leftColumn.Source);
            Assert.Equal(leftTableName, leftColumnTable.Name);
            Assert.Null(leftColumnTable.Alias);
            Assert.Null(leftColumnTable.Schema);

            SourceColumn rightColumn = Assert.IsType<SourceColumn>(condition.RightExpression);
            Assert.Equal(rightColumnName, rightColumn.Name);
            Assert.Null(rightColumn.Alias);

            Table rightColumnTable = Assert.IsType<Table>(rightColumn.Source);
            Assert.Equal(rightTableName, rightColumnTable.Name);
            Assert.Null(rightColumnTable.Alias);
            Assert.Null(rightColumnTable.Schema);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void FullJoin_TableAndJoinAction_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            const string tableName = "right_test_table";
            Action<ConditionBuilder> joinAction = (cb) => cb.Equal("test_column1", "test_column2");

            // Act
            query.FullJoin(tableName, joinAction);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);

            Assert.Single(query.JoinCollection);
            FullJoin join = Assert.IsType<FullJoin>(query.JoinCollection[0]);
            Table table = Assert.IsType<Table>(join.Source);

            Assert.Equal(tableName, table.Name);

            EqualCondition condition = Assert.IsType<EqualCondition>(join.Condition);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void FullJoin_TableAndCondition_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            const string tableName = "right_test_table";
            ICondition condition = new Mock<ICondition>().Object;

            // Act
            query.FullJoin(tableName, condition);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Single(query.JoinCollection);

            FullJoin join = Assert.IsType<FullJoin>(query.JoinCollection[0]);

            Table table = Assert.IsType<Table>(join.Source);
            Assert.Equal(tableName, table.Name);
            Assert.Null(table.Alias);
            Assert.Null(table.Schema);

            Assert.Equal(condition, join.Condition);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void FullJoin_LeftSourceAndRightSourceAndJoinAction_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            ISource leftSource = NewSource();
            ISource rightSource = NewSource();

            const string leftColumnName = "left_test_column";
            const string rightColumnName = "right_test_column";

            Action<ConditionBuilder, ISource, ISource> joinAction = (c, l, r) => c.Equal(leftColumnName, l, rightColumnName, r);

            // Act
            query.FullJoin(leftSource, rightSource, joinAction);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Single(query.JoinCollection);

            FullJoin join = Assert.IsType<FullJoin>(query.JoinCollection[0]);
            Assert.Equal(rightSource, join.Source);

            EqualCondition condition = Assert.IsType<EqualCondition>(join.Condition);

            SourceColumn leftColumn = Assert.IsType<SourceColumn>(condition.LeftExpression);
            Assert.Equal(leftColumnName, leftColumn.Name);
            Assert.Null(leftColumn.Alias);
            Assert.Equal(leftSource, leftColumn.Source);

            SourceColumn rightColumn = Assert.IsType<SourceColumn>(condition.RightExpression);
            Assert.Equal(rightColumnName, rightColumn.Name);
            Assert.Null(rightColumn.Alias);
            Assert.Equal(rightSource, rightColumn.Source);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void FullJoin_SourceAndJoinAction_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            ISource source = NewSource();
            ICondition condition = NewCondition();

            // Act
            query.FullJoin(source, c => c.Condition(condition));

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Single(query.JoinCollection);

            FullJoin join = Assert.IsType<FullJoin>(query.JoinCollection[0]);
            Assert.Equal(source, join.Source);
            Assert.Equal(condition, join.Condition);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void FullJoin_SourceAndCondition_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            ISource source = NewSource();
            ICondition condition = NewCondition();

            // Act
            query.FullJoin(source, condition);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Single(query.JoinCollection);

            FullJoin join = Assert.IsType<FullJoin>(query.JoinCollection[0]);
            Assert.Equal(source, join.Source);
            Assert.Equal(condition, join.Condition);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData(null, "right_table")]
        [InlineData("", null)]
        [InlineData("", "")]
        [InlineData("", "right_table")]
        [InlineData("left_table", null)]
        [InlineData("left_table", "")]
        public void FullJoin_NullOrEmptyLeftTableOrNullOrEmptyRightTableAndJoinAction_ThrowsArgumentException(string? leftTable, string? rightTable) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).FullJoin(leftTable!, rightTable!, (c, l, r) => c.Equal("left_column", l, "right_column", r)));

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData(null, "right_table")]
        [InlineData("", null)]
        [InlineData("", "")]
        [InlineData("", "right_table")]
        [InlineData("left_table", null)]
        [InlineData("left_table", "")]
        public void FullJoin_NullOrEmptyLeftTableOrNullOrEmptyRightTableAndNullJoinAction_ThrowsArgumentException(string? leftTable, string? rightTable) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).FullJoin(leftTable!, rightTable!, joinAction: null!));

        [Fact]
        public void FullJoin_LeftTableAndRightTableAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).FullJoin("left_table", "right_table", joinAction: null!));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void FullJoin_NullOrEmptyTableAndJoinAction_ThrowsArgumentException(string? table) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).FullJoin(table!, c => c.Condition(NewCondition())));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void FullJoin_NullOrEmptyTableAndNullJoinAction_ThrowsArgumentNullException(string? table) =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).FullJoin(table!, joinAction: null!));

        [Fact]
        public void FullJoin_TableAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).FullJoin("table", joinAction: null!));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void FullJoin_NullOrEmptyTableAndCondition_ThrowsArgumentException(string? table) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).FullJoin(table!, NewCondition()));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void FullJoin_NullOrEmptyTableAndNullCondition_ThrowsArgumentException(string? table) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).FullJoin(table!, condition: null!));

        [Fact]
        public void FullJoin_TableAndNullCondition_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).FullJoin("table", condition: null!));

        [Fact]
        public void FullJoin_NullLeftSourceAndNullRightSourceAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).FullJoin(leftSource: null!, rightSource: null!, joinAction: null!));

        [Fact]
        public void FullJoin_NullLeftSourceAndNullRightSourceAndJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).FullJoin(leftSource: null!, rightSource: null!, (c, l, r) => c.Equal("left_column", l, "right_column", r)));

        [Fact]
        public void FullJoin_NullLeftSourceAndRightSourceAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).FullJoin(leftSource: null!, NewSource(), joinAction: null!));

        [Fact]
        public void FullJoin_NullLeftSourceAndRightSourceAndJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).FullJoin(leftSource: null!, NewSource(), (c, l, r) => c.Equal("left_column", l, "right_column", r)));

        [Fact]
        public void FullJoin_LeftSourceAndNullRightSourceAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).FullJoin(NewSource(), rightSource: null!, joinAction: null!));

        [Fact]
        public void FullJoin_LeftSourceAndNullRightSourceAndJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).FullJoin(NewSource(), rightSource: null!, (c, l, r) => c.Equal("left_column", l, "right_column", r)));

        [Fact]
        public void FullJoin_LeftSourceAndRightSourceAndNullJoinAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).FullJoin(NewSource(), NewSource(), joinAction: null!));

        [Fact]
        public void CrossJoin_Table_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            const string tableName = "test_table";

            // Act
            query.CrossJoin(tableName);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Single(query.JoinCollection);

            CrossJoin join = Assert.IsType<CrossJoin>(query.JoinCollection[0]);
            Table table = Assert.IsType<Table>(join.Source);
            Assert.Equal(tableName, table.Name);
            Assert.Null(table.Alias);
            Assert.Null(table.Schema);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void CrossJoin_Source_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            ISource source = NewSource();

            // Act
            query.CrossJoin(source);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Single(query.JoinCollection);

            CrossJoin join = Assert.IsType<CrossJoin>(query.JoinCollection[0]);
            Assert.Equal(source, join.Source);
            
            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CrossJoin_NullOrEmptyTable_ThrowsArgumentException(string? table) =>
            Assert.Throws<ArgumentException>(() => new Select(Array.Empty<IColumn>()).CrossJoin(table!));

        [Fact]
        public void CrossJoin_NullSource_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).CrossJoin(source: null!));

        [Fact]
        public void Join_Join_AddToJoinCollection()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());

            IJoin join = new Mock<IJoin>().Object;

            // Act
            query.Join(join);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);

            Assert.Single(query.JoinCollection);
            Assert.Equal(join, query.JoinCollection[0]);

            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void Join_NullJoin_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).Join(join: null));

        [Fact]
        public void Having_Condition_SetHavingCondition()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());
            ICondition condition = new Mock<ICondition>().Object;

            // Act
            query.Having(condition);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Empty(query.JoinCollection);
            Assert.Equal(condition, query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void Having_NullCondition_SetHavingCondition()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>()).Having(new Mock<ICondition>().Object);

            // Act
            query.Having(condition: null);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Empty(query.JoinCollection);
            Assert.Null(query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void Having_ConditionAction_SetHavingCondition()
        {
            // Arrange
            Select query = new Select(Array.Empty<IColumn>());
            ICondition condition = new Mock<ICondition>().Object;
            Action<ConditionBuilder> conditionAction = (cb) => cb.Condition(condition);

            // Act
            query.Having(conditionAction);

            // Assert
            Assert.Empty(query.ColumnCollection);
            Assert.Null(query.DistinctValue);
            Assert.Empty(query.SourceCollection);
            Assert.Null(query.WhereCondition);
            Assert.Empty(query.JoinCollection);
            Assert.Equal(condition, query.HavingCondition);
            Assert.Empty(query.OrderByCollection);
            Assert.Empty(query.GroupByCollection);
            Assert.False(query.OffsetValue.HasValue);
            Assert.False(query.LimitValue.HasValue);
        }

        [Fact]
        public void Having_NullConditionAction_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Select(Array.Empty<IColumn>()).Having(conditionAction: null!));

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
