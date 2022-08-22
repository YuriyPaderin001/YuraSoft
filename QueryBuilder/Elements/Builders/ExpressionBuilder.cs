using System;
using System.Collections.Generic;

using YuraSoft.QueryBuilder.Interfaces;

namespace YuraSoft.QueryBuilder
{
	public class ExpressionBuilder
	{
		private readonly List<IExpression> _expressions = new List<IExpression>();

		public ExpressionBuilder Int8(sbyte value) => AddExpression(new Int8Value(value));
		public ExpressionBuilder Int16(short value) => AddExpression(new Int16Value(value));
		public ExpressionBuilder Int32(int value) => AddExpression(new Int32Value(value));
		public ExpressionBuilder Int64(long value) => AddExpression(new Int64Value(value));
		public ExpressionBuilder Float(float value) => AddExpression(new FloatValue(value));
		public ExpressionBuilder Double(double value) => AddExpression(new DoubleValue(value));
		public ExpressionBuilder Decimal(decimal value) => AddExpression(new DecimalValue(value));
		public ExpressionBuilder DateTime(DateTime value, string? format = null) => AddExpression(new DateTimeValue(value, format));
		public ExpressionBuilder String(string value) => AddExpression(new StringValue(value));
		public ExpressionBuilder Null() => AddExpression(new NullValue());

		public List<IExpression> Build() => _expressions;

		private ExpressionBuilder AddExpression(IExpression expression)
		{
			_expressions.Add(expression);

			return this;
		}
	}
}
