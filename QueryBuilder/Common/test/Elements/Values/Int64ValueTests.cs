using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Values
{
	public class Int64ValueTests
	{
		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(1)]
		public void Constructor_Value_Success(long value)
		{
			// Act
			Int64Value int64Value = new Int64Value(value);

			// Assert
			Assert.Equal(value, int64Value.Data);
		}

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(1)]
		public void ImplicitOperatorInt64Value_String_ReturnsInt64Value(long value)
		{
			// Act
			Int64Value int64Value = value;

			// Assert
			Assert.Equal(value, int64Value.Data);
		}

		[Fact]
		public void RenderValue_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			Int64Value int64Value = new Int64Value(123);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<Int64Value>(), It.IsAny<StringBuilder>())).Callback((Int64Value value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			int64Value.RenderValue(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderValue_Renderer_ReturnsSql()
		{
			// Arrange
			Int64Value int64Value = new Int64Value(123);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<Int64Value>(), It.IsAny<StringBuilder>())).Callback((Int64Value value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = int64Value.RenderValue(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			Int64Value int64Value = new Int64Value(123);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<Int64Value>(), It.IsAny<StringBuilder>())).Callback((Int64Value value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			int64Value.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			Int64Value int64Value = new Int64Value(123);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<Int64Value>(), It.IsAny<StringBuilder>())).Callback((Int64Value value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = int64Value.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}
	}
}
