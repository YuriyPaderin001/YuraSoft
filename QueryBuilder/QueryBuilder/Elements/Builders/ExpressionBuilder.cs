using System;
using System.Collections.Generic;

using YuraSoft.QueryBuilder.Interfaces;

namespace YuraSoft.QueryBuilder
{
	public class ExpressionBuilder
	{
		public readonly ExpressionFactory Factory = ExpressionFactory.Instance;

		private readonly List<IExpression> _expressions = new List<IExpression>();

		#region Columns methods

		#region ExpressionColumn methods

		public ExpressionBuilder Column(Func<ExpressionFactory, IColumn> function) => Add(Factory.Column(function));
		public ExpressionBuilder Column(IExpression expression, string? name = null) => Add(Factory.Column(expression, name));
		public ExpressionBuilder Column(Func<ExpressionFactory, IExpression> expressionFunction, string? name = null) => Add(Factory.Column(expressionFunction, name));

		#endregion ExpressionColumn methods

		#region SourceColumn methods

		public ExpressionBuilder Column(string name) => Add(Factory.Column(name));
		public ExpressionBuilder Column(string name, string? alias) => Add(Factory.Column(name, alias));
		public ExpressionBuilder Column(string name, string? alias, string? table) => Add(Factory.Column(name, alias, table));
		public ExpressionBuilder Column(string name, ISource? source) => Add(Factory.Column(name, source));
		public ExpressionBuilder Column(string name, string? alias, ISource? source) => Add(Factory.Column(name, alias, source));

		#endregion SourceColumn methods

		#endregion Columns methods

		#region Conditions methods

		#region AndCondition methods

		public ExpressionBuilder And(params ICondition[] conditions) => Add(Factory.And(conditions));
		public ExpressionBuilder And(IEnumerable<ICondition> conditions) => Add(Factory.And(conditions));
		public ExpressionBuilder And(ConditionBuilder builder) => Add(Factory.And(builder.Conditions));
		public ExpressionBuilder And(Action<ConditionBuilder> buildConditionMethod) => Add(Factory.And(buildConditionMethod));

		#endregion AndCondition methods

		#region OrCondition methods

		public ExpressionBuilder Or(params ICondition[] conditions) => Add(Factory.Or(conditions));
		public ExpressionBuilder Or(IEnumerable<ICondition> conditions) => Add(Factory.Or(conditions));
		public ExpressionBuilder Or(ConditionBuilder builder) => Add(Factory.Or(builder.Conditions));
		public ExpressionBuilder Or(Action<ConditionBuilder> buildConditionMethod) => Add(Factory.Or(buildConditionMethod));

		#endregion OrCondition methods

		#region EqualCondition methods

		public ExpressionBuilder Equal(IExpression expression, sbyte value) => Add(Factory.Equal(expression, value));
		public ExpressionBuilder Equal(IExpression expression, short value) => Add(Factory.Equal(expression, value));
		public ExpressionBuilder Equal(IExpression expression, int value) => Add(Factory.Equal(expression, value));
		public ExpressionBuilder Equal(IExpression expression, long value) => Add(Factory.Equal(expression, value));
		public ExpressionBuilder Equal(IExpression expression, float value) => Add(Factory.Equal(expression, value));
		public ExpressionBuilder Equal(IExpression expression, double value) => Add(Factory.Equal(expression, value));
		public ExpressionBuilder Equal(IExpression expression, decimal value) => Add(Factory.Equal(expression, value));
		public ExpressionBuilder Equal(IExpression expression, DateTime value, string? format = null) => Add(Factory.Equal(expression, value, format));
		public ExpressionBuilder Equal(IExpression expression, string value) => Add(Factory.Equal(expression, value));
		public ExpressionBuilder Equal(IExpression expression1, IExpression expression2) => Add(Factory.Equal(expression1, expression2));
		public ExpressionBuilder Equal(IExpression expression, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Equal(expression, expressionFunction));

		public ExpressionBuilder Equal(string column, sbyte value) => Add(Factory.Equal(column, value));
		public ExpressionBuilder Equal(string column, short value) => Add(Factory.Equal(column, value));
		public ExpressionBuilder Equal(string column, int value) => Add(Factory.Equal(column, value));
		public ExpressionBuilder Equal(string column, long value) => Add(Factory.Equal(column, value));
		public ExpressionBuilder Equal(string column, float value) => Add(Factory.Equal(column, value));
		public ExpressionBuilder Equal(string column, double value) => Add(Factory.Equal(column, value));
		public ExpressionBuilder Equal(string column, decimal value) => Add(Factory.Equal(column, value));
		public ExpressionBuilder Equal(string column, DateTime value, string? format = null) => Add(Factory.Equal(column, value, format));
		public ExpressionBuilder Equal(string column, string value) => Add(Factory.Equal(column, value));
		public ExpressionBuilder Equal(string column, IExpression expression) => Add(Factory.Equal(column, expression));
		public ExpressionBuilder Equal(string column, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Equal(column, expressionFunction));

		public ExpressionBuilder Equal(string column, string table, sbyte value) => Add(Factory.Equal(column, table, value));
		public ExpressionBuilder Equal(string column, string table, short value) => Add(Factory.Equal(column, table, value));
		public ExpressionBuilder Equal(string column, string table, int value) => Add(Factory.Equal(column, table, value));
		public ExpressionBuilder Equal(string column, string table, long value) => Add(Factory.Equal(column, table, value));
		public ExpressionBuilder Equal(string column, string table, float value) => Add(Factory.Equal(column, table, value));
		public ExpressionBuilder Equal(string column, string table, double value) => Add(Factory.Equal(column, table, value));
		public ExpressionBuilder Equal(string column, string table, decimal value) => Add(Factory.Equal(column, table, value));
		public ExpressionBuilder Equal(string column, string table, DateTime value, string? format = null) => Add(Factory.Equal(column, table, value, format));
		public ExpressionBuilder Equal(string column, string table, string value) => Add(Factory.Equal(column, table, value));
		public ExpressionBuilder Equal(string column, string table, IExpression expression) => Add(Factory.Equal(column, table, expression));
		public ExpressionBuilder Equal(string column, string table, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Equal(column, table, expressionFunction));

		public ExpressionBuilder Equal(string column, ISource source, sbyte value) => Add(Factory.Equal(column, source, value));
		public ExpressionBuilder Equal(string column, ISource source, short value) => Add(Factory.Equal(column, source, value));
		public ExpressionBuilder Equal(string column, ISource source, int value) => Add(Factory.Equal(column, source, value));
		public ExpressionBuilder Equal(string column, ISource source, long value) => Add(Factory.Equal(column, source, value));
		public ExpressionBuilder Equal(string column, ISource source, float value) => Add(Factory.Equal(column, source, value));
		public ExpressionBuilder Equal(string column, ISource source, double value) => Add(Factory.Equal(column, source, value));
		public ExpressionBuilder Equal(string column, ISource source, decimal value) => Add(Factory.Equal(column, source, value));
		public ExpressionBuilder Equal(string column, ISource source, DateTime value, string? format = null) => Add(Factory.Equal(column, source, value, format));
		public ExpressionBuilder Equal(string column, ISource source, string value) => Add(Factory.Equal(column, source, value));
		public ExpressionBuilder Equal(string column, ISource source, IExpression expression) => Add(Factory.Equal(column, source, expression));
		public ExpressionBuilder Equal(string column, ISource source, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Equal(column, source, expressionFunction));

		public ExpressionBuilder Equal(string column1, string table1, string column2, string table2) => Add(Factory.Equal(column1, table1, column2, table2));
		public ExpressionBuilder Equal(string column1, string table1, string column2, ISource source2) => Add(Factory.Equal(column1, table1, column2, source2));
		public ExpressionBuilder Equal(string column1, ISource source1, string column2, string table2) => Add(Factory.Equal(column1, source1, column2, table2));
		public ExpressionBuilder Equal(string column1, ISource source1, string column2, ISource source2) => Add(Factory.Equal(column1, source1, column2, source2));
		public ExpressionBuilder Equal(Func<ExpressionFactory, IExpression> expressionFunction1, Func<ExpressionFactory, IExpression> expressionFunction2) => Add(Factory.Equal(expressionFunction1, expressionFunction2));

		#endregion EqualCondition methods

		#region NotEqualCondition methods

		public ExpressionBuilder NotEqual(IExpression expression, sbyte value) => Add(Factory.NotEqual(expression, value));
		public ExpressionBuilder NotEqual(IExpression expression, short value) => Add(Factory.NotEqual(expression, value));
		public ExpressionBuilder NotEqual(IExpression expression, int value) => Add(Factory.NotEqual(expression, value));
		public ExpressionBuilder NotEqual(IExpression expression, long value) => Add(Factory.NotEqual(expression, value));
		public ExpressionBuilder NotEqual(IExpression expression, float value) => Add(Factory.NotEqual(expression, value));
		public ExpressionBuilder NotEqual(IExpression expression, double value) => Add(Factory.NotEqual(expression, value));
		public ExpressionBuilder NotEqual(IExpression expression, decimal value) => Add(Factory.NotEqual(expression, value));
		public ExpressionBuilder NotEqual(IExpression expression, DateTime value, string? format = null) => Add(Factory.NotEqual(expression, value, format));
		public ExpressionBuilder NotEqual(IExpression expression, string value) => Add(Factory.NotEqual(expression, value));
		public ExpressionBuilder NotEqual(IExpression expression1, IExpression expression2) => Add(Factory.NotEqual(expression1, expression2));
		public ExpressionBuilder NotEqual(IExpression expression, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.NotEqual(expression, expressionFunction));

		public ExpressionBuilder NotEqual(string column, sbyte value) => Add(Factory.NotEqual(column, value));
		public ExpressionBuilder NotEqual(string column, short value) => Add(Factory.NotEqual(column, value));
		public ExpressionBuilder NotEqual(string column, int value) => Add(Factory.NotEqual(column, value));
		public ExpressionBuilder NotEqual(string column, long value) => Add(Factory.NotEqual(column, value));
		public ExpressionBuilder NotEqual(string column, float value) => Add(Factory.NotEqual(column, value));
		public ExpressionBuilder NotEqual(string column, double value) => Add(Factory.NotEqual(column, value));
		public ExpressionBuilder NotEqual(string column, decimal value) => Add(Factory.NotEqual(column, value));
		public ExpressionBuilder NotEqual(string column, DateTime value, string? format = null) => Add(Factory.NotEqual(column, value, format));
		public ExpressionBuilder NotEqual(string column, string value) => Add(Factory.NotEqual(column, value));
		public ExpressionBuilder NotEqual(string column, IExpression expression) => Add(Factory.NotEqual(column, expression));
		public ExpressionBuilder NotEqual(string column, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.NotEqual(column, expressionFunction));

