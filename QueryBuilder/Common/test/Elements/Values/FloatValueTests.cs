using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Values
{
	public class FloatValueTests
	{
		[Theory]
		[InlineData(-3.23)]
		[InlineData(0)]
		[InlineData(0.23)]
		[InlineData(1.23)]
		public void Constructor_Value_Success(float value)
		{
			// Act
			FloatValue floatValue = new FloatValue(value);

			// Assert
			Assert.Equal(value, floatValue.Data);
		}

		[Theory]
		[InlineData(-3.23)]
		[InlineData(0)]
		[InlineData(0.23)]
		[InlineData(1.23)]
		public void ImplicitOperatorFloatValue_String_ReturnsFloatValue(float value)
		{
			// Act
			FloatValue floatValue = value;

			// Assert
			Assert.Equal(value, floatValue.Data);
		}

		[Theory]
		[InlineData(-3.23)]
		[InlineData(0)]
		[InlineData(0.23)]
		[InlineData(1.23)]
		public void SetData_Float_Success(float value)
		{
			// Arrange
			FloatValue floatValue = new FloatValue(-9);

			// Act
			floatValue.Data = value;

			// Assert
			Assert.Equal(value, floatValue.Data);
		}

		[Fact]
		public void RenderValue_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			FloatValue floatValue = new FloatValue(4.32f);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<FloatValue>(), It.IsAny<StringBuilder>())).Callback((FloatValue value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			floatValue.RenderValue(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderValue_Renderer_ReturnsSql()
		{
			// Arrange
			FloatValue floatValue = new FloatValue(4.32f);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<FloatValue>(), It.IsAny<StringBuilder>())).Callback((FloatValue value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = floatValue.RenderValue(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			FloatValue floatValue = new FloatValue(4.32f);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<FloatValue>(), It.IsAny<StringBuilder>())).Callback((FloatValue value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			floatValue.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			FloatValue floatValue = new FloatValue(4.32f);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<FloatValue>(), It.IsAny<StringBuilder>())).Callback((FloatValue value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = floatValue.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}
	}
}
