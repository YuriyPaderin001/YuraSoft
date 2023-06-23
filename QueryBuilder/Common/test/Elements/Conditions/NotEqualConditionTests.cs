using System;
using System.Text;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Conditions
{
	public class NotEqualConditionTests : TestsBase
	{
		[Fact]
		public void Constructor_LeftExpressionAndRightExpression_Success()
		{
			// Arrange
			IExpression leftExpression = NewExpression();
			IExpression rightExpression = NewExpression();

			// Act
			NotEqualCondition notEqualCondition = new NotEqualCondition(leftExpression, rightExpression);

			// Assert
			Assert.Equal(leftExpression, notEqualCondition.LeftExpression);
			Assert.Equal(rightExpression, notEqualCondition.RightExpression);
		}

		[Fact]
		public void Constructor_NullLeftExpressionAndRightExpression_ThrowsArgumentNullException() =>
			Constructor_LeftExpressionAndRightExpression_ThrowsArgumentNullException_Base(leftExpression: null, NewExpression());

		[Fact]
		public void Constructor_LeftExpressionAndNullRightExpression_ThrowsArgumentNullException() =>
			Constructor_LeftExpressionAndRightExpression_ThrowsArgumentNullException_Base(NewExpression(), rightExpression: null);

		[Fact]
		public void Constructor_NullLeftExpressionAndNullRightExpression_ThrowsArgumentNullException() =>
			Constructor_LeftExpressionAndRightExpression_ThrowsArgumentNullException_Base(leftExpression: null, rightExpression: null);

		[Fact]
		public void RenderCondition_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			NotEqualCondition notEqualCondition = new NotEqualCondition(NewExpression(), NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			notEqualCondition.RenderCondition(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderCondition_Renderer_ReturnsSql()
		{
			// Arrange
			NotEqualCondition notEqualCondition = new NotEqualCondition(NewExpression(), NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = notEqualCondition.RenderCondition(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			NotEqualCondition notEqualCondition = new NotEqualCondition(NewExpression(), NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			notEqualCondition.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			NotEqualCondition notEqualCondition = new NotEqualCondition(NewExpression(), NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = notEqualCondition.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_LeftExpressionAndRightExpression_ThrowsArgumentNullException_Base(IExpression? leftExpression, IExpression? rightExpression)
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new NotEqualCondition(leftExpression!, rightExpression!));
		}
	}
}
