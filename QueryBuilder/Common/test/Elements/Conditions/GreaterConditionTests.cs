using System;
using System.Text;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Conditions
{
	public class GreaterConditionTests : TestsBase
	{
		[Fact]
		public void Constructor_LeftExpressionAndRightExpression_Success()
		{
			// Arrange
			IExpression leftExpression = NewExpression();
			IExpression rightExpression = NewExpression();

			// Act
			GreaterCondition greaterCondition = new GreaterCondition(leftExpression, rightExpression);

			// Assert
			Assert.Equal(leftExpression, greaterCondition.LeftExpression);
			Assert.Equal(rightExpression, greaterCondition.RightExpression);
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
			GreaterCondition greaterCondition = new GreaterCondition(NewExpression(), rightExpression);
			IExpression leftExpression = NewExpression();

			// Act
			greaterCondition.LeftExpression = leftExpression;

			// Assert
			Assert.Equal(leftExpression, greaterCondition.LeftExpression);
			Assert.Equal(rightExpression, greaterCondition.RightExpression);
		}

		[Fact]
		public void SetLeftExpression_NullIExpression_ThrowsArgumentNullException()
		{
			// Arrange
			GreaterCondition greaterCondition = new GreaterCondition(NewExpression(), NewExpression());

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => greaterCondition.LeftExpression = null!);
		}

		[Fact]
		public void SetRightExpression_IExpression_Success()
		{
			// Arrange
			IExpression leftExpression = NewExpression();
			GreaterCondition greaterCondition = new GreaterCondition(leftExpression, NewExpression());
			IExpression rightExpression = NewExpression();

			// Act
			greaterCondition.RightExpression = rightExpression;

			// Assert
			Assert.Equal(leftExpression, greaterCondition.LeftExpression);
			Assert.Equal(rightExpression, greaterCondition.RightExpression);
		}

		[Fact]
		public void SetRightExpression_NullIExpression_ThrowsArgumentNullException()
		{
			// Arrange
			GreaterCondition greaterCondition = new GreaterCondition(NewExpression(), NewExpression());

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => greaterCondition.RightExpression = null!);
		}

		[Fact]
		public void RenderCondition_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			GreaterCondition greaterCondition = new GreaterCondition(NewExpression(), NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			greaterCondition.RenderCondition(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderCondition_Renderer_ReturnsSql()
		{
			// Arrange
			GreaterCondition greaterCondition = new GreaterCondition(NewExpression(), NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = greaterCondition.RenderCondition(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			GreaterCondition greaterCondition = new GreaterCondition(NewExpression(), NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			greaterCondition.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			GreaterCondition greaterCondition = new GreaterCondition(NewExpression(), NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = greaterCondition.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_LeftExpressionAndRightExpression_ThrowsArgumentNullException_Base(IExpression? leftExpression, IExpression? rightExpression)
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new GreaterCondition(leftExpression!, rightExpression!));
		}
	}
}
