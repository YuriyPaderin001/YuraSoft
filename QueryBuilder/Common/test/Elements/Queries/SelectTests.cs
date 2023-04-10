using System;
using System.Collections.Generic;
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
			Assert.Throws<ArgumentNullException>(() => new Select(action: null!));
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
        public void SetDistinctValue_IDistinct_Success() =>
            SetDistinctValue_IDistinct_Success_Base(NewDistinct());

        [Fact]
        public void SetDistinctValue_NullIDistinct_Success() =>
            SetDistinctValue_IDistinct_Success_Base(distinct: null);

        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        public void SetColumnCollection_IColumnList_Success(int length) =>
            SetColumnCollection_IColumnList_Success_Base(NewColumns(length));

        [Fact]
        public void SetColumnCollection_NullIColumnList_ThrowsArgumentNullException()
        {
            // Arrange
            Select select = new Select(NewColumns(3));

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => select.ColumnCollection = null!);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        public void SetSourceCollection_ISourceList_Success(int length) =>
            SetSourceCollection_ISourceList_Success_Base(NewSources(length));

        [Fact]
        public void SetSourceCollection_NullISourceList_ThrowsArgumentNullException()
        {
            // Arrange
            Select select = new Select(NewColumns(3));

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => select.SourceCollection = null!);
        }

        [Fact]
        public void SetWhereCondition_ICondition_Success() =>
            SetWhereCondition_ICondition_Success_Base(NewCondition());

        [Fact]
        public void SetWhereCondition_NullICondition_Success() =>
            SetWhereCondition_ICondition_Success_Base(condition: null);

        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        public void SetJoinCollection_IJoinList_Success(int length) =>
            SetJoinCollection_IJoinList_Success_Base(NewJoins(length));

        [Fact]
        public void SetJoinCollection_NullIJoinList_ThrowsArgumentNullException()
        {
            // Arrange
            Select select = new Select(NewColumns(3));

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => select.JoinCollection = null!);
        }

        [Fact]
        public void SetHavingCondition_ICondition_Success() =>
            SetHavingCondition_ICondition_Success_Base(NewCondition());

        [Fact]
        public void SetHavingCondition_NullICondition_Success() =>
            SetHavingCondition_ICondition_Success_Base(condition: null);

        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        public void SetOrderByCollection_IOrderByList_Success(int length) =>
            SetOrderByCollection_IOrderByList_Success_Base(NewOrderBies(length));

        [Fact]
        public void SetOrderByCollection_NullIOrderByList_ThrowsArgumentNullException()
        {
            // Arrange
            Select select = new Select(NewColumns(3));

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => select.OrderByCollection = null!);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        public void SetGroupByCollection_IGroupByList_Success(int length) =>
            SetGroupByCollection_IColumnList_Success_Base(NewColumns(length));

        [Fact]
        public void SetGroupByCollection_NullIGroupByList_ThrowsArgumentNullException()
        {
            // Arrange
            Select select = new Select(NewColumns(3));

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => select.GroupByCollection = null!);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(3)]
        public void SetOffsetValue_NullableInt32_Success(int? offset)
        {
            // Arrange
            List<IColumn> columns = NewColumns(3);
            Select select = new Select(columns);

            // Act
            select.OffsetValue = offset;

            // Assert
            if (offset.HasValue)
            {
                Assert.Equal(offset.Value, select.OffsetValue);
            }
            else
            {
                Assert.Null(select.OffsetValue);
            }

            Assert.Null(select.DistinctValue);
            Assert.Equal(columns, select.ColumnCollection);
            Assert.Empty(select.SourceCollection);
            Assert.Null(select.WhereCondition);
            Assert.Empty(select.JoinCollection);
            Assert.Null(select.HavingCondition);
            Assert.Empty(select.OrderByCollection);
            Assert.Empty(select.GroupByCollection);
            Assert.False(select.LimitValue.HasValue);
        }

        [Fact]
        public void SetOffsetValue_NegativeInt32_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            Select select = new Select(NewColumns(3));

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => select.OffsetValue = -3);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(3)]
        public void SetLimitValue_NullableInt32_Success(int? limit)
        {
            // Arrange
            List<IColumn> columns = NewColumns(3);
            Select select = new Select(columns);

            // Act
            select.LimitValue = limit;

            // Assert
            if (limit.HasValue)
            {
                Assert.Equal(limit.Value, select.LimitValue);
            }
            else
            {
                Assert.Null(select.LimitValue);
            }

            Assert.Null(select.DistinctValue);
            Assert.Equal(columns, select.ColumnCollection);
            Assert.Empty(select.SourceCollection);
            Assert.Null(select.WhereCondition);
            Assert.Empty(select.JoinCollection);
            Assert.Null(select.HavingCondition);
            Assert.Empty(select.OrderByCollection);
            Assert.Empty(select.GroupByCollection);
            Assert.False(select.OffsetValue.HasValue);
        }

        [Fact]
        public void SetLimitValue_NegativeInt32_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            Select select = new Select(NewColumns(3));

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => select.LimitValue = -3);
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

        private void SetDistinctValue_IDistinct_Success_Base(IDistinct? distinct)
        {
            // Arrange
            List<IColumn> columns = NewColumns(2);
            Select select = new Select(columns);

            // Act
            select.DistinctValue = distinct;

            // Assert
            Assert.Equal(distinct, select.DistinctValue);

            Assert.Equal(columns, select.ColumnCollection);
            Assert.Empty(select.SourceCollection);
            Assert.Null(select.WhereCondition);
            Assert.Empty(select.JoinCollection);
            Assert.Null(select.HavingCondition);
            Assert.Empty(select.OrderByCollection);
            Assert.Empty(select.GroupByCollection);
            Assert.False(select.OffsetValue.HasValue);
            Assert.False(select.LimitValue.HasValue);
        }

        private void SetColumnCollection_IColumnList_Success_Base(List<IColumn> columns)
        {
            // Arrange
            Select select = new Select(NewColumns(3));

            // Act
            select.ColumnCollection = columns;

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

        private void SetSourceCollection_ISourceList_Success_Base(List<ISource> sources)
        {
            // Arrange
            List<IColumn> columns = NewColumns(3);
            Select select = new Select(columns);

            // Act
            select.SourceCollection = sources;

            // Assert
            Assert.Equal(sources, select.SourceCollection);

            Assert.Null(select.DistinctValue);
            Assert.Equal(columns, select.ColumnCollection);
            Assert.Null(select.WhereCondition);
            Assert.Empty(select.JoinCollection);
            Assert.Null(select.HavingCondition);
            Assert.Empty(select.OrderByCollection);
            Assert.Empty(select.GroupByCollection);
            Assert.False(select.OffsetValue.HasValue);
            Assert.False(select.LimitValue.HasValue);
        }

        private void SetWhereCondition_ICondition_Success_Base(ICondition? condition)
        {
            // Arrange
            List<IColumn> columns = NewColumns(3);
            Select select = new Select(columns);

            // Act
            select.WhereCondition = condition;

            // Assert
            if (condition == null)
            {
                Assert.Null(select.WhereCondition);
            }
            else
            {
                Assert.Equal(condition, select.WhereCondition);
            }

            Assert.Equal(columns, select.ColumnCollection);
            Assert.Null(select.DistinctValue);
            Assert.Empty(select.SourceCollection);
            Assert.Empty(select.JoinCollection);
            Assert.Null(select.HavingCondition);
            Assert.Empty(select.OrderByCollection);
            Assert.Empty(select.GroupByCollection);
            Assert.False(select.OffsetValue.HasValue);
            Assert.False(select.LimitValue.HasValue);
        }

        private void SetJoinCollection_IJoinList_Success_Base(List<IJoin> joins)
        {
            // Arrange
            List<IColumn> columns = NewColumns(3);
            Select select = new Select(columns);

            // Act
            select.JoinCollection = joins;

            // Assert
            Assert.Equal(joins, select.JoinCollection);

            Assert.Null(select.DistinctValue);
            Assert.Equal(columns, select.ColumnCollection);
            Assert.Empty(select.SourceCollection);
            Assert.Null(select.WhereCondition);
            Assert.Null(select.HavingCondition);
            Assert.Empty(select.OrderByCollection);
            Assert.Empty(select.GroupByCollection);
            Assert.False(select.OffsetValue.HasValue);
            Assert.False(select.LimitValue.HasValue);
        }

        private void SetHavingCondition_ICondition_Success_Base(ICondition? condition)
        {
            // Arrange
            List<IColumn> columns = NewColumns(3);
            Select select = new Select(columns);

            // Act
            select.HavingCondition = condition;

            // Assert
            if (condition == null)
            {
                Assert.Null(select.HavingCondition);
            }
            else
            {
                Assert.Equal(condition, select.HavingCondition);
            }

            Assert.Equal(columns, select.ColumnCollection);
            Assert.Null(select.DistinctValue);
            Assert.Empty(select.SourceCollection);
            Assert.Null(select.WhereCondition);
            Assert.Empty(select.JoinCollection);
            Assert.Empty(select.OrderByCollection);
            Assert.Empty(select.GroupByCollection);
            Assert.False(select.OffsetValue.HasValue);
            Assert.False(select.LimitValue.HasValue);
        }

        private void SetOrderByCollection_IOrderByList_Success_Base(List<IOrderBy> orderBies)
        {
            // Arrange
            List<IColumn> columns = NewColumns(3);
            Select select = new Select(columns);

            // Act
            select.OrderByCollection = orderBies;

            // Assert
            Assert.Equal(orderBies, select.OrderByCollection);

            Assert.Null(select.DistinctValue);
            Assert.Equal(columns, select.ColumnCollection);
            Assert.Empty(select.SourceCollection);
            Assert.Null(select.WhereCondition);
            Assert.Empty(select.JoinCollection);
            Assert.Null(select.HavingCondition);
            Assert.Empty(select.GroupByCollection);
            Assert.False(select.OffsetValue.HasValue);
            Assert.False(select.LimitValue.HasValue);
        }

        private void SetGroupByCollection_IColumnList_Success_Base(List<IColumn> groupBies)
        {
            // Arrange
            List<IColumn> columns = NewColumns(3);
            Select select = new Select(columns);

            // Act
            select.GroupByCollection = groupBies;

            // Assert
            Assert.Equal(groupBies, select.GroupByCollection);

            Assert.Null(select.DistinctValue);
            Assert.Equal(columns, select.ColumnCollection);
            Assert.Empty(select.SourceCollection);
            Assert.Null(select.WhereCondition);
            Assert.Empty(select.JoinCollection);
            Assert.Null(select.HavingCondition);
            Assert.Empty(select.OrderByCollection);
            Assert.False(select.OffsetValue.HasValue);
            Assert.False(select.LimitValue.HasValue);
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
    }
}
