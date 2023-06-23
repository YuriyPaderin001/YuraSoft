using System;
using System.Collections.Generic;

using YuraSoft.QueryBuilder.Common;

namespace YuraSoft.QueryBuilder.PostgreSql
{
    public static class ColumnBuilderExtensions
    {
		private static readonly ExpressionFactory _factory = ExpressionFactory.Instance;

        #region AnyFunction methods

        public static ColumnBuilder Any(this ColumnBuilder builder, string? alias, params sbyte[] values) => builder.Column(_factory.Any(values), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, string? alias, params short[] values) => builder.Column(_factory.Any(values), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, string? alias, params int[] values) => builder.Column(_factory.Any(values), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, string? alias, params long[] values) => builder.Column(_factory.Any(values), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, string? alias, params float[] values) => builder.Column(_factory.Any(values), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, string? alias, params double[] values) => builder.Column(_factory.Any(values), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, string? alias, params decimal[] values) => builder.Column(_factory.Any(values), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, string? alias, params DateTime[] values) => builder.Column(_factory.Any(values), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, string? alias, string format, params DateTime[] values) => builder.Column(_factory.Any(format, values), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, string? alias, params string[] values) => builder.Column(_factory.Any(values), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, string? alias, params bool[] values) => builder.Column(_factory.Any(values), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, string? alias, params IExpression[] expressions) => builder.Column(_factory.Any(expressions), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, IEnumerable<sbyte> values, string? alias = null) => builder.Column(_factory.Any(values), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, IEnumerable<short> values, string? alias = null) => builder.Column(_factory.Any(values), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, IEnumerable<int> values, string? alias = null) => builder.Column(_factory.Any(values), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, IEnumerable<long> values, string? alias = null) => builder.Column(_factory.Any(values), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, IEnumerable<float> values, string? alias = null) => builder.Column(_factory.Any(values), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, IEnumerable<double> values, string? alias = null) => builder.Column(_factory.Any(values), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, IEnumerable<decimal> values, string? alias = null) => builder.Column(_factory.Any(values), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, IEnumerable<DateTime> values, string? alias = null) => builder.Column(_factory.Any(values), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, IEnumerable<DateTime> values, string format, string? alias) => builder.Column(_factory.Any(values, format), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, IEnumerable<string> values, string? alias = null) => builder.Column(_factory.Any(values), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, IEnumerable<bool> values, string? alias = null) => builder.Column(_factory.Any(values), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, Action<ExpressionBuilder> expressionAction, string? alias = null) => builder.Column(_factory.Any(expressionAction), alias);
        public static ColumnBuilder Any(this ColumnBuilder builder, IEnumerable<IExpression> expressions, string? alias = null) => builder.Column(_factory.Any(expressions), alias);

        #endregion AnyFunction methods

        public static ColumnBuilder ArrayAgg(this ColumnBuilder builder, string columnName, string? alias = null) =>
            builder.Column(_factory.ArrayAgg(columnName), alias);

        public static ColumnBuilder ArrayAgg(this ColumnBuilder builder, string columnName, string columnTableName, string? alias = null) =>
            builder.Column(_factory.ArrayAgg(columnName, columnTableName), alias);

        public static ColumnBuilder ArrayAgg(this ColumnBuilder builder, string columnName, ISource? columnSource, string? alias = null) =>
            builder.Column(_factory.ArrayAgg(columnName, columnSource), alias);

        public static ColumnBuilder ArrayAgg(this ColumnBuilder builder, Func<ExpressionFactory, IExpression> expressionFunction, string? alias = null) =>
            builder.Column(_factory.ArrayAgg(expressionFunction), alias);

        public static ColumnBuilder ArrayAgg(this ColumnBuilder builder, IExpression expression, string? alias = null) =>
            builder.Column(_factory.ArrayAgg(expression), alias);

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

        public static ColumnBuilder YearInterval(this ColumnBuilder builder, int years, string? alias = null) => builder.Column(_factory.YearInterval(years), alias);
        public static ColumnBuilder MonthInterval(this ColumnBuilder builder, int months, string? alias = null) => builder.Column(_factory.MonthInterval(months), alias);
        public static ColumnBuilder DayInterval(this ColumnBuilder builder, int days, string? alias = null) => builder.Column(_factory.DayInterval(days), alias);
        public static ColumnBuilder HourInterval(this ColumnBuilder builder, int hours, string? alias = null) => builder.Column(_factory.HourInterval(hours), alias);
        public static ColumnBuilder MinuteInterval(this ColumnBuilder builder, int minutes, string? alias = null) => builder.Column(_factory.MinuteInterval(minutes), alias);
        public static ColumnBuilder SecondInterval(this ColumnBuilder builder, int seconds, string? alias = null) => builder.Column(_factory.SecondInterval(seconds), alias);
        public static ColumnBuilder MillisecondInterval(this ColumnBuilder builder, int milliseconds, string? alias = null) => builder.Column(_factory.MillisecondInterval(milliseconds), alias);
        public static ColumnBuilder Interval(this ColumnBuilder builder, int years = 0, int months = 0, int days = 0, int hours = 0, int minutes = 0, int seconds = 0, int milliseconds = 0, string? alias = null) =>
            builder.Column(_factory.Interval(years, months, days, hours, minutes, seconds, milliseconds), alias);
    }
}
