using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Expressions
{
	public class PlusExpressionTests : TestsBase
	{
		[Theory]
		[InlineData(2)]
		[InlineData(3)]
		public void Constructor_Expressions_Success(int length)
		{
			// Arrange
			List<IExpression> expressions = NewExpressionList(length);

			// Act
			PlusExpression plusExpression = new PlusExpression(expressions);

			// Assert
			Assert.Equal(expressions, plusExpression.Expressions);
		}

		[Fact]
		public void Constructor_OneExpression_ThrowsArgumentOutOfRangeException()
		{
			// Act & Assert
			Assert.Throws<ArgumentOutOfRangeException>(() => new PlusExpression(NewExpressionList(1)));
		}

		[Fact]
		public void Constructor_EmptyExpressionEnumerable_ThrowsArgumentOutOfRangeException()
		{
			// Act & Assert
			Assert.Throws<ArgumentOutOfRangeException>(() => new PlusExpression(NewEmptyExpressionList()));
		}

		[Fact]
		public void Constructor_NullEnumerable_ThrowsArgumentNullException()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new PlusExpression(null!));
		}

		[Theory]
		[InlineData(2)]
		[InlineData(3)]
		public void SetExpressions_Expressions_Success(int length)
		{
			// Arrange
			PlusExpression plusExpression = new PlusExpression(NewExpressionList(length));
			List<IExpression> expressions = NewExpressionList(length);

			// Act
			plusExpression.Expressions = expressions;

			// Assert
			Assert.Equal(expressions, plusExpression.Expressions);
		}

		[Fact]
		public void SetExpressions_OneExpression_ThrowsArgumentOutOfRangeException()
		{
			// Arrange
			PlusExpression plusExpression = new PlusExpression(NewExpressionList(2));

			// Act & Assert
			Assert.Throws<ArgumentOutOfRangeException>(() => plusExpression.Expressions = NewExpressionList(1));
		}

		[Fact]
		public void SetExpressions_EmptyExpressionList_ThrowsArgumentOutOfRangeException()
		{
			// Arrange
			PlusExpression plusExpression = new PlusExpression(NewExpressionList(2));

			// Act & Assert
			Assert.Throws<ArgumentOutOfRangeException>(() => plusExpression.Expressions = NewEmptyExpressionList());
		}

		[Fact]
		public void SetExpressions_NullList_ThrowsArgumentNullException()
		{
			// Arrange
			PlusExpression plusExpression = new PlusExpression(NewExpressionList(2));

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => plusExpression.Expressions = null!);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			PlusExpression plusExpression = new PlusExpression(NewExpressionList(2));

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock
			  .Setup(ca => ca.RenderExpression(It.IsAny<PlusExpression>(), It.IsAny<StringBuilder>()))
			  .Callback((PlusExpression expression, StringBuilder sql) =>
			  {
				  sql.Append(expectedSql);
			  });

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			plusExpression.RenderExpression(renderer, sql);

			// Assert
			Assert.NotNull(sql);
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			PlusExpression plusExpression = new PlusExpression(NewExpressionList(2));

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock
			  .Setup(ca => ca.RenderExpression(It.IsAny<PlusExpression>(), It.IsAny<StringBuilder>()))
			  .Callback((PlusExpression expression, StringBuilder sql) =>
			  {
				  sql.Append(expectedSql);
			  });

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = plusExpression.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}
	}
}
