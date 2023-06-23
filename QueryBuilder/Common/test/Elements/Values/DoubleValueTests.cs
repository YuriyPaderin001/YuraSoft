using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Values
{
	public class DoubleValueTests
	{
		[Theory]
		[InlineData(-3.23)]
		[InlineData(0)]
		[InlineData(0.23)]
		[InlineData(1.23)]
		public void Constructor_Value_Success(double value)
		{
			// Act
			DoubleValue doubleValue = new DoubleValue(value);

			// Assert
			Assert.Equal(value, doubleValue.Data);
		}

		[Theory]
		[InlineData(-3.23)]
		[InlineData(0)]
		[InlineData(0.23)]
		[InlineData(1.23)]
		public void ImplicitOperatorDoubleValue_String_ReturnsDoubleValue(double value)
		{
			// Act
			DoubleValue doubleValue = value;

			// Assert
			Assert.Equal(value, doubleValue.Data);
		}

		[Fact]
		public void RenderValue_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			DoubleValue doubleValue = new DoubleValue(4.32d);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<DoubleValue>(), It.IsAny<StringBuilder>())).Callback((DoubleValue value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			doubleValue.RenderValue(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderValue_Renderer_ReturnsSql()
		{
			// Arrange
			DoubleValue doubleValue = new DoubleValue(4.32d);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<DoubleValue>(), It.IsAny<StringBuilder>())).Callback((DoubleValue value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = doubleValue.RenderValue(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			DoubleValue doubleValue = new DoubleValue(4.32d);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<DoubleValue>(), It.IsAny<StringBuilder>())).Callback((DoubleValue value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			doubleValue.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			DoubleValue doubleValue = new DoubleValue(4.32d);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<DoubleValue>(), It.IsAny<StringBuilder>())).Callback((DoubleValue value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = doubleValue.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}
	}
}
