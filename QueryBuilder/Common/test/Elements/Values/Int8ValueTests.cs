using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Values
{
	public class Int8ValueTests
	{
		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(1)]
		public void Constructor_Value_Success(sbyte value)
		{
			// Act
			Int8Value int8Value = new Int8Value(value);

			// Assert
			Assert.Equal(value, int8Value.Data);
		}

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(1)]
		public void ImplicitOperatorInt8Value_String_ReturnsInt8Value(sbyte value)
		{
			// Act
			Int8Value int8Value = value;

			// Assert
			Assert.Equal(value, int8Value.Data);
		}

		[Fact]
		public void RenderValue_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			Int8Value int8Value = new Int8Value(123);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<Int8Value>(), It.IsAny<StringBuilder>())).Callback((Int8Value value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			int8Value.RenderValue(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderValue_Renderer_ReturnsSql()
		{
			// Arrange
			Int8Value int8Value = new Int8Value(123);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<Int8Value>(), It.IsAny<StringBuilder>())).Callback((Int8Value value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = int8Value.RenderValue(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			Int8Value int8Value = new Int8Value(123);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<Int8Value>(), It.IsAny<StringBuilder>())).Callback((Int8Value value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			int8Value.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			Int8Value int8Value = new Int8Value(123);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<Int8Value>(), It.IsAny<StringBuilder>())).Callback((Int8Value value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = int8Value.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}
	}
}
