using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Expressions
{
	public class DivideExpressionTests : TestsBase
	{
    [Theory]
    [InlineData(2)]
    [InlineData(3)]
		public void Constructor_Expressions_Success(int length)
		{
			// Arrange
			List<IExpression> expressions = NewExpressionList(length);

			// Act
			DivideExpression divideExpression = new DivideExpression(expressions);

      // Assert
      Assert.Equal(expressions, divideExpression.Expressions);
		}

		[Fact]
		public void Constructor_OneExpression_ThrowsArgumentOutOfRangeException()
		{
			// Act & Assert
			Assert.Throws<ArgumentOutOfRangeException>(() => new DivideExpression(NewExpressionList(1)));
		}

		[Fact]
		public void Constructor_EmptyExpressionEnumerable_ThrowsArgumentOutOfRangeException()
		{
			// Act & Assert
			Assert.Throws<ArgumentOutOfRangeException>(() => new DivideExpression(NewEmptyExpressionList()));
		}

		[Fact]
		public void Constructor_NullEnumerable_ThrowsArgumentNullException()
		{
      // Act & Assert
      Assert.Throws<ArgumentNullException>(() => new DivideExpression(null!));
		}

    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    public void SetExpressions_Expressions_Success(int length)
    {
      // Arrange
      DivideExpression divideExpression = new DivideExpression(NewExpressionList(length));
      List<IExpression> expressions = NewExpressionList(length);

      // Act
      divideExpression.Expressions = expressions;

      // Assert
      Assert.Equal(expressions, divideExpression.Expressions);
    }

    [Fact]
    public void SetExpressions_OneExpression_ThrowsArgumentOutOfRangeException()
    {
      // Arrange
      DivideExpression divideExpression = new DivideExpression(NewExpressionList(2));

      // Act & Assert
      Assert.Throws<ArgumentOutOfRangeException>(() => divideExpression.Expressions = NewExpressionList(1));
    }

    [Fact]
    public void SetExpressions_EmptyExpressionList_ThrowsArgumentOutOfRangeException()
    {
      // Arrange
      DivideExpression divideExpression = new DivideExpression(NewExpressionList(2));

      // Act & Assert
      Assert.Throws<ArgumentOutOfRangeException>(() => divideExpression.Expressions = NewEmptyExpressionList());
    }

    [Fact]
    public void SetExpressions_NullList_ThrowsArgumentNullException()
    {
      // Arrange
      DivideExpression divideExpression = new DivideExpression(NewExpressionList(2));

      // Act & Assert
      Assert.Throws<ArgumentNullException>(() => divideExpression.Expressions = null!);
    }

    [Fact]
    public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
    {
      // Arrange
      DivideExpression divideExpression = new DivideExpression(NewExpressionList(2));

      const string expectedSql = "test";

      Mock<IRenderer> rendererMock = new Mock<IRenderer>();
      rendererMock
        .Setup(ca => ca.RenderExpression(It.IsAny<DivideExpression>(), It.IsAny<StringBuilder>()))
        .Callback((DivideExpression expression, StringBuilder sql) =>
        {
          sql.Append(expectedSql);
        });

      IRenderer renderer = rendererMock.Object;
      StringBuilder sql = new StringBuilder();

      // Act
      divideExpression.RenderExpression(renderer, sql);

      // Assert
      Assert.NotNull(sql);
      Assert.Equal(expectedSql, sql.ToString());
    }

    [Fact]
    public void RenderExpression_Renderer_ReturnsSql()
    {
      // Arrange
      DivideExpression divideExpression = new DivideExpression(NewExpressionList(2));

      const string expectedSql = "test";

      Mock<IRenderer> rendererMock = new Mock<IRenderer>();
      rendererMock
        .Setup(ca => ca.RenderExpression(It.IsAny<DivideExpression>(), It.IsAny<StringBuilder>()))
        .Callback((DivideExpression expression, StringBuilder sql) =>
        {
          sql.Append(expectedSql);
        });

      IRenderer renderer = rendererMock.Object;

      // Act
      string sql = divideExpression.RenderExpression(renderer);

      // Assert
      Assert.Equal(expectedSql, sql);
    }
  }
}