		public ExpressionBuilder NotEqual(string column, string table, sbyte value) => Add(Factory.NotEqual(column, table, value));
		public ExpressionBuilder NotEqual(string column, string table, short value) => Add(Factory.NotEqual(column, table, value));
		public ExpressionBuilder NotEqual(string column, string table, int value) => Add(Factory.NotEqual(column, table, value));
		public ExpressionBuilder NotEqual(string column, string table, long value) => Add(Factory.NotEqual(column, table, value));
		public ExpressionBuilder NotEqual(string column, string table, float value) => Add(Factory.NotEqual(column, table, value));
		public ExpressionBuilder NotEqual(string column, string table, double value) => Add(Factory.NotEqual(column, table, value));
		public ExpressionBuilder NotEqual(string column, string table, decimal value) => Add(Factory.NotEqual(column, table, value));
		public ExpressionBuilder NotEqual(string column, string table, DateTime value, string? format = null) => Add(Factory.NotEqual(column, table, value, format));
		public ExpressionBuilder NotEqual(string column, string table, string value) => Add(Factory.NotEqual(column, table, value));
		public ExpressionBuilder NotEqual(string column, string table, IExpression expression) => Add(Factory.NotEqual(column, table, expression));
		public ExpressionBuilder NotEqual(string column, string table, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.NotEqual(column, table, expressionFunction));

		public ExpressionBuilder NotEqual(string column, ISource source, sbyte value) => Add(Factory.NotEqual(column, source, value));
		public ExpressionBuilder NotEqual(string column, ISource source, short value) => Add(Factory.NotEqual(column, source, value));
		public ExpressionBuilder NotEqual(string column, ISource source, int value) => Add(Factory.NotEqual(column, source, value));
		public ExpressionBuilder NotEqual(string column, ISource source, long value) => Add(Factory.NotEqual(column, source, value));
		public ExpressionBuilder NotEqual(string column, ISource source, float value) => Add(Factory.NotEqual(column, source, value));
		public ExpressionBuilder NotEqual(string column, ISource source, double value) => Add(Factory.NotEqual(column, source, value));
		public ExpressionBuilder NotEqual(string column, ISource source, decimal value) => Add(Factory.NotEqual(column, source, value));
		public ExpressionBuilder NotEqual(string column, ISource source, DateTime value, string? format = null) => Add(Factory.NotEqual(column, source, value, format));
		public ExpressionBuilder NotEqual(string column, ISource source, string value) => Add(Factory.NotEqual(column, source, value));
		public ExpressionBuilder NotEqual(string column, ISource source, IExpression expression) => Add(Factory.NotEqual(column, source, expression));
		public ExpressionBuilder NotEqual(string column, ISource source, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.NotEqual(column, source, expressionFunction));

		public ExpressionBuilder NotEqual(string column1, string table1, string column2, string table2) => Add(Factory.NotEqual(column1, table1, column2, table2));
		public ExpressionBuilder NotEqual(string column1, string table1, string column2, ISource source2) => Add(Factory.NotEqual(column1, table1, column2, source2));
		public ExpressionBuilder NotEqual(string column1, ISource source1, string column2, string table2) => Add(Factory.NotEqual(column1, source1, column2, table2));
		public ExpressionBuilder NotEqual(string column1, ISource source1, string column2, ISource source2) => Add(Factory.NotEqual(column1, source1, column2, source2));
		public ExpressionBuilder NotEqual(Func<ExpressionFactory, IExpression> expressionFunction1, Func<ExpressionFactory, IExpression> expressionFunction2) => Add(Factory.NotEqual(expressionFunction1, expressionFunction2));

		#endregion NotEqualCondition methods

		#region ExistsCondition methods

		public ExpressionBuilder Exists(string column, Select select) => Add(Factory.Exists(column, select));
		public ExpressionBuilder Exists(string column, string table, Select select) => Add(Factory.Exists(column, table, select));
		public ExpressionBuilder Exists(string column, ISource source, Select select) => Add(Factory.Exists(column, source, select));
		public ExpressionBuilder Exists(IExpression expression, Select select) => Add(Factory.Exists(expression, select));
		public ExpressionBuilder Exists(Func<ExpressionFactory, IExpression> expressionFunction, Select select) => Add(Factory.Exists(expressionFunction, select));

		#endregion ExistsCondition methods

		#region NotExistsCondition methods

		public ExpressionBuilder NotExists(string column, Select select) => Add(Factory.NotExists(column, select));
		public ExpressionBuilder NotExists(string column, string table, Select select) => Add(Factory.NotExists(column, table, select));
		public ExpressionBuilder NotExists(string column, ISource source, Select select) => Add(Factory.NotExists(column, source, select));
		public ExpressionBuilder NotExists(IExpression expression, Select select) => Add(Factory.NotExists(expression, select));
		public ExpressionBuilder NotExists(Func<ExpressionFactory, IExpression> expressionFunction, Select select) => Add(Factory.Exists(expressionFunction, select));

		#endregion NotExistsCondition methods

		#region GreaterCondition methods

		public ExpressionBuilder Greater(IExpression expression, sbyte value) => Add(Factory.Greater(expression, value));
		public ExpressionBuilder Greater(IExpression expression, short value) => Add(Factory.Greater(expression, value));
		public ExpressionBuilder Greater(IExpression expression, int value) => Add(Factory.Greater(expression, value));
		public ExpressionBuilder Greater(IExpression expression, long value) => Add(Factory.Greater(expression, value));
		public ExpressionBuilder Greater(IExpression expression, float value) => Add(Factory.Greater(expression, value));
		public ExpressionBuilder Greater(IExpression expression, double value) => Add(Factory.Greater(expression, value));
		public ExpressionBuilder Greater(IExpression expression, decimal value) => Add(Factory.Greater(expression, value));
		public ExpressionBuilder Greater(IExpression expression, DateTime value, string? format = null) => Add(Factory.Greater(expression, value, format));
		public ExpressionBuilder Greater(IExpression expression, string value) => Add(Factory.Greater(expression, value));
		public ExpressionBuilder Greater(IExpression expression1, IExpression expression2) => Add(Factory.Greater(expression1, expression2));
		public ExpressionBuilder Greater(IExpression expression, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Greater(expression, expressionFunction));

		public ExpressionBuilder Greater(string column, sbyte value) => Add(Factory.Greater(column, value));
		public ExpressionBuilder Greater(string column, short value) => Add(Factory.Greater(column, value));
		public ExpressionBuilder Greater(string column, int value) => Add(Factory.Greater(column, value));
		public ExpressionBuilder Greater(string column, long value) => Add(Factory.Greater(column, value));
		public ExpressionBuilder Greater(string column, float value) => Add(Factory.Greater(column, value));
		public ExpressionBuilder Greater(string column, double value) => Add(Factory.Greater(column, value));
		public ExpressionBuilder Greater(string column, decimal value) => Add(Factory.Greater(column, value));
		public ExpressionBuilder Greater(string column, DateTime value, string? format = null) => Add(Factory.Greater(column, value, format));
		public ExpressionBuilder Greater(string column, string value) => Add(Factory.Greater(column, value));
		public ExpressionBuilder Greater(string column, IExpression expression) => Add(Factory.Greater(column, expression));
		public ExpressionBuilder Greater(string column, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Greater(column, expressionFunction));

		public ExpressionBuilder Greater(string column, string table, sbyte value) => Add(Factory.Greater(column, table, value));
		public ExpressionBuilder Greater(string column, string table, short value) => Add(Factory.Greater(column, table, value));
		public ExpressionBuilder Greater(string column, string table, int value) => Add(Factory.Greater(column, table, value));
		public ExpressionBuilder Greater(string column, string table, long value) => Add(Factory.Greater(column, table, value));
		public ExpressionBuilder Greater(string column, string table, float value) => Add(Factory.Greater(column, table, value));
		public ExpressionBuilder Greater(string column, string table, double value) => Add(Factory.Greater(column, table, value));
		public ExpressionBuilder Greater(string column, string table, decimal value) => Add(Factory.Greater(column, table, value));
		public ExpressionBuilder Greater(string column, string table, DateTime value, string? format = null) => Add(Factory.Greater(column, table, value, format));
		public ExpressionBuilder Greater(string column, string table, string value) => Add(Factory.Greater(column, table, value));
		public ExpressionBuilder Greater(string column, string table, IExpression expression) => Add(Factory.Greater(column, table, expression));
		public ExpressionBuilder Greater(string column, string table, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Greater(column, table, expressionFunction));

		public ExpressionBuilder Greater(string column, ISource source, sbyte value) => Add(Factory.Greater(column, source, value));
		public ExpressionBuilder Greater(string column, ISource source, short value) => Add(Factory.Greater(column, source, value));
		public ExpressionBuilder Greater(string column, ISource source, int value) => Add(Factory.Greater(column, source, value));
		public ExpressionBuilder Greater(string column, ISource source, long value) => Add(Factory.Greater(column, source, value));
		public ExpressionBuilder Greater(string column, ISource source, float value) => Add(Factory.Greater(column, source, value));
		public ExpressionBuilder Greater(string column, ISource source, double value) => Add(Factory.Greater(column, source, value));
		public ExpressionBuilder Greater(string column, ISource source, decimal value) => Add(Factory.Greater(column, source, value));
		public ExpressionBuilder Greater(string column, ISource source, DateTime value, string? format = null) => Add(Factory.Greater(column, source, value, format));
		public ExpressionBuilder Greater(string column, ISource source, string value) => Add(Factory.Greater(column, source, value));
		public ExpressionBuilder Greater(string column, ISource source, IExpression expression) => Add(Factory.Greater(column, source, expression));
		public ExpressionBuilder Greater(string column, ISource source, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Greater(column, source, expressionFunction));

		public ExpressionBuilder Greater(string column1, string table1, string column2, string table2) => Add(Factory.Greater(column1, table1, column2, table2));
		public ExpressionBuilder Greater(string column1, string table1, string column2, ISource source2) => Add(Factory.Greater(column1, table1, column2, source2));
		public ExpressionBuilder Greater(string column1, ISource source1, string column2, string table2) => Add(Factory.Greater(column1, source1, column2, table2));
		public ExpressionBuilder Greater(string column1, ISource source1, string column2, ISource source2) => Add(Factory.Greater(column1, source1, column2, source2));
		public ExpressionBuilder Greater(Func<ExpressionFactory, IExpression> expressionFunction1, Func<ExpressionFactory, IExpression> expressionFunction2) => Add(Factory.Greater(expressionFunction1, expressionFunction2));

		#endregion GreaterCondition methods

		#region GreaterOrEqualCondition methods

		public ExpressionBuilder GreaterOrEqual(IExpression expression, sbyte value) => Add(Factory.GreaterOrEqual(expression, value));
		public ExpressionBuilder GreaterOrEqual(IExpression expression, short value) => Add(Factory.GreaterOrEqual(expression, value));
		public ExpressionBuilder GreaterOrEqual(IExpression expression, int value) => Add(Factory.GreaterOrEqual(expression, value));
		public ExpressionBuilder GreaterOrEqual(IExpression expression, long value) => Add(Factory.GreaterOrEqual(expression, value));
		public ExpressionBuilder GreaterOrEqual(IExpression expression, float value) => Add(Factory.GreaterOrEqual(expression, value));
		public ExpressionBuilder GreaterOrEqual(IExpression expression, double value) => Add(Factory.GreaterOrEqual(expression, value));
		public ExpressionBuilder GreaterOrEqual(IExpression expression, decimal value) => Add(Factory.GreaterOrEqual(expression, value));
		public ExpressionBuilder GreaterOrEqual(IExpression expression, DateTime value, string? format = null) => Add(Factory.GreaterOrEqual(expression, value, format));
		public ExpressionBuilder GreaterOrEqual(IExpression expression, string value) => Add(Factory.GreaterOrEqual(expression, value));
		public ExpressionBuilder GreaterOrEqual(IExpression expression1, IExpression expression2) => Add(Factory.GreaterOrEqual(expression1, expression2));
		public ExpressionBuilder GreaterOrEqual(IExpression expression, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.GreaterOrEqual(expression, expressionFunction));

