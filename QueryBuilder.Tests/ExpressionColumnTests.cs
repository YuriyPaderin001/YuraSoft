using System;
using Xunit;

using YuraSoft.QueryBuilder.Interfaces;

namespace YuraSoft.QueryBuilder.Tests
{
	public class ExpressionColumnTests
	{
		[Fact]
		public void Create_WithAllParameters_Success()
		{
			const string name = "max_column";

			IColumn column = new SourceColumn("column_name");
			MaxFunction maxFunction = new MaxFunction(column);

			ExpressionColumn expressionColumn = new ExpressionColumn(maxFunction, "max_column");

			Assert.IsType<MaxFunction>(expressionColumn.Expression);
			Assert.Equal(maxFunction, (MaxFunction)expressionColumn.Expression);
			Assert.Equal(name, expressionColumn.Name);
		}

		[Fact]
		public void Create_ExpressionIsNull_ThrowArgumentShouldNotBeNullException()
		{
			Assert.Throws<ArgumentNullException>(() => new ExpressionColumn(null!));
		}

		[Theory]
		[InlineData("")]
		[InlineData(null)]
		public void Create_NameIsEmptyOrNull_NameIsNull(string? name)
		{
			IColumn column = new SourceColumn("column_name");
			MaxFunction maxFunction = new MaxFunction(column);

			ExpressionColumn expressionColumn = new ExpressionColumn(maxFunction, name);

			Assert.IsType<MaxFunction>(expressionColumn.Expression);
			Assert.Equal(maxFunction, (MaxFunction)expressionColumn.Expression);
			Assert.Null(expressionColumn.Name);
		}
	}
}
