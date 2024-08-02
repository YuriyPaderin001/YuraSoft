using System;
using System.Runtime.CompilerServices;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Builders
{
	public partial class ExpressionFactoryTests : TestsBase
	{
		#region + Column(function: Func<ExpressionFactory, IColumn>): IColumn

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

			// Act
			IColumn column = ExpressionFactory.Column(function);

			// Assert
			Assert.NotNull(column);
			Assert.Equal(expectedColumn, column);
		}

		[Fact]
		public void Column_NullFuncExpressionFactoryIColumn_ThrowsArgumentNullException() =>
			Column_ThrowsException<ArgumentNullException>(factory => factory.Column(function: null!));

		#endregion + Column(function: Func<ExpressionFactory, IColumn>): IColumn

		#region + Column(expression: IExpression, alias: string | null): ExpressionColumn

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("column_1")]
		public void Column_IExpressionAndString_Success(string? alias)
		{
			// Arrange
			IExpression expression = NewExpression();

			// Act
			ExpressionColumn expressionColumn = ExpressionFactory.Column(expression, alias);

			// Assert
			Assert.NotNull(expressionColumn);
			Assert.Equal(expression, expressionColumn.Expression);

			ValidateAlias(alias, expressionColumn.Alias);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("column_1")]
		public void Column_NullIExpressionAndString_ThrowsArgumentNullException(string? alias) =>
			Column_ThrowsException<ArgumentNullException>(factory => factory.Column(expression: null!, alias));

		#endregion + Column(expression: IExpression, alias: string | null): ExpressionColumn

		#region + Column(expressionFunction: Func<ExpressionFactory, IExpression>, alias: string | null): ExpressionColumn

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

			// Act
			ExpressionColumn expressionColumn = ExpressionFactory.Column(expressionFunction, alias);

			// Assert
			Assert.NotNull(expressionColumn);
			Assert.Equal(expression, expressionColumn.Expression);

			ValidateAlias(alias, expressionColumn.Alias);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("column_1")]
		public void Column_NullFuncExpressionFactoryIExpressionAndString_ThrowsArgumentNullException(string? alias) =>
			Column_ThrowsException<ArgumentNullException>(factory => factory.Column(expressionFunction: null!, alias));

		#endregion + Column(expressionFunction: Func<ExpressionFactory, IExpression>, alias: string | null): ExpressionColumn

		#region + Column(name: string): SourceColumn

		[Fact]
		public void Column_String_Success()
		{
			// Arrange
			string name = "column_1";

			// Act
			SourceColumn sourceColumn = ExpressionFactory.Column(name);

			// Assert
			Assert.NotNull(sourceColumn);
			Assert.Equal(name, sourceColumn.Name);
			Assert.Null(sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Column_NullOrEmptyString_ThrowsArgumentException(string? name) =>
			Column_ThrowsException<ArgumentException>(factory => factory.Column(name!));

		#endregion + Column(name: string): SourceColumn

		#region + Column(name: string, alias: string | null): SourceColumn

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("alias_1")]
		public void Column_StringAndString_Success(string? alias)
		{
			// Arrange
			string name = "column_1";

			// Act
			SourceColumn sourceColumn = ExpressionFactory.Column(name, alias);

			// Assert
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
				factory => factory.Column(name!, alias));

		#endregion + Column(name: string, alias: string | null): SourceColumn

		#region + Column(name: string, alias: string | null, table: string | null): SourceColumn

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

			// Act
			SourceColumn sourceColumn = ExpressionFactory.Column(name, alias, table);

			// Assert
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
				factory => factory.Column(name!, alias, table));

		#endregion + Column(name: string, alias: string | null, table: string | null): SourceColumn

		#region + Column(name: string, source: ISource | null): SourceColumn

		[Fact]
		public void Column_StringAndISource_Success()
		{
			// Arrange
			string name = "column_1";
			ISource source = NewSource();

			// Act
			SourceColumn sourceColumn = ExpressionFactory.Column(name, source);

			// Assert
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

			// Act
			SourceColumn sourceColumn = ExpressionFactory.Column(name, source: null);

			// Assert
			Assert.NotNull(sourceColumn);
			Assert.Equal(name, sourceColumn.Name);
			Assert.Null(sourceColumn.Source);
			Assert.Null(sourceColumn.Alias);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Column_NullOrEmptyStringAndISource_ThrowsArgumentException(string? name) =>
			Column_ThrowsException<ArgumentException>(factory => factory.Column(
				name!, source: NewSource()));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Column_NullOrEmptyStringAndNullISource_ThrowsArgumentException(string? name) =>
			Column_ThrowsException<ArgumentException>(factory => factory.Column(
				name!, source: null));

		#endregion + Column(name: string, source: ISource | null): SourceColumn

		#region + Column(name: string, alias: string | null, source: ISource | null): SourceColumn

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("alias_1")]
		public void Column_StringAndStringAndISource_Success(string? alias)
		{
			// Arrange
			string name = "column_1";
			ISource source = NewSource();

			// Act
			SourceColumn sourceColumn = ExpressionFactory.Column(name, alias, source);

			// Assert
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

			// Act
			SourceColumn sourceColumn = ExpressionFactory.Column(name, alias, source: null);

			// Assert
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
				factory => factory.Column(name!, alias, source: NewSource()));

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "alias_1")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "alias_1")]
		public void Column_NullOrEmptyStringAndStringAndNullISource_ThrowsArgumentException(
			string? name, string? alias) => Column_ThrowsException<ArgumentException>(
				factory => factory.Column(name!, alias, source: null));

		#endregion + Column(name: string, alias: string | null, source: ISource | null): SourceColumn

		private void Column_ThrowsException<TException>(Func<ExpressionFactory, IColumn> columnFunction) where TException : Exception
		{
			// Arrange & Act & Assert
			Assert.Throws<TException>(() => columnFunction.Invoke(ExpressionFactory));
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
	}
}
