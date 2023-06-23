using System;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Functions
{
	public class RoundFunctionTests : TestsBase
	{
		[Fact]
		public void Constructor_Expression_Success()
		{
			// Arrange
			IExpression expression = NewExpression();

			// Act
			RoundFunction function = new RoundFunction(expression);

			// Assert
			Assert.Equal(expression, function.Expression);
			Assert.Null(function.Precision);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(3)]
		public void Constructor_ExpressionAndPrecision_Success(int? precision)
		{
			// Arrange
			IExpression expression = NewExpression();

			// Act
			RoundFunction function = new RoundFunction(expression, precision);

            // Assert
            Assert.Equal(expression, function.Expression);

			if (precision.HasValue)
			{
				Assert.Equal(precision.Value, function.Precision);
			}
			else
			{
				Assert.Null(function.Precision);
			}
		}

		[Fact]
		public void Constructor_NullExpression_ThrowsArgumentNullException() =>
			Assert.Throws<ArgumentNullException>(() => new RoundFunction(expression: null!));

		[Theory]
		[InlineData(null)]
		[InlineData(3)]
		public void Constructor_NullExpressionAndPrecision_ThrowsArgumentNullException(int? precision) => 
			Assert.Throws<ArgumentNullException>(() => new RoundFunction(expression: null!, precision));

		[Fact]
		public void RenderFunction_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			RoundFunction function = NewRoundFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<RoundFunction>(), It.IsAny<StringBuilder>())).Callback((RoundFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			function.RenderFunction(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderFunction_Renderer_ReturnsSql()
		{
			// Arrange
			RoundFunction function = NewRoundFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<RoundFunction>(), It.IsAny<StringBuilder>())).Callback((RoundFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = function.RenderFunction(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			RoundFunction function = NewRoundFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<RoundFunction>(), It.IsAny<StringBuilder>())).Callback((RoundFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			function.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			RoundFunction function = NewRoundFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<RoundFunction>(), It.IsAny<StringBuilder>())).Callback((RoundFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = function.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private RoundFunction NewRoundFunction(IExpression? expression = null, int? precision = null) => 
			new RoundFunction(expression ?? NewExpression(), precision ?? 3);
	}
}
