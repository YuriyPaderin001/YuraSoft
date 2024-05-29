using System;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Builders
{
	public class ExpressionFactoryTests : TestsBase
	{
		[Theory]
		[InlineData("")]
		[InlineData("%att_r%")]
		public void Like_IExpressionAndString_Success(string pattern)
		{
			// Arrange
			IExpression expression = NewExpression();

			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act
			LikeCondition likeCondition = expressionFactory.Like(expression, pattern);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.Equal(expression, likeCondition.Expression);
			Assert.NotNull(likeCondition.Pattern);

			StringValue stringValue = Assert.IsType<StringValue>(likeCondition.Pattern);

			Assert.Equal(pattern, stringValue.Data);
		}

		[Fact]
		public void Like_IExpressionAndNullString_ThrowsArgumentNullException() =>
			Like_IExpressionAndString_ThrowsException<ArgumentNullException>(
				expression: NewExpression(), pattern: null);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("%att_r%")]
		public void Like_NullIExpressionAndString_ThrowsArgumentNullException(string? pattern) =>
			Like_IExpressionAndString_ThrowsException<ArgumentNullException>(expression: null, pattern);

		[Theory]
		[InlineData("column_1", "")]
		[InlineData("column_1", "%att_r%")]
		public void Like_StringAndString_Success(string column, string pattern)
		{
			// Arrange
			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act
			LikeCondition likeCondition = expressionFactory.Like(column, pattern);

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
			Like_StringAndString_ThrowsException<ArgumentNullException>(column, pattern);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "%att_r%")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "%att_r%")]
		public void Like_NullOrEmptyStringAndString_ThrowsArgumentException(string? column, string? pattern) =>
			Like_StringAndString_ThrowsException<ArgumentException>(column, pattern);

		[Theory]
		[InlineData("column_1", "table_1", "")]
		[InlineData("column_1", "table_1", "%att_r%")]
		public void Like_StringAndStringAndString_Success(string column, string table, string pattern)
		{
			// Arrange
			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act
			LikeCondition likeCondition = expressionFactory.Like(column, table, pattern);

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
			// Arrange
			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act
			LikeCondition likeCondition = expressionFactory.Like(column, table: null, pattern);

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
			Like_StringAndStringAndString_ThrowsException<ArgumentNullException>(column, table, pattern);

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
			Like_StringAndStringAndString_ThrowsException<ArgumentException>(column, table, pattern);

		[Theory]
		[InlineData("column_1", "")]
		[InlineData("column_1", "%att_r%")]
		public void Like_StringAndISourceAndString_Success(string column, string pattern)
		{
			// Arrange
			ISource source = NewSource();

			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act
			LikeCondition likeCondition = expressionFactory.Like(column, source, pattern);

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
			Like_StringAndISourceAndString_ThrowsException<ArgumentNullException>(column, source: NewSource(), pattern);

		[Theory]
		[InlineData("column_1", null)]
		public void Like_StringAndNullISourceAndString_ThrowsArgumentNullException(string? column, string? pattern) =>
			Like_StringAndISourceAndString_ThrowsException<ArgumentNullException>(column, source: null, pattern);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "%att_r%")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "%att_r%")]
		public void Like_StringAndISourceAndString_ThrowsArgumentException(string? column, string? pattern) =>
			Like_StringAndISourceAndString_ThrowsException<ArgumentException>(column, source: NewSource(), pattern);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "%att_r%")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "%att_r%")]
		public void Like_StringAndNullISourceAndString_ThrowsArgumentException(string? column, string? pattern) =>
			Like_StringAndISourceAndString_ThrowsException<ArgumentException>(column, source: null, pattern);

		[Theory]
		[InlineData("")]
		[InlineData("%att_r%")]
		public void Like_FuncExpressionFactoryIExpressionAndString_Success(string pattern)
		{
			// Arrange
			IExpression expression = NewExpression();
			Func<ExpressionFactory, IExpression> expressionFunction = (factory) =>
			{
				Assert.NotNull(factory);

				return expression;
			};

			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act
			LikeCondition likeCondition = expressionFactory.Like(expressionFunction, pattern);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.Equal(expression, likeCondition.Expression);
			Assert.NotNull(likeCondition.Pattern);

			StringValue stringValue = Assert.IsType<StringValue>(likeCondition.Pattern);

			Assert.Equal(pattern, stringValue.Data);
		}

		[Fact]
		public void Like_FuncExpressionFactoryIExpressionAndNullString_ThrowsArgumentNullException() =>
			Like_FuncExpressionFactoryIExpressionAndString_ThrowsException<ArgumentNullException>((_) => NewExpression(), pattern: null);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("%att_r%")]
		public void Like_NullFuncExpressionFactoryIExpressionAndString_ThrowsArgumentNullException(string? pattern) =>
			Like_FuncExpressionFactoryIExpressionAndString_ThrowsException<ArgumentNullException>(expressionFunction: null, pattern);

		[Fact]
		public void Like_IExpressionAndIExpression_Success()
		{
			// Arrange
			IExpression expression = NewExpression();
			IExpression pattern = NewExpression();

			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act
			LikeCondition likeCondition = expressionFactory.Like(expression, pattern);

			// Assert
			Assert.NotNull(likeCondition);
			Assert.Equal(expression, likeCondition.Expression);
			Assert.Equal(pattern, likeCondition.Pattern);
		}

		[Fact]
		public void Like_IExpressionAndNullIExpression_ThrowsArgumentNullException() =>
			Like_IExpressionAndIExpression_ThrowsException<ArgumentNullException>(expression: NewExpression(), pattern: null);

		[Fact]
		public void Like_NullIExpressionAndIExpression_ThrowsArgumentNullException() =>
			Like_IExpressionAndIExpression_ThrowsException<ArgumentNullException>(expression: null, pattern: NewExpression());

		[Fact]
		public void Like_NullIExpressionAndNullIExpression_ThrowsArgumentNullException() =>
			Like_IExpressionAndIExpression_ThrowsException<ArgumentNullException>(expression: null, pattern: null);

		private void Like_IExpressionAndString_ThrowsException<TException>(IExpression? expression, string? pattern) where TException : Exception
		{
			// Arrange
			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act & Assert
			Assert.Throws<TException>(() => expressionFactory.Like(expression!, pattern!));
		}

		private void Like_StringAndString_ThrowsException<TException>(string? column, string? pattern) where TException : Exception
		{
			// Arrange
			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act & Assert
			Assert.Throws<TException>(() => expressionFactory.Like(column!, pattern!));
		}

		private void Like_StringAndStringAndString_ThrowsException<TException>(string? column, string? table, string? pattern) where TException : Exception
		{
			// Arrange
			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act & Assert
			Assert.Throws<TException>(() => expressionFactory.Like(column!, table!, pattern!));
		}

		private void Like_StringAndISourceAndString_ThrowsException<TException>(string? column, ISource? source, string? pattern) where TException : Exception
		{
			// Arrange
			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act & Assert
			Assert.Throws<TException>(() => expressionFactory.Like(column!, source!, pattern!));
		}

		private void Like_FuncExpressionFactoryIExpressionAndString_ThrowsException<TException>(
			Func<ExpressionFactory, IExpression>? expressionFunction, string? pattern) where TException : Exception
		{
			// Arrange
			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act & Assert
			Assert.Throws<TException>(() => expressionFactory.Like(expressionFunction!, pattern!));
		}

		private void Like_IExpressionAndIExpression_ThrowsException<TException>(IExpression? expression, IExpression? pattern) where TException : Exception
		{
			// Arrange
			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act & Assert
			Assert.Throws<TException>(() => expressionFactory.Like(expression!, pattern!));
		}

		[Theory]
		[InlineData("")]
		[InlineData("%att_r%")]
		public void NotLike_IExpressionAndString_Success(string pattern)
		{
			// Arrange
			IExpression expression = NewExpression();

			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act
			NotLikeCondition notLikeCondition = expressionFactory.NotLike(expression, pattern);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.Equal(expression, notLikeCondition.Expression);
			Assert.NotNull(notLikeCondition.Pattern);

			StringValue stringValue = Assert.IsType<StringValue>(notLikeCondition.Pattern);

			Assert.Equal(pattern, stringValue.Data);
		}

		[Fact]
		public void NotLike_IExpressionAndNullString_ThrowsArgumentNullException() =>
			NotLike_IExpressionAndString_ThrowsException<ArgumentNullException>(
				expression: NewExpression(), pattern: null);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("%att_r%")]
		public void NotLike_NullIExpressionAndString_ThrowsArgumentNullException(string? pattern) =>
			NotLike_IExpressionAndString_ThrowsException<ArgumentNullException>(expression: null, pattern);

		[Theory]
		[InlineData("column_1", "")]
		[InlineData("column_1", "%att_r%")]
		public void NotLike_StringAndString_Success(string column, string pattern)
		{
			// Arrange
			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act
			NotLikeCondition notLikeCondition = expressionFactory.NotLike(column, pattern);

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
			NotLike_StringAndString_ThrowsException<ArgumentNullException>(column, pattern);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "%att_r%")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "%att_r%")]
		public void NotLike_NullOrEmptyStringAndString_ThrowsArgumentException(string? column, string? pattern) =>
			NotLike_StringAndString_ThrowsException<ArgumentException>(column, pattern);

		[Theory]
		[InlineData("column_1", "table_1", "")]
		[InlineData("column_1", "table_1", "%att_r%")]
		public void NotLike_StringAndStringAndString_Success(string column, string table, string pattern)
		{
			// Arrange
			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act
			NotLikeCondition notLikeCondition = expressionFactory.NotLike(column, table, pattern);

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
			// Arrange
			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act
			NotLikeCondition notLikeCondition = expressionFactory.NotLike(column, table: null, pattern);

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
			NotLike_StringAndStringAndString_ThrowsException<ArgumentNullException>(column, table, pattern);

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
			NotLike_StringAndStringAndString_ThrowsException<ArgumentException>(column, table, pattern);

		[Theory]
		[InlineData("column_1", "")]
		[InlineData("column_1", "%att_r%")]
		public void NotLike_StringAndISourceAndString_Success(string column, string pattern)
		{
			// Arrange
			ISource source = NewSource();

			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act
			NotLikeCondition notLikeCondition = expressionFactory.NotLike(column, source, pattern);

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
			NotLike_StringAndISourceAndString_ThrowsException<ArgumentNullException>(column, source: NewSource(), pattern);

		[Theory]
		[InlineData("column_1", null)]
		public void NotLike_StringAndNullISourceAndString_ThrowsArgumentNullException(string? column, string? pattern) =>
			NotLike_StringAndISourceAndString_ThrowsException<ArgumentNullException>(column, source: null, pattern);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "%att_r%")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "%att_r%")]
		public void NotLike_StringAndISourceAndString_ThrowsArgumentException(string? column, string? pattern) =>
			NotLike_StringAndISourceAndString_ThrowsException<ArgumentException>(column, source: NewSource(), pattern);

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "%att_r%")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "%att_r%")]
		public void NotLike_StringAndNullISourceAndString_ThrowsArgumentException(string? column, string? pattern) =>
			NotLike_StringAndISourceAndString_ThrowsException<ArgumentException>(column, source: null, pattern);

		[Theory]
		[InlineData("")]
		[InlineData("%att_r%")]
		public void NotLike_FuncExpressionFactoryIExpressionAndString_Success(string pattern)
		{
			// Arrange
			IExpression expression = NewExpression();
			Func<ExpressionFactory, IExpression> expressionFunction = (factory) =>
			{
				Assert.NotNull(factory);

				return expression;
			};

			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act
			NotLikeCondition notLikeCondition = expressionFactory.NotLike(expressionFunction, pattern);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.Equal(expression, notLikeCondition.Expression);
			Assert.NotNull(notLikeCondition.Pattern);

			StringValue stringValue = Assert.IsType<StringValue>(notLikeCondition.Pattern);

			Assert.Equal(pattern, stringValue.Data);
		}

		[Fact]
		public void NotLike_FuncExpressionFactoryIExpressionAndNullString_ThrowsArgumentNullException() =>
			NotLike_FuncExpressionFactoryIExpressionAndString_ThrowsException<ArgumentNullException>((_) => NewExpression(), pattern: null);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("%att_r%")]
		public void NotLike_NullFuncExpressionFactoryIExpressionAndString_ThrowsArgumentNullException(string? pattern) =>
			NotLike_FuncExpressionFactoryIExpressionAndString_ThrowsException<ArgumentNullException>(expressionFunction: null, pattern);

		[Fact]
		public void NotLike_IExpressionAndIExpression_Success()
		{
			// Arrange
			IExpression expression = NewExpression();
			IExpression pattern = NewExpression();

			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act
			NotLikeCondition notLikeCondition = expressionFactory.NotLike(expression, pattern);

			// Assert
			Assert.NotNull(notLikeCondition);
			Assert.Equal(expression, notLikeCondition.Expression);
			Assert.Equal(pattern, notLikeCondition.Pattern);
		}

		[Fact]
		public void NotLike_IExpressionAndNullIExpression_ThrowsArgumentNullException() =>
			NotLike_IExpressionAndIExpression_ThrowsException<ArgumentNullException>(expression: NewExpression(), pattern: null);

		[Fact]
		public void NotLike_NullIExpressionAndIExpression_ThrowsArgumentNullException() =>
			NotLike_IExpressionAndIExpression_ThrowsException<ArgumentNullException>(expression: null, pattern: NewExpression());

		[Fact]
		public void NotLike_NullIExpressionAndNullIExpression_ThrowsArgumentNullException() =>
			NotLike_IExpressionAndIExpression_ThrowsException<ArgumentNullException>(expression: null, pattern: null);

		private void NotLike_IExpressionAndString_ThrowsException<TException>(IExpression? expression, string? pattern) where TException : Exception
		{
			// Arrange
			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act & Assert
			Assert.Throws<TException>(() => expressionFactory.NotLike(expression!, pattern!));
		}

		private void NotLike_StringAndString_ThrowsException<TException>(string? column, string? pattern) where TException : Exception
		{
			// Arrange
			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act & Assert
			Assert.Throws<TException>(() => expressionFactory.NotLike(column!, pattern!));
		}

		private void NotLike_StringAndStringAndString_ThrowsException<TException>(string? column, string? table, string? pattern) where TException : Exception
		{
			// Arrange
			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act & Assert
			Assert.Throws<TException>(() => expressionFactory.NotLike(column!, table!, pattern!));
		}

		private void NotLike_StringAndISourceAndString_ThrowsException<TException>(string? column, ISource? source, string? pattern) where TException : Exception
		{
			// Arrange
			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act & Assert
			Assert.Throws<TException>(() => expressionFactory.NotLike(column!, source!, pattern!));
		}

		private void NotLike_FuncExpressionFactoryIExpressionAndString_ThrowsException<TException>(
			Func<ExpressionFactory, IExpression>? expressionFunction, string? pattern) where TException : Exception
		{
			// Arrange
			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act & Assert
			Assert.Throws<TException>(() => expressionFactory.NotLike(expressionFunction!, pattern!));
		}

		private void NotLike_IExpressionAndIExpression_ThrowsException<TException>(IExpression? expression, IExpression? pattern) where TException : Exception
		{
			// Arrange
			ExpressionFactory expressionFactory = ExpressionFactory.Instance;

			// Act & Assert
			Assert.Throws<TException>(() => expressionFactory.NotLike(expression!, pattern!));
		}
	}
}