		public ExpressionBuilder GreaterOrEqual(string column, sbyte value) => Add(Factory.GreaterOrEqual(column, value));
		public ExpressionBuilder GreaterOrEqual(string column, short value) => Add(Factory.GreaterOrEqual(column, value));
		public ExpressionBuilder GreaterOrEqual(string column, int value) => Add(Factory.GreaterOrEqual(column, value));
		public ExpressionBuilder GreaterOrEqual(string column, long value) => Add(Factory.GreaterOrEqual(column, value));
		public ExpressionBuilder GreaterOrEqual(string column, float value) => Add(Factory.GreaterOrEqual(column, value));
		public ExpressionBuilder GreaterOrEqual(string column, double value) => Add(Factory.GreaterOrEqual(column, value));
		public ExpressionBuilder GreaterOrEqual(string column, decimal value) => Add(Factory.GreaterOrEqual(column, value));
		public ExpressionBuilder GreaterOrEqual(string column, DateTime value, string? format = null) => Add(Factory.GreaterOrEqual(column, value, format));
		public ExpressionBuilder GreaterOrEqual(string column, string value) => Add(Factory.GreaterOrEqual(column, value));
		public ExpressionBuilder GreaterOrEqual(string column, IExpression expression) => Add(Factory.GreaterOrEqual(column, expression));
		public ExpressionBuilder GreaterOrEqual(string column, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.GreaterOrEqual(column, expressionFunction));

		public ExpressionBuilder GreaterOrEqual(string column, string table, sbyte value) => Add(Factory.GreaterOrEqual(column, table, value));
		public ExpressionBuilder GreaterOrEqual(string column, string table, short value) => Add(Factory.GreaterOrEqual(column, table, value));
		public ExpressionBuilder GreaterOrEqual(string column, string table, int value) => Add(Factory.GreaterOrEqual(column, table, value));
		public ExpressionBuilder GreaterOrEqual(string column, string table, long value) => Add(Factory.GreaterOrEqual(column, table, value));
		public ExpressionBuilder GreaterOrEqual(string column, string table, float value) => Add(Factory.GreaterOrEqual(column, table, value));
		public ExpressionBuilder GreaterOrEqual(string column, string table, double value) => Add(Factory.GreaterOrEqual(column, table, value));
		public ExpressionBuilder GreaterOrEqual(string column, string table, decimal value) => Add(Factory.GreaterOrEqual(column, table, value));
		public ExpressionBuilder GreaterOrEqual(string column, string table, DateTime value, string? format = null) => Add(Factory.GreaterOrEqual(column, table, value, format));
		public ExpressionBuilder GreaterOrEqual(string column, string table, string value) => Add(Factory.GreaterOrEqual(column, table, value));
		public ExpressionBuilder GreaterOrEqual(string column, string table, IExpression expression) => Add(Factory.GreaterOrEqual(column, table, expression));
		public ExpressionBuilder GreaterOrEqual(string column, string table, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.GreaterOrEqual(column, table, expressionFunction));

		public ExpressionBuilder GreaterOrEqual(string column, ISource source, sbyte value) => Add(Factory.GreaterOrEqual(column, source, value));
		public ExpressionBuilder GreaterOrEqual(string column, ISource source, short value) => Add(Factory.GreaterOrEqual(column, source, value));
		public ExpressionBuilder GreaterOrEqual(string column, ISource source, int value) => Add(Factory.GreaterOrEqual(column, source, value));
		public ExpressionBuilder GreaterOrEqual(string column, ISource source, long value) => Add(Factory.GreaterOrEqual(column, source, value));
		public ExpressionBuilder GreaterOrEqual(string column, ISource source, float value) => Add(Factory.GreaterOrEqual(column, source, value));
		public ExpressionBuilder GreaterOrEqual(string column, ISource source, double value) => Add(Factory.GreaterOrEqual(column, source, value));
		public ExpressionBuilder GreaterOrEqual(string column, ISource source, decimal value) => Add(Factory.GreaterOrEqual(column, source, value));
		public ExpressionBuilder GreaterOrEqual(string column, ISource source, DateTime value, string? format = null) => Add(Factory.GreaterOrEqual(column, source, value, format));
		public ExpressionBuilder GreaterOrEqual(string column, ISource source, string value) => Add(Factory.GreaterOrEqual(column, source, value));
		public ExpressionBuilder GreaterOrEqual(string column, ISource source, IExpression expression) => Add(Factory.GreaterOrEqual(column, source, expression));
		public ExpressionBuilder GreaterOrEqual(string column, ISource source, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.GreaterOrEqual(column, source, expressionFunction));

		public ExpressionBuilder GreaterOrEqual(string column1, string table1, string column2, string table2) => Add(Factory.GreaterOrEqual(column1, table1, column2, table2));
		public ExpressionBuilder GreaterOrEqual(string column1, string table1, string column2, ISource source2) => Add(Factory.GreaterOrEqual(column1, table1, column2, source2));
		public ExpressionBuilder GreaterOrEqual(string column1, ISource source1, string column2, string table2) => Add(Factory.GreaterOrEqual(column1, source1, column2, table2));
		public ExpressionBuilder GreaterOrEqual(string column1, ISource source1, string column2, ISource source2) => Add(Factory.GreaterOrEqual(column1, source1, column2, source2));
		public ExpressionBuilder GreaterOrEqual(Func<ExpressionFactory, IExpression> expressionFunction1, Func<ExpressionFactory, IExpression> expressionFunction2) => Add(Factory.GreaterOrEqual(expressionFunction1, expressionFunction2));

		#endregion GreaterOrEqualCondition methods

		#region LessCondition methods

		public ExpressionBuilder Less(IExpression expression, sbyte value) => Add(Factory.Less(expression, value));
		public ExpressionBuilder Less(IExpression expression, short value) => Add(Factory.Less(expression, value));
		public ExpressionBuilder Less(IExpression expression, int value) => Add(Factory.Less(expression, value));
		public ExpressionBuilder Less(IExpression expression, long value) => Add(Factory.Less(expression, value));
		public ExpressionBuilder Less(IExpression expression, float value) => Add(Factory.Less(expression, value));
		public ExpressionBuilder Less(IExpression expression, double value) => Add(Factory.Less(expression, value));
		public ExpressionBuilder Less(IExpression expression, decimal value) => Add(Factory.Less(expression, value));
		public ExpressionBuilder Less(IExpression expression, DateTime value, string? format = null) => Add(Factory.Less(expression, value, format));
		public ExpressionBuilder Less(IExpression expression, string value) => Add(Factory.Less(expression, value));
		public ExpressionBuilder Less(IExpression expression1, IExpression expression2) => Add(Factory.Less(expression1, expression2));
		public ExpressionBuilder Less(IExpression expression, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Less(expression, expressionFunction));

		public ExpressionBuilder Less(string column, sbyte value) => Add(Factory.Less(column, value));
		public ExpressionBuilder Less(string column, short value) => Add(Factory.Less(column, value));
		public ExpressionBuilder Less(string column, int value) => Add(Factory.Less(column, value));
		public ExpressionBuilder Less(string column, long value) => Add(Factory.Less(column, value));
		public ExpressionBuilder Less(string column, float value) => Add(Factory.Less(column, value));
		public ExpressionBuilder Less(string column, double value) => Add(Factory.Less(column, value));
		public ExpressionBuilder Less(string column, decimal value) => Add(Factory.Less(column, value));
		public ExpressionBuilder Less(string column, DateTime value, string? format = null) => Add(Factory.Less(column, value, format));
		public ExpressionBuilder Less(string column, string value) => Add(Factory.Less(column, value));
		public ExpressionBuilder Less(string column, IExpression expression) => Add(Factory.Less(column, expression));
		public ExpressionBuilder Less(string column, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Less(column, expressionFunction));

		public ExpressionBuilder Less(string column, string table, sbyte value) => Add(Factory.Less(column, table, value));
		public ExpressionBuilder Less(string column, string table, short value) => Add(Factory.Less(column, table, value));
		public ExpressionBuilder Less(string column, string table, int value) => Add(Factory.Less(column, table, value));
		public ExpressionBuilder Less(string column, string table, long value) => Add(Factory.Less(column, table, value));
		public ExpressionBuilder Less(string column, string table, float value) => Add(Factory.Less(column, table, value));
		public ExpressionBuilder Less(string column, string table, double value) => Add(Factory.Less(column, table, value));
		public ExpressionBuilder Less(string column, string table, decimal value) => Add(Factory.Less(column, table, value));
		public ExpressionBuilder Less(string column, string table, DateTime value, string? format = null) => Add(Factory.Less(column, table, value, format));
		public ExpressionBuilder Less(string column, string table, string value) => Add(Factory.Less(column, table, value));
		public ExpressionBuilder Less(string column, string table, IExpression expression) => Add(Factory.Less(column, table, expression));
		public ExpressionBuilder Less(string column, string table, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Less(column, table, expressionFunction));

		public ExpressionBuilder Less(string column, ISource source, sbyte value) => Add(Factory.Less(column, source, value));
		public ExpressionBuilder Less(string column, ISource source, short value) => Add(Factory.Less(column, source, value));
		public ExpressionBuilder Less(string column, ISource source, int value) => Add(Factory.Less(column, source, value));
		public ExpressionBuilder Less(string column, ISource source, long value) => Add(Factory.Less(column, source, value));
		public ExpressionBuilder Less(string column, ISource source, float value) => Add(Factory.Less(column, source, value));
		public ExpressionBuilder Less(string column, ISource source, double value) => Add(Factory.Less(column, source, value));
		public ExpressionBuilder Less(string column, ISource source, decimal value) => Add(Factory.Less(column, source, value));
		public ExpressionBuilder Less(string column, ISource source, DateTime value, string? format = null) => Add(Factory.Less(column, source, value, format));
		public ExpressionBuilder Less(string column, ISource source, string value) => Add(Factory.Less(column, source, value));
		public ExpressionBuilder Less(string column, ISource source, IExpression expression) => Add(Factory.Less(column, source, expression));
		public ExpressionBuilder Less(string column, ISource source, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Less(column, source, expressionFunction));

		public ExpressionBuilder Less(string column1, string table1, string column2, string table2) => Add(Factory.Less(column1, table1, column2, table2));
		public ExpressionBuilder Less(string column1, string table1, string column2, ISource source2) => Add(Factory.Less(column1, table1, column2, source2));
		public ExpressionBuilder Less(string column1, ISource source1, string column2, string table2) => Add(Factory.Less(column1, source1, column2, table2));
		public ExpressionBuilder Less(string column1, ISource source1, string column2, ISource source2) => Add(Factory.Less(column1, source1, column2, source2));
		public ExpressionBuilder Less(Func<ExpressionFactory, IExpression> expressionFunction1, Func<ExpressionFactory, IExpression> expressionFunction2) => Add(Factory.Less(expressionFunction1, expressionFunction2));

		#endregion LessCondition methods

		#region LessOrEqualCondition methods

