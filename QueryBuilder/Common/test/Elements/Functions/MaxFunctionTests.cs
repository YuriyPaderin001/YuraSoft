using System;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Functions
{
	public class MaxFunctionTests : TestsBase
	{
		[Fact]
		public void Constructor_Expression_Success()
		{
			// Arrange
			IExpression expression = NewExpression();

			// Act
			MaxFunction maxFunction = new MaxFunction(expression);

			// Assert
			Assert.Equal(expression, maxFunction.Expression);
		}

		[Fact]
		public void Constructor_NullExpression_ThrowsArgumentNullException()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new MaxFunction(expression: null!));
		}

		[Fact]
		public void RenderFunction_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			MaxFunction maxFunction = NewMaxFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<MaxFunction>(), It.IsAny<StringBuilder>())).Callback((MaxFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			maxFunction.RenderFunction(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderFunction_Renderer_ReturnsSql()
		{
			// Arrange
			MaxFunction maxFunction = NewMaxFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<MaxFunction>(), It.IsAny<StringBuilder>())).Callback((MaxFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = maxFunction.RenderFunction(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			MaxFunction maxFunction = NewMaxFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<MaxFunction>(), It.IsAny<StringBuilder>())).Callback((MaxFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			maxFunction.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			MaxFunction maxFunction = NewMaxFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<MaxFunction>(), It.IsAny<StringBuilder>())).Callback((MaxFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = maxFunction.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private MaxFunction NewMaxFunction(IExpression? expression = null) => new MaxFunction(expression ?? NewExpression());
	}
}
