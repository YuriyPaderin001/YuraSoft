using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Conditions
{
	public class NotInConditionTests : TestsBase
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
			NotInCondition notInCondition = new NotInCondition(expression, values);

			// Assert
			Assert.Equal(expression, notInCondition.Expression);
			Assert.Equal(values, notInCondition.Values);
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

		[Fact]
		public void RenderCondition_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			NotInCondition notInCondition = new NotInCondition(NewExpression(), NewExpressionList(3));

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			notInCondition.RenderCondition(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderCondition_Renderer_ReturnsSql()
		{
			// Arrange
			NotInCondition notInCondition = new NotInCondition(NewExpression(), NewExpressionList(3));

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = notInCondition.RenderCondition(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			NotInCondition notInCondition = new NotInCondition(NewExpression(), NewExpressionList(3));

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			notInCondition.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			NotInCondition notInCondition = new NotInCondition(NewExpression(), NewExpressionList(3));

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = notInCondition.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_ExpressionAndIExpressionList_ThrowsException<TException>(IExpression? expression, List<IExpression>? values) where TException: Exception
		{
			// Act & Assert
			Assert.Throws<TException>(() => new NotInCondition(expression!, values!));
		}
	}
}
