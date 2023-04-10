using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Values
{
	public class Int16ValueTests
	{
		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(1)]
		public void Constructor_Value_Success(short value)
		{
			// Act
			Int16Value int16Value = new Int16Value(value);

			// Assert
			Assert.Equal(value, int16Value.Data);
		}

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(1)]
		public void ImplicitOperatorInt16Value_String_ReturnsInt16Value(short value)
		{
			// Act
			Int16Value int16Value = value;

			// Assert
			Assert.Equal(value, int16Value.Data);
		}

		[Theory]
		[InlineData(-3)]
		[InlineData(0)]
		[InlineData(1)]
		public void SetData_Short_Success(short value)
		{
			// Arrange
			Int16Value int16Value = new Int16Value(-9);

			// Act
			int16Value.Data = value;

			// Assert
			Assert.Equal(value, int16Value.Data);
		}

		[Fact]
		public void RenderValue_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			Int16Value int16Value = new Int16Value(123);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<Int16Value>(), It.IsAny<StringBuilder>())).Callback((Int16Value value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			int16Value.RenderValue(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderValue_Renderer_ReturnsSql()
		{
			// Arrange
			Int16Value int16Value = new Int16Value(123);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<Int16Value>(), It.IsAny<StringBuilder>())).Callback((Int16Value value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = int16Value.RenderValue(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			Int16Value int16Value = new Int16Value(123);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<Int16Value>(), It.IsAny<StringBuilder>())).Callback((Int16Value value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			int16Value.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			Int16Value int16Value = new Int16Value(123);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<Int16Value>(), It.IsAny<StringBuilder>())).Callback((Int16Value value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = int16Value.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}
	}
}
