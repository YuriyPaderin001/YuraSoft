﻿using System;
using System.Text;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Conditions
{
	public class LikeConditionTests : TestsBase
	{
		[Fact]
		public void Constructor_ExpressionAndPattern_Success()
		{
			// Arrange
			IExpression expression = NewExpression();
			string pattern = "%test%";

			// Act
			LikeCondition likeCondition = new LikeCondition(expression, pattern);

			// Assert
			Assert.Equal(expression, likeCondition.Expression);
			Assert.Equal(pattern, likeCondition.Pattern);
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
		public void SetExpression_IExpression_Success()
		{
			// Arrange
			string pattern = "%test%";
			LikeCondition likeCondition = new LikeCondition(NewExpression(), pattern);
			IExpression expression = NewExpression();

			// Act
			likeCondition.Expression = expression;

			// Assert
			Assert.Equal(expression, likeCondition.Expression);
			Assert.Equal(pattern, likeCondition.Pattern);
		}

		[Fact]
		public void SetExpression_NullIExpression_ThrowsArgumentNullException()
		{
			// Arrange
			LikeCondition likeCondition = new LikeCondition(NewExpression(), "%test%");

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => likeCondition.Expression = null!);
		}

		[Fact]
		public void SetPattern_String_Success()
		{
			// Arrange
			IExpression expression = NewExpression();
			LikeCondition likeCondition = new LikeCondition(expression, "%test%");
			string pattern = "%new_test%";

			// Act
			likeCondition.Pattern = pattern;

			// Assert
			Assert.Equal(expression, likeCondition.Expression);
			Assert.Equal(pattern, likeCondition.Pattern);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void SetPattern_NullOrEmptyString_ThrowsArgumentException(string? pattern)
		{
			// Arrange
			LikeCondition likeCondition = new LikeCondition(NewExpression(), "%test%");

			// Act & Assert
			Assert.Throws<ArgumentException>(() => likeCondition.Pattern = pattern!);
		}

		[Fact]
		public void RenderCondition_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			LikeCondition likeCondition = new LikeCondition(NewExpression(), "%test%");

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			likeCondition.RenderCondition(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderCondition_Renderer_ReturnsSql()
		{
			// Arrange
			LikeCondition likeCondition = new LikeCondition(NewExpression(), "%test%");

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = likeCondition.RenderCondition(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			LikeCondition likeCondition = new LikeCondition(NewExpression(), "%test%");

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			likeCondition.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			LikeCondition likeCondition = new LikeCondition(NewExpression(), "%test%");

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = likeCondition.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_ExpressionAndPattern_ThrowsException<TException>(IExpression? expression, string? pattern) where TException: Exception
		{
			// Act & Assert
			Assert.Throws<TException>(() => new LikeCondition(expression!, pattern!));
		}
	}
}
