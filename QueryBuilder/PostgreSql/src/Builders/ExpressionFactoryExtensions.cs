using System;
using System.Collections.Generic;
using System.Linq;

using YuraSoft.QueryBuilder.Common;

namespace YuraSoft.QueryBuilder.PostgreSql
{
    public static class ExpressionFactoryExtensions
    {
        #region Functions factory methods

        #region CountWindowFunction factory methods

        public static CountWindowFunction Count(this ExpressionFactory factory, IExpression expression, ICondition? filter, IEnumerable<IColumn>? partitionBy, Action<OrderByBuilder> orderByAction) =>
            new CountWindowFunction(expression, filter, partitionBy, factory.OrderBy(orderByAction));

        public static CountWindowFunction Count(this ExpressionFactory _, IExpression expression, ICondition? filter, IEnumerable<IColumn>? partitionBy, IEnumerable<IOrderBy>? orderBy) =>
            new CountWindowFunction(expression, filter, partitionBy, orderBy);

        #endregion CountWindowFunction factory methods

        #endregion Functions factory methods

        public static EqualCondition True(this ExpressionFactory factory, IExpression expression) =>
			Equal(factory, expression, value: true);

		public static EqualCondition True(this ExpressionFactory factory, Func<ExpressionFactory, IExpression> expressionFunction) =>
			Equal(factory, expressionFunction, value: true);

		public static EqualCondition True(this ExpressionFactory factory, string column) =>
			Equal(factory, column, value: true);

        public static EqualCondition True(this ExpressionFactory factory, string column, string table) =>
            Equal(factory, column, table, value: true);

        public static EqualCondition True(this ExpressionFactory factory, string column, ISource source) =>
            Equal(factory, column, source, value: true);

        public static EqualCondition False(this ExpressionFactory factory, IExpression expression) =>
            Equal(factory, expression, value: false);

        public static EqualCondition False(this ExpressionFactory factory, Func<ExpressionFactory, IExpression> expressionFunction) =>
            Equal(factory, expressionFunction, value: false);

        public static EqualCondition False(this ExpressionFactory factory, string column) =>
            Equal(factory, column, value: false);

        public static EqualCondition False(this ExpressionFactory factory, string column, string table) =>
            Equal(factory, column, table, value: false);

        public static EqualCondition False(this ExpressionFactory factory, string column, ISource source) =>
            Equal(factory, column, source, value: false);

		public static EqualCondition Equal(this ExpressionFactory factory, IExpression expression, bool value) =>
            factory.Equal(expression, Bool(factory, value));

        public static EqualCondition Equal(this ExpressionFactory factory, Func<ExpressionFactory, IExpression> expressionFunction, bool value) =>
            factory.Equal(expressionFunction, Bool(factory, value));

        public static EqualCondition Equal(this ExpressionFactory factory, string column, bool value) =>
            factory.Equal(column, Bool(factory, value));

        public static EqualCondition Equal(this ExpressionFactory factory, string column, string table, bool value) =>
            factory.Equal(column, table, Bool(factory, value));

        public static EqualCondition Equal(this ExpressionFactory factory, string column, ISource source, bool value) =>
            factory.Equal(column, source, Bool(factory, value));

        public static NotEqualCondition NotEqual(this ExpressionFactory factory, IExpression expression, bool value) =>
            factory.NotEqual(expression, Bool(factory, value));

        public static NotEqualCondition NotEqual(this ExpressionFactory factory, Func<ExpressionFactory, IExpression> expressionFunction, bool value) =>
            factory.NotEqual(expressionFunction, Bool(factory, value));

        public static NotEqualCondition NotEqual(this ExpressionFactory factory, string column, bool value) =>
            factory.NotEqual(column, Bool(factory, value));

        public static NotEqualCondition NotEqual(this ExpressionFactory factory, string column, string table, bool value) =>
            factory.NotEqual(column, table, Bool(factory, value));

        public static NotEqualCondition NotEqual(this ExpressionFactory factory, string column, ISource source, bool value) =>
            factory.NotEqual(column, source, Bool(factory, value));

        #region Function methods

        #region AnyFunction methods

