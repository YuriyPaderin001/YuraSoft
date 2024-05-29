using System;
using System.Text;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Conditions
{
	public class NotLikeConditionTests : TestsBase
	{
		[Fact]
		public void Constructor_ExpressionAndPattern_Success()
		{
			// Arrange
			IExpression expression = NewExpression();
			IExpression pattern = NewExpression();

			// Act
			NotLikeCondition notLikeCondition = new NotLikeCondition(expression, pattern);

			// Assert
			Assert.Equal(expression, notLikeCondition.Expression);
			Assert.Equal(pattern, notLikeCondition.Pattern);
		}

		[Fact]
		public void Constructor_NullIExpressionAndIExpression_ThrowsArgumentNullException() =>
			Constructor_IExpressionAndIExpression_ThrowsException<ArgumentNullException>(expression: null, pattern: NewExpression());

		[Fact]
		public void Constructor_IExpressionAndNullIExpression_ThrowsArgumentException() =>
			Constructor_IExpressionAndIExpression_ThrowsException<ArgumentNullException>(expression: NewExpression(), pattern: null);

		[Fact]
		public void Constructor_NullIExpressionAndNullIExpression_ThrowsArgumentNullException() =>
			Constructor_IExpressionAndIExpression_ThrowsException<ArgumentNullException>(expression: null, pattern: null);

		[Fact]
		public void RenderCondition_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			IExpression expression = NewExpression();
			IExpression pattern = NewExpression();

			NotLikeCondition notLikeCondition = new NotLikeCondition(expression, pattern);

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			notLikeCondition.RenderCondition(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderCondition_Renderer_ReturnsSql()
		{
			// Arrange
			IExpression expression = NewExpression();
			IExpression pattern = NewExpression();

			NotLikeCondition notLikeCondition = new NotLikeCondition(expression, pattern);

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = notLikeCondition.RenderCondition(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			IExpression expression = NewExpression();
			IExpression pattern = NewExpression();

			NotLikeCondition notLikeCondition = new NotLikeCondition(expression, pattern);

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			notLikeCondition.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			IExpression expression = NewExpression();
			IExpression pattern = NewExpression();

			NotLikeCondition notLikeCondition = new NotLikeCondition(expression, pattern);

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = notLikeCondition.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_IExpressionAndIExpression_ThrowsException<TException>(IExpression? expression, IExpression? pattern) where TException: Exception
		{
			// Act & Assert
			Assert.Throws<TException>(() => new NotLikeCondition(expression!, pattern!));
		}
	}
}