		public ExpressionBuilder LessOrEqual(IExpression expression, sbyte value) => Add(Factory.LessOrEqual(expression, value));
		public ExpressionBuilder LessOrEqual(IExpression expression, short value) => Add(Factory.LessOrEqual(expression, value));
		public ExpressionBuilder LessOrEqual(IExpression expression, int value) => Add(Factory.LessOrEqual(expression, value));
		public ExpressionBuilder LessOrEqual(IExpression expression, long value) => Add(Factory.LessOrEqual(expression, value));
		public ExpressionBuilder LessOrEqual(IExpression expression, float value) => Add(Factory.LessOrEqual(expression, value));
		public ExpressionBuilder LessOrEqual(IExpression expression, double value) => Add(Factory.LessOrEqual(expression, value));
		public ExpressionBuilder LessOrEqual(IExpression expression, decimal value) => Add(Factory.LessOrEqual(expression, value));
		public ExpressionBuilder LessOrEqual(IExpression expression, DateTime value, string? format = null) => Add(Factory.LessOrEqual(expression, value, format));
		public ExpressionBuilder LessOrEqual(IExpression expression, string value) => Add(Factory.LessOrEqual(expression, value));
		public ExpressionBuilder LessOrEqual(IExpression expression1, IExpression expression2) => Add(Factory.LessOrEqual(expression1, expression2));
		public ExpressionBuilder LessOrEqual(IExpression expression, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.LessOrEqual(expression, expressionFunction));

		public ExpressionBuilder LessOrEqual(string column, sbyte value) => Add(Factory.LessOrEqual(column, value));
		public ExpressionBuilder LessOrEqual(string column, short value) => Add(Factory.LessOrEqual(column, value));
		public ExpressionBuilder LessOrEqual(string column, int value) => Add(Factory.LessOrEqual(column, value));
		public ExpressionBuilder LessOrEqual(string column, long value) => Add(Factory.LessOrEqual(column, value));
		public ExpressionBuilder LessOrEqual(string column, float value) => Add(Factory.LessOrEqual(column, value));
		public ExpressionBuilder LessOrEqual(string column, double value) => Add(Factory.LessOrEqual(column, value));
		public ExpressionBuilder LessOrEqual(string column, decimal value) => Add(Factory.LessOrEqual(column, value));
		public ExpressionBuilder LessOrEqual(string column, DateTime value, string? format = null) => Add(Factory.LessOrEqual(column, value, format));
		public ExpressionBuilder LessOrEqual(string column, string value) => Add(Factory.LessOrEqual(column, value));
		public ExpressionBuilder LessOrEqual(string column, IExpression expression) => Add(Factory.LessOrEqual(column, expression));
		public ExpressionBuilder LessOrEqual(string column, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.LessOrEqual(column, expressionFunction));

		public ExpressionBuilder LessOrEqual(string column, string table, sbyte value) => Add(Factory.LessOrEqual(column, table, value));
		public ExpressionBuilder LessOrEqual(string column, string table, short value) => Add(Factory.LessOrEqual(column, table, value));
		public ExpressionBuilder LessOrEqual(string column, string table, int value) => Add(Factory.LessOrEqual(column, table, value));
		public ExpressionBuilder LessOrEqual(string column, string table, long value) => Add(Factory.LessOrEqual(column, table, value));
		public ExpressionBuilder LessOrEqual(string column, string table, float value) => Add(Factory.LessOrEqual(column, table, value));
		public ExpressionBuilder LessOrEqual(string column, string table, double value) => Add(Factory.LessOrEqual(column, table, value));
		public ExpressionBuilder LessOrEqual(string column, string table, decimal value) => Add(Factory.LessOrEqual(column, table, value));
		public ExpressionBuilder LessOrEqual(string column, string table, DateTime value, string? format = null) => Add(Factory.LessOrEqual(column, table, value, format));
		public ExpressionBuilder LessOrEqual(string column, string table, string value) => Add(Factory.LessOrEqual(column, table, value));
		public ExpressionBuilder LessOrEqual(string column, string table, IExpression expression) => Add(Factory.LessOrEqual(column, table, expression));
		public ExpressionBuilder LessOrEqual(string column, string table, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.LessOrEqual(column, table, expressionFunction));

		public ExpressionBuilder LessOrEqual(string column, ISource source, sbyte value) => Add(Factory.LessOrEqual(column, source, value));
		public ExpressionBuilder LessOrEqual(string column, ISource source, short value) => Add(Factory.LessOrEqual(column, source, value));
		public ExpressionBuilder LessOrEqual(string column, ISource source, int value) => Add(Factory.LessOrEqual(column, source, value));
		public ExpressionBuilder LessOrEqual(string column, ISource source, long value) => Add(Factory.LessOrEqual(column, source, value));
		public ExpressionBuilder LessOrEqual(string column, ISource source, float value) => Add(Factory.LessOrEqual(column, source, value));
		public ExpressionBuilder LessOrEqual(string column, ISource source, double value) => Add(Factory.LessOrEqual(column, source, value));
		public ExpressionBuilder LessOrEqual(string column, ISource source, decimal value) => Add(Factory.LessOrEqual(column, source, value));
		public ExpressionBuilder LessOrEqual(string column, ISource source, DateTime value, string? format = null) => Add(Factory.LessOrEqual(column, source, value, format));
		public ExpressionBuilder LessOrEqual(string column, ISource source, string value) => Add(Factory.LessOrEqual(column, source, value));
		public ExpressionBuilder LessOrEqual(string column, ISource source, IExpression expression) => Add(Factory.LessOrEqual(column, source, expression));
		public ExpressionBuilder LessOrEqual(string column, ISource source, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.LessOrEqual(column, source, expressionFunction));

		public ExpressionBuilder LessOrEqual(string column1, string table1, string column2, string table2) => Add(Factory.LessOrEqual(column1, table1, column2, table2));
		public ExpressionBuilder LessOrEqual(string column1, string table1, string column2, ISource source2) => Add(Factory.LessOrEqual(column1, table1, column2, source2));
		public ExpressionBuilder LessOrEqual(string column1, ISource source1, string column2, string table2) => Add(Factory.LessOrEqual(column1, source1, column2, table2));
		public ExpressionBuilder LessOrEqual(string column1, ISource source1, string column2, ISource source2) => Add(Factory.LessOrEqual(column1, source1, column2, source2));
		public ExpressionBuilder LessOrEqual(Func<ExpressionFactory, IExpression> expressionFunction1, Func<ExpressionFactory, IExpression> expressionFunction2) => Add(Factory.LessOrEqual(expressionFunction1, expressionFunction2));

		#endregion LessOrEqualCondition methods

		#region IsNullCondition methods

		public ExpressionBuilder IsNull(IExpression expression) => Add(Factory.IsNull(expression));
		public ExpressionBuilder IsNull(string column) => Add(Factory.IsNull(column));
		public ExpressionBuilder IsNull(string column, string table) => Add(Factory.IsNull(column, table));
		public ExpressionBuilder IsNull(string column, ISource source) => Add(Factory.IsNull(column, source));
		public ExpressionBuilder IsNull(Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.IsNull(expressionFunction));

		#endregion IsNullCondition methods

		#region IsNotNullCondition methods

		public ExpressionBuilder IsNotNull(IExpression expression) => Add(Factory.IsNotNull(expression));
		public ExpressionBuilder IsNotNull(string column) => Add(Factory.IsNotNull(column));
		public ExpressionBuilder IsNotNull(string column, string table) => Add(Factory.IsNotNull(column, table));
		public ExpressionBuilder IsNotNull(string column, ISource source) => Add(Factory.IsNotNull(column, source));
		public ExpressionBuilder IsNotNull(Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.IsNotNull(expressionFunction));

		#endregion IsNotNullCondition methods

		#region InCondition methods

		public ExpressionBuilder In(IExpression expression, params sbyte[] values) => Add(Factory.In(expression, values));
		public ExpressionBuilder In(IExpression expression, params short[] values) => Add(Factory.In(expression, values));
		public ExpressionBuilder In(IExpression expression, params int[] values) => Add(Factory.In(expression, values));
		public ExpressionBuilder In(IExpression expression, params long[] values) => Add(Factory.In(expression, values));
		public ExpressionBuilder In(IExpression expression, params float[] values) => Add(Factory.In(expression, values));
		public ExpressionBuilder In(IExpression expression, params double[] values) => Add(Factory.In(expression, values));
		public ExpressionBuilder In(IExpression expression, params decimal[] values) => Add(Factory.In(expression, values));
		public ExpressionBuilder In(IExpression expression, params DateTime[] values) => Add(Factory.In(expression, values));
		public ExpressionBuilder In(IExpression expression, string format, params DateTime[] values) => Add(Factory.In(expression, format, values));
		public ExpressionBuilder In(IExpression expression, params string[] values) => Add(Factory.In(expression, values));
		public ExpressionBuilder In(IExpression expression, params IExpression[] values) => Add(Factory.In(expression, values));
		public ExpressionBuilder In(IExpression expression, IEnumerable<sbyte> values) => Add(Factory.In(expression, values));
		public ExpressionBuilder In(IExpression expression, IEnumerable<short> values) => Add(Factory.In(expression, values));
		public ExpressionBuilder In(IExpression expression, IEnumerable<int> values) => Add(Factory.In(expression, values));
		public ExpressionBuilder In(IExpression expression, IEnumerable<long> values) => Add(Factory.In(expression, values));
		public ExpressionBuilder In(IExpression expression, IEnumerable<float> values) => Add(Factory.In(expression, values));
		public ExpressionBuilder In(IExpression expression, IEnumerable<double> values) => Add(Factory.In(expression, values));
		public ExpressionBuilder In(IExpression expression, IEnumerable<decimal> values) => Add(Factory.In(expression, values));
		public ExpressionBuilder In(IExpression expression, IEnumerable<DateTime> values, string? format = null) => Add(Factory.In(expression, values, format));
		public ExpressionBuilder In(IExpression expression, IEnumerable<string> values) => Add(Factory.In(expression, values));
		public ExpressionBuilder In(IExpression expression, IEnumerable<IExpression> values) => Add(Factory.In(expression, values));
		public ExpressionBuilder In(IExpression expression, Action<ExpressionBuilder> buildExpressionMethod) =>  Add(Factory.In(expression, buildExpressionMethod));
		public ExpressionBuilder In(Func<ExpressionFactory, IExpression> expressionFunction, Action<ExpressionBuilder> buildExpressionMethod) => Add(Factory.In(expressionFunction, buildExpressionMethod));

		public ExpressionBuilder In(string column, params sbyte[] values) => Add(Factory.In(column, values));
		public ExpressionBuilder In(string column, params short[] values) => Add(Factory.In(column, values));
		public ExpressionBuilder In(string column, params int[] values) => Add(Factory.In(column, values));
		public ExpressionBuilder In(string column, params long[] values) => Add(Factory.In(column, values));
		public ExpressionBuilder In(string column, params float[] values) => Add(Factory.In(column, values));
		public ExpressionBuilder In(string column, params double[] values) => Add(Factory.In(column, values));
		public ExpressionBuilder In(string column, params decimal[] values) => Add(Factory.In(column, values));
		public ExpressionBuilder In(string column, params DateTime[] values) => Add(Factory.In(column, values));
		public ExpressionBuilder In(string column, string format, params DateTime[] values) => Add(Factory.In(column, format, values));
		public ExpressionBuilder In(string column, params string[] values) => Add(Factory.In(column, values));
		public ExpressionBuilder In(string column, params IExpression[] values) => Add(Factory.In(column, values));
		public ExpressionBuilder In(string column, IEnumerable<sbyte> values) => Add(Factory.In(column, values));
		public ExpressionBuilder In(string column, IEnumerable<short> values) => Add(Factory.In(column, values));
		public ExpressionBuilder In(string column, IEnumerable<int> values) => Add(Factory.In(column, values));
		public ExpressionBuilder In(string column, IEnumerable<long> values) => Add(Factory.In(column, values));
		public ExpressionBuilder In(string column, IEnumerable<float> values) => Add(Factory.In(column, values));
		public ExpressionBuilder In(string column, IEnumerable<double> values) => Add(Factory.In(column, values));
		public ExpressionBuilder In(string column, IEnumerable<decimal> values) => Add(Factory.In(column, values));
		public ExpressionBuilder In(string column, IEnumerable<DateTime> values, string? format = null) => Add(Factory.In(column, values, format));
		public ExpressionBuilder In(string column, IEnumerable<string> values) => Add(Factory.In(column, values));
		public ExpressionBuilder In(string column, IEnumerable<IExpression> values) => Add(Factory.In(column, values));
		public ExpressionBuilder In(string column, Action<ExpressionBuilder> buildExpressionMethod) => Add(Factory.In(column, buildExpressionMethod));

