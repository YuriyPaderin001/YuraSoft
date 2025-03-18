using System;
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
			Update update = new Update(tableName);

			// Assert
			AssertTable(update.Source, tableName);
			Assert.Empty(update.SetCollection);
			Assert.Null(update.Condition);
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
			Update update = new Update(tableName, tableSchema);

			// Assert
			AssertTable(update.Source, tableName, alias: null, tableSchema);
			Assert.Empty(update.SetCollection);
			Assert.Null(update.Condition);
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
			Update update = new Update(tableName, tableAlias, tableSchema);

			// Assert
			AssertTable(update.Source, tableName, tableAlias, tableSchema);
			Assert.Empty(update.SetCollection);
			Assert.Null(update.Condition);
		}

		[Fact]
		public void Constructor_Source_Success()
		{
			// Arrange
			Table source = new Table("test_name", "test_alias", "test_schema");

			// Act
			Update update = new Update(source);

			// Assert

			AssertTable(update.Source, source);
			Assert.Empty(update.SetCollection);
			Assert.Null(update.Condition);
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
		public void Set_ColumnNameAndSbyteValue_AddToSetCollection(sbyte value) =>
			Set_ColumnNameAndValue_AddToSetCollection<sbyte, Int8Value>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndNullableSbyteValue_AddToSetCollection(int? intValue) =>
			Set_ColumnNameAndNullableValue_AddToSetCollection<sbyte, Int8Value>((sbyte?)intValue, update => update.Set);

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Set_NullOrEmptyColumnNameAndSbyteValue_ThrowsArgumentException(string? columnName) =>
            Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, (sbyte)1));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndNullableSbyteValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, (sbyte?)null));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndShortValue_AddToSetCollection(short value) =>
			Set_ColumnNameAndValue_AddToSetCollection<short, Int16Value>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndNullableShortValue_AddToSetCollection(int? intValue) =>
			Set_ColumnNameAndNullableValue_AddToSetCollection<short, Int16Value>((short?)intValue, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndShortValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, (short)1));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndNullableShortValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, (short?)1));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndIntValue_AddToSetCollection(int value) =>
			Set_ColumnNameAndValue_AddToSetCollection<int, Int32Value>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndNullableIntValue_AddToSetCollection(int? value) =>
			Set_ColumnNameAndNullableValue_AddToSetCollection<int, Int32Value>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndIntValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, 1));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndNullableValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, (int?)1));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndLongValue_AddToSetCollection(long value) =>
			Set_ColumnNameAndValue_AddToSetCollection<long, Int64Value>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData(-3L)]
		[InlineData(0L)]
		[InlineData(3L)]
		public void Set_ColumnNameAndNullableLongValue_AddToSetCollection(long? value) =>
			Set_ColumnNameAndNullableValue_AddToSetCollection<long, Int64Value>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndLongValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, (long)1));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndNullableLongValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, (long?)1));

		[Theory]
		[InlineData(-3.3f)]
		[InlineData(0f)]
		[InlineData(3.2f)]
		public void Set_ColumnNameAndFloatValue_AddToSetCollection(float value) =>
			Set_ColumnNameAndValue_AddToSetCollection<float, FloatValue>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData(-3.3f)]
		[InlineData(0f)]
		[InlineData(3.2f)]
		public void Set_ColumnNameAndNullableFloatValue_AddToSetCollection(float? value) =>
			Set_ColumnNameAndNullableValue_AddToSetCollection<float, FloatValue>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndFloatValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, 1.3f));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndNullableFloatValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, (float?)1.3f));

		[Theory]
		[InlineData(-3.3d)]
		[InlineData(0d)]
		[InlineData(3.2d)]
		public void Set_ColumnNameAndDoubleValue_AddToSetCollection(double value) =>
			Set_ColumnNameAndValue_AddToSetCollection<double, DoubleValue>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData(-3.3d)]
		[InlineData(0d)]
		[InlineData(3.2d)]
		public void Set_ColumnNameAndNullableDoubleValue_AddToSetCollection(double? value) =>
			Set_ColumnNameAndNullableValue_AddToSetCollection<double, DoubleValue>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndDoubleValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, 1.3d));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndNullableDoubleValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, (double?)1.3d));

		[Theory]
		[InlineData(-3.3d)]
		[InlineData(0d)]
		[InlineData(3.2d)]
		public void Set_ColumnNameAndDecimalValue_AddToSetCollection(decimal value) =>
			Set_ColumnNameAndValue_AddToSetCollection<decimal, DecimalValue>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData(-3.3d)]
		[InlineData(0d)]
		[InlineData(3.2d)]
		public void Set_ColumnNameAndNullableDecimalValue_AddToSetCollection(double? value) =>
			Set_ColumnNameAndNullableValue_AddToSetCollection<decimal, DecimalValue>((decimal?)value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndDecimalValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, 1.3m));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndNullableDecimalValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, (decimal?)1.3m));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("yyyy-MM-ddTHH:mm:ss")]
		public void Set_ColumnNameAndDateTimeValue_AddToSetCollection(string? format) =>
			Set_ColumnNameAndValue_AddToSetCollection(new DateTime(2023, 11, 21, 23, 12, 32), format, update => update.Set);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "yyyy-MM-ddTHH:mm:ss")]
		[InlineData("2023-11-21 23:12:32", null)]
		[InlineData("2023-11-21 23:12:32", "")]
		[InlineData("2023-11-21 23:12:32", "yyyy-MM-ddTHH:mm:ss")]
		public void Set_ColumnNameAndNullableDateTimeValue_AddToSetCollection(string? dateTimeString, string? format) =>
			Set_ColumnNameAndNullableValue_AddToSetCollection(string.IsNullOrEmpty(dateTimeString) 
				? (DateTime?)null : DateTime.Parse(dateTimeString), format, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndDateTimeValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, new DateTime(2023, 11, 21, 23, 12, 32)));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndNullableDateTimeValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, (DateTime?)new DateTime(2023, 11, 21, 23, 12, 32)));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("string")]
		public void Set_ColumnNameAndStringValue_AddToSetCollection(string? str) =>
			Set_ColumnNameAndValue_AddToSetCollection<string, StringValue>(str!, update => update.Set);
		
		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndStringValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, "string"));

		[Fact]
		public void Set_ColumnNameAndExpressionValue_AddToSetCollection()
		{
			// Arrange
			Update update = NewInstance();

			ISource source = update.Source;
			string columnName = "column_name";
            IExpression expression = NewExpression();

			// Act
			update.Set(columnName, expression);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			AssertSourceColumn(columnExpressionPair.Item1, columnName);

            Assert.Equal(expression, columnExpressionPair.Item2);

			Assert.Null(update.Condition);
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
			Update update = NewInstance();

			ISource source = update.Source;
			string columnName = "column_name";

			// Act
			update.SetNull(columnName);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			AssertSourceColumn(columnExpressionPair.Item1, columnName);

			Assert.IsType<NullValue>(columnExpressionPair.Item2);

			Assert.Null(update.Condition);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void SetNull_NullOrEmptyColumnName_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().SetNull(columnName!));

		[Theory]
		[InlineData(null, -3)]
		[InlineData(null, 0)]
		[InlineData(null, 3)]
		[InlineData("", -3)]
		[InlineData("", 0)]
		[InlineData("", 3)]
		[InlineData("table_name", -3)]
		[InlineData("table_name", 0)]
		[InlineData("table_name", 3)]
		public void Set_ColumnNameAndTableNameAndSbyteValue_AddToSetCollection(string? tableName, sbyte value) =>
			Set_ColumnNameAndTableNameAndValue_AddToSetCollection<sbyte, Int8Value>(tableName, value, update => update.Set);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, -3)]
		[InlineData(null, 0)]
		[InlineData(null, 3)]
		[InlineData("", null)]
		[InlineData("", -3)]
		[InlineData("", 0)]
		[InlineData("", 3)]
		[InlineData("table_name", null)]
		[InlineData("table_name", -3)]
		[InlineData("table_name", 0)]
		[InlineData("table_name", 3)]
		public void Set_ColumnNameAndTableNameAndNullableSbyteValue_AddToSetCollection(string? tableName, int? intValue) =>
			Set_ColumnNameAndTableNameAndNullableValue_AddToSetCollection<sbyte, Int8Value>(tableName, (sbyte?)intValue, update => update.Set);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		public void Set_NullOrEmptyColumnNameAndTableNameAndSbyteValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, (sbyte)1));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		public void Set_NullOrEmptyColumnNameAndTableNameAndNullableSbyteValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName, (sbyte?)1));

		[Theory]
		[InlineData(null, -3)]
		[InlineData(null, 0)]
		[InlineData(null, 3)]
		[InlineData("", -3)]
		[InlineData("", 0)]
		[InlineData("", 3)]
		[InlineData("table_name", -3)]
		[InlineData("table_name", 0)]
		[InlineData("table_name", 3)]
		public void Set_ColumnNameAndTableNameAndShortValue_AddToSetCollection(string? tableName, short value) =>
			Set_ColumnNameAndTableNameAndValue_AddToSetCollection<short, Int16Value>(tableName, value, update => update.Set);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, -3)]
		[InlineData(null, 0)]
		[InlineData(null, 3)]
		[InlineData("", null)]
		[InlineData("", -3)]
		[InlineData("", 0)]
		[InlineData("", 3)]
		[InlineData("table_name", null)]
		[InlineData("table_name", -3)]
		[InlineData("table_name", 0)]
		[InlineData("table_name", 3)]
		public void Set_ColumnNameAndTableNameAndNullableShortValue_AddToSetCollection(string? tableName, int? intValue) =>
			Set_ColumnNameAndTableNameAndNullableValue_AddToSetCollection<short, Int16Value>(tableName, (short?)intValue, update => update.Set);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		public void Set_NullOrEmptyColumnNameAndTableNameAndShortValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, (short)1));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		public void Set_NullOrEmptyColumnNameAndTableNameAndNullableShortValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, (short?)1));

		[Theory]
		[InlineData(null, -3)]
		[InlineData(null, 0)]
		[InlineData(null, 3)]
		[InlineData("", -3)]
		[InlineData("", 0)]
		[InlineData("", 3)]
		[InlineData("table_name", -3)]
		[InlineData("table_name", 0)]
		[InlineData("table_name", 3)]
		public void Set_ColumnNameAndTableNameAndIntValue_AddToSetCollection(string? tableName, int value) =>
			Set_ColumnNameAndTableNameAndValue_AddToSetCollection<int, Int32Value>(tableName, value, update => update.Set);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, -3)]
		[InlineData(null, 0)]
		[InlineData(null, 3)]
		[InlineData("", null)]
		[InlineData("", -3)]
		[InlineData("", 0)]
		[InlineData("", 3)]
		[InlineData("table_name", null)]
		[InlineData("table_name", -3)]
		[InlineData("table_name", 0)]
		[InlineData("table_name", 3)]
		public void Set_ColumnNameAndTableNameAndNullableIntValue_AddToSetCollection(string? tableName, int? value) =>
			Set_ColumnNameAndTableNameAndNullableValue_AddToSetCollection<int, Int32Value>(tableName, value, update => update.Set);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		public void Set_NullOrEmptyColumnNameAndTableNameAndIntValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, 1));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		public void Set_NullOrEmptyColumnNameAndTableNameAndNullableIntValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, (int?)1));

		[Theory]
		[InlineData(null, -3L)]
		[InlineData(null, 0L)]
		[InlineData(null, 3L)]
		[InlineData("", -3L)]
		[InlineData("", 0L)]
		[InlineData("", 3L)]
		[InlineData("table_name", -3L)]
		[InlineData("table_name", 0L)]
		[InlineData("table_name", 3L)]
		public void Set_ColumnNameAndTableNameAndLongValue_AddToSetCollection(string? tableName, long value) =>
			Set_ColumnNameAndTableNameAndValue_AddToSetCollection<long, Int64Value>(tableName, value, update => update.Set);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, -3L)]
		[InlineData(null, 0L)]
		[InlineData(null, 3L)]
		[InlineData("", null)]
		[InlineData("", -3L)]
		[InlineData("", 0L)]
		[InlineData("", 3L)]
		[InlineData("table_name", null)]
		[InlineData("table_name", -3L)]
		[InlineData("table_name", 0L)]
		[InlineData("table_name", 3L)]
		public void Set_ColumnNameAndTableNameAndNullableLongValue_AddToSetCollection(string? tableName, long? value) =>
			Set_ColumnNameAndTableNameAndNullableValue_AddToSetCollection<long, Int64Value>(tableName, value, update => update.Set);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		public void Set_NullOrEmptyColumnNameOrNullOrEmptyTableNameAndLongValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, (long)1));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		public void Set_NullOrEmptyColumnNameOrNullOrEmptyTableNameAndNullableLongValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, (long?)1));

		[Theory]
		[InlineData(null, -3.3f)]
		[InlineData(null, 0f)]
		[InlineData(null, 3.2f)]
		[InlineData("", -3.3f)]
		[InlineData("", 0f)]
		[InlineData("", 3.2f)]
		[InlineData("table_name", -3.3f)]
		[InlineData("table_name", 0f)]
		[InlineData("table_name", 3.2f)]
		public void Set_ColumnNameAndTableNameAndFloatValue_AddToSetCollection(string? tableName, float value) =>
			Set_ColumnNameAndTableNameAndValue_AddToSetCollection<float, FloatValue>(tableName, value, update => update.Set);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, -3.3f)]
		[InlineData(null, 0f)]
		[InlineData(null, 3.2f)]
		[InlineData("", null)]
		[InlineData("", -3.3f)]
		[InlineData("", 0f)]
		[InlineData("", 3.2f)]
		[InlineData("table_name", null)]
		[InlineData("table_name", -3.3f)]
		[InlineData("table_name", 0f)]
		[InlineData("table_name", 3.2f)]
		public void Set_ColumnNameAndTableNameAndNullableFloatValue_AddToSetCollection(string? tableName, float? value) =>
			Set_ColumnNameAndTableNameAndNullableValue_AddToSetCollection<float, FloatValue>(tableName, value, update => update.Set);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		public void Set_NullOrEmptyColumnNameAndTableNameAndFloatValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, 1.3f));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		public void Set_NullOrEmptyColumnNameAndTableNameAndNullableFloatValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, (float?)1.3f));

		[Theory]
		[InlineData(null, -3.3d)]
		[InlineData(null, 0d)]
		[InlineData(null, 3.2d)]
		[InlineData("", -3.3d)]
		[InlineData("", 0d)]
		[InlineData("", 3.2d)]
		[InlineData("table_name", -3.3d)]
		[InlineData("table_name", 0d)]
		[InlineData("table_name", 3.2d)]
		public void Set_ColumnNameAndTableNameAndDoubleValue_AddToSetCollection(string? tableName, double value) =>
			Set_ColumnNameAndTableNameAndValue_AddToSetCollection<double, DoubleValue>(tableName, value, update => update.Set);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, -3.3d)]
		[InlineData(null, 0d)]
		[InlineData(null, 3.2d)]
		[InlineData("", null)]
		[InlineData("", -3.3d)]
		[InlineData("", 0d)]
		[InlineData("", 3.2d)]
		[InlineData("table_name", null)]
		[InlineData("table_name", -3.3d)]
		[InlineData("table_name", 0d)]
		[InlineData("table_name", 3.2d)]
		public void Set_ColumnNameAndTableNameAndNullableDoubleValue_AddToSetCollection(string? tableName, double? value) =>
			Set_ColumnNameAndTableNameAndNullableValue_AddToSetCollection<double, DoubleValue>(tableName, value, update => update.Set);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		public void Set_NullOrEmptyColumnNameAndTableNameAndDoubleValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, 1.3d));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		public void Set_NullOrEmptyColumnNameAndTableNameAndNullableDoubleValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, (double?)1.3d));

		[Theory]
		[InlineData(null, -3.3d)]
		[InlineData(null, 0d)]
		[InlineData(null, 3.2d)]
		[InlineData("", -3.3d)]
		[InlineData("", 0d)]
		[InlineData("", 3.2d)]
		[InlineData("table_name", -3.3d)]
		[InlineData("table_name", 0d)]
		[InlineData("table_name", 3.2d)]
		public void Set_ColumnNameAndTableNameAndDecimalValue_AddToSetCollection(string? tableName, decimal value) =>
			Set_ColumnNameAndTableNameAndValue_AddToSetCollection<decimal, DecimalValue>(tableName, value, update => update.Set);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, -3.3d)]
		[InlineData(null, 0d)]
		[InlineData(null, 3.2d)]
		[InlineData("", null)]
		[InlineData("", -3.3d)]
		[InlineData("", 0d)]
		[InlineData("", 3.2d)]
		[InlineData("table_name", null)]
		[InlineData("table_name", -3.3d)]
		[InlineData("table_name", 0d)]
		[InlineData("table_name", 3.2d)]
		public void Set_ColumnNameAndTableNameAndNullableDecimalValue_AddToSetCollection(string? tableName, double? doubleValue) =>
			Set_ColumnNameAndTableNameAndNullableValue_AddToSetCollection<decimal, DecimalValue>(tableName, (decimal?)doubleValue, update => update.Set);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		public void Set_NullOrEmptyColumnNameAndTableNameAndDecimalValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, 1.3m));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		public void Set_NullOrEmptyColumnNameAndTableNameAndNullableDecimalValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, (decimal?)1.3m));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "yyyy-MM-dd HH:mm:ss")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "yyyy-MM-dd HH:mm:ss")]
		[InlineData("table_name", null)]
		[InlineData("table_name", "")]
		[InlineData("table_name", "yyyy-MM-dd HH:mm:ss")]
		public void Set_ColumnNameAndTableNameAndDateTimeValue_AddToSetCollection(string? tableName, string? format) =>
			Set_ColumnNameAndTableNameAndValue_AddToSetCollection(tableName, new DateTime(2023, 11, 21, 23, 12, 32), format, update => update.Set);

		[Theory]
		[InlineData(null, null, null)]
		[InlineData(null, null, "")]
		[InlineData(null, null, "yyyy-MM-dd HH:mm:ss")]
		[InlineData(null, "2023-11-21 23:12:32", null)]
		[InlineData(null, "2023-11-21 23:12:32", "")]
		[InlineData(null, "2023-11-21 23:12:32", "yyyy-MM-dd HH:mm:ss")]
		[InlineData("", null, null)]
		[InlineData("", null, "")]
		[InlineData("", null, "yyyy-MM-dd HH:mm:ss")]
		[InlineData("", "2023-11-21 23:12:32", null)]
		[InlineData("", "2023-11-21 23:12:32", "")]
		[InlineData("", "2023-11-21 23:12:32", "yyyy-MM-dd HH:mm:ss")]
		[InlineData("table_name", null, null)]
		[InlineData("table_name", null, "")]
		[InlineData("table_name", null, "yyyy-MM-dd HH:mm:ss")]
		[InlineData("table_name", "2023-11-21 23:12:32", null)]
		[InlineData("table_name", "2023-11-21 23:12:32", "")]
		[InlineData("table_name", "2023-11-21 23:12:32", "yyyy-MM-dd HH:mm:ss")]
		public void Set_ColumnNameAndTableNameAndNullableDateTimeValue_AddToSetCollection(string? tableName, string? dateTimeString, string? format) =>
			Set_ColumnNameAndTableNameAndNullableValue_AddToSetCollection(tableName, string.IsNullOrEmpty(dateTimeString) ? (DateTime?)null : DateTime.Parse(dateTimeString), format, update => update.Set);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		public void Set_NullOrEmptyColumnNameAndTableNameAndDateTimeValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, new DateTime(2023, 11, 21, 23, 12, 32)));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		public void Set_NullOrEmptyColumnNameAndTableNameAndNullableDateTimeValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, (DateTime?)new DateTime(2023, 11, 21, 23, 12, 32)));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "string")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "string")]
		[InlineData("table_name", null)]
		[InlineData("table_name", "")]
		[InlineData("table_name", "string")]
		public void Set_ColumnNameAndTableNameAndStringValue_AddToSetCollection(string? tableName, string? str) =>
			Set_ColumnNameAndTableNameAndValue_AddToSetCollection<string, StringValue>(tableName, str!, update => update.Set);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		public void Set_NullOrEmptyColumnNameAndTableNameAndStringValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, "string"));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("table_name")]
		public void Set_ColumnNameAndTableNameAndExpressionValue_AddToSetCollection(string? tableName)
		{
			// Arrange
			Update update = NewInstance();

			ISource source = update.Source;
			const string columnName = "column_name";
			
			IExpression expression = NewExpression();

			// Act
			update.Set(columnName, tableName, expression);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			AssertSourceColumn(columnExpressionPair.Item1, columnName, alias: null, tableName);

			Assert.Equal(expression, columnExpressionPair.Item2);

			Assert.Null(update.Condition);
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		public void Set_NullOrEmptyColumnNameAndTableNameAndExpressionValue_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, tableName!, NewExpression()));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("table_name")]
		public void Set_ColumnNameAndTableNameAndNullExpressionValue_ThrowsArgumentNullException(string? tableName) =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set("column_name", tableName, value: (IExpression)null!));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("table_name")]
		public void SetNull_ColumnNameAndTableName_AddToSetCollection(string? tableName)
		{
			// Arrange
			Update update = NewInstance();

			ISource source = update.Source;
			const string columnName = "column_name";

			// Act
			update.SetNull(columnName, tableName);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			AssertSourceColumn(columnExpressionPair.Item1, columnName, alias: null, tableName);

			Assert.IsType<NullValue>(columnExpressionPair.Item2);

			Assert.Null(update.Condition);
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_name")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "table_name")]
		public void SetNull_NullOrEmptyColumnNameAndTableName_ThrowsArgumentException(string? columnName, string? tableName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().SetNull(columnName!, tableName!));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndColumnSourceAndSbyteValue_AddToSetCollection(sbyte value) =>
			Set_ColumnNameAndColumnSourceAndValue_AddToSetCollection<sbyte, Int8Value>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndColumnSourceAndNullableSbyteValue_AddToSetCollection(int? value) =>
			Set_ColumnNameAndColumnSourceAndNullableValue_AddToSetCollection<sbyte, Int8Value>((sbyte?)value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndSbyteValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), (sbyte)1));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndNullableSbyteValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), (sbyte?)1));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndColumnSourceAndShortValue_AddToSetCollection(short value) =>
			Set_ColumnNameAndColumnSourceAndValue_AddToSetCollection<short, Int16Value>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndColumnSourceAndNullableShortValue_AddToSetCollection(int? value) =>
			Set_ColumnNameAndColumnSourceAndNullableValue_AddToSetCollection<short, Int16Value>((short?)value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndShortValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), (short)1));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndNullableShortValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), (short?)1));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndColumnSourceAndIntValue_AddToSetCollection(int value) =>
			Set_ColumnNameAndColumnSourceAndValue_AddToSetCollection<int, Int32Value>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnNameAndColumnSourceAndNullableIntValue_AddToSetCollection(int? value) =>
			Set_ColumnNameAndColumnSourceAndNullableValue_AddToSetCollection<int, Int32Value>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndIntValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), 1));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndNullableIntValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), (int?)1));

		[Theory]
		[InlineData(-3L)]
		[InlineData(0L)]
		[InlineData(3L)]
		public void Set_ColumnNameAndColumnSourceAndLongValue_AddToSetCollection(long value) =>
			Set_ColumnNameAndColumnSourceAndValue_AddToSetCollection<long, Int64Value>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData(-3L)]
		[InlineData(0L)]
		[InlineData(3L)]
		public void Set_ColumnNameAndColumnSourceAndNullableLongValue_AddToSetCollection(long? value) =>
			Set_ColumnNameAndColumnSourceAndNullableValue_AddToSetCollection<long, Int64Value>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndLongValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), (long)1));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndNullableLongValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), (long?)1));

		[Theory]
		[InlineData(-3.3f)]
		[InlineData(0f)]
		[InlineData(3.2f)]
		public void Set_ColumnNameAndColumnSourceAndFloatValue_AddToSetCollection(float value) =>
			Set_ColumnNameAndColumnSourceAndValue_AddToSetCollection<float, FloatValue>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData(-3.3f)]
		[InlineData(0f)]
		[InlineData(3.2f)]
		public void Set_ColumnNameAndColumnSourceAndNullableFloatValue_AddToSetCollection(float? value) =>
			Set_ColumnNameAndColumnSourceAndNullableValue_AddToSetCollection<float, FloatValue>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndFloatValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), 1.3f));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndNullableFloatValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), (float?)1.3f));

		[Theory]
		[InlineData(-3.3d)]
		[InlineData(0d)]
		[InlineData(3.2d)]
		public void Set_ColumnNameAndColumnSourceAndDoubleValue_AddToSetCollection(double value) =>
			Set_ColumnNameAndColumnSourceAndValue_AddToSetCollection<double, DoubleValue>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData(-3.3d)]
		[InlineData(0d)]
		[InlineData(3.2d)]
		public void Set_ColumnNameAndColumnSourceAndNullableDoubleValue_AddToSetCollection(double? value) =>
			Set_ColumnNameAndColumnSourceAndNullableValue_AddToSetCollection<double, DoubleValue>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndDoubleValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), 1.3d));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndNullableDoubleValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), (double?)1.3d));

		[Theory]
		[InlineData(-3.3d)]
		[InlineData(0d)]
		[InlineData(3.2d)]
		public void Set_ColumnNameAndColumnSourceAndDecimalValue_AddToSetCollection(decimal value) =>
			Set_ColumnNameAndColumnSourceAndValue_AddToSetCollection<decimal, DecimalValue>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData(-3.3d)]
		[InlineData(0d)]
		[InlineData(3.2d)]
		public void Set_ColumnNameAndColumnSourceAndNullableDecimalValue_AddToSetCollection(double? value) =>
			Set_ColumnNameAndColumnSourceAndNullableValue_AddToSetCollection<decimal, DecimalValue>((decimal?)value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndDecimalValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), 1.3m));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndNullableDecimalValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), (decimal?)1.3m));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("yyyy-MM-dd HH:mm:ss")]
		public void Set_ColumnNameAndColumnSourceAndDateTimeValue_AddToSetCollection(string? format) =>
			Set_ColumnNameAndColumnSourceAndValue_AddToSetCollection(new DateTime(2023, 11, 21, 23, 12, 32), format, update => update.Set);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "yyyy-MM-dd HH:mm:ss")]
		[InlineData("2023-11-21 23:12:32", null)]
		[InlineData("2023-11-21 23:12:32", "")]
		[InlineData("2023-11-21 23:12:32", "yyyy-MM-dd HH:mm:ss")]
		public void Set_ColumnNameAndColumnSourceAndNullableDateTimeValue_AddToSetCollection(string? dateTimeString, string? format) =>
			Set_ColumnNameAndColumnSourceAndNullableValue_AddToSetCollection(
				string.IsNullOrEmpty(dateTimeString) ? (DateTime?)null : DateTime.Parse(dateTimeString), format, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndDateTimeValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), new DateTime(2023, 11, 21, 23, 12, 32)));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndNullableDateTimeValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), (DateTime?)new DateTime(2023, 11, 21, 23, 12, 32)));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("string")]
		public void Set_ColumnNameAndColumnSourceAndStringValue_AddToSetCollection(string? str) =>
			Set_ColumnNameAndColumnSourceAndValue_AddToSetCollection<string, StringValue>(str!, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Set_NullOrEmptyColumnNameAndColumnSourceAndStringValue_ThrowsArgumentException(string? columnName) =>
			Assert.Throws<ArgumentException>(() => NewInstance().Set(columnName!, NewSource(), "string"));

		[Fact]
		public void Set_ColumnNameAndColumnSourceAndExpressionValue_AddToSetCollection()
		{
			// Arrange
			Update update = NewInstance();

			ISource source = update.Source;
			const string columnName = "column_name";
			ISource columnSource = NewSource();

			IExpression expression = NewExpression();

			// Act
			update.Set(columnName, columnSource, expression);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			AssertSourceColumn(columnExpressionPair.Item1, columnName, alias: null, columnSource);

			Assert.Equal(expression, columnExpressionPair.Item2);

			Assert.Null(update.Condition);
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
			Update update = NewInstance();

			ISource source = update.Source;
			const string columnName = "column_name";
			ISource columnSource = NewSource();

			// Act
			update.SetNull(columnName, columnSource);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			AssertSourceColumn(columnExpressionPair.Item1, columnName, alias: null, columnSource);

			Assert.IsType<NullValue>(columnExpressionPair.Item2);

			Assert.Null(update.Condition);
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
		public void Set_ColumnAndSbyteValue_AddToSetCollection(sbyte value) =>
			Set_ColumnAndValue_AddToSetCollection<sbyte, Int8Value>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnAndNullableSbyteValue_AddToSetCollection(int? value) =>
			Set_ColumnAndNullableValue_AddToSetCollection<sbyte, Int8Value>((sbyte?)value, update => update.Set);

		[Fact]
		public void Set_NullColumnAndSbyteValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, (sbyte)1));

		[Fact]
		public void Set_NullColumnAndNullableSbyteValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, (sbyte?)1));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnAndShortValue_AddToSetCollection(short value) =>
			Set_ColumnAndValue_AddToSetCollection<short, Int16Value>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnAndNullableShortValue_AddToSetCollection(int? value) =>
			Set_ColumnAndNullableValue_AddToSetCollection<short, Int16Value>((short?)value, update => update.Set);

		[Fact]
		public void Set_NullColumnAndShortValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, (short)1));

		[Fact]
		public void Set_NullColumnAndNullableShortValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, (short?)1));

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnAndIntValue_AddToSetCollection(int value) =>
			Set_ColumnAndValue_AddToSetCollection<int, Int32Value>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(3)]
		public void Set_ColumnAndNullableIntValue_AddToSetCollection(int? value) =>
			Set_ColumnAndNullableValue_AddToSetCollection<int, Int32Value>(value, update => update.Set);

		[Fact]
		public void Set_NullColumnAndIntValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, 1));

		[Fact]
		public void Set_NullColumnAndNullableIntValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, (int?)1));

		[Theory]
		[InlineData(-3L)]
		[InlineData(0L)]
		[InlineData(3L)]
		public void Set_ColumnAndLongValue_AddToSetCollection(long value) =>
			Set_ColumnAndValue_AddToSetCollection<long, Int64Value>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData(-3L)]
		[InlineData(0L)]
		[InlineData(3L)]
		public void Set_ColumnAndNullableLongValue_AddToSetCollection(long? value) =>
			Set_ColumnAndNullableValue_AddToSetCollection<long, Int64Value>(value, update => update.Set);

		[Fact]
		public void Set_NullColumnAndLongValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, (long)1));

		[Fact]
		public void Set_NullColumnAndNullableLongValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, (long?)1));

		[Theory]
		[InlineData(-3.3f)]
		[InlineData(0f)]
		[InlineData(3.2f)]
		public void Set_ColumnAndFloatValue_AddToSetCollection(float value) =>
			Set_ColumnAndValue_AddToSetCollection<float, FloatValue>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData(-3.3f)]
		[InlineData(0f)]
		[InlineData(3.2f)]
		public void Set_ColumnAndNullableFloatValue_AddToSetCollection(float? value) =>
			Set_ColumnAndNullableValue_AddToSetCollection<float, FloatValue>(value, update => update.Set);

		[Fact]
		public void Set_NullColumnAndFloatValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, 1.3f));

		[Fact]
		public void Set_NullColumnAndNullableFloatValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, (float?)1.3f));

		[Theory]
		[InlineData(-3.3d)]
		[InlineData(0d)]
		[InlineData(3.2d)]
		public void Set_ColumnAndDoubleValue_AddToSetCollection(double value) =>
			Set_ColumnAndValue_AddToSetCollection<double, DoubleValue>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData(-3.3d)]
		[InlineData(0d)]
		[InlineData(3.2d)]
		public void Set_ColumnAndNullableDoubleValue_AddToSetCollection(double? value) =>
			Set_ColumnAndNullableValue_AddToSetCollection<double, DoubleValue>(value, update => update.Set);

		[Fact]
		public void Set_NullColumnAndDoubleValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, 1.3d));

		[Fact]
		public void Set_NullColumnAndNullableDoubleValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, (double?)1.3d));

		[Theory]
		[InlineData(-3.3d)]
		[InlineData(0d)]
		[InlineData(3.2d)]
		public void Set_ColumnAndDecimalValue_AddToSetCollection(decimal value) =>
			Set_ColumnAndValue_AddToSetCollection<decimal, DecimalValue>(value, update => update.Set);

		[Theory]
		[InlineData(null)]
		[InlineData(-3.3d)]
		[InlineData(0d)]
		[InlineData(3.2d)]
		public void Set_ColumnAndNullableDecimalValue_AddToSetCollection(double? value) =>
			Set_ColumnAndNullableValue_AddToSetCollection<decimal, DecimalValue>((decimal?)value, update => update.Set);

		[Fact]
		public void Set_NullColumnAndDecimalValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, 1.3m));

		[Fact]
		public void Set_NullColumnAndNullableDecimalValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, (decimal?)1.3m));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("yyyy-MM-dd HH:mm:ss")]
		public void Set_ColumnAndDateTimeValue_AddToSetCollection(string? format) =>
			Set_ColumnAndValue_AddToSetCollection(new DateTime(2023, 11, 21, 23, 12, 32), format, update => update.Set);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "yyyy-MM-dd HH:mm:ss")]
		[InlineData("2023-11-21 23:12:32", null)]
		[InlineData("2023-11-21 23:12:32", "")]
		[InlineData("2023-11-21 23:12:32", "yyyy-MM-dd HH:mm:ss")]
		public void Set_ColumnAndNullableDateTimeValue_AddToSetCollection(string? dateTimeString, string? format) =>
			Set_ColumnAndNullableValue_AddToSetCollection(string.IsNullOrEmpty(dateTimeString) ? (DateTime?)null : DateTime.Parse(dateTimeString), format, update => update.Set);

		[Fact]
		public void Set_NullColumnAndDateTimeValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, new DateTime(2023, 11, 21, 23, 12, 32)));

		[Fact]
		public void Set_NullColumnAndNullableDateTimeValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, (DateTime?)new DateTime(2023, 11, 21, 23, 12, 32)));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("string")]
		public void Set_ColumnAndStringValue_AddToSetCollection(string? str) =>
			Set_ColumnAndValue_AddToSetCollection<string, StringValue>(str!, update => update.Set);

		[Fact]
		public void Set_ColumnAndNullStringValue_AddToSetCollection()
		{
			// Arrange
			Update update = NewInstance();

			ISource source = update.Source;
			IColumn column = NewColumn();

			string? nullString = null;

			// Act
			update.Set(column, nullString);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			Assert.Equal(column, columnExpressionPair.Item1);
			Assert.IsType<NullValue>(columnExpressionPair.Item2);

			Assert.Null(update.Condition);
		}

		[Fact]
		public void Set_NullColumnAndNullStringValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, value: (string)null!));

		[Fact]
		public void Set_NullColumnAndStringValue_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().Set(column: null!, "string"));

		[Fact]
		public void Set_ColumnAndExpressionValue_AddToSetCollection()
		{
			// Arrange
			Update update = NewInstance();

			ISource source = update.Source;
			IColumn column = NewColumn();

			IExpression expression = NewExpression();

			// Act
			update.Set(column, expression);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			Assert.Equal(column, columnExpressionPair.Item1);
			Assert.Equal(expression, columnExpressionPair.Item2);

			Assert.Null(update.Condition);
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
			Update update = NewInstance();

			ISource source = update.Source;
			IColumn column = NewColumn();

			// Act
			update.SetNull(column);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			Assert.Equal(column, columnExpressionPair.Item1);
			Assert.IsType<NullValue>(columnExpressionPair.Item2);

			Assert.Null(update.Condition);
		}

		[Fact]
		public void SetNull_NullColumn_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => NewInstance().SetNull(column: null!));

		[Fact]
        public void RenderQuery_RendererAndSql_WritesSqlToSql()
        {
            // Arrange
            Update update = new Update("test_name");

            const string expectedSql = "test_sql";

            Mock<IRenderer> rendererMock = new Mock<IRenderer>();
            rendererMock.Setup(ca => ca.RenderQuery(It.IsAny<Update>(), It.IsAny<StringBuilder>()))
                .Callback((Update update, StringBuilder sql) => sql.Append(expectedSql));

            IRenderer renderer = rendererMock.Object;
            StringBuilder sql = new StringBuilder();

            // Act
            update.RenderQuery(renderer, sql);

            // Assert
            Assert.Equal(expectedSql, sql.ToString());
        }

        [Fact]
        public void RenderQuery_Renderer_ReturnsSql()
        {
            // Arrange
            Update update = new Update("test_name");

            const string expectedSql = "test_sql";

            Mock<IRenderer> rendererMock = new Mock<IRenderer>();
            rendererMock.Setup(ca => ca.RenderQuery(It.IsAny<Update>(), It.IsAny<StringBuilder>()))
                .Callback((Update update, StringBuilder sql) => sql.Append(expectedSql));

            IRenderer renderer = rendererMock.Object;

            // Act
            string sql = update.RenderQuery(renderer);

            // Assert
            Assert.Equal(expectedSql, sql.ToString());
        }

        private static Update NewInstance() => new Update("test_name");

		private void Set_ColumnNameAndNullableValue_AddToSetCollection(
			DateTime? nullableValue, string? format, Func<Update, Func<string, DateTime?, string?, Update>> setMethodSelector)
		{
			// Arrange
			Update update = NewInstance();

			ISource source = update.Source;
			string columnName = "column_name";

			// Act
			Func<string, DateTime?, string?, Update> setMethod = setMethodSelector.Invoke(update);
			setMethod.Invoke(columnName, nullableValue, format);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			AssertSourceColumn(columnExpressionPair.Item1, columnName);

			if (nullableValue.HasValue)
			{
				DateTimeValue elementValue = Assert.IsType<DateTimeValue>(columnExpressionPair.Item2);
				Assert.Equal(nullableValue.Value, elementValue.Data);

				if (string.IsNullOrEmpty(format))
				{
					Assert.Equal("o", elementValue.Format);
				}
				else
				{
					Assert.Equal(format, elementValue.Format);
				}
			}
			else
			{
				Assert.IsType<NullValue>(columnExpressionPair.Item2);
			}

			Assert.Null(update.Condition);
		}

		private void Set_ColumnNameAndNullableValue_AddToSetCollection<TValue, TElementValue>(
			TValue? nullableValue, Func<Update, Func<string, TValue?, Update>> setMethodSelector)
			where TValue : struct
			where TElementValue : DataValue<TValue>
		{
			// Arrange
			Update update = NewInstance();

			ISource source = update.Source;
			string columnName = "column_name";

			// Act
			Func<string, TValue?, Update> setMethod = setMethodSelector.Invoke(update);
			setMethod.Invoke(columnName, nullableValue);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			AssertSourceColumn(columnExpressionPair.Item1, columnName);

			if (nullableValue.HasValue)
			{
				TElementValue elementValue = Assert.IsType<TElementValue>(columnExpressionPair.Item2);
				Assert.Equal(nullableValue.Value, elementValue.Data);
			}
			else
			{
				Assert.IsType<NullValue>(columnExpressionPair.Item2);
			}

			Assert.Null(update.Condition);
		}

		private void Set_ColumnNameAndValue_AddToSetCollection(
			DateTime value, string? format, Func<Update, Func<string, DateTime, string?, Update>> setMethodSelector)
		{
			// Arrange
			Update update = NewInstance();

			ISource source = update.Source;
			string columnName = "column_name";

			// Act
			Func<string, DateTime, string?, Update> setMethod = setMethodSelector.Invoke(update);
			setMethod.Invoke(columnName, value, format);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			AssertSourceColumn(columnExpressionPair.Item1, columnName);

			DateTimeValue elementValue = Assert.IsType<DateTimeValue>(columnExpressionPair.Item2);
			Assert.Equal(value, elementValue.Data);

			if (string.IsNullOrEmpty(format))
			{
				Assert.Equal("o", elementValue.Format);
			}
			else
			{
				Assert.Equal(format, elementValue.Format);
			}

			Assert.Null(update.Condition);
		}

		private void Set_ColumnNameAndValue_AddToSetCollection<TValue, TElementValue>(
			TValue value, Func<Update, Func<string, TValue, Update>> setMethodSelector) 
			where TElementValue : DataValue<TValue>
		{
			// Arrange
			Update update = NewInstance();

			ISource source = update.Source;
			string columnName = "column_name";

			// Act
			Func<string, TValue, Update> setMethod = setMethodSelector.Invoke(update);
			setMethod.Invoke(columnName, value);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			AssertSourceColumn(columnExpressionPair.Item1, columnName);

			if (value is null)
			{
				Assert.IsType<NullValue>(columnExpressionPair.Item2);
			}
			else
			{
				TElementValue elementValue = Assert.IsType<TElementValue>(columnExpressionPair.Item2);
				Assert.Equal(value, elementValue.Data);
			}

			Assert.Null(update.Condition);
		}

		private void Set_ColumnNameAndTableNameAndNullableValue_AddToSetCollection(
			string? tableName, DateTime? nullableValue, string? format, 
			Func<Update, Func<string, string?, DateTime?, string?, Update>> setMethodSelector)
		{
			// Arrange
			Update update = NewInstance();

			ISource source = update.Source;
			string columnName = "column_name";

			// Act
			Func<string, string?, DateTime?, string?, Update> setMethod = setMethodSelector.Invoke(update);
			setMethod.Invoke(columnName, tableName, nullableValue, format);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			AssertSourceColumn(columnExpressionPair.Item1, columnName, alias: null, tableName);

			if (nullableValue.HasValue)
			{
				DateTimeValue elementValue = Assert.IsType<DateTimeValue>(columnExpressionPair.Item2);
				Assert.Equal(nullableValue.Value, elementValue.Data);

				if (string.IsNullOrEmpty(format))
				{
					Assert.Equal("o", elementValue.Format);
				}
				else
				{
					Assert.Equal(format, elementValue.Format);
				}
			}
			else
			{
				Assert.IsType<NullValue>(columnExpressionPair.Item2);
			}

			Assert.Null(update.Condition);
		}

		private void Set_ColumnNameAndTableNameAndNullableValue_AddToSetCollection<TValue, TElementValue>(
			string? tableName, TValue? nullableValue, Func<Update, Func<string, string?, TValue?, Update>> setMethodSelector)
			where TValue : struct
			where TElementValue : DataValue<TValue>
		{
			// Arrange
			Update update = NewInstance();

			ISource source = update.Source;
			string columnName = "column_name";

			// Act
			Func<string, string?, TValue?, Update> setMethod = setMethodSelector.Invoke(update);
			setMethod.Invoke(columnName, tableName, nullableValue);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			AssertSourceColumn(columnExpressionPair.Item1, columnName, alias: null, tableName);

			if (nullableValue.HasValue)
			{
				TElementValue elementValue = Assert.IsType<TElementValue>(columnExpressionPair.Item2);
				Assert.Equal(nullableValue.Value, elementValue.Data);
			}
			else
			{
				Assert.IsType<NullValue>(columnExpressionPair.Item2);
			}

			Assert.Null(update.Condition);
		}

		private void Set_ColumnNameAndTableNameAndValue_AddToSetCollection(
			string? tableName, DateTime value, string? format, 
			Func<Update, Func<string, string?, DateTime, string?, Update>> setMethodSelector)
		{
			// Arrange
			Update update = NewInstance();

			ISource source = update.Source;
			string columnName = "column_name";

			// Act
			Func<string, string?, DateTime, string?, Update> setMethod = setMethodSelector.Invoke(update);
			setMethod.Invoke(columnName, tableName, value, format);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			AssertSourceColumn(columnExpressionPair.Item1, columnName, alias: null, tableName);

			DateTimeValue elementValue = Assert.IsType<DateTimeValue>(columnExpressionPair.Item2);
			Assert.Equal(value, elementValue.Data);

			if (string.IsNullOrEmpty(format))
			{
				Assert.Equal("o", elementValue.Format);
			}
			else
			{
				Assert.Equal(format, elementValue.Format);
			}

			Assert.Null(update.Condition);
		}

		private void Set_ColumnNameAndTableNameAndValue_AddToSetCollection<TValue, TElementValue>(
			string? tableName, TValue value, Func<Update, Func<string, string?, TValue, Update>> setMethodSelector)
			where TElementValue : DataValue<TValue>
		{
			// Arrange
			Update update = NewInstance();

			ISource source = update.Source;
			string columnName = "column_name";

			// Act
			Func<string, string?, TValue, Update> setMethod = setMethodSelector.Invoke(update);
			setMethod.Invoke(columnName, tableName, value);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			AssertSourceColumn(columnExpressionPair.Item1, columnName, alias: null, tableName);

			if (value is null)
			{
				Assert.IsType<NullValue>(columnExpressionPair.Item2);
			}
			else
			{
				TElementValue elementValue = Assert.IsType<TElementValue>(columnExpressionPair.Item2);
				Assert.Equal(value, elementValue.Data);
			}

			Assert.Null(update.Condition);
		}

		private void Set_ColumnNameAndColumnSourceAndNullableValue_AddToSetCollection(
			DateTime? value, string? format,
			Func<Update, Func<string, ISource?, DateTime?, string?, Update>> setMethodSelector)
		{
			// Arrange
			Update update = NewInstance();

			ISource source = update.Source;
			string columnName = "column_name";
			ISource columnSource = NewSource();

			// Act
			Func<string, ISource?, DateTime?, string?, Update> setMethod = setMethodSelector.Invoke(update);
			setMethod.Invoke(columnName, columnSource, value, format);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			AssertSourceColumn(columnExpressionPair.Item1, columnName, alias: null, columnSource);

			if (value is null)
			{
				Assert.IsType<NullValue>(columnExpressionPair.Item2);
			}
			else
			{
				DateTimeValue elementValue = Assert.IsType<DateTimeValue>(columnExpressionPair.Item2);
				Assert.Equal(value, elementValue.Data);

				if (string.IsNullOrEmpty(format))
				{
					Assert.Equal("o", elementValue.Format);
				}
				else
				{
					Assert.Equal(format, elementValue.Format);
				}
			}

			Assert.Null(update.Condition);
		}

		private void Set_ColumnNameAndColumnSourceAndNullableValue_AddToSetCollection<TValue, TElementValue>(
			TValue? value, Func<Update, Func<string, ISource, TValue?, Update>> setMethodSelector)
			where TValue : struct
			where TElementValue : DataValue<TValue>
		{
			// Arrange
			Update update = NewInstance();

			ISource source = update.Source;
			string columnName = "column_name";
			ISource columnSource = NewSource();

			// Act
			Func<string, ISource, TValue?, Update> setMethod = setMethodSelector.Invoke(update);
			setMethod.Invoke(columnName, columnSource, value);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			AssertSourceColumn(columnExpressionPair.Item1, columnName, alias: null, columnSource);

			if (value is null)
			{
				Assert.IsType<NullValue>(columnExpressionPair.Item2);
			}
			else
			{
				TElementValue elementValue = Assert.IsType<TElementValue>(columnExpressionPair.Item2);
				Assert.Equal(value, elementValue.Data);
			}

			Assert.Null(update.Condition);
		}

		private void Set_ColumnNameAndColumnSourceAndValue_AddToSetCollection(
			DateTime value, string? format,
			Func<Update, Func<string, ISource?, DateTime, string?, Update>> setMethodSelector)
		{
			// Arrange
			Update update = NewInstance();

			ISource source = update.Source;
			string columnName = "column_name";
			ISource columnSource = NewSource();

			// Act
			Func<string, ISource?, DateTime, string?, Update> setMethod = setMethodSelector.Invoke(update);
			setMethod.Invoke(columnName, columnSource, value, format);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			AssertSourceColumn(columnExpressionPair.Item1, columnName, alias: null, columnSource);

			DateTimeValue elementValue = Assert.IsType<DateTimeValue>(columnExpressionPair.Item2);
			Assert.Equal(value, elementValue.Data);

			if (string.IsNullOrEmpty(format))
			{
				Assert.Equal("o", elementValue.Format);
			}
			else
			{
				Assert.Equal(format, elementValue.Format);
			}

			Assert.Null(update.Condition);
		}

		private void Set_ColumnNameAndColumnSourceAndValue_AddToSetCollection<TValue, TElementValue>(
			TValue value, Func<Update, Func<string, ISource, TValue, Update>> setMethodSelector)
			where TElementValue : DataValue<TValue>
		{
			// Arrange
			Update update = NewInstance();

			ISource source = update.Source;
			string columnName = "column_name";
			ISource columnSource = NewSource();

			// Act
			Func<string, ISource, TValue, Update> setMethod = setMethodSelector.Invoke(update);
			setMethod.Invoke(columnName, columnSource, value);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			AssertSourceColumn(columnExpressionPair.Item1, columnName, alias: null, columnSource);

			if (value is null)
			{
				Assert.IsType<NullValue>(columnExpressionPair.Item2);
			}
			else
			{
				TElementValue elementValue = Assert.IsType<TElementValue>(columnExpressionPair.Item2);
				Assert.Equal(value, elementValue.Data);
			}
			
			Assert.Null(update.Condition);
		}

		private void Set_ColumnAndNullableValue_AddToSetCollection(
			DateTime? value, string? format,
			Func<Update, Func<IColumn, DateTime?, string?, Update>> setMethodSelector)
		{
			// Arrange
			Update update = NewInstance();

			ISource source = update.Source;
			IColumn column = NewColumn();

			// Act
			Func<IColumn, DateTime?, string?, Update> setMethod = setMethodSelector.Invoke(update);
			setMethod.Invoke(column, value, format);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			Assert.Equal(column, columnExpressionPair.Item1);

			if (value is null)
			{
				Assert.IsType<NullValue>(columnExpressionPair.Item2);
			}
			else
			{
				DateTimeValue elementValue = Assert.IsType<DateTimeValue>(columnExpressionPair.Item2);
				Assert.Equal(value, elementValue.Data);

				if (string.IsNullOrEmpty(format))
				{
					Assert.Equal("o", elementValue.Format);
				}
				else
				{
					Assert.Equal(format, elementValue.Format);
				}
			}

			Assert.Null(update.Condition);
		}

		private void Set_ColumnAndNullableValue_AddToSetCollection<TValue, TElementValue>(
			TValue? value, Func<Update, Func<IColumn, TValue?, Update>> setMethodSelector)
			where TValue : struct
			where TElementValue : DataValue<TValue>
		{
			// Arrange
			Update update = NewInstance();

			ISource source = update.Source;
			IColumn column = NewColumn();

			// Act
			Func<IColumn, TValue?, Update> setMethod = setMethodSelector.Invoke(update);
			setMethod.Invoke(column, value);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			Assert.Equal(column, columnExpressionPair.Item1);

			if (value is null)
			{
				Assert.IsType<NullValue>(columnExpressionPair.Item2);
			}
			else
			{
				TElementValue elementValue = Assert.IsType<TElementValue>(columnExpressionPair.Item2);
				Assert.Equal(value, elementValue.Data);
			}

			Assert.Null(update.Condition);
		}

		private void Set_ColumnAndValue_AddToSetCollection(
			DateTime value, string? format,
			Func<Update, Func<IColumn, DateTime, string?, Update>> setMethodSelector)
		{
			// Arrange
			Update update = NewInstance();

			ISource source = update.Source;
			IColumn column = NewColumn();

			// Act
			Func<IColumn, DateTime, string?, Update> setMethod = setMethodSelector.Invoke(update);
			setMethod.Invoke(column, value, format);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			Assert.Equal(column, columnExpressionPair.Item1);

			DateTimeValue elementValue = Assert.IsType<DateTimeValue>(columnExpressionPair.Item2);
			Assert.Equal(value, elementValue.Data);

			if (string.IsNullOrEmpty(format))
			{
				Assert.Equal("o", elementValue.Format);
			}
			else
			{
				Assert.Equal(format, elementValue.Format);
			}

			Assert.Null(update.Condition);
		}

		private void Set_ColumnAndValue_AddToSetCollection<TValue, TElementValue>(
			TValue value, Func<Update, Func<IColumn, TValue, Update>> setMethodSelector)
			where TElementValue : DataValue<TValue>
		{
			// Arrange
			Update update = NewInstance();

			ISource source = update.Source;
			IColumn column = NewColumn();

			// Act
			Func<IColumn, TValue, Update> setMethod = setMethodSelector.Invoke(update);
			setMethod.Invoke(column, value);

			// Assert
			Assert.Equal(source, update.Source);

			Tuple<IColumn, IExpression> columnExpressionPair = Assert.Single(update.SetCollection);
			Assert.Equal(column, columnExpressionPair.Item1);

			if (value is null)
			{
				Assert.IsType<NullValue>(columnExpressionPair.Item2);
			}
			else
			{
				TElementValue elementValue = Assert.IsType<TElementValue>(columnExpressionPair.Item2);
				Assert.Equal(value, elementValue.Data);
			}

			Assert.Null(update.Condition);
		}

		private static void AssertSourceColumn(IColumn column, string name) =>
			AssertSourceColumn(column, name, alias: null, source: null);

		private static void AssertSourceColumn(IColumn column, string name, string? alias, string? tableName) =>
			AssertSourceColumn(column, name, alias, source: string.IsNullOrEmpty(tableName) ? null : new Table(tableName));

		private static void AssertSourceColumn(IColumn column, string name, string? alias, ISource? source)
		{
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

			Assert.Equal(source, sourceColumn.Source);
		}

		private static void AssertTable(ISource source, Table expectedTable)
		{
			Assert.NotNull(source);

			Table table = Assert.IsType<Table>(source);
			Assert.Equal(expectedTable, table);
		}

		private static void AssertTable(ISource source, string name) =>
			AssertTable(source, name, alias: null, schema: null);

		private static void AssertTable(ISource source, string name, string? alias, string? schema)
		{
			Assert.NotNull(source);

			Table table = Assert.IsType<Table>(source);
			Assert.NotNull(table.Name);
			Assert.NotEqual(string.Empty, table.Name);
			Assert.Equal(name, table.Name);

			if (string.IsNullOrEmpty(alias))
			{
				Assert.Null(table.Alias);
			}
			else
			{
				Assert.Equal(alias, table.Alias);
			}

			if (string.IsNullOrEmpty(schema))
			{
				Assert.Null(table.Schema);
			}
			else
			{
				Assert.Equal(schema, table.Schema);
			}
		}
	}
}
