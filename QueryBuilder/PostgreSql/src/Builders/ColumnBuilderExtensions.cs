using System;
using YuraSoft.QueryBuilder.Common;

namespace YuraSoft.QueryBuilder.PostgreSql
{
    public static class ColumnBuilderExtensions
    {
		private static readonly ExpressionFactory _factory = ExpressionFactory.Instance;

		public static ColumnBuilder Coalesce(this ColumnBuilder builder, string column, bool value, string? alias = null) =>
			builder.Column(_factory.Coalesce(column, value), alias);

		public static ColumnBuilder Coalesce(this ColumnBuilder builder, string column, string table, bool value, string? alias = null) =>
			builder.Column(_factory.Coalesce(column, table, value), alias);

		public static ColumnBuilder Coalesce(this ColumnBuilder builder, string column, ISource source, bool value, string? alias = null) =>
			builder.Column(_factory.Coalesce(column, source, value), alias);

		public static ColumnBuilder Coalesce(this ColumnBuilder builder, Func<ExpressionFactory, IExpression> expressionFunction, bool value, string? alias = null) =>
			builder.Column(_factory.Coalesce(expressionFunction, value), alias);

		public static ColumnBuilder Coalesce(this ColumnBuilder builder, IExpression expression, bool value, string? alias = null) =>
			builder.Column(_factory.Coalesce(expression, value), alias);

		public static ColumnBuilder True(this ColumnBuilder builder, string? alias = null) =>
			builder.Column(_factory.True(), alias);

		public static ColumnBuilder False(this ColumnBuilder builder, string? alias = null) =>
			builder.Column(_factory.False(), alias);

		public static ColumnBuilder Bool(this ColumnBuilder builder, bool value, string? alias = null) => 
			builder.Column(_factory.Bool(value), alias);

		public static ColumnBuilder Bool(this ColumnBuilder builder, bool? value, string? alias = null) =>
			builder.Column(_factory.Bool(value), alias);
	}
}