		public ExpressionBuilder In(string column, string table, params sbyte[] values) => Add(Factory.In(column, table, values));
		public ExpressionBuilder In(string column, string table, params short[] values) => Add(Factory.In(column, table, values));
		public ExpressionBuilder In(string column, string table, params int[] values) => Add(Factory.In(column, table, values));
		public ExpressionBuilder In(string column, string table, params long[] values) => Add(Factory.In(column, table, values));
		public ExpressionBuilder In(string column, string table, params float[] values) => Add(Factory.In(column, table, values));
		public ExpressionBuilder In(string column, string table, params double[] values) => Add(Factory.In(column, table, values));
		public ExpressionBuilder In(string column, string table, params decimal[] values) => Add(Factory.In(column, table, values));
		public ExpressionBuilder In(string column, string table, string? format, params DateTime[] values) => Add(Factory.In(column, table, format, values));
		public ExpressionBuilder In(string column, string table, params string[] values) => Add(Factory.In(column, table, values));
		public ExpressionBuilder In(string column, string table, params IExpression[] values) => Add(Factory.In(column, table, values));
		public ExpressionBuilder In(string column, string table, IEnumerable<sbyte> values) => Add(Factory.In(column, table, values));
		public ExpressionBuilder In(string column, string table, IEnumerable<short> values) => Add(Factory.In(column, table, values));
		public ExpressionBuilder In(string column, string table, IEnumerable<int> values) => Add(Factory.In(column, table, values));
		public ExpressionBuilder In(string column, string table, IEnumerable<long> values) => Add(Factory.In(column, table, values));
		public ExpressionBuilder In(string column, string table, IEnumerable<float> values) => Add(Factory.In(column, table, values));
		public ExpressionBuilder In(string column, string table, IEnumerable<double> values) => Add(Factory.In(column, table, values));
		public ExpressionBuilder In(string column, string table, IEnumerable<decimal> values) => Add(Factory.In(column, table, values));
		public ExpressionBuilder In(string column, string table, IEnumerable<DateTime> values, string? format = null) => Add(Factory.In(column, table, values, format));
		public ExpressionBuilder In(string column, string table, IEnumerable<string> values) => Add(Factory.In(column, table, values));
		public ExpressionBuilder In(string column, string table, IEnumerable<IExpression> values) => Add(Factory.In(column, table, values));
		public ExpressionBuilder In(string column, string table, Action<ExpressionBuilder> buildExpressionMethod) => Add(Factory.In(column, table, buildExpressionMethod));

		public ExpressionBuilder In(string column, ISource source, params sbyte[] values) => Add(Factory.In(column, source, values));
		public ExpressionBuilder In(string column, ISource source, params short[] values) => Add(Factory.In(column, source, values));
		public ExpressionBuilder In(string column, ISource source, params int[] values) => Add(Factory.In(column, source, values));
		public ExpressionBuilder In(string column, ISource source, params long[] values) => Add(Factory.In(column, source, values));
		public ExpressionBuilder In(string column, ISource source, params float[] values) => Add(Factory.In(column, source, values));
		public ExpressionBuilder In(string column, ISource source, params double[] values) => Add(Factory.In(column, source, values));
		public ExpressionBuilder In(string column, ISource source, params decimal[] values) => Add(Factory.In(column, source, values));
		public ExpressionBuilder In(string column, ISource source, params DateTime[] values) => Add(Factory.In(column, source, values));
		public ExpressionBuilder In(string column, ISource source, string format, params DateTime[] values) => Add(Factory.In(column, source, format, values));
		public ExpressionBuilder In(string column, ISource source, params string[] values) => Add(Factory.In(column, source, values));
		public ExpressionBuilder In(string column, ISource source, params IExpression[] values) => Add(Factory.In(column, source, values));
		public ExpressionBuilder In(string column, ISource source, IEnumerable<sbyte> values) => Add(Factory.In(column, source, values));
		public ExpressionBuilder In(string column, ISource source, IEnumerable<short> values) => Add(Factory.In(column, source, values));
		public ExpressionBuilder In(string column, ISource source, IEnumerable<int> values) => Add(Factory.In(column, source, values));
		public ExpressionBuilder In(string column, ISource source, IEnumerable<long> values) => Add(Factory.In(column, source, values));
		public ExpressionBuilder In(string column, ISource source, IEnumerable<float> values) => Add(Factory.In(column, source, values));
		public ExpressionBuilder In(string column, ISource source, IEnumerable<double> values) => Add(Factory.In(column, source, values));
		public ExpressionBuilder In(string column, ISource source, IEnumerable<decimal> values) => Add(Factory.In(column, source, values));
		public ExpressionBuilder In(string column, ISource source, IEnumerable<DateTime> values, string? format = null) => Add(Factory.In(column, source, values, format));
		public ExpressionBuilder In(string column, ISource source, IEnumerable<string> values) => Add(Factory.In(column, source, values));
		public ExpressionBuilder In(string column, ISource source, IEnumerable<IExpression> values) => Add(Factory.In(column, source, values));
		public ExpressionBuilder In(string column, ISource source, Action<ExpressionBuilder> buildExpressionMethod) => Add(Factory.In(column, source, buildExpressionMethod));

		#endregion InCondition methods

		#region NotInCondition methods

		public ExpressionBuilder NotIn(IExpression expression, params sbyte[] values) => Add(Factory.NotIn(expression, values));
		public ExpressionBuilder NotIn(IExpression expression, params short[] values) => Add(Factory.NotIn(expression, values));
		public ExpressionBuilder NotIn(IExpression expression, params int[] values) => Add(Factory.NotIn(expression, values));
		public ExpressionBuilder NotIn(IExpression expression, params long[] values) => Add(Factory.NotIn(expression, values));
		public ExpressionBuilder NotIn(IExpression expression, params float[] values) => Add(Factory.NotIn(expression, values));
		public ExpressionBuilder NotIn(IExpression expression, params double[] values) => Add(Factory.NotIn(expression, values));
		public ExpressionBuilder NotIn(IExpression expression, params decimal[] values) => Add(Factory.NotIn(expression, values));
		public ExpressionBuilder NotIn(IExpression expression, params DateTime[] values) => Add(Factory.NotIn(expression, values));
		public ExpressionBuilder NotIn(IExpression expression, string format, params DateTime[] values) => Add(Factory.NotIn(expression, format, values));
		public ExpressionBuilder NotIn(IExpression expression, params string[] values) => Add(Factory.NotIn(expression, values));
		public ExpressionBuilder NotIn(IExpression expression, params IExpression[] values) => Add(Factory.NotIn(expression, values));
		public ExpressionBuilder NotIn(IExpression expression, IEnumerable<sbyte> values) => Add(Factory.NotIn(expression, values));
		public ExpressionBuilder NotIn(IExpression expression, IEnumerable<short> values) => Add(Factory.NotIn(expression, values));
		public ExpressionBuilder NotIn(IExpression expression, IEnumerable<int> values) => Add(Factory.NotIn(expression, values));
		public ExpressionBuilder NotIn(IExpression expression, IEnumerable<long> values) => Add(Factory.NotIn(expression, values));
		public ExpressionBuilder NotIn(IExpression expression, IEnumerable<float> values) => Add(Factory.NotIn(expression, values));
		public ExpressionBuilder NotIn(IExpression expression, IEnumerable<double> values) => Add(Factory.NotIn(expression, values));
		public ExpressionBuilder NotIn(IExpression expression, IEnumerable<decimal> values) => Add(Factory.NotIn(expression, values));
		public ExpressionBuilder NotIn(IExpression expression, IEnumerable<DateTime> values, string? format = null) => Add(Factory.NotIn(expression, values, format));
		public ExpressionBuilder NotIn(IExpression expression, IEnumerable<string> values) => Add(Factory.NotIn(expression, values));
		public ExpressionBuilder NotIn(IExpression expression, IEnumerable<IExpression> values) => Add(Factory.NotIn(expression, values));
		public ExpressionBuilder NotIn(IExpression expression, Action<ExpressionBuilder> buildExpressionMethod) => Add(Factory.NotIn(expression, buildExpressionMethod));
		public ExpressionBuilder NotIn(Func<ExpressionFactory, IExpression> expressionFunction, Action<ExpressionBuilder> buildExpressionMethod) => Add(Factory.NotIn(expressionFunction, buildExpressionMethod));

		public ExpressionBuilder NotIn(string column, params sbyte[] values) => Add(Factory.NotIn(column, values));
		public ExpressionBuilder NotIn(string column, params short[] values) => Add(Factory.NotIn(column, values));
		public ExpressionBuilder NotIn(string column, params int[] values) => Add(Factory.NotIn(column, values));
		public ExpressionBuilder NotIn(string column, params long[] values) => Add(Factory.NotIn(column, values));
		public ExpressionBuilder NotIn(string column, params float[] values) => Add(Factory.NotIn(column, values));
		public ExpressionBuilder NotIn(string column, params double[] values) => Add(Factory.NotIn(column, values));
		public ExpressionBuilder NotIn(string column, params decimal[] values) => Add(Factory.NotIn(column, values));
		public ExpressionBuilder NotIn(string column, params DateTime[] values) => Add(Factory.NotIn(column, values));
		public ExpressionBuilder NotIn(string column, string format, params DateTime[] values) => Add(Factory.NotIn(column, format, values));
		public ExpressionBuilder NotIn(string column, params string[] values) => Add(Factory.NotIn(column, values));
		public ExpressionBuilder NotIn(string column, params IExpression[] values) => Add(Factory.NotIn(column, values));
		public ExpressionBuilder NotIn(string column, IEnumerable<sbyte> values) => Add(Factory.NotIn(column, values));
		public ExpressionBuilder NotIn(string column, IEnumerable<short> values) => Add(Factory.NotIn(column, values));
		public ExpressionBuilder NotIn(string column, IEnumerable<int> values) => Add(Factory.NotIn(column, values));
		public ExpressionBuilder NotIn(string column, IEnumerable<long> values) => Add(Factory.NotIn(column, values));
		public ExpressionBuilder NotIn(string column, IEnumerable<float> values) => Add(Factory.NotIn(column, values));
		public ExpressionBuilder NotIn(string column, IEnumerable<double> values) => Add(Factory.NotIn(column, values));
		public ExpressionBuilder NotIn(string column, IEnumerable<decimal> values) => Add(Factory.NotIn(column, values));
		public ExpressionBuilder NotIn(string column, IEnumerable<DateTime> values, string? format = null) => Add(Factory.NotIn(column, values, format));
		public ExpressionBuilder NotIn(string column, IEnumerable<string> values) => Add(Factory.NotIn(column, values));
		public ExpressionBuilder NotIn(string column, IEnumerable<IExpression> values) => Add(Factory.NotIn(column, values));
		public ExpressionBuilder NotIn(string column, Action<ExpressionBuilder> buildExpressionMethod) => Add(Factory.NotIn(column, buildExpressionMethod));

