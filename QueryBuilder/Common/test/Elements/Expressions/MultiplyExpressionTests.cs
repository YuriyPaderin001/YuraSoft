using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Expressions
{
	public class MultiplyExpressionTests : TestsBase
	{
		[Theory]
		[InlineData(2)]
		[InlineData(3)]
		public void Constructor_Expressions_Success(int length)
		{
			// Arrange
			List<IExpression> expressions = NewExpressionList(length);

			// Act
			MultiplyExpression multiplyExpression = new MultiplyExpression(expressions);

			// Assert
			Assert.Equal(expressions, multiplyExpression.Expressions);
		}

		[Fact]
		public void Constructor_OneExpression_ThrowsArgumentOutOfRangeException()
		{
			// Act & Assert
			Assert.Throws<ArgumentOutOfRangeException>(() => new MultiplyExpression(NewExpressionList(1)));
		}

		[Fact]
		public void Constructor_EmptyExpressionEnumerable_ThrowsArgumentOutOfRangeException()
		{
			// Act & Assert
			Assert.Throws<ArgumentOutOfRangeException>(() => new MultiplyExpression(NewEmptyExpressionList()));
		}

		[Fact]
		public void Constructor_NullEnumerable_ThrowsArgumentNullException()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new MultiplyExpression(null!));
		}

		[Theory]
		[InlineData(2)]
		[InlineData(3)]
		public void SetExpressions_Expressions_Success(int length)
		{
			// Arrange
			MultiplyExpression multiplyExpression = new MultiplyExpression(NewExpressionList(length));
			List<IExpression> expressions = NewExpressionList(length);

			// Act
			multiplyExpression.Expressions = expressions;

			// Assert
			Assert.Equal(expressions, multiplyExpression.Expressions);
		}

		[Fact]
		public void SetExpressions_OneExpression_ThrowsArgumentOutOfRangeException()
		{
			// Arrange
			MultiplyExpression multiplyExpression = new MultiplyExpression(NewExpressionList(2));

			// Act & Assert
			Assert.Throws<ArgumentOutOfRangeException>(() => multiplyExpression.Expressions = NewExpressionList(1));
		}

		[Fact]
		public void SetExpressions_EmptyExpressionList_ThrowsArgumentOutOfRangeException()
		{
			// Arrange
			MultiplyExpression multiplyExpression = new MultiplyExpression(NewExpressionList(2));

			// Act & Assert
			Assert.Throws<ArgumentOutOfRangeException>(() => multiplyExpression.Expressions = NewEmptyExpressionList());
		}

		[Fact]
		public void SetExpressions_NullList_ThrowsArgumentNullException()
		{
			// Arrange
			MultiplyExpression multiplyExpression = new MultiplyExpression(NewExpressionList(2));

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => multiplyExpression.Expressions = null!);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			MultiplyExpression multiplyExpression = new MultiplyExpression(NewExpressionList(2));

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock
			  .Setup(ca => ca.RenderExpression(It.IsAny<MultiplyExpression>(), It.IsAny<StringBuilder>()))
			  .Callback((MultiplyExpression expression, StringBuilder sql) =>
			  {
				  sql.Append(expectedSql);
			  });

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			multiplyExpression.RenderExpression(renderer, sql);

			// Assert
			Assert.NotNull(sql);
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			MultiplyExpression multiplyExpression = new MultiplyExpression(NewExpressionList(2));

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock
			  .Setup(ca => ca.RenderExpression(It.IsAny<MultiplyExpression>(), It.IsAny<StringBuilder>()))
			  .Callback((MultiplyExpression expression, StringBuilder sql) =>
			  {
				  sql.Append(expectedSql);
			  });

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = multiplyExpression.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}
	}
}
