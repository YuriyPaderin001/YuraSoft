using System;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Functions
{
	public class ExtractFunctionTests : TestsBase
	{
		[Fact]
		public void Constructor_ExpressionAndType_Success()
		{
			// Arrange
			string part = "month";
			IExpression expression = NewExpression();

			// Act
			ExtractFunction ExtractFunction = new ExtractFunction(part, expression);

            // Assert
            Assert.Equal(part, ExtractFunction.Part);
            Assert.Equal(expression, ExtractFunction.Expression);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Constructor_NullOrEmptyPartAndExpression_ThrowsArgumentException(string? part) =>
			Constructor_PartAndExpression_ThrowsException<ArgumentException>(part, NewExpression());

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Constructor_NullOrEmptyPartAndNullExpression_ThrowsArgumentNullException(string? part) =>
            Constructor_PartAndExpression_ThrowsException<ArgumentNullException>(part, expression: null);

		[Fact]
		public void Constructor_PartAndNullExpression_ThrowsArgumentNullException() =>
            Constructor_PartAndExpression_ThrowsException<ArgumentNullException>(part: "month", expression: null);

		[Fact]
		public void RenderFunction_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			ExtractFunction ExtractFunction = NewExtractFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<ExtractFunction>(), It.IsAny<StringBuilder>())).Callback((ExtractFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			ExtractFunction.RenderFunction(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderFunction_Renderer_ReturnsSql()
		{
			// Arrange
			ExtractFunction ExtractFunction = NewExtractFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<ExtractFunction>(), It.IsAny<StringBuilder>())).Callback((ExtractFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = ExtractFunction.RenderFunction(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			ExtractFunction ExtractFunction = NewExtractFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<ExtractFunction>(), It.IsAny<StringBuilder>())).Callback((ExtractFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			ExtractFunction.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			ExtractFunction ExtractFunction = NewExtractFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<ExtractFunction>(), It.IsAny<StringBuilder>())).Callback((ExtractFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = ExtractFunction.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_PartAndExpression_ThrowsException<TException>(string? part, IExpression? expression) where TException: Exception
		{
			// Act & Assert
			Assert.Throws<TException>(() => new ExtractFunction(part!, expression!));
		}

		private ExtractFunction NewExtractFunction(string? part = null, IExpression? expression = null) => 
			new ExtractFunction(part ?? "month", expression ?? NewExpression());
	}
}