		public ExpressionBuilder NotIn(string column, string table, params sbyte[] values) => Add(Factory.NotIn(column, table, values));
		public ExpressionBuilder NotIn(string column, string table, params short[] values) => Add(Factory.NotIn(column, table, values));
		public ExpressionBuilder NotIn(string column, string table, params int[] values) => Add(Factory.NotIn(column, table, values));
		public ExpressionBuilder NotIn(string column, string table, params long[] values) => Add(Factory.NotIn(column, table, values));
		public ExpressionBuilder NotIn(string column, string table, params float[] values) => Add(Factory.NotIn(column, table, values));
		public ExpressionBuilder NotIn(string column, string table, params double[] values) => Add(Factory.NotIn(column, table, values));
		public ExpressionBuilder NotIn(string column, string table, params decimal[] values) => Add(Factory.NotIn(column, table, values));
		public ExpressionBuilder NotIn(string column, string table, string? format, params DateTime[] values) => Add(Factory.NotIn(column, table, format, values));
		public ExpressionBuilder NotIn(string column, string table, params string[] values) => Add(Factory.NotIn(column, table, values));
		public ExpressionBuilder NotIn(string column, string table, params IExpression[] values) => Add(Factory.NotIn(column, table, values));
		public ExpressionBuilder NotIn(string column, string table, IEnumerable<sbyte> values) => Add(Factory.NotIn(column, table, values));
		public ExpressionBuilder NotIn(string column, string table, IEnumerable<short> values) => Add(Factory.NotIn(column, table, values));
		public ExpressionBuilder NotIn(string column, string table, IEnumerable<int> values) => Add(Factory.NotIn(column, table, values));
		public ExpressionBuilder NotIn(string column, string table, IEnumerable<long> values) => Add(Factory.NotIn(column, table, values));
		public ExpressionBuilder NotIn(string column, string table, IEnumerable<float> values) => Add(Factory.NotIn(column, table, values));
		public ExpressionBuilder NotIn(string column, string table, IEnumerable<double> values) => Add(Factory.NotIn(column, table, values));
		public ExpressionBuilder NotIn(string column, string table, IEnumerable<decimal> values) => Add(Factory.NotIn(column, table, values));
		public ExpressionBuilder NotIn(string column, string table, IEnumerable<DateTime> values, string? format = null) => Add(Factory.NotIn(column, table, values, format));
		public ExpressionBuilder NotIn(string column, string table, IEnumerable<string> values) => Add(Factory.NotIn(column, table, values));
		public ExpressionBuilder NotIn(string column, string table, IEnumerable<IExpression> values) => Add(Factory.NotIn(column, table, values));
		public ExpressionBuilder NotIn(string column, string table, Action<ExpressionBuilder> buildExpressionMethod) => Add(Factory.NotIn(column, table, buildExpressionMethod));

		public ExpressionBuilder NotIn(string column, ISource source, params sbyte[] values) => Add(Factory.NotIn(column, source, values));
		public ExpressionBuilder NotIn(string column, ISource source, params short[] values) => Add(Factory.NotIn(column, source, values));
		public ExpressionBuilder NotIn(string column, ISource source, params int[] values) => Add(Factory.NotIn(column, source, values));
		public ExpressionBuilder NotIn(string column, ISource source, params long[] values) => Add(Factory.NotIn(column, source, values));
		public ExpressionBuilder NotIn(string column, ISource source, params float[] values) => Add(Factory.NotIn(column, source, values));
		public ExpressionBuilder NotIn(string column, ISource source, params double[] values) => Add(Factory.NotIn(column, source, values));
		public ExpressionBuilder NotIn(string column, ISource source, params decimal[] values) => Add(Factory.NotIn(column, source, values));
		public ExpressionBuilder NotIn(string column, ISource source, params DateTime[] values) => Add(Factory.NotIn(column, source, values));
		public ExpressionBuilder NotIn(string column, ISource source, string? format, params DateTime[] values) => Add(Factory.NotIn(column, source, format, values));
		public ExpressionBuilder NotIn(string column, ISource source, params string[] values) => Add(Factory.NotIn(column, source, values));
		public ExpressionBuilder NotIn(string column, ISource source, params IExpression[] values) => Add(Factory.NotIn(column, source, values));
		public ExpressionBuilder NotIn(string column, ISource source, IEnumerable<sbyte> values) => Add(Factory.NotIn(column, source, values));
		public ExpressionBuilder NotIn(string column, ISource source, IEnumerable<short> values) => Add(Factory.NotIn(column, source, values));
		public ExpressionBuilder NotIn(string column, ISource source, IEnumerable<int> values) => Add(Factory.NotIn(column, source, values));
		public ExpressionBuilder NotIn(string column, ISource source, IEnumerable<long> values) => Add(Factory.NotIn(column, source, values));
		public ExpressionBuilder NotIn(string column, ISource source, IEnumerable<float> values) => Add(Factory.NotIn(column, source, values));
		public ExpressionBuilder NotIn(string column, ISource source, IEnumerable<double> values) => Add(Factory.NotIn(column, source, values));
		public ExpressionBuilder NotIn(string column, ISource source, IEnumerable<decimal> values) => Add(Factory.NotIn(column, source, values));
		public ExpressionBuilder NotIn(string column, ISource source, IEnumerable<DateTime> values, string? format = null) => Add(Factory.NotIn(column, source, values, format));
		public ExpressionBuilder NotIn(string column, ISource source, IEnumerable<string> values) => Add(Factory.NotIn(column, source, values));
		public ExpressionBuilder NotIn(string column, ISource source, IEnumerable<IExpression> values) => Add(Factory.NotIn(column, source, values));
		public ExpressionBuilder NotIn(string column, ISource source, Action<ExpressionBuilder> buildExpressionMethod) => Add(Factory.NotIn(column, source, buildExpressionMethod));

		#endregion NotInCondition methods

		#region LikeCondition methods

		public ExpressionBuilder Like(IExpression expression, string pattern) => Add(Factory.Like(expression, pattern));
		public ExpressionBuilder Like(string column, string pattern) => Add(Factory.Like(column, pattern));
		public ExpressionBuilder Like(string column, string table, string pattern) => Add(Factory.Like(column, table, pattern));
		public ExpressionBuilder Like(string column, ISource source, string pattern) => Add(Factory.Like(column, source, pattern));
		public ExpressionBuilder Like(Func<ExpressionFactory, IExpression> expressionFunction, string pattern) => Add(Factory.Like(expressionFunction, pattern));

		#endregion LikeCondition methods

		#region NotLikeCondition methods

		public ExpressionBuilder NotLike(IExpression expression, string pattern) => Add(Factory.NotLike(expression, pattern));
		public ExpressionBuilder NotLike(string column, string pattern) => Add(Factory.NotLike(column, pattern));
		public ExpressionBuilder NotLike(string column, string table, string pattern) => Add(Factory.NotLike(column, table, pattern));
		public ExpressionBuilder NotLike(string column, ISource source, string pattern) => Add(Factory.NotLike(column, source, pattern));
		public ExpressionBuilder NotLike(Func<ExpressionFactory, IExpression> expressionFunction, string pattern) => Add(Factory.NotLike(expressionFunction, pattern));

		#endregion NotLikeCondition methods

		#region BetweenCondition methods

		public ExpressionBuilder Between(IExpression expression, sbyte lowBound, sbyte hightBound) => Add(Factory.Between(expression, lowBound, hightBound));
		public ExpressionBuilder Between(IExpression expression, short lowBound, short hightBound) => Add(Factory.Between(expression, lowBound, hightBound));
		public ExpressionBuilder Between(IExpression expression, int lowBound, int hightBound) => Add(Factory.Between(expression, lowBound, hightBound));
		public ExpressionBuilder Between(IExpression expression, long lowBound, long hightBound) => Add(Factory.Between(expression, lowBound, hightBound));
		public ExpressionBuilder Between(IExpression expression, float lowBound, float hightBound) => Add(Factory.Between(expression, lowBound, hightBound));
		public ExpressionBuilder Between(IExpression expression, double lowBound, double hightBound) => Add(Factory.Between(expression, lowBound, hightBound));
		public ExpressionBuilder Between(IExpression expression, decimal lowBound, decimal hightBound) => Add(Factory.Between(expression, lowBound, hightBound));
		public ExpressionBuilder Between(IExpression expression, DateTime lowBound, DateTime hightBound, string? format = null) => Add(Factory.Between(expression, lowBound, hightBound, format));
		public ExpressionBuilder Between(IExpression expression, string lowBound, string hightBound) => Add(Factory.Between(expression, lowBound, hightBound));
		public ExpressionBuilder Between(IExpression expression1, IExpression lowBound, IExpression hightBound) => Add(Factory.Between(expression1, lowBound, hightBound));
		public ExpressionBuilder Between(IExpression expression, Func<ExpressionFactory, IExpression> lowBoundFunction, Func<ExpressionFactory, IExpression> hightBoundFunction) => Add(Factory.Between(expression, lowBoundFunction, hightBoundFunction));
		public ExpressionBuilder Between(Func<ExpressionFactory, IExpression> expressionFunction, Func<ExpressionFactory, IExpression> lowBoundFunction, Func<ExpressionFactory, IExpression> hightBoundFunction) => Add(Factory.Between(expressionFunction, lowBoundFunction, hightBoundFunction));

		public ExpressionBuilder Between(string column, sbyte lowBound, sbyte hightBound) => Add(Factory.Between(column, lowBound, hightBound));
		public ExpressionBuilder Between(string column, short lowBound, short hightBound) => Add(Factory.Between(column, lowBound, hightBound));
		public ExpressionBuilder Between(string column, int lowBound, int hightBound) => Add(Factory.Between(column, lowBound, hightBound));
		public ExpressionBuilder Between(string column, long lowBound, long hightBound) => Add(Factory.Between(column, lowBound, hightBound));
		public ExpressionBuilder Between(string column, float lowBound, float hightBound) => Add(Factory.Between(column, lowBound, hightBound));
		public ExpressionBuilder Between(string column, double lowBound, double hightBound) => Add(Factory.Between(column, lowBound, hightBound));
		public ExpressionBuilder Between(string column, decimal lowBound, decimal hightBound) => Add(Factory.Between(column, lowBound, hightBound));
		public ExpressionBuilder Between(string column, DateTime lowBound, DateTime hightBound, string? format = null) => Add(Factory.Between(column, lowBound, hightBound, format));
		public ExpressionBuilder Between(string column, string lowBound, string hightBound) => Add(Factory.Between(column, lowBound, hightBound));
		public ExpressionBuilder Between(string column, IExpression lowBound, IExpression hightBound) => Add(Factory.Between(column, lowBound, hightBound));
		public ExpressionBuilder Between(string column, Func<ExpressionFactory, IExpression> lowBoundFunction, Func<ExpressionFactory, IExpression> hightBoundFunction) => Add(Factory.Between(column, lowBoundFunction, hightBoundFunction));

