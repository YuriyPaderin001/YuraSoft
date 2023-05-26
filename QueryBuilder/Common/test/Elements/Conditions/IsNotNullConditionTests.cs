using System;
using System.Text;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Conditions
{
	public class IsNotNullConditionTests : TestsBase
	{
		[Fact]
		public void Constructor_Expression_Success()
		{
			// Arrange
			IExpression expression = NewExpression();

			// Act
			IsNotNullCondition isNotNullCondition = new IsNotNullCondition(expression);

			// Assert
			Assert.Equal(expression, isNotNullCondition.Expression);
		}

		[Fact]
		public void Constructor_NullExpression_ThrowsArgumentNullException()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new IsNotNullCondition(expression: null!));
		}

		[Fact]
		public void RenderCondition_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			IsNotNullCondition isNotNullCondition = new IsNotNullCondition(NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			isNotNullCondition.RenderCondition(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderCondition_Renderer_ReturnsSql()
		{
			// Arrange
			IsNotNullCondition isNotNullCondition = new IsNotNullCondition(NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = isNotNullCondition.RenderCondition(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			IsNotNullCondition isNotNullCondition = new IsNotNullCondition(NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			isNotNullCondition.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			IsNotNullCondition isNotNullCondition = new IsNotNullCondition(NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = isNotNullCondition.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}
	}
}
