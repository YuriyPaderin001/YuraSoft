using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Values
{
  public class NullValueTests
  {
    [Fact]
    public void RenderValue_RendererAndStringBuilder_WritesSqlToStringBuilder()
    {
      // Arrange
      NullValue nullValue = new NullValue();

      const string expectedSql = "test";

      Mock<IRenderer> rendererMock = new Mock<IRenderer>();
      rendererMock.Setup(ca => ca.RenderValue(It.IsAny<NullValue>(), It.IsAny<StringBuilder>())).Callback((NullValue value, StringBuilder sql) =>
      {
        sql.Append(expectedSql);
      });

      IRenderer renderer = rendererMock.Object;
      StringBuilder sql = new StringBuilder();

      // Act
      nullValue.RenderValue(renderer, sql);

      // Assert
      Assert.Equal(expectedSql, sql.ToString());
    }

    [Fact]
    public void RenderValue_Renderer_ReturnsSql()
    {
      // Arrange
      NullValue nullValue = new NullValue();

      const string expectedSql = "test";

      Mock<IRenderer> rendererMock = new Mock<IRenderer>();
      rendererMock.Setup(ca => ca.RenderValue(It.IsAny<NullValue>(), It.IsAny<StringBuilder>())).Callback((NullValue value, StringBuilder sql) =>
      {
        sql.Append(expectedSql);
      });

      IRenderer renderer = rendererMock.Object;

      // Act
      string sql = nullValue.RenderValue(renderer);

      // Assert
      Assert.Equal(expectedSql, sql);
    }

    [Fact]
    public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
    {
      // Arrange
      NullValue nullValue = new NullValue();

      const string expectedSql = "test";

      Mock<IRenderer> rendererMock = new Mock<IRenderer>();
      rendererMock.Setup(ca => ca.RenderValue(It.IsAny<NullValue>(), It.IsAny<StringBuilder>())).Callback((NullValue value, StringBuilder sql) =>
      {
        sql.Append(expectedSql);
      });

      IRenderer renderer = rendererMock.Object;
      StringBuilder sql = new StringBuilder();

      // Act
      nullValue.RenderExpression(renderer, sql);

      // Assert
      Assert.Equal(expectedSql, sql.ToString());
    }

    [Fact]
    public void RenderExpression_Renderer_ReturnsSql()
    {
      // Arrange
      NullValue nullValue = new NullValue();

      const string expectedSql = "test";

      Mock<IRenderer> rendererMock = new Mock<IRenderer>();
      rendererMock.Setup(ca => ca.RenderValue(It.IsAny<NullValue>(), It.IsAny<StringBuilder>())).Callback((NullValue value, StringBuilder sql) =>
      {
        sql.Append(expectedSql);
      });

      IRenderer renderer = rendererMock.Object;

      // Act
      string sql = nullValue.RenderExpression(renderer);

      // Assert
      Assert.Equal(expectedSql, sql);
    }
  }
}
