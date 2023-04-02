using System;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Functions
{
	public class CoalesceFunctionTests : TestsBase
	{
		[Fact]
		public void Constructor_ExpressionAndType_Success()
		{
			// Arrange
			IExpression expression = NewExpression();
			IExpression defaultExpression = NewExpression();

			// Act
			CoalesceFunction coalesceFunction = new CoalesceFunction(expression, defaultExpression);

			// Assert
			Assert.Equal(expression, coalesceFunction.Expression);
			Assert.Equal(defaultExpression, coalesceFunction.DefaultExpression);
		}

		[Fact]
		public void Constructor_NullExpressionAndDefaultExpression_ThrowsArgumentNullException() =>
			Constructor_ExpressionAndDefaultExpression_ThrowsException<ArgumentNullException>(expression: null, defaultExpression: NewExpression());

		[Fact]
		public void Constructor_NullExpressionAndNullDefaultExpression_ThrowsArgumentNullException() =>
			Constructor_ExpressionAndDefaultExpression_ThrowsException<ArgumentNullException>(expression: null, defaultExpression: null);

		[Fact]
		public void Constructor_ExpressionAndNullDefaultExpression_ThrowsArgumentNullExpression() =>
			Constructor_ExpressionAndDefaultExpression_ThrowsException<ArgumentNullException>(expression: NewExpression(), defaultExpression: null);

		[Fact]
		public void SetExpression_Expression_Success()
		{
			// Arrange
			CoalesceFunction coalesceFunction = NewCoalesceFunction();
			IExpression expression = NewExpression();

			// Act
			coalesceFunction.Expression = expression;

			// Assert
			Assert.Equal(expression, coalesceFunction.Expression);
		}

		[Fact]
		public void SetExpression_NullExpression_ThrowsArgumentNullException()
		{
			// Arrange
			CoalesceFunction coalesceFunction = NewCoalesceFunction();

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => coalesceFunction.Expression = null!);
		}

		[Fact]
		public void SetDefaultExpression_Expression_Success()
		{
			// Arrange
			CoalesceFunction coalesceFunction = NewCoalesceFunction();
			IExpression expression = NewExpression();

			// Act
			coalesceFunction.DefaultExpression = expression;

			// Assert
			Assert.Equal(expression, coalesceFunction.DefaultExpression);
		}

		[Fact]
		public void SetDefaultExpression_NullExpression_ThrowsArgumentNullException()
		{
			// Arrange
			CoalesceFunction coalesceFunction = NewCoalesceFunction();

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => coalesceFunction.DefaultExpression = null!);
		}

		[Fact]
		public void RenderFunction_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			CoalesceFunction coalesceFunction = NewCoalesceFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<CoalesceFunction>(), It.IsAny<StringBuilder>())).Callback((CoalesceFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			coalesceFunction.RenderFunction(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderFunction_Renderer_ReturnsSql()
		{
			// Arrange
			CoalesceFunction coalesceFunction = NewCoalesceFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<CoalesceFunction>(), It.IsAny<StringBuilder>())).Callback((CoalesceFunction value, StringBuilder sql) => sql.Append(expectedSql));
			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = coalesceFunction.RenderFunction(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			CoalesceFunction coalesceFunction = NewCoalesceFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<CoalesceFunction>(), It.IsAny<StringBuilder>())).Callback((CoalesceFunction value, StringBuilder sql) => sql.Append(expectedSql));

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			coalesceFunction.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			CoalesceFunction coalesceFunction = NewCoalesceFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<CoalesceFunction>(), It.IsAny<StringBuilder>())).Callback((CoalesceFunction value, StringBuilder sql) => sql.Append(expectedSql));

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = coalesceFunction.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_ExpressionAndDefaultExpression_ThrowsException<TException>(IExpression? expression, IExpression? defaultExpression) where TException: Exception
		{
			// Act & Assert
			Assert.Throws<TException>(() => new CoalesceFunction(expression!, defaultExpression!));
		}

		private CoalesceFunction NewCoalesceFunction(IExpression? expression = null, IExpression? defaultExpression = null) => 
			new CoalesceFunction(expression ?? NewExpression(), defaultExpression ?? NewExpression());
	}
}
