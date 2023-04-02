using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Conditions
{
	public class BetweenConditionTests : TestsBase
	{
		[Fact]
		public void Constructor_ExpressionAndLessExpressionAndHightExpression_Success()
		{
			// Arrange
			IExpression expression = NewExpression();
			IExpression lessExpression = NewExpression();
			IExpression hightExpression = NewExpression();

			// Act
			BetweenCondition betweenCondition = new BetweenCondition(expression, lessExpression, hightExpression);

			// Assert
			Assert.Equal(expression, betweenCondition.Expression);
			Assert.Equal(lessExpression, betweenCondition.LessExpression);
			Assert.Equal(hightExpression, betweenCondition.HightExpression);
		}

		[Fact]
		public void Constructor_NullExpressionAndLessExpressionAndHightExpression_ThrowsArgumentNullException()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new BetweenCondition(expression: null!, NewExpression(), NewExpression()));
		}

		[Fact]
		public void Constructor_NullExpressionAndNullLessExpressionAndHightExpression_ThrowsArgumentNullException()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new BetweenCondition(expression: null!, lessExpression: null!, NewExpression()));
		}

		[Fact]
		public void Constructor_NullExpressionAndLessExpressionAndNullHightExpression_ThrowsArgumentNullException()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new BetweenCondition(expression: null!, NewExpression(), hightExpression: null!));
		}

		[Fact]
		public void Constructor_NullExpressionAndNullLessExpressionAndNullHightExpression_ThrowsArgumentNullException()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new BetweenCondition(expression: null!, lessExpression: null!, hightExpression: null!));
		}

		[Fact]
		public void Constructor_ExpressionAndNullLessExpressionAndHightExpression_ThrowsArgumentNullException()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new BetweenCondition(NewExpression(), lessExpression: null!, NewExpression()));
		}

		[Fact]
		public void Constructor_ExpressionAndNullLessExpressionAndNullHightExpression_ThrowsArgumentNullException()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new BetweenCondition(NewExpression(), lessExpression: null!, hightExpression: null!));
		}

		[Fact]
		public void Constructor_ExpressionAndLessExpressionAndNullHightExpression_ThrowsArgumentNullException()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new BetweenCondition(NewExpression(), NewExpression(), hightExpression: null!));
		}

		[Fact]
		public void SetExpression_IExpression_Success()
		{
			// Arrange
			IExpression lessExpression = NewExpression();
			IExpression hightExpression = NewExpression();
			BetweenCondition betweenCondition = new BetweenCondition(NewExpression(), lessExpression, hightExpression);
			IExpression expression = NewExpression();

			// Act
			betweenCondition.Expression = expression;

			// Assert
			Assert.Equal(expression, betweenCondition.Expression);
			Assert.Equal(lessExpression, betweenCondition.LessExpression);
			Assert.Equal(hightExpression, betweenCondition.HightExpression);
		}

		[Fact]
		public void SetExpression_NullIExpression_ThrowsArgumentNullException()
		{
			// Arrange
			BetweenCondition betweenCondition = new BetweenCondition(NewExpression(), NewExpression(), NewExpression());

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => betweenCondition.Expression = null!);
		}

		[Fact]
		public void SetLessExpression_IExpression_Success()
		{
			// Arrange
			IExpression expression = NewExpression();
			IExpression hightExpression = NewExpression();
			BetweenCondition betweenCondition = new BetweenCondition(expression, NewExpression(), hightExpression);
			IExpression lessExpression = NewExpression();

			// Act
			betweenCondition.LessExpression = lessExpression;

			// Assert
			Assert.Equal(expression, betweenCondition.Expression);
			Assert.Equal(lessExpression, betweenCondition.LessExpression);
			Assert.Equal(hightExpression, betweenCondition.HightExpression);
		}

		[Fact]
		public void SetLessExpression_NullIExpression_ThrowsArgumentNullException()
		{
			// Arrange
			BetweenCondition betweenCondition = new BetweenCondition(NewExpression(), NewExpression(), NewExpression());

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => betweenCondition.LessExpression = null!);
		}

		[Fact]
		public void SetHightExpression_IExpression_Success()
		{
			// Arrange
			IExpression expression = NewExpression();
			IExpression lessExpression = NewExpression();
			BetweenCondition betweenCondition = new BetweenCondition(expression, lessExpression, NewExpression());
			IExpression hightExpression = NewExpression();

			// Act
			betweenCondition.HightExpression = hightExpression;

			// Assert
			Assert.Equal(expression, betweenCondition.Expression);
			Assert.Equal(lessExpression, betweenCondition.LessExpression);
			Assert.Equal(hightExpression, betweenCondition.HightExpression);
		}

		[Fact]
		public void SetHightExpression_NullIExpression_ThrowsArgumentNullException()
		{
			// Arrange
			BetweenCondition betweenCondition = new BetweenCondition(NewExpression(), NewExpression(), NewExpression());

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => betweenCondition.HightExpression = null!);
		}

		[Fact]
		public void RenderCondition_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			BetweenCondition betweenCondition = new BetweenCondition(NewExpression(), NewExpression(), NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			betweenCondition.RenderCondition(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderCondition_Renderer_ReturnsSql()
		{
			// Arrange
			BetweenCondition betweenCondition = new BetweenCondition(NewExpression(), NewExpression(), NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = betweenCondition.RenderCondition(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			BetweenCondition betweenCondition = new BetweenCondition(NewExpression(), NewExpression(), NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			betweenCondition.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			BetweenCondition betweenCondition = new BetweenCondition(NewExpression(), NewExpression(), NewExpression());

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = betweenCondition.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_ExpressionAndLessExpressionAndHightExpression_ThrowsArgumentNullException_Base(IExpression expression, IExpression lessExpression, IExpression hightExpression)
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new BetweenCondition(expression!, lessExpression!, hightExpression!));
		}
	}
}
