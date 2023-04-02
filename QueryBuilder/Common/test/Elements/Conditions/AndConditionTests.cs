using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Conditions
{
	public class AndConditionTests : TestsBase
	{
		[Theory]
		[InlineData(1)]
		[InlineData(3)]
		public void Constructor_IConditionList_Success(int length)
		{
			// Arrange
			List<ICondition> conditions = NewConditionList(length);

			// Act
			AndCondition andCondition = new AndCondition(conditions);

			// Assert
			Assert.Equal(conditions, andCondition.Conditions);
		}

		[Fact]
		public void Constructor_EmptyIConditionList_ThrowsArgumentOutOfRangeException() =>
			Constructor_IConditionList_ThrowsException<ArgumentOutOfRangeException>(NewEmptyConditionList());

		[Fact]
		public void Constructor_NullIConditionList_ThrowsArgumentNullException() =>
			Constructor_IConditionList_ThrowsException<ArgumentNullException>(conditions: null);

		[Theory]
		[InlineData(1)]
		[InlineData(3)]
		public void SetConditions_IConditionList_Success(int length)
		{
			// Arrange
			AndCondition andCondition = new AndCondition(NewConditionList(3));
			List<ICondition> conditions = NewConditionList(length);

			// Act
			andCondition.Conditions = conditions;

			// Assert
			Assert.Equal(conditions, andCondition.Conditions);
		}

		[Fact]
		public void SetConditions_EmptyIConditionList_ThrowsArgumentOutOfRangeException() =>
			SetConditions_IConditionList_ThrowsException<ArgumentOutOfRangeException>(NewEmptyConditionList());

		[Fact]
		public void SetConditions_NullIConditionList_ThrowsArgumentNullException() =>
			SetConditions_IConditionList_ThrowsException<ArgumentNullException>(conditions: null);

		[Fact]
		public void RenderCondition_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			AndCondition andCondition = new AndCondition(NewConditionList(3));

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			andCondition.RenderCondition(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderCondition_Renderer_ReturnsSql()
		{
			// Arrange
			AndCondition andCondition = new AndCondition(NewConditionList(3));

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = andCondition.RenderCondition(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			AndCondition andCondition = new AndCondition(NewConditionList(3));

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);
			StringBuilder sql = new StringBuilder();

			// Act
			andCondition.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			AndCondition andCondition = new AndCondition(NewConditionList(3));

			const string expectedSql = "test";
			IRenderer renderer = new NullRenderer(expectedSql);

			// Act
			string sql = andCondition.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_IConditionList_ThrowsException<TException>(List<ICondition>? conditions) where TException: Exception
		{
			// Act & Assert
			Assert.Throws<TException>(() => new AndCondition(conditions!));
		}

		private void SetConditions_IConditionList_ThrowsException<TException>(List<ICondition>? conditions) where TException: Exception
		{
			// Arrange
			AndCondition andCondition = new AndCondition(NewConditionList(3));

			// Act & Assert
			Assert.Throws<TException>(() => andCondition.Conditions = conditions!);
		}
	}
}
