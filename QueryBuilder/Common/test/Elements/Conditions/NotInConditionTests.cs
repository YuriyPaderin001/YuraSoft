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

		[Theory]
		[InlineData(1)]
		[InlineData(3)]
		public void SetExpression_IExpression_Success(int length)
		{
			// Arrange
			List<IExpression> values = NewExpressionList(length);
			NotInCondition notInCondition = new NotInCondition(NewExpression(), values);
			IExpression expression = NewExpression();

			// Act
			notInCondition.Expression = expression;

			// Assert
			Assert.Equal(expression, notInCondition.Expression);
			Assert.Equal(values, notInCondition.Values);
		}

		[Fact]
		public void SetExpression_NullIExpression_ThrowsArgumentNullException()
		{
			// Arrange
			NotInCondition notInCondition = new NotInCondition(NewExpression(), NewExpressionList(3));

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => notInCondition.Expression = null!);
		}

		[Theory]
		[InlineData(1)]
		[InlineData(3)]
		public void SetValues_IExpressionList_Success(int length)
		{
			// Arrange
			IExpression expression = NewExpression();
			NotInCondition notInCondition = new NotInCondition(expression, NewExpressionList(3));
			List<IExpression> values = NewExpressionList(length);

			// Act
			notInCondition.Values = values;

			// Assert
			Assert.Equal(expression, notInCondition.Expression);
			Assert.Equal(values, notInCondition.Values);
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

		private void SetValues_IExpressionList_ThrowsException<TException>(List<IExpression>? values) where TException: Exception
		{
			// Arrange
			NotInCondition notInCondition = new NotInCondition(NewExpression(), NewExpressionList(3));

			// Act & Assert
			Assert.Throws<TException>(() => notInCondition.Values = values!);
		}
	}
}
