using System;
using System.Runtime.CompilerServices;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Builders
{
	public partial class ColumnBuilderTests : TestsBase
	{
		#region + Column(column: IColumn): ColumnBuilder

		[Fact]
		public void Column_IColumn_Success()
		{
			// Arrange
			IColumn column = NewColumn();

			ColumnBuilder columnBuilder = new ColumnBuilder();

			// Act
			ColumnBuilder configuredColumnBuilder = columnBuilder.Column(column);

			// Assert
			IColumn buildedColumn = ValidateColumnBuilder(columnBuilder, configuredColumnBuilder);

			Assert.NotNull(buildedColumn);
			Assert.Equal(column, buildedColumn);
		}

		[Fact]
		public void Column_NullIColumn_ThrowsArgumentNullException() =>
			Column_ThrowsException<ArgumentNullException>(builder => builder.Column(column: null!));

		#endregion + Column(column: IColumn): ColumnBuilder

		#region + Column(expression: IExpression, alias: string | null): ColumnBuilder

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("column_1")]
		public void Column_IExpressionAndString_Success(string? alias)
		{
			// Arrange
			IExpression expression = NewExpression();

			ColumnBuilder columnBuilder = new ColumnBuilder();

			// Act
			ColumnBuilder configuredColumnBuilder = columnBuilder.Column(expression, alias);

			// Assert
			IColumn buildedColumn = ValidateColumnBuilder(
				columnBuilder, configuredColumnBuilder);

			ExpressionColumn expressionColumn = Assert.IsType<ExpressionColumn>(buildedColumn);

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

		#endregion + Column(expression: IExpression, alias: string | null): ColumnBuilder

		#region + Column(expressionFunction: Func<ExpressionFactory, IExpression>, alias: string | null): ColumnBuilder

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

			ColumnBuilder columnBuilder = new ColumnBuilder();

			// Act
			ColumnBuilder configuredColumnBuilder = columnBuilder.Column(expressionFunction, alias);

			// Assert
			IColumn buildedColumn = ValidateColumnBuilder(columnBuilder, configuredColumnBuilder);

			ExpressionColumn expressionColumn = Assert.IsType<ExpressionColumn>(buildedColumn);

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

		#endregion + Column(expressionFunction: Func<ExpressionFactory, IExpression>, alias: string | null): ColumnBuilder

		#region + Column(name: string): ColumnBuilder

		[Fact]
		public void Column_String_Success()
		{
			// Arrange
			string name = "column_1";

			ColumnBuilder columnBuilder = new ColumnBuilder();

			// Act
			ColumnBuilder configuredColumnBuilder = columnBuilder.Column(name);

			// Assert
			IColumn buildedColumn = ValidateColumnBuilder(columnBuilder, configuredColumnBuilder);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(buildedColumn);

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

		#endregion + Column(name: string): ColumnBuilder

		#region + Column(name: string, alias: string | null): ColumnBuilder

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("alias_1")]
		public void Column_StringAndString_Success(string? alias)
		{
			// Arrange
			string name = "column_1";

			ColumnBuilder columnBuilder = new ColumnBuilder();

			// Act
			ColumnBuilder configuredColumnBuilder = columnBuilder.Column(name, alias);

			// Assert
			IColumn buildedColumn = ValidateColumnBuilder(columnBuilder, configuredColumnBuilder);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(buildedColumn);

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

		#endregion + Column(name: string, alias: string | null): ColumnBuilder

		#region + Column(name: string, alias: string | null, table: string | null): ColumnBuilder

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

			ColumnBuilder columnBuilder = new ColumnBuilder();

			// Act
			ColumnBuilder configuredColumnBuilder = columnBuilder.Column(name, alias, table);

			// Assert
			IColumn buildedColumn = ValidateColumnBuilder(columnBuilder, configuredColumnBuilder);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(buildedColumn);

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

		#endregion + Column(name: string, alias: string | null, table: string | null): ColumnBuilder

		#region + Column(name: string, source: ISource | null): ColumnBuilder

		[Fact]
		public void Column_StringAndISource_Success()
		{
			// Arrange
			string name = "column_1";
			ISource source = NewSource();

			ColumnBuilder columnBuilder = new ColumnBuilder();

			// Act
			ColumnBuilder configuredColumnBuilder = columnBuilder.Column(name, source);

			// Assert
			IColumn buildedColumn = ValidateColumnBuilder(columnBuilder, configuredColumnBuilder);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(buildedColumn);

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

			ColumnBuilder columnBuilder = new ColumnBuilder();

			// Act
			ColumnBuilder configuredColumnBuilder = columnBuilder.Column(name, source: null);

			// Assert
			IColumn buildedColumn = ValidateColumnBuilder(columnBuilder, configuredColumnBuilder);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(buildedColumn);

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

		#endregion + Column(name: string, source: ISource | null): ColumnBuilder

		#region + Column(name: string, alias: string | null, source: ISource | null): ColumnBuilder

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("alias_1")]
		public void Column_StringAndStringAndISource_Success(string? alias)
		{
			// Arrange
			string name = "column_1";
			ISource source = NewSource();

			ColumnBuilder columnBuilder = new ColumnBuilder();

			// Act
			ColumnBuilder configuredColumnBuilder = columnBuilder.Column(name, alias, source);

			// Assert
			IColumn buildedColumn = ValidateColumnBuilder(columnBuilder, configuredColumnBuilder);

			SourceColumn sourceColumn = Assert.IsType<SourceColumn>(buildedColumn);

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

			ColumnBuilder columnBuilder = new ColumnBuilder();

			// Act
			ColumnBuilder configuredColumnBuilder = columnBuilder.Column(name, alias, source: null);

			// Assert
			IExpression buildedExpression = ValidateColumnBuilder(columnBuilder, configuredColumnBuilder);

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

		#endregion + Column(name: string, alias: string | null, source: ISource | null): ColumnBuilder

		private void Column_ThrowsException<TException>(Action<ColumnBuilder> buildFunction) where TException : Exception
		{
			// Arrange
			ColumnBuilder columnBuilder = new ColumnBuilder();

			// Act & Assert
			Assert.Throws<TException>(() => buildFunction.Invoke(columnBuilder));
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
		private static IColumn ValidateColumnBuilder(
			ColumnBuilder originalColumnBuilder,
			ColumnBuilder configuredColumnBuilder)
		{
			Assert.NotNull(configuredColumnBuilder);
			Assert.Equal(originalColumnBuilder, configuredColumnBuilder);

			IColumn buildedColumn = Assert.Single(configuredColumnBuilder.Build());

			Assert.NotNull(buildedColumn);

			return buildedColumn;
		}
	}
}