		public ExpressionBuilder Between(string column, string table, sbyte lowBound, sbyte hightBound) => Add(Factory.Between(column, table, lowBound, hightBound));
		public ExpressionBuilder Between(string column, string table, short lowBound, short hightBound) => Add(Factory.Between(column, table, lowBound, hightBound));
		public ExpressionBuilder Between(string column, string table, int lowBound, int hightBound) => Add(Factory.Between(column, table, lowBound, hightBound));
		public ExpressionBuilder Between(string column, string table, long lowBound, long hightBound) => Add(Factory.Between(column, table, lowBound, hightBound));
		public ExpressionBuilder Between(string column, string table, float lowBound, float hightBound) => Add(Factory.Between(column, table, lowBound, hightBound));
		public ExpressionBuilder Between(string column, string table, double lowBound, double hightBound) => Add(Factory.Between(column, table, lowBound, hightBound));
		public ExpressionBuilder Between(string column, string table, decimal lowBound, decimal hightBound) => Add(Factory.Between(column, table, lowBound, hightBound));
		public ExpressionBuilder Between(string column, string table, DateTime lowBound, DateTime hightBound, string? format = null) => Add(Factory.Between(column, table, lowBound, hightBound, format));
		public ExpressionBuilder Between(string column, string table, string lowBound, string hightBound) => Add(Factory.Between(column, table, lowBound, hightBound));
		public ExpressionBuilder Between(string column, string table, IExpression lowBound, IExpression hightBound) => Add(Factory.Between(column, table, lowBound, hightBound));
		public ExpressionBuilder Between(string column, string table, Func<ExpressionFactory, IExpression> lowBoundFunction, Func<ExpressionFactory, IExpression> hightBoundFunction) => Add(Factory.Between(column, table, lowBoundFunction, hightBoundFunction));

		public ExpressionBuilder Between(string column, ISource source, sbyte lowBound, sbyte hightBound) => Add(Factory.Between(column, source, lowBound, hightBound));
		public ExpressionBuilder Between(string column, ISource source, short lowBound, short hightBound) => Add(Factory.Between(column, source, lowBound, hightBound));
		public ExpressionBuilder Between(string column, ISource source, int lowBound, int hightBound) => Add(Factory.Between(column, source, lowBound, hightBound));
		public ExpressionBuilder Between(string column, ISource source, long lowBound, long hightBound) => Add(Factory.Between(column, source, lowBound, hightBound));
		public ExpressionBuilder Between(string column, ISource source, float lowBound, float hightBound) => Add(Factory.Between(column, source, lowBound, hightBound));
		public ExpressionBuilder Between(string column, ISource source, double lowBound, double hightBound) => Add(Factory.Between(column, source, lowBound, hightBound));
		public ExpressionBuilder Between(string column, ISource source, decimal lowBound, decimal hightBound) => Add(Factory.Between(column, source, lowBound, hightBound));
		public ExpressionBuilder Between(string column, ISource source, DateTime lowBound, DateTime hightBound, string? format = null) => Add(Factory.Between(column, source, lowBound, hightBound, format));
		public ExpressionBuilder Between(string column, ISource source, string lowBound, string hightBound) => Add(Factory.Between(column, source, lowBound, hightBound));
		public ExpressionBuilder Between(string column, ISource source, IExpression lowBound, IExpression hightBound) => Add(Factory.Between(column, source, lowBound, hightBound));
		public ExpressionBuilder Between(string column, ISource source, Func<ExpressionFactory, IExpression> lowBoundFunction, Func<ExpressionFactory, IExpression> hightBoundFunction) => Add(Factory.Between(column, source, lowBoundFunction, hightBoundFunction));

		#endregion BetweenCondition methods

		#endregion Conditions methods

		#region Expressions methods

		#region PlusEpression methods

		public ExpressionBuilder Plus(params IExpression[] expressions) => Add(Factory.Plus(expressions));
		public ExpressionBuilder Plus(Action<ExpressionBuilder> action) => Add(Factory.Plus(action));
		public ExpressionBuilder Plus(IEnumerable<IExpression> expressions) => Add(Factory.Plus(expressions));

		#endregion PlusExpression methods

		#region MinusExpression methods

		public ExpressionBuilder Minus(params IExpression[] expressions) => Add(Factory.Minus(expressions));
		public ExpressionBuilder Minus(Action<ExpressionBuilder> action) => Add(Factory.Minus(action));
		public ExpressionBuilder Minus(IEnumerable<IExpression> expressions) => Add(Factory.Minus(expressions));

		#endregion MinusExpression methods

		#region MultiplyExpression methods

		public ExpressionBuilder Multiply(params IExpression[] expressions) => Add(Factory.Multiply(expressions));
		public ExpressionBuilder Multiply(Action<ExpressionBuilder> action) => Add(Factory.Multiply(action));
		public ExpressionBuilder Multiply(IEnumerable<IExpression> expressions) => Add(Factory.Multiply(expressions));

		#endregion MultiplyExpression methods

		#region DivideExpression methods

		public ExpressionBuilder Divide(params IExpression[] expressions) => Add(Factory.Divide(expressions));
		public ExpressionBuilder Divide(Action<ExpressionBuilder> action) => Add(Factory.Divide(action));
		public ExpressionBuilder Divide(IEnumerable<IExpression> expressions) => Add(Factory.Divide(expressions));

		#endregion DivideExpression methods

		#region Expression methods

		public ExpressionBuilder Expression(IExpression expression) => Add(expression);
		public ExpressionBuilder Expression(Func<ExpressionFactory, IExpression> function) => Add(Factory.Expression(function));

		#endregion Expression methods

		#region GeneralCaseExpression methods

		public ExpressionBuilder Case(Action<GeneralCaseBuilder> caseBuildMethod) => Add(Factory.Case(caseBuildMethod));

		#endregion GeneralCaseExpression methods

		#region SimpleCaseExpression methods

		public ExpressionBuilder Case(string column, Action<SimpleCaseBuilder> caseBuildMethod) => Add(Factory.Case(column, caseBuildMethod));
		public ExpressionBuilder Case(string column, string table, Action<SimpleCaseBuilder> caseBuildMethod) => Add(Factory.Case(column, table, caseBuildMethod));
		public ExpressionBuilder Case(string column, ISource source, Action<SimpleCaseBuilder> caseBuildMethod) => Add(Factory.Case(column, source, caseBuildMethod));
		public ExpressionBuilder Case(IExpression expression, Action<SimpleCaseBuilder> caseBuildMethod) => Add(Factory.Case(expression, caseBuildMethod));
		public ExpressionBuilder Case(Func<ExpressionBuilder, IExpression> expressionFunction, Action<SimpleCaseBuilder> caseBuildMethod) => Add(Factory.Case(expressionFunction, caseBuildMethod));

		#endregion SimpleCaseExpression methods

		#endregion Expressions methods

		#region Functions methods

		#region CoalesceFunction methods

		public ExpressionBuilder Coalesce(string column, sbyte value) => Add(Factory.Coalesce(column, value));
		public ExpressionBuilder Coalesce(string column, short value) => Add(Factory.Coalesce(column, value));
		public ExpressionBuilder Coalesce(string column, int value) => Add(Factory.Coalesce(column, value));
		public ExpressionBuilder Coalesce(string column, long value) => Add(Factory.Coalesce(column, value));
		public ExpressionBuilder Coalesce(string column, float value) => Add(Factory.Coalesce(column, value));
		public ExpressionBuilder Coalesce(string column, double value) => Add(Factory.Coalesce(column, value));
		public ExpressionBuilder Coalesce(string column, DateTime value, string? format = null) => Add(Factory.Coalesce(column, value, format));
		public ExpressionBuilder Coalesce(string column, string value) => Add(Factory.Coalesce(column, value));
		public ExpressionBuilder Coalesce(string column, Func<ExpressionFactory, IExpression> function) => Add(Factory.Coalesce(column, function));
		public ExpressionBuilder Coalesce(string column, IExpression defaultValue) => Add(Factory.Coalesce(column, defaultValue));

		public ExpressionBuilder Coalesce(string column, string table, sbyte value) => Add(Factory.Coalesce(column, table, value));
		public ExpressionBuilder Coalesce(string column, string table, short value) => Add(Factory.Coalesce(column, table, value));
		public ExpressionBuilder Coalesce(string column, string table, int value) => Add(Factory.Coalesce(column, table, value));
		public ExpressionBuilder Coalesce(string column, string table, long value) => Add(Factory.Coalesce(column, table, value));
		public ExpressionBuilder Coalesce(string column, string table, float value) => Add(Factory.Coalesce(column, table, value));
		public ExpressionBuilder Coalesce(string column, string table, double value) => Add(Factory.Coalesce(column, table, value));
		public ExpressionBuilder Coalesce(string column, string table, DateTime value, string? format = null) => Add(Factory.Coalesce(column, table, value, format));
		public ExpressionBuilder Coalesce(string column, string table, string value) => Add(Factory.Coalesce(column, table, value));
		public ExpressionBuilder Coalesce(string column, string table, Func<ExpressionFactory, IExpression> function) => Add(Factory.Coalesce(column, table, function));
		public ExpressionBuilder Coalesce(string column, string table, IExpression defaultValue) => Add(Factory.Coalesce(column, table, defaultValue));

		public ExpressionBuilder Coalesce(string column, ISource source, sbyte value) => Add(Factory.Coalesce(column, source, value));
		public ExpressionBuilder Coalesce(string column, ISource source, short value) => Add(Factory.Coalesce(column, source, value));
		public ExpressionBuilder Coalesce(string column, ISource source, int value) => Add(Factory.Coalesce(column, source, value));
		public ExpressionBuilder Coalesce(string column, ISource source, long value) => Add(Factory.Coalesce(column, source, value));
		public ExpressionBuilder Coalesce(string column, ISource source, float value) => Add(Factory.Coalesce(column, source, value));
		public ExpressionBuilder Coalesce(string column, ISource source, double value) => Add(Factory.Coalesce(column, source, value));
		public ExpressionBuilder Coalesce(string column, ISource source, DateTime value, string? format = null) => Add(Factory.Coalesce(column, source, value, format));
		public ExpressionBuilder Coalesce(string column, ISource source, string value) => Add(Factory.Coalesce(column, source, value));
		public ExpressionBuilder Coalesce(string column, ISource source, Func<ExpressionFactory, IExpression> function) => Add(Factory.Coalesce(column, source, function));
		public ExpressionBuilder Coalesce(string column, ISource source, IExpression defaultValue) => Add(Factory.Coalesce(column, source, defaultValue));

