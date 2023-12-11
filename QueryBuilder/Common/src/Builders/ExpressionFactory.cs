using System;
using System.Collections.Generic;
using System.Linq;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class ExpressionFactory
	{
		static ExpressionFactory() => Instance = new ExpressionFactory();

		private ExpressionFactory()
		{
		}

		public static readonly ExpressionFactory Instance;

		#region Columns factory methods

		#region IColumn factory methods

		public IColumn Column(Func<ExpressionFactory, IColumn> columnFunction) => columnFunction.Invoke(this);

		public IEnumerable<IColumn> Columns(Action<ColumnBuilder> columnsFunction)
		{
			Guard.ThrowIfNull(columnsFunction, nameof(columnsFunction));

			ColumnBuilder columnBuilder = new ColumnBuilder();
            columnsFunction.Invoke(columnBuilder);

			IEnumerable<IColumn> columns = columnBuilder.Build();

			return columns;
		}

		public IEnumerable<IColumn> Columns(IEnumerable<string> columns)
		{
			Guard.ThrowIfNullOrContainsNullOrEmptyElements(columns, nameof(columns));

			return columns.Select(c => Column(c));
		}

		#endregion IColumn factory methods

		#region ExpressionColumn factory method

		public ExpressionColumn Column(IExpression expression, string? alias = null) =>
		  new ExpressionColumn(expression, alias);

		public ExpressionColumn Column(Func<ExpressionFactory, IExpression> expressionFunction, string? alias = null)
		{
			ExpressionFactory expressionFactory = new ExpressionFactory();
			IExpression expression = expressionFunction.Invoke(expressionFactory);

			return new ExpressionColumn(expression, alias);
		}

		#endregion ExpressionColumn factory methods

		#region SourceColumn factory methods

		public SourceColumn Column(string name) => new SourceColumn(name);
		public SourceColumn Column(string name, string? alias) => new SourceColumn(name, alias);
		public SourceColumn Column(string name, string? table, string? alias) => new SourceColumn(name, string.IsNullOrEmpty(table) ? null : new Table(table), alias); 
		public SourceColumn Column(string name, ISource? source, string? alias = null) => new SourceColumn(name, source, alias);

		#endregion SourceColumn factory methods

		#endregion Columns factory methods

		#region Conditions factory methods

		#region AndCondition factory methods

		public AndCondition And(params ICondition[] conditions) => new AndCondition(conditions);
		public AndCondition And(IEnumerable<ICondition> conditions) => new AndCondition(conditions);
		public AndCondition And(ConditionBuilder conditionBuilder) => new AndCondition(conditionBuilder.Conditions);
		public AndCondition And(Action<ConditionBuilder> conditionFunction)
		{
			ConditionBuilder conditionBuilder = new ConditionBuilder();
			conditionFunction.Invoke(conditionBuilder);

			return new AndCondition(conditionBuilder.Conditions);
		}

		#endregion AndCondition factory methods

		#region OrCondition factory methods

		public OrCondition Or(params ICondition[] conditions) => new OrCondition(conditions);
		public OrCondition Or(IEnumerable<ICondition> conditions) => new OrCondition(conditions);
		public OrCondition Or(ConditionBuilder conditionBuilder) => new OrCondition(conditionBuilder.Conditions);
		public OrCondition Or(Action<ConditionBuilder> conditionFunction)
		{
			ConditionBuilder conditionBuilder = new ConditionBuilder();
			conditionFunction.Invoke(conditionBuilder);

			return new OrCondition(conditionBuilder.Conditions);
		}

		#endregion OrCondition factory methods

		#region EqualCondition factory methods

		public EqualCondition Equal(string column, sbyte value) => Equal(column, Int8(value));
		public EqualCondition Equal(string column, short value) => Equal(column, Int16(value));
		public EqualCondition Equal(string column, int value) => Equal(column, Int32(value));
		public EqualCondition Equal(string column, long value) => Equal(column, Int64(value));
		public EqualCondition Equal(string column, float value) => Equal(column, Float(value));
		public EqualCondition Equal(string column, double value) => Equal(column, Double(value));
		public EqualCondition Equal(string column, decimal value) => Equal(column, Decimal(value));
		public EqualCondition Equal(string column, DateTime value, string? format = null) => Equal(column, DateTime(value, format));
		public EqualCondition Equal(string column, string value) => Equal(column, String(value));
		public EqualCondition Equal(string column, string valueColumn, ISource? valueSource) => Equal(column, Column(valueColumn, valueSource));
		public EqualCondition Equal(string column, Func<ExpressionFactory, IExpression> valueFunction) => Equal(column, Expression(valueFunction));
        public EqualCondition Equal(string column, IExpression value) => Equal(Column(column), value);

        public EqualCondition Equal(string column, string? table, sbyte value) => Equal(column, table, Int8(value));
        public EqualCondition Equal(string column, string? table, short value) => Equal(column, table, Int16(value));
        public EqualCondition Equal(string column, string? table, int value) => Equal(column, table, Int32(value));
        public EqualCondition Equal(string column, string? table, long value) => Equal(column, table, Int64(value));
        public EqualCondition Equal(string column, string? table, float value) => Equal(column, table, Float(value));
        public EqualCondition Equal(string column, string? table, double value) => Equal(column, table, Double(value));
        public EqualCondition Equal(string column, string? table, decimal value) => Equal(column, table, Decimal(value));
        public EqualCondition Equal(string column, string? table, DateTime value, string? format = null) => Equal(column, table, DateTime(value, format));
        public EqualCondition Equal(string column, string? table, string value) => Equal(column, table, String(value));
        public EqualCondition Equal(string column, string? table, string valueColumn, string? valueTable) => Equal(column, table, Column(valueColumn, valueTable, alias: null));
        public EqualCondition Equal(string column, string? table, string valueColumn, ISource? valueSource) => Equal(column, table, Column(valueColumn, valueSource));
        public EqualCondition Equal(string column, string? table, Func<ExpressionFactory, IExpression> valueFunction) => Equal(column, table, Expression(valueFunction));
        public EqualCondition Equal(string column, string? table, IExpression value) => Equal(Column(column, table, alias: null), value);

        public EqualCondition Equal(string column, ISource? source, sbyte value) => Equal(column, source, Int8(value));
		public EqualCondition Equal(string column, ISource? source, short value) => Equal(column, source, Int16(value));
		public EqualCondition Equal(string column, ISource? source, int value) => Equal(column, source, Int32(value));
		public EqualCondition Equal(string column, ISource? source, long value) => Equal(column, source, Int64(value));
		public EqualCondition Equal(string column, ISource? source, float value) => Equal(column, source, Float(value));
		public EqualCondition Equal(string column, ISource? source, double value) => Equal(column, source, Double(value));
		public EqualCondition Equal(string column, ISource? source, decimal value) => Equal(column, source, Decimal(value));
		public EqualCondition Equal(string column, ISource? source, DateTime value, string? format = null) => Equal(column, source, DateTime(value, format));
		public EqualCondition Equal(string column, ISource? source, string value) => Equal(column, source, String(value));
        public EqualCondition Equal(string column, ISource? source, string valueColumn, string? valueTable) => Equal(column, source, Column(valueColumn, valueTable, alias: null));
        public EqualCondition Equal(string column, ISource? source, string valueColumn, ISource? valueSource) => Equal(column, source, Column(valueColumn, valueSource));
        public EqualCondition Equal(string column, ISource? source, Func<ExpressionFactory, IExpression> valueFunction) => Equal(column, source, Expression(valueFunction));
        public EqualCondition Equal(string column, ISource? source, IExpression value) => Equal(Column(column, source), value);

        public EqualCondition Equal(Func<ExpressionFactory, IExpression> expressionFunction, sbyte value) => Equal(expressionFunction, Int8(value));
        public EqualCondition Equal(Func<ExpressionFactory, IExpression> expressionFunction, short value) => Equal(expressionFunction, Int16(value));
        public EqualCondition Equal(Func<ExpressionFactory, IExpression> expressionFunction, int value) => Equal(expressionFunction, Int32(value));
        public EqualCondition Equal(Func<ExpressionFactory, IExpression> expressionFunction, long value) => Equal(expressionFunction, Int64(value));
        public EqualCondition Equal(Func<ExpressionFactory, IExpression> expressionFunction, float value) => Equal(expressionFunction, Float(value));
        public EqualCondition Equal(Func<ExpressionFactory, IExpression> expressionFunction, double value) => Equal(expressionFunction, Double(value));
        public EqualCondition Equal(Func<ExpressionFactory, IExpression> expressionFunction, decimal value) => Equal(expressionFunction, Decimal(value));
        public EqualCondition Equal(Func<ExpressionFactory, IExpression> expressionFunction, DateTime value, string? format = null) => Equal(expressionFunction, DateTime(value, format));
        public EqualCondition Equal(Func<ExpressionFactory, IExpression> expressionFunction, string value) => Equal(expressionFunction, String(value));
		public EqualCondition Equal(Func<ExpressionFactory, IExpression> expressionFunction, string valueColumn, string? valueTable) => Equal(expressionFunction, Column(valueColumn, valueTable, alias: null));
		public EqualCondition Equal(Func<ExpressionFactory, IExpression> expressionFunction, string valueColumn, ISource? valueSource) => Equal(expressionFunction, Column(valueColumn, valueSource));
        public EqualCondition Equal(Func<ExpressionFactory, IExpression> expressionFunction, Func<ExpressionFactory, IExpression> valueFunction) => Equal(expressionFunction, Expression(valueFunction));
        public EqualCondition Equal(Func<ExpressionFactory, IExpression> expressionFunction, IExpression value) => Equal(Expression(expressionFunction), value);

        public EqualCondition Equal(IExpression expression, sbyte value) => Equal(expression, Int8(value));
        public EqualCondition Equal(IExpression expression, short value) => Equal(expression, Int16(value));
        public EqualCondition Equal(IExpression expression, int value) => Equal(expression, Int32(value));
        public EqualCondition Equal(IExpression expression, long value) => Equal(expression, Int64(value));
        public EqualCondition Equal(IExpression expression, float value) => Equal(expression, Float(value));
        public EqualCondition Equal(IExpression expression, double value) => Equal(expression, Double(value));
        public EqualCondition Equal(IExpression expression, decimal value) => Equal(expression, Decimal(value));
        public EqualCondition Equal(IExpression expression, DateTime value, string? format = null) => Equal(expression, DateTime(value, format));
        public EqualCondition Equal(IExpression expression, string value) => Equal(expression, String(value));
		public EqualCondition Equal(IExpression expression, string valueColumn, string? valueTable) => Equal(expression, Column(valueColumn, valueTable, alias: null));
		public EqualCondition Equal(IExpression expression, string valueColumn, ISource? valueSource) => Equal(expression, Column(valueColumn, valueSource));
        public EqualCondition Equal(IExpression expression, Func<ExpressionFactory, IExpression> valueFunction) => Equal(expression, Expression(valueFunction));
        public virtual EqualCondition Equal(IExpression expression, IExpression value) => new EqualCondition(expression, value);

        #endregion EqualCondition factory methods

        #region NotEqualCondition factory methods

		public NotEqualCondition NotEqual(string column, sbyte value) => NotEqual(column, Int8(value));
		public NotEqualCondition NotEqual(string column, short value) => NotEqual(column, Int16(value));
		public NotEqualCondition NotEqual(string column, int value) => NotEqual(column, Int32(value));
		public NotEqualCondition NotEqual(string column, long value) => NotEqual(column, Int64(value));
		public NotEqualCondition NotEqual(string column, float value) => NotEqual(column, Float(value));
		public NotEqualCondition NotEqual(string column, double value) => NotEqual(column, Double(value));
		public NotEqualCondition NotEqual(string column, decimal value) => NotEqual(column, Decimal(value));
		public NotEqualCondition NotEqual(string column, DateTime value, string? format = null) => NotEqual(column, DateTime(value, format));
		public NotEqualCondition NotEqual(string column, string value) => NotEqual(column, String(value));
		public NotEqualCondition NotEqual(string column, string valueColumn, ISource? valueSource) => NotEqual(column, Column(valueColumn, valueSource));
		public NotEqualCondition NotEqual(string column, Func<ExpressionFactory, IExpression> valueFunction) => NotEqual(column, Expression(valueFunction));
        public NotEqualCondition NotEqual(string column, IExpression value) => NotEqual(Column(column), value);

        public NotEqualCondition NotEqual(string column, string? table, sbyte value) => NotEqual(column, table, Int8(value));
        public NotEqualCondition NotEqual(string column, string? table, short value) => NotEqual(column, table, Int16(value));
        public NotEqualCondition NotEqual(string column, string? table, int value) => NotEqual(column, table, Int32(value));
        public NotEqualCondition NotEqual(string column, string? table, long value) => NotEqual(column, table, Int64(value));
        public NotEqualCondition NotEqual(string column, string? table, float value) => NotEqual(column, table, Float(value));
        public NotEqualCondition NotEqual(string column, string? table, double value) => NotEqual(column, table, Double(value));
        public NotEqualCondition NotEqual(string column, string? table, decimal value) => NotEqual(column, table, Decimal(value));
        public NotEqualCondition NotEqual(string column, string? table, DateTime value, string? format = null) => NotEqual(column, table, DateTime(value, format));
        public NotEqualCondition NotEqual(string column, string? table, string value) => NotEqual(column, table, String(value));
        public NotEqualCondition NotEqual(string column, string? table, string valueColumn, string? valueTable) => NotEqual(column, table, Column(valueColumn, valueTable, alias: null));
        public NotEqualCondition NotEqual(string column, string? table, string valueColumn, ISource? valueSource) => NotEqual(column, table, Column(valueColumn, valueSource));
        public NotEqualCondition NotEqual(string column, string? table, Func<ExpressionFactory, IExpression> valueFunction) => NotEqual(column, table, Expression(valueFunction));
        public NotEqualCondition NotEqual(string column, string? table, IExpression value) => NotEqual(Column(column, table, alias: null), value);

        public NotEqualCondition NotEqual(string column, ISource? source, sbyte value) => NotEqual(column, source, Int8(value));
		public NotEqualCondition NotEqual(string column, ISource? source, short value) => NotEqual(column, source, Int16(value));
		public NotEqualCondition NotEqual(string column, ISource? source, int value) => NotEqual(column, source, Int32(value));
		public NotEqualCondition NotEqual(string column, ISource? source, long value) => NotEqual(column, source, Int64(value));
		public NotEqualCondition NotEqual(string column, ISource? source, float value) => NotEqual(column, source, Float(value));
		public NotEqualCondition NotEqual(string column, ISource? source, double value) => NotEqual(column, source, Double(value));
		public NotEqualCondition NotEqual(string column, ISource? source, decimal value) => NotEqual(column, source, Decimal(value));
		public NotEqualCondition NotEqual(string column, ISource? source, DateTime value, string? format = null) => NotEqual(column, source, DateTime(value, format));
		public NotEqualCondition NotEqual(string column, ISource? source, string value) => NotEqual(column, source, String(value));
        public NotEqualCondition NotEqual(string column, ISource? source, string valueColumn, string? valueTable) => NotEqual(column, source, Column(valueColumn, valueTable, alias: null));
        public NotEqualCondition NotEqual(string column, ISource? source, string valueColumn, ISource? valueSource) => NotEqual(column, source, Column(valueColumn, valueSource));
        public NotEqualCondition NotEqual(string column, ISource? source, Func<ExpressionFactory, IExpression> valueFunction) => NotEqual(column, source, Expression(valueFunction));
        public NotEqualCondition NotEqual(string column, ISource? source, IExpression value) => NotEqual(Column(column, source), value);

        public NotEqualCondition NotEqual(Func<ExpressionFactory, IExpression> expressionFunction, sbyte value) => NotEqual(expressionFunction, Int8(value));
        public NotEqualCondition NotEqual(Func<ExpressionFactory, IExpression> expressionFunction, short value) => NotEqual(expressionFunction, Int16(value));
        public NotEqualCondition NotEqual(Func<ExpressionFactory, IExpression> expressionFunction, int value) => NotEqual(expressionFunction, Int32(value));
        public NotEqualCondition NotEqual(Func<ExpressionFactory, IExpression> expressionFunction, long value) => NotEqual(expressionFunction, Int64(value));
        public NotEqualCondition NotEqual(Func<ExpressionFactory, IExpression> expressionFunction, float value) => NotEqual(expressionFunction, Float(value));
        public NotEqualCondition NotEqual(Func<ExpressionFactory, IExpression> expressionFunction, double value) => NotEqual(expressionFunction, Double(value));
        public NotEqualCondition NotEqual(Func<ExpressionFactory, IExpression> expressionFunction, decimal value) => NotEqual(expressionFunction, Decimal(value));
        public NotEqualCondition NotEqual(Func<ExpressionFactory, IExpression> expressionFunction, DateTime value, string? format = null) => NotEqual(expressionFunction, DateTime(value, format));
        public NotEqualCondition NotEqual(Func<ExpressionFactory, IExpression> expressionFunction, string value) => NotEqual(expressionFunction, String(value));
		public NotEqualCondition NotEqual(Func<ExpressionFactory, IExpression> expressionFunction, string valueColumn, string? valueTable) => NotEqual(expressionFunction, Column(valueColumn, valueTable, alias: null));
		public NotEqualCondition NotEqual(Func<ExpressionFactory, IExpression> expressionFunction, string valueColumn, ISource? valueSource) => NotEqual(expressionFunction, Column(valueColumn, valueSource));
        public NotEqualCondition NotEqual(Func<ExpressionFactory, IExpression> expressionFunction, Func<ExpressionFactory, IExpression> valueFunction) => NotEqual(expressionFunction, Expression(valueFunction));
        public NotEqualCondition NotEqual(Func<ExpressionFactory, IExpression> expressionFunction, IExpression value) => NotEqual(Expression(expressionFunction), value);

        public NotEqualCondition NotEqual(IExpression expression, sbyte value) => NotEqual(expression, Int8(value));
        public NotEqualCondition NotEqual(IExpression expression, short value) => NotEqual(expression, Int16(value));
        public NotEqualCondition NotEqual(IExpression expression, int value) => NotEqual(expression, Int32(value));
        public NotEqualCondition NotEqual(IExpression expression, long value) => NotEqual(expression, Int64(value));
        public NotEqualCondition NotEqual(IExpression expression, float value) => NotEqual(expression, Float(value));
        public NotEqualCondition NotEqual(IExpression expression, double value) => NotEqual(expression, Double(value));
        public NotEqualCondition NotEqual(IExpression expression, decimal value) => NotEqual(expression, Decimal(value));
        public NotEqualCondition NotEqual(IExpression expression, DateTime value, string? format = null) => NotEqual(expression, DateTime(value, format));
        public NotEqualCondition NotEqual(IExpression expression, string value) => NotEqual(expression, String(value));
		public NotEqualCondition NotEqual(IExpression expression, string valueColumn, string? valueTable) => NotEqual(expression, Column(valueColumn, valueTable, alias: null));
		public NotEqualCondition NotEqual(IExpression expression, string valueColumn, ISource? valueSource) => NotEqual(expression, Column(valueColumn, valueSource));
        public NotEqualCondition NotEqual(IExpression expression, Func<ExpressionFactory, IExpression> valueFunction) => NotEqual(expression, Expression(valueFunction));
        public virtual NotEqualCondition NotEqual(IExpression expression, IExpression value) => new NotEqualCondition(expression, value);

        #endregion NotEqualCondition factory methods

        #region ExistsCondition factory methods

        public virtual ExistsCondition Exists(Select select) => new ExistsCondition(select);

		#endregion ExistsCondition factory methods

		#region NotExistsCondition factory methods

		public virtual NotExistsCondition NotExists(Select select) => new NotExistsCondition(select);

		#endregion NotExistsCondition factory methods

		#region GreaterCondition factory methods

		public GreaterCondition Greater(string column, sbyte value) => Greater(column, Int8(value));
		public GreaterCondition Greater(string column, short value) => Greater(column, Int16(value));
		public GreaterCondition Greater(string column, int value) => Greater(column, Int32(value));
		public GreaterCondition Greater(string column, long value) => Greater(column, Int64(value));
		public GreaterCondition Greater(string column, float value) => Greater(column, Float(value));
		public GreaterCondition Greater(string column, double value) => Greater(column, Double(value));
		public GreaterCondition Greater(string column, decimal value) => Greater(column, Decimal(value));
		public GreaterCondition Greater(string column, DateTime value, string? format = null) => Greater(column, DateTime(value, format));
		public GreaterCondition Greater(string column, string value) => Greater(column, String(value));
		public GreaterCondition Greater(string column, string valueColumn, ISource? valueSource) => Greater(column, Column(valueColumn, valueSource));
		public GreaterCondition Greater(string column, Func<ExpressionFactory, IExpression> valueFunction) => Greater(column, Expression(valueFunction));
        public GreaterCondition Greater(string column, IExpression value) => Greater(Column(column), value);

        public GreaterCondition Greater(string column, string? table, sbyte value) => Greater(column, table, Int8(value));
        public GreaterCondition Greater(string column, string? table, short value) => Greater(column, table, Int16(value));
        public GreaterCondition Greater(string column, string? table, int value) => Greater(column, table, Int32(value));
        public GreaterCondition Greater(string column, string? table, long value) => Greater(column, table, Int64(value));
        public GreaterCondition Greater(string column, string? table, float value) => Greater(column, table, Float(value));
        public GreaterCondition Greater(string column, string? table, double value) => Greater(column, table, Double(value));
        public GreaterCondition Greater(string column, string? table, decimal value) => Greater(column, table, Decimal(value));
        public GreaterCondition Greater(string column, string? table, DateTime value, string? format = null) => Greater(column, table, DateTime(value, format));
        public GreaterCondition Greater(string column, string? table, string value) => Greater(column, table, String(value));
        public GreaterCondition Greater(string column, string? table, string valueColumn, string? valueTable) => Greater(column, table, Column(valueColumn, valueTable, alias: null));
        public GreaterCondition Greater(string column, string? table, string valueColumn, ISource? valueSource) => Greater(column, table, Column(valueColumn, valueSource));
        public GreaterCondition Greater(string column, string? table, Func<ExpressionFactory, IExpression> valueFunction) => Greater(column, table, Expression(valueFunction));
        public GreaterCondition Greater(string column, string? table, IExpression value) => Greater(Column(column, table, alias: null), value);

        public GreaterCondition Greater(string column, ISource? source, sbyte value) => Greater(column, source, Int8(value));
		public GreaterCondition Greater(string column, ISource? source, short value) => Greater(column, source, Int16(value));
		public GreaterCondition Greater(string column, ISource? source, int value) => Greater(column, source, Int32(value));
		public GreaterCondition Greater(string column, ISource? source, long value) => Greater(column, source, Int64(value));
		public GreaterCondition Greater(string column, ISource? source, float value) => Greater(column, source, Float(value));
		public GreaterCondition Greater(string column, ISource? source, double value) => Greater(column, source, Double(value));
		public GreaterCondition Greater(string column, ISource? source, decimal value) => Greater(column, source, Decimal(value));
		public GreaterCondition Greater(string column, ISource? source, DateTime value, string? format = null) => Greater(column, source, DateTime(value, format));
		public GreaterCondition Greater(string column, ISource? source, string value) => Greater(column, source, String(value));
        public GreaterCondition Greater(string column, ISource? source, string valueColumn, string? valueTable) => Greater(column, source, Column(valueColumn, valueTable, alias: null));
        public GreaterCondition Greater(string column, ISource? source, string valueColumn, ISource? valueSource) => Greater(column, source, Column(valueColumn, valueSource));
        public GreaterCondition Greater(string column, ISource? source, Func<ExpressionFactory, IExpression> valueFunction) => Greater(column, source, Expression(valueFunction));
        public GreaterCondition Greater(string column, ISource? source, IExpression value) => Greater(Column(column, source), value);

        public GreaterCondition Greater(Func<ExpressionFactory, IExpression> expressionFunction, sbyte value) => Greater(expressionFunction, Int8(value));
        public GreaterCondition Greater(Func<ExpressionFactory, IExpression> expressionFunction, short value) => Greater(expressionFunction, Int16(value));
        public GreaterCondition Greater(Func<ExpressionFactory, IExpression> expressionFunction, int value) => Greater(expressionFunction, Int32(value));
        public GreaterCondition Greater(Func<ExpressionFactory, IExpression> expressionFunction, long value) => Greater(expressionFunction, Int64(value));
        public GreaterCondition Greater(Func<ExpressionFactory, IExpression> expressionFunction, float value) => Greater(expressionFunction, Float(value));
        public GreaterCondition Greater(Func<ExpressionFactory, IExpression> expressionFunction, double value) => Greater(expressionFunction, Double(value));
        public GreaterCondition Greater(Func<ExpressionFactory, IExpression> expressionFunction, decimal value) => Greater(expressionFunction, Decimal(value));
        public GreaterCondition Greater(Func<ExpressionFactory, IExpression> expressionFunction, DateTime value, string? format = null) => Greater(expressionFunction, DateTime(value, format));
        public GreaterCondition Greater(Func<ExpressionFactory, IExpression> expressionFunction, string value) => Greater(expressionFunction, String(value));
		public GreaterCondition Greater(Func<ExpressionFactory, IExpression> expressionFunction, string valueColumn, string? valueTable) => Greater(expressionFunction, Column(valueColumn, valueTable, alias: null));
		public GreaterCondition Greater(Func<ExpressionFactory, IExpression> expressionFunction, string valueColumn, ISource? valueSource) => Greater(expressionFunction, Column(valueColumn, valueSource));
		public GreaterCondition Greater(Func<ExpressionFactory, IExpression> expressionFunction, Func<ExpressionFactory, IExpression> valueFunction) => Greater(expressionFunction, Expression(valueFunction));
        public GreaterCondition Greater(Func<ExpressionFactory, IExpression> expressionFunction, IExpression value) => Greater(Expression(expressionFunction), value);

        public GreaterCondition Greater(IExpression expression, sbyte value) => Greater(expression, Int8(value));
        public GreaterCondition Greater(IExpression expression, short value) => Greater(expression, Int16(value));
        public GreaterCondition Greater(IExpression expression, int value) => Greater(expression, Int32(value));
        public GreaterCondition Greater(IExpression expression, long value) => Greater(expression, Int64(value));
        public GreaterCondition Greater(IExpression expression, float value) => Greater(expression, Float(value));
        public GreaterCondition Greater(IExpression expression, double value) => Greater(expression, Double(value));
        public GreaterCondition Greater(IExpression expression, decimal value) => Greater(expression, Decimal(value));
        public GreaterCondition Greater(IExpression expression, DateTime value, string? format = null) => Greater(expression, DateTime(value, format));
        public GreaterCondition Greater(IExpression expression, string value) => Greater(expression, String(value));
		public GreaterCondition Greater(IExpression expression, string valueColumn, string? valueTable) => Greater(expression, Column(valueColumn, valueTable, alias: null));
		public GreaterCondition Greater(IExpression expression, string valueColumn, ISource? valueSource) => Greater(expression, Column(valueColumn, valueSource));
        public GreaterCondition Greater(IExpression expression, Func<ExpressionFactory, IExpression> valueFunction) => Greater(expression, Expression(valueFunction));
        public virtual GreaterCondition Greater(IExpression expression, IExpression value) => new GreaterCondition(expression, value);

        #endregion GreaterCondition factory methods

        #region GreaterOrEqualCondition factory methods

		public GreaterOrEqualCondition GreaterOrEqual(string column, sbyte value) => GreaterOrEqual(column, Int8(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, short value) => GreaterOrEqual(column, Int16(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, int value) => GreaterOrEqual(column, Int32(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, long value) => GreaterOrEqual(column, Int64(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, float value) => GreaterOrEqual(column, Float(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, double value) => GreaterOrEqual(column, Double(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, decimal value) => GreaterOrEqual(column, Decimal(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, DateTime value, string? format = null) => GreaterOrEqual(column, DateTime(value, format));
		public GreaterOrEqualCondition GreaterOrEqual(string column, string value) => GreaterOrEqual(column, String(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, string valueColumn, ISource? valueSource) => GreaterOrEqual(column, Column(valueColumn, valueSource));
		public GreaterOrEqualCondition GreaterOrEqual(string column, Func<ExpressionFactory, IExpression> valueFunction) => GreaterOrEqual(column, Expression(valueFunction));
        public GreaterOrEqualCondition GreaterOrEqual(string column, IExpression value) => GreaterOrEqual(Column(column), value);

        public GreaterOrEqualCondition GreaterOrEqual(string column, string? table, sbyte value) => GreaterOrEqual(column, table, Int8(value));
        public GreaterOrEqualCondition GreaterOrEqual(string column, string? table, short value) => GreaterOrEqual(column, table, Int16(value));
        public GreaterOrEqualCondition GreaterOrEqual(string column, string? table, int value) => GreaterOrEqual(column, table, Int32(value));
        public GreaterOrEqualCondition GreaterOrEqual(string column, string? table, long value) => GreaterOrEqual(column, table, Int64(value));
        public GreaterOrEqualCondition GreaterOrEqual(string column, string? table, float value) => GreaterOrEqual(column, table, Float(value));
        public GreaterOrEqualCondition GreaterOrEqual(string column, string? table, double value) => GreaterOrEqual(column, table, Double(value));
        public GreaterOrEqualCondition GreaterOrEqual(string column, string? table, decimal value) => GreaterOrEqual(column, table, Decimal(value));
        public GreaterOrEqualCondition GreaterOrEqual(string column, string? table, DateTime value, string? format = null) => GreaterOrEqual(column, table, DateTime(value, format));
        public GreaterOrEqualCondition GreaterOrEqual(string column, string? table, string value) => GreaterOrEqual(column, table, String(value));
        public GreaterOrEqualCondition GreaterOrEqual(string column, string? table, string valueColumn, string? valueTable) => GreaterOrEqual(column, table, Column(valueColumn, valueTable, alias: null));
        public GreaterOrEqualCondition GreaterOrEqual(string column, string? table, string valueColumn, ISource? valueSource) => GreaterOrEqual(column, table, Column(valueColumn, valueSource));
        public GreaterOrEqualCondition GreaterOrEqual(string column, string? table, Func<ExpressionFactory, IExpression> valueFunction) => GreaterOrEqual(column, table, Expression(valueFunction));
        public GreaterOrEqualCondition GreaterOrEqual(string column, string? table, IExpression value) => GreaterOrEqual(Column(column, table, alias: null), value);

        public GreaterOrEqualCondition GreaterOrEqual(string column, ISource? source, sbyte value) => GreaterOrEqual(column, source, Int8(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, ISource? source, short value) => GreaterOrEqual(column, source, Int16(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, ISource? source, int value) => GreaterOrEqual(column, source, Int32(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, ISource? source, long value) => GreaterOrEqual(column, source, Int64(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, ISource? source, float value) => GreaterOrEqual(column, source, Float(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, ISource? source, double value) => GreaterOrEqual(column, source, Double(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, ISource? source, decimal value) => GreaterOrEqual(column, source, Decimal(value));
		public GreaterOrEqualCondition GreaterOrEqual(string column, ISource? source, DateTime value, string? format = null) => GreaterOrEqual(column, source, DateTime(value, format));
		public GreaterOrEqualCondition GreaterOrEqual(string column, ISource? source, string value) => GreaterOrEqual(column, source, String(value));
        public GreaterOrEqualCondition GreaterOrEqual(string column, ISource? source, string valueColumn, string? valueTable) => GreaterOrEqual(column, source, Column(valueColumn, valueTable, alias: null));
        public GreaterOrEqualCondition GreaterOrEqual(string column, ISource? source, string valueColumn, ISource? valueSource) => GreaterOrEqual(column, source, Column(valueColumn, valueSource));
        public GreaterOrEqualCondition GreaterOrEqual(string column, ISource? source, Func<ExpressionFactory, IExpression> valueFunction) => GreaterOrEqual(column, source, Expression(valueFunction));
        public GreaterOrEqualCondition GreaterOrEqual(string column, ISource? source, IExpression value) => GreaterOrEqual(Column(column, source), value);

        public GreaterOrEqualCondition GreaterOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, sbyte value) => GreaterOrEqual(expressionFunction, Int8(value));
        public GreaterOrEqualCondition GreaterOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, short value) => GreaterOrEqual(expressionFunction, Int16(value));
        public GreaterOrEqualCondition GreaterOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, int value) => GreaterOrEqual(expressionFunction, Int32(value));
        public GreaterOrEqualCondition GreaterOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, long value) => GreaterOrEqual(expressionFunction, Int64(value));
        public GreaterOrEqualCondition GreaterOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, float value) => GreaterOrEqual(expressionFunction, Float(value));
        public GreaterOrEqualCondition GreaterOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, double value) => GreaterOrEqual(expressionFunction, Double(value));
        public GreaterOrEqualCondition GreaterOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, decimal value) => GreaterOrEqual(expressionFunction, Decimal(value));
        public GreaterOrEqualCondition GreaterOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, DateTime value, string? format = null) => GreaterOrEqual(expressionFunction, DateTime(value, format));
        public GreaterOrEqualCondition GreaterOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, string value) => GreaterOrEqual(expressionFunction, String(value));
        public GreaterOrEqualCondition GreaterOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, string valueColumn, string? valueTable) => GreaterOrEqual(expressionFunction, Column(valueColumn, valueTable, alias: null));
        public GreaterOrEqualCondition GreaterOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, string valueColumn, ISource? valueSource) => GreaterOrEqual(expressionFunction, Column(valueColumn, valueSource));
        public GreaterOrEqualCondition GreaterOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, Func<ExpressionFactory, IExpression> valueFunction) => GreaterOrEqual(expressionFunction, Expression(valueFunction));
        public GreaterOrEqualCondition GreaterOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, IExpression value) => GreaterOrEqual(Expression(expressionFunction), value);

        public GreaterOrEqualCondition GreaterOrEqual(IExpression expression, sbyte value) => GreaterOrEqual(expression, Int8(value));
        public GreaterOrEqualCondition GreaterOrEqual(IExpression expression, short value) => GreaterOrEqual(expression, Int16(value));
        public GreaterOrEqualCondition GreaterOrEqual(IExpression expression, int value) => GreaterOrEqual(expression, Int32(value));
        public GreaterOrEqualCondition GreaterOrEqual(IExpression expression, long value) => GreaterOrEqual(expression, Int64(value));
        public GreaterOrEqualCondition GreaterOrEqual(IExpression expression, float value) => GreaterOrEqual(expression, Float(value));
        public GreaterOrEqualCondition GreaterOrEqual(IExpression expression, double value) => GreaterOrEqual(expression, Double(value));
        public GreaterOrEqualCondition GreaterOrEqual(IExpression expression, decimal value) => GreaterOrEqual(expression, Decimal(value));
        public GreaterOrEqualCondition GreaterOrEqual(IExpression expression, DateTime value, string? format = null) => GreaterOrEqual(expression, DateTime(value, format));
        public GreaterOrEqualCondition GreaterOrEqual(IExpression expression, string value) => GreaterOrEqual(expression, String(value));
		public GreaterOrEqualCondition GreaterOrEqual(IExpression expression, string valueColumn, string? valueTable) => GreaterOrEqual(expression, Column(valueColumn, valueTable, alias: null));
		public GreaterOrEqualCondition GreaterOrEqual(IExpression expression, string valueColumn, ISource? valueSource) => GreaterOrEqual(expression, Column(valueColumn, valueSource));
        public GreaterOrEqualCondition GreaterOrEqual(IExpression expression, Func<ExpressionFactory, IExpression> valueFunction) => GreaterOrEqual(expression, Expression(valueFunction));
        public virtual GreaterOrEqualCondition GreaterOrEqual(IExpression expression, IExpression value) => new GreaterOrEqualCondition(expression, value);

        #endregion GreaterOrEqualCondition factory methods

        #region LessCondition factory methods

		public LessCondition Less(string column, sbyte value) => Less(column, Int8(value));
		public LessCondition Less(string column, short value) => Less(column, Int16(value));
		public LessCondition Less(string column, int value) => Less(column, Int32(value));
		public LessCondition Less(string column, long value) => Less(column, Int64(value));
		public LessCondition Less(string column, float value) => Less(column, Float(value));
		public LessCondition Less(string column, double value) => Less(column, Double(value));
		public LessCondition Less(string column, decimal value) => Less(column, Decimal(value));
		public LessCondition Less(string column, DateTime value, string? format = null) => Less(column, DateTime(value, format));
		public LessCondition Less(string column, string value) => Less(column, String(value));
		public LessCondition Less(string column, string valueColumn, ISource? valueSource) => Less(column, Column(valueColumn, valueSource));
		public LessCondition Less(string column, Func<ExpressionFactory, IExpression> valueFunction) => Less(column, Expression(valueFunction));
        public LessCondition Less(string column, IExpression value) => Less(Column(column), value);

        public LessCondition Less(string column, string? table, sbyte value) => Less(column, table, Int8(value));
        public LessCondition Less(string column, string? table, short value) => Less(column, table, Int16(value));
        public LessCondition Less(string column, string? table, int value) => Less(column, table, Int32(value));
        public LessCondition Less(string column, string? table, long value) => Less(column, table, Int64(value));
        public LessCondition Less(string column, string? table, float value) => Less(column, table, Float(value));
        public LessCondition Less(string column, string? table, double value) => Less(column, table, Double(value));
        public LessCondition Less(string column, string? table, decimal value) => Less(column, table, Decimal(value));
        public LessCondition Less(string column, string? table, DateTime value, string? format = null) => Less(column, table, DateTime(value, format));
        public LessCondition Less(string column, string? table, string value) => Less(column, table, String(value));
        public LessCondition Less(string column, string? table, string valueColumn, string? valueTable) => Less(column, table, Column(valueColumn, valueTable));
        public LessCondition Less(string column, string? table, string valueColumn, ISource? valueSource) => Less(column, table, Column(valueColumn, valueSource));
        public LessCondition Less(string column, string? table, Func<ExpressionFactory, IExpression> valueFunction) => Less(column, table, Expression(valueFunction));
        public LessCondition Less(string column, string? table, IExpression value) => Less(Column(column, table, alias: null), value);

        public LessCondition Less(string column, ISource? source, sbyte value) => Less(column, source, Int8(value));
		public LessCondition Less(string column, ISource? source, short value) => Less(column, source, Int16(value));
		public LessCondition Less(string column, ISource? source, int value) => Less(column, source, Int32(value));
		public LessCondition Less(string column, ISource? source, long value) => Less(column, source, Int64(value));
		public LessCondition Less(string column, ISource? source, float value) => Less(column, source, Float(value));
		public LessCondition Less(string column, ISource? source, double value) => Less(column, source, Double(value));
		public LessCondition Less(string column, ISource? source, decimal value) => Less(column, source, Decimal(value));
		public LessCondition Less(string column, ISource? source, DateTime value, string? format = null) => Less(column, source, DateTime(value, format));
		public LessCondition Less(string column, ISource? source, string value) => Less(column, source, String(value));
        public LessCondition Less(string column, ISource? source, string valueColumn, string? valueTable) => Less(column, source, Column(valueColumn, valueTable));
        public LessCondition Less(string column, ISource? source, string valueColumn, ISource? valueSource) => Less(column, source, Column(valueColumn, valueSource));
        public LessCondition Less(string column, ISource? source, Func<ExpressionFactory, IExpression> valueFunction) => Less(column, source, Expression(valueFunction));
        public LessCondition Less(string column, ISource? source, IExpression value) => Less(Column(column, source), value);

        public LessCondition Less(Func<ExpressionFactory, IExpression> expressionFunction, sbyte value) => Less(expressionFunction, Int8(value));
        public LessCondition Less(Func<ExpressionFactory, IExpression> expressionFunction, short value) => Less(expressionFunction, Int16(value));
        public LessCondition Less(Func<ExpressionFactory, IExpression> expressionFunction, int value) => Less(expressionFunction, Int32(value));
        public LessCondition Less(Func<ExpressionFactory, IExpression> expressionFunction, long value) => Less(expressionFunction, Int64(value));
        public LessCondition Less(Func<ExpressionFactory, IExpression> expressionFunction, float value) => Less(expressionFunction, Float(value));
        public LessCondition Less(Func<ExpressionFactory, IExpression> expressionFunction, double value) => Less(expressionFunction, Double(value));
        public LessCondition Less(Func<ExpressionFactory, IExpression> expressionFunction, decimal value) => Less(expressionFunction, Decimal(value));
        public LessCondition Less(Func<ExpressionFactory, IExpression> expressionFunction, DateTime value, string? format = null) => Less(expressionFunction, DateTime(value, format));
        public LessCondition Less(Func<ExpressionFactory, IExpression> expressionFunction, string value) => Less(expressionFunction, String(value));
        public LessCondition Less(Func<ExpressionFactory, IExpression> expressionFunction, string valueColumn, string? valueTable) => Less(expressionFunction, Column(valueColumn, valueTable, alias: null));
        public LessCondition Less(Func<ExpressionFactory, IExpression> expressionFunction, string valueColumn, ISource? valueSource) => Less(expressionFunction, Column(valueColumn, valueSource));
        public LessCondition Less(Func<ExpressionFactory, IExpression> expressionFunction, Func<ExpressionFactory, IExpression> valueFunction) => Less(expressionFunction, Expression(valueFunction));
        public LessCondition Less(Func<ExpressionFactory, IExpression> expressionFunction, IExpression value) => Less(Expression(expressionFunction), value);

        public LessCondition Less(IExpression expression, sbyte value) => Less(expression, Int8(value));
        public LessCondition Less(IExpression expression, short value) => Less(expression, Int16(value));
        public LessCondition Less(IExpression expression, int value) => Less(expression, Int32(value));
        public LessCondition Less(IExpression expression, long value) => Less(expression, Int64(value));
        public LessCondition Less(IExpression expression, float value) => Less(expression, Float(value));
        public LessCondition Less(IExpression expression, double value) => Less(expression, Double(value));
        public LessCondition Less(IExpression expression, decimal value) => Less(expression, Decimal(value));
        public LessCondition Less(IExpression expression, DateTime value, string? format = null) => Less(expression, DateTime(value, format));
        public LessCondition Less(IExpression expression, string value) => Less(expression, String(value));
        public LessCondition Less(IExpression expression, string valueColumn, string? valueTable) => Less(expression, Column(valueColumn, valueTable, alias: null));
        public LessCondition Less(IExpression expression, string valueColumn, ISource? valueSource) => Less(expression, Column(valueColumn, valueSource));
        public LessCondition Less(IExpression expression, Func<ExpressionFactory, IExpression> valueFunction) => Less(expression, Expression(valueFunction));
        public virtual LessCondition Less(IExpression expression, IExpression value) => new LessCondition(expression, value);

        #endregion LessCondition factory methods

        #region LessOrEqualCondition factory methods

		public LessOrEqualCondition LessOrEqual(string column, sbyte value) => LessOrEqual(column, Int8(value));
		public LessOrEqualCondition LessOrEqual(string column, short value) => LessOrEqual(column, Int16(value));
		public LessOrEqualCondition LessOrEqual(string column, int value) => LessOrEqual(column, Int32(value));
		public LessOrEqualCondition LessOrEqual(string column, long value) => LessOrEqual(column, Int64(value));
		public LessOrEqualCondition LessOrEqual(string column, float value) => LessOrEqual(column, Float(value));
		public LessOrEqualCondition LessOrEqual(string column, double value) => LessOrEqual(column, Double(value));
		public LessOrEqualCondition LessOrEqual(string column, decimal value) => LessOrEqual(column, Decimal(value));
		public LessOrEqualCondition LessOrEqual(string column, DateTime value, string? format = null) => LessOrEqual(column, DateTime(value, format));
		public LessOrEqualCondition LessOrEqual(string column, string value) => LessOrEqual(column, String(value));
		public LessOrEqualCondition LessOrEqual(string column, string valueColumn, ISource? valueSource) => LessOrEqual(column, Column(valueColumn, valueSource));
		public LessOrEqualCondition LessOrEqual(string column, Func<ExpressionFactory, IExpression> valueFunction) => LessOrEqual(column, Expression(valueFunction));
        public LessOrEqualCondition LessOrEqual(string column, IExpression value) => LessOrEqual(Column(column), value);

        public LessOrEqualCondition LessOrEqual(string column, string? table, sbyte value) => LessOrEqual(column, table, Int8(value));
        public LessOrEqualCondition LessOrEqual(string column, string? table, short value) => LessOrEqual(column, table, Int16(value));
        public LessOrEqualCondition LessOrEqual(string column, string? table, int value) => LessOrEqual(column, table, Int32(value));
        public LessOrEqualCondition LessOrEqual(string column, string? table, long value) => LessOrEqual(column, table, Int64(value));
        public LessOrEqualCondition LessOrEqual(string column, string? table, float value) => LessOrEqual(column, table, Float(value));
        public LessOrEqualCondition LessOrEqual(string column, string? table, double value) => LessOrEqual(column, table, Double(value));
        public LessOrEqualCondition LessOrEqual(string column, string? table, decimal value) => LessOrEqual(column, table, Decimal(value));
        public LessOrEqualCondition LessOrEqual(string column, string? table, DateTime value, string? format = null) => LessOrEqual(column, table, DateTime(value, format));
        public LessOrEqualCondition LessOrEqual(string column, string? table, string value) => LessOrEqual(column, table, String(value));
        public LessOrEqualCondition LessOrEqual(string column, string? table, string valueColumn, string? valueTable) => LessOrEqual(column, table, Column(valueColumn, valueTable, alias: null));
        public LessOrEqualCondition LessOrEqual(string column, string? table, string valueColumn, ISource? valueSource) => LessOrEqual(column, table, Column(valueColumn, valueSource));
        public LessOrEqualCondition LessOrEqual(string column, string? table, Func<ExpressionFactory, IExpression> valueFunction) => LessOrEqual(column, table, Expression(valueFunction));
        public LessOrEqualCondition LessOrEqual(string column, string? table, IExpression value) => LessOrEqual(Column(column, table, alias: null), value);

        public LessOrEqualCondition LessOrEqual(string column, ISource? source, sbyte value) => LessOrEqual(column, source, Int8(value));
		public LessOrEqualCondition LessOrEqual(string column, ISource? source, short value) => LessOrEqual(column, source, Int16(value));
		public LessOrEqualCondition LessOrEqual(string column, ISource? source, int value) => LessOrEqual(column, source, Int32(value));
		public LessOrEqualCondition LessOrEqual(string column, ISource? source, long value) => LessOrEqual(column, source, Int64(value));
		public LessOrEqualCondition LessOrEqual(string column, ISource? source, float value) => LessOrEqual(column, source, Float(value));
		public LessOrEqualCondition LessOrEqual(string column, ISource? source, double value) => LessOrEqual(column, source, Double(value));
		public LessOrEqualCondition LessOrEqual(string column, ISource? source, decimal value) => LessOrEqual(column, source, Decimal(value));
		public LessOrEqualCondition LessOrEqual(string column, ISource? source, DateTime value, string? format = null) => LessOrEqual(column, source, DateTime(value, format));
		public LessOrEqualCondition LessOrEqual(string column, ISource? source, string value) => LessOrEqual(column, source, String(value));
        public LessOrEqualCondition LessOrEqual(string column, ISource? source, string valueColumn, string? valueTable) => LessOrEqual(column, source, Column(valueColumn, valueTable, alias: null));
        public LessOrEqualCondition LessOrEqual(string column, ISource? source, string valueColumn, ISource? valueSource) => LessOrEqual(column, source, Column(valueColumn, valueSource));
		public LessOrEqualCondition LessOrEqual(string column, ISource? source, Func<ExpressionFactory, IExpression> valueFunction) => LessOrEqual(column, source, Expression(valueFunction));
        public LessOrEqualCondition LessOrEqual(string column, ISource? source, IExpression value) => LessOrEqual(Column(column, source), value);

        public LessOrEqualCondition LessOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, sbyte value) => LessOrEqual(expressionFunction, Int8(value));
        public LessOrEqualCondition LessOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, short value) => LessOrEqual(expressionFunction, Int16(value));
        public LessOrEqualCondition LessOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, int value) => LessOrEqual(expressionFunction, Int32(value));
        public LessOrEqualCondition LessOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, long value) => LessOrEqual(expressionFunction, Int64(value));
        public LessOrEqualCondition LessOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, float value) => LessOrEqual(expressionFunction, Float(value));
        public LessOrEqualCondition LessOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, double value) => LessOrEqual(expressionFunction, Double(value));
        public LessOrEqualCondition LessOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, decimal value) => LessOrEqual(expressionFunction, Decimal(value));
        public LessOrEqualCondition LessOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, DateTime value, string? format = null) => LessOrEqual(expressionFunction, DateTime(value, format));
        public LessOrEqualCondition LessOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, string value) => LessOrEqual(expressionFunction, String(value));
		public LessOrEqualCondition LessOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, string valueColumn, string? valueTable) => LessOrEqual(expressionFunction, Column(valueColumn, valueTable, alias: null));
		public LessOrEqualCondition LessOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, string valueColumn, ISource? valueSource) => LessOrEqual(expressionFunction, Column(valueColumn, valueSource));
		public LessOrEqualCondition LessOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, Func<ExpressionFactory, IExpression> valueFunction) => LessOrEqual(expressionFunction, Expression(valueFunction));
        public LessOrEqualCondition LessOrEqual(Func<ExpressionFactory, IExpression> expressionFunction, IExpression value) => LessOrEqual(Expression(expressionFunction), value);

        public LessOrEqualCondition LessOrEqual(IExpression expression, sbyte value) => LessOrEqual(expression, Int8(value));
        public LessOrEqualCondition LessOrEqual(IExpression expression, short value) => LessOrEqual(expression, Int16(value));
        public LessOrEqualCondition LessOrEqual(IExpression expression, int value) => LessOrEqual(expression, Int32(value));
        public LessOrEqualCondition LessOrEqual(IExpression expression, long value) => LessOrEqual(expression, Int64(value));
        public LessOrEqualCondition LessOrEqual(IExpression expression, float value) => LessOrEqual(expression, Float(value));
        public LessOrEqualCondition LessOrEqual(IExpression expression, double value) => LessOrEqual(expression, Double(value));
        public LessOrEqualCondition LessOrEqual(IExpression expression, decimal value) => LessOrEqual(expression, Decimal(value));
        public LessOrEqualCondition LessOrEqual(IExpression expression, DateTime value, string? format = null) => LessOrEqual(expression, DateTime(value, format));
        public LessOrEqualCondition LessOrEqual(IExpression expression, string value) => LessOrEqual(expression, String(value));
        public LessOrEqualCondition LessOrEqual(IExpression expression, string valueColumn, string? valueTable) => LessOrEqual(expression, Column(valueColumn, valueTable, alias: null));
        public LessOrEqualCondition LessOrEqual(IExpression expression, string valueColumn, ISource? valueSource) => LessOrEqual(expression, Column(valueColumn, valueSource));
        public LessOrEqualCondition LessOrEqual(IExpression expression, Func<ExpressionFactory, IExpression> valueFunction) => LessOrEqual(expression, Expression(valueFunction));
        public virtual LessOrEqualCondition LessOrEqual(IExpression expression, IExpression value) => new LessOrEqualCondition(expression, value);

        #endregion LessOrEqualCondition factory methods

        #region IsNullCondition factory methods

		public IsNullCondition IsNull(string column) => IsNull(new SourceColumn(column));
		public IsNullCondition IsNull(string column, string? table) => IsNull(Column(column, table, alias: null));
		public IsNullCondition IsNull(string column, ISource? source) => IsNull(Column(column, source));
		public IsNullCondition IsNull(Func<ExpressionFactory, IExpression> expressionFunction) => IsNull(Expression(expressionFunction));
        public virtual IsNullCondition IsNull(IExpression expression) => new IsNullCondition(expression);

        #endregion IsNullCondition factory methods

        #region IsNotNullCondition factory methods

		public IsNotNullCondition IsNotNull(string column) => IsNotNull(Column(column));
		public IsNotNullCondition IsNotNull(string column, string? table) => IsNotNull(Column(column, table, alias: null));
		public IsNotNullCondition IsNotNull(string column, ISource? source) => IsNotNull(Column(column, source));
		public IsNotNullCondition IsNotNull(Func<ExpressionFactory, IExpression> expressionFunction) => IsNotNull(Expression(expressionFunction));
        public virtual IsNotNullCondition IsNotNull(IExpression expression) => new IsNotNullCondition(expression);

        #endregion IsNotNullCondition factory methods

        #region InCondition factory methods

		public InCondition In(string column, params sbyte[] values) => In(column, values.Select(v => Int8(v)));
		public InCondition In(string column, params short[] values) => In(column, values.Select(v => Int16(v)));
		public InCondition In(string column, params int[] values) => In(column, values.Select(v => Int32(v)));
		public InCondition In(string column, params long[] values) => In(column, values.Select(v => Int64(v)));
		public InCondition In(string column, params float[] values) => In(column, values.Select(v => Float(v)));
		public InCondition In(string column, params double[] values) => In(column, values.Select(v => Double(v)));
		public InCondition In(string column, params decimal[] values) => In(column, values.Select(v => Decimal(v)));
		public InCondition In(string column, params DateTime[] values) => In(column, values.Select(v => DateTime(v)));
		public InCondition In(string column, string format, params DateTime[] values) => In(column, values.Select(v => DateTime(v, format)));
		public InCondition In(string column, params string[] values) => In(column, values.Select(v => String(v)));
		public InCondition In(string column, params IExpression[] values) => In(column, values);
		public InCondition In(string column, IEnumerable<sbyte> values) => In(column, values.Select(v => Int8(v)));
		public InCondition In(string column, IEnumerable<short> values) => In(column, values.Select(v => Int16(v)));
		public InCondition In(string column, IEnumerable<int> values) => In(column, values.Select(v => Int32(v)));
		public InCondition In(string column, IEnumerable<long> values) => In(column, values.Select(v => Int64(v)));
		public InCondition In(string column, IEnumerable<float> values) => In(column, values.Select(v => Float(v)));
		public InCondition In(string column, IEnumerable<double> values) => In(column, values.Select(v => Double(v)));
		public InCondition In(string column, IEnumerable<decimal> values) => In(column, values.Select(v => Decimal(v)));
		public InCondition In(string column, IEnumerable<DateTime> values, string? format = null) => In(column, values.Select(v => DateTime(v, format)));
		public InCondition In(string column, IEnumerable<string> values) => In(column, values.Select(v => String(v)));
		public InCondition In(string column, Action<ExpressionBuilder> valuesFunction) => In(column, Expressions(valuesFunction));
        public InCondition In(string column, IEnumerable<IExpression> values) => In(Column(column), values);

        public InCondition In(string column, string? table, params sbyte[] values) => In(column, table, values.Select(v => Int8(v)));
        public InCondition In(string column, string? table, params short[] values) => In(column, table, values.Select(v => Int16(v)));
        public InCondition In(string column, string? table, params int[] values) => In(column, table, values.Select(v => Int32(v)));
        public InCondition In(string column, string? table, params long[] values) => In(column, table, values.Select(v => Int64(v)));
        public InCondition In(string column, string? table, params float[] values) => In(column, table, values.Select(v => Float(v)));
        public InCondition In(string column, string? table, params double[] values) => In(column, table, values.Select(v => Double(v)));
        public InCondition In(string column, string? table, params decimal[] values) => In(column, table, values.Select(v => Decimal(v)));
        public InCondition In(string column, string? table, string format, params DateTime[] values) => In(column, table, values.Select(v => DateTime(v, format)));
        public InCondition In(string column, string? table, params string[] values) => In(column, table, values.Select(v => String(v)));
        public InCondition In(string column, string? table, params IExpression[] values) => In(column, table, values);
        public InCondition In(string column, string? table, IEnumerable<sbyte> values) => In(column, table, values.Select(v => Int8(v)));
        public InCondition In(string column, string? table, IEnumerable<short> values) => In(column, table, values.Select(v => Int16(v)));
        public InCondition In(string column, string? table, IEnumerable<int> values) => In(column, table, values.Select(v => Int32(v)));
        public InCondition In(string column, string? table, IEnumerable<long> values) => In(column, table, values.Select(v => Int64(v)));
        public InCondition In(string column, string? table, IEnumerable<float> values) => In(column, table, values.Select(v => Float(v)));
        public InCondition In(string column, string? table, IEnumerable<double> values) => In(column, table, values.Select(v => Double(v)));
        public InCondition In(string column, string? table, IEnumerable<decimal> values) => In(column, table, values.Select(v => Decimal(v)));
        public InCondition In(string column, string? table, IEnumerable<DateTime> values, string? format = null) => In(column, table, values.Select(v => DateTime(v, format)));
        public InCondition In(string column, string? table, IEnumerable<string> values) => In(column, table, values.Select(v => String(v)));
        public InCondition In(string column, string? table, Action<ExpressionBuilder> valuesFunction) => In(column, table, Expressions(valuesFunction));
        public InCondition In(string column, string? table, IEnumerable<IExpression> values) => In(Column(column, table, alias: null), values);

        public InCondition In(string column, ISource? source, params sbyte[] values) => In(column, source, values.Select(v => Int8(v)));
		public InCondition In(string column, ISource? source, params short[] values) => In(column, source, values.Select(v => Int16(v)));
		public InCondition In(string column, ISource? source, params int[] values) => In(column, source, values.Select(v => Int32(v)));
		public InCondition In(string column, ISource? source, params long[] values) => In(column, source, values.Select(v => Int64(v)));
		public InCondition In(string column, ISource? source, params float[] values) => In(column, source, values.Select(v => Float(v)));
		public InCondition In(string column, ISource? source, params double[] values) => In(column, source, values.Select(v => Double(v)));
		public InCondition In(string column, ISource? source, params decimal[] values) => In(column, source, values.Select(v => Decimal(v)));
		public InCondition In(string column, ISource? source, params DateTime[] values) => In(column, source, values.Select(v => DateTime(v)));
		public InCondition In(string column, ISource? source, string format, params DateTime[] values) => In(column, source, values.Select(v => DateTime(v, format)));
		public InCondition In(string column, ISource? source, params string[] values) => In(column, source, values.Select(v => String(v)));
		public InCondition In(string column, ISource? source, params IExpression[] values) => In(column, source, values);
		public InCondition In(string column, ISource? source, IEnumerable<sbyte> values) => In(column, source, values.Select(v => Int8(v)));
		public InCondition In(string column, ISource? source, IEnumerable<short> values) => In(column, source, values.Select(v => Int16(v)));
		public InCondition In(string column, ISource? source, IEnumerable<int> values) => In(column, source, values.Select(v => Int32(v)));
		public InCondition In(string column, ISource? source, IEnumerable<long> values) => In(column, source, values.Select(v => Int64(v)));
		public InCondition In(string column, ISource? source, IEnumerable<float> values) => In(column, source, values.Select(v => Float(v)));
		public InCondition In(string column, ISource? source, IEnumerable<double> values) => In(column, source, values.Select(v => Double(v)));
		public InCondition In(string column, ISource? source, IEnumerable<decimal> values) => In(column, source, values.Select(v => Decimal(v)));
		public InCondition In(string column, ISource? source, IEnumerable<DateTime> values, string? format = null) => In(column, source, values.Select(v => DateTime(v, format)));
		public InCondition In(string column, ISource? source, IEnumerable<string> values) => In(column, source, values.Select(v => String(v)));
		public InCondition In(string column, ISource? source, Action<ExpressionBuilder> valuesFunction) => In(column, source, Expressions(valuesFunction));
        public InCondition In(string column, ISource? source, IEnumerable<IExpression> values) => In(Column(column, source), values);

        public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, params sbyte[] values) => In(expressionFunction, values.Select(v => Int8(v)));
        public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, params short[] values) => In(expressionFunction, values.Select(v => Int16(v)));
        public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, params int[] values) => In(expressionFunction, values.Select(v => Int32(v)));
        public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, params long[] values) => In(expressionFunction, values.Select(v => Int64(v)));
        public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, params float[] values) => In(expressionFunction, values.Select(v => Float(v)));
        public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, params double[] values) => In(expressionFunction, values.Select(v => Double(v)));
        public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, params decimal[] values) => In(expressionFunction, values.Select(v => Decimal(v)));
        public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, params DateTime[] values) => In(expressionFunction, values.Select(v => DateTime(v)));
        public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, string format, params DateTime[] values) => In(expressionFunction, values.Select(v => DateTime(v, format)));
        public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, params string[] values) => In(expressionFunction, values.Select(v => String(v)));
        public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, params IExpression[] values) => In(expressionFunction, values);
        public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, IEnumerable<sbyte> values) => In(expressionFunction, values.Select(v => Int8(v)));
        public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, IEnumerable<short> values) => In(expressionFunction, values.Select(v => Int16(v)));
        public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, IEnumerable<int> values) => In(expressionFunction, values.Select(v => Int32(v)));
        public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, IEnumerable<long> values) => In(expressionFunction, values.Select(v => Int64(v)));
        public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, IEnumerable<float> values) => In(expressionFunction, values.Select(v => Float(v)));
        public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, IEnumerable<double> values) => In(expressionFunction, values.Select(v => Double(v)));
        public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, IEnumerable<decimal> values) => In(expressionFunction, values.Select(v => Decimal(v)));
        public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, IEnumerable<DateTime> values, string? format = null) => In(expressionFunction, values.Select(v => DateTime(v, format)));
        public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, IEnumerable<string> values) => In(expressionFunction, values.Select(v => String(v)));
        public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, Action<ExpressionBuilder> valuesFunction) => In(expressionFunction, Expressions(valuesFunction));
        public InCondition In(Func<ExpressionFactory, IExpression> expressionFunction, IEnumerable<IExpression> values) => In(Expression(expressionFunction), values);

        public InCondition In(IExpression expression, params sbyte[] values) => In(expression, values.Select(v => Int8(v)));
        public InCondition In(IExpression expression, params short[] values) => In(expression, values.Select(v => Int16(v)));
        public InCondition In(IExpression expression, params int[] values) => In(expression, values.Select(v => Int32(v)));
        public InCondition In(IExpression expression, params long[] values) => In(expression, values.Select(v => Int64(v)));
        public InCondition In(IExpression expression, params float[] values) => In(expression, values.Select(v => Float(v)));
        public InCondition In(IExpression expression, params double[] values) => In(expression, values.Select(v => Double(v)));
        public InCondition In(IExpression expression, params decimal[] values) => In(expression, values.Select(v => Decimal(v)));
        public InCondition In(IExpression expression, params DateTime[] values) => In(expression, values.Select(v => DateTime(v)));
        public InCondition In(IExpression expression, string format, params DateTime[] values) => In(expression, values.Select(v => DateTime(v, format)));
        public InCondition In(IExpression expression, params string[] values) => In(expression, values.Select(v => String(v)));
        public InCondition In(IExpression expression, params IExpression[] values) => In(expression, values);
        public InCondition In(IExpression expression, IEnumerable<sbyte> values) => In(expression, values.Select(v => Int8(v)));
        public InCondition In(IExpression expression, IEnumerable<short> values) => In(expression, values.Select(v => Int16(v)));
        public InCondition In(IExpression expression, IEnumerable<int> values) => In(expression, values.Select(v => Int32(v)));
        public InCondition In(IExpression expression, IEnumerable<long> values) => In(expression, values.Select(v => Int64(v)));
        public InCondition In(IExpression expression, IEnumerable<float> values) => In(expression, values.Select(v => Float(v)));
        public InCondition In(IExpression expression, IEnumerable<double> values) => In(expression, values.Select(v => Double(v)));
        public InCondition In(IExpression expression, IEnumerable<decimal> values) => In(expression, values.Select(v => Decimal(v)));
        public InCondition In(IExpression expression, IEnumerable<DateTime> values, string? format = null) => In(expression, values.Select(v => DateTime(v, format)));
        public InCondition In(IExpression expression, IEnumerable<string> values) => In(expression, values.Select(v => String(v)));
        public InCondition In(IExpression expression, Action<ExpressionBuilder> valuesFunction) => In(expression, Expressions(valuesFunction));
        public virtual InCondition In(IExpression expression, IEnumerable<IExpression> values) => new InCondition(expression, values);

        #endregion InCondition factory methods

        #region NotInCondition factory methods

		public NotInCondition NotIn(string column, params sbyte[] values) => NotIn(column, values.Select(v => Int8(v)));
		public NotInCondition NotIn(string column, params short[] values) => NotIn(column, values.Select(v => Int16(v)));
		public NotInCondition NotIn(string column, params int[] values) => NotIn(column, values.Select(v => Int32(v)));
		public NotInCondition NotIn(string column, params long[] values) => NotIn(column, values.Select(v => Int64(v)));
		public NotInCondition NotIn(string column, params float[] values) => NotIn(column, values.Select(v => Float(v)));
		public NotInCondition NotIn(string column, params double[] values) => NotIn(column, values.Select(v => Double(v)));
		public NotInCondition NotIn(string column, params decimal[] values) => NotIn(column, values.Select(v => Decimal(v)));
		public NotInCondition NotIn(string column, params DateTime[] values) => NotIn(column, values.Select(v => DateTime(v)));
		public NotInCondition NotIn(string column, string format, params DateTime[] values) => NotIn(column, values.Select(v => DateTime(v, format)));
		public NotInCondition NotIn(string column, params string[] values) => NotIn(column, values.Select(v => String(v)));
		public NotInCondition NotIn(string column, params IExpression[] values) => NotIn(column, values);
		public NotInCondition NotIn(string column, IEnumerable<sbyte> values) => NotIn(column, values.Select(v => Int8(v)));
		public NotInCondition NotIn(string column, IEnumerable<short> values) => NotIn(column, values.Select(v => Int16(v)));
		public NotInCondition NotIn(string column, IEnumerable<int> values) => NotIn(column, values.Select(v => Int32(v)));
		public NotInCondition NotIn(string column, IEnumerable<long> values) => NotIn(column, values.Select(v => Int64(v)));
		public NotInCondition NotIn(string column, IEnumerable<float> values) => NotIn(column, values.Select(v => Float(v)));
		public NotInCondition NotIn(string column, IEnumerable<double> values) => NotIn(column, values.Select(v => Double(v)));
		public NotInCondition NotIn(string column, IEnumerable<decimal> values) => NotIn(column, values.Select(v => Decimal(v)));
		public NotInCondition NotIn(string column, IEnumerable<DateTime> values, string? format = null) => NotIn(column, values.Select(v => DateTime(v, format)));
		public NotInCondition NotIn(string column, IEnumerable<string> values) => NotIn(column, values.Select(v => String(v)));
		public NotInCondition NotIn(string column, Action<ExpressionBuilder> valuesFunction) => NotIn(column, Expressions(valuesFunction));
        public NotInCondition NotIn(string column, IEnumerable<IExpression> values) => NotIn(Column(column), values);

        public NotInCondition NotIn(string column, string? table, params sbyte[] values) => NotIn(column, table, values.Select(v => Int8(v)));
        public NotInCondition NotIn(string column, string? table, params short[] values) => NotIn(column, table, values.Select(v => Int16(v)));
        public NotInCondition NotIn(string column, string? table, params int[] values) => NotIn(column, table, values.Select(v => Int32(v)));
        public NotInCondition NotIn(string column, string? table, params long[] values) => NotIn(column, table, values.Select(v => Int64(v)));
        public NotInCondition NotIn(string column, string? table, params float[] values) => NotIn(column, table, values.Select(v => Float(v)));
        public NotInCondition NotIn(string column, string? table, params double[] values) => NotIn(column, table, values.Select(v => Double(v)));
        public NotInCondition NotIn(string column, string? table, params decimal[] values) => NotIn(column, table, values.Select(v => Decimal(v)));
        public NotInCondition NotIn(string column, string? table, string? format, params DateTime[] values) => NotIn(column, table, values.Select(v => DateTime(v, format)));
        public NotInCondition NotIn(string column, string? table, params string[] values) => NotIn(column, table, values.Select(v => String(v)));
        public NotInCondition NotIn(string column, string? table, params IExpression[] values) => NotIn(column, table, values);
        public NotInCondition NotIn(string column, string? table, IEnumerable<sbyte> values) => NotIn(column, table, values.Select(v => Int8(v)));
        public NotInCondition NotIn(string column, string? table, IEnumerable<short> values) => NotIn(column, table, values.Select(v => Int16(v)));
        public NotInCondition NotIn(string column, string? table, IEnumerable<int> values) => NotIn(column, table, values.Select(v => Int32(v)));
        public NotInCondition NotIn(string column, string? table, IEnumerable<long> values) => NotIn(column, table, values.Select(v => Int64(v)));
        public NotInCondition NotIn(string column, string? table, IEnumerable<float> values) => NotIn(column, table, values.Select(v => Float(v)));
        public NotInCondition NotIn(string column, string? table, IEnumerable<double> values) => NotIn(column, table, values.Select(v => Double(v)));
        public NotInCondition NotIn(string column, string? table, IEnumerable<decimal> values) => NotIn(column, table, values.Select(v => Decimal(v)));
        public NotInCondition NotIn(string column, string? table, IEnumerable<DateTime> values, string? format = null) => NotIn(column, table, values.Select(v => DateTime(v, format)));
        public NotInCondition NotIn(string column, string? table, IEnumerable<string> values) => NotIn(column, table, values.Select(v => String(v)));
        public NotInCondition NotIn(string column, string? table, Action<ExpressionBuilder> valuesFunction) => NotIn(column, table, Expressions(valuesFunction));
        public NotInCondition NotIn(string column, string? table, IEnumerable<IExpression> values) => NotIn(Column(column, table, alias: null), values);

        public NotInCondition NotIn(string column, ISource? source, params sbyte[] values) => NotIn(column, source, values.Select(v => Int8(v)));
		public NotInCondition NotIn(string column, ISource? source, params short[] values) => NotIn(column, source, values.Select(v => Int16(v)));
		public NotInCondition NotIn(string column, ISource? source, params int[] values) => NotIn(column, source, values.Select(v => Int32(v)));
		public NotInCondition NotIn(string column, ISource? source, params long[] values) => NotIn(column, source, values.Select(v => Int64(v)));
		public NotInCondition NotIn(string column, ISource? source, params float[] values) => NotIn(column, source, values.Select(v => Float(v)));
		public NotInCondition NotIn(string column, ISource? source, params double[] values) => NotIn(column, source, values.Select(v => Double(v)));
		public NotInCondition NotIn(string column, ISource? source, params decimal[] values) => NotIn(column, source, values.Select(v => Decimal(v)));
		public NotInCondition NotIn(string column, ISource? source, params DateTime[] values) => NotIn(column, source, values.Select(v => DateTime(v)));
		public NotInCondition NotIn(string column, ISource? source, string? format, params DateTime[] values) => NotIn(column, source, values.Select(v => DateTime(v, format)));
		public NotInCondition NotIn(string column, ISource? source, params string[] values) => NotIn(column, source, values.Select(v => String(v)));
		public NotInCondition NotIn(string column, ISource? source, params IExpression[] values) => NotIn(column, source, values);
		public NotInCondition NotIn(string column, ISource? source, IEnumerable<sbyte> values) => NotIn(column, source, values.Select(v => Int8(v)));
		public NotInCondition NotIn(string column, ISource? source, IEnumerable<short> values) => NotIn(column, source, values.Select(v => Int16(v)));
		public NotInCondition NotIn(string column, ISource? source, IEnumerable<int> values) => NotIn(column, source, values.Select(v => Int32(v)));
		public NotInCondition NotIn(string column, ISource? source, IEnumerable<long> values) => NotIn(column, source, values.Select(v => Int64(v)));
		public NotInCondition NotIn(string column, ISource? source, IEnumerable<float> values) => NotIn(column, source, values.Select(v => Float(v)));
		public NotInCondition NotIn(string column, ISource? source, IEnumerable<double> values) => NotIn(column, source, values.Select(v => Double(v)));
		public NotInCondition NotIn(string column, ISource? source, IEnumerable<decimal> values) => NotIn(column, source, values.Select(v => Decimal(v)));
		public NotInCondition NotIn(string column, ISource? source, IEnumerable<DateTime> values, string? format = null) => NotIn(column, source, values.Select(v => DateTime(v, format)));
		public NotInCondition NotIn(string column, ISource? source, IEnumerable<string> values) => NotIn(column, source, values.Select(v => String(v)));
		public NotInCondition NotIn(string column, ISource? source, Action<ExpressionBuilder> valuesFunction) => NotIn(column, source, Expressions(valuesFunction));
        public NotInCondition NotIn(string column, ISource? source, IEnumerable<IExpression> values) => NotIn(Column(column, source), values);

        public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, params sbyte[] values) => NotIn(expressionFunction, values.Select(v => Int8(v)));
        public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, params short[] values) => NotIn(expressionFunction, values.Select(v => Int16(v)));
        public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, params int[] values) => NotIn(expressionFunction, values.Select(v => Int32(v)));
        public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, params long[] values) => NotIn(expressionFunction, values.Select(v => Int64(v)));
        public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, params float[] values) => NotIn(expressionFunction, values.Select(v => Float(v)));
        public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, params double[] values) => NotIn(expressionFunction, values.Select(v => Double(v)));
        public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, params decimal[] values) => NotIn(expressionFunction, values.Select(v => Decimal(v)));
        public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, params DateTime[] values) => NotIn(expressionFunction, values.Select(v => DateTime(v)));
        public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, string format, params DateTime[] values) => NotIn(expressionFunction, values.Select(v => DateTime(v, format)));
        public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, params string[] values) => NotIn(expressionFunction, values.Select(v => String(v)));
        public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, params IExpression[] values) => NotIn(expressionFunction, values);
        public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, IEnumerable<sbyte> values) => NotIn(expressionFunction, values.Select(v => Int8(v)));
        public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, IEnumerable<short> values) => NotIn(expressionFunction, values.Select(v => Int16(v)));
        public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, IEnumerable<int> values) => NotIn(expressionFunction, values.Select(v => Int32(v)));
        public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, IEnumerable<long> values) => NotIn(expressionFunction, values.Select(v => Int64(v)));
        public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, IEnumerable<float> values) => NotIn(expressionFunction, values.Select(v => Float(v)));
        public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, IEnumerable<double> values) => NotIn(expressionFunction, values.Select(v => Double(v)));
        public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, IEnumerable<decimal> values) => NotIn(expressionFunction, values.Select(v => Decimal(v)));
        public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, IEnumerable<DateTime> values, string? format = null) => NotIn(expressionFunction, values.Select(v => DateTime(v, format)));
        public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, IEnumerable<string> values) => NotIn(expressionFunction, values.Select(v => String(v)));
        public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, Action<ExpressionBuilder> valuesFunction) => NotIn(expressionFunction, Expressions(valuesFunction));
        public NotInCondition NotIn(Func<ExpressionFactory, IExpression> expressionFunction, IEnumerable<IExpression> values) => NotIn(Expression(expressionFunction), values);

        public NotInCondition NotIn(IExpression expression, params sbyte[] values) => NotIn(expression, values.Select(v => Int8(v)));
        public NotInCondition NotIn(IExpression expression, params short[] values) => NotIn(expression, values.Select(v => Int16(v)));
        public NotInCondition NotIn(IExpression expression, params int[] values) => NotIn(expression, values.Select(v => Int32(v)));
        public NotInCondition NotIn(IExpression expression, params long[] values) => NotIn(expression, values.Select(v => Int64(v)));
        public NotInCondition NotIn(IExpression expression, params float[] values) => NotIn(expression, values.Select(v => Float(v)));
        public NotInCondition NotIn(IExpression expression, params double[] values) => NotIn(expression, values.Select(v => Double(v)));
        public NotInCondition NotIn(IExpression expression, params decimal[] values) => NotIn(expression, values.Select(v => Decimal(v)));
        public NotInCondition NotIn(IExpression expression, params DateTime[] values) => NotIn(expression, values.Select(v => DateTime(v)));
        public NotInCondition NotIn(IExpression expression, string format, params DateTime[] values) => NotIn(expression, values.Select(v => DateTime(v, format)));
        public NotInCondition NotIn(IExpression expression, params string[] values) => NotIn(expression, values.Select(v => String(v)));
        public NotInCondition NotIn(IExpression expression, params IExpression[] values) => NotIn(expression, values);
        public NotInCondition NotIn(IExpression expression, IEnumerable<sbyte> values) => NotIn(expression, values.Select(v => Int8(v)));
        public NotInCondition NotIn(IExpression expression, IEnumerable<short> values) => NotIn(expression, values.Select(v => Int16(v)));
        public NotInCondition NotIn(IExpression expression, IEnumerable<int> values) => NotIn(expression, values.Select(v => Int32(v)));
        public NotInCondition NotIn(IExpression expression, IEnumerable<long> values) => NotIn(expression, values.Select(v => Int64(v)));
        public NotInCondition NotIn(IExpression expression, IEnumerable<float> values) => NotIn(expression, values.Select(v => Float(v)));
        public NotInCondition NotIn(IExpression expression, IEnumerable<double> values) => NotIn(expression, values.Select(v => Double(v)));
        public NotInCondition NotIn(IExpression expression, IEnumerable<decimal> values) => NotIn(expression, values.Select(v => Decimal(v)));
        public NotInCondition NotIn(IExpression expression, IEnumerable<DateTime> values, string? format = null) => NotIn(expression, values.Select(v => DateTime(v, format)));
        public NotInCondition NotIn(IExpression expression, IEnumerable<string> values) => NotIn(expression, values.Select(v => String(v)));
        public NotInCondition NotIn(IExpression expression, Action<ExpressionBuilder> valuesFunction) => NotIn(expression, Expressions(valuesFunction));
        public virtual NotInCondition NotIn(IExpression expression, IEnumerable<IExpression> values) => new NotInCondition(expression, values);

        #endregion NotInCondition factory methods

        #region LikeCondition factory methods

		public LikeCondition Like(string column, string pattern) => Like(Column(column), pattern);
		public LikeCondition Like(string column, string? table, string pattern) => Like(Column(column, table, alias: null), pattern);
		public LikeCondition Like(string column, ISource? source, string pattern) => Like(Column(column, source), pattern);
		public LikeCondition Like(Func<ExpressionFactory, IExpression> expressionFunction, string pattern) => Like(Expression(expressionFunction), pattern);
        public virtual LikeCondition Like(IExpression expression, string pattern) => new LikeCondition(expression, pattern);

        #endregion LikeCondition factory methods

        #region NotLikeCondition factory methods

		public NotLikeCondition NotLike(string column, string pattern) => NotLike(Column(column), pattern);
		public NotLikeCondition NotLike(string column, string? table, string pattern) => NotLike(Column(column, table, alias: null), pattern);
		public NotLikeCondition NotLike(string column, ISource? source, string pattern) => NotLike(Column(column, source), pattern);
		public NotLikeCondition NotLike(Func<ExpressionFactory, IExpression> expressionFunction, string pattern) => NotLike(Expression(expressionFunction), pattern);
        public virtual NotLikeCondition NotLike(IExpression expression, string pattern) => new NotLikeCondition(expression, pattern);

        #endregion NotLikeCondition factory methods

        #region BetweenCondition factory methods

		public BetweenCondition Between(string column, sbyte lowBound, sbyte hightBound) => Between(column, Int8(lowBound), Int8(hightBound));
		public BetweenCondition Between(string column, short lowBound, short hightBound) => Between(column, Int16(lowBound), Int16(hightBound));
		public BetweenCondition Between(string column, int lowBound, int hightBound) => Between(column, Int32(lowBound), Int32(hightBound));
		public BetweenCondition Between(string column, long lowBound, long hightBound) => Between(column, Int64(lowBound), Int64(hightBound));
		public BetweenCondition Between(string column, float lowBound, float hightBound) => Between(column, Float(lowBound), Float(hightBound));
		public BetweenCondition Between(string column, double lowBound, double hightBound) => Between(column, Double(lowBound), Double(hightBound));
		public BetweenCondition Between(string column, decimal lowBound, decimal hightBound) => Between(column, Decimal(lowBound), Decimal(hightBound));
		public BetweenCondition Between(string column, DateTime lowBound, DateTime hightBound, string? format = null) => Between(column, DateTime(lowBound, format), DateTime(hightBound, format));
		public BetweenCondition Between(string column, string lowBound, string hightBound) => Between(column, String(lowBound), String(hightBound));
		public BetweenCondition Between(string column, Func<ExpressionFactory, IExpression> lowBoundFunction, Func<ExpressionFactory, IExpression> hightBoundFunction) => Between(column, Expression(lowBoundFunction), Expression(hightBoundFunction));
        public BetweenCondition Between(string column, IExpression lowBound, IExpression hightBound) => Between(Column(column), lowBound, hightBound);

        public BetweenCondition Between(string column, string? table, sbyte lowBound, sbyte hightBound) => Between(column, table, Int8(lowBound), Int8(hightBound));
        public BetweenCondition Between(string column, string? table, short lowBound, short hightBound) => Between(column, table, Int16(lowBound), Int16(hightBound));
        public BetweenCondition Between(string column, string? table, int lowBound, int hightBound) => Between(column, table, Int32(lowBound), Int32(hightBound));
        public BetweenCondition Between(string column, string? table, long lowBound, long hightBound) => Between(column, table, Int64(lowBound), Int64(hightBound));
        public BetweenCondition Between(string column, string? table, float lowBound, float hightBound) => Between(column, table, Float(lowBound), Float(hightBound));
        public BetweenCondition Between(string column, string? table, double lowBound, double hightBound) => Between(column, table, Double(lowBound), Double(hightBound));
        public BetweenCondition Between(string column, string? table, decimal lowBound, decimal hightBound) => Between(column, table, Decimal(lowBound), Decimal(hightBound));
        public BetweenCondition Between(string column, string? table, DateTime lowBound, DateTime hightBound, string? format = null) => Between(column, table, DateTime(lowBound, format), DateTime(hightBound, format));
        public BetweenCondition Between(string column, string? table, string lowBound, string hightBound) => Between(column, table, String(lowBound), String(hightBound));
        public BetweenCondition Between(string column, string? table, Func<ExpressionFactory, IExpression> lowBoundFunction, Func<ExpressionFactory, IExpression> hightBoundFunction) => Between(column, table, Expression(lowBoundFunction), Expression(hightBoundFunction));
        public BetweenCondition Between(string column, string? table, IExpression lowBound, IExpression hightBound) => Between(Column(column, table, alias: null), lowBound, hightBound);

        public BetweenCondition Between(string column, ISource? source, sbyte lowBound, sbyte hightBound) => Between(column, source, Int8(lowBound), Int8(hightBound));
		public BetweenCondition Between(string column, ISource? source, short lowBound, short hightBound) => Between(column, source, Int16(lowBound), Int16(hightBound));
		public BetweenCondition Between(string column, ISource? source, int lowBound, int hightBound) => Between(column, source, Int32(lowBound), Int32(hightBound));
		public BetweenCondition Between(string column, ISource? source, long lowBound, long hightBound) => Between(column, source, Int64(lowBound), Int64(hightBound));
		public BetweenCondition Between(string column, ISource? source, float lowBound, float hightBound) => Between(column, source, Float(lowBound), Float(hightBound));
		public BetweenCondition Between(string column, ISource? source, double lowBound, double hightBound) => Between(column, source, Double(lowBound), Double(hightBound));
		public BetweenCondition Between(string column, ISource? source, decimal lowBound, decimal hightBound) => Between(column, source, Decimal(lowBound), Decimal(hightBound));
		public BetweenCondition Between(string column, ISource? source, DateTime lowBound, DateTime hightBound, string? format = null) => Between(column, source, DateTime(lowBound, format), DateTime(hightBound, format));
		public BetweenCondition Between(string column, ISource? source, string lowBound, string hightBound) => Between(column, source, String(lowBound), String(hightBound));
		public BetweenCondition Between(string column, ISource? source, Func<ExpressionFactory, IExpression> lowBoundFunction, Func<ExpressionFactory, IExpression> hightBoundFunction) => Between(column, source, Expression(lowBoundFunction), Expression(hightBoundFunction));
        public BetweenCondition Between(string column, ISource? source, IExpression lowBound, IExpression hightBound) => Between(Column(column, source), lowBound, hightBound);

        public BetweenCondition Between(Func<ExpressionFactory, IExpression> expressionFunction, sbyte lowBound, sbyte hightBound) => Between(expressionFunction, Int8(lowBound), Int8(hightBound));
        public BetweenCondition Between(Func<ExpressionFactory, IExpression> expressionFunction, short lowBound, short hightBound) => Between(expressionFunction, Int16(lowBound), Int16(hightBound));
        public BetweenCondition Between(Func<ExpressionFactory, IExpression> expressionFunction, int lowBound, int hightBound) => Between(expressionFunction, Int32(lowBound), Int32(hightBound));
        public BetweenCondition Between(Func<ExpressionFactory, IExpression> expressionFunction, long lowBound, long hightBound) => Between(expressionFunction, Int64(lowBound), Int64(hightBound));
        public BetweenCondition Between(Func<ExpressionFactory, IExpression> expressionFunction, float lowBound, float hightBound) => Between(expressionFunction, Float(lowBound), Float(hightBound));
        public BetweenCondition Between(Func<ExpressionFactory, IExpression> expressionFunction, double lowBound, double hightBound) => Between(expressionFunction, Double(lowBound), Double(hightBound));
        public BetweenCondition Between(Func<ExpressionFactory, IExpression> expressionFunction, decimal lowBound, decimal hightBound) => Between(expressionFunction, Decimal(lowBound), Decimal(hightBound));
        public BetweenCondition Between(Func<ExpressionFactory, IExpression> expressionFunction, DateTime lowBound, DateTime hightBound, string? format = null) => Between(expressionFunction, DateTime(lowBound, format), DateTime(hightBound, format));
        public BetweenCondition Between(Func<ExpressionFactory, IExpression> expressionFunction, string lowBound, string hightBound) => Between(expressionFunction, String(lowBound), String(hightBound));
        public BetweenCondition Between(Func<ExpressionFactory, IExpression> expressionFunction, Func<ExpressionFactory, IExpression> lowBoundFunction, Func<ExpressionFactory, IExpression> hightBoundFunction) => Between(expressionFunction, Expression(lowBoundFunction), Expression(hightBoundFunction));
        public BetweenCondition Between(Func<ExpressionFactory, IExpression> expressionFunction, IExpression lowBound, IExpression hightBound) => Between(Expression(expressionFunction), lowBound, hightBound);

        public BetweenCondition Between(IExpression expression, sbyte lowBound, sbyte hightBound) => Between(expression, Int8(lowBound), Int8(hightBound));
        public BetweenCondition Between(IExpression expression, short lowBound, short hightBound) => Between(expression, Int16(lowBound), Int16(hightBound));
        public BetweenCondition Between(IExpression expression, int lowBound, int hightBound) => Between(expression, Int32(lowBound), Int32(hightBound));
        public BetweenCondition Between(IExpression expression, long lowBound, long hightBound) => Between(expression, Int64(lowBound), Int64(hightBound));
        public BetweenCondition Between(IExpression expression, float lowBound, float hightBound) => Between(expression, Float(lowBound), Float(hightBound));
        public BetweenCondition Between(IExpression expression, double lowBound, double hightBound) => Between(expression, Double(lowBound), Double(hightBound));
        public BetweenCondition Between(IExpression expression, decimal lowBound, decimal hightBound) => Between(expression, Decimal(lowBound), Decimal(hightBound));
        public BetweenCondition Between(IExpression expression, DateTime lowBound, DateTime hightBound, string? format = null) => Between(expression, DateTime(lowBound, format), DateTime(hightBound, format));
        public BetweenCondition Between(IExpression expression, string lowBound, string hightBound) => Between(expression, String(lowBound), String(hightBound));
        public BetweenCondition Between(IExpression expression, Func<ExpressionFactory, IExpression> lowBoundFunction, Func<ExpressionFactory, IExpression> hightBoundFunction) => Between(expression, Expression(lowBoundFunction), Expression(hightBoundFunction));
        public virtual BetweenCondition Between(IExpression expression, IExpression lowBound, IExpression hightBound) => new BetweenCondition(expression, lowBound, hightBound);

        #endregion BetweenCondition factory methods

        #region ICondition factory methods

        public ICondition Condition(Action<ConditionBuilder> conditionFunction)
		{
			Guard.ThrowIfNull(conditionFunction, nameof(conditionFunction));

			ConditionBuilder conditionBuilder = new ConditionBuilder();
			conditionFunction.Invoke(conditionBuilder);

			ICondition condition = conditionBuilder.Build();

			return condition;
		}

		public ICondition Condition(ISource source1, ISource source2, Action<ConditionBuilder, ISource, ISource> conditionFunction)
		{
			Guard.ThrowIfNull(source1, nameof(source1));
			Guard.ThrowIfNull(source2, nameof(source2));
			Guard.ThrowIfNull(conditionFunction, nameof(conditionFunction));

			ConditionBuilder conditionBuilder = new ConditionBuilder();
			conditionFunction.Invoke(conditionBuilder, source1, source2);

			ICondition condition = conditionBuilder.Build();

			return condition;
		}

		#endregion ICondition factory methods

		#endregion Conditions factory methods

		#region Expressions factory methods

		#region PlusEpression factory methods

		public PlusExpression Plus(string leftColumn, string rightColumn) => Plus(Column(leftColumn), Column(rightColumn));
		public PlusExpression Plus(string leftColumn, ISource? leftSource, string rightColumn, ISource? rightSource) => Plus(Column(leftColumn, leftSource), Column(rightColumn, rightSource));
		public PlusExpression Plus(IExpression leftExpression, IExpression rightExpression) => Plus(leftExpression, rightExpression);
		public PlusExpression Plus(Action<ExpressionBuilder> expressionsFunction) => Plus(Expressions(expressionsFunction));
        public PlusExpression Plus(params IExpression[] expressions) => Plus((IEnumerable<IExpression>)expressions);
        public virtual PlusExpression Plus(IEnumerable<IExpression> expressions) => new PlusExpression(expressions);

		#endregion PlusExpression factory methods

		#region MinusExpression factory methods

		public MinusExpression Minus(string leftColumn, string rightColumn) => Minus(Column(leftColumn), Column(rightColumn));
		public MinusExpression Minus(string leftColumn, ISource? leftSource, string rightColumn, ISource? rightSource) => Minus(Column(leftColumn, leftSource), Column(rightColumn, rightSource));
		public MinusExpression Minus(IExpression leftExpression, IExpression rightExpression) => Minus(leftExpression, rightExpression);
		public MinusExpression Minus(Action<ExpressionBuilder> expressionsFunction) => Minus(Expressions(expressionsFunction));
        public MinusExpression Minus(params IExpression[] expressions) => Minus((IEnumerable<IExpression>)expressions);
        public virtual MinusExpression Minus(IEnumerable<IExpression> expressions) => new MinusExpression(expressions);

		#endregion MinusExpression factory methods

		#region MultiplyExpression factory methods

		public MultiplyExpression Multiply(string leftColumn, string rightColumn) => Multiply(Column(leftColumn), Column(rightColumn));
		public MultiplyExpression Multiply(string leftColumn, ISource? leftSource, string rightColumn, ISource rightSource) => Multiply(Column(leftColumn, leftSource), Column(rightColumn, rightSource));
		public MultiplyExpression Multiply(IExpression leftExpression, IExpression rightExpression) => Multiply(leftExpression, rightExpression);
		public MultiplyExpression Multiply(Action<ExpressionBuilder> expressionsFunction) => Multiply(Expressions(expressionsFunction));
        public MultiplyExpression Multiply(params IExpression[] expressions) => Multiply((IEnumerable<IExpression>)expressions);
        public virtual MultiplyExpression Multiply(IEnumerable<IExpression> expressions) => new MultiplyExpression(expressions);

		#endregion MultiplyExpression factory methods

		#region DivideExpression factory methods

		public DivideExpression Divide(string leftColumn, string rightColumn) => Divide(Column(leftColumn), Column(rightColumn));
		public DivideExpression Divide(string leftColumn, ISource? leftSource, string rightColumn, ISource? rightSource) => Divide(Column(leftColumn, leftSource), Column(rightColumn, rightSource));
		public DivideExpression Divide(IExpression leftExpression, IExpression rightExpression) => Divide(leftExpression, rightExpression);
		public DivideExpression Divide(Action<ExpressionBuilder> expressionsFunction) => Divide(Expressions(expressionsFunction));
        public DivideExpression Divide(params IExpression[] expressions) => Divide((IEnumerable<IExpression>)expressions);
        public virtual DivideExpression Divide(IEnumerable<IExpression> expressions) => new DivideExpression(expressions);

		#endregion DivideExpression factory methods

		#region Expression factory methods

		public virtual IExpression Expression(Func<ExpressionFactory, IExpression> expressionFunction) => expressionFunction.Invoke(this);
		public virtual List<IExpression> Expressions(Action<ExpressionBuilder> expressionsFunction)
		{
			Guard.ThrowIfNull(expressionsFunction, nameof(expressionsFunction));

			ExpressionBuilder expressionBuilder = new ExpressionBuilder();
			expressionsFunction.Invoke(expressionBuilder);

			return expressionBuilder.Build();
		}

		#endregion Expression factory methods

		#region GeneralCaseExpression factory methods

		public virtual GeneralCaseExpression Case(Action<GeneralCaseBuilder> generalCaseFunction)
		{
			GeneralCaseBuilder generalCaseBuilder = new GeneralCaseBuilder();
			generalCaseFunction.Invoke(generalCaseBuilder);

			return generalCaseBuilder.Build();
		}

		#endregion GeneralCaseExpression factory methods

		#region SimpleCaseExpression factory methods

		public SimpleCaseExpression Case(string column, Action<SimpleCaseBuilder> simpleCaseFunction) => Case(new SourceColumn(column), simpleCaseFunction);
		public SimpleCaseExpression Case(string column, ISource? source, Action<SimpleCaseBuilder> simpleCaseFunction) => Case(new SourceColumn(column, source), simpleCaseFunction);
		public SimpleCaseExpression Case(Func<ExpressionFactory, IExpression> expressionFunction, Action<SimpleCaseBuilder> simpleCaseFunction) => Case(Expression(expressionFunction), simpleCaseFunction);
        public virtual SimpleCaseExpression Case(IExpression expression, Action<SimpleCaseBuilder> simpleCaseFunction)
		{
			SimpleCaseBuilder simpleCaseBuilder = new SimpleCaseBuilder(expression);
			simpleCaseFunction.Invoke(simpleCaseBuilder);

			return simpleCaseBuilder.Build();
		}

		#endregion SimpleCaseExpression factory methods

		#endregion Expressions factory methods

		#region Functions factory methods

		#region CastFunction factory methods

		public CastFunction Cast(string column, string type) => Cast(Column(column), type);
		public CastFunction Cast(string column, ISource source, string type) => Cast(Column(column, source), type);
		public CastFunction Cast(Func<ExpressionFactory, IExpression> expressionFunction, string type) => Cast(Expression(expressionFunction), type);
		public virtual CastFunction Cast(IExpression expression, string type) => new CastFunction(expression, type);

		#endregion CastFunction factory methods

		#region CoalesceFunction factory methods

		public CoalesceFunction Coalesce(string column, sbyte value) => new CoalesceFunction(new SourceColumn(column), new Int8Value(value));
		public CoalesceFunction Coalesce(string column, short value) => new CoalesceFunction(new SourceColumn(column), new Int16Value(value));
		public CoalesceFunction Coalesce(string column, int value) => new CoalesceFunction(new SourceColumn(column), new Int32Value(value));
		public CoalesceFunction Coalesce(string column, long value) => new CoalesceFunction(new SourceColumn(column), new Int64Value(value));
		public CoalesceFunction Coalesce(string column, float value) => new CoalesceFunction(new SourceColumn(column), new FloatValue(value));
		public CoalesceFunction Coalesce(string column, double value) => new CoalesceFunction(new SourceColumn(column), new DoubleValue(value));
		public CoalesceFunction Coalesce(string column, DateTime value, string? format = null) => new CoalesceFunction(new SourceColumn(column), new DateTimeValue(value, format));
		public CoalesceFunction Coalesce(string column, string value) => new CoalesceFunction(new SourceColumn(column), new StringValue(value));
		public CoalesceFunction Coalesce(string column, Func<ExpressionFactory, IExpression> valueFunction) => new CoalesceFunction(new SourceColumn(column), Expression(valueFunction));
		public CoalesceFunction Coalesce(string column, IExpression value) => new CoalesceFunction(new SourceColumn(column), value);
		public CoalesceFunction Coalesce(string column1, string column2, ISource source2) => new CoalesceFunction(new SourceColumn(column1), new SourceColumn(column2, source2));

		public CoalesceFunction Coalesce(string column, ISource source, sbyte value) => new CoalesceFunction(new SourceColumn(column, source), new Int8Value(value));
		public CoalesceFunction Coalesce(string column, ISource source, short value) => new CoalesceFunction(new SourceColumn(column, source), new Int16Value(value));
		public CoalesceFunction Coalesce(string column, ISource source, int value) => new CoalesceFunction(new SourceColumn(column, source), new Int32Value(value));
		public CoalesceFunction Coalesce(string column, ISource source, long value) => new CoalesceFunction(new SourceColumn(column, source), new Int64Value(value));
		public CoalesceFunction Coalesce(string column, ISource source, float value) => new CoalesceFunction(new SourceColumn(column, source), new FloatValue(value));
		public CoalesceFunction Coalesce(string column, ISource source, double value) => new CoalesceFunction(new SourceColumn(column, source), new DoubleValue(value));
		public CoalesceFunction Coalesce(string column, ISource source, DateTime value, string? format = null) => new CoalesceFunction(new SourceColumn(column, source), new DateTimeValue(value, format));
		public CoalesceFunction Coalesce(string column, ISource source, string value) => new CoalesceFunction(new SourceColumn(column, source), new StringValue(value));
		public CoalesceFunction Coalesce(string column, ISource source, Func<ExpressionFactory, IExpression> valueFunction) => new CoalesceFunction(new SourceColumn(column, source), Expression(valueFunction));
		public CoalesceFunction Coalesce(string column, ISource source, IExpression value) => new CoalesceFunction(new SourceColumn(column, source), value);
		public CoalesceFunction Coalesce(string column1, ISource source1, string column2, ISource source2) => new CoalesceFunction(new SourceColumn(column1, source1), new SourceColumn(column2, source2));

		public CoalesceFunction Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, sbyte value) => new CoalesceFunction(Expression(expressionFunction), new Int8Value(value));
		public CoalesceFunction Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, short value) => new CoalesceFunction(Expression(expressionFunction), new Int16Value(value));
		public CoalesceFunction Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, int value) => new CoalesceFunction(Expression(expressionFunction), new Int32Value(value));
		public CoalesceFunction Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, long value) => new CoalesceFunction(Expression(expressionFunction), new Int64Value(value));
		public CoalesceFunction Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, float value) => new CoalesceFunction(Expression(expressionFunction), new FloatValue(value));
		public CoalesceFunction Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, double value) => new CoalesceFunction(Expression(expressionFunction), new DoubleValue(value));
		public CoalesceFunction Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, DateTime value, string? format = null) => new CoalesceFunction(Expression(expressionFunction), new DateTimeValue(value, format));
		public CoalesceFunction Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, string value) => new CoalesceFunction(Expression(expressionFunction), new StringValue(value));
		public CoalesceFunction Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, Func<ExpressionFactory, IExpression> valueFunction) => new CoalesceFunction(Expression(expressionFunction), Expression(valueFunction));
		public CoalesceFunction Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, IExpression value) => new CoalesceFunction(Expression(expressionFunction), value);
		public CoalesceFunction Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, string column2, ISource source2) => new CoalesceFunction(Expression(expressionFunction), new SourceColumn(column2, source2));

		public CoalesceFunction Coalesce(IExpression expression, sbyte value) => new CoalesceFunction(expression, new Int8Value(value));
		public CoalesceFunction Coalesce(IExpression expression, short value) => new CoalesceFunction(expression, new Int16Value(value));
		public CoalesceFunction Coalesce(IExpression expression, int value) => new CoalesceFunction(expression, new Int32Value(value));
		public CoalesceFunction Coalesce(IExpression expression, long value) => new CoalesceFunction(expression, new Int64Value(value));
		public CoalesceFunction Coalesce(IExpression expression, float value) => new CoalesceFunction(expression, new FloatValue(value));
		public CoalesceFunction Coalesce(IExpression expression, double value) => new CoalesceFunction(expression, new DoubleValue(value));
		public CoalesceFunction Coalesce(IExpression expression, DateTime value, string? format = null) => new CoalesceFunction(expression, new DateTimeValue(value, format));
		public CoalesceFunction Coalesce(IExpression expression, string value) => new CoalesceFunction(expression, new StringValue(value));
		public CoalesceFunction Coalesce(IExpression expression, Func<ExpressionFactory, IExpression> valueFunction) => new CoalesceFunction(expression, Expression(valueFunction));
		public CoalesceFunction Coalesce(IExpression expression, IExpression value) => new CoalesceFunction(expression, value);
		public CoalesceFunction Coalesce(IExpression expression, string column2, ISource source2) => new CoalesceFunction(expression, new SourceColumn(column2, source2));

		#endregion CoalesceFunction factory methods

		#region ConcatFunction factory methods

		public ConcatFunction Concat(params IExpression[] expressions) => new ConcatFunction(expressions);
		public ConcatFunction Concat(Action<ExpressionBuilder> expressionsFunction) => new ConcatFunction(Expressions(expressionsFunction));
		public ConcatFunction Concat(IEnumerable<IExpression> expressions) => new ConcatFunction(expressions);

		#endregion ConcatFunction factory methods

		#region CountFunction factory methods

		public CountFunction Count(string column) => new CountFunction(new SourceColumn(column));
		public CountFunction Count(string column, ISource source) => new CountFunction(new SourceColumn(column, source));
		public CountFunction Count(Func<ExpressionFactory, IExpression> expressionFunction) => new CountFunction(Expression(expressionFunction));
		public CountFunction Count(IExpression expression) => new CountFunction(expression);

		#endregion CountFunction factory methods

		#region Function factory methods

		public NativeFunction Function(string name) => new NativeFunction(name, parameters: null);
		public NativeFunction Function(string name, params IExpression[] parameters) => new NativeFunction(name, parameters);
		public NativeFunction Function(string name, IEnumerable<IExpression>? parameters) => new NativeFunction(name, parameters);
		public NativeFunction Function(string name, Action<ExpressionBuilder> expressionsFunction) => new NativeFunction(name, Expressions(expressionsFunction));

		#endregion Function factory methods

		#region MaxFunction factory methods

		public MaxFunction Max(string column) => new MaxFunction(new SourceColumn(column));
		public MaxFunction Max(string column, ISource source) => new MaxFunction(new SourceColumn(column, source));
		public MaxFunction Max(Func<ExpressionFactory, IExpression> expressionFunction) => new MaxFunction(Expression(expressionFunction));
		public MaxFunction Max(IExpression expression) => new MaxFunction(expression);

		#endregion MaxFunction factory methods

		#region MinFunction factory methods

		public MinFunction Min(string column) => new MinFunction(new SourceColumn(column));
		public MinFunction Min(string column, ISource source) => new MinFunction(new SourceColumn(column, source));
		public MinFunction Min(Func<ExpressionFactory, IExpression> expressionFunction) => new MinFunction(Column(expressionFunction));
		public MinFunction Min(IExpression expression) => new MinFunction(expression);

		#endregion MinFunction factory methods

		#region NowFunction factory methods

		public NowFunction Now() => new NowFunction();

		#endregion NowFunction factory methods

		#region SumFunction factory methods

		public SumFunction Sum(string column) => new SumFunction(new SourceColumn(column));
		public SumFunction Sum(string column, ISource source) => new SumFunction(new SourceColumn(column, source));
		public SumFunction Sum(Func<ExpressionFactory, IExpression> expressionFunction) => new SumFunction(Expression(expressionFunction));
		public SumFunction Sum(IExpression expression) => new SumFunction(expression);

		#endregion SumFunction factory methods

		#region ExtractFunction factory methods

		public ExtractFunction Extract(string part, string column) => Extract(part, Column(column));
		public ExtractFunction Extract(string part, string column, ISource source) => Extract(part, Column(column, source));
		public ExtractFunction Extract(string part, Func<ExpressionFactory, IExpression> expressionFunction) => Extract(part, Expression(expressionFunction));
		public ExtractFunction Extract(string part, IExpression expression) => new ExtractFunction(part, expression);

        #endregion ExtractFunction factory methods

        #region RoundFunction factory methods

        public RoundFunction Round(string column, int? precision = null) => Round(Column(column), precision);
        public RoundFunction Round(string column, ISource source, int? precision = null) => Round(Column(column, source), precision);
        public RoundFunction Round(Func<ExpressionFactory, IExpression> expressionFunction, int? precision = null) => Round(Expression(expressionFunction), precision);
        public RoundFunction Round(IExpression expression, int? precision = null) => new RoundFunction(expression, precision);

		#endregion RoundFunction factory methods

		#endregion Functions factory methods

		#region OrderBy factory methods

		public List<IOrderBy> OrderBy(Action<OrderByBuilder> orderBiesFunction)
		{
			OrderByBuilder orderByBuilder = new OrderByBuilder();
			orderBiesFunction.Invoke(orderByBuilder);

			return orderByBuilder.Build();
		}

		public OrderBy OrderBy(string column, OrderDirection direction) => new OrderBy(Column(column), direction);
		public OrderBy OrderBy(string column, ISource source, OrderDirection direction) => new OrderBy(Column(column, source), direction);
		public OrderBy OrderBy(IColumn column, OrderDirection direction) => new OrderBy(column, direction);

        #endregion OrderBy factory methods

        #region Parameter factory methods

        public Parameter Parameter(string name) => new Parameter(name);

		#endregion Parameter factory methods

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
