using System;
using System.Text;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Conditions
{
	public class GreaterOrEqualConditionTests : TestsBase
	{
		[Fact]
		public void Constructor_LeftExpressionAndRightExpression_Success()
		{
			// Arrange
			IExpression leftExpression = NewExpression();
			IExpression rightExpression = NewExpression();

			// Act
			GreaterOrEqualCondition greaterOrEqualCondition = new GreaterOrEqualCondition(leftExpression, rightExpression);

			// Assert
			Assert.Equal(leftExpression, greaterOrEqualCondition.LeftExpression);
			Assert.Equal(rightExpression, greaterOrEqualCondition.RightExpression);
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
		public void SetLeftExpression_IExpression_Success()
		{
			// Arrange
			IExpression rightExpression = NewExpression();
			GreaterOrEqualCondition greaterOrEqualCondition = new GreaterOrEqualCondition(NewExpression(), rightExpression);
			IExpression leftExpression = NewExpression();

			// Act
			greaterOrEqualCondition.LeftExpression = leftExpression;

			// Assert
			Assert.Equal(leftExpression, greaterOrEqualCondition.LeftExpression);
			Assert.Equal(rightExpression, greaterOrEqualCondition.RightExpression);
		}

		[Fact]
		public void SetLeftExpression_NullIExpression_ThrowsArgumentNullException()
		{
			// Arrange
			GreaterOrEqualCondition greaterOrEqualCondition = new GreaterOrEqualCondition(NewExpression(), NewExpression());

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => greaterOrEqualCondition.LeftExpression = null!);
		}

		[Fact]
		public void SetRightExpression_IExpression_Success()
		{
			// Arrange
			IExpression leftExpression = NewExpression();
			GreaterOrEqualCondition greaterOrEqualCondition = new GreaterOrEqualCondition(leftExpression, NewExpression());
			IExpression rightExpression = NewExpression();

			// Act
			greaterOrEqualCondition.RightExpression = rightExpression;

			// Assert
			Assert.Equal(leftExpression, greaterOrEqualCondition.LeftExpression);
			Assert.Equal(rightExpression, greaterOrEqualCondition.RightExpression);
		}

		[Fact]
		public void SetRightExpression_NullIExpression_ThrowsArgumentNullException()
		{
			// Arrange
			GreaterOrEqualCondition greaterOrEqualCondition = new GreaterOrEqualCondition(NewExpression(), NewExpression());

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => greaterOrEqualCondition.RightExpression = null!);
		}

		[Fact]
		public void RenderCondition_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			GreaterOrEqualCondition greaterOrEqualCondition = new GreaterOrEqualCondition(NewExpression(), NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			greaterOrEqualCondition.RenderCondition(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderCondition_Renderer_ReturnsSql()
		{
			// Arrange
			GreaterOrEqualCondition greaterOrEqualCondition = new GreaterOrEqualCondition(NewExpression(), NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = greaterOrEqualCondition.RenderCondition(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			GreaterOrEqualCondition greaterOrEqualCondition = new GreaterOrEqualCondition(NewExpression(), NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			greaterOrEqualCondition.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			GreaterOrEqualCondition greaterOrEqualCondition = new GreaterOrEqualCondition(NewExpression(), NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = greaterOrEqualCondition.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_LeftExpressionAndRightExpression_ThrowsArgumentNullException_Base(IExpression? leftExpression, IExpression? rightExpression)
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new GreaterOrEqualCondition(leftExpression!, rightExpression!));
		}
	}
}
