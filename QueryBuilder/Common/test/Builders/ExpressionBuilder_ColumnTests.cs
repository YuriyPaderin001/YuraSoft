using System;
using System.Runtime.CompilerServices;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Builders
{
	public partial class ExpressionBuilderTests : TestsBase
	{
		#region + Column(function: Func<ExpressionFactory, IColumn>): ExpressionBuilder

		[Fact]
		public void Column_FuncExpressionFactoryIColumn_Success()
		{
			// Arrange
			IColumn expectedColumn = NewColumn();

			Func<ExpressionFactory, IColumn> function = (ExpressionFactory factory) =>
			{
				Assert.NotNull(factory);

				return expectedColumn;
			};

			ExpressionBuilder expressionBuilder = new ExpressionBuilder();

			// Act
			ExpressionBuilder configuredExpressionBuilder = expressionBuilder.Column(function);

			// Assert
			IExpression buildedExpression = ValidateExpressionBuilder(
				expressionBuilder, configuredExpressionBuilder);

			IColumn column = Assert.IsAssignableFrom<IColumn>(buildedExpression);

			Assert.NotNull(column);
			Assert.Equal(expectedColumn, column);
		}

		[Fact]
		public void Column_NullFuncExpressionFactoryIColumn_ThrowsArgumentNullException() =>
			Column_ThrowsException<ArgumentNullException>(builder => builder.Column(function: null!));

		#endregion + Column(function: Func<ExpressionFactory, IColumn>): ExpressionBuilder

		#region + Column(expression: IExpression, alias: string | null): ExpressionBuilder

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("column_1")]
		public void Column_IExpressionAndString_Success(string? alias)
		{
			// Arrange
			IExpression expression = NewExpression();

			ExpressionBuilder expressionBuilder = new ExpressionBuilder();

			// Act
			ExpressionBuilder configuredExpressionBuilder = expressionBuilder.Column(expression, alias);

			// Assert
			IExpression buildedExpression = ValidateExpressionBuilder(
				expressionBuilder, configuredExpressionBuilder);

			ExpressionColumn expressionColumn = Assert.IsType<ExpressionColumn>(buildedExpression);

			Assert.NotNull(expressionColumn);
			Assert.Equal(expression, expressionColumn.Expression);

			ValidateAlias(alias, expressionColumn.Alias);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("column_1")]
		public void Column_NullIExpressionAndString_ThrowsArgumentNullException(string? alias) =>
			Column_ThrowsException<ArgumentNullException>(builder => builder.Column(expression: null!, alias));

		#endregion + Column(expression: IExpression, alias: string | null): ExpressionBuilder

		#region + Column(expressionFunction: Func<ExpressionFactory, IExpression>, alias: string | null): ExpressionBuilder

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("column_1")]
		public void Column_FuncExpressionFactoryIExpressionAndString_Success(string? alias)
		{
			// Arrange
			IExpression expression = NewExpression();

			Func<ExpressionFactory, IExpression> expressionFunction = (factory) =>
			{
				Assert.NotNull(factory);

				return expression;
			};

			ExpressionBuilder expressionBuilder = new ExpressionBuilder();

			// Act
			ExpressionBuilder configuredExpressionBuilder = expressionBuilder.Column(expressionFunction, alias);

			// Assert
			IExpression buildedExpression = ValidateExpressionBuilder(
				expressionBuilder, configuredExpressionBuilder);

			ExpressionColumn expressionColumn = Assert.IsType<ExpressionColumn>(buildedExpression);

			Assert.NotNull(expressionColumn);
			Assert.Equal(expression, expressionColumn.Expression);

			ValidateAlias(alias, expressionColumn.Alias);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("column_1")]
		public void Column_NullFuncExpressionFactoryIExpressionAndString_ThrowsArgumentNullException(string? alias) =>
			Column_ThrowsException<ArgumentNullException>(builder => builder.Column(expressionFunction: null!, alias));

		#endregion + Column(expressionFunction: Func<ExpressionFactory, IExpression>, alias: string | null): ExpressionBuilder

		#region + Column(name: string): ExpressionBuilder

		[Fact]
		public void Column_String_Success()
		{
			// Arrange
			string name = "column_1";

			ExpressionBuilder expressionBuilder = new ExpressionBuilder();

			// Act
			ExpressionBuilder configuredExpressionBuilder = expressionBuilder.Column(name);

			// Assert
			IExpression buildedExpression = ValidateExpressionBuilder(
				expressionBuilder, configuredExpressionBuilder);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(buildedExpression);

			Assert.NotNull(sourceColumn);
			Assert.Equal(name, sourceColumn.Name);
			Assert.Null(sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Column_NullOrEmptyString_ThrowsArgumentException(string? name) =>
			Column_ThrowsException<ArgumentException>(builder => builder.Column(name!));

		#endregion + Column(name: string): ExpressionBuilder

		#region + Column(name: string, alias: string | null): ExpressionBuilder

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("alias_1")]
		public void Column_StringAndString_Success(string? alias)
		{
			// Arrange
			string name = "column_1";

			ExpressionBuilder expressionBuilder = new ExpressionBuilder();

			// Act
			ExpressionBuilder configuredExpressionBuilder = expressionBuilder.Column(name, alias);

			// Assert
			IExpression buildedExpression = ValidateExpressionBuilder(
				expressionBuilder, configuredExpressionBuilder);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(buildedExpression);

			Assert.NotNull(sourceColumn);
			Assert.Equal(name, sourceColumn.Name);
			Assert.Null(sourceColumn.Source);

			ValidateAlias(alias, sourceColumn.Alias);
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "alias_1")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "alias_1")]
		public void Column_NullOrEmptyStringAndString_ThrowsArgumentException(
			string? name, string? alias) => Column_ThrowsException<ArgumentException>(
				builder => builder.Column(name!, alias));

		#endregion + Column(name: string, alias: string | null): ExpressionBuilder

		#region + Column(name: string, alias: string | null, table: string | null): ExpressionBuilder

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "table_1")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "alias_1")]
		[InlineData("alias_1", null)]
		[InlineData("alias_1", "")]
		[InlineData("alias_1", "table_1")]
		public void Column_StringAndStringAndString_Success(string? alias, string? table)
		{
			// Arrange
			string name = "column_1";

			ExpressionBuilder expressionBuilder = new ExpressionBuilder();

			// Act
			ExpressionBuilder configuredExpressionBuilder = expressionBuilder.Column(name, alias, table);

			// Assert
			IExpression buildedExpression = ValidateExpressionBuilder(
				expressionBuilder, configuredExpressionBuilder);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(buildedExpression);

			Assert.NotNull(sourceColumn);
			Assert.Equal(name, sourceColumn.Name);

			if (string.IsNullOrEmpty(table))
			{
				Assert.Null(sourceColumn.Source);
			}
			else
			{
				Assert.NotNull(sourceColumn.Source);

				Table columnTable = Assert.IsType<Table>(sourceColumn.Source);

				Assert.Equal(table, columnTable.Name);
				Assert.Null(columnTable.Schema);
				Assert.Null(columnTable.Alias);
			}

			ValidateAlias(alias, sourceColumn.Alias);
		}

		[Theory]
		[InlineData(null, null, null)]
		[InlineData(null, null, "")]
		[InlineData(null, null, "table_1")]
		[InlineData(null, "", null)]
		[InlineData(null, "", "")]
		[InlineData(null, "", "table_1")]
		[InlineData(null, "alias_1", null)]
		[InlineData(null, "alias_1", "")]
		[InlineData(null, "alias_1", "table_1")]
		[InlineData("", null, null)]
		[InlineData("", null, "")]
		[InlineData("", null, "table_1")]
		[InlineData("", "", null)]
		[InlineData("", "", "")]
		[InlineData("", "", "table_1")]
		[InlineData("", "alias_1", null)]
		[InlineData("", "alias_1", "")]
		[InlineData("", "alias_1", "table_1")]
		public void Column_NullOrEmptyStringAndStringAndString_ThrowsArgumentException(
			string? name, string? alias, string? table) => Column_ThrowsException<ArgumentException>(
				builder => builder.Column(name!, alias, table));

		#endregion + Column(name: string, alias: string | null, table: string | null): ExpressionBuilder

		#region + Column(name: string, source: ISource | null): ExpressionBuilder

		[Fact]
		public void Column_StringAndISource_Success()
		{
			// Arrange
			string name = "column_1";
			ISource source = NewSource();

			ExpressionBuilder expressionBuilder = new ExpressionBuilder();

			// Act
			ExpressionBuilder configuredExpressionBuilder = expressionBuilder.Column(name, source);

			// Assert
			IExpression buildedExpression = ValidateExpressionBuilder(
				expressionBuilder, configuredExpressionBuilder);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(buildedExpression);

			Assert.NotNull(sourceColumn);
			Assert.Equal(name, sourceColumn.Name);
			Assert.Equal(source, sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);
		}

		[Fact]
		public void Column_StringAndNullISource_Success()
		{
			// Arrange
			string name = "column_1";

			ExpressionBuilder expressionBuilder = new ExpressionBuilder();

			// Act
			ExpressionBuilder configuredExpressionBuilder = expressionBuilder.Column(name, source: null);

			// Assert
			IExpression buildedExpression = ValidateExpressionBuilder(
				expressionBuilder, configuredExpressionBuilder);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(buildedExpression);

			Assert.NotNull(sourceColumn);
			Assert.Equal(name, sourceColumn.Name);
			Assert.Null(sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Column_NullOrEmptyStringAndISource_ThrowsArgumentException(string? name) =>
			Column_ThrowsException<ArgumentException>(builder => builder.Column(
				name!, source: NewSource()));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Column_NullOrEmptyStringAndNullISource_ThrowsArgumentException(string? name) =>
			Column_ThrowsException<ArgumentException>(builder => builder.Column(
				name!, source: null));

		#endregion + Column(name: string, source: ISource | null): ExpressionBuilder

		#region + Column(name: string, alias: string | null, source: ISource | null): ExpressionBuilder

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("alias_1")]
		public void Column_StringAndStringAndISource_Success(string? alias)
		{
			// Arrange
			string name = "column_1";
			ISource source = NewSource();

			ExpressionBuilder expressionBuilder = new ExpressionBuilder();

			// Act
			ExpressionBuilder configuredExpressionBuilder = expressionBuilder.Column(name, alias, source);

			// Assert
			IExpression buildedExpression = ValidateExpressionBuilder(
				expressionBuilder, configuredExpressionBuilder);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(buildedExpression);

			Assert.NotNull(sourceColumn);
			Assert.Equal(name, sourceColumn.Name);
			Assert.Equal(source, sourceColumn.Source);

			ValidateAlias(alias, sourceColumn.Alias);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("alias_1")]
		public void Column_StringAndStringAndNullISource_Success(string? alias)
		{
			// Arrange
			string name = "column_1";

			ExpressionBuilder expressionBuilder = new ExpressionBuilder();

			// Act
			ExpressionBuilder configuredExpressionBuilder = expressionBuilder.Column(name, alias, source: null);

			// Assert
			IExpression buildedExpression = ValidateExpressionBuilder(
				expressionBuilder, configuredExpressionBuilder);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(buildedExpression);

			Assert.NotNull(sourceColumn);
			Assert.Equal(name, sourceColumn.Name);
			Assert.Null(sourceColumn.Source);

			ValidateAlias(alias, sourceColumn.Alias);
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "alias_1")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "alias_1")]
		public void Column_NullOrEmptyStringAndStringAndISource_ThrowsArgumentException(
			string? name, string? alias) => Column_ThrowsException<ArgumentException>(
				builder => builder.Column(name!, alias, source: NewSource()));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "alias_1")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "alias_1")]
		public void Column_NullOrEmptyStringAndStringAndNullISource_ThrowsArgumentException(
			string? name, string? alias) => Column_ThrowsException<ArgumentException>(
				builder => builder.Column(name!, alias, source: null));

		#endregion + Column(name: string, alias: string | null, source: ISource | null): ExpressionBuilder

		private void Column_ThrowsException<TException>(Action<ExpressionBuilder> buildFunction) where TException : Exception
		{
			// Arrange
			ExpressionBuilder expressionBuilder = new ExpressionBuilder();

			// Act & Assert
			Assert.Throws<TException>(() => buildFunction.Invoke(expressionBuilder));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ValidateAlias(string? alias, string? actualAlias)
		{
			if (string.IsNullOrEmpty(alias))
			{
				Assert.Null(actualAlias);
			}
			else
			{
				Assert.Equal(alias, actualAlias);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static IExpression ValidateExpressionBuilder(
			ExpressionBuilder originalExpressionBuilder,
			ExpressionBuilder configuredExpressionBuilder)
		{
			Assert.NotNull(configuredExpressionBuilder);
			Assert.Equal(originalExpressionBuilder, configuredExpressionBuilder);

			IExpression buildedExpression = Assert.Single(configuredExpressionBuilder.Build());

			Assert.NotNull(buildedExpression);

			return buildedExpression;
		}
	}
}
