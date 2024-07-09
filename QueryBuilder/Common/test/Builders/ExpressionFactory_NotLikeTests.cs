using System;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Builders
{
	public partial class ExpressionFactoryTests : TestsBase
	{
		#region + NotLike(column: string, pattern: string): NotLikeCondition

		[Theory]
		[InlineData("column_1", "")]
		[InlineData("column_1", "%att_r%")]
		public void NotLike_StringAndString_Success(string column, string pattern)
		{
			// Arrange & Act
			NotLikeCondition notLikeCondition = ExpressionFactory.NotLike(column, pattern);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.NotNull(notLikeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(notLikeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.Null(sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);

			Assert.NotNull(notLikeCondition.Pattern);

			StringValue stringValue = Assert.IsType<StringValue>(notLikeCondition.Pattern);

			Assert.Equal(pattern, stringValue.Data);
		}

		[Theory]
		[InlineData("column_1", null)]
		public void NotLike_StringAndNullString_ThrowsArgumentNullException(string? column, string? pattern) =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(column!, pattern!));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "%att_r%")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "%att_r%")]
		public void NotLike_NullOrEmptyStringAndString_ThrowsArgumentException(string? column, string? pattern) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, pattern!));

		#endregion + NotLike(column: string, pattern: string): NotLikeCondition

		#region + NotLike(column: string, patternFunction: Func<ExpressionFactory, IExpression>): NotLikeCondition

		[Theory]
		[InlineData("column_1")]
		public void NotLike_StringAndFuncExpressionFactoryIExpression_Success(string column)
		{
			// Arrange
			IExpression pattern = NewExpression();

			Func<ExpressionFactory, IExpression> patternFunction = NewExpressionFunction(resultExpression: pattern);

			// Act
			NotLikeCondition notLikeCondition = ExpressionFactory.NotLike(column, patternFunction);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.NotNull(notLikeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(notLikeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.Null(sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);

			Assert.NotNull(notLikeCondition.Pattern);
			Assert.Equal(pattern, notLikeCondition.Pattern);
		}

		[Theory]
		[InlineData("column_1")]
		public void NotLike_StringAndNullFuncExpressionFactoryIExpression_ThrowsArgumentNullException(string column) =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(column, patternFunction: null!));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void NotLike_NullOrEmptyStringAndFuncExpressionFactoryIExpression_ThrowsArgumentException(string? column) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, patternFunction: (_) => NewExpression()));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void NotLike_NullOrEmptyStringAndNullFuncExpressionFactoryIExpression_ThrowsArgumentException(string? column) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, patternFunction: null!));

		#endregion + NotLike(column: string, patternFunction: Func<ExpressionFactory, IExpression>): NotLikeCondition

		#region + NotLike(column: string, pattern: IExpression): NotLikeCondition

		[Theory]
		[InlineData("column_1")]
		public void NotLike_StringAndIExpression_Success(string column)
		{
			// Arrange
			IExpression pattern = NewExpression();

			// Act
			NotLikeCondition notLikeCondition = ExpressionFactory.NotLike(column, pattern);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.NotNull(notLikeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(notLikeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.Null(sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);

			Assert.NotNull(notLikeCondition.Pattern);
			Assert.Equal(pattern, notLikeCondition.Pattern);
		}

		[Theory]
		[InlineData("column_1")]
		public void NotLike_StringAndNullIExpression_ThrowsArgumentNullException(string column) =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(column, pattern: (IExpression)null!));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void NotLike_NullOrEmptyStringAndIExpression_ThrowsArgumentException(string? column) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, pattern: NewExpression()));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void NotLike_NullOrEmptyStringAndNullIExpression_ThrowsArgumentException(string? column) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, pattern: (IExpression)null!));

		#endregion + NotLike(column: string, pattern: IExpression): NotLikeCondition

		#region + NotLike(column: string, table: string | null, pattern: string): NotLikeCondition

		[Theory]
		[InlineData("column_1", "table_1", "")]
		[InlineData("column_1", "table_1", "%att_r%")]
		public void NotLike_StringAndStringAndString_Success(string column, string table, string pattern)
		{
			// Arrange & Act
			NotLikeCondition notLikeCondition = ExpressionFactory.NotLike(column, table, pattern);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.NotNull(notLikeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(notLikeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.NotNull(sourceColumn.Source);

			Table columnTable = Assert.IsType<Table>(sourceColumn.Source);

			Assert.Equal(table, columnTable.Name);
			Assert.Null(columnTable.Schema);
			Assert.Null(columnTable.Alias);
			Assert.Null(sourceColumn.Alias);

			Assert.NotNull(notLikeCondition.Pattern);

			StringValue stringValue = Assert.IsType<StringValue>(notLikeCondition.Pattern);

			Assert.Equal(pattern, stringValue.Data);
		}

		[Theory]
		[InlineData("column_1", "")]
		[InlineData("column_1", "%att_r%")]
		public void NotLike_StringAndNullStringAndString_Success(string column, string pattern)
		{
			// Arrange & Act
			NotLikeCondition notLikeCondition = ExpressionFactory.NotLike(column, table: null, pattern);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.NotNull(notLikeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(notLikeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.Null(sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);

			Assert.NotNull(notLikeCondition.Pattern);

			StringValue stringValue = Assert.IsType<StringValue>(notLikeCondition.Pattern);

			Assert.Equal(pattern, stringValue.Data);
		}

		[Theory]
		[InlineData("column_1", null, null)]
		[InlineData("column_1", "table_1", null)]
		public void NotLike_StringAndStringAndString_ThrowsArgumentNullException(string? column, string? table, string? pattern) =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(column!, table, pattern!));

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
		public void NotLike_StringAndStringAndString_ThrowsArgumentException(string? column, string? table, string? pattern) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, table, pattern!));

		#endregion + NotLike(column: string, table: string | null, pattern: string): NotLikeCondition

		#region + NotLike(column: string, table: string | null, patternFunction: Func<ExpressionFactory, IExpression>): NotLikeCondition

		[Theory]
		[InlineData("column_1", "table_1")]
		public void NotLike_StringAndStringAndFuncExpressionFactoryIExpression_Success(string column, string table)
		{
			// Arrange
			IExpression pattern = NewExpression();

			Func<ExpressionFactory, IExpression> patternFunction = NewExpressionFunction(resultExpression: pattern);

			// Act
			NotLikeCondition notLikeCondition = ExpressionFactory.NotLike(column, table, patternFunction);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.NotNull(notLikeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(notLikeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.NotNull(sourceColumn.Source);

			Table columnTable = Assert.IsType<Table>(sourceColumn.Source);

			Assert.Equal(table, columnTable.Name);
			Assert.Null(columnTable.Schema);
			Assert.Null(columnTable.Alias);
			Assert.Null(sourceColumn.Alias);

			Assert.NotNull(notLikeCondition.Pattern);
			Assert.Equal(pattern, notLikeCondition.Pattern);
		}

		[Theory]
		[InlineData("column_1", null)]
		[InlineData("column_1", "")]
		public void NotLike_StringAndNullOrEmptyStringAndFuncExpressionFactoryIExpression_Success(string column, string? table)
		{
			// Arrange
			IExpression pattern = NewExpression();

			Func<ExpressionFactory, IExpression> patternFunction = NewExpressionFunction(resultExpression: pattern);

			// Act
			NotLikeCondition notLikeCondition = ExpressionFactory.NotLike(column, table, patternFunction);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.NotNull(notLikeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(notLikeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.Null(sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);

			Assert.NotNull(notLikeCondition.Pattern);
			Assert.Equal(pattern, notLikeCondition.Pattern);
		}

		[Theory]
		[InlineData("column_1", "table_1")]
		public void NotLike_StringAndStringAndNullFuncExpressionFactoryIExpression_ThrowsArgumentNullException(string column, string table) =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(column, table, patternFunction: null!));

		[Theory]
		[InlineData("column_1", null)]
		[InlineData("column_1", "")]
		public void NotLike_StringAndNullOrEmptyStringAndNullFuncExpressionFactoryIExpression_ThrowsArgumentNullException(string column, string? table) =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(column, table, patternFunction: null!));

		[Theory]
		[InlineData(null, "table_1")]
		[InlineData("", "table_1")]
		public void NotLike_NullOrEmptyStringAndStringAndFuncExpressionFactoryIExpression_ThrowsArgumentException(string? column, string table) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, table, patternFunction: (_) => NewExpression()));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData("", null)]
		[InlineData("", "")]
		public void NotLike_NullOrEmptyStringAndNullOrEmptyStringAndFuncExpressionFactoryIExpression_ThrowsArgumentException(string? column, string? table) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, table, patternFunction: (_) => NewExpression()));

		[Theory]
		[InlineData(null, "table_1")]
		[InlineData("", "table_1")]
		public void NotLike_NullOrEmptyStringAndStringAndNullFuncExpressionFactoryIExpression_ThrowsArgumentException(string? column, string table) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, table, patternFunction: null!));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData("", null)]
		[InlineData("", "")]
		public void NotLike_NullOrEmptyStringAndNullOrEmptyStringAndNullFuncExpressionFactoryIExpression_ThrowsArgumentException(string? column, string? table) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, table, patternFunction: null!));

		#endregion + NotLike(column: string, table: string | null, patternFunction: Func<ExpressionFactory, IExpression>): NotLikeCondition

		#region + NotLike(column: string, table: string | null, pattern: IExpression): NotLikeCondition

		[Theory]
		[InlineData("column_1", "table_1")]
		public void NotLike_StringAndStringAndIExpression_Success(string column, string table)
		{
			// Arrange
			IExpression pattern = NewExpression();

			// Act
			NotLikeCondition notLikeCondition = ExpressionFactory.NotLike(column, table, pattern);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.NotNull(notLikeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(notLikeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.NotNull(sourceColumn.Source);

			Table columnTable = Assert.IsType<Table>(sourceColumn.Source);

			Assert.Equal(table, columnTable.Name);
			Assert.Null(columnTable.Schema);
			Assert.Null(columnTable.Alias);
			Assert.Null(sourceColumn.Alias);

			Assert.NotNull(notLikeCondition.Pattern);
			Assert.Equal(pattern, notLikeCondition.Pattern);
		}

		[Theory]
		[InlineData("column_1", null)]
		[InlineData("column_1", "")]
		public void NotLike_StringAndNullOrEmptyStringAndIExpression_Success(string column, string? table)
		{
			// Arrange
			IExpression pattern = NewExpression();

			// Act
			NotLikeCondition notLikeCondition = ExpressionFactory.NotLike(column, table, pattern);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.NotNull(notLikeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(notLikeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.Null(sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);

			Assert.NotNull(notLikeCondition.Pattern);
			Assert.Equal(pattern, notLikeCondition.Pattern);
		}

		[Theory]
		[InlineData("column_1", "table_1")]
		public void NotLike_StringAndStringAndIExpression_ThrowsArgumentNullException(string column, string table) =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(column, table, pattern: (IExpression)null!));

		[Theory]
		[InlineData("column_1", null)]
		[InlineData("column_1", "")]
		public void NotLike_StringAndNullOrEmptyStringAndIExpression_ThrowsArgumentNullException(string column, string? table) =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(column, table, pattern: (IExpression)null!));

		[Theory]
		[InlineData(null, "table_1")]
		[InlineData("", "table_1")]
		public void NotLike_NullOrEmptyStringAndStringAndIExpression_ThrowsArgumentException(string? column, string table) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, table, pattern: (IExpression)null!));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData("", null)]
		[InlineData("", "")]
		public void NotLike_NullOrEmptyStringAndNullOrEmptyStringAndIExpression_ThrowsArgumentException(string? column, string? table) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, table, pattern: (IExpression)null!));

		[Theory]
		[InlineData(null, "table_1")]
		[InlineData("", "table_1")]
		public void NotLike_NullOrEmptyStringAndStringAndNullIExpression_ThrowsArgumentException(string? column, string table) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, table, pattern: (IExpression)null!));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData("", null)]
		[InlineData("", "")]
		public void NotLike_NullOrEmptyStringAndNullOrEmptyStringAndNullIExpression_ThrowsArgumentException(string? column, string? table) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, table, pattern: (IExpression)null!));

		#endregion + NotLike(column: string, table: string | null, pattern: IExpression): NotLikeCondition

		#region + NotLike(column: string, source: ISource | null, pattern: string): NotLikeCondition

		[Theory]
		[InlineData("column_1", "")]
		[InlineData("column_1", "%att_r%")]
		public void NotLike_StringAndISourceAndString_Success(string column, string pattern)
		{
			// Arrange
			ISource source = NewSource();

			// Act
			NotLikeCondition notLikeCondition = ExpressionFactory.NotLike(column, source, pattern);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.NotNull(notLikeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(notLikeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.Equal(source, sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);

			Assert.NotNull(notLikeCondition.Pattern);

			StringValue stringValue = Assert.IsType<StringValue>(notLikeCondition.Pattern);

			Assert.Equal(pattern, stringValue.Data);
		}

		[Theory]
		[InlineData("column_1", null)]
		public void NotLike_StringAndISourceAndString_ThrowsArgumentNullException(string? column, string? pattern) =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(column!, source: NewSource(), pattern!));

		[Theory]
		[InlineData("column_1", null)]
		public void NotLike_StringAndNullISourceAndString_ThrowsArgumentNullException(string? column, string? pattern) =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(column!, source: null, pattern!));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "%att_r%")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "%att_r%")]
		public void NotLike_StringAndISourceAndString_ThrowsArgumentException(string? column, string? pattern) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, source: NewSource(), pattern!));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "%att_r%")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "%att_r%")]
		public void NotLike_StringAndNullISourceAndString_ThrowsArgumentException(string? column, string? pattern) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, source: null, pattern!));

		#endregion + NotLike(column: string, source: ISource | null, pattern: string): NotLikeCondition

		#region + NotLike(column: string, source: ISource | null, pattern: Func<ExpressionFactory, IExpression>): NotLikeCondition

		[Theory]
		[InlineData("column_1")]
		public void NotLike_StringAndISourceAndFuncExpressionFactoryIExpression_Success(string column)
		{
			// Arrange
			ISource source = NewSource();
			IExpression pattern = NewExpression();

			Func<ExpressionFactory, IExpression> patternFunction = NewExpressionFunction(resultExpression: pattern);

			// Act
			NotLikeCondition notLikeCondition = ExpressionFactory.NotLike(column, source, patternFunction);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.NotNull(notLikeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(notLikeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.Equal(source, sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);

			Assert.Equal(pattern, notLikeCondition.Pattern);
		}

		[Theory]
		[InlineData("column_1")]
		public void NotLike_StringAndNullISourceAndFuncExpressionFactoryIExpression_Success(string column)
		{
			// Arrange
			IExpression pattern = NewExpression();

			Func<ExpressionFactory, IExpression> patternFunction = NewExpressionFunction(resultExpression: pattern);

			// Act
			NotLikeCondition notLikeCondition = ExpressionFactory.NotLike(column, source: null, patternFunction);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.NotNull(notLikeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(notLikeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.Null(sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);

			Assert.Equal(pattern, notLikeCondition.Pattern);
		}

		[Theory]
		[InlineData("column_1")]
		public void NotLike_StringAndISourceAndNullFuncExpressionFactoryIExpression_ThrowsArgumentNullException(string column) =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(column, source: NewSource(), patternFunction: null!));

		[Theory]
		[InlineData("column_1")]
		public void NotLike_StringAndNullISourceAndNullFuncExpressionFactoryIExpression_ThrowsArgumentNullException(string column) =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(column, source: null!, patternFunction: null!));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void NotLike_NullOrEmptyStringAndISourceAndFuncExpressionFactoryIExpression_ThrowsArgumentException(string? column) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, source: NewSource(), patternFunction: (_) => NewExpression()));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void NotLike_NullOrEmptyStringAndNullISourceAndFuncExpressionFactoryIExpression_ThrowsArgumentException(string? column) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, source: null!, patternFunction: (_) => NewExpression()));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void NotLike_NullOrEmptyStringAndISourceAndNullFuncExpressionFactoryIExpression_ThrowsArgumentException(string? column) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, source: NewSource(), patternFunction: null!));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void NotLike_NullOrEmptyStringAndNullISourceAndNullFuncExpressionFactoryIExpression_ThrowsArgumentException(string? column) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, source: null!, patternFunction: null!));

		#endregion + NotLike(column: string, source: ISource | null, pattern: Func<ExpressionFactory, IExpression>): NotLikeCondition

		#region + NotLike(column: string, source: ISource | null, pattern: IExpression): NotLikeCondition

		[Theory]
		[InlineData("column_1")]
		public void NotLike_StringAndISourceAndIExpression_Success(string column)
		{
			// Arrange
			ISource source = NewSource();
			IExpression pattern = NewExpression();

			// Act
			NotLikeCondition notLikeCondition = ExpressionFactory.NotLike(column, source, pattern);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.NotNull(notLikeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(notLikeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.Equal(source, sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);

			Assert.Equal(pattern, notLikeCondition.Pattern);
		}

		[Theory]
		[InlineData("column_1")]
		public void NotLike_StringAndNullISourceAndIExpression_Success(string column)
		{
			// Arrange
			IExpression pattern = NewExpression();

			// Act
			NotLikeCondition notLikeCondition = ExpressionFactory.NotLike(column, source: null, pattern);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.NotNull(notLikeCondition.Expression);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(notLikeCondition.Expression);

			Assert.Equal(column, sourceColumn.Name);
			Assert.Null(sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);

			Assert.Equal(pattern, notLikeCondition.Pattern);
		}

		[Theory]
		[InlineData("column_1")]
		public void NotLike_StringAndISourceAndNullIExpression_ThrowsArgumentNullException(string column) =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(column, source: NewSource(), pattern: (IExpression)null!));

		[Theory]
		[InlineData("column_1")]
		public void NotLike_StringAndNullISourceAndNullIExpression_ThrowsArgumentNullException(string column) =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(column, source: null, pattern: (IExpression)null!));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void NotLike_NullOrEmptyStringAndISourceAndIExpression_ThrowsArgumentException(string? column) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, source: NewSource(), pattern: NewExpression()));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void NotLike_NullOrEmptyStringAndNullISourceAndIExpression_ThrowsArgumentException(string? column) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, source: null, pattern: NewExpression()));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void NotLike_NullOrEmptyStringAndISourceAndNullIExpression_ThrowsArgumentException(string? column) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, source: NewSource(), pattern: (IExpression)null!));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void NotLike_NullOrEmptyStringAndNullISourceAndNullIExpression_ThrowsArgumentException(string? column) =>
			NotLike_ThrowsException<ArgumentException>(factory => factory.NotLike(column!, source: null, pattern: (IExpression)null!));

		#endregion + NotLike(column: string, source: ISource | null, pattern: IExpression): NotLikeCondition

		#region + NotLike(expressionFunction: Func<ExpressionFactory, IExpression>, pattern: string): NotLikeCondition

		[Theory]
		[InlineData("")]
		[InlineData("%att_r%")]
		public void NotLike_FuncExpressionFactoryIExpressionAndString_Success(string pattern)
		{
			// Arrange
			IExpression expression = NewExpression();

			Func<ExpressionFactory, IExpression> expressionFunction = NewExpressionFunction(resultExpression: expression);

			// Act
			NotLikeCondition notLikeCondition = ExpressionFactory.NotLike(expressionFunction, pattern);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.Equal(expression, notLikeCondition.Expression);
			Assert.NotNull(notLikeCondition.Pattern);

			StringValue stringValue = Assert.IsType<StringValue>(notLikeCondition.Pattern);

			Assert.Equal(pattern, stringValue.Data);
		}

		[Fact]
		public void NotLike_FuncExpressionFactoryIExpressionAndNullString_ThrowsArgumentNullException() =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike((_) => NewExpression(), pattern: (string?)null!));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("%att_r%")]
		public void NotLike_NullFuncExpressionFactoryIExpressionAndString_ThrowsArgumentNullException(string? pattern) =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(expressionFunction: null!, pattern!));

		#endregion + NotLike(expressionFunction: Func<ExpressionFactory, IExpression>, pattern: string): NotLikeCondition

		#region + NotLike(expressionFunction: Func<ExpressionFactory, IExpression>, patternFunction: Func<ExpressionFactory, IExpression>): NotLikeCondition

		[Fact]
		public void NotLike_FuncExpressionFactoryIExpressionAndFuncExpressionFactoryIExpression_Success()
		{
			// Arrange
			IExpression expression = NewExpression();
			IExpression pattern = NewExpression();

			Func<ExpressionFactory, IExpression> expressionFunction = NewExpressionFunction(resultExpression: expression);
			Func<ExpressionFactory, IExpression> patternFunction = NewExpressionFunction(resultExpression: pattern);

			// Act
			NotLikeCondition notLikeCondition = ExpressionFactory.NotLike(expressionFunction, patternFunction);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.Equal(expression, notLikeCondition.Expression);
			Assert.Equal(pattern, notLikeCondition.Pattern);
		}

		[Fact]
		public void NotLike_FuncExpressionFactoryIExpressionAndNullFuncExpressionFactoryIExpression_ThrowsArgumentNullException() =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(
				expressionFunction: (_) => NewExpression(), patternFunction: null!));

		[Fact]
		public void NotLike_NullFuncExpressionFactoryIExpressionAndFuncExpressionFactoryIExpression_ThrowsArgumentNullException() =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(
				expressionFunction: null!, patternFunction: (_) => NewExpression()));

		[Fact]
		public void NotLike_NullFuncExpressionFactoryIExpressionAndNullFuncExpressionFactoryIExpression_ThrowsArgumentNullException() =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(
				expressionFunction: null!, patternFunction: null!));

		#endregion + NotLike(expressionFunction: Func<ExpressionFactory, IExpression>, patternFunction: Func<ExpressionFactory, IExpression>): NotLikeCondition

		#region + NotLike(expressionFunction: Func<ExpressionFactory, IExpression>, pattern: IExpression): NotLikeCondition

		[Fact]
		public void NotLike_FuncExpressionFactoryIExpressionAndIExpression_Success()
		{
			// Arrange
			IExpression expression = NewExpression();
			IExpression pattern = NewExpression();

			Func<ExpressionFactory, IExpression> expressionFunction = NewExpressionFunction(resultExpression: expression);

			// Act
			NotLikeCondition notLikeCondition = ExpressionFactory.NotLike(expressionFunction, pattern);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.Equal(expression, notLikeCondition.Expression);
			Assert.Equal(pattern, notLikeCondition.Pattern);
		}

		[Fact]
		public void NotLike_FuncExpressionFactoryIExpressionAndNullIExpression_ThrowsArgumentNullException() =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(
				expressionFunction: (_) => NewExpression(), pattern: (IExpression?)null!));

		[Fact]
		public void NotLike_NullFuncExpressionFactoryIExpressionAndIExpression_ThrowsArgumentNullException() =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(
				expressionFunction: null!, pattern: NewExpression()));

		[Fact]
		public void NotLike_NullFuncExpressionFactoryIExpressionAndNullIExpression_ThrowsArgumentNullException() =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(
				expressionFunction: null!, pattern: (IExpression?)null!));

		#endregion + NotLike(expressionFunction: Func<ExpressionFactory, IExpression>, pattern: IExpression): NotLikeCondition

		#region + NotLike(expression: IExpression, pattern: string): NotLikeCondition

		[Theory]
		[InlineData("")]
		[InlineData("%att_r%")]
		public void NotLike_IExpressionAndString_Success(string pattern)
		{
			// Arrange
			IExpression expression = NewExpression();

			// Act
			NotLikeCondition notLikeCondition = ExpressionFactory.NotLike(expression, pattern);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.Equal(expression, notLikeCondition.Expression);
			Assert.NotNull(notLikeCondition.Pattern);

			StringValue stringValue = Assert.IsType<StringValue>(notLikeCondition.Pattern);

			Assert.Equal(pattern, stringValue.Data);
		}

		[Fact]
		public void NotLike_IExpressionAndNullString_ThrowsArgumentNullException() =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(expression: NewExpression(), pattern: (string?)null!));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("%att_r%")]
		public void NotLike_NullIExpressionAndString_ThrowsArgumentNullException(string? pattern) =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(expression: null!, pattern!));

		#endregion + NotLike(expression: IExpression, pattern: string): NotLikeCondition

		#region + NotLike(expression: IExpression, patternFunction: Func<ExpressionFactory, IExpression>): NotLikeCondition

		[Fact]
		public void NotLike_IExpressionAndFuncExpressionFactoryIExpression_Success()
		{
			// Arrange
			IExpression expression = NewExpression();
			IExpression pattern = NewExpression();

			Func<ExpressionFactory, IExpression> patternFunction = NewExpressionFunction(resultExpression: pattern);

			// Act
			NotLikeCondition notLikeCondition = ExpressionFactory.NotLike(expression, patternFunction);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.Equal(expression, notLikeCondition.Expression);
			Assert.Equal(pattern, notLikeCondition.Pattern);
		}

		[Fact]
		public void NotLike_IExpressionAndNullFuncExpressionFactoryIExpression_ThrowsArgumentNullException() =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(
				expression: NewExpression(), patternFunction: null!));

		[Fact]
		public void NotLike_NullIExpressionAndFuncExpressionFactoryIExpression_ThrowsArgumentNullException() =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(
				expression: null!, patternFunction: (_) => NewExpression()));

		[Fact]
		public void NotLike_NullIExpressionAndNullFuncExpressionFactoryIExpression_ThrowsArgumentNullException() =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(expression: null!, patternFunction: null!));

		#endregion + NotLike(expression: IExpression, patternFunction: Func<ExpressionFactory, IExpression>): NotLikeCondition

		#region + NotLike(expression: IExpression, pattern: IExpression): NotLikeCondition

		[Fact]
		public void NotLike_IExpressionAndIExpression_Success()
		{
			// Arrange
			IExpression expression = NewExpression();
			IExpression pattern = NewExpression();

			// Act
			NotLikeCondition notLikeCondition = ExpressionFactory.NotLike(expression, pattern);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.Equal(expression, notLikeCondition.Expression);
			Assert.Equal(pattern, notLikeCondition.Pattern);
		}

		[Fact]
		public void NotLike_IExpressionAndNullIExpression_ThrowsArgumentNullException() =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(
				expression: NewExpression(), pattern: (IExpression)null!));

		[Fact]
		public void NotLike_NullIExpressionAndIExpression_ThrowsArgumentNullException() =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(
				expression: null!, pattern: NewExpression()));

		[Fact]
		public void NotLike_NullIExpressionAndNullIExpression_ThrowsArgumentNullException() =>
			NotLike_ThrowsException<ArgumentNullException>(factory => factory.NotLike(
				expression: null!, pattern: (IExpression?)null!));

		#endregion + NotLike(expression: IExpression, pattern: IExpression): NotLikeCondition

		private void NotLike_ThrowsException<TException>(Func<ExpressionFactory, NotLikeCondition> likeFunction) where TException : Exception
		{
			// Arrange & Act & Assert
			Assert.Throws<TException>(() => likeFunction.Invoke(ExpressionFactory));
		}
	}
}
