using System;
using System.Text;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Conditions
{
	public class EqualConditionTests : TestsBase
	{
		[Fact]
		public void Constructor_LeftExpressionAndRightExpression_Success()
		{
			// Arrange
			IExpression leftExpression = NewExpression();
			IExpression rightExpression = NewExpression();

			// Act
			EqualCondition equalCondition = new EqualCondition(leftExpression, rightExpression);

			// Assert
			Assert.Equal(leftExpression, equalCondition.LeftExpression);
			Assert.Equal(rightExpression, equalCondition.RightExpression);
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
			EqualCondition equalCondition = new EqualCondition(NewExpression(), rightExpression);
			IExpression leftExpression = NewExpression();

			// Act
			equalCondition.LeftExpression = leftExpression;

			// Assert
			Assert.Equal(leftExpression, equalCondition.LeftExpression);
			Assert.Equal(rightExpression, equalCondition.RightExpression);
		}

		[Fact]
		public void SetLeftExpression_NullIExpression_ThrowsArgumentNullException()
		{
			// Arrange
			EqualCondition equalCondition = new EqualCondition(NewExpression(), NewExpression());

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => equalCondition.LeftExpression = null!);
		}

		[Fact]
		public void SetRightExpression_IExpression_Success()
		{
			// Arrange
			IExpression leftExpression = NewExpression();
			EqualCondition equalCondition = new EqualCondition(leftExpression, NewExpression());
			IExpression rightExpression = NewExpression();

			// Act
			equalCondition.RightExpression = rightExpression;

			// Assert
			Assert.Equal(leftExpression, equalCondition.LeftExpression);
			Assert.Equal(rightExpression, equalCondition.RightExpression);
		}

		[Fact]
		public void SetRightExpression_NullIExpression_ThrowsArgumentNullException()
		{
			// Arrange
			EqualCondition equalCondition = new EqualCondition(NewExpression(), NewExpression());

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => equalCondition.RightExpression = null!);
		}

		[Fact]
		public void RenderCondition_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			EqualCondition equalCondition = new EqualCondition(NewExpression(), NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			equalCondition.RenderCondition(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderCondition_Renderer_ReturnsSql()
		{
			// Arrange
			EqualCondition equalCondition = new EqualCondition(NewExpression(), NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = equalCondition.RenderCondition(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			EqualCondition equalCondition = new EqualCondition(NewExpression(), NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			equalCondition.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			EqualCondition equalCondition = new EqualCondition(NewExpression(), NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = equalCondition.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_LeftExpressionAndRightExpression_ThrowsArgumentNullException_Base(IExpression? leftExpression, IExpression? rightExpression)
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new EqualCondition(leftExpression!, rightExpression!));
		}
	}
}
