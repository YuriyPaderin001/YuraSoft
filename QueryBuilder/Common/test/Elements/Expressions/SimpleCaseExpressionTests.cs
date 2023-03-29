using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Expressions
{
  public class SimpleCaseExpressionTests : TestsBase
  {
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    public void Constructor_ExpressionAndWhenThens_Success(int length)
    {
      // Act
      IExpression expression = NewExpression();
      List<Tuple<IExpression, IExpression>> whenThens = NewSimpleWhenThenList(length);
      SimpleCaseExpression simpleCaseExpression = new SimpleCaseExpression(expression, whenThens);

      // Assert
      Assert.Equal(expression, simpleCaseExpression.Expression);
      Assert.Equal(whenThens, simpleCaseExpression.WhenThens);
      Assert.Null(simpleCaseExpression.Else);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    public void Constructor_ExpressionAndWhenThensAndElse_Success(int length) =>
      Constructor_ExpressionAndWhenThensAndElse_Success_Base(expression: NewExpression(), whenThens: NewSimpleWhenThenList(length), @else: NewExpression());

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    public void Constructor_ExpressionAndOneWhenThensAndNullElse_Success(int length) =>
      Constructor_ExpressionAndWhenThensAndElse_Success_Base(expression: NewExpression(), whenThens: NewSimpleWhenThenList(length), @else: null);

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(3)]
    public void Constructor_NullExpressionWhenThens_ThrowsArgumentNullException(int length) =>
      Constructor_ExpressionAndWhenThens_ThrowsException<ArgumentNullException>(expression: null, NewSimpleWhenThenList(length));

    [Fact]
    public void Constructor_NullExpressionAndNullWhenThens_ThrowsArgumentNullException() =>
      Constructor_ExpressionAndWhenThens_ThrowsException<ArgumentNullException>(expression: null, whenThens: null);

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(3)]
    public void Constructor_NullExpressionAndOneWhenThenAndElse_ThrowsArgumentNullException(int length) =>
      Constructor_ExpressionAndWhenThensAndElse_ThrowsException<ArgumentNullException>(expression: null, whenThens: NewSimpleWhenThenList(length), @else: NewExpression());

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(3)]
    public void Constructor_NullExpressionAndOneWhenThenAndNullElse_ThrowsArgumentNullException(int length) =>
      Constructor_ExpressionAndWhenThensAndElse_ThrowsException<ArgumentNullException>(expression: null, whenThens: NewSimpleWhenThenList(length), @else: null);

    [Fact]
    public void Constructor_NullExpressionAndNullWhenThensAndElse_ThrowsArgumentNullException() =>
      Constructor_ExpressionAndWhenThensAndElse_ThrowsException<ArgumentNullException>(expression: null, whenThens: null, @else: NewExpression());

    [Fact]
    public void Constructor_NullExpressionAndNullWhenThensAndNullElse_ThrowsArgumentNullException() =>
      Constructor_ExpressionAndWhenThensAndElse_ThrowsException<ArgumentNullException>(expression: null, whenThens: null, @else: null);

    [Fact]
    public void Constructor_ExpressionAndEmptyWhenThens_ThrowsArgumentOutOfRangeException() =>
      Constructor_ExpressionAndWhenThens_ThrowsException<ArgumentOutOfRangeException>(expression: NewExpression(), whenThens: NewSimpleEmptyWhenThenList());

    [Fact]
    public void Constructor_ExpressionAndNullWhenThens_ThrowsArgumentNullException() =>
      Constructor_ExpressionAndWhenThens_ThrowsException<ArgumentNullException>(expression: NewExpression(), whenThens: null);

    [Fact]
    public void Constructor_ExpressionAndEmptyWhenThensAndElse_ThrowsArgumentOutOfRangeException() =>
      Constructor_ExpressionAndWhenThensAndElse_ThrowsException<ArgumentOutOfRangeException>(expression: NewExpression(), whenThens: NewSimpleEmptyWhenThenList(), @else: NewExpression());

    [Fact]
    public void Constructor_ExpressionAndEmptyWhenThensAndNullElse_ThrowsArgumentOutOfRangeException() =>
      Constructor_ExpressionAndWhenThensAndElse_ThrowsException<ArgumentOutOfRangeException>(expression: NewExpression(), whenThens: NewSimpleEmptyWhenThenList(), @else: null);

    [Fact]
    public void Constructor_ExpressionAndNullWhenThensAndElse_ThrowsArgumentNullException() =>
      Constructor_ExpressionAndWhenThensAndElse_ThrowsException<ArgumentNullException>(expression: NewExpression(), whenThens: null, @else: NewExpression());

    [Fact]
    public void Constructor_ExpressionAndNullWhenThensAndNullElse_ThrowsArgumentNullException() =>
      Constructor_ExpressionAndWhenThensAndElse_ThrowsException<ArgumentNullException>(expression: NewExpression(), whenThens: null, @else: null);

    [Fact]
    public void SetExpression_Expression_Success()
    {
      // Arrange
      SimpleCaseExpression simpleCaseExpression = new SimpleCaseExpression(NewExpression(), NewSimpleWhenThenList(1));

      IExpression expression = NewExpression();

      // Act
      simpleCaseExpression.Expression = expression;

      // Assert
      Assert.Equal(expression, simpleCaseExpression.Expression);
    }

    [Fact]
    public void SetExpression_Null_Success()
    {
      // Arrange
      SimpleCaseExpression simpleCaseExpression = new SimpleCaseExpression(NewExpression(), NewSimpleWhenThenList(1));

      // Act & Assert
      Assert.Throws<ArgumentNullException>(() => simpleCaseExpression.Expression = null!);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    public void SetWhenThens_OneWhenThen_Success(int length)
    {
      // Arrange
      SimpleCaseExpression simpleCaseExpression = new SimpleCaseExpression(NewExpression(), NewSimpleWhenThenList(1));
      List<Tuple<IExpression, IExpression>> whenThens = NewSimpleWhenThenList(length);

      // Act
      simpleCaseExpression.WhenThens = whenThens;

      // Assert
      Assert.Equal(whenThens, simpleCaseExpression.WhenThens);
    }

    [Fact]
    public void SetWhenThens_EmptyWhenThens_ThrowsArgumentOutOfRangeException() =>
      SetWhenThens_ThrowsException<ArgumentOutOfRangeException>(NewSimpleEmptyWhenThenList());

    [Fact]
    public void SetWhenThens_NullWhenThens_ThrowsArgumentNullException() =>
      SetWhenThens_ThrowsException<ArgumentNullException>(whenThens: null);

    [Fact]
    public void SetElse_Expression_Success()
    {
      // Arrange
      SimpleCaseExpression simpleCaseExpression = new SimpleCaseExpression(NewExpression(), NewSimpleWhenThenList(1));
      IExpression @else = NewExpression();

      // Act
      simpleCaseExpression.Else = @else;

      // Assert
      Assert.Equal(@else, simpleCaseExpression.Else);
    }

    [Fact]
    public void SetElse_Null_Success()
    {
      // Arrange
      SimpleCaseExpression simpleCaseExpression = new SimpleCaseExpression(NewExpression(), NewSimpleWhenThenList(1));

      // Act
      simpleCaseExpression.Else = null;

      // Assert
      Assert.Null(simpleCaseExpression.Else);
    }

    [Fact]
    public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
    {
      // Arrange
      SimpleCaseExpression simpleCaseExpression = new SimpleCaseExpression(NewExpression(), NewSimpleWhenThenList(1), NewExpression());

      const string expectedSql = "test";

      Mock<IRenderer> rendererMock = new Mock<IRenderer>();
      rendererMock
        .Setup(ca => ca.RenderExpression(It.IsAny<SimpleCaseExpression>(), It.IsAny<StringBuilder>()))
        .Callback((SimpleCaseExpression expression, StringBuilder sql) =>
        {
          sql.Append(expectedSql);
        });

      IRenderer renderer = rendererMock.Object;
      StringBuilder sql = new StringBuilder();

      // Act
      simpleCaseExpression.RenderExpression(renderer, sql);

      // Assert
      Assert.NotNull(sql);
      Assert.Equal(expectedSql, sql.ToString());
    }

    [Fact]
    public void RenderExpression_Renderer_ReturnsSql()
    {
      // Arrange
      SimpleCaseExpression simpleCaseExpression = new SimpleCaseExpression(NewExpression(), NewSimpleWhenThenList(1), NewExpression());

      const string expectedSql = "test";

      Mock<IRenderer> rendererMock = new Mock<IRenderer>();
      rendererMock
        .Setup(ca => ca.RenderExpression(It.IsAny<SimpleCaseExpression>(), It.IsAny<StringBuilder>()))
        .Callback((SimpleCaseExpression expression, StringBuilder sql) =>
        {
          sql.Append(expectedSql);
        });

      IRenderer renderer = rendererMock.Object;

      // Act
      string sql = simpleCaseExpression.RenderExpression(renderer);

      // Assert
      Assert.Equal(expectedSql, sql);
    }

    private void Constructor_ExpressionAndWhenThens_ThrowsException<TException>(IExpression? expression,
      IEnumerable<Tuple<IExpression, IExpression>>? whenThens) where TException : Exception
    {
      // Act & Assert
      Assert.Throws<TException>(() => new SimpleCaseExpression(expression!, whenThens!));
    }

    private void Constructor_ExpressionAndWhenThensAndElse_Success_Base(IExpression expression, IEnumerable<Tuple<IExpression, IExpression>> whenThens, IExpression? @else)
    {
      // Act
      SimpleCaseExpression simpleCaseExpression = new SimpleCaseExpression(expression, whenThens, @else);

      // Assert
      Assert.Equal(expression, simpleCaseExpression.Expression);
      Assert.Equal(whenThens, simpleCaseExpression.WhenThens);

      if (@else == null)
      {
        Assert.Null(simpleCaseExpression.Else);
      }
      else
      {
        Assert.Equal(@else, simpleCaseExpression.Else);
      }
    }

    private void Constructor_ExpressionAndWhenThensAndElse_ThrowsException<TException>(IExpression? expression,
      IEnumerable<Tuple<IExpression, IExpression>>? whenThens, IExpression? @else) where TException : Exception
    {
      // Act & Assert
      Assert.Throws<TException>(() => new SimpleCaseExpression(expression!, whenThens!, @else!));
    }

    private void SetWhenThens_ThrowsException<TException>(IEnumerable<Tuple<IExpression, IExpression>>? whenThens) where TException : Exception
    {
      // Arrange
      SimpleCaseExpression simpleCaseExpression = new SimpleCaseExpression(NewExpression(), NewSimpleWhenThenList(1));
      List<Tuple<IExpression, IExpression>> whenThensList = whenThens == null ? null! : new List<Tuple<IExpression, IExpression>>(whenThens);

      // Act & Assert
      Assert.Throws<TException>(() => simpleCaseExpression.WhenThens = whenThensList);
    }
  }
}
