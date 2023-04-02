using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Conditions
{
	public class InConditionTests : TestsBase
	{
		[Theory]
		[InlineData(1)]
		[InlineData(3)]
		public void Constructor_ExpressionAndIExpressionList_Success(int length)
		{
			// Arrange
			IExpression expression = NewExpression();
			List<IExpression> values = NewExpressionList(length);

			// Act
			InCondition inCondition = new InCondition(expression, values);

			// Assert
			Assert.Equal(expression, inCondition.Expression);
			Assert.Equal(values, inCondition.Values);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(1)]
		[InlineData(3)]
		public void Constructor_NullExpressionAndIExpressionList_ThrowsArgumentNullException(int length) =>
			Constructor_ExpressionAndIExpressionList_ThrowsException<ArgumentNullException>(expression: null, NewExpressionList(length));

		[Fact]
		public void Constructor_NullExpressionAndNullIExpressionList_ThrowsArgumentNullException() =>
			Constructor_ExpressionAndIExpressionList_ThrowsException<ArgumentNullException>(expression: null, values: null);

		[Fact]
		public void Constructor_ExpressionAndEmptyIExpressionList_ThrowsArgumentOutOfRangeException() =>
			Constructor_ExpressionAndIExpressionList_ThrowsException<ArgumentOutOfRangeException>(NewExpression(), NewEmptyExpressionList());

		[Fact]
		public void Constructor_ExpressionAndNullIExpressionList_ThrowsArgumentNullException() =>
			Constructor_ExpressionAndIExpressionList_ThrowsException<ArgumentNullException>(NewExpression(), values: null);

		[Theory]
		[InlineData(1)]
		[InlineData(3)]
		public void SetExpression_IExpression_Success(int length)
		{
			// Arrange
			List<IExpression> values = NewExpressionList(length);
			InCondition inCondition = new InCondition(NewExpression(), values);
			IExpression expression = NewExpression();

			// Act
			inCondition.Expression = expression;

			// Assert
			Assert.Equal(expression, inCondition.Expression);
			Assert.Equal(values, inCondition.Values);
		}

		[Fact]
		public void SetExpression_NullIExpression_ThrowsArgumentNullException()
		{
			// Arrange
			InCondition inCondition = new InCondition(NewExpression(), NewExpressionList(3));

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => inCondition.Expression = null!);
		}

		[Theory]
		[InlineData(1)]
		[InlineData(3)]
		public void SetValues_IExpressionList_Success(int length)
		{
			// Arrange
			IExpression expression = NewExpression();
			InCondition inCondition = new InCondition(expression, NewExpressionList(3));
			List<IExpression> values = NewExpressionList(length);

			// Act
			inCondition.Values = values;

			// Assert
			Assert.Equal(expression, inCondition.Expression);
			Assert.Equal(values, inCondition.Values);
		}

		[Fact]
		public void SetValues_EmptyIExpressionList_ThrowsArgumentOutOfLengthException() =>
			SetValues_IExpressionList_ThrowsException<ArgumentOutOfRangeException>(NewEmptyExpressionList());

		[Fact]
		public void SetValues_NullIExpressionList_ThrowsArgumentNullException() =>
			SetValues_IExpressionList_ThrowsException<ArgumentNullException>(values: null);

		[Fact]
		public void RenderCondition_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			InCondition inCondition = new InCondition(NewExpression(), NewExpressionList(3));

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			inCondition.RenderCondition(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderCondition_Renderer_ReturnsSql()
		{
			// Arrange
			InCondition inCondition = new InCondition(NewExpression(), NewExpressionList(3));

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = inCondition.RenderCondition(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			InCondition inCondition = new InCondition(NewExpression(), NewExpressionList(3));

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			inCondition.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			InCondition inCondition = new InCondition(NewExpression(), NewExpressionList(3));

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = inCondition.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_ExpressionAndIExpressionList_ThrowsException<TException>(IExpression? expression, List<IExpression>? values) where TException: Exception
		{
			// Act & Assert
			Assert.Throws<TException>(() => new InCondition(expression!, values!));
		}

		private void SetValues_IExpressionList_ThrowsException<TException>(List<IExpression>? values) where TException: Exception
		{
			// Arrange
			InCondition inCondition = new InCondition(NewExpression(), NewExpressionList(3));

			// Act & Assert
			Assert.Throws<TException>(() => inCondition.Values = values!);
		}
	}
}