		public ExpressionBuilder Coalesce(Func<ExpressionFactory, IColumn> columnFunction, sbyte value) => Add(Factory.Coalesce(columnFunction, value));
		public ExpressionBuilder Coalesce(Func<ExpressionFactory, IColumn> columnFunction, short value) => Add(Factory.Coalesce(columnFunction, value));
		public ExpressionBuilder Coalesce(Func<ExpressionFactory, IColumn> columnFunction, int value) => Add(Factory.Coalesce(columnFunction, value));
		public ExpressionBuilder Coalesce(Func<ExpressionFactory, IColumn> columnFunction, long value) => Add(Factory.Coalesce(columnFunction, value));
		public ExpressionBuilder Coalesce(Func<ExpressionFactory, IColumn> columnFunction, float value) => Add(Factory.Coalesce(columnFunction, value));
		public ExpressionBuilder Coalesce(Func<ExpressionFactory, IColumn> columnFunction, double value) => Add(Factory.Coalesce(columnFunction, value));
		public ExpressionBuilder Coalesce(Func<ExpressionFactory, IColumn> columnFunction, DateTime value, string? format = null) => Add(Factory.Coalesce(columnFunction, value, format));
		public ExpressionBuilder Coalesce(Func<ExpressionFactory, IColumn> columnFunction, string value) => Add(Factory.Coalesce(columnFunction, value));
		public ExpressionBuilder Coalesce(Func<ExpressionFactory, IColumn> columnFunction, Func<ExpressionFactory, IExpression> function) => Add(Factory.Coalesce(columnFunction, function));
		public ExpressionBuilder Coalesce(Func<ExpressionFactory, IColumn> columnFunction, IExpression defaultValue) => Add(Factory.Coalesce(columnFunction, defaultValue));

		public ExpressionBuilder Coalesce(IColumn column, sbyte value) => Add(Factory.Coalesce(column, value));
		public ExpressionBuilder Coalesce(IColumn column, short value) => Add(Factory.Coalesce(column, value));
		public ExpressionBuilder Coalesce(IColumn column, int value) => Add(Factory.Coalesce(column, value));
		public ExpressionBuilder Coalesce(IColumn column, long value) => Add(Factory.Coalesce(column, value));
		public ExpressionBuilder Coalesce(IColumn column, float value) => Add(Factory.Coalesce(column, value));
		public ExpressionBuilder Coalesce(IColumn column, double value) => Add(Factory.Coalesce(column, value));
		public ExpressionBuilder Coalesce(IColumn column, DateTime value, string? format = null) => Add(Factory.Coalesce(column, value, format));
		public ExpressionBuilder Coalesce(IColumn column, string value) => Add(Factory.Coalesce(column, value));
		public ExpressionBuilder Coalesce(IColumn column, Func<ExpressionFactory, IExpression> function) => Add(Factory.Coalesce(column, function));
		public ExpressionBuilder Coalesce(IColumn column, IExpression defaultValue) => Add(Factory.Coalesce(column, defaultValue));

		#endregion CoalesceFunction methods

		#region ConcatFunction methods

		public ExpressionBuilder Concat(params IExpression[] expressions) => Add(Factory.Concat(expressions));
		public ExpressionBuilder Concat(Action<ExpressionBuilder> action) => Add(Factory.Concat(action));
		public ExpressionBuilder Concat(IEnumerable<IExpression> expressions) => Add(Factory.Concat(expressions));

		#endregion ConcatFunction methods

		#region CountFunction methods

		public ExpressionBuilder Count(string column) => Add(Factory.Count(column));
		public ExpressionBuilder Count(string column, string table) => Add(Factory.Count(column, table));
		public ExpressionBuilder Count(string column, ISource source) => Add(Factory.Count(column, source));
		public ExpressionBuilder Count(Func<ExpressionFactory, IColumn> function) => Add(Factory.Count(function));
		public ExpressionBuilder Count(IColumn column) => Add(Factory.Count(column));

		#endregion CountFunction methods

		#region Function methods

		public ExpressionBuilder Function(string name) => Add(Factory.Function(name));
		public ExpressionBuilder Function(string name, params IExpression[] parameters) => Add(Factory.Function(name, parameters));
		public ExpressionBuilder Function(string name, IEnumerable<IExpression>? parameters) => Add(Factory.Function(name, parameters));
		public ExpressionBuilder Function(string name, Action<ExpressionBuilder> action) => Add(Factory.Function(name, action));

		#endregion Function methods

		#region MaxFunction methods

		public ExpressionBuilder Max(string column) => Add(Factory.Max(column));
		public ExpressionBuilder Max(string column, string table) => Add(Factory.Max(column, table));
		public ExpressionBuilder Max(string column, ISource source) => Add(Factory.Max(column, source));
		public ExpressionBuilder Max(Func<ExpressionFactory, IColumn> function) => Add(Factory.Max(function));
		public ExpressionBuilder Max(IColumn column) => Add(Factory.Max(column));

		#endregion MaxFunction methods

		#region MinFunction methods

		public ExpressionBuilder Min(string column) => Add(Factory.Min(column));
		public ExpressionBuilder Min(string column, string table) => Add(Factory.Min(column, table));
		public ExpressionBuilder Min(string column, ISource source) => Add(Factory.Min(column, source));
		public ExpressionBuilder Min(Func<ExpressionFactory, IColumn> function) => Add(Factory.Min(function));
		public ExpressionBuilder Min(IColumn column) => Add(Factory.Min(column));

		#endregion MinFunction methods

		#region SumFunction methods

		public ExpressionBuilder Sum(string column) => Add(Factory.Sum(column));
		public ExpressionBuilder Sum(string column, string table) => Add(Factory.Sum(column, table));
		public ExpressionBuilder Sum(string column, ISource source) => Add(Factory.Sum(column, source));
		public ExpressionBuilder Sum(Func<ExpressionFactory, IColumn> function) => Add(Factory.Sum(function));
		public ExpressionBuilder Sum(IColumn column) => Add(Factory.Sum(column));

		#endregion SumFunction methods

		#endregion Functions methods

		#region Parameter methods

		public ExpressionBuilder Parameter(string name) => Add(Factory.Parameter(name));

		#endregion Parameter methods

		#region Values methods

		#region Int8Value methods

		public ExpressionBuilder Int8(sbyte value) => Add(Factory.Int8(value));
		public ExpressionBuilder Int8(short value) => Add(Factory.Int8(value));
		public ExpressionBuilder Int8(int value) => Add(Factory.Int8(value));
		public ExpressionBuilder Int8(long value) => Add(Factory.Int8(value));
		public ExpressionBuilder Int8(float value) => Add(Factory.Int8(value));
		public ExpressionBuilder Int8(double value) => Add(Factory.Int8(value));
		public ExpressionBuilder Int8(decimal value) => Add(Factory.Int8(value));

		public ExpressionBuilder Int8(sbyte? value) => Add(Factory.Int8(value));
		public ExpressionBuilder Int8(short? value) => Add(Factory.Int8(value));
		public ExpressionBuilder Int8(int? value) => Add(Factory.Int8(value));
		public ExpressionBuilder Int8(long? value) => Add(Factory.Int8(value));
		public ExpressionBuilder Int8(float? value) => Add(Factory.Int8(value));
		public ExpressionBuilder Int8(double? value) => Add(Factory.Int8(value));
		public ExpressionBuilder Int8(decimal? value) => Add(Factory.Int8(value));

		#endregion Int8Value methods

		#region Int16Value methods

		public ExpressionBuilder Int16(short value) => Add(Factory.Int16(value));
		public ExpressionBuilder Int16(int value) => Add(Factory.Int16(value));
		public ExpressionBuilder Int16(long value) => Add(Factory.Int16(value));
		public ExpressionBuilder Int16(float value) => Add(Factory.Int16(value));
		public ExpressionBuilder Int16(double value) => Add(Factory.Int16(value));
		public ExpressionBuilder Int16(decimal value) => Add(Factory.Int16(value));

		public ExpressionBuilder Int16(short? value) => Add(Factory.Int16(value));
		public ExpressionBuilder Int16(int? value) => Add(Factory.Int16(value));
		public ExpressionBuilder Int16(long? value) => Add(Factory.Int16(value));
		public ExpressionBuilder Int16(float? value) => Add(Factory.Int16(value));
		public ExpressionBuilder Int16(double? value) => Add(Factory.Int16(value));
		public ExpressionBuilder Int16(decimal? value) => Add(Factory.Int16(value));

		#endregion Int16Value methods

		#region Int32Value methods

		public ExpressionBuilder Int32(int value) => Add(Factory.Int32(value));
		public ExpressionBuilder Int32(long value) => Add(Factory.Int32(value));
		public ExpressionBuilder Int32(float value) => Add(Factory.Int32(value));
		public ExpressionBuilder Int32(double value) => Add(Factory.Int32(value));
		public ExpressionBuilder Int32(decimal value) => Add(Factory.Int32(value));

		public ExpressionBuilder Int32(int? value) => Add(Factory.Int32(value));
		public ExpressionBuilder Int32(long? value) => Add(Factory.Int32(value));
		public ExpressionBuilder Int32(float? value) => Add(Factory.Int32(value));
		public ExpressionBuilder Int32(double? value) => Add(Factory.Int32(value));
		public ExpressionBuilder Int32(decimal? value) => Add(Factory.Int32(value));

		#endregion Int32Value methods

		#region Int64Value methods

		public ExpressionBuilder Int64(long value) => Add(Factory.Int64(value));
		public ExpressionBuilder Int64(float value) => Add(Factory.Int64(value));
		public ExpressionBuilder Int64(double value) => Add(Factory.Int64(value));
		public ExpressionBuilder Int64(decimal value) => Add(Factory.Int64(value));

		public ExpressionBuilder Int64(long? value) => Add(Factory.Int64(value));
		public ExpressionBuilder Int64(float? value) => Add(Factory.Int64(value));
		public ExpressionBuilder Int64(double? value) => Add(Factory.Int64(value));
		public ExpressionBuilder Int64(decimal? value) => Add(Factory.Int64(value));

		#endregion Int64Value methods

		#region FloatValue methods

		public ExpressionBuilder Float(float value) => Add(Factory.Float(value));
		public ExpressionBuilder Float(double value) => Add(Factory.Float(value));
		public ExpressionBuilder Float(decimal value) => Add(Factory.Float(value));

		public ExpressionBuilder Float(float? value) => Add(Factory.Float(value));
		public ExpressionBuilder Float(double? value) => Add(Factory.Float(value));
		public ExpressionBuilder Float(decimal? value) => Add(Factory.Float(value));

		#endregion FloatValue methods

		#region DoubleValue methods

		public ExpressionBuilder Double(double value) => Add(Factory.Double(value));
		public ExpressionBuilder Double(decimal value) => Add(Factory.Double(value));

		public ExpressionBuilder Double(double? value) => Add(Factory.Double(value));
		public ExpressionBuilder Double(decimal? value) => Add(Factory.Double(value));

		#endregion DoubleValue methods

		#region DecimalValue methods

		public ExpressionBuilder Decimal(decimal value) => Add(Factory.Decimal(value));
		public ExpressionBuilder Decimal(decimal? value) => Add(Factory.Decimal(value));

		#endregion DecimalValue methods

		#region DateTimeValue methods

		public ExpressionBuilder DateTime(DateTime value, string? format = null) => Add(Factory.DateTime(value, format));
		public ExpressionBuilder DateTime(DateTime? value, string? format = null) => Add(Factory.DateTime(value, format));

		#endregion DateTimeValue methods

		#region StringValue methods

		public ExpressionBuilder String(string? value) => Add(Factory.String(value));
		public ExpressionBuilder String(object? value) => Add(Factory.String(value));

		#endregion StringValue methods

		#region NullValue methods

		public ExpressionBuilder Null() => Add(Factory.Null());

		#endregion NullValue methods

		#endregion Values methods

		public List<IExpression> Build() => _expressions;

		private ExpressionBuilder Add(IExpression expression)
		{
			_expressions.Add(expression);

			return this;
		}
	}
}
