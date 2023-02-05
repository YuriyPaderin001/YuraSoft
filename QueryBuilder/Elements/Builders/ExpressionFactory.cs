using System;
using System.Collections.Generic;
using System.Linq;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public class ExpressionFactory
	{
		static ExpressionFactory() => Instance = new ExpressionFactory();

		private ExpressionFactory()
		{
		}

		public static ExpressionFactory Instance { get; private set; }

		#region Columns factory methods

		#region IColumn factory methods

		public IColumn Column(Func<ExpressionFactory, IColumn> function) => function.Invoke(this);

		public IEnumerable<IColumn> Columns(Action<ColumnBuilder> action)
		{
			Validator.ThrowIfArgumentIsNull(action, nameof(action));

			ColumnBuilder builder = new ColumnBuilder();
			action.Invoke(builder);

			IEnumerable<IColumn> columns = builder.Build();

			return columns;
		}

		#endregion IColumn factory methods

		#region ExpressionColumn factory method

		public ExpressionColumn Column(IExpression expression, string? name = null) =>
		  new ExpressionColumn(expression, name);

		public ExpressionColumn Column(Func<ExpressionFactory, IExpression> expressionFunction, string? name = null)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression = expressionFunction.Invoke(factory);

			return new ExpressionColumn(expression, name);
		}

		#endregion ExpressionColumn factory methods

		#region SourceColumn factory methods

		public SourceColumn Column(string name) => new SourceColumn(name);
		public SourceColumn Column(string name, string? alias) => new SourceColumn(name, alias);
		public SourceColumn Column(string name, string? alias, string? table) => new SourceColumn(name, alias, string.IsNullOrEmpty(table) ? null : new Table(table));
		public SourceColumn Column(string name, ISource? source) => new SourceColumn(name, source);
		public SourceColumn Column(string name, string? alias, ISource? source) => new SourceColumn(name, alias, source);

		#endregion SourceColumn factory methods

		#endregion Columns factory methods

		#region Conditions factory methods

		#region AndCondition factory methods

		public AndCondition And(params ICondition[] conditions) => new AndCondition(conditions);
		public AndCondition And(IEnumerable<ICondition> conditions) => new AndCondition(conditions);
		public AndCondition And(ConditionBuilder builder) => new AndCondition(builder.Conditions);
		public AndCondition And(Action<ConditionBuilder> buildConditionMethod)
		{
			ConditionBuilder builder = new ConditionBuilder();
			buildConditionMethod.Invoke(builder);

			return new AndCondition(builder.Conditions);
		}

		#endregion AndCondition factory methods

		#region OrCondition factory methods

		public OrCondition Or(params ICondition[] conditions) => new OrCondition(conditions);
		public OrCondition Or(IEnumerable<ICondition> conditions) => new OrCondition(conditions);
		public OrCondition Or(ConditionBuilder builder) => new OrCondition(builder.Conditions);
		public OrCondition Or(Action<ConditionBuilder> buildConditionMethod)
		{
			ConditionBuilder builder = new ConditionBuilder();
			buildConditionMethod.Invoke(builder);

			return new OrCondition(builder.Conditions);
		}

		#endregion OrCondition factory methods

		#region EqualCondition factory methods

		public EqualCondition Equal(IExpression expression, sbyte value) => new EqualCondition(expression, new Int8Value(value));
		public EqualCondition Equal(IExpression expression, short value) => new EqualCondition(expression, new Int16Value(value));
		public EqualCondition Equal(IExpression expression, int value) => new EqualCondition(expression, new Int32Value(value));
		public EqualCondition Equal(IExpression expression, long value) => new EqualCondition(expression, new Int64Value(value));
		public EqualCondition Equal(IExpression expression, float value) => new EqualCondition(expression, new FloatValue(value));
		public EqualCondition Equal(IExpression expression, double value) => new EqualCondition(expression, new DoubleValue(value));
		public EqualCondition Equal(IExpression expression, decimal value) => new EqualCondition(expression, new DecimalValue(value));
		public EqualCondition Equal(IExpression expression, DateTime value, string? format = null) => new EqualCondition(expression, new DateTimeValue(value, format));
		public EqualCondition Equal(IExpression expression, string value) => new EqualCondition(expression, new StringValue(value));
		public EqualCondition Equal(IExpression expression1, IExpression expression2) => new EqualCondition(expression1, expression2);
		public EqualCondition Equal(IExpression expression, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression2 = expressionFunction.Invoke(factory);

			return new EqualCondition(expression, expression2);
		}

		public EqualCondition Equal(string column, sbyte value) => new EqualCondition(new SourceColumn(column), new Int8Value(value));
		public EqualCondition Equal(string column, short value) => new EqualCondition(new SourceColumn(column), new Int16Value(value));
		public EqualCondition Equal(string column, int value) => new EqualCondition(new SourceColumn(column), new Int32Value(value));
		public EqualCondition Equal(string column, long value) => new EqualCondition(new SourceColumn(column), new Int64Value(value));
		public EqualCondition Equal(string column, float value) => new EqualCondition(new SourceColumn(column), new FloatValue(value));
		public EqualCondition Equal(string column, double value) => new EqualCondition(new SourceColumn(column), new DoubleValue(value));
		public EqualCondition Equal(string column, decimal value) => new EqualCondition(new SourceColumn(column), new DecimalValue(value));
		public EqualCondition Equal(string column, DateTime value, string? format = null) => new EqualCondition(new SourceColumn(column), new DateTimeValue(value, format));
		public EqualCondition Equal(string column, string value) => new EqualCondition(new SourceColumn(column), new StringValue(value));
		public EqualCondition Equal(string column, IExpression expression) => new EqualCondition(new SourceColumn(column), expression);
		public EqualCondition Equal(string column, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression = expressionFunction.Invoke(factory);

			return new EqualCondition(new SourceColumn(column), expression);
		}

		public EqualCondition Equal(string column, string table, sbyte value) => new EqualCondition(new SourceColumn(column, new Table(table)), new Int8Value(value));
		public EqualCondition Equal(string column, string table, short value) => new EqualCondition(new SourceColumn(column, new Table(table)), new Int16Value(value));
		public EqualCondition Equal(string column, string table, int value) => new EqualCondition(new SourceColumn(column, new Table(table)), new Int32Value(value));
		public EqualCondition Equal(string column, string table, long value) => new EqualCondition(new SourceColumn(column, new Table(table)), new Int64Value(value));
		public EqualCondition Equal(string column, string table, float value) => new EqualCondition(new SourceColumn(column, new Table(table)), new FloatValue(value));
		public EqualCondition Equal(string column, string table, double value) => new EqualCondition(new SourceColumn(column, new Table(table)), new DoubleValue(value));
		public EqualCondition Equal(string column, string table, decimal value) => new EqualCondition(new SourceColumn(column, new Table(table)), new DecimalValue(value));
		public EqualCondition Equal(string column, string table, DateTime value, string? format = null) => new EqualCondition(new SourceColumn(column, new Table(table)), new DateTimeValue(value, format));
		public EqualCondition Equal(string column, string table, string value) => new EqualCondition(new SourceColumn(column, new Table(table)), new StringValue(value));
		public EqualCondition Equal(string column, string table, IExpression expression) => new EqualCondition(new SourceColumn(column, new Table(table)), expression);
		public EqualCondition Equal(string column, string table, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression = expressionFunction.Invoke(factory);

			return new EqualCondition(new SourceColumn(column, new Table(table)), expression);
		}

		public EqualCondition Equal(string column, ISource source, sbyte value) => new EqualCondition(new SourceColumn(column, source), new Int8Value(value));
		public EqualCondition Equal(string column, ISource source, short value) => new EqualCondition(new SourceColumn(column, source), new Int16Value(value));
		public EqualCondition Equal(string column, ISource source, int value) => new EqualCondition(new SourceColumn(column, source), new Int32Value(value));
		public EqualCondition Equal(string column, ISource source, long value) => new EqualCondition(new SourceColumn(column, source), new Int64Value(value));
		public EqualCondition Equal(string column, ISource source, float value) => new EqualCondition(new SourceColumn(column, source), new FloatValue(value));
		public EqualCondition Equal(string column, ISource source, double value) => new EqualCondition(new SourceColumn(column, source), new DoubleValue(value));
		public EqualCondition Equal(string column, ISource source, decimal value) => new EqualCondition(new SourceColumn(column, source), new DecimalValue(value));
		public EqualCondition Equal(string column, ISource source, DateTime value, string? format = null) => new EqualCondition(new SourceColumn(column, source), new DateTimeValue(value, format));
		public EqualCondition Equal(string column, ISource source, string value) => new EqualCondition(new SourceColumn(column, source), new StringValue(value));
		public EqualCondition Equal(string column, ISource source, IExpression expression) => new EqualCondition(new SourceColumn(column, source), expression);
		public EqualCondition Equal(string column, ISource source, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression = expressionFunction.Invoke(factory);

			return new EqualCondition(new SourceColumn(column, source), expression);
		}

		public EqualCondition Equal(string column1, string table1, string column2, string table2) => new EqualCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, new Table(table2)));
		public EqualCondition Equal(string column1, string table1, string column2, ISource source2) => new EqualCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, source2));
		public EqualCondition Equal(string column1, ISource source1, string column2, string table2) => new EqualCondition(new SourceColumn(column1, source1), new SourceColumn(column2, new Table(table2)));
		public EqualCondition Equal(string column1, ISource source1, string column2, ISource source2) => new EqualCondition(new SourceColumn(column1, source1), new SourceColumn(column2, source2));
		public EqualCondition Equal(Func<ExpressionFactory, IExpression> expressionFunction1, Func<ExpressionFactory, IExpression> expressionFunction2)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression1 = expressionFunction1(factory);
			IExpression expression2 = expressionFunction2(factory);

			return new EqualCondition(expression1, expression2);
		}

		#endregion EqualCondition factory methods

		#region NotEqualCondition factory methods

		public NotEqualCondition NotEqual(IExpression expression, sbyte value) => new NotEqualCondition(expression, new Int8Value(value));
		public NotEqualCondition NotEqual(IExpression expression, short value) => new NotEqualCondition(expression, new Int16Value(value));
		public NotEqualCondition NotEqual(IExpression expression, int value) => new NotEqualCondition(expression, new Int32Value(value));
		public NotEqualCondition NotEqual(IExpression expression, long value) => new NotEqualCondition(expression, new Int64Value(value));
		public NotEqualCondition NotEqual(IExpression expression, float value) => new NotEqualCondition(expression, new FloatValue(value));
		public NotEqualCondition NotEqual(IExpression expression, double value) => new NotEqualCondition(expression, new DoubleValue(value));
		public NotEqualCondition NotEqual(IExpression expression, decimal value) => new NotEqualCondition(expression, new DecimalValue(value));
		public NotEqualCondition NotEqual(IExpression expression, DateTime value, string? format = null) => new NotEqualCondition(expression, new DateTimeValue(value, format));
		public NotEqualCondition NotEqual(IExpression expression, string value) => new NotEqualCondition(expression, new StringValue(value));
		public NotEqualCondition NotEqual(IExpression expression1, IExpression expression2) => new NotEqualCondition(expression1, expression2);
		public NotEqualCondition NotEqual(IExpression expression, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression2 = expressionFunction.Invoke(factory);

			return new NotEqualCondition(expression, expression2);
		}

		public NotEqualCondition NotEqual(string column, sbyte value) => new NotEqualCondition(new SourceColumn(column), new Int8Value(value));
		public NotEqualCondition NotEqual(string column, short value) => new NotEqualCondition(new SourceColumn(column), new Int16Value(value));
		public NotEqualCondition NotEqual(string column, int value) => new NotEqualCondition(new SourceColumn(column), new Int32Value(value));
		public NotEqualCondition NotEqual(string column, long value) => new NotEqualCondition(new SourceColumn(column), new Int64Value(value));
		public NotEqualCondition NotEqual(string column, float value) => new NotEqualCondition(new SourceColumn(column), new FloatValue(value));
		public NotEqualCondition NotEqual(string column, double value) => new NotEqualCondition(new SourceColumn(column), new DoubleValue(value));
		public NotEqualCondition NotEqual(string column, decimal value) => new NotEqualCondition(new SourceColumn(column), new DecimalValue(value));
		public NotEqualCondition NotEqual(string column, DateTime value, string? format = null) => new NotEqualCondition(new SourceColumn(column), new DateTimeValue(value, format));
		public NotEqualCondition NotEqual(string column, string value) => new NotEqualCondition(new SourceColumn(column), new StringValue(value));
		public NotEqualCondition NotEqual(string column, IExpression expression) => new NotEqualCondition(new SourceColumn(column), expression);
		public NotEqualCondition NotEqual(string column, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression = expressionFunction.Invoke(factory);

			return new NotEqualCondition(new SourceColumn(column), expression);
		}

		public NotEqualCondition NotEqual(string column, string table, sbyte value) => new NotEqualCondition(new SourceColumn(column, new Table(table)), new Int8Value(value));
		public NotEqualCondition NotEqual(string column, string table, short value) => new NotEqualCondition(new SourceColumn(column, new Table(table)), new Int16Value(value));
		public NotEqualCondition NotEqual(string column, string table, int value) => new NotEqualCondition(new SourceColumn(column, new Table(table)), new Int32Value(value));
		public NotEqualCondition NotEqual(string column, string table, long value) => new NotEqualCondition(new SourceColumn(column, new Table(table)), new Int64Value(value));
		public NotEqualCondition NotEqual(string column, string table, float value) => new NotEqualCondition(new SourceColumn(column, new Table(table)), new FloatValue(value));
		public NotEqualCondition NotEqual(string column, string table, double value) => new NotEqualCondition(new SourceColumn(column, new Table(table)), new DoubleValue(value));
		public NotEqualCondition NotEqual(string column, string table, decimal value) => new NotEqualCondition(new SourceColumn(column, new Table(table)), new DecimalValue(value));
		public NotEqualCondition NotEqual(string column, string table, DateTime value, string? format = null) => new NotEqualCondition(new SourceColumn(column, new Table(table)), new DateTimeValue(value, format));
		public NotEqualCondition NotEqual(string column, string table, string value) => new NotEqualCondition(new SourceColumn(column, new Table(table)), new StringValue(value));
		public NotEqualCondition NotEqual(string column, string table, IExpression expression) => new NotEqualCondition(new SourceColumn(column, new Table(table)), expression);
		public NotEqualCondition NotEqual(string column, string table, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression = expressionFunction.Invoke(factory);

			return new NotEqualCondition(new SourceColumn(column, new Table(table)), expression);
		}

		public NotEqualCondition NotEqual(string column, ISource source, sbyte value) => new NotEqualCondition(new SourceColumn(column, source), new Int8Value(value));
		public NotEqualCondition NotEqual(string column, ISource source, short value) => new NotEqualCondition(new SourceColumn(column, source), new Int16Value(value));
		public NotEqualCondition NotEqual(string column, ISource source, int value) => new NotEqualCondition(new SourceColumn(column, source), new Int32Value(value));
		public NotEqualCondition NotEqual(string column, ISource source, long value) => new NotEqualCondition(new SourceColumn(column, source), new Int64Value(value));
		public NotEqualCondition NotEqual(string column, ISource source, float value) => new NotEqualCondition(new SourceColumn(column, source), new FloatValue(value));
		public NotEqualCondition NotEqual(string column, ISource source, double value) => new NotEqualCondition(new SourceColumn(column, source), new DoubleValue(value));
		public NotEqualCondition NotEqual(string column, ISource source, decimal value) => new NotEqualCondition(new SourceColumn(column, source), new DecimalValue(value));
		public NotEqualCondition NotEqual(string column, ISource source, DateTime value, string? format = null) => new NotEqualCondition(new SourceColumn(column, source), new DateTimeValue(value, format));
		public NotEqualCondition NotEqual(string column, ISource source, string value) => new NotEqualCondition(new SourceColumn(column, source), new StringValue(value));
		public NotEqualCondition NotEqual(string column, ISource source, IExpression expression) => new NotEqualCondition(new SourceColumn(column, source), expression);
		public NotEqualCondition NotEqual(string column, ISource source, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression = expressionFunction.Invoke(factory);

			return new NotEqualCondition(new SourceColumn(column, source), expression);
		}

		public NotEqualCondition NotEqual(string column1, string table1, string column2, string table2) => new NotEqualCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, new Table(table2)));
		public NotEqualCondition NotEqual(string column1, string table1, string column2, ISource source2) => new NotEqualCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, source2));
		public NotEqualCondition NotEqual(string column1, ISource source1, string column2, string table2) => new NotEqualCondition(new SourceColumn(column1, source1), new SourceColumn(column2, new Table(table2)));
		public NotEqualCondition NotEqual(string column1, ISource source1, string column2, ISource source2) => new NotEqualCondition(new SourceColumn(column1, source1), new SourceColumn(column2, source2));
		public NotEqualCondition NotEqual(Func<ExpressionFactory, IExpression> expressionFunction1, Func<ExpressionFactory, IExpression> expressionFunction2)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression1 = expressionFunction1(factory);
			IExpression expression2 = expressionFunction2(factory);

			return new NotEqualCondition(expression1, expression2);
		}

		#endregion NotEqualCondition factory methods

		#region ExistsCondition factory methods

		public ExistsCondition Exists(string column, Select select) => new ExistsCondition(new SourceColumn(column), select);
		public ExistsCondition Exists(string column, string table, Select select) => new ExistsCondition(new SourceColumn(column, new Table(table)), select);
		public ExistsCondition Exists(string column, ISource source, Select select) => new ExistsCondition(new SourceColumn(column, source), select);
		public ExistsCondition Exists(IExpression expression, Select select) => new ExistsCondition(expression, select);
		public ExistsCondition Exists(Func<ExpressionFactory, IExpression> expressionFunction, Select select)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression = expressionFunction(factory);

			return new ExistsCondition(expression, select);
		}

		#endregion ExistsCondition factory methods

		#region NotExistsCondition factory methods

		public NotExistsCondition NotExists(string column, Select select) => new NotExistsCondition(new SourceColumn(column), select);
		public NotExistsCondition NotExists(string column, string table, Select select) => new NotExistsCondition(new SourceColumn(column, new Table(table)), select);
		public NotExistsCondition NotExists(string column, ISource source, Select select) => new NotExistsCondition(new SourceColumn(column, source), select);
		public NotExistsCondition NotExists(IExpression expression, Select select) => new NotExistsCondition(expression, select);
		public NotExistsCondition NotExists(Func<ExpressionFactory, IExpression> expressionFunction, Select select)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression = expressionFunction(factory);

			return new NotExistsCondition(expression, select);
		}

		#endregion NotExistsCondition factory methods

		#region GreaterCondition factory methods

		public GreaterCondition Greater(IExpression expression, sbyte value) => new GreaterCondition(expression, new Int8Value(value));
		public GreaterCondition Greater(IExpression expression, short value) => new GreaterCondition(expression, new Int16Value(value));
		public GreaterCondition Greater(IExpression expression, int value) => new GreaterCondition(expression, new Int32Value(value));
		public GreaterCondition Greater(IExpression expression, long value) => new GreaterCondition(expression, new Int64Value(value));
		public GreaterCondition Greater(IExpression expression, float value) => new GreaterCondition(expression, new FloatValue(value));
		public GreaterCondition Greater(IExpression expression, double value) => new GreaterCondition(expression, new DoubleValue(value));
		public GreaterCondition Greater(IExpression expression, decimal value) => new GreaterCondition(expression, new DecimalValue(value));
		public GreaterCondition Greater(IExpression expression, DateTime value, string? format = null) => new GreaterCondition(expression, new DateTimeValue(value, format));
		public GreaterCondition Greater(IExpression expression, string value) => new GreaterCondition(expression, new StringValue(value));
		public GreaterCondition Greater(IExpression expression1, IExpression expression2) => new GreaterCondition(expression1, expression2);
		public GreaterCondition Greater(IExpression expression, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression2 = expressionFunction.Invoke(factory);

			return new GreaterCondition(expression, expression2);
		}

		public GreaterCondition Greater(string column, sbyte value) => new GreaterCondition(new SourceColumn(column), new Int8Value(value));
		public GreaterCondition Greater(string column, short value) => new GreaterCondition(new SourceColumn(column), new Int16Value(value));
		public GreaterCondition Greater(string column, int value) => new GreaterCondition(new SourceColumn(column), new Int32Value(value));
		public GreaterCondition Greater(string column, long value) => new GreaterCondition(new SourceColumn(column), new Int64Value(value));
		public GreaterCondition Greater(string column, float value) => new GreaterCondition(new SourceColumn(column), new FloatValue(value));
		public GreaterCondition Greater(string column, double value) => new GreaterCondition(new SourceColumn(column), new DoubleValue(value));
		public GreaterCondition Greater(string column, decimal value) => new GreaterCondition(new SourceColumn(column), new DecimalValue(value));
		public GreaterCondition Greater(string column, DateTime value, string? format = null) => new GreaterCondition(new SourceColumn(column), new DateTimeValue(value, format));
		public GreaterCondition Greater(string column, string value) => new GreaterCondition(new SourceColumn(column), new StringValue(value));
		public GreaterCondition Greater(string column, IExpression expression) => new GreaterCondition(new SourceColumn(column), expression);
		public GreaterCondition Greater(string column, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression = expressionFunction.Invoke(factory);

			return new GreaterCondition(new SourceColumn(column), expression);
		}

		public GreaterCondition Greater(string column, string table, sbyte value) => new GreaterCondition(new SourceColumn(column, new Table(table)), new Int8Value(value));
		public GreaterCondition Greater(string column, string table, short value) => new GreaterCondition(new SourceColumn(column, new Table(table)), new Int16Value(value));
		public GreaterCondition Greater(string column, string table, int value) => new GreaterCondition(new SourceColumn(column, new Table(table)), new Int32Value(value));
		public GreaterCondition Greater(string column, string table, long value) => new GreaterCondition(new SourceColumn(column, new Table(table)), new Int64Value(value));
		public GreaterCondition Greater(string column, string table, float value) => new GreaterCondition(new SourceColumn(column, new Table(table)), new FloatValue(value));
		public GreaterCondition Greater(string column, string table, double value) => new GreaterCondition(new SourceColumn(column, new Table(table)), new DoubleValue(value));
		public GreaterCondition Greater(string column, string table, decimal value) => new GreaterCondition(new SourceColumn(column, new Table(table)), new DecimalValue(value));
		public GreaterCondition Greater(string column, string table, DateTime value, string? format = null) => new GreaterCondition(new SourceColumn(column, new Table(table)), new DateTimeValue(value, format));
		public GreaterCondition Greater(string column, string table, string value) => new GreaterCondition(new SourceColumn(column, new Table(table)), new StringValue(value));
		public GreaterCondition Greater(string column, string table, IExpression expression) => new GreaterCondition(new SourceColumn(column, new Table(table)), expression);
		public GreaterCondition Greater(string column, string table, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression = expressionFunction.Invoke(factory);

			return new GreaterCondition(new SourceColumn(column, new Table(table)), expression);
		}

		public GreaterCondition Greater(string column, ISource source, sbyte value) => new GreaterCondition(new SourceColumn(column, source), new Int8Value(value));
		public GreaterCondition Greater(string column, ISource source, short value) => new GreaterCondition(new SourceColumn(column, source), new Int16Value(value));
		public GreaterCondition Greater(string column, ISource source, int value) => new GreaterCondition(new SourceColumn(column, source), new Int32Value(value));
		public GreaterCondition Greater(string column, ISource source, long value) => new GreaterCondition(new SourceColumn(column, source), new Int64Value(value));
		public GreaterCondition Greater(string column, ISource source, float value) => new GreaterCondition(new SourceColumn(column, source), new FloatValue(value));
		public GreaterCondition Greater(string column, ISource source, double value) => new GreaterCondition(new SourceColumn(column, source), new DoubleValue(value));
		public GreaterCondition Greater(string column, ISource source, decimal value) => new GreaterCondition(new SourceColumn(column, source), new DecimalValue(value));
		public GreaterCondition Greater(string column, ISource source, DateTime value, string? format = null) => new GreaterCondition(new SourceColumn(column, source), new DateTimeValue(value, format));
		public GreaterCondition Greater(string column, ISource source, string value) => new GreaterCondition(new SourceColumn(column, source), new StringValue(value));
		public GreaterCondition Greater(string column, ISource source, IExpression expression) => new GreaterCondition(new SourceColumn(column, source), expression);
		public GreaterCondition Greater(string column, ISource source, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression = expressionFunction.Invoke(factory);

			return new GreaterCondition(new SourceColumn(column, source), expression);
		}

		public GreaterCondition Greater(string column1, string table1, string column2, string table2) => new GreaterCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, new Table(table2)));
		public GreaterCondition Greater(string column1, string table1, string column2, ISource source2) => new GreaterCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, source2));
		public GreaterCondition Greater(string column1, ISource source1, string column2, string table2) => new GreaterCondition(new SourceColumn(column1, source1), new SourceColumn(column2, new Table(table2)));
		public GreaterCondition Greater(string column1, ISource source1, string column2, ISource source2) => new GreaterCondition(new SourceColumn(column1, source1), new SourceColumn(column2, source2));
		public GreaterCondition Greater(Func<ExpressionFactory, IExpression> expressionFunction1, Func<ExpressionFactory, IExpression> expressionFunction2)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression1 = expressionFunction1(factory);
			IExpression expression2 = expressionFunction2(factory);

			return new GreaterCondition(expression1, expression2);
		}

		#endregion GreaterCondition factory methods

		#region GreaterOrEqualCondition factory methods

		public GreaterOrEqualCondition GreaterOrEqual(IExpression expression, sbyte value) => new GreaterOrEqualCondition(expression, new Int8Value(value));
		public GreaterOrEqualCondition GreaterOrEqual(IExpression expression, short value) => new GreaterOrEqualCondition(expression, new Int16Value(value));
		public GreaterOrEqualCondition GreaterOrEqual(IExpression expression, int value) => new GreaterOrEqualCondition(expression, new Int32Value(value));
		public GreaterOrEqualCondition GreaterOrEqual(IExpression expression, long value) => new GreaterOrEqualCondition(expression, new Int64Value(value));
		public GreaterOrEqualCondition GreaterOrEqual(IExpression expression, float value) => new GreaterOrEqualCondition(expression, new FloatValue(value));
		public GreaterOrEqualCondition GreaterOrEqual(IExpression expression, double value) => new GreaterOrEqualCondition(expression, new DoubleValue(value));
		public GreaterOrEqualCondition GreaterOrEqual(IExpression expression, decimal value) => new GreaterOrEqualCondition(expression, new DecimalValue(value));
		public GreaterOrEqualCondition GreaterOrEqual(IExpression expression, DateTime value, string? format = null) => new GreaterOrEqualCondition(expression, new DateTimeValue(value, format));
		public GreaterOrEqualCondition GreaterOrEqual(IExpression expression, string value) => new GreaterOrEqualCondition(expression, new StringValue(value));
		public GreaterOrEqualCondition GreaterOrEqual(IExpression expression1, IExpression expression2) => new GreaterOrEqualCondition(expression1, expression2);
		public GreaterOrEqualCondition GreaterOrEqual(IExpression expression, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression2 = expressionFunction.Invoke(factory);

			return new GreaterOrEqualCondition(expression, expression2);
		}

		public GreaterOrEqualCondition GreaterOrEqual(string column, sbyte value) => new GreaterOrEqualCondition(new SourceColumn(column), new Int8Value(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, short value) => new GreaterOrEqualCondition(new SourceColumn(column), new Int16Value(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, int value) => new GreaterOrEqualCondition(new SourceColumn(column), new Int32Value(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, long value) => new GreaterOrEqualCondition(new SourceColumn(column), new Int64Value(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, float value) => new GreaterOrEqualCondition(new SourceColumn(column), new FloatValue(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, double value) => new GreaterOrEqualCondition(new SourceColumn(column), new DoubleValue(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, decimal value) => new GreaterOrEqualCondition(new SourceColumn(column), new DecimalValue(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, DateTime value, string? format = null) => new GreaterOrEqualCondition(new SourceColumn(column), new DateTimeValue(value, format));
		public GreaterOrEqualCondition GreaterOrEqual(string column, string value) => new GreaterOrEqualCondition(new SourceColumn(column), new StringValue(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, IExpression expression) => new GreaterOrEqualCondition(new SourceColumn(column), expression);
		public GreaterOrEqualCondition GreaterOrEqual(string column, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression2 = expressionFunction.Invoke(factory);

			return new GreaterOrEqualCondition(new SourceColumn(column), expression2);
		}

		public GreaterOrEqualCondition GreaterOrEqual(string column, string table, sbyte value) => new GreaterOrEqualCondition(new SourceColumn(column, new Table(table)), new Int8Value(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, string table, short value) => new GreaterOrEqualCondition(new SourceColumn(column, new Table(table)), new Int16Value(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, string table, int value) => new GreaterOrEqualCondition(new SourceColumn(column, new Table(table)), new Int32Value(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, string table, long value) => new GreaterOrEqualCondition(new SourceColumn(column, new Table(table)), new Int64Value(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, string table, float value) => new GreaterOrEqualCondition(new SourceColumn(column, new Table(table)), new FloatValue(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, string table, double value) => new GreaterOrEqualCondition(new SourceColumn(column, new Table(table)), new DoubleValue(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, string table, decimal value) => new GreaterOrEqualCondition(new SourceColumn(column, new Table(table)), new DecimalValue(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, string table, DateTime value, string? format = null) => new GreaterOrEqualCondition(new SourceColumn(column, new Table(table)), new DateTimeValue(value, format));
		public GreaterOrEqualCondition GreaterOrEqual(string column, string table, string value) => new GreaterOrEqualCondition(new SourceColumn(column, new Table(table)), new StringValue(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, string table, IExpression expression) => new GreaterOrEqualCondition(new SourceColumn(column, new Table(table)), expression);
		public GreaterOrEqualCondition GreaterOrEqual(string column, string table, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression2 = expressionFunction.Invoke(factory);

			return new GreaterOrEqualCondition(new SourceColumn(column, new Table(table)), expression2);
		}

		public GreaterOrEqualCondition GreaterOrEqual(string column, ISource source, sbyte value) => new GreaterOrEqualCondition(new SourceColumn(column, source), new Int8Value(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, ISource source, short value) => new GreaterOrEqualCondition(new SourceColumn(column, source), new Int16Value(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, ISource source, int value) => new GreaterOrEqualCondition(new SourceColumn(column, source), new Int32Value(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, ISource source, long value) => new GreaterOrEqualCondition(new SourceColumn(column, source), new Int64Value(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, ISource source, float value) => new GreaterOrEqualCondition(new SourceColumn(column, source), new FloatValue(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, ISource source, double value) => new GreaterOrEqualCondition(new SourceColumn(column, source), new DoubleValue(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, ISource source, decimal value) => new GreaterOrEqualCondition(new SourceColumn(column, source), new DecimalValue(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, ISource source, DateTime value, string? format = null) => new GreaterOrEqualCondition(new SourceColumn(column, source), new DateTimeValue(value, format));
		public GreaterOrEqualCondition GreaterOrEqual(string column, ISource source, string value) => new GreaterOrEqualCondition(new SourceColumn(column, source), new StringValue(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, ISource source, IExpression expression) => new GreaterOrEqualCondition(new SourceColumn(column, source), expression);
		public GreaterOrEqualCondition GreaterOrEqual(string column, ISource source, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression2 = expressionFunction.Invoke(factory);

			return new GreaterOrEqualCondition(new SourceColumn(column, source), expression2);
		}

		public GreaterOrEqualCondition GreaterOrEqual(string column1, string table1, string column2, string table2) => new GreaterOrEqualCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, new Table(table2)));
		public GreaterOrEqualCondition GreaterOrEqual(string column1, string table1, string column2, ISource source2) => new GreaterOrEqualCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, source2));
		public GreaterOrEqualCondition GreaterOrEqual(string column1, ISource source1, string column2, string table2) => new GreaterOrEqualCondition(new SourceColumn(column1, source1), new SourceColumn(column2, new Table(table2)));
		public GreaterOrEqualCondition GreaterOrEqual(string column1, ISource source1, string column2, ISource source2) => new GreaterOrEqualCondition(new SourceColumn(column1, source1), new SourceColumn(column2, source2));
		public GreaterOrEqualCondition GreaterOrEqual(Func<ExpressionFactory, IExpression> expressionFunction1, Func<ExpressionFactory, IExpression> expressionFunction2)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression1 = expressionFunction1.Invoke(factory);
			IExpression expression2 = expressionFunction2.Invoke(factory);

			return new GreaterOrEqualCondition(expression1, expression2);
		}

		#endregion GreaterOrEqualCondition factory methods

		#region LessCondition factory methods

		public LessCondition Less(IExpression expression, sbyte value) => new LessCondition(expression, new Int8Value(value));
		public LessCondition Less(IExpression expression, short value) => new LessCondition(expression, new Int16Value(value));
		public LessCondition Less(IExpression expression, int value) => new LessCondition(expression, new Int32Value(value));
		public LessCondition Less(IExpression expression, long value) => new LessCondition(expression, new Int64Value(value));
		public LessCondition Less(IExpression expression, float value) => new LessCondition(expression, new FloatValue(value));
		public LessCondition Less(IExpression expression, double value) => new LessCondition(expression, new DoubleValue(value));
		public LessCondition Less(IExpression expression, decimal value) => new LessCondition(expression, new DecimalValue(value));
		public LessCondition Less(IExpression expression, DateTime value, string? format = null) => new LessCondition(expression, new DateTimeValue(value, format));
		public LessCondition Less(IExpression expression, string value) => new LessCondition(expression, new StringValue(value));
		public LessCondition Less(IExpression expression1, IExpression expression2) => new LessCondition(expression1, expression2);
		public LessCondition Less(IExpression expression, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression2 = expressionFunction.Invoke(factory);

			return new LessCondition(expression, expression2);
		}

		public LessCondition Less(string column, sbyte value) => new LessCondition(new SourceColumn(column), new Int8Value(value));
		public LessCondition Less(string column, short value) => new LessCondition(new SourceColumn(column), new Int16Value(value));
		public LessCondition Less(string column, int value) => new LessCondition(new SourceColumn(column), new Int32Value(value));
		public LessCondition Less(string column, long value) => new LessCondition(new SourceColumn(column), new Int64Value(value));
		public LessCondition Less(string column, float value) => new LessCondition(new SourceColumn(column), new FloatValue(value));
		public LessCondition Less(string column, double value) => new LessCondition(new SourceColumn(column), new DoubleValue(value));
		public LessCondition Less(string column, decimal value) => new LessCondition(new SourceColumn(column), new DecimalValue(value));
		public LessCondition Less(string column, DateTime value, string? format = null) => new LessCondition(new SourceColumn(column), new DateTimeValue(value, format));
		public LessCondition Less(string column, string value) => new LessCondition(new SourceColumn(column), new StringValue(value));
		public LessCondition Less(string column, IExpression expression) => new LessCondition(new SourceColumn(column), expression);
		public LessCondition Less(string column, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression2 = expressionFunction.Invoke(factory);

			return new LessCondition(new SourceColumn(column), expression2);
		}

		public LessCondition Less(string column, string table, sbyte value) => new LessCondition(new SourceColumn(column, new Table(table)), new Int8Value(value));
		public LessCondition Less(string column, string table, short value) => new LessCondition(new SourceColumn(column, new Table(table)), new Int16Value(value));
		public LessCondition Less(string column, string table, int value) => new LessCondition(new SourceColumn(column, new Table(table)), new Int32Value(value));
		public LessCondition Less(string column, string table, long value) => new LessCondition(new SourceColumn(column, new Table(table)), new Int64Value(value));
		public LessCondition Less(string column, string table, float value) => new LessCondition(new SourceColumn(column, new Table(table)), new FloatValue(value));
		public LessCondition Less(string column, string table, double value) => new LessCondition(new SourceColumn(column, new Table(table)), new DoubleValue(value));
		public LessCondition Less(string column, string table, decimal value) => new LessCondition(new SourceColumn(column, new Table(table)), new DecimalValue(value));
		public LessCondition Less(string column, string table, DateTime value, string? format = null) => new LessCondition(new SourceColumn(column, new Table(table)), new DateTimeValue(value, format));
		public LessCondition Less(string column, string table, string value) => new LessCondition(new SourceColumn(column, new Table(table)), new StringValue(value));
		public LessCondition Less(string column, string table, IExpression expression) => new LessCondition(new SourceColumn(column, new Table(table)), expression);
		public LessCondition Less(string column, string table, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression2 = expressionFunction.Invoke(factory);

			return new LessCondition(new SourceColumn(column, new Table(table)), expression2);
		}

		public LessCondition Less(string column, ISource source, sbyte value) => new LessCondition(new SourceColumn(column, source), new Int8Value(value));
		public LessCondition Less(string column, ISource source, short value) => new LessCondition(new SourceColumn(column, source), new Int16Value(value));
		public LessCondition Less(string column, ISource source, int value) => new LessCondition(new SourceColumn(column, source), new Int32Value(value));
		public LessCondition Less(string column, ISource source, long value) => new LessCondition(new SourceColumn(column, source), new Int64Value(value));
		public LessCondition Less(string column, ISource source, float value) => new LessCondition(new SourceColumn(column, source), new FloatValue(value));
		public LessCondition Less(string column, ISource source, double value) => new LessCondition(new SourceColumn(column, source), new DoubleValue(value));
		public LessCondition Less(string column, ISource source, decimal value) => new LessCondition(new SourceColumn(column, source), new DecimalValue(value));
		public LessCondition Less(string column, ISource source, DateTime value, string? format = null) => new LessCondition(new SourceColumn(column, source), new DateTimeValue(value, format));
		public LessCondition Less(string column, ISource source, string value) => new LessCondition(new SourceColumn(column, source), new StringValue(value));
		public LessCondition Less(string column, ISource source, IExpression expression) => new LessCondition(new SourceColumn(column, source), expression);
		public LessCondition Less(string column, ISource source, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression2 = expressionFunction.Invoke(factory);

			return new LessCondition(new SourceColumn(column, source), expression2);
		}

		public LessCondition Less(string column1, string table1, string column2, string table2) => new LessCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, new Table(table2)));
		public LessCondition Less(string column1, string table1, string column2, ISource source2) => new LessCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, source2));
		public LessCondition Less(string column1, ISource source1, string column2, string table2) => new LessCondition(new SourceColumn(column1, source1), new SourceColumn(column2, new Table(table2)));
		public LessCondition Less(string column1, ISource source1, string column2, ISource source2) => new LessCondition(new SourceColumn(column1, source1), new SourceColumn(column2, source2));
		public LessCondition Less(Func<ExpressionFactory, IExpression> expressionFunction1, Func<ExpressionFactory, IExpression> expressionFunction2)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression1 = expressionFunction1.Invoke(factory);
			IExpression expression2 = expressionFunction2.Invoke(factory);

			return new LessCondition(expression1, expression2);
		}

		#endregion LessCondition factory methods

		#region LessOrEqualCondition factory methods

		public LessOrEqualCondition LessOrEqual(IExpression expression, sbyte value) => new LessOrEqualCondition(expression, new Int8Value(value));
		public LessOrEqualCondition LessOrEqual(IExpression expression, short value) => new LessOrEqualCondition(expression, new Int16Value(value));
		public LessOrEqualCondition LessOrEqual(IExpression expression, int value) => new LessOrEqualCondition(expression, new Int32Value(value));
		public LessOrEqualCondition LessOrEqual(IExpression expression, long value) => new LessOrEqualCondition(expression, new Int64Value(value));
		public LessOrEqualCondition LessOrEqual(IExpression expression, float value) => new LessOrEqualCondition(expression, new FloatValue(value));
		public LessOrEqualCondition LessOrEqual(IExpression expression, double value) => new LessOrEqualCondition(expression, new DoubleValue(value));
		public LessOrEqualCondition LessOrEqual(IExpression expression, decimal value) => new LessOrEqualCondition(expression, new DecimalValue(value));
		public LessOrEqualCondition LessOrEqual(IExpression expression, DateTime value, string? format = null) => new LessOrEqualCondition(expression, new DateTimeValue(value, format));
		public LessOrEqualCondition LessOrEqual(IExpression expression, string value) => new LessOrEqualCondition(expression, new StringValue(value));
		public LessOrEqualCondition LessOrEqual(IExpression expression1, IExpression expression2) => new LessOrEqualCondition(expression1, expression2);
		public LessOrEqualCondition LessOrEqual(IExpression expression, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression2 = expressionFunction.Invoke(factory);

			return new LessOrEqualCondition(expression, expression2);
		}

		public LessOrEqualCondition LessOrEqual(string column, sbyte value) => new LessOrEqualCondition(new SourceColumn(column), new Int8Value(value));
		public LessOrEqualCondition LessOrEqual(string column, short value) => new LessOrEqualCondition(new SourceColumn(column), new Int16Value(value));
		public LessOrEqualCondition LessOrEqual(string column, int value) => new LessOrEqualCondition(new SourceColumn(column), new Int32Value(value));
		public LessOrEqualCondition LessOrEqual(string column, long value) => new LessOrEqualCondition(new SourceColumn(column), new Int64Value(value));
		public LessOrEqualCondition LessOrEqual(string column, float value) => new LessOrEqualCondition(new SourceColumn(column), new FloatValue(value));
		public LessOrEqualCondition LessOrEqual(string column, double value) => new LessOrEqualCondition(new SourceColumn(column), new DoubleValue(value));
		public LessOrEqualCondition LessOrEqual(string column, decimal value) => new LessOrEqualCondition(new SourceColumn(column), new DecimalValue(value));
		public LessOrEqualCondition LessOrEqual(string column, DateTime value, string? format = null) => new LessOrEqualCondition(new SourceColumn(column), new DateTimeValue(value, format));
		public LessOrEqualCondition LessOrEqual(string column, string value) => new LessOrEqualCondition(new SourceColumn(column), new StringValue(value));
		public LessOrEqualCondition LessOrEqual(string column, IExpression expression) => new LessOrEqualCondition(new SourceColumn(column), expression);
		public LessOrEqualCondition LessOrEqual(string column, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression2 = expressionFunction.Invoke(factory);

			return new LessOrEqualCondition(new SourceColumn(column), expression2);
		}

		public LessOrEqualCondition LessOrEqual(string column, string table, sbyte value) => new LessOrEqualCondition(new SourceColumn(column, new Table(table)), new Int8Value(value));
		public LessOrEqualCondition LessOrEqual(string column, string table, short value) => new LessOrEqualCondition(new SourceColumn(column, new Table(table)), new Int16Value(value));
		public LessOrEqualCondition LessOrEqual(string column, string table, int value) => new LessOrEqualCondition(new SourceColumn(column, new Table(table)), new Int32Value(value));
		public LessOrEqualCondition LessOrEqual(string column, string table, long value) => new LessOrEqualCondition(new SourceColumn(column, new Table(table)), new Int64Value(value));
		public LessOrEqualCondition LessOrEqual(string column, string table, float value) => new LessOrEqualCondition(new SourceColumn(column, new Table(table)), new FloatValue(value));
		public LessOrEqualCondition LessOrEqual(string column, string table, double value) => new LessOrEqualCondition(new SourceColumn(column, new Table(table)), new DoubleValue(value));
		public LessOrEqualCondition LessOrEqual(string column, string table, decimal value) => new LessOrEqualCondition(new SourceColumn(column, new Table(table)), new DecimalValue(value));
		public LessOrEqualCondition LessOrEqual(string column, string table, DateTime value, string? format = null) => new LessOrEqualCondition(new SourceColumn(column, new Table(table)), new DateTimeValue(value, format));
		public LessOrEqualCondition LessOrEqual(string column, string table, string value) => new LessOrEqualCondition(new SourceColumn(column, new Table(table)), new StringValue(value));
		public LessOrEqualCondition LessOrEqual(string column, string table, IExpression expression) => new LessOrEqualCondition(new SourceColumn(column, new Table(table)), expression);
		public LessOrEqualCondition LessOrEqual(string column, string table, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression2 = expressionFunction.Invoke(factory);

			return new LessOrEqualCondition(new SourceColumn(column, new Table(table)), expression2);
		}

		public LessOrEqualCondition LessOrEqual(string column, ISource source, sbyte value) => new LessOrEqualCondition(new SourceColumn(column, source), new Int8Value(value));
		public LessOrEqualCondition LessOrEqual(string column, ISource source, short value) => new LessOrEqualCondition(new SourceColumn(column, source), new Int16Value(value));
		public LessOrEqualCondition LessOrEqual(string column, ISource source, int value) => new LessOrEqualCondition(new SourceColumn(column, source), new Int32Value(value));
		public LessOrEqualCondition LessOrEqual(string column, ISource source, long value) => new LessOrEqualCondition(new SourceColumn(column, source), new Int64Value(value));
		public LessOrEqualCondition LessOrEqual(string column, ISource source, float value) => new LessOrEqualCondition(new SourceColumn(column, source), new FloatValue(value));
		public LessOrEqualCondition LessOrEqual(string column, ISource source, double value) => new LessOrEqualCondition(new SourceColumn(column, source), new DoubleValue(value));
		public LessOrEqualCondition LessOrEqual(string column, ISource source, decimal value) => new LessOrEqualCondition(new SourceColumn(column, source), new DecimalValue(value));
		public LessOrEqualCondition LessOrEqual(string column, ISource source, DateTime value, string? format = null) => new LessOrEqualCondition(new SourceColumn(column, source), new DateTimeValue(value, format));
		public LessOrEqualCondition LessOrEqual(string column, ISource source, string value) => new LessOrEqualCondition(new SourceColumn(column, source), new StringValue(value));
		public LessOrEqualCondition LessOrEqual(string column, ISource source, IExpression expression) => new LessOrEqualCondition(new SourceColumn(column, source), expression);
		public LessOrEqualCondition LessOrEqual(string column, ISource source, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression2 = expressionFunction.Invoke(factory);

			return new LessOrEqualCondition(new SourceColumn(column, source), expression2);
		}

		public LessOrEqualCondition LessOrEqual(string column1, string table1, string column2, string table2) => new LessOrEqualCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, new Table(table2)));
		public LessOrEqualCondition LessOrEqual(string column1, string table1, string column2, ISource source2) => new LessOrEqualCondition(new SourceColumn(column1, new Table(table1)), new SourceColumn(column2, source2));
		public LessOrEqualCondition LessOrEqual(string column1, ISource source1, string column2, string table2) => new LessOrEqualCondition(new SourceColumn(column1, source1), new SourceColumn(column2, new Table(table2)));
		public LessOrEqualCondition LessOrEqual(string column1, ISource source1, string column2, ISource source2) => new LessOrEqualCondition(new SourceColumn(column1, source1), new SourceColumn(column2, source2));
		public LessOrEqualCondition LessOrEqual(Func<ExpressionFactory, IExpression> expressionFunction1, Func<ExpressionFactory, IExpression> expressionFunction2)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression1 = expressionFunction1.Invoke(factory);
			IExpression expression2 = expressionFunction2.Invoke(factory);

			return new LessOrEqualCondition(expression1, expression2);
		}

		#endregion LessOrEqualCondition factory methods

		#region IsNullCondition factory methods

		public IsNullCondition IsNull(IExpression expression) => new IsNullCondition(expression);
		public IsNullCondition IsNull(string column) => new IsNullCondition(new SourceColumn(column));
		public IsNullCondition IsNull(string column, string table) => new IsNullCondition(new SourceColumn(column, new Table(table)));
		public IsNullCondition IsNull(string column, ISource source) => new IsNullCondition(new SourceColumn(column, source));
		public IsNullCondition IsNull(Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression = expressionFunction.Invoke(factory);

			return new IsNullCondition(expression);
		}

		#endregion IsNullCondition factory methods

		#region IsNotNullCondition factory methods

		public IsNotNullCondition IsNotNull(IExpression expression) => new IsNotNullCondition(expression);
		public IsNotNullCondition IsNotNull(string column) => new IsNotNullCondition(new SourceColumn(column));
		public IsNotNullCondition IsNotNull(string column, string table) => new IsNotNullCondition(new SourceColumn(column, new Table(table)));
		public IsNotNullCondition IsNotNull(string column, ISource source) => new IsNotNullCondition(new SourceColumn(column, source));
		public IsNotNullCondition IsNotNull(Func<ExpressionFactory, IExpression> expressionFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression = expressionFunction.Invoke(factory);

			return new IsNotNullCondition(expression);
		}

		#endregion IsNotNullCondition factory methods

		#region InCondition factory methods

		public InCondition In(IExpression expression, params sbyte[] values) => new InCondition(expression, values.Select(v => new Int8Value(v)));
		public InCondition In(IExpression expression, params short[] values) => new InCondition(expression, values.Select(v => new Int16Value(v)));
		public InCondition In(IExpression expression, params int[] values) => new InCondition(expression, values.Select(v => new Int32Value(v)));
		public InCondition In(IExpression expression, params long[] values) => new InCondition(expression, values.Select(v => new Int64Value(v)));
		public InCondition In(IExpression expression, params float[] values) => new InCondition(expression, values.Select(v => new FloatValue(v)));
		public InCondition In(IExpression expression, params double[] values) => new InCondition(expression, values.Select(v => new DoubleValue(v)));
		public InCondition In(IExpression expression, params decimal[] values) => new InCondition(expression, values.Select(v => new DecimalValue(v)));
		public InCondition In(IExpression expression, params DateTime[] values) => new InCondition(expression, values.Select(v => new DateTimeValue(v)));
		public InCondition In(IExpression expression, string format, params DateTime[] values) => new InCondition(expression, values.Select(v => new DateTimeValue(v, format)));
		public InCondition In(IExpression expression, params string[] values) => new InCondition(expression, values.Select(v => new StringValue(v)));
		public InCondition In(IExpression expression, params IExpression[] values) => new InCondition(expression, values);
		public InCondition In(IExpression expression, IEnumerable<sbyte> values) => new InCondition(expression, values.Select(v => new Int8Value(v)));
		public InCondition In(IExpression expression, IEnumerable<short> values) => new InCondition(expression, values.Select(v => new Int16Value(v)));
		public InCondition In(IExpression expression, IEnumerable<int> values) => new InCondition(expression, values.Select(v => new Int32Value(v)));
		public InCondition In(IExpression expression, IEnumerable<long> values) => new InCondition(expression, values.Select(v => new Int64Value(v)));
		public InCondition In(IExpression expression, IEnumerable<float> values) => new InCondition(expression, values.Select(v => new FloatValue(v)));
		public InCondition In(IExpression expression, IEnumerable<double> values) => new InCondition(expression, values.Select(v => new DoubleValue(v)));
		public InCondition In(IExpression expression, IEnumerable<decimal> values) => new InCondition(expression, values.Select(v => new DecimalValue(v)));
		public InCondition In(IExpression expression, IEnumerable<DateTime> values, string? format = null) => new InCondition(expression, values.Select(v => new DateTimeValue(v, format)));
		public InCondition In(IExpression expression, IEnumerable<string> values) => new InCondition(expression, values.Select(v => new StringValue(v)));
		public InCondition In(IExpression expression, IEnumerable<IExpression> values) => new InCondition(expression, values);
		public InCondition In(IExpression expression, Action<ExpressionBuilder> buildExpressionMethod)
		{
			ExpressionBuilder builder = new ExpressionBuilder();
			buildExpressionMethod.Invoke(builder);

			return new InCondition(expression, builder.Build());
		}

		public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, Action<ExpressionBuilder> buildExpressionMethod)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression = expressionFunction.Invoke(factory);

			ExpressionBuilder builder = new ExpressionBuilder();
			buildExpressionMethod.Invoke(builder);

			return new InCondition(expression, builder.Build());
		}

		public InCondition In(string column, params sbyte[] values) => new InCondition(new SourceColumn(column), values.Select(v => new Int8Value(v)));
		public InCondition In(string column, params short[] values) => new InCondition(new SourceColumn(column), values.Select(v => new Int16Value(v)));
		public InCondition In(string column, params int[] values) => new InCondition(new SourceColumn(column), values.Select(v => new Int32Value(v)));
		public InCondition In(string column, params long[] values) => new InCondition(new SourceColumn(column), values.Select(v => new Int64Value(v)));
		public InCondition In(string column, params float[] values) => new InCondition(new SourceColumn(column), values.Select(v => new FloatValue(v)));
		public InCondition In(string column, params double[] values) => new InCondition(new SourceColumn(column), values.Select(v => new DoubleValue(v)));
		public InCondition In(string column, params decimal[] values) => new InCondition(new SourceColumn(column), values.Select(v => new DecimalValue(v)));
		public InCondition In(string column, params DateTime[] values) => new InCondition(new SourceColumn(column), values.Select(v => new DateTimeValue(v)));
		public InCondition In(string column, string format, params DateTime[] values) => new InCondition(new SourceColumn(column), values.Select(v => new DateTimeValue(v, format)));
		public InCondition In(string column, params string[] values) => new InCondition(new SourceColumn(column), values.Select(v => new StringValue(v)));
		public InCondition In(string column, params IExpression[] values) => new InCondition(new SourceColumn(column), values);
		public InCondition In(string column, IEnumerable<sbyte> values) => new InCondition(new SourceColumn(column), values.Select(v => new Int8Value(v)));
		public InCondition In(string column, IEnumerable<short> values) => new InCondition(new SourceColumn(column), values.Select(v => new Int16Value(v)));
		public InCondition In(string column, IEnumerable<int> values) => new InCondition(new SourceColumn(column), values.Select(v => new Int32Value(v)));
		public InCondition In(string column, IEnumerable<long> values) => new InCondition(new SourceColumn(column), values.Select(v => new Int64Value(v)));
		public InCondition In(string column, IEnumerable<float> values) => new InCondition(new SourceColumn(column), values.Select(v => new FloatValue(v)));
		public InCondition In(string column, IEnumerable<double> values) => new InCondition(new SourceColumn(column), values.Select(v => new DoubleValue(v)));
		public InCondition In(string column, IEnumerable<decimal> values) => new InCondition(new SourceColumn(column), values.Select(v => new DecimalValue(v)));
		public InCondition In(string column, IEnumerable<DateTime> values, string? format = null) => new InCondition(new SourceColumn(column), values.Select(v => new DateTimeValue(v, format)));
		public InCondition In(string column, IEnumerable<string> values) => new InCondition(new SourceColumn(column), values.Select(v => new StringValue(v)));
		public InCondition In(string column, IEnumerable<IExpression> values) => new InCondition(new SourceColumn(column), values);
		public InCondition In(string column, Action<ExpressionBuilder> buildExpressionMethod)
		{
			ExpressionBuilder builder = new ExpressionBuilder();
			buildExpressionMethod.Invoke(builder);

			return new InCondition(new SourceColumn(column), builder.Build());
		}

		public InCondition In(string column, string table, params sbyte[] values) => new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int8Value(v)));
		public InCondition In(string column, string table, params short[] values) => new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int16Value(v)));
		public InCondition In(string column, string table, params int[] values) => new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int32Value(v)));
		public InCondition In(string column, string table, params long[] values) => new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int64Value(v)));
		public InCondition In(string column, string table, params float[] values) => new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new FloatValue(v)));
		public InCondition In(string column, string table, params double[] values) => new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DoubleValue(v)));
		public InCondition In(string column, string table, params decimal[] values) => new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DecimalValue(v)));
		public InCondition In(string column, string table, string? format, params DateTime[] values) => new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DateTimeValue(v, format)));
		public InCondition In(string column, string table, params string[] values) => new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new StringValue(v)));
		public InCondition In(string column, string table, params IExpression[] values) => new InCondition(new SourceColumn(column, new Table(table)), values);
		public InCondition In(string column, string table, IEnumerable<sbyte> values) => new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int8Value(v)));
		public InCondition In(string column, string table, IEnumerable<short> values) => new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int16Value(v)));
		public InCondition In(string column, string table, IEnumerable<int> values) => new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int32Value(v)));
		public InCondition In(string column, string table, IEnumerable<long> values) => new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int64Value(v)));
		public InCondition In(string column, string table, IEnumerable<float> values) => new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new FloatValue(v)));
		public InCondition In(string column, string table, IEnumerable<double> values) => new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DoubleValue(v)));
		public InCondition In(string column, string table, IEnumerable<decimal> values) => new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DecimalValue(v)));
		public InCondition In(string column, string table, IEnumerable<DateTime> values, string? format = null) => new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DateTimeValue(v, format)));
		public InCondition In(string column, string table, IEnumerable<string> values) => new InCondition(new SourceColumn(column, new Table(table)), values.Select(v => new StringValue(v)));
		public InCondition In(string column, string table, IEnumerable<IExpression> values) => new InCondition(new SourceColumn(column, new Table(table)), values);
		public InCondition In(string column, string table, Action<ExpressionBuilder> buildExpressionMethod)
		{
			ExpressionBuilder builder = new ExpressionBuilder();
			buildExpressionMethod.Invoke(builder);

			return new InCondition(new SourceColumn(column, new Table(table)), builder.Build());
		}

		public InCondition In(string column, ISource source, params sbyte[] values) => new InCondition(new SourceColumn(column, source), values.Select(v => new Int8Value(v)));
		public InCondition In(string column, ISource source, params short[] values) => new InCondition(new SourceColumn(column, source), values.Select(v => new Int16Value(v)));
		public InCondition In(string column, ISource source, params int[] values) => new InCondition(new SourceColumn(column, source), values.Select(v => new Int32Value(v)));
		public InCondition In(string column, ISource source, params long[] values) => new InCondition(new SourceColumn(column, source), values.Select(v => new Int64Value(v)));
		public InCondition In(string column, ISource source, params float[] values) => new InCondition(new SourceColumn(column, source), values.Select(v => new FloatValue(v)));
		public InCondition In(string column, ISource source, params double[] values) => new InCondition(new SourceColumn(column, source), values.Select(v => new DoubleValue(v)));
		public InCondition In(string column, ISource source, params decimal[] values) => new InCondition(new SourceColumn(column, source), values.Select(v => new DecimalValue(v)));
		public InCondition In(string column, ISource source, params DateTime[] values) => new InCondition(new SourceColumn(column, source), values.Select(v => new DateTimeValue(v)));
		public InCondition In(string column, ISource source, string format, params DateTime[] values) => new InCondition(new SourceColumn(column, source), values.Select(v => new DateTimeValue(v, format)));
		public InCondition In(string column, ISource source, params string[] values) => new InCondition(new SourceColumn(column, source), values.Select(v => new StringValue(v)));
		public InCondition In(string column, ISource source, params IExpression[] values) => new InCondition(new SourceColumn(column, source), values);
		public InCondition In(string column, ISource source, IEnumerable<sbyte> values) => new InCondition(new SourceColumn(column, source), values.Select(v => new Int8Value(v)));
		public InCondition In(string column, ISource source, IEnumerable<short> values) => new InCondition(new SourceColumn(column, source), values.Select(v => new Int16Value(v)));
		public InCondition In(string column, ISource source, IEnumerable<int> values) => new InCondition(new SourceColumn(column, source), values.Select(v => new Int32Value(v)));
		public InCondition In(string column, ISource source, IEnumerable<long> values) => new InCondition(new SourceColumn(column, source), values.Select(v => new Int64Value(v)));
		public InCondition In(string column, ISource source, IEnumerable<float> values) => new InCondition(new SourceColumn(column, source), values.Select(v => new FloatValue(v)));
		public InCondition In(string column, ISource source, IEnumerable<double> values) => new InCondition(new SourceColumn(column, source), values.Select(v => new DoubleValue(v)));
		public InCondition In(string column, ISource source, IEnumerable<decimal> values) => new InCondition(new SourceColumn(column, source), values.Select(v => new DecimalValue(v)));
		public InCondition In(string column, ISource source, IEnumerable<DateTime> values, string? format = null) => new InCondition(new SourceColumn(column, source), values.Select(v => new DateTimeValue(v, format)));
		public InCondition In(string column, ISource source, IEnumerable<string> values) => new InCondition(new SourceColumn(column, source), values.Select(v => new StringValue(v)));
		public InCondition In(string column, ISource source, IEnumerable<IExpression> values) => new InCondition(new SourceColumn(column, source), values);
		public InCondition In(string column, ISource source, Action<ExpressionBuilder> buildExpressionMethod)
		{
			ExpressionBuilder builder = new ExpressionBuilder();
			buildExpressionMethod.Invoke(builder);

			return new InCondition(new SourceColumn(column, source), builder.Build());
		}

		#endregion InCondition factory methods

		#region NotInCondition factory methods

		public NotInCondition NotIn(IExpression expression, params sbyte[] values) => new NotInCondition(expression, values.Select(v => new Int8Value(v)));
		public NotInCondition NotIn(IExpression expression, params short[] values) => new NotInCondition(expression, values.Select(v => new Int16Value(v)));
		public NotInCondition NotIn(IExpression expression, params int[] values) => new NotInCondition(expression, values.Select(v => new Int32Value(v)));
		public NotInCondition NotIn(IExpression expression, params long[] values) => new NotInCondition(expression, values.Select(v => new Int64Value(v)));
		public NotInCondition NotIn(IExpression expression, params float[] values) => new NotInCondition(expression, values.Select(v => new FloatValue(v)));
		public NotInCondition NotIn(IExpression expression, params double[] values) => new NotInCondition(expression, values.Select(v => new DoubleValue(v)));
		public NotInCondition NotIn(IExpression expression, params decimal[] values) => new NotInCondition(expression, values.Select(v => new DecimalValue(v)));
		public NotInCondition NotIn(IExpression expression, params DateTime[] values) => new NotInCondition(expression, values.Select(v => new DateTimeValue(v)));
		public NotInCondition NotIn(IExpression expression, string format, params DateTime[] values) => new NotInCondition(expression, values.Select(v => new DateTimeValue(v, format)));
		public NotInCondition NotIn(IExpression expression, params string[] values) => new NotInCondition(expression, values.Select(v => new StringValue(v)));
		public NotInCondition NotIn(IExpression expression, params IExpression[] values) => new NotInCondition(expression, values);
		public NotInCondition NotIn(IExpression expression, IEnumerable<sbyte> values) => new NotInCondition(expression, values.Select(v => new Int8Value(v)));
		public NotInCondition NotIn(IExpression expression, IEnumerable<short> values) => new NotInCondition(expression, values.Select(v => new Int16Value(v)));
		public NotInCondition NotIn(IExpression expression, IEnumerable<int> values) => new NotInCondition(expression, values.Select(v => new Int32Value(v)));
		public NotInCondition NotIn(IExpression expression, IEnumerable<long> values) => new NotInCondition(expression, values.Select(v => new Int64Value(v)));
		public NotInCondition NotIn(IExpression expression, IEnumerable<float> values) => new NotInCondition(expression, values.Select(v => new FloatValue(v)));
		public NotInCondition NotIn(IExpression expression, IEnumerable<double> values) => new NotInCondition(expression, values.Select(v => new DoubleValue(v)));
		public NotInCondition NotIn(IExpression expression, IEnumerable<decimal> values) => new NotInCondition(expression, values.Select(v => new DecimalValue(v)));
		public NotInCondition NotIn(IExpression expression, IEnumerable<DateTime> values, string? format = null) => new NotInCondition(expression, values.Select(v => new DateTimeValue(v, format)));
		public NotInCondition NotIn(IExpression expression, IEnumerable<string> values) => new NotInCondition(expression, values.Select(v => new StringValue(v)));
		public NotInCondition NotIn(IExpression expression, IEnumerable<IExpression> values) => new NotInCondition(expression, values);
		public NotInCondition NotIn(IExpression expression, Action<ExpressionBuilder> buildExpressionMethod)
		{
			ExpressionBuilder builder = new ExpressionBuilder();
			buildExpressionMethod.Invoke(builder);

			return new NotInCondition(expression, builder.Build());
		}

		public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, Action<ExpressionBuilder> buildExpressionMethod)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression = expressionFunction.Invoke(factory);

			ExpressionBuilder builder = new ExpressionBuilder();
			buildExpressionMethod.Invoke(builder);

			return new NotInCondition(expression, builder.Build());
		}

		public NotInCondition NotIn(string column, params sbyte[] values) => new NotInCondition(new SourceColumn(column), values.Select(v => new Int8Value(v)));
		public NotInCondition NotIn(string column, params short[] values) => new NotInCondition(new SourceColumn(column), values.Select(v => new Int16Value(v)));
		public NotInCondition NotIn(string column, params int[] values) => new NotInCondition(new SourceColumn(column), values.Select(v => new Int32Value(v)));
		public NotInCondition NotIn(string column, params long[] values) => new NotInCondition(new SourceColumn(column), values.Select(v => new Int64Value(v)));
		public NotInCondition NotIn(string column, params float[] values) => new NotInCondition(new SourceColumn(column), values.Select(v => new FloatValue(v)));
		public NotInCondition NotIn(string column, params double[] values) => new NotInCondition(new SourceColumn(column), values.Select(v => new DoubleValue(v)));
		public NotInCondition NotIn(string column, params decimal[] values) => new NotInCondition(new SourceColumn(column), values.Select(v => new DecimalValue(v)));
		public NotInCondition NotIn(string column, params DateTime[] values) => new NotInCondition(new SourceColumn(column), values.Select(v => new DateTimeValue(v)));
		public NotInCondition NotIn(string column, string format, params DateTime[] values) => new NotInCondition(new SourceColumn(column), values.Select(v => new DateTimeValue(v, format)));
		public NotInCondition NotIn(string column, params string[] values) => new NotInCondition(new SourceColumn(column), values.Select(v => new StringValue(v)));
		public NotInCondition NotIn(string column, params IExpression[] values) => new NotInCondition(new SourceColumn(column), values);
		public NotInCondition NotIn(string column, IEnumerable<sbyte> values) => new NotInCondition(new SourceColumn(column), values.Select(v => new Int8Value(v)));
		public NotInCondition NotIn(string column, IEnumerable<short> values) => new NotInCondition(new SourceColumn(column), values.Select(v => new Int16Value(v)));
		public NotInCondition NotIn(string column, IEnumerable<int> values) => new NotInCondition(new SourceColumn(column), values.Select(v => new Int32Value(v)));
		public NotInCondition NotIn(string column, IEnumerable<long> values) => new NotInCondition(new SourceColumn(column), values.Select(v => new Int64Value(v)));
		public NotInCondition NotIn(string column, IEnumerable<float> values) => new NotInCondition(new SourceColumn(column), values.Select(v => new FloatValue(v)));
		public NotInCondition NotIn(string column, IEnumerable<double> values) => new NotInCondition(new SourceColumn(column), values.Select(v => new DoubleValue(v)));
		public NotInCondition NotIn(string column, IEnumerable<decimal> values) => new NotInCondition(new SourceColumn(column), values.Select(v => new DecimalValue(v)));
		public NotInCondition NotIn(string column, IEnumerable<DateTime> values, string? format = null) => new NotInCondition(new SourceColumn(column), values.Select(v => new DateTimeValue(v, format)));
		public NotInCondition NotIn(string column, IEnumerable<string> values) => new NotInCondition(new SourceColumn(column), values.Select(v => new StringValue(v)));
		public NotInCondition NotIn(string column, IEnumerable<IExpression> values) => new NotInCondition(new SourceColumn(column), values);
		public NotInCondition NotIn(string column, Action<ExpressionBuilder> buildExpressionMethod)
		{
			ExpressionBuilder builder = new ExpressionBuilder();
			buildExpressionMethod.Invoke(builder);

			return new NotInCondition(new SourceColumn(column), builder.Build());
		}

		public NotInCondition NotIn(string column, string table, params sbyte[] values) => new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int8Value(v)));
		public NotInCondition NotIn(string column, string table, params short[] values) => new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int16Value(v)));
		public NotInCondition NotIn(string column, string table, params int[] values) => new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int32Value(v)));
		public NotInCondition NotIn(string column, string table, params long[] values) => new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int64Value(v)));
		public NotInCondition NotIn(string column, string table, params float[] values) => new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new FloatValue(v)));
		public NotInCondition NotIn(string column, string table, params double[] values) => new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DoubleValue(v)));
		public NotInCondition NotIn(string column, string table, params decimal[] values) => new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DecimalValue(v)));
		public NotInCondition NotIn(string column, string table, string? format, params DateTime[] values) => new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DateTimeValue(v, format)));
		public NotInCondition NotIn(string column, string table, params string[] values) => new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new StringValue(v)));
		public NotInCondition NotIn(string column, string table, params IExpression[] values) => new NotInCondition(new SourceColumn(column, new Table(table)), values);
		public NotInCondition NotIn(string column, string table, IEnumerable<sbyte> values) => new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int8Value(v)));
		public NotInCondition NotIn(string column, string table, IEnumerable<short> values) => new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int16Value(v)));
		public NotInCondition NotIn(string column, string table, IEnumerable<int> values) => new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int32Value(v)));
		public NotInCondition NotIn(string column, string table, IEnumerable<long> values) => new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new Int64Value(v)));
		public NotInCondition NotIn(string column, string table, IEnumerable<float> values) => new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new FloatValue(v)));
		public NotInCondition NotIn(string column, string table, IEnumerable<double> values) => new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DoubleValue(v)));
		public NotInCondition NotIn(string column, string table, IEnumerable<decimal> values) => new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DecimalValue(v)));
		public NotInCondition NotIn(string column, string table, IEnumerable<DateTime> values, string? format = null) => new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new DateTimeValue(v, format)));
		public NotInCondition NotIn(string column, string table, IEnumerable<string> values) => new NotInCondition(new SourceColumn(column, new Table(table)), values.Select(v => new StringValue(v)));
		public NotInCondition NotIn(string column, string table, IEnumerable<IExpression> values) => new NotInCondition(new SourceColumn(column, new Table(table)), values);
		public NotInCondition NotIn(string column, string table, Action<ExpressionBuilder> buildExpressionMethod)
		{
			ExpressionBuilder builder = new ExpressionBuilder();
			buildExpressionMethod.Invoke(builder);

			return new NotInCondition(new SourceColumn(column, new Table(table)), builder.Build());
		}

		public NotInCondition NotIn(string column, ISource source, params sbyte[] values) => new NotInCondition(new SourceColumn(column, source), values.Select(v => new Int8Value(v)));
		public NotInCondition NotIn(string column, ISource source, params short[] values) => new NotInCondition(new SourceColumn(column, source), values.Select(v => new Int16Value(v)));
		public NotInCondition NotIn(string column, ISource source, params int[] values) => new NotInCondition(new SourceColumn(column, source), values.Select(v => new Int32Value(v)));
		public NotInCondition NotIn(string column, ISource source, params long[] values) => new NotInCondition(new SourceColumn(column, source), values.Select(v => new Int64Value(v)));
		public NotInCondition NotIn(string column, ISource source, params float[] values) => new NotInCondition(new SourceColumn(column, source), values.Select(v => new FloatValue(v)));
		public NotInCondition NotIn(string column, ISource source, params double[] values) => new NotInCondition(new SourceColumn(column, source), values.Select(v => new DoubleValue(v)));
		public NotInCondition NotIn(string column, ISource source, params decimal[] values) => new NotInCondition(new SourceColumn(column, source), values.Select(v => new DecimalValue(v)));
		public NotInCondition NotIn(string column, ISource source, params DateTime[] values) => new NotInCondition(new SourceColumn(column, source), values.Select(v => new DateTimeValue(v)));
		public NotInCondition NotIn(string column, ISource source, string? format, params DateTime[] values) => new NotInCondition(new SourceColumn(column, source), values.Select(v => new DateTimeValue(v, format)));
		public NotInCondition NotIn(string column, ISource source, params string[] values) => new NotInCondition(new SourceColumn(column, source), values.Select(v => new StringValue(v)));
		public NotInCondition NotIn(string column, ISource source, params IExpression[] values) => new NotInCondition(new SourceColumn(column, source), values);
		public NotInCondition NotIn(string column, ISource source, IEnumerable<sbyte> values) => new NotInCondition(new SourceColumn(column, source), values.Select(v => new Int8Value(v)));
		public NotInCondition NotIn(string column, ISource source, IEnumerable<short> values) => new NotInCondition(new SourceColumn(column, source), values.Select(v => new Int16Value(v)));
		public NotInCondition NotIn(string column, ISource source, IEnumerable<int> values) => new NotInCondition(new SourceColumn(column, source), values.Select(v => new Int32Value(v)));
		public NotInCondition NotIn(string column, ISource source, IEnumerable<long> values) => new NotInCondition(new SourceColumn(column, source), values.Select(v => new Int64Value(v)));
		public NotInCondition NotIn(string column, ISource source, IEnumerable<float> values) => new NotInCondition(new SourceColumn(column, source), values.Select(v => new FloatValue(v)));
		public NotInCondition NotIn(string column, ISource source, IEnumerable<double> values) => new NotInCondition(new SourceColumn(column, source), values.Select(v => new DoubleValue(v)));
		public NotInCondition NotIn(string column, ISource source, IEnumerable<decimal> values) => new NotInCondition(new SourceColumn(column, source), values.Select(v => new DecimalValue(v)));
		public NotInCondition NotIn(string column, ISource source, IEnumerable<DateTime> values, string? format = null) => new NotInCondition(new SourceColumn(column, source), values.Select(v => new DateTimeValue(v, format)));
		public NotInCondition NotIn(string column, ISource source, IEnumerable<string> values) => new NotInCondition(new SourceColumn(column, source), values.Select(v => new StringValue(v)));
		public NotInCondition NotIn(string column, ISource source, IEnumerable<IExpression> values) => new NotInCondition(new SourceColumn(column, source), values);
		public NotInCondition NotIn(string column, ISource source, Action<ExpressionBuilder> buildExpressionMethod)
		{
			ExpressionBuilder builder = new ExpressionBuilder();
			buildExpressionMethod.Invoke(builder);

			return new NotInCondition(new SourceColumn(column, source), builder.Build());
		}

		#endregion NotInCondition factory methods

		#region LikeCondition factory methods

		public LikeCondition Like(IExpression expression, string pattern) => new LikeCondition(expression, pattern);
		public LikeCondition Like(string column, string pattern) => new LikeCondition(new SourceColumn(column), pattern);
		public LikeCondition Like(string column, string table, string pattern) => new LikeCondition(new SourceColumn(column, new Table(table)), pattern);
		public LikeCondition Like(string column, ISource source, string pattern) => new LikeCondition(new SourceColumn(column, source), pattern);
		public LikeCondition Like(Func<ExpressionFactory, IExpression> expressionFunction, string pattern)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression = expressionFunction.Invoke(factory);

			return new LikeCondition(expression, pattern);
		}

		#endregion LikeCondition factory methods

		#region NotLikeCondition factory methods

		public NotLikeCondition NotLike(IExpression expression, string pattern) => new NotLikeCondition(expression, pattern);
		public NotLikeCondition NotLike(string column, string pattern) => new NotLikeCondition(new SourceColumn(column), pattern);
		public NotLikeCondition NotLike(string column, string table, string pattern) => new NotLikeCondition(new SourceColumn(column, new Table(table)), pattern);
		public NotLikeCondition NotLike(string column, ISource source, string pattern) => new NotLikeCondition(new SourceColumn(column, source), pattern);
		public NotLikeCondition NotLike(Func<ExpressionFactory, IExpression> expressionFunction, string pattern)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression = expressionFunction.Invoke(factory);

			return new NotLikeCondition(expression, pattern);
		}

		#endregion NotLikeCondition factory methods

		#region BetweenCondition factory methods

		public BetweenCondition Between(IExpression expression, sbyte lowBound, sbyte hightBound) => new BetweenCondition(expression, new Int8Value(lowBound), new Int8Value(hightBound));
		public BetweenCondition Between(IExpression expression, short lowBound, short hightBound) => new BetweenCondition(expression, new Int16Value(lowBound), new Int16Value(hightBound));
		public BetweenCondition Between(IExpression expression, int lowBound, int hightBound) => new BetweenCondition(expression, new Int32Value(lowBound), new Int32Value(hightBound));
		public BetweenCondition Between(IExpression expression, long lowBound, long hightBound) => new BetweenCondition(expression, new Int64Value(lowBound), new Int64Value(hightBound));
		public BetweenCondition Between(IExpression expression, float lowBound, float hightBound) => new BetweenCondition(expression, new FloatValue(lowBound), new FloatValue(hightBound));
		public BetweenCondition Between(IExpression expression, double lowBound, double hightBound) => new BetweenCondition(expression, new DoubleValue(lowBound), new DoubleValue(hightBound));
		public BetweenCondition Between(IExpression expression, decimal lowBound, decimal hightBound) => new BetweenCondition(expression, new DecimalValue(lowBound), new DecimalValue(hightBound));
		public BetweenCondition Between(IExpression expression, DateTime lowBound, DateTime hightBound, string? format = null) => new BetweenCondition(expression, new DateTimeValue(lowBound, format), new DateTimeValue(hightBound, format));
		public BetweenCondition Between(IExpression expression, string lowBound, string hightBound) => new BetweenCondition(expression, new StringValue(lowBound), new StringValue(hightBound));
		public BetweenCondition Between(IExpression expression1, IExpression lowBound, IExpression hightBound) => new BetweenCondition(expression1, lowBound, hightBound);
		public BetweenCondition Between(IExpression expression, Func<ExpressionFactory, IExpression> lowBoundFunction, Func<ExpressionFactory, IExpression> hightBoundFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression lowBound = lowBoundFunction.Invoke(factory);
			IExpression hightBound = hightBoundFunction.Invoke(factory);

			return new BetweenCondition(expression, lowBound, hightBound);
		}

		public BetweenCondition Between(Func<ExpressionFactory, IExpression> expressionFunction, Func<ExpressionFactory, IExpression> lowBoundFunction, Func<ExpressionFactory, IExpression> hightBoundFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression expression = expressionFunction.Invoke(factory);
			IExpression lowBound = lowBoundFunction.Invoke(factory);
			IExpression hightBound = hightBoundFunction.Invoke(factory);

			return new BetweenCondition(expression, lowBound, hightBound);
		}

		public BetweenCondition Between(string column, sbyte lowBound, sbyte hightBound) => new BetweenCondition(new SourceColumn(column), new Int8Value(lowBound), new Int8Value(hightBound));
		public BetweenCondition Between(string column, short lowBound, short hightBound) => new BetweenCondition(new SourceColumn(column), new Int16Value(lowBound), new Int16Value(hightBound));
		public BetweenCondition Between(string column, int lowBound, int hightBound) => new BetweenCondition(new SourceColumn(column), new Int32Value(lowBound), new Int32Value(hightBound));
		public BetweenCondition Between(string column, long lowBound, long hightBound) => new BetweenCondition(new SourceColumn(column), new Int64Value(lowBound), new Int64Value(hightBound));
		public BetweenCondition Between(string column, float lowBound, float hightBound) => new BetweenCondition(new SourceColumn(column), new FloatValue(lowBound), new FloatValue(hightBound));
		public BetweenCondition Between(string column, double lowBound, double hightBound) => new BetweenCondition(new SourceColumn(column), new DoubleValue(lowBound), new DoubleValue(hightBound));
		public BetweenCondition Between(string column, decimal lowBound, decimal hightBound) => new BetweenCondition(new SourceColumn(column), new DecimalValue(lowBound), new DecimalValue(hightBound));
		public BetweenCondition Between(string column, DateTime lowBound, DateTime hightBound, string? format = null) => new BetweenCondition(new SourceColumn(column), new DateTimeValue(lowBound, format), new DateTimeValue(hightBound, format));
		public BetweenCondition Between(string column, string lowBound, string hightBound) => new BetweenCondition(new SourceColumn(column), new StringValue(lowBound), new StringValue(hightBound));
		public BetweenCondition Between(string column, IExpression lowBound, IExpression hightBound) => new BetweenCondition(new SourceColumn(column), lowBound, hightBound);
		public BetweenCondition Between(string column, Func<ExpressionFactory, IExpression> lowBoundFunction, Func<ExpressionFactory, IExpression> hightBoundFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression lowBound = lowBoundFunction.Invoke(factory);
			IExpression hightBound = hightBoundFunction.Invoke(factory);

			return new BetweenCondition(new SourceColumn(column), lowBound, hightBound);
		}

		public BetweenCondition Between(string column, string table, sbyte lowBound, sbyte hightBound) => new BetweenCondition(new SourceColumn(column, new Table(table)), new Int8Value(lowBound), new Int8Value(hightBound));
		public BetweenCondition Between(string column, string table, short lowBound, short hightBound) => new BetweenCondition(new SourceColumn(column, new Table(table)), new Int16Value(lowBound), new Int16Value(hightBound));
		public BetweenCondition Between(string column, string table, int lowBound, int hightBound) => new BetweenCondition(new SourceColumn(column, new Table(table)), new Int32Value(lowBound), new Int32Value(hightBound));
		public BetweenCondition Between(string column, string table, long lowBound, long hightBound) => new BetweenCondition(new SourceColumn(column, new Table(table)), new Int64Value(lowBound), new Int64Value(hightBound));
		public BetweenCondition Between(string column, string table, float lowBound, float hightBound) => new BetweenCondition(new SourceColumn(column, new Table(table)), new FloatValue(lowBound), new FloatValue(hightBound));
		public BetweenCondition Between(string column, string table, double lowBound, double hightBound) => new BetweenCondition(new SourceColumn(column, new Table(table)), new DoubleValue(lowBound), new DoubleValue(hightBound));
		public BetweenCondition Between(string column, string table, decimal lowBound, decimal hightBound) => new BetweenCondition(new SourceColumn(column, new Table(table)), new DecimalValue(lowBound), new DecimalValue(hightBound));
		public BetweenCondition Between(string column, string table, DateTime lowBound, DateTime hightBound, string? format = null) => new BetweenCondition(new SourceColumn(column, new Table(table)), new DateTimeValue(lowBound, format), new DateTimeValue(hightBound, format));
		public BetweenCondition Between(string column, string table, string lowBound, string hightBound) => new BetweenCondition(new SourceColumn(column, new Table(table)), new StringValue(lowBound), new StringValue(hightBound));
		public BetweenCondition Between(string column, string table, IExpression lowBound, IExpression hightBound) => new BetweenCondition(new SourceColumn(column, new Table(table)), lowBound, hightBound);
		public BetweenCondition Between(string column, string table, Func<ExpressionFactory, IExpression> lowBoundFunction, Func<ExpressionFactory, IExpression> hightBoundFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression lowBound = lowBoundFunction.Invoke(factory);
			IExpression hightBound = hightBoundFunction.Invoke(factory);

			return new BetweenCondition(new SourceColumn(column, new Table(table)), lowBound, hightBound);
		}

		public BetweenCondition Between(string column, ISource source, sbyte lowBound, sbyte hightBound) => new BetweenCondition(new SourceColumn(column, source), new Int8Value(lowBound), new Int8Value(hightBound));
		public BetweenCondition Between(string column, ISource source, short lowBound, short hightBound) => new BetweenCondition(new SourceColumn(column, source), new Int16Value(lowBound), new Int16Value(hightBound));
		public BetweenCondition Between(string column, ISource source, int lowBound, int hightBound) => new BetweenCondition(new SourceColumn(column, source), new Int32Value(lowBound), new Int32Value(hightBound));
		public BetweenCondition Between(string column, ISource source, long lowBound, long hightBound) => new BetweenCondition(new SourceColumn(column, source), new Int64Value(lowBound), new Int64Value(hightBound));
		public BetweenCondition Between(string column, ISource source, float lowBound, float hightBound) => new BetweenCondition(new SourceColumn(column, source), new FloatValue(lowBound), new FloatValue(hightBound));
		public BetweenCondition Between(string column, ISource source, double lowBound, double hightBound) => new BetweenCondition(new SourceColumn(column, source), new DoubleValue(lowBound), new DoubleValue(hightBound));
		public BetweenCondition Between(string column, ISource source, decimal lowBound, decimal hightBound) => new BetweenCondition(new SourceColumn(column, source), new DecimalValue(lowBound), new DecimalValue(hightBound));
		public BetweenCondition Between(string column, ISource source, DateTime lowBound, DateTime hightBound, string? format = null) => new BetweenCondition(new SourceColumn(column, source), new DateTimeValue(lowBound, format), new DateTimeValue(hightBound, format));
		public BetweenCondition Between(string column, ISource source, string lowBound, string hightBound) => new BetweenCondition(new SourceColumn(column, source), new StringValue(lowBound), new StringValue(hightBound));
		public BetweenCondition Between(string column, ISource source, IExpression lowBound, IExpression hightBound) => new BetweenCondition(new SourceColumn(column, source), lowBound, hightBound);
		public BetweenCondition Between(string column, ISource source, Func<ExpressionFactory, IExpression> lowBoundFunction, Func<ExpressionFactory, IExpression> hightBoundFunction)
		{
			ExpressionFactory factory = new ExpressionFactory();
			IExpression lowBound = lowBoundFunction.Invoke(factory);
			IExpression hightBound = hightBoundFunction.Invoke(factory);

			return new BetweenCondition(new SourceColumn(column, source), lowBound, hightBound);
		}

		#endregion BetweenCondition factory methods

		#region ICondition factory methods

		public ICondition Condition(Action<ConditionBuilder> action)
		{
			Validator.ThrowIfArgumentIsNull(action, nameof(action));

			ConditionBuilder builder = new ConditionBuilder();
			action.Invoke(builder);

			ICondition condition = builder.Build();

			return condition;
		}

		public ICondition Condition(ISource leftSource, ISource rightSource, Action<ConditionBuilder, ISource, ISource> action)
		{
			Validator.ThrowIfArgumentIsNull(action, nameof(action));

			ConditionBuilder builder = new ConditionBuilder();
			action.Invoke(builder, leftSource, rightSource);

			ICondition condition = builder.Build();

			return condition;
		}

		#endregion ICondition factory methods

		#endregion Conditions factory methods

		#region Expressions factory methods

		#region PlusEpression factory methods

		public PlusExpression Plus(params IExpression[] expressions) => new PlusExpression(expressions);
		public PlusExpression Plus(Action<ExpressionBuilder> action) => new PlusExpression(Expressions(action));
		public PlusExpression Plus(IEnumerable<IExpression> expressions) => new PlusExpression(expressions);

		#endregion PlusExpression factory methods

		#region MinusExpression factory methods

		public MinusExpression Minus(params IExpression[] expressions) => new MinusExpression(expressions);
		public MinusExpression Minus(Action<ExpressionBuilder> action) => new MinusExpression(Expressions(action));
		public MinusExpression Minus(IEnumerable<IExpression> expressions) => new MinusExpression(expressions);

		#endregion MinusExpression factory methods

		#region MultiplyExpression factory methods

		public MultiplyExpression Multiply(params IExpression[] expressions) => new MultiplyExpression(expressions);
		public MultiplyExpression Multiply(Action<ExpressionBuilder> action) => new MultiplyExpression(Expressions(action));
		public MultiplyExpression Multiply(IEnumerable<IExpression> expressions) => new MultiplyExpression(expressions);

		#endregion MultiplyExpression factory methods

		#region DivideExpression factory methods

		public DivideExpression Divide(params IExpression[] expressions) => new DivideExpression(expressions);
		public DivideExpression Divide(Action<ExpressionBuilder> action) => new DivideExpression(Expressions(action));
		public DivideExpression Divide(IEnumerable<IExpression> expressions) => new DivideExpression(expressions);

		#endregion DivideExpression factory methods

		#region Expression factory methods

		public IExpression Expression(Func<ExpressionFactory, IExpression> function) => function.Invoke(this);
		public List<IExpression> Expressions(Action<ExpressionBuilder> action)
		{
			ExpressionBuilder builder = new ExpressionBuilder();
			action.Invoke(builder);

			return builder.Build();
		}

		#endregion Expression factory methods

		#region GeneralCaseExpression factory methods

		public GeneralCaseExpression Case(Action<GeneralCaseBuilder> caseBuildMethod)
		{
			GeneralCaseBuilder caseBuilder = new GeneralCaseBuilder();
			caseBuildMethod.Invoke(caseBuilder);

			return caseBuilder.Build();
		}

		#endregion GeneralCaseExpression factory methods

		#region SimpleCaseExpression factory methods

		public SimpleCaseExpression Case(string column, Action<SimpleCaseBuilder> caseBuildMethod) => Case(new SourceColumn(column), caseBuildMethod);
		public SimpleCaseExpression Case(string column, string table, Action<SimpleCaseBuilder> caseBuildMethod) => Case(new SourceColumn(column, new Table(table)), caseBuildMethod);
		public SimpleCaseExpression Case(string column, ISource source, Action<SimpleCaseBuilder> caseBuildMethod) => Case(new SourceColumn(column, source), caseBuildMethod);
		public SimpleCaseExpression Case(IExpression expression, Action<SimpleCaseBuilder> caseBuildMethod)
		{
			SimpleCaseBuilder caseBuilder = new SimpleCaseBuilder(expression);
			caseBuildMethod.Invoke(caseBuilder);

			return caseBuilder.Build();
		}
		
		public SimpleCaseExpression Case(Func<ExpressionBuilder, IExpression> expressionFunction, Action<SimpleCaseBuilder> caseBuildMethod)
		{
			ExpressionBuilder builder = new ExpressionBuilder();
			IExpression expression = expressionFunction.Invoke(builder);

			return Case(expression, caseBuildMethod);
		}

		#endregion SimpleCaseExpression factory methods

		#endregion Expressions factory methods

		#region Functions factory methods

		#region CoalesceFunction factory methods

		public CoalesceFunction Coalesce(string column, sbyte value) => new CoalesceFunction(new SourceColumn(column), new Int8Value(value));
		public CoalesceFunction Coalesce(string column, short value) => new CoalesceFunction(new SourceColumn(column), new Int16Value(value));
		public CoalesceFunction Coalesce(string column, int value) => new CoalesceFunction(new SourceColumn(column), new Int32Value(value));
		public CoalesceFunction Coalesce(string column, long value) => new CoalesceFunction(new SourceColumn(column), new Int64Value(value));
		public CoalesceFunction Coalesce(string column, float value) => new CoalesceFunction(new SourceColumn(column), new FloatValue(value));
		public CoalesceFunction Coalesce(string column, double value) => new CoalesceFunction(new SourceColumn(column), new DoubleValue(value));
		public CoalesceFunction Coalesce(string column, DateTime value, string? format = null) => new CoalesceFunction(new SourceColumn(column), new DateTimeValue(value, format));
		public CoalesceFunction Coalesce(string column, string value) => new CoalesceFunction(new SourceColumn(column), new StringValue(value));
		public CoalesceFunction Coalesce(string column, Func<ExpressionFactory, IExpression> function) => new CoalesceFunction(new SourceColumn(column), Expression(function));
		public CoalesceFunction Coalesce(string column, IExpression defaultValue) => new CoalesceFunction(new SourceColumn(column), defaultValue);

		public CoalesceFunction Coalesce(string column, string table, sbyte value) => new CoalesceFunction(new SourceColumn(column, new Table(table)), new Int8Value(value));
		public CoalesceFunction Coalesce(string column, string table, short value) => new CoalesceFunction(new SourceColumn(column, new Table(table)), new Int16Value(value));
		public CoalesceFunction Coalesce(string column, string table, int value) => new CoalesceFunction(new SourceColumn(column, new Table(table)), new Int32Value(value));
		public CoalesceFunction Coalesce(string column, string table, long value) => new CoalesceFunction(new SourceColumn(column, new Table(table)), new Int64Value(value));
		public CoalesceFunction Coalesce(string column, string table, float value) => new CoalesceFunction(new SourceColumn(column, new Table(table)), new FloatValue(value));
		public CoalesceFunction Coalesce(string column, string table, double value) => new CoalesceFunction(new SourceColumn(column, new Table(table)), new DoubleValue(value));
		public CoalesceFunction Coalesce(string column, string table, DateTime value, string? format = null) => new CoalesceFunction(new SourceColumn(column, new Table(table)), new DateTimeValue(value, format));
		public CoalesceFunction Coalesce(string column, string table, string value) => new CoalesceFunction(new SourceColumn(column, new Table(table)), new StringValue(value));
		public CoalesceFunction Coalesce(string column, string table, Func<ExpressionFactory, IExpression> function) => new CoalesceFunction(new SourceColumn(column, new Table(table)), Expression(function));
		public CoalesceFunction Coalesce(string column, string table, IExpression defaultValue) => new CoalesceFunction(new SourceColumn(column, new Table(table)), defaultValue);

		public CoalesceFunction Coalesce(string column, ISource source, sbyte value) => new CoalesceFunction(new SourceColumn(column, source), new Int8Value(value));
		public CoalesceFunction Coalesce(string column, ISource source, short value) => new CoalesceFunction(new SourceColumn(column, source), new Int16Value(value));
		public CoalesceFunction Coalesce(string column, ISource source, int value) => new CoalesceFunction(new SourceColumn(column, source), new Int32Value(value));
		public CoalesceFunction Coalesce(string column, ISource source, long value) => new CoalesceFunction(new SourceColumn(column, source), new Int64Value(value));
		public CoalesceFunction Coalesce(string column, ISource source, float value) => new CoalesceFunction(new SourceColumn(column, source), new FloatValue(value));
		public CoalesceFunction Coalesce(string column, ISource source, double value) => new CoalesceFunction(new SourceColumn(column, source), new DoubleValue(value));
		public CoalesceFunction Coalesce(string column, ISource source, DateTime value, string? format = null) => new CoalesceFunction(new SourceColumn(column, source), new DateTimeValue(value, format));
		public CoalesceFunction Coalesce(string column, ISource source, string value) => new CoalesceFunction(new SourceColumn(column, source), new StringValue(value));
		public CoalesceFunction Coalesce(string column, ISource source, Func<ExpressionFactory, IExpression> function) => new CoalesceFunction(new SourceColumn(column, source), Expression(function));
		public CoalesceFunction Coalesce(string column, ISource source, IExpression defaultValue) => new CoalesceFunction(new SourceColumn(column, source), defaultValue);

		public CoalesceFunction Coalesce(Func<ExpressionFactory, IColumn> columnFunction, sbyte value) => new CoalesceFunction(Column(columnFunction), new Int8Value(value));
		public CoalesceFunction Coalesce(Func<ExpressionFactory, IColumn> columnFunction, short value) => new CoalesceFunction(Column(columnFunction), new Int16Value(value));
		public CoalesceFunction Coalesce(Func<ExpressionFactory, IColumn> columnFunction, int value) => new CoalesceFunction(Column(columnFunction), new Int32Value(value));
		public CoalesceFunction Coalesce(Func<ExpressionFactory, IColumn> columnFunction, long value) => new CoalesceFunction(Column(columnFunction), new Int64Value(value));
		public CoalesceFunction Coalesce(Func<ExpressionFactory, IColumn> columnFunction, float value) => new CoalesceFunction(Column(columnFunction), new FloatValue(value));
		public CoalesceFunction Coalesce(Func<ExpressionFactory, IColumn> columnFunction, double value) => new CoalesceFunction(Column(columnFunction), new DoubleValue(value));
		public CoalesceFunction Coalesce(Func<ExpressionFactory, IColumn> columnFunction, DateTime value, string? format = null) => new CoalesceFunction(Column(columnFunction), new DateTimeValue(value, format));
		public CoalesceFunction Coalesce(Func<ExpressionFactory, IColumn> columnFunction, string value) => new CoalesceFunction(Column(columnFunction), new StringValue(value));
		public CoalesceFunction Coalesce(Func<ExpressionFactory, IColumn> columnFunction, Func<ExpressionFactory, IExpression> function) => new CoalesceFunction(Column(columnFunction), Expression(function));
		public CoalesceFunction Coalesce(Func<ExpressionFactory, IColumn> columnFunction, IExpression defaultValue) => new CoalesceFunction(Column(columnFunction), defaultValue);

		public CoalesceFunction Coalesce(IColumn column, sbyte value) => new CoalesceFunction(column, new Int8Value(value));
		public CoalesceFunction Coalesce(IColumn column, short value) => new CoalesceFunction(column, new Int16Value(value));
		public CoalesceFunction Coalesce(IColumn column, int value) => new CoalesceFunction(column, new Int32Value(value));
		public CoalesceFunction Coalesce(IColumn column, long value) => new CoalesceFunction(column, new Int64Value(value));
		public CoalesceFunction Coalesce(IColumn column, float value) => new CoalesceFunction(column, new FloatValue(value));
		public CoalesceFunction Coalesce(IColumn column, double value) => new CoalesceFunction(column, new DoubleValue(value));
		public CoalesceFunction Coalesce(IColumn column, DateTime value, string? format = null) => new CoalesceFunction(column, new DateTimeValue(value, format));
		public CoalesceFunction Coalesce(IColumn column, string value) => new CoalesceFunction(column, new StringValue(value));
		public CoalesceFunction Coalesce(IColumn column, Func<ExpressionFactory, IExpression> function) => new CoalesceFunction(column, Expression(function));
		public CoalesceFunction Coalesce(IColumn column, IExpression defaultValue) => new CoalesceFunction(column, defaultValue);

		#endregion CoalesceFunction factory methods

		#region ConcatFunction factory methods

		public ConcatFunction Concat(params IExpression[] expressions) => new ConcatFunction(expressions);
		public ConcatFunction Concat(Action<ExpressionBuilder> action) => new ConcatFunction(Expressions(action));
		public ConcatFunction Concat(IEnumerable<IExpression> expressions) => new ConcatFunction(expressions);

		#endregion ConcatFunction factory methods

		#region CountFunction factory methods

		public CountFunction Count(string column) => new CountFunction(new SourceColumn(column));
		public CountFunction Count(string column, string table) => new CountFunction(new SourceColumn(column, new Table(table)));
		public CountFunction Count(string column, ISource source) => new CountFunction(new SourceColumn(column, source));
		public CountFunction Count(Func<ExpressionFactory, IColumn> function) => new CountFunction(Column(function));
		public CountFunction Count(IColumn column) => new CountFunction(column);

		#endregion CountFunction factory methods

		#region Function factory methods

		public Function Function(string name) => new Function(name, parameters: null);
		public Function Function(string name, params IExpression[] parameters) => new Function(name, parameters);
		public Function Function(string name, IEnumerable<IExpression>? parameters) => new Function(name, parameters);
		public Function Function(string name, Action<ExpressionBuilder> action) => new Function(name, Expressions(action));

		#endregion Function factory methods

		#region MaxFunction factory methods

		public MaxFunction Max(string column) => new MaxFunction(new SourceColumn(column));
		public MaxFunction Max(string column, string table) => new MaxFunction(new SourceColumn(column, new Table(table)));
		public MaxFunction Max(string column, ISource source) => new MaxFunction(new SourceColumn(column, source));
		public MaxFunction Max(Func<ExpressionFactory, IColumn> function) => new MaxFunction(Column(function));
		public MaxFunction Max(IColumn column) => new MaxFunction(column);

		#endregion MaxFunction factory methods

		#region MinFunction factory methods

		public MinFunction Min(string column) => new MinFunction(new SourceColumn(column));
		public MinFunction Min(string column, string table) => new MinFunction(new SourceColumn(column, new Table(table)));
		public MinFunction Min(string column, ISource source) => new MinFunction(new SourceColumn(column, source));
		public MinFunction Min(Func<ExpressionFactory, IColumn> function) => new MinFunction(Column(function));
		public MinFunction Min(IColumn column) => new MinFunction(column);

		#endregion MinFunction factory methods

		#region SumFunction factory methods

		public SumFunction Sum(string column) => new SumFunction(new SourceColumn(column));
		public SumFunction Sum(string column, string table) => new SumFunction(new SourceColumn(column, new Table(table)));
		public SumFunction Sum(string column, ISource source) => new SumFunction(new SourceColumn(column, source));
		public SumFunction Sum(Func<ExpressionFactory, IColumn> function) => new SumFunction(Column(function));
		public SumFunction Sum(IColumn column) => new SumFunction(column);

		#endregion SumFunction factory methods

		#endregion Functions factory methods

		#region Parameter factory methods

		public Parameter Parameter(string name) => new Parameter(name);

		#endregion Parameter factory methods

		#region Select factory methods



		#endregion Select factory methods

		#region Values factory methods

		#region Int8Value factory methods

		public Int8Value Int8(sbyte value) => new Int8Value(value);
		public Int8Value Int8(short value) => new Int8Value((sbyte)value);
		public Int8Value Int8(int value) => new Int8Value((sbyte)value);
		public Int8Value Int8(long value) => new Int8Value((sbyte)value);
		public Int8Value Int8(float value) => new Int8Value((sbyte)value);
		public Int8Value Int8(double value) => new Int8Value((sbyte)value);
		public Int8Value Int8(decimal value) => new Int8Value((sbyte)value);

		public IValue Int8(sbyte? value) => value.HasValue ? (IValue)new Int8Value(value.Value) : new NullValue();
		public IValue Int8(short? value) => value.HasValue ? (IValue)new Int8Value((sbyte)value.Value) : new NullValue();
		public IValue Int8(int? value) => value.HasValue ? (IValue)new Int8Value((sbyte)value.Value) : new NullValue();
		public IValue Int8(long? value) => value.HasValue ? (IValue)new Int8Value((sbyte)value.Value) : new NullValue();
		public IValue Int8(float? value) => value.HasValue ? (IValue)new Int8Value((sbyte)value.Value) : new NullValue();
		public IValue Int8(double? value) => value.HasValue ? (IValue)new Int8Value((sbyte)value.Value) : new NullValue();
		public IValue Int8(decimal? value) => value.HasValue ? (IValue)new Int8Value((sbyte)value.Value) : new NullValue();

		#endregion Int8Value factory methods

		#region Int16Value factory methods

		public Int16Value Int16(short value) => new Int16Value(value);
		public Int16Value Int16(int value) => new Int16Value((short)value);
		public Int16Value Int16(long value) => new Int16Value((short)value);
		public Int16Value Int16(float value) => new Int16Value((short)value);
		public Int16Value Int16(double value) => new Int16Value((short)value);
		public Int16Value Int16(decimal value) => new Int16Value((short)value);

		public IValue Int16(short? value) => value.HasValue ? (IValue)new Int16Value(value.Value) : new NullValue();
		public IValue Int16(int? value) => value.HasValue ? (IValue)new Int16Value((short)value.Value) : new NullValue();
		public IValue Int16(long? value) => value.HasValue ? (IValue)new Int16Value((short)value.Value) : new NullValue();
		public IValue Int16(float? value) => value.HasValue ? (IValue)new Int16Value((short)value.Value) : new NullValue();
		public IValue Int16(double? value) => value.HasValue ? (IValue)new Int16Value((short)value.Value) : new NullValue();
		public IValue Int16(decimal? value) => value.HasValue ? (IValue)new Int16Value((short)value.Value) : new NullValue();

		#endregion Int16Value factory methods

		#region Int32Value factory methods

		public Int32Value Int32(int value) => new Int32Value(value);
		public Int32Value Int32(long value) => new Int32Value((int)value);
		public Int32Value Int32(float value) => new Int32Value((int)value);
		public Int32Value Int32(double value) => new Int32Value((int)value);
		public Int32Value Int32(decimal value) => new Int32Value((int)value);

		public IValue Int32(int? value) => value.HasValue ? (IValue)new Int32Value(value.Value) : new NullValue();
		public IValue Int32(long? value) => value.HasValue ? (IValue)new Int32Value((int)value.Value) : new NullValue();
		public IValue Int32(float? value) => value.HasValue ? (IValue)new Int32Value((int)value.Value) : new NullValue();
		public IValue Int32(double? value) => value.HasValue ? (IValue)new Int32Value((int)value.Value) : new NullValue();
		public IValue Int32(decimal? value) => value.HasValue ? (IValue)new Int32Value((int)value.Value) : new NullValue();

		#endregion Int32Value factory methods

		#region Int64Value factory methods

		public Int64Value Int64(long value) => new Int64Value(value);
		public Int64Value Int64(float value) => new Int64Value((long)value);
		public Int64Value Int64(double value) => new Int64Value((long)value);
		public Int64Value Int64(decimal value) => new Int64Value((long)value);

		public IValue Int64(long? value) => value.HasValue ? (IValue)new Int64Value(value.Value) : new NullValue();
		public IValue Int64(float? value) => value.HasValue ? (IValue)new Int64Value((long)value.Value) : new NullValue();
		public IValue Int64(double? value) => value.HasValue ? (IValue)new Int64Value((long)value.Value) : new NullValue();
		public IValue Int64(decimal? value) => value.HasValue ? (IValue)new Int64Value((long)value.Value) : new NullValue();

		#endregion Int64Value factory methods

		#region FloatValue factory methods

		public FloatValue Float(float value) => new FloatValue(value);
		public FloatValue Float(double value) => new FloatValue((float)value);
		public FloatValue Float(decimal value) => new FloatValue((float)value);

		public IValue Float(float? value) => value.HasValue ? (IValue)new FloatValue(value.Value) : new NullValue();
		public IValue Float(double? value) => value.HasValue ? (IValue)new FloatValue((float)value.Value) : new NullValue();
		public IValue Float(decimal? value) => value.HasValue ? (IValue)new FloatValue((float)value.Value) : new NullValue();

		#endregion FloatValue factory methods

		#region DoubleValue factory methods

		public DoubleValue Double(double value) => new DoubleValue(value);
		public DoubleValue Double(decimal value) => new DoubleValue((double)value);

		public IValue Double(double? value) => value.HasValue ? (IValue)new DoubleValue(value.Value) : new NullValue();
		public IValue Double(decimal? value) => value.HasValue ? (IValue)new DoubleValue((double)value.Value) : new NullValue();

		#endregion DoubleValue factory methods

		#region DecimalValue factory methods

		public DecimalValue Decimal(decimal value) => new DecimalValue(value);

		public IValue Decimal(decimal? value) => value.HasValue ? (IValue)new DecimalValue(value.Value) : new NullValue();

		#endregion DecimalValue factory methods

		#region DateTimeValue factory methods

		public DateTimeValue DateTime(DateTime value, string? format = null) => new DateTimeValue(value, format);

		public IValue DateTime(DateTime? value, string? format = null) => value.HasValue ? (IValue)new DateTimeValue(value.Value, format) : new NullValue();

		#endregion DateTimeValue factory methods

		#region StringValue factory methods

		public IValue String(string? value) => value == null ? (IValue)new NullValue() : new StringValue(value);
		public IValue String(object? value) => value == null ? (IValue)new NullValue() : new StringValue(value.ToString()!);

		#endregion StringValue factory methods

		#region NullValue factory methods

		public NullValue Null() => new NullValue();

		#endregion NullValue factory methods

		#endregion Values factory methods
	}
}
