using System;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Functions
{
	public class CountFunctionTests : TestsBase
	{
		[Fact]
		public void Constructor_Expression_Success()
		{
			// Arrange
			IExpression expression = NewExpression();

			// Act
			CountFunction countFunction = new CountFunction(expression);

			// Assert
			Assert.Equal(expression, countFunction.Expression);
		}

		[Fact]
		public void Constructor_NullExpression_ThrowsArgumentNullException()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new CountFunction(expression: null!));
		}

		[Fact]
		public void RenderFunction_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			CountFunction countFunction = NewCountFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<CountFunction>(), It.IsAny<StringBuilder>())).Callback((CountFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			countFunction.RenderFunction(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderFunction_Renderer_ReturnsSql()
		{
			// Arrange
			CountFunction countFunction = NewCountFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<CountFunction>(), It.IsAny<StringBuilder>())).Callback((CountFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = countFunction.RenderFunction(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			CountFunction countFunction = NewCountFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<CountFunction>(), It.IsAny<StringBuilder>())).Callback((CountFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			countFunction.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			CountFunction countFunction = NewCountFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<CountFunction>(), It.IsAny<StringBuilder>())).Callback((CountFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = countFunction.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private CountFunction NewCountFunction(IExpression? expression = null) => new CountFunction(expression ?? NewExpression());
	}
}
