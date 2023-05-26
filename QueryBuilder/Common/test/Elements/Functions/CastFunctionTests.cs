using System;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Functions
{
	public class CastFunctionTests : TestsBase
	{
		[Fact]
		public void Constructor_ExpressionAndType_Success()
		{
			// Arrange
			IExpression expression = NewExpression();
			string type = "test_type";

			// Act
			CastFunction castFunction = new CastFunction(expression, type);

			// Assert
			Assert.Equal(expression, castFunction.Expression);
			Assert.Equal(type, castFunction.Type);
		}

		[Fact]
		public void Constructor_NullExpressionAndType_ThrowsArgumentNullException() =>
			Constructor_ExpressionAndType_ThrowsException<ArgumentNullException>(expression: null, "test_type");

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Constructor_ExpressionAndNullOrEmptyType_ThrowsArgumentException(string? type) =>
			Constructor_ExpressionAndType_ThrowsException<ArgumentException>(expression: NewExpression(), type);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Constructor_NullExpressionAndNullOrEmptyType_ThrowsArgumentNullException(string? type) =>
			Constructor_ExpressionAndType_ThrowsException<ArgumentNullException>(expression: null, type);

		[Fact]
		public void RenderFunction_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			CastFunction castFunction = NewCastFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<CastFunction>(), It.IsAny<StringBuilder>())).Callback((CastFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			castFunction.RenderFunction(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderFunction_Renderer_ReturnsSql()
		{
			// Arrange
			CastFunction castFunction = NewCastFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<CastFunction>(), It.IsAny<StringBuilder>())).Callback((CastFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = castFunction.RenderFunction(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			CastFunction castFunction = NewCastFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<CastFunction>(), It.IsAny<StringBuilder>())).Callback((CastFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			castFunction.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			CastFunction castFunction = NewCastFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<CastFunction>(), It.IsAny<StringBuilder>())).Callback((CastFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = castFunction.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_ExpressionAndType_ThrowsException<TException>(IExpression? expression, string? type) where TException: Exception
		{
			// Act & Assert
			Assert.Throws<TException>(() => new CastFunction(expression!, type!));
		}

		private CastFunction NewCastFunction(IExpression? expression = null, string? type = null) => new CastFunction(expression ?? NewExpression(), type ?? "test_type");
	}
}
