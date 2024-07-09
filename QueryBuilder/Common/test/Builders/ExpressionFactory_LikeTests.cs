using System;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Builders
{
	public partial class ExpressionFactoryTests : TestsBase
	{
		#region + Like(column: string, pattern: string): LikeCondition

		[Theory]
		[InlineData("column_1", "")]
		[InlineData("column_1", "%att_r%")]
		public void Like_StringAndString_Success(string column, string pattern)
		{
			// Arrange & Act
			LikeCondition likeCondition = ExpressionFactory.Like(column, pattern);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.NotNull(likeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(likeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.Null(sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);

			Assert.NotNull(likeCondition.Pattern);

			StringValue stringValue = Assert.IsType<StringValue>(likeCondition.Pattern);

			Assert.Equal(pattern, stringValue.Data);
		}

		[Theory]
		[InlineData("column_1", null)]
		public void Like_StringAndNullString_ThrowsArgumentNullException(string? column, string? pattern) =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(column!, pattern!));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "%att_r%")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "%att_r%")]
		public void Like_NullOrEmptyStringAndString_ThrowsArgumentException(string? column, string? pattern) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, pattern!));

		#endregion + Like(column: string, pattern: string): LikeCondition

		#region + Like(column: string, patternFunction: Func<ExpressionFactory, IExpression>): LikeCondition

		[Theory]
		[InlineData("column_1")]
		public void Like_StringAndFuncExpressionFactoryIExpression_Success(string column)
		{
			// Arrange
			IExpression pattern = NewExpression();

			Func<ExpressionFactory, IExpression> patternFunction = NewExpressionFunction(resultExpression: pattern);

			// Act
			LikeCondition likeCondition = ExpressionFactory.Like(column, patternFunction);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.NotNull(likeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(likeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.Null(sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);

			Assert.NotNull(likeCondition.Pattern);
			Assert.Equal(pattern, likeCondition.Pattern);
		}

		[Theory]
		[InlineData("column_1")]
		public void Like_StringAndNullFuncExpressionFactoryIExpression_ThrowsArgumentNullException(string column) =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(column, patternFunction: null!));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Like_NullOrEmptyStringAndFuncExpressionFactoryIExpression_ThrowsArgumentException(string? column) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, patternFunction: (_) => NewExpression()));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Like_NullOrEmptyStringAndNullFuncExpressionFactoryIExpression_ThrowsArgumentException(string? column) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, patternFunction: null!));

		#endregion + Like(column: string, patternFunction: Func<ExpressionFactory, IExpression>): LikeCondition

		#region + Like(column: string, pattern: IExpression): LikeCondition

		[Theory]
		[InlineData("column_1")]
		public void Like_StringAndIExpression_Success(string column)
		{
			// Arrange
			IExpression pattern = NewExpression();

			// Act
			LikeCondition likeCondition = ExpressionFactory.Like(column, pattern);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.NotNull(likeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(likeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.Null(sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);

			Assert.NotNull(likeCondition.Pattern);
			Assert.Equal(pattern, likeCondition.Pattern);
		}

		[Theory]
		[InlineData("column_1")]
		public void Like_StringAndNullIExpression_ThrowsArgumentNullException(string column) =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(column, pattern: (IExpression)null!));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Like_NullOrEmptyStringAndIExpression_ThrowsArgumentException(string? column) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, pattern: NewExpression()));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Like_NullOrEmptyStringAndNullIExpression_ThrowsArgumentException(string? column) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, pattern: (IExpression)null!));

		#endregion + Like(column: string, pattern: IExpression): LikeCondition

		#region + Like(column: string, table: string | null, pattern: string): LikeCondition

		[Theory]
		[InlineData("column_1", "table_1", "")]
		[InlineData("column_1", "table_1", "%att_r%")]
		public void Like_StringAndStringAndString_Success(string column, string table, string pattern)
		{
			// Arrange & Act
			LikeCondition likeCondition = ExpressionFactory.Like(column, table, pattern);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.NotNull(likeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(likeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.NotNull(sourceColumn.Source);

			Table columnTable = Assert.IsType<Table>(sourceColumn.Source);

			Assert.Equal(table, columnTable.Name);
			Assert.Null(columnTable.Schema);
			Assert.Null(columnTable.Alias);
			Assert.Null(sourceColumn.Alias);

			Assert.NotNull(likeCondition.Pattern);

			StringValue stringValue = Assert.IsType<StringValue>(likeCondition.Pattern);

			Assert.Equal(pattern, stringValue.Data);
		}

		[Theory]
		[InlineData("column_1", "")]
		[InlineData("column_1", "%att_r%")]
		public void Like_StringAndNullStringAndString_Success(string column, string pattern)
		{
			// Arrange & Act
			LikeCondition likeCondition = ExpressionFactory.Like(column, table: null, pattern);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.NotNull(likeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(likeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.Null(sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);

			Assert.NotNull(likeCondition.Pattern);

			StringValue stringValue = Assert.IsType<StringValue>(likeCondition.Pattern);

			Assert.Equal(pattern, stringValue.Data);
		}

		[Theory]
		[InlineData("column_1", null, null)]
		[InlineData("column_1", "table_1", null)]
		public void Like_StringAndStringAndString_ThrowsArgumentNullException(string? column, string? table, string? pattern) =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(column!, table, pattern!));

		[Theory]
		[InlineData(null, null, null)]
		[InlineData(null, null, "")]
		[InlineData(null, null, "%att_r%")]
		[InlineData(null, "table_1", null)]
		[InlineData(null, "table_1", "")]
		[InlineData(null, "table_1", "%att_r%")]
		[InlineData("", null, null)]
		[InlineData("", null, "")]
		[InlineData("", null, "%att_r%")]
		[InlineData("", "table_1", null)]
		[InlineData("", "table_1", "")]
		[InlineData("", "table_1", "%att_r%")]
		public void Like_StringAndStringAndString_ThrowsArgumentException(string? column, string? table, string? pattern) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, table, pattern!));

		#endregion + Like(column: string, table: string | null, pattern: string): LikeCondition

		#region + Like(column: string, table: string | null, patternFunction: Func<ExpressionFactory, IExpression>): LikeCondition

		[Theory]
		[InlineData("column_1", "table_1")]
		public void Like_StringAndStringAndFuncExpressionFactoryIExpression_Success(string column, string table)
		{
			// Arrange
			IExpression pattern = NewExpression();

			Func<ExpressionFactory, IExpression> patternFunction = NewExpressionFunction(resultExpression: pattern);

			// Act
			LikeCondition likeCondition = ExpressionFactory.Like(column, table, patternFunction);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.NotNull(likeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(likeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.NotNull(sourceColumn.Source);

			Table columnTable = Assert.IsType<Table>(sourceColumn.Source);

			Assert.Equal(table, columnTable.Name);
			Assert.Null(columnTable.Schema);
			Assert.Null(columnTable.Alias);
			Assert.Null(sourceColumn.Alias);

			Assert.NotNull(likeCondition.Pattern);
			Assert.Equal(pattern, likeCondition.Pattern);
		}

		[Theory]
		[InlineData("column_1", null)]
		[InlineData("column_1", "")]
		public void Like_StringAndNullOrEmptyStringAndFuncExpressionFactoryIExpression_Success(string column, string? table)
		{
			// Arrange
			IExpression pattern = NewExpression();

			Func<ExpressionFactory, IExpression> patternFunction = NewExpressionFunction(resultExpression: pattern);

			// Act
			LikeCondition likeCondition = ExpressionFactory.Like(column, table, patternFunction);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.NotNull(likeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(likeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.Null(sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);

			Assert.NotNull(likeCondition.Pattern);
			Assert.Equal(pattern, likeCondition.Pattern);
		}

		[Theory]
		[InlineData("column_1", "table_1")]
		public void Like_StringAndStringAndNullFuncExpressionFactoryIExpression_ThrowsArgumentNullException(string column, string table) =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(column, table, patternFunction: null!));

		[Theory]
		[InlineData("column_1", null)]
		[InlineData("column_1", "")]
		public void Like_StringAndNullOrEmptyStringAndNullFuncExpressionFactoryIExpression_ThrowsArgumentNullException(string column, string? table) =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(column, table, patternFunction: null!));

		[Theory]
		[InlineData(null, "table_1")]
		[InlineData("", "table_1")]
		public void Like_NullOrEmptyStringAndStringAndFuncExpressionFactoryIExpression_ThrowsArgumentException(string? column, string table) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, table, patternFunction: (_) => NewExpression()));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData("", null)]
		[InlineData("", "")]
		public void Like_NullOrEmptyStringAndNullOrEmptyStringAndFuncExpressionFactoryIExpression_ThrowsArgumentException(string? column, string? table) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, table, patternFunction: (_) => NewExpression()));

		[Theory]
		[InlineData(null, "table_1")]
		[InlineData("", "table_1")]
		public void Like_NullOrEmptyStringAndStringAndNullFuncExpressionFactoryIExpression_ThrowsArgumentException(string? column, string table) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, table, patternFunction: null!));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData("", null)]
		[InlineData("", "")]
		public void Like_NullOrEmptyStringAndNullOrEmptyStringAndNullFuncExpressionFactoryIExpression_ThrowsArgumentException(string? column, string? table) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, table, patternFunction: null!));

		#endregion + Like(column: string, table: string | null, patternFunction: Func<ExpressionFactory, IExpression>): LikeCondition

		#region + Like(column: string, table: string | null, pattern: IExpression): LikeCondition

		[Theory]
		[InlineData("column_1", "table_1")]
		public void Like_StringAndStringAndIExpression_Success(string column, string table)
		{
			// Arrange
			IExpression pattern = NewExpression();

			// Act
			LikeCondition likeCondition = ExpressionFactory.Like(column, table, pattern);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.NotNull(likeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(likeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.NotNull(sourceColumn.Source);

			Table columnTable = Assert.IsType<Table>(sourceColumn.Source);

			Assert.Equal(table, columnTable.Name);
			Assert.Null(columnTable.Schema);
			Assert.Null(columnTable.Alias);
			Assert.Null(sourceColumn.Alias);

			Assert.NotNull(likeCondition.Pattern);
			Assert.Equal(pattern, likeCondition.Pattern);
		}

		[Theory]
		[InlineData("column_1", null)]
		[InlineData("column_1", "")]
		public void Like_StringAndNullOrEmptyStringAndIExpression_Success(string column, string? table)
		{
			// Arrange
			IExpression pattern = NewExpression();

			// Act
			LikeCondition likeCondition = ExpressionFactory.Like(column, table, pattern);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.NotNull(likeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(likeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.Null(sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);

			Assert.NotNull(likeCondition.Pattern);
			Assert.Equal(pattern, likeCondition.Pattern);
		}

		[Theory]
		[InlineData("column_1", "table_1")]
		public void Like_StringAndStringAndIExpression_ThrowsArgumentNullException(string column, string table) =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(column, table, pattern: (IExpression)null!));

		[Theory]
		[InlineData("column_1", null)]
		[InlineData("column_1", "")]
		public void Like_StringAndNullOrEmptyStringAndIExpression_ThrowsArgumentNullException(string column, string? table) =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(column, table, pattern: (IExpression)null!));

		[Theory]
		[InlineData(null, "table_1")]
		[InlineData("", "table_1")]
		public void Like_NullOrEmptyStringAndStringAndIExpression_ThrowsArgumentException(string? column, string table) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, table, pattern: (IExpression)null!));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData("", null)]
		[InlineData("", "")]
		public void Like_NullOrEmptyStringAndNullOrEmptyStringAndIExpression_ThrowsArgumentException(string? column, string? table) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, table, pattern: (IExpression)null!));

		[Theory]
		[InlineData(null, "table_1")]
		[InlineData("", "table_1")]
		public void Like_NullOrEmptyStringAndStringAndNullIExpression_ThrowsArgumentException(string? column, string table) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, table, pattern: (IExpression)null!));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData("", null)]
		[InlineData("", "")]
		public void Like_NullOrEmptyStringAndNullOrEmptyStringAndNullIExpression_ThrowsArgumentException(string? column, string? table) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, table, pattern: (IExpression)null!));

		#endregion + Like(column: string, table: string | null, pattern: IExpression): LikeCondition

		#region + Like(column: string, source: ISource | null, pattern: string): LikeCondition

		[Theory]
		[InlineData("column_1", "")]
		[InlineData("column_1", "%att_r%")]
		public void Like_StringAndISourceAndString_Success(string column, string pattern)
		{
			// Arrange
			ISource source = NewSource();

			// Act
			LikeCondition likeCondition = ExpressionFactory.Like(column, source, pattern);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.NotNull(likeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(likeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.Equal(source, sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);

			Assert.NotNull(likeCondition.Pattern);

			StringValue stringValue = Assert.IsType<StringValue>(likeCondition.Pattern);

			Assert.Equal(pattern, stringValue.Data);
		}

		[Theory]
		[InlineData("column_1", null)]
		public void Like_StringAndISourceAndString_ThrowsArgumentNullException(string? column, string? pattern) =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(column!, source: NewSource(), pattern!));

		[Theory]
		[InlineData("column_1", null)]
		public void Like_StringAndNullISourceAndString_ThrowsArgumentNullException(string? column, string? pattern) =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(column!, source: null, pattern!));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "%att_r%")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "%att_r%")]
		public void Like_StringAndISourceAndString_ThrowsArgumentException(string? column, string? pattern) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, source: NewSource(), pattern!));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "%att_r%")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "%att_r%")]
		public void Like_StringAndNullISourceAndString_ThrowsArgumentException(string? column, string? pattern) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, source: null, pattern!));

		#endregion + Like(column: string, source: ISource | null, pattern: string): LikeCondition

		#region + Like(column: string, source: ISource | null, pattern: Func<ExpressionFactory, IExpression>): LikeCondition

		[Theory]
		[InlineData("column_1")]
		public void Like_StringAndISourceAndFuncExpressionFactoryIExpression_Success(string column)
		{
			// Arrange
			ISource source = NewSource();
			IExpression pattern = NewExpression();

			Func<ExpressionFactory, IExpression> patternFunction = NewExpressionFunction(resultExpression: pattern);

			// Act
			LikeCondition likeCondition = ExpressionFactory.Like(column, source, patternFunction);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.NotNull(likeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(likeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.Equal(source, sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);

			Assert.Equal(pattern, likeCondition.Pattern);
		}

		[Theory]
		[InlineData("column_1")]
		public void Like_StringAndNullISourceAndFuncExpressionFactoryIExpression_Success(string column)
		{
			// Arrange
			IExpression pattern = NewExpression();

			Func<ExpressionFactory, IExpression> patternFunction = NewExpressionFunction(resultExpression: pattern);

			// Act
			LikeCondition likeCondition = ExpressionFactory.Like(column, source: null, patternFunction);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.NotNull(likeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(likeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.Null(sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);

			Assert.Equal(pattern, likeCondition.Pattern);
		}

		[Theory]
		[InlineData("column_1")]
		public void Like_StringAndISourceAndNullFuncExpressionFactoryIExpression_ThrowsArgumentNullException(string column) =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(column, source: NewSource(), patternFunction: null!));

		[Theory]
		[InlineData("column_1")]
		public void Like_StringAndNullISourceAndNullFuncExpressionFactoryIExpression_ThrowsArgumentNullException(string column) =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(column, source: null!, patternFunction: null!));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Like_NullOrEmptyStringAndISourceAndFuncExpressionFactoryIExpression_ThrowsArgumentException(string? column) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, source: NewSource(), patternFunction: (_) => NewExpression()));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Like_NullOrEmptyStringAndNullISourceAndFuncExpressionFactoryIExpression_ThrowsArgumentException(string? column) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, source: null!, patternFunction: (_) => NewExpression()));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Like_NullOrEmptyStringAndISourceAndNullFuncExpressionFactoryIExpression_ThrowsArgumentException(string? column) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, source: NewSource(), patternFunction: null!));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Like_NullOrEmptyStringAndNullISourceAndNullFuncExpressionFactoryIExpression_ThrowsArgumentException(string? column) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, source: null!, patternFunction: null!));

		#endregion + Like(column: string, source: ISource | null, pattern: Func<ExpressionFactory, IExpression>): LikeCondition

		#region + Like(column: string, source: ISource | null, pattern: IExpression): LikeCondition

		[Theory]
		[InlineData("column_1")]
		public void Like_StringAndISourceAndIExpression_Success(string column)
		{
			// Arrange
			ISource source = NewSource();
			IExpression pattern = NewExpression();

			// Act
			LikeCondition likeCondition = ExpressionFactory.Like(column, source, pattern);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.NotNull(likeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(likeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.Equal(source, sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);

			Assert.Equal(pattern, likeCondition.Pattern);
		}

		[Theory]
		[InlineData("column_1")]
		public void Like_StringAndNullISourceAndIExpression_Success(string column)
		{
			// Arrange
			IExpression pattern = NewExpression();

			// Act
			LikeCondition likeCondition = ExpressionFactory.Like(column, source: null, pattern);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.NotNull(likeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(likeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.Null(sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);

			Assert.Equal(pattern, likeCondition.Pattern);
		}

		[Theory]
		[InlineData("column_1")]
		public void Like_StringAndISourceAndNullIExpression_ThrowsArgumentNullException(string column) =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(column, source: NewSource(), pattern: (IExpression)null!));

		[Theory]
		[InlineData("column_1")]
		public void Like_StringAndNullISourceAndNullIExpression_ThrowsArgumentNullException(string column) =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(column, source: null, pattern: (IExpression)null!));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Like_NullOrEmptyStringAndISourceAndIExpression_ThrowsArgumentException(string? column) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, source: NewSource(), pattern: NewExpression()));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Like_NullOrEmptyStringAndNullISourceAndIExpression_ThrowsArgumentException(string? column) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, source: null, pattern: NewExpression()));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Like_NullOrEmptyStringAndISourceAndNullIExpression_ThrowsArgumentException(string? column) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, source: NewSource(), pattern: (IExpression)null!));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Like_NullOrEmptyStringAndNullISourceAndNullIExpression_ThrowsArgumentException(string? column) =>
			Like_ThrowsException<ArgumentException>(factory => factory.Like(column!, source: null, pattern: (IExpression)null!));

		#endregion + Like(column: string, source: ISource | null, pattern: IExpression): LikeCondition

		#region + Like(expressionFunction: Func<ExpressionFactory, IExpression>, pattern: string): LikeCondition

		[Theory]
		[InlineData("")]
		[InlineData("%att_r%")]
		public void Like_FuncExpressionFactoryIExpressionAndString_Success(string pattern)
		{
			// Arrange
			IExpression expression = NewExpression();

			Func<ExpressionFactory, IExpression> expressionFunction = NewExpressionFunction(resultExpression: expression);

			// Act
			LikeCondition likeCondition = ExpressionFactory.Like(expressionFunction, pattern);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.Equal(expression, likeCondition.Expression);
			Assert.NotNull(likeCondition.Pattern);

			StringValue stringValue = Assert.IsType<StringValue>(likeCondition.Pattern);

			Assert.Equal(pattern, stringValue.Data);
		}

		[Fact]
		public void Like_FuncExpressionFactoryIExpressionAndNullString_ThrowsArgumentNullException() =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like((_) => NewExpression(), pattern: (string?)null!));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("%att_r%")]
		public void Like_NullFuncExpressionFactoryIExpressionAndString_ThrowsArgumentNullException(string? pattern) =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(expressionFunction: null!, pattern!));

		#endregion + Like(expressionFunction: Func<ExpressionFactory, IExpression>, pattern: string): LikeCondition

		#region + Like(expressionFunction: Func<ExpressionFactory, IExpression>, patternFunction: Func<ExpressionFactory, IExpression>): LikeCondition

		[Fact]
		public void Like_FuncExpressionFactoryIExpressionAndFuncExpressionFactoryIExpression_Success()
		{
			// Arrange
			IExpression expression = NewExpression();
			IExpression pattern = NewExpression();

			Func<ExpressionFactory, IExpression> expressionFunction = NewExpressionFunction(resultExpression: expression);
			Func<ExpressionFactory, IExpression> patternFunction = NewExpressionFunction(resultExpression: pattern);

			// Act
			LikeCondition likeCondition = ExpressionFactory.Like(expressionFunction, patternFunction);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.Equal(expression, likeCondition.Expression);
			Assert.Equal(pattern, likeCondition.Pattern);
		}

		[Fact]
		public void Like_FuncExpressionFactoryIExpressionAndNullFuncExpressionFactoryIExpression_ThrowsArgumentNullException() =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(
				expressionFunction: (_) => NewExpression(), patternFunction: null!));

		[Fact]
		public void Like_NullFuncExpressionFactoryIExpressionAndFuncExpressionFactoryIExpression_ThrowsArgumentNullException() =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(
				expressionFunction: null!, patternFunction: (_) => NewExpression()));

		[Fact]
		public void Like_NullFuncExpressionFactoryIExpressionAndNullFuncExpressionFactoryIExpression_ThrowsArgumentNullException() =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(
				expressionFunction: null!, patternFunction: null!));

		#endregion + Like(expressionFunction: Func<ExpressionFactory, IExpression>, patternFunction: Func<ExpressionFactory, IExpression>): LikeCondition

		#region + Like(expressionFunction: Func<ExpressionFactory, IExpression>, pattern: IExpression): LikeCondition

		[Fact]
		public void Like_FuncExpressionFactoryIExpressionAndIExpression_Success()
		{
			// Arrange
			IExpression expression = NewExpression();
			IExpression pattern = NewExpression();

			Func<ExpressionFactory, IExpression> expressionFunction = NewExpressionFunction(resultExpression: expression);

			// Act
			LikeCondition likeCondition = ExpressionFactory.Like(expressionFunction, pattern);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.Equal(expression, likeCondition.Expression);
			Assert.Equal(pattern, likeCondition.Pattern);
		}

		[Fact]
		public void Like_FuncExpressionFactoryIExpressionAndNullIExpression_ThrowsArgumentNullException() =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(
				expressionFunction: (_) => NewExpression(), pattern: (IExpression?)null!));

		[Fact]
		public void Like_NullFuncExpressionFactoryIExpressionAndIExpression_ThrowsArgumentNullException() =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(
				expressionFunction: null!, pattern: NewExpression()));

		[Fact]
		public void Like_NullFuncExpressionFactoryIExpressionAndNullIExpression_ThrowsArgumentNullException() =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(
				expressionFunction: null!, pattern: (IExpression?)null!));

		#endregion + Like(expressionFunction: Func<ExpressionFactory, IExpression>, pattern: IExpression): LikeCondition

		#region + Like(expression: IExpression, pattern: string): LikeCondition

		[Theory]
		[InlineData("")]
		[InlineData("%att_r%")]
		public void Like_IExpressionAndString_Success(string pattern)
		{
			// Arrange
			IExpression expression = NewExpression();

			// Act
			LikeCondition likeCondition = ExpressionFactory.Like(expression, pattern);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.Equal(expression, likeCondition.Expression);
			Assert.NotNull(likeCondition.Pattern);

			StringValue stringValue = Assert.IsType<StringValue>(likeCondition.Pattern);

			Assert.Equal(pattern, stringValue.Data);
		}

		[Fact]
		public void Like_IExpressionAndNullString_ThrowsArgumentNullException() =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(expression: NewExpression(), pattern: (string?)null!));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("%att_r%")]
		public void Like_NullIExpressionAndString_ThrowsArgumentNullException(string? pattern) =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(expression: null!, pattern!));

		#endregion + Like(expression: IExpression, pattern: string): LikeCondition

		#region + Like(expression: IExpression, patternFunction: Func<ExpressionFactory, IExpression>): LikeCondition

		[Fact]
		public void Like_IExpressionAndFuncExpressionFactoryIExpression_Success()
		{
			// Arrange
			IExpression expression = NewExpression();
			IExpression pattern = NewExpression();

			Func<ExpressionFactory, IExpression> patternFunction = NewExpressionFunction(resultExpression: pattern);

			// Act
			LikeCondition likeCondition = ExpressionFactory.Like(expression, patternFunction);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.Equal(expression, likeCondition.Expression);
			Assert.Equal(pattern, likeCondition.Pattern);
		}

		[Fact]
		public void Like_IExpressionAndNullFuncExpressionFactoryIExpression_ThrowsArgumentNullException() =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(
				expression: NewExpression(), patternFunction: null!));

		[Fact]
		public void Like_NullIExpressionAndFuncExpressionFactoryIExpression_ThrowsArgumentNullException() =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(
				expression: null!, patternFunction: (_) => NewExpression()));

		[Fact]
		public void Like_NullIExpressionAndNullFuncExpressionFactoryIExpression_ThrowsArgumentNullException() =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(expression: null!, patternFunction: null!));

		#endregion + Like(expression: IExpression, patternFunction: Func<ExpressionFactory, IExpression>): LikeCondition

		#region + Like(expression: IExpression, pattern: IExpression): LikeCondition

		[Fact]
		public void Like_IExpressionAndIExpression_Success()
		{
			// Arrange
			IExpression expression = NewExpression();
			IExpression pattern = NewExpression();

			// Act
			LikeCondition likeCondition = ExpressionFactory.Like(expression, pattern);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.Equal(expression, likeCondition.Expression);
			Assert.Equal(pattern, likeCondition.Pattern);
		}

		[Fact]
		public void Like_IExpressionAndNullIExpression_ThrowsArgumentNullException() =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(
				expression: NewExpression(), pattern: (IExpression)null!));

		[Fact]
		public void Like_NullIExpressionAndIExpression_ThrowsArgumentNullException() =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(
				expression: null!, pattern: NewExpression()));

		[Fact]
		public void Like_NullIExpressionAndNullIExpression_ThrowsArgumentNullException() =>
			Like_ThrowsException<ArgumentNullException>(factory => factory.Like(
				expression: null!, pattern: (IExpression?)null!));

		#endregion + Like(expression: IExpression, pattern: IExpression): LikeCondition

		private void Like_ThrowsException<TException>(Func<ExpressionFactory, LikeCondition> likeFunction) where TException : Exception
		{
			// Arrange & Act & Assert
			Assert.Throws<TException>(() => likeFunction.Invoke(ExpressionFactory));
		}
	}
}
