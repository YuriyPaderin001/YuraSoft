using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Values
{
	public class DecimalValueTests
	{
		[Theory]
		[InlineData(-3.23)]
		[InlineData(0)]
		[InlineData(0.23)]
		[InlineData(1.23)]
		public void Constructor_Value_Success(decimal value)
		{
			// Act
			DecimalValue decimalValue = new DecimalValue(value);

			// Assert
			Assert.Equal(value, decimalValue.Data);
		}

		[Theory]
		[InlineData(-3.23)]
		[InlineData(0)]
		[InlineData(0.23)]
		[InlineData(1.23)]
		public void ImplicitOperatorDecimalValue_Value_ReturnsDecimalValue(decimal value)
		{
			// Act
			DecimalValue decimalValue = value;

			// Assert
			Assert.Equal(value, decimalValue.Data);
		}

		[Theory]
		[InlineData(-3.23)]
		[InlineData(0)]
		[InlineData(0.23)]
		[InlineData(1.23)]
		public void SetData_Decimal_Success(decimal value)
		{
			// Arrange
			DecimalValue decimalValue = new DecimalValue(-9);

			// Act
			decimalValue.Data = value;

			// Assert
			Assert.Equal(value, decimalValue.Data);
		}

		[Fact]
		public void RenderValue_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			DecimalValue decimalValue = new DecimalValue(4.32m);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<DecimalValue>(), It.IsAny<StringBuilder>())).Callback((DecimalValue value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			decimalValue.RenderValue(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderValue_Renderer_ReturnsSql()
		{
			// Arrange
			DecimalValue decimalValue = new DecimalValue(4.32m);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<DecimalValue>(), It.IsAny<StringBuilder>())).Callback((DecimalValue value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = decimalValue.RenderValue(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			DecimalValue decimalValue = new DecimalValue(4.32m);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<DecimalValue>(), It.IsAny<StringBuilder>())).Callback((DecimalValue value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			decimalValue.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			DecimalValue decimalValue = new DecimalValue(4.32m);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<DecimalValue>(), It.IsAny<StringBuilder>())).Callback((DecimalValue value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = decimalValue.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}
	}
}
