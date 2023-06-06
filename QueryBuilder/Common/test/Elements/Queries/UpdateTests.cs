using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Queries
{
    public class UpdateTests : TestsBase
    {
        [Fact]
        public void Constructor_TableName_Success()
        {
            // Arrange
            const string tableName = "test_table";

            // Act
            Update query = new Update(tableName);

            // Assert
            Assert.NotNull(query.Source);

            Table table = Assert.IsType<Table>(query.Source);
            Assert.Equal(tableName, table.Name);
            Assert.Null(table.Alias);
            Assert.Null(table.Schema);

            Assert.Empty(query.SetCollection);
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
            Update query = new Update(tableName, tableSchema);

            // Assert
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

			Assert.Empty(query.SetCollection);
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
            Update query = new Update(tableName, tableAlias, tableSchema);

            // Assert
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

            Assert.Empty(query.SetCollection);
            Assert.Null(query.Condition);
        }

        [Fact]
        public void Constructor_Source_Success()
        {
            // Arrange
            Table source = new Table("test_name", "test_alias", "test_schema");

            // Act
            Update query = new Update(source);

            // Assert
            Assert.NotNull(query.Source);

            Table table = Assert.IsType<Table>(query.Source);
            Assert.Equal(source, table);
            Assert.Empty(query.SetCollection);
            Assert.Null(query.Condition);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_NullOrEmptyTableName_ThrowsArgumentException(string? tableName) =>
            Assert.Throws<ArgumentException>(() => new Update(tableName!));

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData(null, "table_schema")]
        [InlineData("", null)]
        [InlineData("", "")]
        [InlineData("", "table_schema")]
        public void Constructor_NullOrEmptyTableNameAndSchema_ThrowsArgumentException(string? tableName, string? tableSchema) =>
            Assert.Throws<ArgumentException>(() => new Update(tableName!, tableSchema));

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
            Assert.Throws<ArgumentException>(() => new Update(tableName!, tableAlias, tableSchema));

        [Fact]
        public void Constructor_NullTable_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Update(table: null!));

        [Theory]
        [InlineData(-3)]
        [InlineData(0)]
        [InlineData(3)]
        public void Set_ColumnNameAndSbyteValue_AddToSetCollection(sbyte number)
        {
            // Arrange
            Update query = NewInstance();

            ISource source = query.Source;
            string columnName = "column_name";

            // Act
            query.Set(columnName, number);

            // Assert
            Assert.Equal(source, query.Source);

            Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);
            
            SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
            Assert.Equal(columnName, column.Name);
            Assert.Null(column.Alias);
            Assert.Null(column.Source);

            Int8Value value = Assert.IsType<Int8Value>(columnExpressionPair.Item2);
            Assert.Equal(number, value.Data);

            Assert.Null(query.Condition);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Set_NullOrEmptyColumnNameAndSbyteValue_ThrowsArgumentException(string? columnName) =>
            Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, (sbyte)1));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndShortValue_AddToSetCollection(short number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			string columnName = "column_name";

			// Act
			query.Set(columnName, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Null(column.Source);

			Int16Value value = Assert.IsType<Int16Value>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndShortValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, (short)1));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndIntValue_AddToSetCollection(int number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			string columnName = "column_name";

			// Act
			query.Set(columnName, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Null(column.Source);

			Int32Value value = Assert.IsType<Int32Value>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndIntValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, 1));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndLongValue_AddToSetCollection(long number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			string columnName = "column_name";

			// Act
			query.Set(columnName, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Null(column.Source);

			Int64Value value = Assert.IsType<Int64Value>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndLongValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, (long)1));

		[Theory]
		[InlineData(-3.3f)]
		[InlineData(0f)]
		[InlineData(3.2f)]
		public void Set_ColumnNameAndFloatValue_AddToSetCollection(float number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			string columnName = "column_name";

			// Act
			query.Set(columnName, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Null(column.Source);

			FloatValue value = Assert.IsType<FloatValue>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndFloatValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, 1.3f));

		[Theory]
		[InlineData(-3.3d)]
		[InlineData(0d)]
		[InlineData(3.2d)]
		public void Set_ColumnNameAndDoubleValue_AddToSetCollection(double number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			string columnName = "column_name";

			// Act
			query.Set(columnName, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Null(column.Source);

			DoubleValue value = Assert.IsType<DoubleValue>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndDoubleValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, 1.3d));

		[Theory]
		[InlineData(-3.3d)]
		[InlineData(0d)]
		[InlineData(3.2d)]
		public void Set_ColumnNameAndDecimalValue_AddToSetCollection(decimal number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			string columnName = "column_name";

			// Act
			query.Set(columnName, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Null(column.Source);

			DecimalValue value = Assert.IsType<DecimalValue>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndDecimalValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, 1.3m));

		[Fact]
		public void Set_ColumnNameAndDateTimeValue_AddToSetCollection()
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			string columnName = "column_name";
            DateTime dateTime = new DateTime(2023, 11, 21, 23, 12, 32);

			// Act
			query.Set(columnName, dateTime);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Null(column.Source);

			DateTimeValue value = Assert.IsType<DateTimeValue>(columnExpressionPair.Item2);
			Assert.Equal(dateTime, value.Data);
            Assert.Equal("o", value.Format);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndDateTimeValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, new DateTime(2023, 11, 21, 23, 12, 32)));

		[Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("yyyy-MM-dd")]
		public void Set_ColumnNameAndDateTimeValueAndFormat_AddToSetCollection(string? format)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			string columnName = "column_name";
			DateTime dateTime = new DateTime(2023, 11, 21, 23, 12, 32);

			// Act
			query.Set(columnName, dateTime, format);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Null(column.Source);

			DateTimeValue value = Assert.IsType<DateTimeValue>(columnExpressionPair.Item2);
			Assert.Equal(dateTime, value.Data);

            if (string.IsNullOrEmpty(format))
            {
                Assert.Equal("o", value.Format);
            }
            else
            {
                Assert.Equal(format, value.Format);
            }

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData(null, "yyyy-MM-dd")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "yyyy-MM-dd")]
		public void Set_NullOrEmptyColumnNameAndDateTimeValueAndFormat_ThrowsArgumentException(string? columnName, string? format) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, new DateTime(2023, 11, 21, 23, 12, 32), format));

		[Theory]
        [InlineData("")]
        [InlineData("string")]
		public void Set_ColumnNameAndStringValue_AddToSetCollection(string str)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			string columnName = "column_name";

			// Act
			query.Set(columnName, str);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Null(column.Source);

			StringValue value = Assert.IsType<StringValue>(columnExpressionPair.Item2);
			Assert.Equal(str, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndStringValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, "string"));

		[Fact]
		public void Set_ColumnNameAndNullStringValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set("column_name", value: (string)null!));

		[Fact]
		public void Set_ColumnNameAndExpressionValue_AddToSetCollection()
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			string columnName = "column_name";
            IExpression expression = NewExpression();

			// Act
			query.Set(columnName, expression);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Null(column.Source);

            Assert.Equal(expression, columnExpressionPair.Item2);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndExpressionValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewExpression()));

		[Fact]
		public void SetNull_ColumnName_AddToSetCollection()
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			string columnName = "column_name";

			// Act
			query.SetNull(columnName);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Null(column.Source);

			Assert.IsType<NullValue>(columnExpressionPair.Item2);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void SetNull_NullOrEmptyColumnName_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().SetNull(columnName!));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndTableNameAndSbyteValue_AddToSetCollection(sbyte number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			string columnName = "column_name";
			string tableName = "table_name";

			// Act
			query.Set(columnName, tableName, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);

			Table columnTable = Assert.IsType<Table>(column.Source);
			Assert.Equal(tableName, columnTable.Name);
			Assert.Null(columnTable.Alias);
			Assert.Null(columnTable.Schema);

			Int8Value value = Assert.IsType<Int8Value>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		[InlineData("column_name", null)]
		[InlineData("column_name", "")]
		public void Set_NullOrEmptyColumnNameOrNullOrEmptyTableNameAndSbyteValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, (sbyte)1));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndTableNameAndShortValue_AddToSetCollection(short number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			string columnName = "column_name";
			string tableName = "table_name";

			// Act
			query.Set(columnName, tableName, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);

			Table columnTable = Assert.IsType<Table>(column.Source);
			Assert.Equal(tableName, columnTable.Name);
			Assert.Null(columnTable.Alias);
			Assert.Null(columnTable.Schema);

			Int16Value value = Assert.IsType<Int16Value>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		[InlineData("column_name", null)]
		[InlineData("column_name", "")]
		public void Set_NullOrEmptyColumnNameOrNullOrEmptyTableNameAndShortValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, (short)1));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndTableNameAndIntValue_AddToSetCollection(int number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			const string columnName = "column_name";
			const string tableName = "table_name";

			// Act
			query.Set(columnName, tableName, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);

			Table columnTable = Assert.IsType<Table>(column.Source);
			Assert.Equal(tableName, columnTable.Name);
			Assert.Null(columnTable.Alias);
			Assert.Null(columnTable.Schema);

			Int32Value value = Assert.IsType<Int32Value>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		[InlineData("column_name", null)]
		[InlineData("column_name", "")]
		public void Set_NullOrEmptyColumnNameOrTableNameAndIntValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, 1));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndTableNameAndLongValue_AddToSetCollection(long number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			string columnName = "column_name";
			string tableName = "table_name";

			// Act
			query.Set(columnName, tableName, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);

			Table columnTable = Assert.IsType<Table>(column.Source);
			Assert.Equal(tableName, columnTable.Name);
			Assert.Null(columnTable.Alias);
			Assert.Null(columnTable.Schema);

			Int64Value value = Assert.IsType<Int64Value>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		[InlineData("column_name", null)]
		[InlineData("column_name", "")]
		public void Set_NullOrEmptyColumnNameOrNullOrEmptyTableNameAndLongValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, (long)1));

		[Theory]
		[InlineData(-3.3f)]
		[InlineData(0f)]
		[InlineData(3.2f)]
		public void Set_ColumnNameAndTableNameAndFloatValue_AddToSetCollection(float number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			string columnName = "column_name";
			string tableName = "table_name";

			// Act
			query.Set(columnName, tableName, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);

			Table columnTable = Assert.IsType<Table>(column.Source);
			Assert.Equal(tableName, columnTable.Name);
			Assert.Null(columnTable.Alias);
			Assert.Null(columnTable.Schema);

			FloatValue value = Assert.IsType<FloatValue>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		[InlineData("column_name", null)]
		[InlineData("column_name", "")]
		public void Set_NullOrEmptyColumnNameOrTableNameAndFloatValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, 1.3f));

		[Theory]
		[InlineData(-3.3d)]
		[InlineData(0d)]
		[InlineData(3.2d)]
		public void Set_ColumnNameAndTableNameAndDoubleValue_AddToSetCollection(double number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			string columnName = "column_name";
			string tableName = "table_name";

			// Act
			query.Set(columnName, tableName, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);

			Table columnTable = Assert.IsType<Table>(column.Source);
			Assert.Equal(tableName, columnTable.Name);
			Assert.Null(columnTable.Alias);
			Assert.Null(columnTable.Schema);

			DoubleValue value = Assert.IsType<DoubleValue>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		[InlineData("column_name", null)]
		[InlineData("column_name", "")]
		public void Set_NullOrEmptyColumnNameOrNullOrEmptyTableNameAndDoubleValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, 1.3d));

		[Theory]
		[InlineData(-3.3d)]
		[InlineData(0d)]
		[InlineData(3.2d)]
		public void Set_ColumnNameAndTableNameAndDecimalValue_AddToSetCollection(decimal number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			const string columnName = "column_name";
			const string tableName = "table_name";

			// Act
			query.Set(columnName, tableName, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);

			Table columnTable = Assert.IsType<Table>(column.Source);
			Assert.Equal(tableName, columnTable.Name);
			Assert.Null(columnTable.Alias);
			Assert.Null(columnTable.Schema);

			DecimalValue value = Assert.IsType<DecimalValue>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		[InlineData("column_name", null)]
		[InlineData("column_name", "")]
		public void Set_NullOrEmptyColumnNameOrNullOrEmptyTableNameAndDecimalValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, 1.3m));

		[Fact]
		public void Set_ColumnNameAndTableNameAndDateTimeValue_AddToSetCollection()
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			const string columnName = "column_name";
			const string tableName = "table_name";
			DateTime dateTime = new DateTime(2023, 11, 21, 23, 12, 32);

			// Act
			query.Set(columnName, tableName, dateTime);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);

			Table columnTable = Assert.IsType<Table>(column.Source);
			Assert.Equal(tableName, columnTable.Name);
			Assert.Null(columnTable.Alias);
			Assert.Null(columnTable.Schema);

			DateTimeValue value = Assert.IsType<DateTimeValue>(columnExpressionPair.Item2);
			Assert.Equal(dateTime, value.Data);
			Assert.Equal("o", value.Format);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		[InlineData("column_name", null)]
		[InlineData("column_name", "")]
		public void Set_NullOrEmptyColumnNameOrNullOrEmptyTableNameAndDateTimeValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, new DateTime(2023, 11, 21, 23, 12, 32)));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("yyyy-MM-dd")]
		public void Set_ColumnNameAndTableNameAndDateTimeValueAndFormat_AddToSetCollection(string? format)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			const string columnName = "column_name";
			const string tableName = "table_name";
			DateTime dateTime = new DateTime(2023, 11, 21, 23, 12, 32);

			// Act
			query.Set(columnName, tableName, dateTime, format);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);

			Table columnTable = Assert.IsType<Table>(column.Source);
			Assert.Equal(tableName, columnTable.Name);
			Assert.Null(columnTable.Alias);
			Assert.Null(columnTable.Schema);

			DateTimeValue value = Assert.IsType<DateTimeValue>(columnExpressionPair.Item2);
			Assert.Equal(dateTime, value.Data);

			if (string.IsNullOrEmpty(format))
			{
				Assert.Equal("o", value.Format);
			}
			else
			{
				Assert.Equal(format, value.Format);
			}

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null, null, null)]
		[InlineData(null, null, "")]
		[InlineData(null, null, "yyyy-MM-dd")]
		[InlineData(null, "", null)]
		[InlineData(null, "", "")]
		[InlineData(null, "", "yyyy-MM-dd")]
		[InlineData(null, "table_name", null)]
		[InlineData(null, "table_name", "")]
		[InlineData(null, "table_name", "yyyy-MM-dd")]
		[InlineData("", null, null)]
		[InlineData("", null, "")]
		[InlineData("", null, "yyyy-MM-dd")]
		[InlineData("", "", null)]
		[InlineData("", "", "")]
		[InlineData("", "", "yyyy-MM-dd")]
		[InlineData("", "table_name", null)]
		[InlineData("", "table_name", "")]
		[InlineData("", "table_name", "yyyy-MM-dd")]
		[InlineData("column_name", null, null)]
		[InlineData("column_name", null, "")]
		[InlineData("column_name", null, "yyyy-MM-dd")]
		[InlineData("column_name", "", null)]
		[InlineData("column_name", "", "")]
		[InlineData("column_name", "", "yyyy-MM-dd")]
		public void Set_NullOrEmptyColumnNameOrNullOrEmptyTableNameAndDateTimeValueAndFormat_ThrowsArgumentException(string? columnName, string? tableName, string? format) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, new DateTime(2023, 11, 21, 23, 12, 32), format));

		[Theory]
		[InlineData("")]
		[InlineData("string")]
		public void Set_ColumnNameAndTableNameAndStringValue_AddToSetCollection(string str)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			const string columnName = "column_name";
			const string tableName = "table_name";

			// Act
			query.Set(columnName, tableName, str);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);

			Table columnTable = Assert.IsType<Table>(column.Source);
			Assert.Equal(tableName, columnTable.Name);
			Assert.Null(columnTable.Alias);
			Assert.Null(columnTable.Schema);

			StringValue value = Assert.IsType<StringValue>(columnExpressionPair.Item2);
			Assert.Equal(str, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		[InlineData("column_name", null)]
		[InlineData("column_name", "")]
		public void Set_NullOrEmptyColumnNameOrNullOrEmptyTableNameAndStringValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, "string"));

		[Fact]
		public void Set_ColumnNameAndTableNameAndNullStringValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set("column_name", "table_name", value: (string)null!));

		[Fact]
		public void Set_ColumnNameAndTableNameAndExpressionValue_AddToSetCollection()
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			const string columnName = "column_name";
			const string tableName = "table_name";
			IExpression expression = NewExpression();

			// Act
			query.Set(columnName, tableName, expression);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);

			Table columnTable = Assert.IsType<Table>(column.Source);
			Assert.Equal(tableName, columnTable.Name);
			Assert.Null(columnTable.Alias);
			Assert.Null(columnTable.Schema);

			Assert.Equal(expression, columnExpressionPair.Item2);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		[InlineData("column_name", null)]
		[InlineData("column_name", "")]
		public void Set_NullOrEmptyColumnNameOrNullOrEmptyTableNameAndExpressionValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, NewExpression()));

		[Fact]
		public void Set_ColumnNameAndTableNameAndNullExpressionValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set("column_name", "table_name", value: (IExpression)null!));

		[Fact]
		public void SetNull_ColumnNameAndTableName_AddToSetCollection()
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			const string columnName = "column_name";
			const string tableName = "table_name";

			// Act
			query.SetNull(columnName, tableName);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);

			Table columnTable = Assert.IsType<Table>(column.Source);
			Assert.Equal(tableName, columnTable.Name);
			Assert.Null(columnTable.Alias);
			Assert.Null(columnTable.Schema);

			Assert.IsType<NullValue>(columnExpressionPair.Item2);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		[InlineData("column_name", null)]
		[InlineData("column_name", "")]
		public void SetNull_NullOrEmptyColumnNameOrNullOrEmptyTableName_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().SetNull(columnName!, tableName!));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndColumnSourceAndSbyteValue_AddToSetCollection(sbyte number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			string columnName = "column_name";
			ISource columnSource = NewSource();

			// Act
			query.Set(columnName, columnSource, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Equal(columnSource, column.Source);

			Int8Value value = Assert.IsType<Int8Value>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndSbyteValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), (sbyte)1));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndColumnSourceAndShortValue_AddToSetCollection(short number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			string columnName = "column_name";
			ISource columnSource = NewSource();

			// Act
			query.Set(columnName, columnSource, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Equal(columnSource, column.Source);

			Int16Value value = Assert.IsType<Int16Value>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndShortValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), (short)1));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndColumnSourceAndIntValue_AddToSetCollection(int number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			const string columnName = "column_name";
			ISource columnSource = NewSource();

			// Act
			query.Set(columnName, columnSource, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Equal(columnSource, column.Source);

			Int32Value value = Assert.IsType<Int32Value>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndIntValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), 1));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndColumnSourceAndLongValue_AddToSetCollection(long number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			string columnName = "column_name";
			ISource columnSource = NewSource();

			// Act
			query.Set(columnName, columnSource, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Equal(columnSource, column.Source);

			Int64Value value = Assert.IsType<Int64Value>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndLongValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), (long)1));

		[Theory]
		[InlineData(-3.3f)]
		[InlineData(0f)]
		[InlineData(3.2f)]
		public void Set_ColumnNameAndColumnSourceAndFloatValue_AddToSetCollection(float number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			string columnName = "column_name";
			ISource columnSource = NewSource();

			// Act
			query.Set(columnName, columnSource, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Equal(columnSource, column.Source);

			FloatValue value = Assert.IsType<FloatValue>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndFloatValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), 1.3f));

		[Theory]
		[InlineData(-3.3d)]
		[InlineData(0d)]
		[InlineData(3.2d)]
		public void Set_ColumnNameAndColumnSourceAndDoubleValue_AddToSetCollection(double number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			string columnName = "column_name";
			ISource columnSource = NewSource();

			// Act
			query.Set(columnName, columnSource, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Equal(columnSource, column.Source);

			DoubleValue value = Assert.IsType<DoubleValue>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndDoubleValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), 1.3d));

		[Theory]
		[InlineData(-3.3d)]
		[InlineData(0d)]
		[InlineData(3.2d)]
		public void Set_ColumnNameAndColumnSourceAndDecimalValue_AddToSetCollection(decimal number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			const string columnName = "column_name";
			ISource columnSource = NewSource();

			// Act
			query.Set(columnName, columnSource, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Equal(columnSource, column.Source);

			DecimalValue value = Assert.IsType<DecimalValue>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndDecimalValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), 1.3m));

		[Fact]
		public void Set_ColumnNameAndColumnSourceAndDateTimeValue_AddToSetCollection()
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			const string columnName = "column_name";
			ISource columnSource = NewSource();

			DateTime dateTime = new DateTime(2023, 11, 21, 23, 12, 32);

			// Act
			query.Set(columnName, columnSource, dateTime);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Equal(columnSource, column.Source);

			DateTimeValue value = Assert.IsType<DateTimeValue>(columnExpressionPair.Item2);
			Assert.Equal(dateTime, value.Data);
			Assert.Equal("o", value.Format);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndDateTimeValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), new DateTime(2023, 11, 21, 23, 12, 32)));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("yyyy-MM-dd")]
		public void Set_ColumnNameAndColumnSourceAndDateTimeValueAndFormat_AddToSetCollection(string? format)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			const string columnName = "column_name";
			ISource columnSource = NewSource();

			DateTime dateTime = new DateTime(2023, 11, 21, 23, 12, 32);

			// Act
			query.Set(columnName, columnSource, dateTime, format);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Equal(columnSource, column.Source);

			DateTimeValue value = Assert.IsType<DateTimeValue>(columnExpressionPair.Item2);
			Assert.Equal(dateTime, value.Data);

			if (string.IsNullOrEmpty(format))
			{
				Assert.Equal("o", value.Format);
			}
			else
			{
				Assert.Equal(format, value.Format);
			}

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "yyyy-MM-dd")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "yyyy-MM-dd")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndDateTimeValueAndFormat_ThrowsArgumentException(string? columnName, string? format) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), new DateTime(2023, 11, 21, 23, 12, 32), format));

		[Theory]
		[InlineData("")]
		[InlineData("string")]
		public void Set_ColumnNameAndColumnSourceAndStringValue_AddToSetCollection(string str)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			const string columnName = "column_name";
			ISource columnSource = NewSource();

			// Act
			query.Set(columnName, columnSource, str);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Equal(columnSource, column.Source);

			StringValue value = Assert.IsType<StringValue>(columnExpressionPair.Item2);
			Assert.Equal(str, value.Data);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndStringValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), "string"));

		[Fact]
		public void Set_ColumnNameAndColumnSourceAndNullStringValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set("column_name", NewSource(), value: (string)null!));

		[Fact]
		public void Set_ColumnNameAndColumnSourceAndExpressionValue_AddToSetCollection()
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			const string columnName = "column_name";
			ISource columnSource = NewSource();

			IExpression expression = NewExpression();

			// Act
			query.Set(columnName, columnSource, expression);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Equal(columnSource, column.Source);

			Assert.Equal(expression, columnExpressionPair.Item2);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndExpressionValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), NewExpression()));

		[Fact]
		public void Set_ColumnNameAndColumnSourceAndNullExpressionValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set("column_name", NewSource(), value: (IExpression)null!));

		[Fact]
		public void SetNull_ColumnNameAndColumnSource_AddToSetCollection()
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			const string columnName = "column_name";
			ISource columnSource = NewSource();

			// Act
			query.SetNull(columnName, columnSource);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);

			SourceColumn column = Assert.IsType<SourceColumn>(columnExpressionPair.Item1);
			Assert.Equal(columnName, column.Name);
			Assert.Null(column.Alias);
			Assert.Equal(columnSource, column.Source);

			Assert.IsType<NullValue>(columnExpressionPair.Item2);

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void SetNull_NullOrEmptyColumnNameAndColumnSource_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().SetNull(columnName!, NewSource()));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnAndSbyteValue_AddToSetCollection(sbyte number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			IColumn column = NewColumn();

			// Act
			query.Set(column, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);
			Assert.Equal(column, columnExpressionPair.Item1);

			Int8Value value = Assert.IsType<Int8Value>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Fact]
		public void Set_NullColumnAndSbyteValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, (sbyte)1));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnAndShortValue_AddToSetCollection(short number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			IColumn column = NewColumn();

			// Act
			query.Set(column, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);
			Assert.Equal(column, columnExpressionPair.Item1);

			Int16Value value = Assert.IsType<Int16Value>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Fact]
		public void Set_NullColumnAndShortValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, (short)1));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnAndIntValue_AddToSetCollection(int number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			IColumn column = NewColumn();

			// Act
			query.Set(column, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);
			Assert.Equal(column, columnExpressionPair.Item1);

			Int32Value value = Assert.IsType<Int32Value>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Fact]
		public void Set_NullColumnAndIntValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, 1));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnAndLongValue_AddToSetCollection(long number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			IColumn column = NewColumn();

			// Act
			query.Set(column, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);
			Assert.Equal(column, columnExpressionPair.Item1);

			Int64Value value = Assert.IsType<Int64Value>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Fact]
		public void Set_NullColumnAndLongValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, (long)1));

		[Theory]
		[InlineData(-3.3f)]
		[InlineData(0f)]
		[InlineData(3.2f)]
		public void Set_ColumnAndFloatValue_AddToSetCollection(float number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			IColumn column = NewColumn();

			// Act
			query.Set(column, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);
			Assert.Equal(column, columnExpressionPair.Item1);

			FloatValue value = Assert.IsType<FloatValue>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Fact]
		public void Set_NullColumnAndFloatValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, 1.3f));

		[Theory]
		[InlineData(-3.3d)]
		[InlineData(0d)]
		[InlineData(3.2d)]
		public void Set_ColumnAndDoubleValue_AddToSetCollection(double number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			IColumn column = NewColumn();

			// Act
			query.Set(column, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);
			Assert.Equal(column, columnExpressionPair.Item1);

			DoubleValue value = Assert.IsType<DoubleValue>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Fact]
		public void Set_NullColumnAndDoubleValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, 1.3d));

		[Theory]
		[InlineData(-3.3d)]
		[InlineData(0d)]
		[InlineData(3.2d)]
		public void Set_ColumnAndDecimalValue_AddToSetCollection(decimal number)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			IColumn column = NewColumn();

			// Act
			query.Set(column, number);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);
			Assert.Equal(column, columnExpressionPair.Item1);

			DecimalValue value = Assert.IsType<DecimalValue>(columnExpressionPair.Item2);
			Assert.Equal(number, value.Data);

			Assert.Null(query.Condition);
		}

		[Fact]
		public void Set_NullColumnAndDecimalValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, 1.3m));

		[Fact]
		public void Set_ColumnAndDateTimeValue_AddToSetCollection()
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			IColumn column = NewColumn();

			DateTime dateTime = new DateTime(2023, 11, 21, 23, 12, 32);

			// Act
			query.Set(column, dateTime);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);
			Assert.Equal(column, columnExpressionPair.Item1);

			DateTimeValue value = Assert.IsType<DateTimeValue>(columnExpressionPair.Item2);
			Assert.Equal(dateTime, value.Data);
			Assert.Equal("o", value.Format);

			Assert.Null(query.Condition);
		}

		[Fact]
		public void Set_NullColumnAndDateTimeValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, new DateTime(2023, 11, 21, 23, 12, 32)));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("yyyy-MM-dd")]
		public void Set_ColumnAndDateTimeValueAndFormat_AddToSetCollection(string? format)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			IColumn column = NewColumn();

			DateTime dateTime = new DateTime(2023, 11, 21, 23, 12, 32);

			// Act
			query.Set(column, dateTime, format);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);
			Assert.Equal(column, columnExpressionPair.Item1);

			DateTimeValue value = Assert.IsType<DateTimeValue>(columnExpressionPair.Item2);
			Assert.Equal(dateTime, value.Data);

			if (string.IsNullOrEmpty(format))
			{
				Assert.Equal("o", value.Format);
			}
			else
			{
				Assert.Equal(format, value.Format);
			}

			Assert.Null(query.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("yyyy-MM-dd")]
		public void Set_NullColumnAndDateTimeValueAndFormat_ThrowsArgumentNullException(string? format) =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, new DateTime(2023, 11, 21, 23, 12, 32), format));

		[Theory]
		[InlineData("")]
		[InlineData("string")]
		public void Set_ColumnAndStringValue_AddToSetCollection(string str)
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			IColumn column = NewColumn();

			// Act
			query.Set(column, str);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);
			Assert.Equal(column, columnExpressionPair.Item1);

			StringValue value = Assert.IsType<StringValue>(columnExpressionPair.Item2);
			Assert.Equal(str, value.Data);

			Assert.Null(query.Condition);
		}

		[Fact]
		public void Set_NullColumnAndNullStringValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, value: (string)null!));

		[Fact]
		public void Set_NullColumnAndStringValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, "string"));

		[Fact]
		public void Set_ColumnAndNullStringValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(NewColumn(), value: (string)null!));

		[Fact]
		public void Set_ColumnAndExpressionValue_AddToSetCollection()
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			IColumn column = NewColumn();

			IExpression expression = NewExpression();

			// Act
			query.Set(column, expression);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);
			Assert.Equal(column, columnExpressionPair.Item1);
			Assert.Equal(expression, columnExpressionPair.Item2);

			Assert.Null(query.Condition);
		}

		[Fact]
		public void Set_NullColumnAndNullExpressionValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, value: (IExpression)null!));

		[Fact]
		public void Set_NullColumnAndExpressionValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, NewExpression()));

		[Fact]
		public void Set_ColumnNullAndNullExpressionValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(NewColumn(), value: (IExpression)null!));

		[Fact]
		public void SetNull_Column_AddToSetCollection()
		{
			// Arrange
			Update query = NewInstance();

			ISource source = query.Source;
			IColumn column = NewColumn();

			// Act
			query.SetNull(column);

			// Assert
			Assert.Equal(source, query.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(query.SetCollection);
			Assert.Equal(column, columnExpressionPair.Item1);
			Assert.IsType<NullValue>(columnExpressionPair.Item2);

			Assert.Null(query.Condition);
		}

		[Fact]
		public void SetNull_NullColumn_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().SetNull(column: null!));

		[Fact]
        public void RenderQuery_RendererAndSql_WritesSqlToSql()
        {
            // Arrange
            Update query = new Update("test_name");

            const string expectedSql = "test_sql";

            Mock<IRenderer> rendererMock = new Mock<IRenderer>();
            rendererMock.Setup(ca => ca.RenderQuery(It.IsAny<Update>(), It.IsAny<StringBuilder>()))
                .Callback((Update query, StringBuilder sql) => sql.Append(expectedSql));

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
            Update query = new Update("test_name");

            const string expectedSql = "test_sql";

            Mock<IRenderer> rendererMock = new Mock<IRenderer>();
            rendererMock.Setup(ca => ca.RenderQuery(It.IsAny<Update>(), It.IsAny<StringBuilder>()))
                .Callback((Update query, StringBuilder sql) => sql.Append(expectedSql));

            IRenderer renderer = rendererMock.Object;

            // Act
            string sql = query.RenderQuery(renderer);

            // Assert
            Assert.Equal(expectedSql, sql.ToString());
        }

        private static Update NewInstance() => new Update("test_name");
    }
}
