using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Values
{
	public class Int32ValueTests
	{
		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(1)]
		public void Constructor_Value_Success(int value)
		{
			// Act
			Int32Value int32Value = new Int32Value(value);

			// Assert
			Assert.Equal(value, int32Value.Data);
		}

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(1)]
		public void ImplicitOperatorInt32Value_String_ReturnsInt32Value(int value)
		{
			// Act
			Int32Value int32Value = value;

			// Assert
			Assert.Equal(value, int32Value.Data);
		}

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(1)]
		public void SetData_Int_Success(int value)
		{
			// Arrange
			Int32Value int32Value = new Int32Value(-9);

			// Act
			int32Value.Data = value;

			// Assert
			Assert.Equal(value, int32Value.Data);
		}

		[Fact]
		public void RenderValue_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			Int32Value int32Value = new Int32Value(123);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<Int32Value>(), It.IsAny<StringBuilder>())).Callback((Int32Value value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			int32Value.RenderValue(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderValue_Renderer_ReturnsSql()
		{
			// Arrange
			Int32Value int32Value = new Int32Value(123);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<Int32Value>(), It.IsAny<StringBuilder>())).Callback((Int32Value value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = int32Value.RenderValue(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			Int32Value int32Value = new Int32Value(123);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<Int32Value>(), It.IsAny<StringBuilder>())).Callback((Int32Value value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			int32Value.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			Int32Value int32Value = new Int32Value(123);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<Int32Value>(), It.IsAny<StringBuilder>())).Callback((Int32Value value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = int32Value.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}
	}
}
