using System;
using YuraSoft.QueryBuilder.Common;

namespace YuraSoft.QueryBuilder.PostgreSql
{
	public static class ConditionBuilderExtensions
	{
		public static ConditionBuilder True(this ConditionBuilder builder, string column) =>
			builder.Condition(builder.Factory.True(column));

		public static ConditionBuilder True(this ConditionBuilder builder, string column, string table) =>
			builder.Condition(builder.Factory.True(column, table));

		public static ConditionBuilder True(this ConditionBuilder builder, string column, ISource source) =>
			builder.Condition(builder.Factory.True(column, source));

		public static ConditionBuilder True(this ConditionBuilder builder, IExpression expression) =>
			builder.Condition(builder.Factory.True(expression));

		public static ConditionBuilder True(this ConditionBuilder builder, Func<ExpressionFactory, IExpression> expressionFunction) =>
			builder.Condition(builder.Factory.True(expressionFunction));

		public static ConditionBuilder False(this ConditionBuilder builder, string column) =>
			builder.Condition(builder.Factory.False(column));

		public static ConditionBuilder False(this ConditionBuilder builder, string column, string table) =>
			builder.Condition(builder.Factory.False(column, table));

		public static ConditionBuilder False(this ConditionBuilder builder, string column, ISource source) =>
			builder.Condition(builder.Factory.False(column, source));

		public static ConditionBuilder False(this ConditionBuilder builder, IExpression expression) =>
			builder.Condition(builder.Factory.False(expression));

		public static ConditionBuilder False(this ConditionBuilder builder, Func<ExpressionFactory, IExpression> expressionFunction) =>
			builder.Condition(builder.Factory.False(expressionFunction));

		public static ConditionBuilder Equal(this ConditionBuilder builder, string column, bool value) =>
			builder.Condition(builder.Factory.Equal(column, value));

		public static ConditionBuilder Equal(this ConditionBuilder builder, string column, string table, bool value) =>
			builder.Condition(builder.Factory.Equal(column, table, value));

		public static ConditionBuilder Equal(this ConditionBuilder builder, string column, ISource source, bool value) =>
			builder.Condition(builder.Factory.Equal(column, source, value));

		public static ConditionBuilder Equal(this ConditionBuilder builder, IExpression expression, bool value) =>
			builder.Condition(builder.Factory.Equal(expression, value));

		public static ConditionBuilder Equal(this ConditionBuilder builder, Func<ExpressionFactory, IExpression> expressionFunction, bool value) =>
			builder.Condition(builder.Factory.Equal(expressionFunction, value));

		public static ConditionBuilder NotEqual(this ConditionBuilder builder, string column, bool value) =>
			builder.Condition(builder.Factory.NotEqual(column, value));

		public static ConditionBuilder NotEqual(this ConditionBuilder builder, string column, string table, bool value) =>
			builder.Condition(builder.Factory.NotEqual(column, table, value));

		public static ConditionBuilder NotEqual(this ConditionBuilder builder, string column, ISource source, bool value) =>
			builder.Condition(builder.Factory.NotEqual(column, source, value));

		public static ConditionBuilder NotEqual(this ConditionBuilder builder, IExpression expression, bool value) =>
			builder.Condition(builder.Factory.NotEqual(expression, value));

		public static ConditionBuilder NotEqual(this ConditionBuilder builder, Func<ExpressionFactory, IExpression> expressionFunction, bool value) =>
			builder.Condition(builder.Factory.NotEqual(expressionFunction, value));
	}
}
