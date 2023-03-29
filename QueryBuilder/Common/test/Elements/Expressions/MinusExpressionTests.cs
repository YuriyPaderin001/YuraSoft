using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Expressions
{
	public class MinusExpressionTests : TestsBase
	{
		[Theory]
		[InlineData(2)]
		[InlineData(3)]
		public void Constructor_Expressions_Success(int length)
		{
			// Arrange
			List<IExpression> expressions = NewExpressionList(length);

			// Act
			MinusExpression minusExpression = new MinusExpression(expressions);

			// Assert
			Assert.Equal(expressions, minusExpression.Expressions);
		}

		[Fact]
		public void Constructor_OneExpression_ThrowsArgumentOutOfRangeException()
		{
			// Act & Assert
			Assert.Throws<ArgumentOutOfRangeException>(() => new MinusExpression(NewExpressionList(1)));
		}

		[Fact]
		public void Constructor_EmptyExpressionEnumerable_ThrowsArgumentOutOfRangeException()
		{
			// Act & Assert
			Assert.Throws<ArgumentOutOfRangeException>(() => new MinusExpression(NewEmptyExpressionList()));
		}

		[Fact]
		public void Constructor_NullEnumerable_ThrowsArgumentNullException()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new MinusExpression(null!));
		}

		[Theory]
		[InlineData(2)]
		[InlineData(3)]
		public void SetExpressions_Expressions_Success(int length)
		{
			// Arrange
			MinusExpression minusExpression = new MinusExpression(NewExpressionList(length));
			List<IExpression> expressions = NewExpressionList(length);

			// Act
			minusExpression.Expressions = expressions;

			// Assert
			Assert.Equal(expressions, minusExpression.Expressions);
		}

		[Fact]
		public void SetExpressions_OneExpression_ThrowsArgumentOutOfRangeException()
		{
			// Arrange
			MinusExpression minusExpression = new MinusExpression(NewExpressionList(2));

			// Act & Assert
			Assert.Throws<ArgumentOutOfRangeException>(() => minusExpression.Expressions = NewExpressionList(1));
		}

		[Fact]
		public void SetExpressions_EmptyExpressionList_ThrowsArgumentOutOfRangeException()
		{
			// Arrange
			MinusExpression minusExpression = new MinusExpression(NewExpressionList(2));

			// Act & Assert
			Assert.Throws<ArgumentOutOfRangeException>(() => minusExpression.Expressions = NewEmptyExpressionList());
		}

		[Fact]
		public void SetExpressions_NullList_ThrowsArgumentNullException()
		{
			// Arrange
			MinusExpression minusExpression = new MinusExpression(NewExpressionList(2));

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => minusExpression.Expressions = null!);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			MinusExpression minusExpression = new MinusExpression(NewExpressionList(2));

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock
			  .Setup(ca => ca.RenderExpression(It.IsAny<MinusExpression>(), It.IsAny<StringBuilder>()))
			  .Callback((MinusExpression expression, StringBuilder sql) =>
			  {
				  sql.Append(expectedSql);
			  });

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			minusExpression.RenderExpression(renderer, sql);

			// Assert
			Assert.NotNull(sql);
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			MinusExpression minusExpression = new MinusExpression(NewExpressionList(2));

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock
			  .Setup(ca => ca.RenderExpression(It.IsAny<MinusExpression>(), It.IsAny<StringBuilder>()))
			  .Callback((MinusExpression expression, StringBuilder sql) =>
			  {
				  sql.Append(expectedSql);
			  });

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = minusExpression.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}
	}
}
