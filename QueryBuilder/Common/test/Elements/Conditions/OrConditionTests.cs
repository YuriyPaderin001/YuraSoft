using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Conditions
{
	public class OrConditionTests : TestsBase
	{
		[Theory]
		[InlineData(1)]
		[InlineData(3)]
		public void Constructor_IConditionList_Success(int length)
		{
			// Arrange
			List<ICondition> conditions = NewConditionList(length);

			// Act
			OrCondition orCondition = new OrCondition(conditions);

			// Assert
			Assert.Equal(conditions, orCondition.Conditions);
		}

		[Fact]
		public void Constructor_EmptyIConditionList_ThrowsArgumentOutOfRangeException() =>
			Constructor_IConditionList_ThrowsException<ArgumentOutOfRangeException>(NewEmptyConditionList());

		[Fact]
		public void Constructor_NullIConditionList_ThrowsArgumentNullException() =>
			Constructor_IConditionList_ThrowsException<ArgumentNullException>(conditions: null);

		[Fact]
		public void RenderCondition_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			OrCondition orCondition = new OrCondition(NewConditionList(3));

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			orCondition.RenderCondition(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderCondition_Renderer_ReturnsSql()
		{
			// Arrange
			OrCondition orCondition = new OrCondition(NewConditionList(3));

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = orCondition.RenderCondition(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			OrCondition orCondition = new OrCondition(NewConditionList(3));

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			orCondition.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			OrCondition orCondition = new OrCondition(NewConditionList(3));

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = orCondition.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_IConditionList_ThrowsException<TException>(List<ICondition>? conditions) where TException: Exception
		{
			// Act & Assert
			Assert.Throws<TException>(() => new OrCondition(conditions!));
		}
	}
}
