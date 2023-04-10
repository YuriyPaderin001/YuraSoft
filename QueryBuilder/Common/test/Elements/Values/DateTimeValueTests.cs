using System;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Values
{
	public class DateTImeValueTests
	{
		[Fact]
		public void Constructor_Value_Success()
		{
			// Arrange
			DateTime value = new DateTime(2022, 1, 1);

			// Act
			DateTimeValue dateTimeValue = new DateTimeValue(value);

			// Assert
			Assert.Equal(value, dateTimeValue.Data);
			Assert.Equal("o", dateTimeValue.Format);
		}

		[Theory]
		[InlineData("o")]
		[InlineData("F")]
		[InlineData("G")]
		public void Constructor_ValueAndFormat_Success(string format)
		{
			// Arrange
			DateTime value = new DateTime(2022, 1, 1);

			// Act
			DateTimeValue dateTimeValue = new DateTimeValue(value, format);

			// Assert
			Assert.Equal(value, dateTimeValue.Data);
			Assert.Equal(format, dateTimeValue.Format);
		}

		[Fact]
		public void Constructor_ValueAndNullFormat_Success()
		{
			// Arrange
			DateTime value = new DateTime(2022, 1, 1);

			// Act
			DateTimeValue dateTimeValue = new DateTimeValue(value, format: null);

			// Assert
			Assert.Equal(value, dateTimeValue.Data);
			Assert.Equal("o", dateTimeValue.Format);
		}

		[Fact]
		public void ImplicitOperatorDateTimeValue_Value_ReturnsDateTimeValue()
		{
			// Arrange
			DateTime value = new DateTime(2022, 1, 1);

			// Act
			DateTimeValue dateTimeValue = value;

			// Assert
			Assert.Equal(value, dateTimeValue.Data);
		}

		[Fact]
		public void SetData_DateTime_Success()
		{
			// Arrange
			DateTimeValue dateTimeValue = new DateTimeValue(new DateTime(2022, 1, 1));
			DateTime value = new DateTime(2023, 11, 3);

			// Act
			dateTimeValue.Data = value;

			// Assert
			Assert.Equal(value, dateTimeValue.Data);
			Assert.Equal("o", dateTimeValue.Format);
		}

		[Theory]
		[InlineData("o")]
		[InlineData("F")]
		[InlineData("G")]
		public void SetFormat_String_Success(string format)
		{
			// Arrange
			DateTimeValue dateTimeValue = new DateTimeValue(new DateTime(2022, 1, 1));

			// Act
			dateTimeValue.Format = format;

			// Assert
			Assert.Equal(format, dateTimeValue.Format);
		}

		[Fact]
		public void SetFormat_Null_SetDefaultFormat()
		{
			// Arrange
			DateTimeValue dateTimeValue = new DateTimeValue(new DateTime(2022, 1, 1), format: "F");

			// Act
			dateTimeValue.Format = null!;

			// Assert
			Assert.Equal("o", dateTimeValue.Format);
		}

		[Fact]
		public void RenderValue_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			DateTimeValue dateTimeValue = new DateTimeValue(new DateTime(2022, 1, 1));

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<DateTimeValue>(), It.IsAny<StringBuilder>())).Callback((DateTimeValue value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			dateTimeValue.RenderValue(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderValue_Renderer_ReturnsSql()
		{
			// Arrange
			DateTimeValue dateTimeValue = new DateTimeValue(new DateTime(2022, 1, 1));

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<DateTimeValue>(), It.IsAny<StringBuilder>())).Callback((DateTimeValue value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = dateTimeValue.RenderValue(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			DateTimeValue dateTimeValue = new DateTimeValue(new DateTime(2022, 1, 1));

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<DateTimeValue>(), It.IsAny<StringBuilder>())).Callback((DateTimeValue value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			dateTimeValue.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			DateTimeValue dateTimeValue = new DateTimeValue(new DateTime(2022, 1, 1));

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderValue(It.IsAny<DateTimeValue>(), It.IsAny<StringBuilder>())).Callback((DateTimeValue value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = dateTimeValue.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}
	}
}
