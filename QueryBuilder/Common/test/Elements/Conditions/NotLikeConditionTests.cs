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
			string pattern = "%test%";

			// Act
			NotLikeCondition notLikeCondition = new NotLikeCondition(expression, pattern);

			// Assert
			Assert.Equal(expression, notLikeCondition.Expression);
			Assert.Equal(pattern, notLikeCondition.Pattern);
		}

		[Fact]
		public void Constructor_NullExpressionAndPattern_ThrowsArgumentNullException() =>
			Constructor_ExpressionAndPattern_ThrowsException<ArgumentNullException>(expression: null, "%test%");

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Constructor_ExpressionAndNullOrEmptyPattern_ThrowsArgumentException(string? pattern) =>
			Constructor_ExpressionAndPattern_ThrowsException<ArgumentException>(NewExpression(), pattern);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Constructor_NullExpressionAndNullOrEmptyPattern_ThrowsArgumentNullException(string? pattern) =>
			Constructor_ExpressionAndPattern_ThrowsException<ArgumentNullException>(expression: null, pattern);

		[Fact]
		public void RenderCondition_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			NotLikeCondition notLikeCondition = new NotLikeCondition(NewExpression(), "%test%");

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
			NotLikeCondition notLikeCondition = new NotLikeCondition(NewExpression(), "%test%");

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
			NotLikeCondition notLikeCondition = new NotLikeCondition(NewExpression(), "%test%");

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
			NotLikeCondition notLikeCondition = new NotLikeCondition(NewExpression(), "%test%");

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = notLikeCondition.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_ExpressionAndPattern_ThrowsException<TException>(IExpression? expression, string? pattern) where TException: Exception
		{
			// Act & Assert
			Assert.Throws<TException>(() => new NotLikeCondition(expression!, pattern!));
		}
	}
}
