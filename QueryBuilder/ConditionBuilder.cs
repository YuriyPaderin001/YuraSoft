using System;
using System.Collections.Generic;
using System.Linq;

using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class ConditionBuilder
	{
		private readonly List<ICondition> _conditions = new List<ICondition>();

		public ConditionBuilder Equal(IExpression expression, sbyte value) => Add(new EqualCondition(expression, new Int8Value(value)));
		public ConditionBuilder Equal(IExpression expression, short value) => Add(new EqualCondition(expression, new Int16Value(value)));
		public ConditionBuilder Equal(IExpression expression, int value) => Add(new EqualCondition(expression, new Int32Value(value)));
		public ConditionBuilder Equal(IExpression expression, long value) => Add(new EqualCondition(expression, new Int64Value(value)));
		public ConditionBuilder Equal(IExpression expression, float value) => Add(new EqualCondition(expression, new FloatValue(value)));
		public ConditionBuilder Equal(IExpression expression, double value) => Add(new EqualCondition(expression, new DoubleValue(value)));
		public ConditionBuilder Equal(IExpression expression, decimal value) => Add(new EqualCondition(expression, new DecimalValue(value)));
		public ConditionBuilder Equal(IExpression expression, DateTime value, string? format = null) => Add(new EqualCondition(expression, new DateTimeValue(value, format)));
		public ConditionBuilder Equal(IExpression expression, string value) => Add(new EqualCondition(expression, new StringValue(value)));
		public ConditionBuilder Equal(IExpression leftExpression, IExpression rightExpression) => Add(new EqualCondition(leftExpression, rightExpression));

		public ConditionBuilder NotEqual(IExpression expression, sbyte value) => Add(new NotEqualCondition(expression, new Int8Value(value)));
		public ConditionBuilder NotEqual(IExpression expression, short value) => Add(new NotEqualCondition(expression, new Int16Value(value)));
		public ConditionBuilder NotEqual(IExpression expression, int value) => Add(new NotEqualCondition(expression, new Int32Value(value)));
		public ConditionBuilder NotEqual(IExpression expression, long value) => Add(new NotEqualCondition(expression, new Int64Value(value)));
		public ConditionBuilder NotEqual(IExpression expression, float value) => Add(new NotEqualCondition(expression, new FloatValue(value)));
		public ConditionBuilder NotEqual(IExpression expression, double value) => Add(new NotEqualCondition(expression, new DoubleValue(value)));
		public ConditionBuilder NotEqual(IExpression expression, decimal value) => Add(new NotEqualCondition(expression, new DecimalValue(value)));
		public ConditionBuilder NotEqual(IExpression expression, DateTime value, string? format = null) => Add(new NotEqualCondition(expression, new DateTimeValue(value, format)));
		public ConditionBuilder NotEqual(IExpression expression, string value) => Add(new NotEqualCondition(expression, new StringValue(value)));
		public ConditionBuilder NotEqual(IExpression leftExpression, IExpression rightExpression) => Add(new NotEqualCondition(leftExpression, rightExpression));

		public ConditionBuilder Greater(IExpression expression, sbyte value) => Add(new GreaterCondition(expression, new Int8Value(value)));
		public ConditionBuilder Greater(IExpression expression, short value) => Add(new GreaterCondition(expression, new Int16Value(value)));
		public ConditionBuilder Greater(IExpression expression, int value) => Add(new GreaterCondition(expression, new Int32Value(value)));
		public ConditionBuilder Greater(IExpression expression, long value) => Add(new GreaterCondition(expression, new Int64Value(value)));
		public ConditionBuilder Greater(IExpression expression, float value) => Add(new GreaterCondition(expression, new FloatValue(value)));
		public ConditionBuilder Greater(IExpression expression, double value) => Add(new GreaterCondition(expression, new DoubleValue(value)));
		public ConditionBuilder Greater(IExpression expression, decimal value) => Add(new GreaterCondition(expression, new DecimalValue(value)));
		public ConditionBuilder Greater(IExpression expression, DateTime value, string? format = null) => Add(new GreaterCondition(expression, new DateTimeValue(value, format)));
		public ConditionBuilder Greater(IExpression expression, string value) => Add(new GreaterCondition(expression, new StringValue(value)));
		public ConditionBuilder Greater(IExpression leftExpression, IExpression rightExpression) => Add(new GreaterCondition(leftExpression, rightExpression));

		public ConditionBuilder GreaterOrEqual(IExpression expression, sbyte value) => Add(new GreaterOrEqualCondition(expression, new Int8Value(value)));
		public ConditionBuilder GreaterOrEqual(IExpression expression, short value) => Add(new GreaterOrEqualCondition(expression, new Int16Value(value)));
		public ConditionBuilder GreaterOrEqual(IExpression expression, int value) => Add(new GreaterOrEqualCondition(expression, new Int32Value(value)));
		public ConditionBuilder GreaterOrEqual(IExpression expression, long value) => Add(new GreaterOrEqualCondition(expression, new Int64Value(value)));
		public ConditionBuilder GreaterOrEqual(IExpression expression, float value) => Add(new GreaterOrEqualCondition(expression, new FloatValue(value)));
		public ConditionBuilder GreaterOrEqual(IExpression expression, double value) => Add(new GreaterOrEqualCondition(expression, new DoubleValue(value)));
		public ConditionBuilder GreaterOrEqual(IExpression expression, decimal value) => Add(new GreaterOrEqualCondition(expression, new DecimalValue(value)));
		public ConditionBuilder GreaterOrEqual(IExpression expression, DateTime value, string? format = null) => Add(new GreaterOrEqualCondition(expression, new DateTimeValue(value, format)));
		public ConditionBuilder GreaterOrEqual(IExpression expression, string value) => Add(new GreaterOrEqualCondition(expression, new StringValue(value)));
		public ConditionBuilder GreaterOrEqual(IExpression leftExpression, IExpression rightExpression) => Add(new GreaterOrEqualCondition(leftExpression, rightExpression));

		public ConditionBuilder Less(IExpression expression, sbyte value) => Add(new LessCondition(expression, new Int8Value(value)));
		public ConditionBuilder Less(IExpression expression, short value) => Add(new LessCondition(expression, new Int16Value(value)));
		public ConditionBuilder Less(IExpression expression, int value) => Add(new LessCondition(expression, new Int32Value(value)));
		public ConditionBuilder Less(IExpression expression, long value) => Add(new LessCondition(expression, new Int64Value(value)));
		public ConditionBuilder Less(IExpression expression, float value) => Add(new LessCondition(expression, new FloatValue(value)));
		public ConditionBuilder Less(IExpression expression, double value) => Add(new LessCondition(expression, new DoubleValue(value)));
		public ConditionBuilder Less(IExpression expression, decimal value) => Add(new LessCondition(expression, new DecimalValue(value)));
		public ConditionBuilder Less(IExpression expression, DateTime value, string? format = null) => Add(new LessCondition(expression, new DateTimeValue(value, format)));
		public ConditionBuilder Less(IExpression expression, string value) => Add(new LessCondition(expression, new StringValue(value)));
		public ConditionBuilder Less(IExpression leftExpression, IExpression rightExpression) => Add(new LessCondition(leftExpression, rightExpression));

		public ConditionBuilder LessOrEqual(IExpression expression, sbyte value) => Add(new LessOrEqualCondition(expression, new Int8Value(value)));
		public ConditionBuilder LessOrEqual(IExpression expression, short value) => Add(new LessOrEqualCondition(expression, new Int16Value(value)));
		public ConditionBuilder LessOrEqual(IExpression expression, int value) => Add(new LessOrEqualCondition(expression, new Int32Value(value)));
		public ConditionBuilder LessOrEqual(IExpression expression, long value) => Add(new LessOrEqualCondition(expression, new Int64Value(value)));
		public ConditionBuilder LessOrEqual(IExpression expression, float value) => Add(new LessOrEqualCondition(expression, new FloatValue(value)));
		public ConditionBuilder LessOrEqual(IExpression expression, double value) => Add(new LessOrEqualCondition(expression, new DoubleValue(value)));
		public ConditionBuilder LessOrEqual(IExpression expression, decimal value) => Add(new LessOrEqualCondition(expression, new DecimalValue(value)));
		public ConditionBuilder LessOrEqual(IExpression expression, DateTime value, string? format = null) => Add(new LessOrEqualCondition(expression, new DateTimeValue(value, format)));
		public ConditionBuilder LessOrEqual(IExpression expression, string value) => Add(new LessOrEqualCondition(expression, new StringValue(value)));
		public ConditionBuilder LessOrEqual(IExpression leftExpression, IExpression rightExpression) => Add(new LessOrEqualCondition(leftExpression, rightExpression));

		public ConditionBuilder IsNull(IExpression expression) => Add(new IsNullCondition(expression));

		public ConditionBuilder IsNotNull(IExpression expression) => Add(new IsNotNullCondition(expression));

		public ConditionBuilder In(IExpression expression, params sbyte[] values) => Add(new InCondition(expression, values.Select(v => new Int8Value(v))));
		public ConditionBuilder In(IExpression expression, params short[] values) => Add(new InCondition(expression, values.Select(v => new Int16Value(v))));
		public ConditionBuilder In(IExpression expression, params int[] values) => Add(new InCondition(expression, values.Select(v => new Int32Value(v))));
		public ConditionBuilder In(IExpression expression, params long[] values) => Add(new InCondition(expression, values.Select(v => new Int64Value(v))));
		public ConditionBuilder In(IExpression expression, params float[] values) => Add(new InCondition(expression, values.Select(v => new FloatValue(v))));
		public ConditionBuilder In(IExpression expression, params double[] values) => Add(new InCondition(expression, values.Select(v => new DoubleValue(v))));
		public ConditionBuilder In(IExpression expression, params decimal[] values) => Add(new InCondition(expression, values.Select(v => new DecimalValue(v))));
		public ConditionBuilder In(IExpression expression, params DateTime[] values) => Add(new InCondition(expression, values.Select(v => new DateTimeValue(v))));
		public ConditionBuilder In(IExpression expression, string format, params DateTime[] values) => Add(new InCondition(expression, values.Select(v => new DateTimeValue(v, format))));
		public ConditionBuilder In(IExpression expression, params string[] values) => Add(new InCondition(expression, values.Select(v => new StringValue(v))));
		public ConditionBuilder In(IExpression expression, params IExpression[] values) => Add(new InCondition(expression, values));
		public ConditionBuilder In(IExpression expression, IEnumerable<sbyte> values) => Add(new InCondition(expression, values.Select(v => new Int8Value(v))));
		public ConditionBuilder In(IExpression expression, IEnumerable<short> values) => Add(new InCondition(expression, values.Select(v => new Int16Value(v))));
		public ConditionBuilder In(IExpression expression, IEnumerable<int> values) => Add(new InCondition(expression, values.Select(v => new Int32Value(v))));
		public ConditionBuilder In(IExpression expression, IEnumerable<long> values) => Add(new InCondition(expression, values.Select(v => new Int64Value(v))));
		public ConditionBuilder In(IExpression expression, IEnumerable<float> values) => Add(new InCondition(expression, values.Select(v => new FloatValue(v))));
		public ConditionBuilder In(IExpression expression, IEnumerable<double> values) => Add(new InCondition(expression, values.Select(v => new DoubleValue(v))));
		public ConditionBuilder In(IExpression expression, IEnumerable<decimal> values) => Add(new InCondition(expression, values.Select(v => new DecimalValue(v))));
		public ConditionBuilder In(IExpression expression, IEnumerable<DateTime> values, string format) => Add(new InCondition(expression, values.Select(v => new DateTimeValue(v, format))));
		public ConditionBuilder In(IExpression expression, IEnumerable<string> values) => Add(new InCondition(expression, values.Select(v => new StringValue(v))));
		public ConditionBuilder In(IExpression expression, IEnumerable<IExpression> values) => Add(new InCondition(expression, values));
		
		public ConditionBuilder NotIn(IExpression expression, params sbyte[] values) => Add(new NotInCondition(expression, values.Select(v => new Int8Value(v))));
		public ConditionBuilder NotIn(IExpression expression, params short[] values) => Add(new NotInCondition(expression, values.Select(v => new Int16Value(v))));
		public ConditionBuilder NotIn(IExpression expression, params int[] values) => Add(new NotInCondition(expression, values.Select(v => new Int32Value(v))));
		public ConditionBuilder NotIn(IExpression expression, params long[] values) => Add(new NotInCondition(expression, values.Select(v => new Int64Value(v))));
		public ConditionBuilder NotIn(IExpression expression, params float[] values) => Add(new NotInCondition(expression, values.Select(v => new FloatValue(v))));
		public ConditionBuilder NotIn(IExpression expression, params double[] values) => Add(new NotInCondition(expression, values.Select(v => new DoubleValue(v))));
		public ConditionBuilder NotIn(IExpression expression, params decimal[] values) => Add(new NotInCondition(expression, values.Select(v => new DecimalValue(v))));
		public ConditionBuilder NotIn(IExpression expression, params DateTime[] values) => Add(new NotInCondition(expression, values.Select(v => new DateTimeValue(v))));
		public ConditionBuilder NotIn(IExpression expression, string format, params DateTime[] values) => Add(new NotInCondition(expression, values.Select(v => new DateTimeValue(v, format))));
		public ConditionBuilder NotIn(IExpression expression, params string[] values) => Add(new NotInCondition(expression, values.Select(v => new StringValue(v))));
		public ConditionBuilder NotIn(IExpression expression, params IExpression[] values) => Add(new NotInCondition(expression, values));
		public ConditionBuilder NotIn(IExpression expression, IEnumerable<sbyte> values) => Add(new NotInCondition(expression, values.Select(v => new Int8Value(v))));
		public ConditionBuilder NotIn(IExpression expression, IEnumerable<short> values) => Add(new NotInCondition(expression, values.Select(v => new Int16Value(v))));
		public ConditionBuilder NotIn(IExpression expression, IEnumerable<int> values) => Add(new NotInCondition(expression, values.Select(v => new Int32Value(v))));
		public ConditionBuilder NotIn(IExpression expression, IEnumerable<long> values) => Add(new NotInCondition(expression, values.Select(v => new Int64Value(v))));
		public ConditionBuilder NotIn(IExpression expression, IEnumerable<float> values) => Add(new NotInCondition(expression, values.Select(v => new FloatValue(v))));
		public ConditionBuilder NotIn(IExpression expression, IEnumerable<double> values) => Add(new NotInCondition(expression, values.Select(v => new DoubleValue(v))));
		public ConditionBuilder NotIn(IExpression expression, IEnumerable<decimal> values) => Add(new NotInCondition(expression, values.Select(v => new DecimalValue(v))));
		public ConditionBuilder NotIn(IExpression expression, IEnumerable<DateTime> values, string format) => Add(new NotInCondition(expression, values.Select(v => new DateTimeValue(v, format))));
		public ConditionBuilder NotIn(IExpression expression, IEnumerable<string> values) => Add(new NotInCondition(expression, values.Select(v => new StringValue(v))));
		public ConditionBuilder NotIn(IExpression expression, IEnumerable<IExpression> values) => Add(new NotInCondition(expression, values));

		public ConditionBuilder Like(IExpression expression, string pattern) => Add(new LikeCondition(expression, pattern));

		public ConditionBuilder NotLike(IExpression expression, string pattern) => Add(new NotLikeCondition(expression, pattern));

		public ConditionBuilder And(params ICondition[] conditions) => Add(new AndCondition(conditions));
		public ConditionBuilder And(IEnumerable<ICondition> conditions) => Add(new AndCondition(conditions));
		public ConditionBuilder And(Action<ConditionBuilder> buildConditionMethod)
		{
			ConditionBuilder builder = new ConditionBuilder();
			buildConditionMethod.Invoke(builder);

			return Add(builder.BuildAnd());
		}

		public ConditionBuilder Or(params ICondition[] conditions) => Add(new OrCondition(conditions));
		public ConditionBuilder Or(IEnumerable<ICondition> conditions) => Add(new OrCondition(conditions));
		public ConditionBuilder Or(Action<ConditionBuilder> buildConditionMethod)
		{
			ConditionBuilder builder = new ConditionBuilder();
			buildConditionMethod.Invoke(builder);

			return Add(builder.BuildOr());
		}

		public ICondition Build() => BuildAnd();

		internal ICondition BuildAnd()
		{
			if (_conditions.Count == 0)
			{
				// TODO: Add normal error message
				throw new ArgumentShouldNotBeNullException(nameof(_conditions));
			}
			else if (_conditions.Count == 1)
			{
				return _conditions[0];
			}
			else
			{
				return new AndCondition(_conditions);
			}
		}

		internal ICondition BuildOr()
		{
			if (_conditions.Count == 0)
			{
				throw new ArgumentShouldNotBeNullException(nameof(_conditions));
			}
			else if (_conditions.Count == 1)
			{
				return _conditions[0];
			}
			else
			{
				return new OrCondition(_conditions);
			}
		}

		private ConditionBuilder Add(ICondition condition)
		{
			_conditions.Add(condition);

			return this;
		}
	}
}
