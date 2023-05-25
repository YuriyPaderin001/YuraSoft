using System;
using YuraSoft.QueryBuilder.Common;

namespace YuraSoft.QueryBuilder.PostgreSql
{
    public static class ExpressionBuilderExtensions
    {
		public static ExpressionBuilder True(this ExpressionBuilder builder, IExpression expression) =>
			builder.Expression(builder.Factory.True(expression));

		public static ExpressionBuilder True(this ExpressionBuilder builder, Func<ExpressionFactory, IExpression> expressionFunction) =>
			builder.Expression(builder.Factory.True(expressionFunction));

		public static ExpressionBuilder True(this ExpressionBuilder builder, string column) =>
			builder.Expression(builder.Factory.True(column));

		public static ExpressionBuilder True(this ExpressionBuilder builder, string column, string table) =>
			builder.Expression(builder.Factory.True(column, table));

		public static ExpressionBuilder True(this ExpressionBuilder builder, string column, ISource source) =>
			builder.Expression(builder.Factory.True(column, source));

		public static ExpressionBuilder False(this ExpressionBuilder builder, IExpression expression) =>
			builder.Expression(builder.Factory.False(expression));

		public static ExpressionBuilder False(this ExpressionBuilder builder, Func<ExpressionFactory, IExpression> expressionFunction) =>
			builder.Expression(builder.Factory.False(expressionFunction));

		public static ExpressionBuilder False(this ExpressionBuilder builder, string column) =>
			builder.Expression(builder.Factory.False(column));

		public static ExpressionBuilder False(this ExpressionBuilder builder, string column, string table) =>
			builder.Expression(builder.Factory.False(column, table));

		public static ExpressionBuilder False(this ExpressionBuilder builder, string column, ISource source) =>
			builder.Expression(builder.Factory.False(column, source));

		public static ExpressionBuilder Equal(this ExpressionBuilder builder, IExpression expression, bool value) =>
			builder.Expression(builder.Factory.Equal(expression, value));

		public static ExpressionBuilder Equal(this ExpressionBuilder builder, Func<ExpressionFactory, IExpression> expressionFunction, bool value) =>
			builder.Expression(builder.Factory.Equal(expressionFunction, value));

		public static ExpressionBuilder Equal(this ExpressionBuilder builder, string column, bool value) =>
			builder.Expression(builder.Factory.Equal(column, value));

		public static ExpressionBuilder Equal(this ExpressionBuilder builder, string column, string table, bool value) =>
			builder.Expression(builder.Factory.Equal(column, table, value));

		public static ExpressionBuilder Equal(this ExpressionBuilder builder, string column, ISource source, bool value) =>
			builder.Expression(builder.Factory.Equal(column, source, value));

		public static ExpressionBuilder NotEqual(this ExpressionBuilder builder, IExpression expression, bool value) =>
			builder.Expression(builder.Factory.NotEqual(expression, value));

		public static ExpressionBuilder NotEqual(this ExpressionBuilder builder, Func<ExpressionFactory, IExpression> expressionFunction, bool value) =>
			builder.Expression(builder.Factory.NotEqual(expressionFunction, value));

		public static ExpressionBuilder NotEqual(this ExpressionBuilder builder, string column, bool value) =>
			builder.Expression(builder.Factory.NotEqual(column, value));

		public static ExpressionBuilder NotEqual(this ExpressionBuilder builder, string column, string table, bool value) =>
			builder.Expression(builder.Factory.NotEqual(column, table, value));

		public static ExpressionBuilder NotEqual(this ExpressionBuilder builder, string column, ISource source, bool value) =>
			builder.Expression(builder.Factory.NotEqual(column, source, value));

		public static ExpressionBuilder Coalesce(this ExpressionBuilder builder, string column, bool value) =>
			builder.Expression(builder.Factory.Coalesce(column, value));

		public static ExpressionBuilder Coalesce(this ExpressionBuilder builder, string column, string table, bool value) =>
			builder.Expression(builder.Factory.Coalesce(column, table, value));

		public static ExpressionBuilder Coalesce(this ExpressionBuilder builder, string column, ISource source, bool value) =>
			builder.Expression(builder.Factory.Coalesce(column, source, value));

		public static ExpressionBuilder Coalesce(this ExpressionBuilder builder, Func<ExpressionFactory, IExpression> expressionFunction, bool value) =>
			builder.Expression(builder.Factory.Coalesce(expressionFunction, value));

		public static ExpressionBuilder Coalesce(this ExpressionBuilder builder, IExpression expression, bool value) =>
			builder.Expression(builder.Factory.Coalesce(expression, value));

		public static ExpressionBuilder True(this ExpressionBuilder builder) =>
			builder.Expression(builder.Factory.True());

		public static ExpressionBuilder False(this ExpressionBuilder builder) =>
			builder.Expression(builder.Factory.False());

		public static ExpressionBuilder Bool(this ExpressionBuilder builder, bool value) => 
			builder.Expression(builder.Factory.Bool(value));

		public static ExpressionBuilder Bool(this ExpressionBuilder builder, bool? value) =>
			builder.Expression(builder.Factory.Bool(value));
	}
}