        public static AnyFunction Any(this ExpressionFactory _, params sbyte[] values) => new AnyFunction(values.Select(v => new Int8Value(v)));
        public static AnyFunction Any(this ExpressionFactory _, params short[] values) => new AnyFunction(values.Select(v => new Int16Value(v)));
        public static AnyFunction Any(this ExpressionFactory _, params int[] values) => new AnyFunction(values.Select(v => new Int32Value(v)));
        public static AnyFunction Any(this ExpressionFactory _, params long[] values) => new AnyFunction(values.Select(v => new Int64Value(v)));
        public static AnyFunction Any(this ExpressionFactory _, params float[] values) => new AnyFunction(values.Select(v => new FloatValue(v)));
        public static AnyFunction Any(this ExpressionFactory _, params double[] values) => new AnyFunction(values.Select(v => new DoubleValue(v)));
        public static AnyFunction Any(this ExpressionFactory _, params decimal[] values) => new AnyFunction(values.Select(v => new DecimalValue(v)));
        public static AnyFunction Any(this ExpressionFactory _, params DateTime[] values) => new AnyFunction(values.Select(v => new DateTimeValue(v)));
        public static AnyFunction Any(this ExpressionFactory _, string format, params DateTime[] values) => new AnyFunction(values.Select(v => new DateTimeValue(v, format)));
        public static AnyFunction Any(this ExpressionFactory _, params string[] values) => new AnyFunction(values.Select(v => new StringValue(v)));
        public static AnyFunction Any(this ExpressionFactory _, params bool[] values) => new AnyFunction(values.Select(v => new BoolValue(v)));
        public static AnyFunction Any(this ExpressionFactory _, params IExpression[] expressions) => new AnyFunction(expressions);
        public static AnyFunction Any(this ExpressionFactory _, IEnumerable<sbyte> values) => new AnyFunction(values.Select(v => new Int8Value(v)));
        public static AnyFunction Any(this ExpressionFactory _, IEnumerable<short> values) => new AnyFunction(values.Select(v => new Int16Value(v)));
        public static AnyFunction Any(this ExpressionFactory _, IEnumerable<int> values) => new AnyFunction(values.Select(v => new Int32Value(v)));
        public static AnyFunction Any(this ExpressionFactory _, IEnumerable<long> values) => new AnyFunction(values.Select(v => new Int64Value(v)));
        public static AnyFunction Any(this ExpressionFactory _, IEnumerable<float> values) => new AnyFunction(values.Select(v => new FloatValue(v)));
        public static AnyFunction Any(this ExpressionFactory _, IEnumerable<double> values) => new AnyFunction(values.Select(v => new DoubleValue(v)));
        public static AnyFunction Any(this ExpressionFactory _, IEnumerable<decimal> values) => new AnyFunction(values.Select(v => new DecimalValue(v)));
        public static AnyFunction Any(this ExpressionFactory _, IEnumerable<DateTime> values, string? format = null) => new AnyFunction(values.Select(v => new DateTimeValue(v, format)));
        public static AnyFunction Any(this ExpressionFactory _, IEnumerable<string> values) => new AnyFunction(values.Select(v => new StringValue(v)));
        public static AnyFunction Any(this ExpressionFactory _, IEnumerable<bool> values) => new AnyFunction(values.Select(v => new BoolValue(v)));
        public static AnyFunction Any(this ExpressionFactory factory, Action<ExpressionBuilder> expressionAction) => new AnyFunction(factory.Expressions(expressionAction));
        public static AnyFunction Any(this ExpressionFactory _, IEnumerable<IExpression> expressions) => new AnyFunction(expressions);

        #endregion AnyFunction methods

        public static ArrayAggFunction ArrayAgg(this ExpressionFactory factory, string columnName) =>
            new ArrayAggFunction(factory.Column(columnName));

        public static ArrayAggFunction ArrayAgg(this ExpressionFactory factory, string columnName, string columnTableName) =>
            new ArrayAggFunction(factory.Column(columnName, new Table(columnTableName)));

        public static ArrayAggFunction ArrayAgg(this ExpressionFactory factory, string columnName, ISource? columnSource) =>
            new ArrayAggFunction(factory.Column(columnName, columnSource));

        public static ArrayAggFunction ArrayAgg(this ExpressionFactory factory, Func<ExpressionFactory, IExpression> expressionFunction) =>
            new ArrayAggFunction(factory.Expression(expressionFunction));

        public static ArrayAggFunction ArrayAgg(this ExpressionFactory _, IExpression expression) =>
            new ArrayAggFunction(expression);

        public static CoalesceFunction Coalesce(this ExpressionFactory factory, string column, bool value) =>
            factory.Coalesce(factory.Column(column), Bool(factory, value));

        public static CoalesceFunction Coalesce(this ExpressionFactory factory, string column, string table, bool value) =>
            factory.Coalesce(factory.Column(column, alias: null, table), Bool(factory, value));

        public static CoalesceFunction Coalesce(this ExpressionFactory factory, string column, ISource source, bool value) =>
            factory.Coalesce(factory.Column(column, source), Bool(factory, value));

        public static CoalesceFunction Coalesce(this ExpressionFactory factory, Func<ExpressionFactory, IExpression> expressionFunction, bool value) =>
            factory.Coalesce(factory.Expression(expressionFunction), Bool(factory, value));

        public static CoalesceFunction Coalesce(this ExpressionFactory factory, IExpression expression, bool value) =>
            factory.Coalesce(expression, Bool(factory, value));

        #endregion Function methods

        public static BoolValue True(this ExpressionFactory factory) => Bool(factory, value: true);
        public static BoolValue False(this ExpressionFactory factory) => Bool(factory, value: false);

        public static IValue Bool(this ExpressionFactory factory, bool? value) => value.HasValue
            ? Bool(factory, value) : factory.Null();

		public static BoolValue Bool(this ExpressionFactory _, bool value) => new BoolValue(value);

        public static IntervalValue YearInterval(this ExpressionFactory _, int years) => Interval(_, years: years);
        public static IntervalValue MonthInterval(this ExpressionFactory _, int months) => Interval(_, months: months);
        public static IntervalValue DayInterval(this ExpressionFactory _, int days) => Interval(_, days: days);
        public static IntervalValue HourInterval(this ExpressionFactory _, int hours) => Interval(_, hours: hours);
        public static IntervalValue MinuteInterval(this ExpressionFactory _, int minutes) => Interval(_, minutes: minutes);
        public static IntervalValue SecondInterval(this ExpressionFactory _, int seconds) => Interval(_, seconds: seconds);
        public static IntervalValue MillisecondInterval(this ExpressionFactory _, int milliseconds) => Interval(_, milliseconds: milliseconds);
        public static IntervalValue Interval(this ExpressionFactory _, int years = 0, int months = 0, int days = 0, int hours = 0, int minutes = 0, int seconds = 0, int milliseconds = 0) =>
            new IntervalValue(years, months, days, hours, minutes, seconds, milliseconds);
	}
}
