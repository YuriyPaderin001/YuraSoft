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

		#region Equal methods

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

		public ConditionBuilder Equal(string column, sbyte value) => Add(new EqualCondition(new SourceColumn(column), new Int8Value(value)));
		public ConditionBuilder Equal(string column, short value) => Add(new EqualCondition(new SourceColumn(column), new Int16Value(value)));
		public ConditionBuilder Equal(string column, int value) => Add(new EqualCondition(new SourceColumn(column), new Int32Value(value)));
		public ConditionBuilder Equal(string column, long value) => Add(new EqualCondition(new SourceColumn(column), new Int64Value(value)));
		public ConditionBuilder Equal(string column, float value) => Add(new EqualCondition(new SourceColumn(column), new FloatValue(value)));
		public ConditionBuilder Equal(string column, double value) => Add(new EqualCondition(new SourceColumn(column), new DoubleValue(value)));
		public ConditionBuilder Equal(string column, decimal value) => Add(new EqualCondition(new SourceColumn(column), new DecimalValue(value)));
		public ConditionBuilder Equal(string column, DateTime value, string? format = null) => Add(new EqualCondition(new SourceColumn(column), new DateTimeValue(value, format)));
		public ConditionBuilder Equal(string column, string value) => Add(new EqualCondition(new SourceColumn(column), new StringValue(value)));
		public ConditionBuilder Equal(string column, IExpression rightExpression) => Add(new EqualCondition(new SourceColumn(column), rightExpression));

		public ConditionBuilder Equal(string column, string table, sbyte value) => Add(new EqualCondition(new SourceColumn(column, new Table(table)), new Int8Value(value)));
		public ConditionBuilder Equal(string column, string table, short value) => Add(new EqualCondition(new SourceColumn(column, new Table(table)), new Int16Value(value)));
		public ConditionBuilder Equal(string column, string table, int value) => Add(new EqualCondition(new SourceColumn(column, new Table(table)), new Int32Value(value)));
		public ConditionBuilder Equal(string column, string table, long value) => Add(new EqualCondition(new SourceColumn(column, new Table(table)), new Int64Value(value)));
		public ConditionBuilder Equal(string column, string table, float value) => Add(new EqualCondition(new SourceColumn(column, new Table(table)), new FloatValue(value)));
		public ConditionBuilder Equal(string column, string table, double value) => Add(new EqualCondition(new SourceColumn(column, new Table(table)), new DoubleValue(value)));
		public ConditionBuilder Equal(string column, string table, decimal value) => Add(new EqualCondition(new SourceColumn(column, new Table(table)), new DecimalValue(value)));
		public ConditionBuilder Equal(string column, string table, DateTime value, string? format = null) => Add(new EqualCondition(new SourceColumn(column, new Table(table)), new DateTimeValue(value, format)));
		public ConditionBuilder Equal(string column, string table, string value) => Add(new EqualCondition(new SourceColumn(column, new Table(table)), new StringValue(value)));
		public ConditionBuilder Equal(string column, string table, IExpression rightExpression) => Add(new EqualCondition(new SourceColumn(column, new Table(table)), rightExpression));

		public ConditionBuilder Equal(string column, ISource source, sbyte value) => Add(new EqualCondition(new SourceColumn(column, source), new Int8Value(value)));
		public ConditionBuilder Equal(string column, ISource source, short value) => Add(new EqualCondition(new SourceColumn(column, source), new Int16Value(value)));
		public ConditionBuilder Equal(string column, ISource source, int value) => Add(new EqualCondition(new SourceColumn(column, source), new Int32Value(value)));
		public ConditionBuilder Equal(string column, ISource source, long value) => Add(new EqualCondition(new SourceColumn(column, source), new Int64Value(value)));
		public ConditionBuilder Equal(string column, ISource source, float value) => Add(new EqualCondition(new SourceColumn(column, source), new FloatValue(value)));
		public ConditionBuilder Equal(string column, ISource source, double value) => Add(new EqualCondition(new SourceColumn(column, source), new DoubleValue(value)));
		public ConditionBuilder Equal(string column, ISource source, decimal value) => Add(new EqualCondition(new SourceColumn(column, source), new DecimalValue(value)));
		public ConditionBuilder Equal(string column, ISource source, DateTime value, string? format = null) => Add(new EqualCondition(new SourceColumn(column, source), new DateTimeValue(value, format)));
		public ConditionBuilder Equal(string column, ISource source, string value) => Add(new EqualCondition(new SourceColumn(column, source), new StringValue(value)));
		public ConditionBuilder Equal(string column, ISource source, IExpression rightExpression) => Add(new EqualCondition(new SourceColumn(column, source), rightExpression));

		public ConditionBuilder Equal(string column1, string table1, string column2, string table2) => Add(new EqualCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, new Table(table2))));
		public ConditionBuilder Equal(string column1, string table1, string column2, ISource source2) => Add(new EqualCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, source2)));
		public ConditionBuilder Equal(string column1, ISource source1, string column2, string table2) => Add(new EqualCondition(new SourceColumn(column1, source1), new SourceColumn(column2, new Table(table2))));
		public ConditionBuilder Equal(string column1, ISource source1, string column2, ISource source2) => Add(new EqualCondition(new SourceColumn(column1, source1), new SourceColumn(column2, source2)));

		#endregion Equal methods

		#region NotEqual methods

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

		public ConditionBuilder NotEqual(string column, sbyte value) => Add(new NotEqualCondition(new SourceColumn(column), new Int8Value(value)));
		public ConditionBuilder NotEqual(string column, short value) => Add(new NotEqualCondition(new SourceColumn(column), new Int16Value(value)));
		public ConditionBuilder NotEqual(string column, int value) => Add(new NotEqualCondition(new SourceColumn(column), new Int32Value(value)));
		public ConditionBuilder NotEqual(string column, long value) => Add(new NotEqualCondition(new SourceColumn(column), new Int64Value(value)));
		public ConditionBuilder NotEqual(string column, float value) => Add(new NotEqualCondition(new SourceColumn(column), new FloatValue(value)));
		public ConditionBuilder NotEqual(string column, double value) => Add(new NotEqualCondition(new SourceColumn(column), new DoubleValue(value)));
		public ConditionBuilder NotEqual(string column, decimal value) => Add(new NotEqualCondition(new SourceColumn(column), new DecimalValue(value)));
		public ConditionBuilder NotEqual(string column, DateTime value, string? format = null) => Add(new NotEqualCondition(new SourceColumn(column), new DateTimeValue(value, format)));
		public ConditionBuilder NotEqual(string column, string value) => Add(new NotEqualCondition(new SourceColumn(column), new StringValue(value)));
		public ConditionBuilder NotEqual(string column, IExpression rightExpression) => Add(new NotEqualCondition(new SourceColumn(column), rightExpression));

		public ConditionBuilder NotEqual(string column, string table, sbyte value) => Add(new NotEqualCondition(new SourceColumn(column, new Table(table)), new Int8Value(value)));
		public ConditionBuilder NotEqual(string column, string table, short value) => Add(new NotEqualCondition(new SourceColumn(column, new Table(table)), new Int16Value(value)));
		public ConditionBuilder NotEqual(string column, string table, int value) => Add(new NotEqualCondition(new SourceColumn(column, new Table(table)), new Int32Value(value)));
		public ConditionBuilder NotEqual(string column, string table, long value) => Add(new NotEqualCondition(new SourceColumn(column, new Table(table)), new Int64Value(value)));
		public ConditionBuilder NotEqual(string column, string table, float value) => Add(new NotEqualCondition(new SourceColumn(column, new Table(table)), new FloatValue(value)));
		public ConditionBuilder NotEqual(string column, string table, double value) => Add(new NotEqualCondition(new SourceColumn(column, new Table(table)), new DoubleValue(value)));
		public ConditionBuilder NotEqual(string column, string table, decimal value) => Add(new NotEqualCondition(new SourceColumn(column, new Table(table)), new DecimalValue(value)));
		public ConditionBuilder NotEqual(string column, string table, DateTime value, string? format = null) => Add(new NotEqualCondition(new SourceColumn(column, new Table(table)), new DateTimeValue(value, format)));
		public ConditionBuilder NotEqual(string column, string table, string value) => Add(new NotEqualCondition(new SourceColumn(column, new Table(table)), new StringValue(value)));
		public ConditionBuilder NotEqual(string column, string table, IExpression rightExpression) => Add(new NotEqualCondition(new SourceColumn(column, new Table(table)), rightExpression));

		public ConditionBuilder NotEqual(string column, ISource source, sbyte value) => Add(new NotEqualCondition(new SourceColumn(column, source), new Int8Value(value)));
		public ConditionBuilder NotEqual(string column, ISource source, short value) => Add(new NotEqualCondition(new SourceColumn(column, source), new Int16Value(value)));
		public ConditionBuilder NotEqual(string column, ISource source, int value) => Add(new NotEqualCondition(new SourceColumn(column, source), new Int32Value(value)));
		public ConditionBuilder NotEqual(string column, ISource source, long value) => Add(new NotEqualCondition(new SourceColumn(column, source), new Int64Value(value)));
		public ConditionBuilder NotEqual(string column, ISource source, float value) => Add(new NotEqualCondition(new SourceColumn(column, source), new FloatValue(value)));
		public ConditionBuilder NotEqual(string column, ISource source, double value) => Add(new NotEqualCondition(new SourceColumn(column, source), new DoubleValue(value)));
		public ConditionBuilder NotEqual(string column, ISource source, decimal value) => Add(new NotEqualCondition(new SourceColumn(column, source), new DecimalValue(value)));
		public ConditionBuilder NotEqual(string column, ISource source, DateTime value, string? format = null) => Add(new NotEqualCondition(new SourceColumn(column, source), new DateTimeValue(value, format)));
		public ConditionBuilder NotEqual(string column, ISource source, string value) => Add(new NotEqualCondition(new SourceColumn(column, source), new StringValue(value)));
		public ConditionBuilder NotEqual(string column, ISource source, IExpression rightExpression) => Add(new NotEqualCondition(new SourceColumn(column, source), rightExpression));

		public ConditionBuilder NotEqual(string column1, string table1, string column2, string table2) => Add(new NotEqualCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, new Table(table2))));
		public ConditionBuilder NotEqual(string column1, string table1, string column2, ISource source2) => Add(new NotEqualCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, source2)));
		public ConditionBuilder NotEqual(string column1, ISource source1, string column2, string table2) => Add(new NotEqualCondition(new SourceColumn(column1, source1), new SourceColumn(column2, new Table(table2))));
		public ConditionBuilder NotEqual(string column1, ISource source1, string column2, ISource source2) => Add(new NotEqualCondition(new SourceColumn(column1, source1), new SourceColumn(column2, source2)));

		#endregion NotEqual methods

		#region Greater methods

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

		public ConditionBuilder Greater(string column, sbyte value) => Add(new GreaterCondition(new SourceColumn(column), new Int8Value(value)));
		public ConditionBuilder Greater(string column, short value) => Add(new GreaterCondition(new SourceColumn(column), new Int16Value(value)));
		public ConditionBuilder Greater(string column, int value) => Add(new GreaterCondition(new SourceColumn(column), new Int32Value(value)));
		public ConditionBuilder Greater(string column, long value) => Add(new GreaterCondition(new SourceColumn(column), new Int64Value(value)));
		public ConditionBuilder Greater(string column, float value) => Add(new GreaterCondition(new SourceColumn(column), new FloatValue(value)));
		public ConditionBuilder Greater(string column, double value) => Add(new GreaterCondition(new SourceColumn(column), new DoubleValue(value)));
		public ConditionBuilder Greater(string column, decimal value) => Add(new GreaterCondition(new SourceColumn(column), new DecimalValue(value)));
		public ConditionBuilder Greater(string column, DateTime value, string? format = null) => Add(new GreaterCondition(new SourceColumn(column), new DateTimeValue(value, format)));
		public ConditionBuilder Greater(string column, string value) => Add(new GreaterCondition(new SourceColumn(column), new StringValue(value)));
		public ConditionBuilder Greater(string column, IExpression rightExpression) => Add(new GreaterCondition(new SourceColumn(column), rightExpression));

		public ConditionBuilder Greater(string column, string table, sbyte value) => Add(new GreaterCondition(new SourceColumn(column, new Table(table)), new Int8Value(value)));
		public ConditionBuilder Greater(string column, string table, short value) => Add(new GreaterCondition(new SourceColumn(column, new Table(table)), new Int16Value(value)));
		public ConditionBuilder Greater(string column, string table, int value) => Add(new GreaterCondition(new SourceColumn(column, new Table(table)), new Int32Value(value)));
		public ConditionBuilder Greater(string column, string table, long value) => Add(new GreaterCondition(new SourceColumn(column, new Table(table)), new Int64Value(value)));
		public ConditionBuilder Greater(string column, string table, float value) => Add(new GreaterCondition(new SourceColumn(column, new Table(table)), new FloatValue(value)));
		public ConditionBuilder Greater(string column, string table, double value) => Add(new GreaterCondition(new SourceColumn(column, new Table(table)), new DoubleValue(value)));
		public ConditionBuilder Greater(string column, string table, decimal value) => Add(new GreaterCondition(new SourceColumn(column, new Table(table)), new DecimalValue(value)));
		public ConditionBuilder Greater(string column, string table, DateTime value, string? format = null) => Add(new GreaterCondition(new SourceColumn(column, new Table(table)), new DateTimeValue(value, format)));
		public ConditionBuilder Greater(string column, string table, string value) => Add(new GreaterCondition(new SourceColumn(column, new Table(table)), new StringValue(value)));
		public ConditionBuilder Greater(string column, string table, IExpression rightExpression) => Add(new GreaterCondition(new SourceColumn(column, new Table(table)), rightExpression));

		public ConditionBuilder Greater(string column, ISource source, sbyte value) => Add(new GreaterCondition(new SourceColumn(column, source), new Int8Value(value)));
		public ConditionBuilder Greater(string column, ISource source, short value) => Add(new GreaterCondition(new SourceColumn(column, source), new Int16Value(value)));
		public ConditionBuilder Greater(string column, ISource source, int value) => Add(new GreaterCondition(new SourceColumn(column, source), new Int32Value(value)));
		public ConditionBuilder Greater(string column, ISource source, long value) => Add(new GreaterCondition(new SourceColumn(column, source), new Int64Value(value)));
		public ConditionBuilder Greater(string column, ISource source, float value) => Add(new GreaterCondition(new SourceColumn(column, source), new FloatValue(value)));
		public ConditionBuilder Greater(string column, ISource source, double value) => Add(new GreaterCondition(new SourceColumn(column, source), new DoubleValue(value)));
		public ConditionBuilder Greater(string column, ISource source, decimal value) => Add(new GreaterCondition(new SourceColumn(column, source), new DecimalValue(value)));
		public ConditionBuilder Greater(string column, ISource source, DateTime value, string? format = null) => Add(new GreaterCondition(new SourceColumn(column, source), new DateTimeValue(value, format)));
		public ConditionBuilder Greater(string column, ISource source, string value) => Add(new GreaterCondition(new SourceColumn(column, source), new StringValue(value)));
		public ConditionBuilder Greater(string column, ISource source, IExpression rightExpression) => Add(new GreaterCondition(new SourceColumn(column, source), rightExpression));

		public ConditionBuilder Greater(string column1, string table1, string column2, string table2) => Add(new GreaterCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, new Table(table2))));
		public ConditionBuilder Greater(string column1, string table1, string column2, ISource source2) => Add(new GreaterCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, source2)));
		public ConditionBuilder Greater(string column1, ISource source1, string column2, string table2) => Add(new GreaterCondition(new SourceColumn(column1, source1), new SourceColumn(column2, new Table(table2))));
		public ConditionBuilder Greater(string column1, ISource source1, string column2, ISource source2) => Add(new GreaterCondition(new SourceColumn(column1, source1), new SourceColumn(column2, source2)));

		#endregion Greater methods

		#region GreaterOrEqual methods

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

		public ConditionBuilder GreaterOrEqual(string column, sbyte value) => Add(new GreaterOrEqualCondition(new SourceColumn(column), new Int8Value(value)));
		public ConditionBuilder GreaterOrEqual(string column, short value) => Add(new GreaterOrEqualCondition(new SourceColumn(column), new Int16Value(value)));
		public ConditionBuilder GreaterOrEqual(string column, int value) => Add(new GreaterOrEqualCondition(new SourceColumn(column), new Int32Value(value)));
		public ConditionBuilder GreaterOrEqual(string column, long value) => Add(new GreaterOrEqualCondition(new SourceColumn(column), new Int64Value(value)));
		public ConditionBuilder GreaterOrEqual(string column, float value) => Add(new GreaterOrEqualCondition(new SourceColumn(column), new FloatValue(value)));
		public ConditionBuilder GreaterOrEqual(string column, double value) => Add(new GreaterOrEqualCondition(new SourceColumn(column), new DoubleValue(value)));
		public ConditionBuilder GreaterOrEqual(string column, decimal value) => Add(new GreaterOrEqualCondition(new SourceColumn(column), new DecimalValue(value)));
		public ConditionBuilder GreaterOrEqual(string column, DateTime value, string? format = null) => Add(new GreaterOrEqualCondition(new SourceColumn(column), new DateTimeValue(value, format)));
		public ConditionBuilder GreaterOrEqual(string column, string value) => Add(new GreaterOrEqualCondition(new SourceColumn(column), new StringValue(value)));
		public ConditionBuilder GreaterOrEqual(string column, IExpression rightExpression) => Add(new GreaterOrEqualCondition(new SourceColumn(column), rightExpression));

		public ConditionBuilder GreaterOrEqual(string column, string table, sbyte value) => Add(new GreaterOrEqualCondition(new SourceColumn(column, new Table(table)), new Int8Value(value)));
		public ConditionBuilder GreaterOrEqual(string column, string table, short value) => Add(new GreaterOrEqualCondition(new SourceColumn(column, new Table(table)), new Int16Value(value)));
		public ConditionBuilder GreaterOrEqual(string column, string table, int value) => Add(new GreaterOrEqualCondition(new SourceColumn(column, new Table(table)), new Int32Value(value)));
		public ConditionBuilder GreaterOrEqual(string column, string table, long value) => Add(new GreaterOrEqualCondition(new SourceColumn(column, new Table(table)), new Int64Value(value)));
		public ConditionBuilder GreaterOrEqual(string column, string table, float value) => Add(new GreaterOrEqualCondition(new SourceColumn(column, new Table(table)), new FloatValue(value)));
		public ConditionBuilder GreaterOrEqual(string column, string table, double value) => Add(new GreaterOrEqualCondition(new SourceColumn(column, new Table(table)), new DoubleValue(value)));
		public ConditionBuilder GreaterOrEqual(string column, string table, decimal value) => Add(new GreaterOrEqualCondition(new SourceColumn(column, new Table(table)), new DecimalValue(value)));
		public ConditionBuilder GreaterOrEqual(string column, string table, DateTime value, string? format = null) => Add(new GreaterOrEqualCondition(new SourceColumn(column, new Table(table)), new DateTimeValue(value, format)));
		public ConditionBuilder GreaterOrEqual(string column, string table, string value) => Add(new GreaterOrEqualCondition(new SourceColumn(column, new Table(table)), new StringValue(value)));
		public ConditionBuilder GreaterOrEqual(string column, string table, IExpression rightExpression) => Add(new GreaterOrEqualCondition(new SourceColumn(column, new Table(table)), rightExpression));

		public ConditionBuilder GreaterOrEqual(string column, ISource source, sbyte value) => Add(new GreaterOrEqualCondition(new SourceColumn(column, source), new Int8Value(value)));
		public ConditionBuilder GreaterOrEqual(string column, ISource source, short value) => Add(new GreaterOrEqualCondition(new SourceColumn(column, source), new Int16Value(value)));
		public ConditionBuilder GreaterOrEqual(string column, ISource source, int value) => Add(new GreaterOrEqualCondition(new SourceColumn(column, source), new Int32Value(value)));
		public ConditionBuilder GreaterOrEqual(string column, ISource source, long value) => Add(new GreaterOrEqualCondition(new SourceColumn(column, source), new Int64Value(value)));
		public ConditionBuilder GreaterOrEqual(string column, ISource source, float value) => Add(new GreaterOrEqualCondition(new SourceColumn(column, source), new FloatValue(value)));
		public ConditionBuilder GreaterOrEqual(string column, ISource source, double value) => Add(new GreaterOrEqualCondition(new SourceColumn(column, source), new DoubleValue(value)));
		public ConditionBuilder GreaterOrEqual(string column, ISource source, decimal value) => Add(new GreaterOrEqualCondition(new SourceColumn(column, source), new DecimalValue(value)));
		public ConditionBuilder GreaterOrEqual(string column, ISource source, DateTime value, string? format = null) => Add(new GreaterOrEqualCondition(new SourceColumn(column, source), new DateTimeValue(value, format)));
		public ConditionBuilder GreaterOrEqual(string column, ISource source, string value) => Add(new GreaterOrEqualCondition(new SourceColumn(column, source), new StringValue(value)));
		public ConditionBuilder GreaterOrEqual(string column, ISource source, IExpression rightExpression) => Add(new GreaterOrEqualCondition(new SourceColumn(column, source), rightExpression));

		public ConditionBuilder GreaterOrEqual(string column1, string table1, string column2, string table2) => Add(new GreaterOrEqualCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, new Table(table2))));
		public ConditionBuilder GreaterOrEqual(string column1, string table1, string column2, ISource source2) => Add(new GreaterOrEqualCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, source2)));
		public ConditionBuilder GreaterOrEqual(string column1, ISource source1, string column2, string table2) => Add(new GreaterOrEqualCondition(new SourceColumn(column1, source1), new SourceColumn(column2, new Table(table2))));
		public ConditionBuilder GreaterOrEqual(string column1, ISource source1, string column2, ISource source2) => Add(new GreaterOrEqualCondition(new SourceColumn(column1, source1), new SourceColumn(column2, source2)));

		#endregion GreaterOrEqual methods

		#region Less methods

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

		public ConditionBuilder Less(string column, sbyte value) => Add(new LessCondition(new SourceColumn(column), new Int8Value(value)));
		public ConditionBuilder Less(string column, short value) => Add(new LessCondition(new SourceColumn(column), new Int16Value(value)));
		public ConditionBuilder Less(string column, int value) => Add(new LessCondition(new SourceColumn(column), new Int32Value(value)));
		public ConditionBuilder Less(string column, long value) => Add(new LessCondition(new SourceColumn(column), new Int64Value(value)));
		public ConditionBuilder Less(string column, float value) => Add(new LessCondition(new SourceColumn(column), new FloatValue(value)));
		public ConditionBuilder Less(string column, double value) => Add(new LessCondition(new SourceColumn(column), new DoubleValue(value)));
		public ConditionBuilder Less(string column, decimal value) => Add(new LessCondition(new SourceColumn(column), new DecimalValue(value)));
		public ConditionBuilder Less(string column, DateTime value, string? format = null) => Add(new LessCondition(new SourceColumn(column), new DateTimeValue(value, format)));
		public ConditionBuilder Less(string column, string value) => Add(new LessCondition(new SourceColumn(column), new StringValue(value)));
		public ConditionBuilder Less(string column, IExpression rightExpression) => Add(new LessCondition(new SourceColumn(column), rightExpression));

		public ConditionBuilder Less(string column, string table, sbyte value) => Add(new LessCondition(new SourceColumn(column, new Table(table)), new Int8Value(value)));
		public ConditionBuilder Less(string column, string table, short value) => Add(new LessCondition(new SourceColumn(column, new Table(table)), new Int16Value(value)));
		public ConditionBuilder Less(string column, string table, int value) => Add(new LessCondition(new SourceColumn(column, new Table(table)), new Int32Value(value)));
		public ConditionBuilder Less(string column, string table, long value) => Add(new LessCondition(new SourceColumn(column, new Table(table)), new Int64Value(value)));
		public ConditionBuilder Less(string column, string table, float value) => Add(new LessCondition(new SourceColumn(column, new Table(table)), new FloatValue(value)));
		public ConditionBuilder Less(string column, string table, double value) => Add(new LessCondition(new SourceColumn(column, new Table(table)), new DoubleValue(value)));
		public ConditionBuilder Less(string column, string table, decimal value) => Add(new LessCondition(new SourceColumn(column, new Table(table)), new DecimalValue(value)));
		public ConditionBuilder Less(string column, string table, DateTime value, string? format = null) => Add(new LessCondition(new SourceColumn(column, new Table(table)), new DateTimeValue(value, format)));
		public ConditionBuilder Less(string column, string table, string value) => Add(new LessCondition(new SourceColumn(column, new Table(table)), new StringValue(value)));
		public ConditionBuilder Less(string column, string table, IExpression rightExpression) => Add(new LessCondition(new SourceColumn(column, new Table(table)), rightExpression));

		public ConditionBuilder Less(string column, ISource source, sbyte value) => Add(new LessCondition(new SourceColumn(column, source), new Int8Value(value)));
		public ConditionBuilder Less(string column, ISource source, short value) => Add(new LessCondition(new SourceColumn(column, source), new Int16Value(value)));
		public ConditionBuilder Less(string column, ISource source, int value) => Add(new LessCondition(new SourceColumn(column, source), new Int32Value(value)));
		public ConditionBuilder Less(string column, ISource source, long value) => Add(new LessCondition(new SourceColumn(column, source), new Int64Value(value)));
		public ConditionBuilder Less(string column, ISource source, float value) => Add(new LessCondition(new SourceColumn(column, source), new FloatValue(value)));
		public ConditionBuilder Less(string column, ISource source, double value) => Add(new LessCondition(new SourceColumn(column, source), new DoubleValue(value)));
		public ConditionBuilder Less(string column, ISource source, decimal value) => Add(new LessCondition(new SourceColumn(column, source), new DecimalValue(value)));
		public ConditionBuilder Less(string column, ISource source, DateTime value, string? format = null) => Add(new LessCondition(new SourceColumn(column, source), new DateTimeValue(value, format)));
		public ConditionBuilder Less(string column, ISource source, string value) => Add(new LessCondition(new SourceColumn(column, source), new StringValue(value)));
		public ConditionBuilder Less(string column, ISource source, IExpression rightExpression) => Add(new LessCondition(new SourceColumn(column, source), rightExpression));

		public ConditionBuilder Less(string column1, string table1, string column2, string table2) => Add(new LessCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, new Table(table2))));
		public ConditionBuilder Less(string column1, string table1, string column2, ISource source2) => Add(new LessCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, source2)));
		public ConditionBuilder Less(string column1, ISource source1, string column2, string table2) => Add(new LessCondition(new SourceColumn(column1, source1), new SourceColumn(column2, new Table(table2))));
		public ConditionBuilder Less(string column1, ISource source1, string column2, ISource source2) => Add(new LessCondition(new SourceColumn(column1, source1), new SourceColumn(column2, source2)));

		#endregion Less methods

		#region LessOrEqual methods

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

		public ConditionBuilder LessOrEqual(string column, sbyte value) => Add(new LessOrEqualCondition(new SourceColumn(column), new Int8Value(value)));
		public ConditionBuilder LessOrEqual(string column, short value) => Add(new LessOrEqualCondition(new SourceColumn(column), new Int16Value(value)));
		public ConditionBuilder LessOrEqual(string column, int value) => Add(new LessOrEqualCondition(new SourceColumn(column), new Int32Value(value)));
		public ConditionBuilder LessOrEqual(string column, long value) => Add(new LessOrEqualCondition(new SourceColumn(column), new Int64Value(value)));
		public ConditionBuilder LessOrEqual(string column, float value) => Add(new LessOrEqualCondition(new SourceColumn(column), new FloatValue(value)));
		public ConditionBuilder LessOrEqual(string column, double value) => Add(new LessOrEqualCondition(new SourceColumn(column), new DoubleValue(value)));
		public ConditionBuilder LessOrEqual(string column, decimal value) => Add(new LessOrEqualCondition(new SourceColumn(column), new DecimalValue(value)));
		public ConditionBuilder LessOrEqual(string column, DateTime value, string? format = null) => Add(new LessOrEqualCondition(new SourceColumn(column), new DateTimeValue(value, format)));
		public ConditionBuilder LessOrEqual(string column, string value) => Add(new LessOrEqualCondition(new SourceColumn(column), new StringValue(value)));
		public ConditionBuilder LessOrEqual(string column, IExpression rightExpression) => Add(new LessOrEqualCondition(new SourceColumn(column), rightExpression));

		public ConditionBuilder LessOrEqual(string column, string table, sbyte value) => Add(new LessOrEqualCondition(new SourceColumn(column, new Table(table)), new Int8Value(value)));
		public ConditionBuilder LessOrEqual(string column, string table, short value) => Add(new LessOrEqualCondition(new SourceColumn(column, new Table(table)), new Int16Value(value)));
		public ConditionBuilder LessOrEqual(string column, string table, int value) => Add(new LessOrEqualCondition(new SourceColumn(column, new Table(table)), new Int32Value(value)));
		public ConditionBuilder LessOrEqual(string column, string table, long value) => Add(new LessOrEqualCondition(new SourceColumn(column, new Table(table)), new Int64Value(value)));
		public ConditionBuilder LessOrEqual(string column, string table, float value) => Add(new LessOrEqualCondition(new SourceColumn(column, new Table(table)), new FloatValue(value)));
		public ConditionBuilder LessOrEqual(string column, string table, double value) => Add(new LessOrEqualCondition(new SourceColumn(column, new Table(table)), new DoubleValue(value)));
		public ConditionBuilder LessOrEqual(string column, string table, decimal value) => Add(new LessOrEqualCondition(new SourceColumn(column, new Table(table)), new DecimalValue(value)));
		public ConditionBuilder LessOrEqual(string column, string table, DateTime value, string? format = null) => Add(new LessOrEqualCondition(new SourceColumn(column, new Table(table)), new DateTimeValue(value, format)));
		public ConditionBuilder LessOrEqual(string column, string table, string value) => Add(new LessOrEqualCondition(new SourceColumn(column, new Table(table)), new StringValue(value)));
		public ConditionBuilder LessOrEqual(string column, string table, IExpression rightExpression) => Add(new LessOrEqualCondition(new SourceColumn(column, new Table(table)), rightExpression));

		public ConditionBuilder LessOrEqual(string column, ISource source, sbyte value) => Add(new LessOrEqualCondition(new SourceColumn(column, source), new Int8Value(value)));
		public ConditionBuilder LessOrEqual(string column, ISource source, short value) => Add(new LessOrEqualCondition(new SourceColumn(column, source), new Int16Value(value)));
		public ConditionBuilder LessOrEqual(string column, ISource source, int value) => Add(new LessOrEqualCondition(new SourceColumn(column, source), new Int32Value(value)));
		public ConditionBuilder LessOrEqual(string column, ISource source, long value) => Add(new LessOrEqualCondition(new SourceColumn(column, source), new Int64Value(value)));
		public ConditionBuilder LessOrEqual(string column, ISource source, float value) => Add(new LessOrEqualCondition(new SourceColumn(column, source), new FloatValue(value)));
		public ConditionBuilder LessOrEqual(string column, ISource source, double value) => Add(new LessOrEqualCondition(new SourceColumn(column, source), new DoubleValue(value)));
		public ConditionBuilder LessOrEqual(string column, ISource source, decimal value) => Add(new LessOrEqualCondition(new SourceColumn(column, source), new DecimalValue(value)));
		public ConditionBuilder LessOrEqual(string column, ISource source, DateTime value, string? format = null) => Add(new LessOrEqualCondition(new SourceColumn(column, source), new DateTimeValue(value, format)));
		public ConditionBuilder LessOrEqual(string column, ISource source, string value) => Add(new LessOrEqualCondition(new SourceColumn(column, source), new StringValue(value)));
		public ConditionBuilder LessOrEqual(string column, ISource source, IExpression rightExpression) => Add(new LessOrEqualCondition(new SourceColumn(column, source), rightExpression));

		public ConditionBuilder LessOrEqual(string column1, string table1, string column2, string table2) => Add(new LessOrEqualCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, new Table(table2))));
		public ConditionBuilder LessOrEqual(string column1, string table1, string column2, ISource source2) => Add(new LessOrEqualCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, source2)));
		public ConditionBuilder LessOrEqual(string column1, ISource source1, string column2, string table2) => Add(new LessOrEqualCondition(new SourceColumn(column1, source1), new SourceColumn(column2, new Table(table2))));
		public ConditionBuilder LessOrEqual(string column1, ISource source1, string column2, ISource source2) => Add(new LessOrEqualCondition(new SourceColumn(column1, source1), new SourceColumn(column2, source2)));

		#endregion LessOrEqual methods

		#region IsNull methods

		public ConditionBuilder IsNull(IExpression expression) => Add(new IsNullCondition(expression));
		public ConditionBuilder IsNull(string column) => Add(new IsNullCondition(new SourceColumn(column)));
		public ConditionBuilder IsNull(string column, string table) => Add(new IsNullCondition(new SourceColumn(column, new Table(table))));
		public ConditionBuilder IsNull(string column, ISource source) => Add(new IsNullCondition(new SourceColumn(column, source)));

		#endregion IsNull methods

		#region IsNotNull methods

		public ConditionBuilder IsNotNull(IExpression expression) => Add(new IsNotNullCondition(expression));
		public ConditionBuilder IsNotNull(string column) => Add(new IsNotNullCondition(new SourceColumn(column)));
		public ConditionBuilder IsNotNull(string column, string table) => Add(new IsNullCondition(new SourceColumn(column, new Table(table))));
		public ConditionBuilder IsNotNull(string column, ISource source) => Add(new IsNullCondition(new SourceColumn(column, source)));

		#endregion IsNotNull methods

		#region In methods

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

		public ConditionBuilder In(string column, params sbyte[] values) => Add(new InCondition(new SourceColumn(column), values.Select(v => new Int8Value(v))));
		public ConditionBuilder In(string column, params short[] values) => Add(new InCondition(new SourceColumn(column), values.Select(v => new Int16Value(v))));
		public ConditionBuilder In(string column, params int[] values) => Add(new InCondition(new SourceColumn(column), values.Select(v => new Int32Value(v))));
		public ConditionBuilder In(string column, params long[] values) => Add(new InCondition(new SourceColumn(column), values.Select(v => new Int64Value(v))));
		public ConditionBuilder In(string column, params float[] values) => Add(new InCondition(new SourceColumn(column), values.Select(v => new FloatValue(v))));
		public ConditionBuilder In(string column, params double[] values) => Add(new InCondition(new SourceColumn(column), values.Select(v => new DoubleValue(v))));
		public ConditionBuilder In(string column, params decimal[] values) => Add(new InCondition(new SourceColumn(column), values.Select(v => new DecimalValue(v))));
		public ConditionBuilder In(string column, params DateTime[] values) => Add(new InCondition(new SourceColumn(column), values.Select(v => new DateTimeValue(v))));
		public ConditionBuilder In(string column, string format, params DateTime[] values) => Add(new InCondition(new SourceColumn(column), values.Select(v => new DateTimeValue(v, format))));
		public ConditionBuilder In(string column, params string[] values) => Add(new InCondition(new SourceColumn(column), values.Select(v => new StringValue(v))));
		public ConditionBuilder In(string column, params IExpression[] values) => Add(new InCondition(new SourceColumn(column), values));
		public ConditionBuilder In(string column, IEnumerable<sbyte> values) => Add(new InCondition(new SourceColumn(column), values.Select(v => new Int8Value(v))));
		public ConditionBuilder In(string column, IEnumerable<short> values) => Add(new InCondition(new SourceColumn(column), values.Select(v => new Int16Value(v))));
		public ConditionBuilder In(string column, IEnumerable<int> values) => Add(new InCondition(new SourceColumn(column), values.Select(v => new Int32Value(v))));
		public ConditionBuilder In(string column, IEnumerable<long> values) => Add(new InCondition(new SourceColumn(column), values.Select(v => new Int64Value(v))));
		public ConditionBuilder In(string column, IEnumerable<float> values) => Add(new InCondition(new SourceColumn(column), values.Select(v => new FloatValue(v))));
		public ConditionBuilder In(string column, IEnumerable<double> values) => Add(new InCondition(new SourceColumn(column), values.Select(v => new DoubleValue(v))));
		public ConditionBuilder In(string column, IEnumerable<decimal> values) => Add(new InCondition(new SourceColumn(column), values.Select(v => new DecimalValue(v))));
		public ConditionBuilder In(string column, IEnumerable<DateTime> values, string format) => Add(new InCondition(new SourceColumn(column), values.Select(v => new DateTimeValue(v, format))));
		public ConditionBuilder In(string column, IEnumerable<string> values) => Add(new InCondition(new SourceColumn(column), values.Select(v => new StringValue(v))));
		public ConditionBuilder In(string column, IEnumerable<IExpression> values) => Add(new InCondition(new SourceColumn(column), values));

		public ConditionBuilder In(string column, string table, params sbyte[] values) => Add(new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int8Value(v))));
		public ConditionBuilder In(string column, string table, params short[] values) => Add(new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int16Value(v))));
		public ConditionBuilder In(string column, string table, params int[] values) => Add(new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int32Value(v))));
		public ConditionBuilder In(string column, string table, params long[] values) => Add(new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int64Value(v))));
		public ConditionBuilder In(string column, string table, params float[] values) => Add(new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new FloatValue(v))));
		public ConditionBuilder In(string column, string table, params double[] values) => Add(new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DoubleValue(v))));
		public ConditionBuilder In(string column, string table, params decimal[] values) => Add(new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DecimalValue(v))));
		public ConditionBuilder In(string column, string table, string? format, params DateTime[] values) => Add(new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DateTimeValue(v, format))));
		public ConditionBuilder In(string column, string table, params string[] values) => Add(new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new StringValue(v))));
		public ConditionBuilder In(string column, string table, params IExpression[] values) => Add(new InCondition(new SourceColumn(column, new Table(table)), values));
		public ConditionBuilder In(string column, string table, IEnumerable<sbyte> values) => Add(new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int8Value(v))));
		public ConditionBuilder In(string column, string table, IEnumerable<short> values) => Add(new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int16Value(v))));
		public ConditionBuilder In(string column, string table, IEnumerable<int> values) => Add(new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int32Value(v))));
		public ConditionBuilder In(string column, string table, IEnumerable<long> values) => Add(new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int64Value(v))));
		public ConditionBuilder In(string column, string table, IEnumerable<float> values) => Add(new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new FloatValue(v))));
		public ConditionBuilder In(string column, string table, IEnumerable<double> values) => Add(new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DoubleValue(v))));
		public ConditionBuilder In(string column, string table, IEnumerable<decimal> values) => Add(new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DecimalValue(v))));
		public ConditionBuilder In(string column, string table, IEnumerable<DateTime> values, string format) => Add(new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DateTimeValue(v, format))));
		public ConditionBuilder In(string column, string table, IEnumerable<string> values) => Add(new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new StringValue(v))));
		public ConditionBuilder In(string column, string table, IEnumerable<IExpression> values) => Add(new InCondition(new SourceColumn(column, new Table(table)), values));

		public ConditionBuilder In(string column, ISource source, params sbyte[] values) => Add(new InCondition(new SourceColumn(column, source), values.Select(v => new Int8Value(v))));
		public ConditionBuilder In(string column, ISource source, params short[] values) => Add(new InCondition(new SourceColumn(column, source), values.Select(v => new Int16Value(v))));
		public ConditionBuilder In(string column, ISource source, params int[] values) => Add(new InCondition(new SourceColumn(column, source), values.Select(v => new Int32Value(v))));
		public ConditionBuilder In(string column, ISource source, params long[] values) => Add(new InCondition(new SourceColumn(column, source), values.Select(v => new Int64Value(v))));
		public ConditionBuilder In(string column, ISource source, params float[] values) => Add(new InCondition(new SourceColumn(column, source), values.Select(v => new FloatValue(v))));
		public ConditionBuilder In(string column, ISource source, params double[] values) => Add(new InCondition(new SourceColumn(column, source), values.Select(v => new DoubleValue(v))));
		public ConditionBuilder In(string column, ISource source, params decimal[] values) => Add(new InCondition(new SourceColumn(column, source), values.Select(v => new DecimalValue(v))));
		public ConditionBuilder In(string column, ISource source, string? format, params DateTime[] values) => Add(new InCondition(new SourceColumn(column, source), values.Select(v => new DateTimeValue(v, format))));
		public ConditionBuilder In(string column, ISource source, params string[] values) => Add(new InCondition(new SourceColumn(column, source), values.Select(v => new StringValue(v))));
		public ConditionBuilder In(string column, ISource source, params IExpression[] values) => Add(new InCondition(new SourceColumn(column, source), values));
		public ConditionBuilder In(string column, ISource source, IEnumerable<sbyte> values) => Add(new InCondition(new SourceColumn(column, source), values.Select(v => new Int8Value(v))));
		public ConditionBuilder In(string column, ISource source, IEnumerable<short> values) => Add(new InCondition(new SourceColumn(column, source), values.Select(v => new Int16Value(v))));
		public ConditionBuilder In(string column, ISource source, IEnumerable<int> values) => Add(new InCondition(new SourceColumn(column, source), values.Select(v => new Int32Value(v))));
		public ConditionBuilder In(string column, ISource source, IEnumerable<long> values) => Add(new InCondition(new SourceColumn(column, source), values.Select(v => new Int64Value(v))));
		public ConditionBuilder In(string column, ISource source, IEnumerable<float> values) => Add(new InCondition(new SourceColumn(column, source), values.Select(v => new FloatValue(v))));
		public ConditionBuilder In(string column, ISource source, IEnumerable<double> values) => Add(new InCondition(new SourceColumn(column, source), values.Select(v => new DoubleValue(v))));
		public ConditionBuilder In(string column, ISource source, IEnumerable<decimal> values) => Add(new InCondition(new SourceColumn(column, source), values.Select(v => new DecimalValue(v))));
		public ConditionBuilder In(string column, ISource source, IEnumerable<DateTime> values, string format) => Add(new InCondition(new SourceColumn(column, source), values.Select(v => new DateTimeValue(v, format))));
		public ConditionBuilder In(string column, ISource source, IEnumerable<string> values) => Add(new InCondition(new SourceColumn(column, source), values.Select(v => new StringValue(v))));
		public ConditionBuilder In(string column, ISource source, IEnumerable<IExpression> values) => Add(new InCondition(new SourceColumn(column, source), values));

		#endregion In methods

		#region NotIn methods

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

		public ConditionBuilder NotIn(string column, params sbyte[] values) => Add(new NotInCondition(new SourceColumn(column), values.Select(v => new Int8Value(v))));
		public ConditionBuilder NotIn(string column, params short[] values) => Add(new NotInCondition(new SourceColumn(column), values.Select(v => new Int16Value(v))));
		public ConditionBuilder NotIn(string column, params int[] values) => Add(new NotInCondition(new SourceColumn(column), values.Select(v => new Int32Value(v))));
		public ConditionBuilder NotIn(string column, params long[] values) => Add(new NotInCondition(new SourceColumn(column), values.Select(v => new Int64Value(v))));
		public ConditionBuilder NotIn(string column, params float[] values) => Add(new NotInCondition(new SourceColumn(column), values.Select(v => new FloatValue(v))));
		public ConditionBuilder NotIn(string column, params double[] values) => Add(new NotInCondition(new SourceColumn(column), values.Select(v => new DoubleValue(v))));
		public ConditionBuilder NotIn(string column, params decimal[] values) => Add(new NotInCondition(new SourceColumn(column), values.Select(v => new DecimalValue(v))));
		public ConditionBuilder NotIn(string column, params DateTime[] values) => Add(new NotInCondition(new SourceColumn(column), values.Select(v => new DateTimeValue(v))));
		public ConditionBuilder NotIn(string column, string format, params DateTime[] values) => Add(new NotInCondition(new SourceColumn(column), values.Select(v => new DateTimeValue(v, format))));
		public ConditionBuilder NotIn(string column, params string[] values) => Add(new NotInCondition(new SourceColumn(column), values.Select(v => new StringValue(v))));
		public ConditionBuilder NotIn(string column, params IExpression[] values) => Add(new NotInCondition(new SourceColumn(column), values));
		public ConditionBuilder NotIn(string column, IEnumerable<sbyte> values) => Add(new NotInCondition(new SourceColumn(column), values.Select(v => new Int8Value(v))));
		public ConditionBuilder NotIn(string column, IEnumerable<short> values) => Add(new NotInCondition(new SourceColumn(column), values.Select(v => new Int16Value(v))));
		public ConditionBuilder NotIn(string column, IEnumerable<int> values) => Add(new NotInCondition(new SourceColumn(column), values.Select(v => new Int32Value(v))));
		public ConditionBuilder NotIn(string column, IEnumerable<long> values) => Add(new NotInCondition(new SourceColumn(column), values.Select(v => new Int64Value(v))));
		public ConditionBuilder NotIn(string column, IEnumerable<float> values) => Add(new NotInCondition(new SourceColumn(column), values.Select(v => new FloatValue(v))));
		public ConditionBuilder NotIn(string column, IEnumerable<double> values) => Add(new NotInCondition(new SourceColumn(column), values.Select(v => new DoubleValue(v))));
		public ConditionBuilder NotIn(string column, IEnumerable<decimal> values) => Add(new NotInCondition(new SourceColumn(column), values.Select(v => new DecimalValue(v))));
		public ConditionBuilder NotIn(string column, IEnumerable<DateTime> values, string format) => Add(new NotInCondition(new SourceColumn(column), values.Select(v => new DateTimeValue(v, format))));
		public ConditionBuilder NotIn(string column, IEnumerable<string> values) => Add(new NotInCondition(new SourceColumn(column), values.Select(v => new StringValue(v))));
		public ConditionBuilder NotIn(string column, IEnumerable<IExpression> values) => Add(new NotInCondition(new SourceColumn(column), values));

		public ConditionBuilder NotIn(string column, string table, params sbyte[] values) => Add(new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int8Value(v))));
		public ConditionBuilder NotIn(string column, string table, params short[] values) => Add(new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int16Value(v))));
		public ConditionBuilder NotIn(string column, string table, params int[] values) => Add(new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int32Value(v))));
		public ConditionBuilder NotIn(string column, string table, params long[] values) => Add(new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int64Value(v))));
		public ConditionBuilder NotIn(string column, string table, params float[] values) => Add(new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new FloatValue(v))));
		public ConditionBuilder NotIn(string column, string table, params double[] values) => Add(new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DoubleValue(v))));
		public ConditionBuilder NotIn(string column, string table, params decimal[] values) => Add(new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DecimalValue(v))));
		public ConditionBuilder NotIn(string column, string table, string? format, params DateTime[] values) => Add(new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DateTimeValue(v, format))));
		public ConditionBuilder NotIn(string column, string table, params string[] values) => Add(new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new StringValue(v))));
		public ConditionBuilder NotIn(string column, string table, params IExpression[] values) => Add(new NotInCondition(new SourceColumn(column, new Table(table)), values));
		public ConditionBuilder NotIn(string column, string table, IEnumerable<sbyte> values) => Add(new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int8Value(v))));
		public ConditionBuilder NotIn(string column, string table, IEnumerable<short> values) => Add(new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int16Value(v))));
		public ConditionBuilder NotIn(string column, string table, IEnumerable<int> values) => Add(new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int32Value(v))));
		public ConditionBuilder NotIn(string column, string table, IEnumerable<long> values) => Add(new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int64Value(v))));
		public ConditionBuilder NotIn(string column, string table, IEnumerable<float> values) => Add(new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new FloatValue(v))));
		public ConditionBuilder NotIn(string column, string table, IEnumerable<double> values) => Add(new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DoubleValue(v))));
		public ConditionBuilder NotIn(string column, string table, IEnumerable<decimal> values) => Add(new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DecimalValue(v))));
		public ConditionBuilder NotIn(string column, string table, IEnumerable<DateTime> values, string format) => Add(new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DateTimeValue(v, format))));
		public ConditionBuilder NotIn(string column, string table, IEnumerable<string> values) => Add(new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new StringValue(v))));
		public ConditionBuilder NotIn(string column, string table, IEnumerable<IExpression> values) => Add(new NotInCondition(new SourceColumn(column, new Table(table)), values));

		public ConditionBuilder NotIn(string column, ISource source, params sbyte[] values) => Add(new NotInCondition(new SourceColumn(column, source), values.Select(v => new Int8Value(v))));
		public ConditionBuilder NotIn(string column, ISource source, params short[] values) => Add(new NotInCondition(new SourceColumn(column, source), values.Select(v => new Int16Value(v))));
		public ConditionBuilder NotIn(string column, ISource source, params int[] values) => Add(new NotInCondition(new SourceColumn(column, source), values.Select(v => new Int32Value(v))));
		public ConditionBuilder NotIn(string column, ISource source, params long[] values) => Add(new NotInCondition(new SourceColumn(column, source), values.Select(v => new Int64Value(v))));
		public ConditionBuilder NotIn(string column, ISource source, params float[] values) => Add(new NotInCondition(new SourceColumn(column, source), values.Select(v => new FloatValue(v))));
		public ConditionBuilder NotIn(string column, ISource source, params double[] values) => Add(new NotInCondition(new SourceColumn(column, source), values.Select(v => new DoubleValue(v))));
		public ConditionBuilder NotIn(string column, ISource source, params decimal[] values) => Add(new NotInCondition(new SourceColumn(column, source), values.Select(v => new DecimalValue(v))));
		public ConditionBuilder NotIn(string column, ISource source, string? format, params DateTime[] values) => Add(new NotInCondition(new SourceColumn(column, source), values.Select(v => new DateTimeValue(v, format))));
		public ConditionBuilder NotIn(string column, ISource source, params string[] values) => Add(new NotInCondition(new SourceColumn(column, source), values.Select(v => new StringValue(v))));
		public ConditionBuilder NotIn(string column, ISource source, params IExpression[] values) => Add(new NotInCondition(new SourceColumn(column, source), values));
		public ConditionBuilder NotIn(string column, ISource source, IEnumerable<sbyte> values) => Add(new NotInCondition(new SourceColumn(column, source), values.Select(v => new Int8Value(v))));
		public ConditionBuilder NotIn(string column, ISource source, IEnumerable<short> values) => Add(new NotInCondition(new SourceColumn(column, source), values.Select(v => new Int16Value(v))));
		public ConditionBuilder NotIn(string column, ISource source, IEnumerable<int> values) => Add(new NotInCondition(new SourceColumn(column, source), values.Select(v => new Int32Value(v))));
		public ConditionBuilder NotIn(string column, ISource source, IEnumerable<long> values) => Add(new NotInCondition(new SourceColumn(column, source), values.Select(v => new Int64Value(v))));
		public ConditionBuilder NotIn(string column, ISource source, IEnumerable<float> values) => Add(new NotInCondition(new SourceColumn(column, source), values.Select(v => new FloatValue(v))));
		public ConditionBuilder NotIn(string column, ISource source, IEnumerable<double> values) => Add(new NotInCondition(new SourceColumn(column, source), values.Select(v => new DoubleValue(v))));
		public ConditionBuilder NotIn(string column, ISource source, IEnumerable<decimal> values) => Add(new NotInCondition(new SourceColumn(column, source), values.Select(v => new DecimalValue(v))));
		public ConditionBuilder NotIn(string column, ISource source, IEnumerable<DateTime> values, string format) => Add(new NotInCondition(new SourceColumn(column, source), values.Select(v => new DateTimeValue(v, format))));
		public ConditionBuilder NotIn(string column, ISource source, IEnumerable<string> values) => Add(new NotInCondition(new SourceColumn(column, source), values.Select(v => new StringValue(v))));
		public ConditionBuilder NotIn(string column, ISource source, IEnumerable<IExpression> values) => Add(new NotInCondition(new SourceColumn(column, source), values));

		#endregion NotIn methods

		#region Like methods

		public ConditionBuilder Like(IExpression expression, string pattern) => Add(new LikeCondition(expression, pattern));
		public ConditionBuilder Like(string column, string pattern) => Add(new LikeCondition(new SourceColumn(column), pattern));
		public ConditionBuilder Like(string column, string table, string pattern) => Add(new LikeCondition(new SourceColumn(column, new Table(table)), pattern));
		public ConditionBuilder Like(string column, ISource source, string pattern) => Add(new LikeCondition(new SourceColumn(column, source), pattern));

		#endregion Like methods

		#region NotLike methods

		public ConditionBuilder NotLike(IExpression expression, string pattern) => Add(new NotLikeCondition(expression, pattern));
		public ConditionBuilder NotLike(string column, string pattern) => Add(new NotLikeCondition(new SourceColumn(column), pattern));
		public ConditionBuilder NotLike(string column, string table, string pattern) => Add(new NotLikeCondition(new SourceColumn(column, new Table(table)), pattern));
		public ConditionBuilder NotLike(string column, ISource source, string pattern) => Add(new NotLikeCondition(new SourceColumn(column, source), pattern));

		#endregion NotLike methods

		#region Between methods

		public ConditionBuilder Between(IExpression expression, sbyte lowBound, sbyte hightBound) => Add(new BetweenCondition(expression, new Int8Value(lowBound), new Int8Value(hightBound)));
		public ConditionBuilder Between(IExpression expression, short lowBound, short hightBound) => Add(new BetweenCondition(expression, new Int16Value(lowBound), new Int16Value(hightBound)));
		public ConditionBuilder Between(IExpression expression, int lowBound, int hightBound) => Add(new BetweenCondition(expression, new Int32Value(lowBound), new Int32Value(hightBound)));
		public ConditionBuilder Between(IExpression expression, long lowBound, long hightBound) => Add(new BetweenCondition(expression, new Int64Value(lowBound), new Int64Value(hightBound)));
		public ConditionBuilder Between(IExpression expression, float lowBound, float hightBound) => Add(new BetweenCondition(expression, new FloatValue(lowBound), new FloatValue(hightBound)));
		public ConditionBuilder Between(IExpression expression, double lowBound, double hightBound) => Add(new BetweenCondition(expression, new DoubleValue(lowBound), new DoubleValue(hightBound)));
		public ConditionBuilder Between(IExpression expression, decimal lowBound, decimal hightBound) => Add(new BetweenCondition(expression, new DecimalValue(lowBound), new DecimalValue(hightBound)));
		public ConditionBuilder Between(IExpression expression, DateTime lowBound, DateTime hightBound, string? format = null) => Add(new BetweenCondition(expression, new DateTimeValue(lowBound, format), new DateTimeValue(hightBound, format)));
		public ConditionBuilder Between(IExpression expression, string lowBound, string hightBound) => Add(new BetweenCondition(expression, new StringValue(lowBound), new StringValue(hightBound)));
		public ConditionBuilder Between(IExpression leftExpression, IExpression lowBound, IExpression hightBound) => Add(new BetweenCondition(leftExpression, lowBound, hightBound));

		public ConditionBuilder Between(string column, sbyte lowBound, sbyte hightBound) => Add(new BetweenCondition(new SourceColumn(column), new Int8Value(lowBound), new Int8Value(hightBound)));
		public ConditionBuilder Between(string column, short lowBound, short hightBound) => Add(new BetweenCondition(new SourceColumn(column), new Int16Value(lowBound), new Int16Value(hightBound)));
		public ConditionBuilder Between(string column, int lowBound, int hightBound) => Add(new BetweenCondition(new SourceColumn(column), new Int32Value(lowBound), new Int32Value(hightBound)));
		public ConditionBuilder Between(string column, long lowBound, long hightBound) => Add(new BetweenCondition(new SourceColumn(column), new Int64Value(lowBound), new Int64Value(hightBound)));
		public ConditionBuilder Between(string column, float lowBound, float hightBound) => Add(new BetweenCondition(new SourceColumn(column), new FloatValue(lowBound), new FloatValue(hightBound)));
		public ConditionBuilder Between(string column, double lowBound, double hightBound) => Add(new BetweenCondition(new SourceColumn(column), new DoubleValue(lowBound), new DoubleValue(hightBound)));
		public ConditionBuilder Between(string column, decimal lowBound, decimal hightBound) => Add(new BetweenCondition(new SourceColumn(column), new DecimalValue(lowBound), new DecimalValue(hightBound)));
		public ConditionBuilder Between(string column, DateTime lowBound, DateTime hightBound, string? format = null) => Add(new BetweenCondition(new SourceColumn(column), new DateTimeValue(lowBound, format), new DateTimeValue(hightBound, format)));
		public ConditionBuilder Between(string column, string lowBound, string hightBound) => Add(new BetweenCondition(new SourceColumn(column), new StringValue(lowBound), new StringValue(hightBound)));
		public ConditionBuilder Between(string column, IExpression lowBound, IExpression hightBound) => Add(new BetweenCondition(new SourceColumn(column), lowBound, hightBound));

		public ConditionBuilder Between(string column, string table, sbyte lowBound, sbyte hightBound) => Add(new BetweenCondition(new SourceColumn(column, new Table(table)), new Int8Value(lowBound), new Int8Value(hightBound)));
		public ConditionBuilder Between(string column, string table, short lowBound, short hightBound) => Add(new BetweenCondition(new SourceColumn(column, new Table(table)), new Int16Value(lowBound), new Int16Value(hightBound)));
		public ConditionBuilder Between(string column, string table, int lowBound, int hightBound) => Add(new BetweenCondition(new SourceColumn(column, new Table(table)), new Int32Value(lowBound), new Int32Value(hightBound)));
		public ConditionBuilder Between(string column, string table, long lowBound, long hightBound) => Add(new BetweenCondition(new SourceColumn(column, new Table(table)), new Int64Value(lowBound), new Int64Value(hightBound)));
		public ConditionBuilder Between(string column, string table, float lowBound, float hightBound) => Add(new BetweenCondition(new SourceColumn(column, new Table(table)), new FloatValue(lowBound), new FloatValue(hightBound)));
		public ConditionBuilder Between(string column, string table, double lowBound, double hightBound) => Add(new BetweenCondition(new SourceColumn(column, new Table(table)), new DoubleValue(lowBound), new DoubleValue(hightBound)));
		public ConditionBuilder Between(string column, string table, decimal lowBound, decimal hightBound) => Add(new BetweenCondition(new SourceColumn(column, new Table(table)), new DecimalValue(lowBound), new DecimalValue(hightBound)));
		public ConditionBuilder Between(string column, string table, DateTime lowBound, DateTime hightBound, string? format = null) => Add(new BetweenCondition(new SourceColumn(column, new Table(table)), new DateTimeValue(lowBound, format), new DateTimeValue(hightBound, format)));
		public ConditionBuilder Between(string column, string table, string lowBound, string hightBound) => Add(new BetweenCondition(new SourceColumn(column, new Table(table)), new StringValue(lowBound), new StringValue(hightBound)));
		public ConditionBuilder Between(string column, string table, IExpression lowBound, IExpression hightBound) => Add(new BetweenCondition(new SourceColumn(column, new Table(table)), lowBound, hightBound));

		public ConditionBuilder Between(string column, ISource source, sbyte lowBound, sbyte hightBound) => Add(new BetweenCondition(new SourceColumn(column, source), new Int8Value(lowBound), new Int8Value(hightBound)));
		public ConditionBuilder Between(string column, ISource source, short lowBound, short hightBound) => Add(new BetweenCondition(new SourceColumn(column, source), new Int16Value(lowBound), new Int16Value(hightBound)));
		public ConditionBuilder Between(string column, ISource source, int lowBound, int hightBound) => Add(new BetweenCondition(new SourceColumn(column, source), new Int32Value(lowBound), new Int32Value(hightBound)));
		public ConditionBuilder Between(string column, ISource source, long lowBound, long hightBound) => Add(new BetweenCondition(new SourceColumn(column, source), new Int64Value(lowBound), new Int64Value(hightBound)));
		public ConditionBuilder Between(string column, ISource source, float lowBound, float hightBound) => Add(new BetweenCondition(new SourceColumn(column, source), new FloatValue(lowBound), new FloatValue(hightBound)));
		public ConditionBuilder Between(string column, ISource source, double lowBound, double hightBound) => Add(new BetweenCondition(new SourceColumn(column, source), new DoubleValue(lowBound), new DoubleValue(hightBound)));
		public ConditionBuilder Between(string column, ISource source, decimal lowBound, decimal hightBound) => Add(new BetweenCondition(new SourceColumn(column, source), new DecimalValue(lowBound), new DecimalValue(hightBound)));
		public ConditionBuilder Between(string column, ISource source, DateTime lowBound, DateTime hightBound, string? format = null) => Add(new BetweenCondition(new SourceColumn(column, source), new DateTimeValue(lowBound, format), new DateTimeValue(hightBound, format)));
		public ConditionBuilder Between(string column, ISource source, string lowBound, string hightBound) => Add(new BetweenCondition(new SourceColumn(column, source), new StringValue(lowBound), new StringValue(hightBound)));
		public ConditionBuilder Between(string column, ISource source, IExpression lowBound, IExpression hightBound) => Add(new BetweenCondition(new SourceColumn(column, source), lowBound, hightBound));

		#endregion Between methods

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
