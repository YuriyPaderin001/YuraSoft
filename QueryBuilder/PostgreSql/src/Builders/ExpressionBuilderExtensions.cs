using System;
using System.Collections.Generic;

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

        #region AnyFunction methods

        public static ExpressionBuilder Any(this ExpressionBuilder builder, params sbyte[] values) => builder.Expression(builder.Factory.Any(values));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, params short[] values) => builder.Expression(builder.Factory.Any(values));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, params int[] values) => builder.Expression(builder.Factory.Any(values));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, params long[] values) => builder.Expression(builder.Factory.Any(values));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, params float[] values) => builder.Expression(builder.Factory.Any(values));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, params double[] values) => builder.Expression(builder.Factory.Any(values));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, params decimal[] values) => builder.Expression(builder.Factory.Any(values));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, params DateTime[] values) => builder.Expression(builder.Factory.Any(values));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, string format, params DateTime[] values) => builder.Expression(builder.Factory.Any(format, values));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, params string[] values) => builder.Expression(builder.Factory.Any(values));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, params bool[] values) => builder.Expression(builder.Factory.Any(values));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, params IExpression[] expressions) => builder.Expression(builder.Factory.Any(expressions));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, IEnumerable<sbyte> values) => builder.Expression(builder.Factory.Any(values));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, IEnumerable<short> values) => builder.Expression(builder.Factory.Any(values));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, IEnumerable<int> values) => builder.Expression(builder.Factory.Any(values));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, IEnumerable<long> values) => builder.Expression(builder.Factory.Any(values));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, IEnumerable<float> values) => builder.Expression(builder.Factory.Any(values));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, IEnumerable<double> values) => builder.Expression(builder.Factory.Any(values));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, IEnumerable<decimal> values) => builder.Expression(builder.Factory.Any(values));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, IEnumerable<DateTime> values, string? format = null) => builder.Expression(builder.Factory.Any(values, format));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, IEnumerable<string> values) => builder.Expression(builder.Factory.Any(values));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, IEnumerable<bool> values) => builder.Expression(builder.Factory.Any(values));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, Action<ExpressionBuilder> expressionAction) => builder.Expression(builder.Factory.Any(expressionAction));
        public static ExpressionBuilder Any(this ExpressionBuilder builder, IEnumerable<IExpression> expressions) => builder.Expression(builder.Factory.Any(expressions));

        #endregion AnyFunction methods

        public static ExpressionBuilder ArrayAgg(this ExpressionBuilder builder, string columnName) =>
            builder.Expression(builder.Factory.ArrayAgg(columnName));

        public static ExpressionBuilder ArrayAgg(this ExpressionBuilder builder, string columnName, string columnTableName) =>
            builder.Expression(builder.Factory.ArrayAgg(columnName, columnTableName));

        public static ExpressionBuilder ArrayAgg(this ExpressionBuilder builder, string columnName, ISource? columnSource) =>
            builder.Expression(builder.Factory.ArrayAgg(columnName, columnSource));

        public static ExpressionBuilder ArrayAgg(this ExpressionBuilder builder, Func<ExpressionFactory, IExpression> expressionFunction) =>
            builder.Expression(builder.Factory.ArrayAgg(expressionFunction));

        public static ExpressionBuilder ArrayAgg(this ExpressionBuilder builder, IExpression expression) =>
            builder.Expression(builder.Factory.ArrayAgg(expression));

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

        public static ExpressionBuilder YearInterval(this ExpressionBuilder builder, int years) => builder.Expression(builder.Factory.Interval(years));
        public static ExpressionBuilder MonthInterval(this ExpressionBuilder builder, int months) => builder.Expression(builder.Factory.Interval(months));
        public static ExpressionBuilder DayInterval(this ExpressionBuilder builder, int days) => builder.Expression(builder.Factory.Interval(days));
        public static ExpressionBuilder HourInterval(this ExpressionBuilder builder, int hours) => builder.Expression(builder.Factory.Interval(hours));
        public static ExpressionBuilder MinuteInterval(this ExpressionBuilder builder, int minutes) => builder.Expression(builder.Factory.Interval(minutes));
        public static ExpressionBuilder SecondInterval(this ExpressionBuilder builder, int seconds) => builder.Expression(builder.Factory.Interval(seconds));
        public static ExpressionBuilder MillisecondInterval(this ExpressionBuilder builder, int milliseconds) => builder.Expression(builder.Factory.Interval(milliseconds));
        public static ExpressionBuilder Interval(this ExpressionBuilder builder, int years = 0, int months = 0, int days = 0, int hours = 0, int minutes = 0, int seconds = 0, int milliseconds = 0) =>
            builder.Expression(builder.Factory.Interval(years, months, days, hours, minutes, seconds, milliseconds));
    }
}
