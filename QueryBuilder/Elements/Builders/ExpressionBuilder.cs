using System;
using System.Collections.Generic;

using YuraSoft.QueryBuilder.Interfaces;

namespace YuraSoft.QueryBuilder
{
	public class ExpressionBuilder
	{
		private readonly List<IExpression> _expressions = new List<IExpression>();

		public ExpressionBuilder Int8(sbyte value) => Add(new Int8Value(value));
		public ExpressionBuilder Int16(short value) => Add(new Int16Value(value));
		public ExpressionBuilder Int32(int value) => Add(new Int32Value(value));
		public ExpressionBuilder Int64(long value) => Add(new Int64Value(value));
		public ExpressionBuilder Float(float value) => Add(new FloatValue(value));
		public ExpressionBuilder Double(double value) => Add(new DoubleValue(value));
		public ExpressionBuilder Decimal(decimal value) => Add(new DecimalValue(value));
		public ExpressionBuilder DateTime(DateTime value, string? format = null) => Add(new DateTimeValue(value, format));
		public ExpressionBuilder String(string value) => Add(new StringValue(value));
		public ExpressionBuilder String(object value) => Add(new StringValue(value.ToString()!));
		public ExpressionBuilder Null() => Add(new NullValue());
		public ExpressionBuilder Expression(IExpression expression) => Add(expression);

		public List<IExpression> Build() => _expressions;

		private ExpressionBuilder Add(IExpression expression)
		{
			_expressions.Add(expression);

			return this;
		}
	}
}
