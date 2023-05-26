using System;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Values
{
	public class StringValueTests
	{
		[Theory]
		[InlineData("")]
		[InlineData("test")]
		public void Constructor_Value_Success(string value)
		{
			// Act
			StringValue stringValue = new StringValue(value);

			// Assert
			Assert.Equal(value, stringValue.Data);
		}

		[Fact]
		public void Constructor_NullValue_ThrowsArgumentNullException()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new StringValue(value: null!));
		}

		[Theory]
		[InlineData("")]
		[InlineData("test")]
		public void ImplicitOperatorStringValue_Value_ReturnsStringValue(string value)
		{
			// Act
			StringValue stringValue = value;

			// Assert
			Assert.Equal(value, stringValue.Data);
		}

		[Fact]
		public void ImplicitOperatorStringValue_NullValue_ThrowsArgumentNullException()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => { StringValue stringValue = (string)null!; });
		}

		[Fact]
		public void RenderValue_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			StringValue stringValue = new StringValue("value");

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<StringValue>(), It.IsAny<StringBuilder>())).Callback((StringValue value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			stringValue.RenderValue(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderValue_Renderer_ReturnsSql()
		{
			// Arrange
			StringValue stringValue = new StringValue("value");

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<StringValue>(), It.IsAny<StringBuilder>())).Callback((StringValue value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = stringValue.RenderValue(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			StringValue stringValue = new StringValue("value");

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<StringValue>(), It.IsAny<StringBuilder>())).Callback((StringValue value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			stringValue.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			StringValue stringValue = new StringValue("value");

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<StringValue>(), It.IsAny<StringBuilder>())).Callback((StringValue value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = stringValue.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}
	}
}
