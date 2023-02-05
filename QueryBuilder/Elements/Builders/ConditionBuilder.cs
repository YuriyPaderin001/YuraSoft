using System;
using System.Collections.Generic;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public class ConditionBuilder
	{
		public readonly ExpressionFactory Factory = ExpressionFactory.Instance;
		public readonly List<ICondition> Conditions = new List<ICondition>();

		#region And methods

		public ConditionBuilder And(params ICondition[] conditions) => Add(Factory.And(conditions));
		public ConditionBuilder And(IEnumerable<ICondition> conditions) => Add(Factory.And(conditions));
		public ConditionBuilder And(ConditionBuilder builder) => Add(Factory.And(builder.Conditions));
		public ConditionBuilder And(Action<ConditionBuilder> buildConditionMethod) => Add(Factory.And(buildConditionMethod));

		#endregion And methods

		#region Or methods

		public ConditionBuilder Or(params ICondition[] conditions) => Add(Factory.Or(conditions));
		public ConditionBuilder Or(IEnumerable<ICondition> conditions) => Add(Factory.Or(conditions));
		public ConditionBuilder Or(ConditionBuilder builder) => Add(Factory.Or(builder.Conditions));
		public ConditionBuilder Or(Action<ConditionBuilder> buildConditionMethod) => Add(Factory.Or(buildConditionMethod));

		#endregion Or methods

		#region Equal methods

		public ConditionBuilder Equal(IExpression expression, sbyte value) => Add(Factory.Equal(expression, value));
		public ConditionBuilder Equal(IExpression expression, short value) => Add(Factory.Equal(expression, value));
		public ConditionBuilder Equal(IExpression expression, int value) => Add(Factory.Equal(expression, value));
		public ConditionBuilder Equal(IExpression expression, long value) => Add(Factory.Equal(expression, value));
		public ConditionBuilder Equal(IExpression expression, float value) => Add(Factory.Equal(expression, value));
		public ConditionBuilder Equal(IExpression expression, double value) => Add(Factory.Equal(expression, value));
		public ConditionBuilder Equal(IExpression expression, decimal value) => Add(Factory.Equal(expression, value));
		public ConditionBuilder Equal(IExpression expression, DateTime value, string? format = null) => Add(Factory.Equal(expression, value, format));
		public ConditionBuilder Equal(IExpression expression, string value) => Add(Factory.Equal(expression, value));
		public ConditionBuilder Equal(IExpression expression1, IExpression expression2) => Add(Factory.Equal(expression1, expression2));
		public ConditionBuilder Equal(IExpression expression, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Equal(expression, expressionFunction));

		public ConditionBuilder Equal(string column, sbyte value) => Add(Factory.Equal(column, value));
		public ConditionBuilder Equal(string column, short value) => Add(Factory.Equal(column, value));
		public ConditionBuilder Equal(string column, int value) => Add(Factory.Equal(column, value));
		public ConditionBuilder Equal(string column, long value) => Add(Factory.Equal(column, value));
		public ConditionBuilder Equal(string column, float value) => Add(Factory.Equal(column, value));
		public ConditionBuilder Equal(string column, double value) => Add(Factory.Equal(column, value));
		public ConditionBuilder Equal(string column, decimal value) => Add(Factory.Equal(column, value));
		public ConditionBuilder Equal(string column, DateTime value, string? format = null) => Add(Factory.Equal(column, value, format));
		public ConditionBuilder Equal(string column, string value) => Add(Factory.Equal(column, value));
		public ConditionBuilder Equal(string column, IExpression expression) => Add(Factory.Equal(column, expression));
		public ConditionBuilder Equal(string column, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Equal(column, expressionFunction));

		public ConditionBuilder Equal(string column, string table, sbyte value) => Add(Factory.Equal(column, table, value));
		public ConditionBuilder Equal(string column, string table, short value) => Add(Factory.Equal(column, table, value));
		public ConditionBuilder Equal(string column, string table, int value) => Add(Factory.Equal(column, table, value));
		public ConditionBuilder Equal(string column, string table, long value) => Add(Factory.Equal(column, table, value));
		public ConditionBuilder Equal(string column, string table, float value) => Add(Factory.Equal(column, table, value));
		public ConditionBuilder Equal(string column, string table, double value) => Add(Factory.Equal(column, table, value));
		public ConditionBuilder Equal(string column, string table, decimal value) => Add(Factory.Equal(column, table, value));
		public ConditionBuilder Equal(string column, string table, DateTime value, string? format = null) => Add(Factory.Equal(column, table, value, format));
		public ConditionBuilder Equal(string column, string table, string value) => Add(Factory.Equal(column, table, value));
		public ConditionBuilder Equal(string column, string table, IExpression expression) => Add(Factory.Equal(column, table, expression));
		public ConditionBuilder Equal(string column, string table, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Equal(column, table, expressionFunction));

		public ConditionBuilder Equal(string column, ISource source, sbyte value) => Add(Factory.Equal(column, source, value));
		public ConditionBuilder Equal(string column, ISource source, short value) => Add(Factory.Equal(column, source, value));
		public ConditionBuilder Equal(string column, ISource source, int value) => Add(Factory.Equal(column, source, value));
		public ConditionBuilder Equal(string column, ISource source, long value) => Add(Factory.Equal(column, source, value));
		public ConditionBuilder Equal(string column, ISource source, float value) => Add(Factory.Equal(column, source, value));
		public ConditionBuilder Equal(string column, ISource source, double value) => Add(Factory.Equal(column, source, value));
		public ConditionBuilder Equal(string column, ISource source, decimal value) => Add(Factory.Equal(column, source, value));
		public ConditionBuilder Equal(string column, ISource source, DateTime value, string? format = null) => Add(Factory.Equal(column, source, value, format));
		public ConditionBuilder Equal(string column, ISource source, string value) => Add(Factory.Equal(column, source, value));
		public ConditionBuilder Equal(string column, ISource source, IExpression expression) => Add(Factory.Equal(column, source, expression));
		public ConditionBuilder Equal(string column, ISource source, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Equal(column, source, expressionFunction));

		public ConditionBuilder Equal(string column1, string table1, string column2, string table2) => Add(Factory.Equal(column1, table1, column2, table2));
		public ConditionBuilder Equal(string column1, string table1, string column2, ISource source2) => Add(Factory.Equal(column1, table1, column2, source2));
		public ConditionBuilder Equal(string column1, ISource source1, string column2, string table2) => Add(Factory.Equal(column1, source1, column2, table2));
		public ConditionBuilder Equal(string column1, ISource source1, string column2, ISource source2) => Add(Factory.Equal(column1, source1, column2, source2));
		public ConditionBuilder Equal(Func<ExpressionFactory, IExpression> expressionFunction1, Func<ExpressionFactory, IExpression> expressionFunction2) => Add(Factory.Equal(expressionFunction1, expressionFunction2));

		#endregion Equal methods

		#region NotEqual methods

		public ConditionBuilder NotEqual(IExpression expression, sbyte value) => Add(Factory.NotEqual(expression, value));
		public ConditionBuilder NotEqual(IExpression expression, short value) => Add(Factory.NotEqual(expression, value));
		public ConditionBuilder NotEqual(IExpression expression, int value) => Add(Factory.NotEqual(expression, value));
		public ConditionBuilder NotEqual(IExpression expression, long value) => Add(Factory.NotEqual(expression, value));
		public ConditionBuilder NotEqual(IExpression expression, float value) => Add(Factory.NotEqual(expression, value));
		public ConditionBuilder NotEqual(IExpression expression, double value) => Add(Factory.NotEqual(expression, value));
		public ConditionBuilder NotEqual(IExpression expression, decimal value) => Add(Factory.NotEqual(expression, value));
		public ConditionBuilder NotEqual(IExpression expression, DateTime value, string? format = null) => Add(Factory.NotEqual(expression, value, format));
		public ConditionBuilder NotEqual(IExpression expression, string value) => Add(Factory.NotEqual(expression, value));
		public ConditionBuilder NotEqual(IExpression expression1, IExpression expression2) => Add(Factory.NotEqual(expression1, expression2));
		public ConditionBuilder NotEqual(IExpression expression, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.NotEqual(expression, expressionFunction));

		public ConditionBuilder NotEqual(string column, sbyte value) => Add(Factory.NotEqual(column, value));
		public ConditionBuilder NotEqual(string column, short value) => Add(Factory.NotEqual(column, value));
		public ConditionBuilder NotEqual(string column, int value) => Add(Factory.NotEqual(column, value));
		public ConditionBuilder NotEqual(string column, long value) => Add(Factory.NotEqual(column, value));
		public ConditionBuilder NotEqual(string column, float value) => Add(Factory.NotEqual(column, value));
		public ConditionBuilder NotEqual(string column, double value) => Add(Factory.NotEqual(column, value));
		public ConditionBuilder NotEqual(string column, decimal value) => Add(Factory.NotEqual(column, value));
		public ConditionBuilder NotEqual(string column, DateTime value, string? format = null) => Add(Factory.NotEqual(column, value, format));
		public ConditionBuilder NotEqual(string column, string value) => Add(Factory.NotEqual(column, value));
		public ConditionBuilder NotEqual(string column, IExpression expression) => Add(Factory.NotEqual(column, expression));
		public ConditionBuilder NotEqual(string column, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.NotEqual(column, expressionFunction));

		public ConditionBuilder NotEqual(string column, string table, sbyte value) => Add(Factory.NotEqual(column, table, value));
		public ConditionBuilder NotEqual(string column, string table, short value) => Add(Factory.NotEqual(column, table, value));
		public ConditionBuilder NotEqual(string column, string table, int value) => Add(Factory.NotEqual(column, table, value));
		public ConditionBuilder NotEqual(string column, string table, long value) => Add(Factory.NotEqual(column, table, value));
		public ConditionBuilder NotEqual(string column, string table, float value) => Add(Factory.NotEqual(column, table, value));
		public ConditionBuilder NotEqual(string column, string table, double value) => Add(Factory.NotEqual(column, table, value));
		public ConditionBuilder NotEqual(string column, string table, decimal value) => Add(Factory.NotEqual(column, table, value));
		public ConditionBuilder NotEqual(string column, string table, DateTime value, string? format = null) => Add(Factory.NotEqual(column, table, value, format));
		public ConditionBuilder NotEqual(string column, string table, string value) => Add(Factory.NotEqual(column, table, value));
		public ConditionBuilder NotEqual(string column, string table, IExpression expression) => Add(Factory.NotEqual(column, table, expression));
		public ConditionBuilder NotEqual(string column, string table, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.NotEqual(column, table, expressionFunction));

		public ConditionBuilder NotEqual(string column, ISource source, sbyte value) => Add(Factory.NotEqual(column, source, value));
		public ConditionBuilder NotEqual(string column, ISource source, short value) => Add(Factory.NotEqual(column, source, value));
		public ConditionBuilder NotEqual(string column, ISource source, int value) => Add(Factory.NotEqual(column, source, value));
		public ConditionBuilder NotEqual(string column, ISource source, long value) => Add(Factory.NotEqual(column, source, value));
		public ConditionBuilder NotEqual(string column, ISource source, float value) => Add(Factory.NotEqual(column, source, value));
		public ConditionBuilder NotEqual(string column, ISource source, double value) => Add(Factory.NotEqual(column, source, value));
		public ConditionBuilder NotEqual(string column, ISource source, decimal value) => Add(Factory.NotEqual(column, source, value));
		public ConditionBuilder NotEqual(string column, ISource source, DateTime value, string? format = null) => Add(Factory.NotEqual(column, source, value, format));
		public ConditionBuilder NotEqual(string column, ISource source, string value) => Add(Factory.NotEqual(column, source, value));
		public ConditionBuilder NotEqual(string column, ISource source, IExpression expression) => Add(Factory.NotEqual(column, source, expression));
		public ConditionBuilder NotEqual(string column, ISource source, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.NotEqual(column, source, expressionFunction));

		public ConditionBuilder NotEqual(string column1, string table1, string column2, string table2) => Add(Factory.NotEqual(column1, table1, column2, table2));
		public ConditionBuilder NotEqual(string column1, string table1, string column2, ISource source2) => Add(Factory.NotEqual(column1, table1, column2, source2));
		public ConditionBuilder NotEqual(string column1, ISource source1, string column2, string table2) => Add(Factory.NotEqual(column1, source1, column2, table2));
		public ConditionBuilder NotEqual(string column1, ISource source1, string column2, ISource source2) => Add(Factory.NotEqual(column1, source1, column2, source2));
		public ConditionBuilder NotEqual(Func<ExpressionFactory, IExpression> expressionFunction1, Func<ExpressionFactory, IExpression> expressionFunction2) => Add(Factory.NotEqual(expressionFunction1, expressionFunction2));

		#endregion NotEqual methods

		#region Exists methods
		
		public ConditionBuilder Exists(string column, Select select) => Add(Factory.Exists(column, select));
		public ConditionBuilder Exists(string column, string table, Select select) => Add(Factory.Exists(column, table, select));
		public ConditionBuilder Exists(string column, ISource source, Select select) => Add(Factory.Exists(column, source, select));
		public ConditionBuilder Exists(IExpression expression, Select select) => Add(Factory.Exists(expression, select));
		public ConditionBuilder Exists(Func<ExpressionFactory, IExpression> expressionFunction, Select select) => Add(Factory.Exists(expressionFunction, select));

		#endregion Exists methods

		#region NotExists methods

		public ConditionBuilder NotExists(string column, Select select) => Add(Factory.NotExists(column, select));
		public ConditionBuilder NotExists(string column, string table, Select select) => Add(Factory.NotExists(column, table, select));
		public ConditionBuilder NotExists(string column, ISource source, Select select) => Add(Factory.NotExists(column, source, select));
		public ConditionBuilder NotExists(IExpression expression, Select select) => Add(Factory.NotExists(expression, select));
		public ConditionBuilder NotExists(Func<ExpressionFactory, IExpression> expressionFunction, Select select) => Add(Factory.NotExists(expressionFunction, select));

		#endregion NotExists methods

		#region Greater methods

		public ConditionBuilder Greater(IExpression expression, sbyte value) => Add(Factory.Greater(expression, value));
		public ConditionBuilder Greater(IExpression expression, short value) => Add(Factory.Greater(expression, value));
		public ConditionBuilder Greater(IExpression expression, int value) => Add(Factory.Greater(expression, value));
		public ConditionBuilder Greater(IExpression expression, long value) => Add(Factory.Greater(expression, value));
		public ConditionBuilder Greater(IExpression expression, float value) => Add(Factory.Greater(expression, value));
		public ConditionBuilder Greater(IExpression expression, double value) => Add(Factory.Greater(expression, value));
		public ConditionBuilder Greater(IExpression expression, decimal value) => Add(Factory.Greater(expression, value));
		public ConditionBuilder Greater(IExpression expression, DateTime value, string? format = null) => Add(Factory.Greater(expression, value, format));
		public ConditionBuilder Greater(IExpression expression, string value) => Add(Factory.Greater(expression, value));
		public ConditionBuilder Greater(IExpression expression1, IExpression expression2) => Add(Factory.Greater(expression1, expression2));
		public ConditionBuilder Greater(IExpression expression, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Greater(expression, expressionFunction));

		public ConditionBuilder Greater(string column, sbyte value) => Add(Factory.Greater(column, value));
		public ConditionBuilder Greater(string column, short value) => Add(Factory.Greater(column, value));
		public ConditionBuilder Greater(string column, int value) => Add(Factory.Greater(column, value));
		public ConditionBuilder Greater(string column, long value) => Add(Factory.Greater(column, value));
		public ConditionBuilder Greater(string column, float value) => Add(Factory.Greater(column, value));
		public ConditionBuilder Greater(string column, double value) => Add(Factory.Greater(column, value));
		public ConditionBuilder Greater(string column, decimal value) => Add(Factory.Greater(column, value));
		public ConditionBuilder Greater(string column, DateTime value, string? format = null) => Add(Factory.Greater(column, value, format));
		public ConditionBuilder Greater(string column, string value) => Add(Factory.Greater(column, value));
		public ConditionBuilder Greater(string column, IExpression expression) => Add(Factory.Greater(column, expression));
		public ConditionBuilder Greater(string column, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Greater(column, expressionFunction));

		public ConditionBuilder Greater(string column, string table, sbyte value) => Add(Factory.Greater(column, table, value));
		public ConditionBuilder Greater(string column, string table, short value) => Add(Factory.Greater(column, table, value));
		public ConditionBuilder Greater(string column, string table, int value) => Add(Factory.Greater(column, table, value));
		public ConditionBuilder Greater(string column, string table, long value) => Add(Factory.Greater(column, table, value));
		public ConditionBuilder Greater(string column, string table, float value) => Add(Factory.Greater(column, table, value));
		public ConditionBuilder Greater(string column, string table, double value) => Add(Factory.Greater(column, table, value));
		public ConditionBuilder Greater(string column, string table, decimal value) => Add(Factory.Greater(column, table, value));
		public ConditionBuilder Greater(string column, string table, DateTime value, string? format = null) => Add(Factory.Greater(column, table, value, format));
		public ConditionBuilder Greater(string column, string table, string value) => Add(Factory.Greater(column, table, value));
		public ConditionBuilder Greater(string column, string table, IExpression expression) => Add(Factory.Greater(column, table, expression));
		public ConditionBuilder Greater(string column, string table, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Greater(column, table, expressionFunction));

		public ConditionBuilder Greater(string column, ISource source, sbyte value) => Add(Factory.Greater(column, source, value));
		public ConditionBuilder Greater(string column, ISource source, short value) => Add(Factory.Greater(column, source, value));
		public ConditionBuilder Greater(string column, ISource source, int value) => Add(Factory.Greater(column, source, value));
		public ConditionBuilder Greater(string column, ISource source, long value) => Add(Factory.Greater(column, source, value));
		public ConditionBuilder Greater(string column, ISource source, float value) => Add(Factory.Greater(column, source, value));
		public ConditionBuilder Greater(string column, ISource source, double value) => Add(Factory.Greater(column, source, value));
		public ConditionBuilder Greater(string column, ISource source, decimal value) => Add(Factory.Greater(column, source, value));
		public ConditionBuilder Greater(string column, ISource source, DateTime value, string? format = null) => Add(Factory.Greater(column, source, value, format));
		public ConditionBuilder Greater(string column, ISource source, string value) => Add(Factory.Greater(column, source, value));
		public ConditionBuilder Greater(string column, ISource source, IExpression expression) => Add(Factory.Greater(column, source, expression));
		public ConditionBuilder Greater(string column, ISource source, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Greater(column, source, expressionFunction));

		public ConditionBuilder Greater(string column1, string table1, string column2, string table2) => Add(Factory.Greater(column1, table1, column2, table2));
		public ConditionBuilder Greater(string column1, string table1, string column2, ISource source2) => Add(Factory.Greater(column1, table1, column2, source2));
		public ConditionBuilder Greater(string column1, ISource source1, string column2, string table2) => Add(Factory.Greater(column1, source1, column2, table2));
		public ConditionBuilder Greater(string column1, ISource source1, string column2, ISource source2) => Add(Factory.Greater(column1, source1, column2, source2));
		public ConditionBuilder Greater(Func<ExpressionFactory, IExpression> expressionFunction1, Func<ExpressionFactory, IExpression> expressionFunction2) => Add(Factory.Greater(expressionFunction1, expressionFunction2));

		#endregion Greater methods

		#region GreaterOrEqual methods

		public ConditionBuilder GreaterOrEqual(IExpression expression, sbyte value) => Add(Factory.GreaterOrEqual(expression, value));
		public ConditionBuilder GreaterOrEqual(IExpression expression, short value) => Add(Factory.GreaterOrEqual(expression, value));
		public ConditionBuilder GreaterOrEqual(IExpression expression, int value) => Add(Factory.GreaterOrEqual(expression, value));
		public ConditionBuilder GreaterOrEqual(IExpression expression, long value) => Add(Factory.GreaterOrEqual(expression, value));
		public ConditionBuilder GreaterOrEqual(IExpression expression, float value) => Add(Factory.GreaterOrEqual(expression, value));
		public ConditionBuilder GreaterOrEqual(IExpression expression, double value) => Add(Factory.GreaterOrEqual(expression, value));
		public ConditionBuilder GreaterOrEqual(IExpression expression, decimal value) => Add(Factory.GreaterOrEqual(expression, value));
		public ConditionBuilder GreaterOrEqual(IExpression expression, DateTime value, string? format = null) => Add(Factory.GreaterOrEqual(expression, value, format));
		public ConditionBuilder GreaterOrEqual(IExpression expression, string value) => Add(Factory.GreaterOrEqual(expression, value));
		public ConditionBuilder GreaterOrEqual(IExpression expression1, IExpression expression2) => Add(Factory.GreaterOrEqual(expression1, expression2));
		public ConditionBuilder GreaterOrEqual(IExpression expression, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.GreaterOrEqual(expression, expressionFunction));

		public ConditionBuilder GreaterOrEqual(string column, sbyte value) => Add(Factory.GreaterOrEqual(column, value));
		public ConditionBuilder GreaterOrEqual(string column, short value) => Add(Factory.GreaterOrEqual(column, value));
		public ConditionBuilder GreaterOrEqual(string column, int value) => Add(Factory.GreaterOrEqual(column, value));
		public ConditionBuilder GreaterOrEqual(string column, long value) => Add(Factory.GreaterOrEqual(column, value));
		public ConditionBuilder GreaterOrEqual(string column, float value) => Add(Factory.GreaterOrEqual(column, value));
		public ConditionBuilder GreaterOrEqual(string column, double value) => Add(Factory.GreaterOrEqual(column, value));
		public ConditionBuilder GreaterOrEqual(string column, decimal value) => Add(Factory.GreaterOrEqual(column, value));
		public ConditionBuilder GreaterOrEqual(string column, DateTime value, string? format = null) => Add(Factory.GreaterOrEqual(column, value, format));
		public ConditionBuilder GreaterOrEqual(string column, string value) => Add(Factory.GreaterOrEqual(column, value));
		public ConditionBuilder GreaterOrEqual(string column, IExpression expression) => Add(Factory.GreaterOrEqual(column, expression));
		public ConditionBuilder GreaterOrEqual(string column, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.GreaterOrEqual(column, expressionFunction));

		public ConditionBuilder GreaterOrEqual(string column, string table, sbyte value) => Add(Factory.GreaterOrEqual(column, table, value));
		public ConditionBuilder GreaterOrEqual(string column, string table, short value) => Add(Factory.GreaterOrEqual(column, table, value));
		public ConditionBuilder GreaterOrEqual(string column, string table, int value) => Add(Factory.GreaterOrEqual(column, table, value));
		public ConditionBuilder GreaterOrEqual(string column, string table, long value) => Add(Factory.GreaterOrEqual(column, table, value));
		public ConditionBuilder GreaterOrEqual(string column, string table, float value) => Add(Factory.GreaterOrEqual(column, table, value));
		public ConditionBuilder GreaterOrEqual(string column, string table, double value) => Add(Factory.GreaterOrEqual(column, table, value));
		public ConditionBuilder GreaterOrEqual(string column, string table, decimal value) => Add(Factory.GreaterOrEqual(column, table, value));
		public ConditionBuilder GreaterOrEqual(string column, string table, DateTime value, string? format = null) => Add(Factory.GreaterOrEqual(column, table, value, format));
		public ConditionBuilder GreaterOrEqual(string column, string table, string value) => Add(Factory.GreaterOrEqual(column, table, value));
		public ConditionBuilder GreaterOrEqual(string column, string table, IExpression expression) => Add(Factory.GreaterOrEqual(column, table, expression));
		public ConditionBuilder GreaterOrEqual(string column, string table, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.GreaterOrEqual(column, table, expressionFunction));

		public ConditionBuilder GreaterOrEqual(string column, ISource source, sbyte value) => Add(Factory.GreaterOrEqual(column, source, value));
		public ConditionBuilder GreaterOrEqual(string column, ISource source, short value) => Add(Factory.GreaterOrEqual(column, source, value));
		public ConditionBuilder GreaterOrEqual(string column, ISource source, int value) => Add(Factory.GreaterOrEqual(column, source, value));
		public ConditionBuilder GreaterOrEqual(string column, ISource source, long value) => Add(Factory.GreaterOrEqual(column, source, value));
		public ConditionBuilder GreaterOrEqual(string column, ISource source, float value) => Add(Factory.GreaterOrEqual(column, source, value));
		public ConditionBuilder GreaterOrEqual(string column, ISource source, double value) => Add(Factory.GreaterOrEqual(column, source, value));
		public ConditionBuilder GreaterOrEqual(string column, ISource source, decimal value) => Add(Factory.GreaterOrEqual(column, source, value));
		public ConditionBuilder GreaterOrEqual(string column, ISource source, DateTime value, string? format = null) => Add(Factory.GreaterOrEqual(column, source, value, format));
		public ConditionBuilder GreaterOrEqual(string column, ISource source, string value) => Add(Factory.GreaterOrEqual(column, source, value));
		public ConditionBuilder GreaterOrEqual(string column, ISource source, IExpression expression) => Add(Factory.GreaterOrEqual(column, source, expression));
		public ConditionBuilder GreaterOrEqual(string column, ISource source, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.GreaterOrEqual(column, source, expressionFunction));

		public ConditionBuilder GreaterOrEqual(string column1, string table1, string column2, string table2) => Add(Factory.GreaterOrEqual(column1, table1, column2, table2));
		public ConditionBuilder GreaterOrEqual(string column1, string table1, string column2, ISource source2) => Add(Factory.GreaterOrEqual(column1, table1, column2, source2));
		public ConditionBuilder GreaterOrEqual(string column1, ISource source1, string column2, string table2) => Add(Factory.GreaterOrEqual(column1, source1, column2, table2));
		public ConditionBuilder GreaterOrEqual(string column1, ISource source1, string column2, ISource source2) => Add(Factory.GreaterOrEqual(column1, source1, column2, source2));
		public ConditionBuilder GreaterOrEqual(Func<ExpressionFactory, IExpression> expressionFunction1, Func<ExpressionFactory, IExpression> expressionFunction2) => Add(Factory.GreaterOrEqual(expressionFunction1, expressionFunction2));

		#endregion GreaterOrEqual methods

		#region Less methods

		public ConditionBuilder Less(IExpression expression, sbyte value) => Add(Factory.Less(expression, value));
		public ConditionBuilder Less(IExpression expression, short value) => Add(Factory.Less(expression, value));
		public ConditionBuilder Less(IExpression expression, int value) => Add(Factory.Less(expression, value));
		public ConditionBuilder Less(IExpression expression, long value) => Add(Factory.Less(expression, value));
		public ConditionBuilder Less(IExpression expression, float value) => Add(Factory.Less(expression, value));
		public ConditionBuilder Less(IExpression expression, double value) => Add(Factory.Less(expression, value));
		public ConditionBuilder Less(IExpression expression, decimal value) => Add(Factory.Less(expression, value));
		public ConditionBuilder Less(IExpression expression, DateTime value, string? format = null) => Add(Factory.Less(expression, value, format));
		public ConditionBuilder Less(IExpression expression, string value) => Add(Factory.Less(expression, value));
		public ConditionBuilder Less(IExpression expression1, IExpression expression2) => Add(Factory.Less(expression1, expression2));
		public ConditionBuilder Less(IExpression expression, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Less(expression, expressionFunction));

		public ConditionBuilder Less(string column, sbyte value) => Add(Factory.Less(column, value));
		public ConditionBuilder Less(string column, short value) => Add(Factory.Less(column, value));
		public ConditionBuilder Less(string column, int value) => Add(Factory.Less(column, value));
		public ConditionBuilder Less(string column, long value) => Add(Factory.Less(column, value));
		public ConditionBuilder Less(string column, float value) => Add(Factory.Less(column, value));
		public ConditionBuilder Less(string column, double value) => Add(Factory.Less(column, value));
		public ConditionBuilder Less(string column, decimal value) => Add(Factory.Less(column, value));
		public ConditionBuilder Less(string column, DateTime value, string? format = null) => Add(Factory.Less(column, value, format));
		public ConditionBuilder Less(string column, string value) => Add(Factory.Less(column, value));
		public ConditionBuilder Less(string column, IExpression expression) => Add(Factory.Less(column, expression));
		public ConditionBuilder Less(string column, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Less(column, expressionFunction));

		public ConditionBuilder Less(string column, string table, sbyte value) => Add(Factory.Less(column, table, value));
		public ConditionBuilder Less(string column, string table, short value) => Add(Factory.Less(column, table, value));
		public ConditionBuilder Less(string column, string table, int value) => Add(Factory.Less(column, table, value));
		public ConditionBuilder Less(string column, string table, long value) => Add(Factory.Less(column, table, value));
		public ConditionBuilder Less(string column, string table, float value) => Add(Factory.Less(column, table, value));
		public ConditionBuilder Less(string column, string table, double value) => Add(Factory.Less(column, table, value));
		public ConditionBuilder Less(string column, string table, decimal value) => Add(Factory.Less(column, table, value));
		public ConditionBuilder Less(string column, string table, DateTime value, string? format = null) => Add(Factory.Less(column, table, value, format));
		public ConditionBuilder Less(string column, string table, string value) => Add(Factory.Less(column, table, value));
		public ConditionBuilder Less(string column, string table, IExpression expression) => Add(Factory.Less(column, table, expression));
		public ConditionBuilder Less(string column, string table, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Less(column, table, expressionFunction));

		public ConditionBuilder Less(string column, ISource source, sbyte value) => Add(Factory.Less(column, source, value));
		public ConditionBuilder Less(string column, ISource source, short value) => Add(Factory.Less(column, source, value));
		public ConditionBuilder Less(string column, ISource source, int value) => Add(Factory.Less(column, source, value));
		public ConditionBuilder Less(string column, ISource source, long value) => Add(Factory.Less(column, source, value));
		public ConditionBuilder Less(string column, ISource source, float value) => Add(Factory.Less(column, source, value));
		public ConditionBuilder Less(string column, ISource source, double value) => Add(Factory.Less(column, source, value));
		public ConditionBuilder Less(string column, ISource source, decimal value) => Add(Factory.Less(column, source, value));
		public ConditionBuilder Less(string column, ISource source, DateTime value, string? format = null) => Add(Factory.Less(column, source, value, format));
		public ConditionBuilder Less(string column, ISource source, string value) => Add(Factory.Less(column, source, value));
		public ConditionBuilder Less(string column, ISource source, IExpression expression) => Add(Factory.Less(column, source, expression));
		public ConditionBuilder Less(string column, ISource source, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.Less(column, source, expressionFunction));

		public ConditionBuilder Less(string column1, string table1, string column2, string table2) => Add(Factory.Less(column1, table1, column2, table2));
		public ConditionBuilder Less(string column1, string table1, string column2, ISource source2) => Add(Factory.Less(column1, table1, column2, source2));
		public ConditionBuilder Less(string column1, ISource source1, string column2, string table2) => Add(Factory.Less(column1, source1, column2, table2));
		public ConditionBuilder Less(string column1, ISource source1, string column2, ISource source2) => Add(Factory.Less(column1, source1, column2, source2));
		public ConditionBuilder Less(Func<ExpressionFactory, IExpression> expressionFunction1, Func<ExpressionFactory, IExpression> expressionFunction2) => Add(Factory.Less(expressionFunction1, expressionFunction2));

		#endregion Less methods

		#region LessOrEqual methods

		public ConditionBuilder LessOrEqual(IExpression expression, sbyte value) => Add(Factory.LessOrEqual(expression, value));
		public ConditionBuilder LessOrEqual(IExpression expression, short value) => Add(Factory.LessOrEqual(expression, value));
		public ConditionBuilder LessOrEqual(IExpression expression, int value) => Add(Factory.LessOrEqual(expression, value));
		public ConditionBuilder LessOrEqual(IExpression expression, long value) => Add(Factory.LessOrEqual(expression, value));
		public ConditionBuilder LessOrEqual(IExpression expression, float value) => Add(Factory.LessOrEqual(expression, value));
		public ConditionBuilder LessOrEqual(IExpression expression, double value) => Add(Factory.LessOrEqual(expression, value));
		public ConditionBuilder LessOrEqual(IExpression expression, decimal value) => Add(Factory.LessOrEqual(expression, value));
		public ConditionBuilder LessOrEqual(IExpression expression, DateTime value, string? format = null) => Add(Factory.LessOrEqual(expression, value, format));
		public ConditionBuilder LessOrEqual(IExpression expression, string value) => Add(Factory.LessOrEqual(expression, value));
		public ConditionBuilder LessOrEqual(IExpression expression1, IExpression expression2) => Add(Factory.LessOrEqual(expression1, expression2));
		public ConditionBuilder LessOrEqual(IExpression expression, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.LessOrEqual(expression, expressionFunction));

		public ConditionBuilder LessOrEqual(string column, sbyte value) => Add(Factory.LessOrEqual(column, value));
		public ConditionBuilder LessOrEqual(string column, short value) => Add(Factory.LessOrEqual(column, value));
		public ConditionBuilder LessOrEqual(string column, int value) => Add(Factory.LessOrEqual(column, value));
		public ConditionBuilder LessOrEqual(string column, long value) => Add(Factory.LessOrEqual(column, value));
		public ConditionBuilder LessOrEqual(string column, float value) => Add(Factory.LessOrEqual(column, value));
		public ConditionBuilder LessOrEqual(string column, double value) => Add(Factory.LessOrEqual(column, value));
		public ConditionBuilder LessOrEqual(string column, decimal value) => Add(Factory.LessOrEqual(column, value));
		public ConditionBuilder LessOrEqual(string column, DateTime value, string? format = null) => Add(Factory.LessOrEqual(column, value, format));
		public ConditionBuilder LessOrEqual(string column, string value) => Add(Factory.LessOrEqual(column, value));
		public ConditionBuilder LessOrEqual(string column, IExpression expression) => Add(Factory.LessOrEqual(column, expression));
		public ConditionBuilder LessOrEqual(string column, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.LessOrEqual(column, expressionFunction));

		public ConditionBuilder LessOrEqual(string column, string table, sbyte value) => Add(Factory.LessOrEqual(column, table, value));
		public ConditionBuilder LessOrEqual(string column, string table, short value) => Add(Factory.LessOrEqual(column, table, value));
		public ConditionBuilder LessOrEqual(string column, string table, int value) => Add(Factory.LessOrEqual(column, table, value));
		public ConditionBuilder LessOrEqual(string column, string table, long value) => Add(Factory.LessOrEqual(column, table, value));
		public ConditionBuilder LessOrEqual(string column, string table, float value) => Add(Factory.LessOrEqual(column, table, value));
		public ConditionBuilder LessOrEqual(string column, string table, double value) => Add(Factory.LessOrEqual(column, table, value));
		public ConditionBuilder LessOrEqual(string column, string table, decimal value) => Add(Factory.LessOrEqual(column, table, value));
		public ConditionBuilder LessOrEqual(string column, string table, DateTime value, string? format = null) => Add(Factory.LessOrEqual(column, table, value, format));
		public ConditionBuilder LessOrEqual(string column, string table, string value) => Add(Factory.LessOrEqual(column, table, value));
		public ConditionBuilder LessOrEqual(string column, string table, IExpression expression) => Add(Factory.LessOrEqual(column, table, expression));
		public ConditionBuilder LessOrEqual(string column, string table, Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.LessOrEqual(column, table, expressionFunction));

		public ConditionBuilder LessOrEqual(string column, ISource source, sbyte value) => Add(Factory.LessOrEqual(column, source, value));
		public ConditionBuilder LessOrEqual(string column, ISource source, short value) => Add(Factory.LessOrEqual(column, source, value));
		public ConditionBuilder LessOrEqual(string column, ISource source, int value) => Add(Factory.LessOrEqual(column, source, value));
		public ConditionBuilder LessOrEqual(string column, ISource source, long value) => Add(Factory.LessOrEqual(column, source, value));
		public ConditionBuilder LessOrEqual(string column, ISource source, float value) => Add(Factory.LessOrEqual(column, source, value));
		public ConditionBuilder LessOrEqual(string column, ISource source, double value) => Add(Factory.LessOrEqual(column, source, value));
		public ConditionBuilder LessOrEqual(string column, ISource source, decimal value) => Add(Factory.LessOrEqual(column, source, value));
		public ConditionBuilder LessOrEqual(string column, ISource source, DateTime value, string? format = null) => Add(Factory.LessOrEqual(column, source, value, format));
		public ConditionBuilder LessOrEqual(string column, ISource source, string value) => Add(Factory.LessOrEqual(column, source, value));
		public ConditionBuilder LessOrEqual(string column, ISource source, IExpression expression) => Add(Factory.LessOrEqual(column, source, expression));
		public ConditionBuilder LessOrEqual(string column, ISource source, Func<ExpressionFactory, IExpression> expressionFunction) =>  Add(Factory.LessOrEqual(column, source, expressionFunction));

		public ConditionBuilder LessOrEqual(string column1, string table1, string column2, string table2) => Add(Factory.LessOrEqual(column1, table1, column2, table2));
		public ConditionBuilder LessOrEqual(string column1, string table1, string column2, ISource source2) => Add(Factory.LessOrEqual(column1, table1, column2, source2));
		public ConditionBuilder LessOrEqual(string column1, ISource source1, string column2, string table2) => Add(Factory.LessOrEqual(column1, source1, column2, table2));
		public ConditionBuilder LessOrEqual(string column1, ISource source1, string column2, ISource source2) => Add(Factory.LessOrEqual(column1, source1, column2, source2));
		public ConditionBuilder LessOrEqual(Func<ExpressionFactory, IExpression> expressionFunction1, Func<ExpressionFactory, IExpression> expressionFunction2) => Add(Factory.LessOrEqual(expressionFunction1, expressionFunction2));

		#endregion LessOrEqual methods

		#region IsNull methods

		public ConditionBuilder IsNull(IExpression expression) => Add(Factory.IsNull(expression));
		public ConditionBuilder IsNull(string column) => Add(Factory.IsNull(column));
		public ConditionBuilder IsNull(string column, string table) => Add(Factory.IsNull(column, table));
		public ConditionBuilder IsNull(string column, ISource source) => Add(Factory.IsNull(column, source));
		public ConditionBuilder IsNull(Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.IsNull(expressionFunction));

		#endregion IsNull methods

		#region IsNotNull methods

		public ConditionBuilder IsNotNull(IExpression expression) => Add(Factory.IsNotNull(expression));
		public ConditionBuilder IsNotNull(string column) => Add(Factory.IsNotNull(column));
		public ConditionBuilder IsNotNull(string column, string table) => Add(Factory.IsNotNull(column, table));
		public ConditionBuilder IsNotNull(string column, ISource source) => Add(Factory.IsNotNull(column, source));
		public ConditionBuilder IsNotNull(Func<ExpressionFactory, IExpression> expressionFunction) => Add(Factory.IsNotNull(expressionFunction));

		#endregion IsNotNull methods

		#region In methods

		public ConditionBuilder In(IExpression expression, params sbyte[] values) => Add(Factory.In(expression, values));
		public ConditionBuilder In(IExpression expression, params short[] values) => Add(Factory.In(expression, values));
		public ConditionBuilder In(IExpression expression, params int[] values) => Add(Factory.In(expression, values));
		public ConditionBuilder In(IExpression expression, params long[] values) => Add(Factory.In(expression, values));
		public ConditionBuilder In(IExpression expression, params float[] values) => Add(Factory.In(expression, values));
		public ConditionBuilder In(IExpression expression, params double[] values) => Add(Factory.In(expression, values));
		public ConditionBuilder In(IExpression expression, params decimal[] values) => Add(Factory.In(expression, values));
		public ConditionBuilder In(IExpression expression, params DateTime[] values) => Add(Factory.In(expression, values));
		public ConditionBuilder In(IExpression expression, string format, params DateTime[] values) => Add(Factory.In(expression, format, values));
		public ConditionBuilder In(IExpression expression, params string[] values) => Add(Factory.In(expression, values));
		public ConditionBuilder In(IExpression expression, params IExpression[] values) => Add(Factory.In(expression, values));
		public ConditionBuilder In(IExpression expression, IEnumerable<sbyte> values) => Add(Factory.In(expression, values));
		public ConditionBuilder In(IExpression expression, IEnumerable<short> values) => Add(Factory.In(expression, values));
		public ConditionBuilder In(IExpression expression, IEnumerable<int> values) => Add(Factory.In(expression, values));
		public ConditionBuilder In(IExpression expression, IEnumerable<long> values) => Add(Factory.In(expression, values));
		public ConditionBuilder In(IExpression expression, IEnumerable<float> values) => Add(Factory.In(expression, values));
		public ConditionBuilder In(IExpression expression, IEnumerable<double> values) => Add(Factory.In(expression, values));
		public ConditionBuilder In(IExpression expression, IEnumerable<decimal> values) => Add(Factory.In(expression, values));
		public ConditionBuilder In(IExpression expression, IEnumerable<DateTime> values, string? format = null) => Add(Factory.In(expression, values, format));
		public ConditionBuilder In(IExpression expression, IEnumerable<string> values) => Add(Factory.In(expression, values));
		public ConditionBuilder In(IExpression expression, IEnumerable<IExpression> values) => Add(Factory.In(expression, values));
		public ConditionBuilder In(IExpression expression, Action<ExpressionBuilder> buildExpressionMethod) => Add(Factory.In(expression, buildExpressionMethod));
		public ConditionBuilder In(Func<ExpressionFactory, IExpression> expressionFunction, Action<ExpressionBuilder> buildExpressionMethod) => Add(Factory.In(expressionFunction, buildExpressionMethod));

		public ConditionBuilder In(string column, params sbyte[] values) => Add(Factory.In(column, values));
		public ConditionBuilder In(string column, params short[] values) => Add(Factory.In(column, values));
		public ConditionBuilder In(string column, params int[] values) => Add(Factory.In(column, values));
		public ConditionBuilder In(string column, params long[] values) => Add(Factory.In(column, values));
		public ConditionBuilder In(string column, params float[] values) => Add(Factory.In(column, values));
		public ConditionBuilder In(string column, params double[] values) => Add(Factory.In(column, values));
		public ConditionBuilder In(string column, params decimal[] values) => Add(Factory.In(column, values));
		public ConditionBuilder In(string column, params DateTime[] values) => Add(Factory.In(column, values));
		public ConditionBuilder In(string column, string format, params DateTime[] values) => Add(Factory.In(column, format, values));
		public ConditionBuilder In(string column, params string[] values) => Add(Factory.In(column, values));
		public ConditionBuilder In(string column, params IExpression[] values) => Add(Factory.In(column, values));
		public ConditionBuilder In(string column, IEnumerable<sbyte> values) => Add(Factory.In(column, values));
		public ConditionBuilder In(string column, IEnumerable<short> values) => Add(Factory.In(column, values));
		public ConditionBuilder In(string column, IEnumerable<int> values) => Add(Factory.In(column, values));
		public ConditionBuilder In(string column, IEnumerable<long> values) => Add(Factory.In(column, values));
		public ConditionBuilder In(string column, IEnumerable<float> values) => Add(Factory.In(column, values));
		public ConditionBuilder In(string column, IEnumerable<double> values) => Add(Factory.In(column, values));
		public ConditionBuilder In(string column, IEnumerable<decimal> values) => Add(Factory.In(column, values));
		public ConditionBuilder In(string column, IEnumerable<DateTime> values, string? format = null) => Add(Factory.In(column, values, format));
		public ConditionBuilder In(string column, IEnumerable<string> values) => Add(Factory.In(column, values));
		public ConditionBuilder In(string column, IEnumerable<IExpression> values) => Add(Factory.In(column, values));
		public ConditionBuilder In(string column, Action<ExpressionBuilder> buildExpressionMethod) => Add(Factory.In(column, buildExpressionMethod));

		public ConditionBuilder In(string column, string table, params sbyte[] values) => Add(Factory.In(column, table, values));
		public ConditionBuilder In(string column, string table, params short[] values) => Add(Factory.In(column, table, values));
		public ConditionBuilder In(string column, string table, params int[] values) => Add(Factory.In(column, table, values));
		public ConditionBuilder In(string column, string table, params long[] values) => Add(Factory.In(column, table, values));
		public ConditionBuilder In(string column, string table, params float[] values) => Add(Factory.In(column, table, values));
		public ConditionBuilder In(string column, string table, params double[] values) => Add(Factory.In(column, table, values));
		public ConditionBuilder In(string column, string table, params decimal[] values) => Add(Factory.In(column, table, values));
		public ConditionBuilder In(string column, string table, string? format, params DateTime[] values) => Add(Factory.In(column, table, format, values));
		public ConditionBuilder In(string column, string table, params string[] values) => Add(Factory.In(column, table, values));
		public ConditionBuilder In(string column, string table, params IExpression[] values) => Add(Factory.In(column, table, values));
		public ConditionBuilder In(string column, string table, IEnumerable<sbyte> values) => Add(Factory.In(column, table, values));
		public ConditionBuilder In(string column, string table, IEnumerable<short> values) => Add(Factory.In(column, table, values));
		public ConditionBuilder In(string column, string table, IEnumerable<int> values) => Add(Factory.In(column, table, values));
		public ConditionBuilder In(string column, string table, IEnumerable<long> values) => Add(Factory.In(column, table, values));
		public ConditionBuilder In(string column, string table, IEnumerable<float> values) => Add(Factory.In(column, table, values));
		public ConditionBuilder In(string column, string table, IEnumerable<double> values) => Add(Factory.In(column, table, values));
		public ConditionBuilder In(string column, string table, IEnumerable<decimal> values) => Add(Factory.In(column, table, values));
		public ConditionBuilder In(string column, string table, IEnumerable<DateTime> values, string? format = null) => Add(Factory.In(column, table, values, format));
		public ConditionBuilder In(string column, string table, IEnumerable<string> values) => Add(Factory.In(column, table, values));
		public ConditionBuilder In(string column, string table, IEnumerable<IExpression> values) => Add(Factory.In(column, table, values));
		public ConditionBuilder In(string column, string table, Action<ExpressionBuilder> buildExpressionMethod) => Add(Factory.In(column, table, buildExpressionMethod));

		public ConditionBuilder In(string column, ISource source, params sbyte[] values) => Add(Factory.In(column, source, values));
		public ConditionBuilder In(string column, ISource source, params short[] values) => Add(Factory.In(column, source, values));
		public ConditionBuilder In(string column, ISource source, params int[] values) => Add(Factory.In(column, source, values));
		public ConditionBuilder In(string column, ISource source, params long[] values) => Add(Factory.In(column, source, values));
		public ConditionBuilder In(string column, ISource source, params float[] values) => Add(Factory.In(column, source, values));
		public ConditionBuilder In(string column, ISource source, params double[] values) => Add(Factory.In(column, source, values));
		public ConditionBuilder In(string column, ISource source, params decimal[] values) => Add(Factory.In(column, source, values));
		public ConditionBuilder In(string column, ISource source, params DateTime[] values) => Add(Factory.In(column, source, values));
		public ConditionBuilder In(string column, ISource source, string format, params DateTime[] values) => Add(Factory.In(column, source, format, values));
		public ConditionBuilder In(string column, ISource source, params string[] values) => Add(Factory.In(column, source, values));
		public ConditionBuilder In(string column, ISource source, params IExpression[] values) => Add(Factory.In(column, source, values));
		public ConditionBuilder In(string column, ISource source, IEnumerable<sbyte> values) => Add(Factory.In(column, source, values));
		public ConditionBuilder In(string column, ISource source, IEnumerable<short> values) => Add(Factory.In(column, source, values));
		public ConditionBuilder In(string column, ISource source, IEnumerable<int> values) => Add(Factory.In(column, source, values));
		public ConditionBuilder In(string column, ISource source, IEnumerable<long> values) => Add(Factory.In(column, source, values));
		public ConditionBuilder In(string column, ISource source, IEnumerable<float> values) => Add(Factory.In(column, source, values));
		public ConditionBuilder In(string column, ISource source, IEnumerable<double> values) => Add(Factory.In(column, source, values));
		public ConditionBuilder In(string column, ISource source, IEnumerable<decimal> values) => Add(Factory.In(column, source, values));
		public ConditionBuilder In(string column, ISource source, IEnumerable<DateTime> values, string? format = null) => Add(Factory.In(column, source, values, format));
		public ConditionBuilder In(string column, ISource source, IEnumerable<string> values) => Add(Factory.In(column, source, values));
		public ConditionBuilder In(string column, ISource source, IEnumerable<IExpression> values) => Add(Factory.In(column, source, values));
		public ConditionBuilder In(string column, ISource source, Action<ExpressionBuilder> buildExpressionMethod) => Add(Factory.In(column, source, buildExpressionMethod));

		#endregion In methods

		#region NotInCondition factory methods

		public ConditionBuilder NotIn(IExpression expression, params sbyte[] values) => Add(Factory.NotIn(expression, values));
		public ConditionBuilder NotIn(IExpression expression, params short[] values) => Add(Factory.NotIn(expression, values));
		public ConditionBuilder NotIn(IExpression expression, params int[] values) => Add(Factory.NotIn(expression, values));
		public ConditionBuilder NotIn(IExpression expression, params long[] values) => Add(Factory.NotIn(expression, values));
		public ConditionBuilder NotIn(IExpression expression, params float[] values) => Add(Factory.NotIn(expression, values));
		public ConditionBuilder NotIn(IExpression expression, params double[] values) => Add(Factory.NotIn(expression, values));
		public ConditionBuilder NotIn(IExpression expression, params decimal[] values) => Add(Factory.NotIn(expression, values));
		public ConditionBuilder NotIn(IExpression expression, params DateTime[] values) => Add(Factory.NotIn(expression, values));
		public ConditionBuilder NotIn(IExpression expression, string format, params DateTime[] values) => Add(Factory.NotIn(expression, format, values));
		public ConditionBuilder NotIn(IExpression expression, params string[] values) => Add(Factory.NotIn(expression, values));
		public ConditionBuilder NotIn(IExpression expression, params IExpression[] values) => Add(Factory.NotIn(expression, values));
		public ConditionBuilder NotIn(IExpression expression, IEnumerable<sbyte> values) => Add(Factory.NotIn(expression, values));
		public ConditionBuilder NotIn(IExpression expression, IEnumerable<short> values) => Add(Factory.NotIn(expression, values));
		public ConditionBuilder NotIn(IExpression expression, IEnumerable<int> values) => Add(Factory.NotIn(expression, values));
		public ConditionBuilder NotIn(IExpression expression, IEnumerable<long> values) => Add(Factory.NotIn(expression, values));
		public ConditionBuilder NotIn(IExpression expression, IEnumerable<float> values) => Add(Factory.NotIn(expression, values));
		public ConditionBuilder NotIn(IExpression expression, IEnumerable<double> values) => Add(Factory.NotIn(expression, values));
		public ConditionBuilder NotIn(IExpression expression, IEnumerable<decimal> values) => Add(Factory.NotIn(expression, values));
		public ConditionBuilder NotIn(IExpression expression, IEnumerable<DateTime> values, string? format = null) => Add(Factory.NotIn(expression, values, format));
		public ConditionBuilder NotIn(IExpression expression, IEnumerable<string> values) => Add(Factory.NotIn(expression, values));
		public ConditionBuilder NotIn(IExpression expression, IEnumerable<IExpression> values) => Add(Factory.NotIn(expression, values));
		public ConditionBuilder NotIn(IExpression expression, Action<ExpressionBuilder> buildExpressionMethod) => Add(Factory.NotIn(expression, buildExpressionMethod));
		public ConditionBuilder NotIn(Func<ExpressionFactory, IExpression> expressionFunction, Action<ExpressionBuilder> buildExpressionMethod) => Add(Factory.NotIn(expressionFunction, buildExpressionMethod));

		public ConditionBuilder NotIn(string column, params sbyte[] values) => Add(Factory.NotIn(column, values));
		public ConditionBuilder NotIn(string column, params short[] values) => Add(Factory.NotIn(column, values));
		public ConditionBuilder NotIn(string column, params int[] values) => Add(Factory.NotIn(column, values));
		public ConditionBuilder NotIn(string column, params long[] values) => Add(Factory.NotIn(column, values));
		public ConditionBuilder NotIn(string column, params float[] values) => Add(Factory.NotIn(column, values));
		public ConditionBuilder NotIn(string column, params double[] values) => Add(Factory.NotIn(column, values));
		public ConditionBuilder NotIn(string column, params decimal[] values) => Add(Factory.NotIn(column, values));
		public ConditionBuilder NotIn(string column, params DateTime[] values) => Add(Factory.NotIn(column, values));
		public ConditionBuilder NotIn(string column, string format, params DateTime[] values) => Add(Factory.NotIn(column, format, values));
		public ConditionBuilder NotIn(string column, params string[] values) => Add(Factory.NotIn(column, values));
		public ConditionBuilder NotIn(string column, params IExpression[] values) => Add(Factory.NotIn(column, values));
		public ConditionBuilder NotIn(string column, IEnumerable<sbyte> values) => Add(Factory.NotIn(column, values));
		public ConditionBuilder NotIn(string column, IEnumerable<short> values) => Add(Factory.NotIn(column, values));
		public ConditionBuilder NotIn(string column, IEnumerable<int> values) => Add(Factory.NotIn(column, values));
		public ConditionBuilder NotIn(string column, IEnumerable<long> values) => Add(Factory.NotIn(column, values));
		public ConditionBuilder NotIn(string column, IEnumerable<float> values) => Add(Factory.NotIn(column, values));
		public ConditionBuilder NotIn(string column, IEnumerable<double> values) => Add(Factory.NotIn(column, values));
		public ConditionBuilder NotIn(string column, IEnumerable<decimal> values) => Add(Factory.NotIn(column, values));
		public ConditionBuilder NotIn(string column, IEnumerable<DateTime> values, string? format = null) => Add(Factory.NotIn(column, values, format));
		public ConditionBuilder NotIn(string column, IEnumerable<string> values) => Add(Factory.NotIn(column, values));
		public ConditionBuilder NotIn(string column, IEnumerable<IExpression> values) => Add(Factory.NotIn(column, values));
		public ConditionBuilder NotIn(string column, Action<ExpressionBuilder> buildExpressionMethod) => Add(Factory.NotIn(column, buildExpressionMethod));

		public ConditionBuilder NotIn(string column, string table, params sbyte[] values) => Add(Factory.NotIn(column, table, values));
		public ConditionBuilder NotIn(string column, string table, params short[] values) => Add(Factory.NotIn(column, table, values));
		public ConditionBuilder NotIn(string column, string table, params int[] values) => Add(Factory.NotIn(column, table, values));
		public ConditionBuilder NotIn(string column, string table, params long[] values) => Add(Factory.NotIn(column, table, values));
		public ConditionBuilder NotIn(string column, string table, params float[] values) => Add(Factory.NotIn(column, table, values));
		public ConditionBuilder NotIn(string column, string table, params double[] values) => Add(Factory.NotIn(column, table, values));
		public ConditionBuilder NotIn(string column, string table, params decimal[] values) => Add(Factory.NotIn(column, table, values));
		public ConditionBuilder NotIn(string column, string table, string? format, params DateTime[] values) => Add(Factory.NotIn(column, table, format, values));
		public ConditionBuilder NotIn(string column, string table, params string[] values) => Add(Factory.NotIn(column, table, values));
		public ConditionBuilder NotIn(string column, string table, params IExpression[] values) => Add(Factory.NotIn(column, table, values));
		public ConditionBuilder NotIn(string column, string table, IEnumerable<sbyte> values) => Add(Factory.NotIn(column, table, values));
		public ConditionBuilder NotIn(string column, string table, IEnumerable<short> values) => Add(Factory.NotIn(column, table, values));
		public ConditionBuilder NotIn(string column, string table, IEnumerable<int> values) => Add(Factory.NotIn(column, table, values));
		public ConditionBuilder NotIn(string column, string table, IEnumerable<long> values) => Add(Factory.NotIn(column, table, values));
		public ConditionBuilder NotIn(string column, string table, IEnumerable<float> values) => Add(Factory.NotIn(column, table, values));
		public ConditionBuilder NotIn(string column, string table, IEnumerable<double> values) => Add(Factory.NotIn(column, table, values));
		public ConditionBuilder NotIn(string column, string table, IEnumerable<decimal> values) => Add(Factory.NotIn(column, table, values));
		public ConditionBuilder NotIn(string column, string table, IEnumerable<DateTime> values, string? format = null) => Add(Factory.NotIn(column, table, values, format));
		public ConditionBuilder NotIn(string column, string table, IEnumerable<string> values) => Add(Factory.NotIn(column, table, values));
		public ConditionBuilder NotIn(string column, string table, IEnumerable<IExpression> values) => Add(Factory.NotIn(column, table, values));
		public ConditionBuilder NotIn(string column, string table, Action<ExpressionBuilder> buildExpressionMethod) => Add(Factory.NotIn(column, table, buildExpressionMethod));

		public ConditionBuilder NotIn(string column, ISource source, params sbyte[] values) => Add(Factory.NotIn(column, source, values));
		public ConditionBuilder NotIn(string column, ISource source, params short[] values) => Add(Factory.NotIn(column, source, values));
		public ConditionBuilder NotIn(string column, ISource source, params int[] values) => Add(Factory.NotIn(column, source, values));
		public ConditionBuilder NotIn(string column, ISource source, params long[] values) => Add(Factory.NotIn(column, source, values));
		public ConditionBuilder NotIn(string column, ISource source, params float[] values) => Add(Factory.NotIn(column, source, values));
		public ConditionBuilder NotIn(string column, ISource source, params double[] values) => Add(Factory.NotIn(column, source, values));
		public ConditionBuilder NotIn(string column, ISource source, params decimal[] values) => Add(Factory.NotIn(column, source, values));
		public ConditionBuilder NotIn(string column, ISource source, params DateTime[] values) => Add(Factory.NotIn(column, source, values));
		public ConditionBuilder NotIn(string column, ISource source, string? format, params DateTime[] values) => Add(Factory.NotIn(column, source, format, values));
		public ConditionBuilder NotIn(string column, ISource source, params string[] values) => Add(Factory.NotIn(column, source, values));
		public ConditionBuilder NotIn(string column, ISource source, params IExpression[] values) => Add(Factory.NotIn(column, source, values));
		public ConditionBuilder NotIn(string column, ISource source, IEnumerable<sbyte> values) => Add(Factory.NotIn(column, source, values));
		public ConditionBuilder NotIn(string column, ISource source, IEnumerable<short> values) => Add(Factory.NotIn(column, source, values));
		public ConditionBuilder NotIn(string column, ISource source, IEnumerable<int> values) => Add(Factory.NotIn(column, source, values));
		public ConditionBuilder NotIn(string column, ISource source, IEnumerable<long> values) => Add(Factory.NotIn(column, source, values));
		public ConditionBuilder NotIn(string column, ISource source, IEnumerable<float> values) => Add(Factory.NotIn(column, source, values));
		public ConditionBuilder NotIn(string column, ISource source, IEnumerable<double> values) => Add(Factory.NotIn(column, source, values));
		public ConditionBuilder NotIn(string column, ISource source, IEnumerable<decimal> values) => Add(Factory.NotIn(column, source, values));
		public ConditionBuilder NotIn(string column, ISource source, IEnumerable<DateTime> values, string? format = null) => Add(Factory.NotIn(column, source, values, format));
		public ConditionBuilder NotIn(string column, ISource source, IEnumerable<string> values) => Add(Factory.NotIn(column, source, values));
		public ConditionBuilder NotIn(string column, ISource source, IEnumerable<IExpression> values) => Add(Factory.NotIn(column, source, values));
		public ConditionBuilder NotIn(string column, ISource source, Action<ExpressionBuilder> buildExpressionMethod) => Add(Factory.NotIn(column, source, buildExpressionMethod));

		#endregion NotInCondition factory methods

		#region LikeCondition factory methods

		public ConditionBuilder Like(IExpression expression, string pattern) => Add(Factory.Like(expression, pattern));
		public ConditionBuilder Like(string column, string pattern) => Add(Factory.Like(column, pattern));
		public ConditionBuilder Like(string column, string table, string pattern) => Add(Factory.Like(column, table, pattern));
		public ConditionBuilder Like(string column, ISource source, string pattern) => Add(Factory.Like(column, source, pattern));
		public ConditionBuilder Like(Func<ExpressionFactory, IExpression> expressionFunction, string pattern) => Add(Factory.Like(expressionFunction, pattern));

		#endregion LikeCondition factory methods

		#region NotLikeCondition factory methods

		public ConditionBuilder NotLike(IExpression expression, string pattern) => Add(Factory.NotLike(expression, pattern));
		public ConditionBuilder NotLike(string column, string pattern) => Add(Factory.NotLike(column, pattern));
		public ConditionBuilder NotLike(string column, string table, string pattern) => Add(Factory.NotLike(column, table, pattern));
		public ConditionBuilder NotLike(string column, ISource source, string pattern) => Add(Factory.NotLike(column, source, pattern));
		public ConditionBuilder NotLike(Func<ExpressionFactory, IExpression> expressionFunction, string pattern) => Add(Factory.NotLike(expressionFunction, pattern));

		#endregion NotLikeCondition factory methods

		#region BetweenCondition factory methods

		public ConditionBuilder Between(IExpression expression, sbyte lowBound, sbyte hightBound) => Add(Factory.Between(expression, lowBound, hightBound));
		public ConditionBuilder Between(IExpression expression, short lowBound, short hightBound) => Add(Factory.Between(expression, lowBound, hightBound));
		public ConditionBuilder Between(IExpression expression, int lowBound, int hightBound) => Add(Factory.Between(expression, lowBound, hightBound));
		public ConditionBuilder Between(IExpression expression, long lowBound, long hightBound) => Add(Factory.Between(expression, lowBound, hightBound));
		public ConditionBuilder Between(IExpression expression, float lowBound, float hightBound) => Add(Factory.Between(expression, lowBound, hightBound));
		public ConditionBuilder Between(IExpression expression, double lowBound, double hightBound) => Add(Factory.Between(expression, lowBound, hightBound));
		public ConditionBuilder Between(IExpression expression, decimal lowBound, decimal hightBound) => Add(Factory.Between(expression, lowBound, hightBound));
		public ConditionBuilder Between(IExpression expression, DateTime lowBound, DateTime hightBound, string? format = null) => Add(Factory.Between(expression, lowBound, hightBound, format));
		public ConditionBuilder Between(IExpression expression, string lowBound, string hightBound) => Add(Factory.Between(expression, lowBound, hightBound));
		public ConditionBuilder Between(IExpression expression1, IExpression lowBound, IExpression hightBound) => Add(Factory.Between(expression1, lowBound, hightBound));
		public ConditionBuilder Between(IExpression expression, Func<ExpressionFactory, IExpression> lowBoundFunction, Func<ExpressionFactory, IExpression> hightBoundFunction) => Add(Factory.Between(expression, lowBoundFunction, hightBoundFunction));
		public ConditionBuilder Between(Func<ExpressionFactory, IExpression> expressionFunction, Func<ExpressionFactory, IExpression> lowBoundFunction, Func<ExpressionFactory, IExpression> hightBoundFunction) => Add(Factory.Between(expressionFunction, lowBoundFunction, hightBoundFunction));

		public ConditionBuilder Between(string column, sbyte lowBound, sbyte hightBound) => Add(Factory.Between(column, lowBound, hightBound));
		public ConditionBuilder Between(string column, short lowBound, short hightBound) => Add(Factory.Between(column, lowBound, hightBound));
		public ConditionBuilder Between(string column, int lowBound, int hightBound) => Add(Factory.Between(column, lowBound, hightBound));
		public ConditionBuilder Between(string column, long lowBound, long hightBound) => Add(Factory.Between(column, lowBound, hightBound));
		public ConditionBuilder Between(string column, float lowBound, float hightBound) => Add(Factory.Between(column, lowBound, hightBound));
		public ConditionBuilder Between(string column, double lowBound, double hightBound) => Add(Factory.Between(column, lowBound, hightBound));
		public ConditionBuilder Between(string column, decimal lowBound, decimal hightBound) => Add(Factory.Between(column, lowBound, hightBound));
		public ConditionBuilder Between(string column, DateTime lowBound, DateTime hightBound, string? format = null) => Add(Factory.Between(column, lowBound, hightBound, format));
		public ConditionBuilder Between(string column, string lowBound, string hightBound) => Add(Factory.Between(column, lowBound, hightBound));
		public ConditionBuilder Between(string column, IExpression lowBound, IExpression hightBound) => Add(Factory.Between(column, lowBound, hightBound));
		public ConditionBuilder Between(string column, Func<ExpressionFactory, IExpression> lowBoundFunction, Func<ExpressionFactory, IExpression> hightBoundFunction) => Add(Factory.Between(column, lowBoundFunction, hightBoundFunction));

		public ConditionBuilder Between(string column, string table, sbyte lowBound, sbyte hightBound) => Add(Factory.Between(column, table, lowBound, hightBound));
		public ConditionBuilder Between(string column, string table, short lowBound, short hightBound) => Add(Factory.Between(column, table, lowBound, hightBound));
		public ConditionBuilder Between(string column, string table, int lowBound, int hightBound) => Add(Factory.Between(column, table, lowBound, hightBound));
		public ConditionBuilder Between(string column, string table, long lowBound, long hightBound) => Add(Factory.Between(column, table, lowBound, hightBound));
		public ConditionBuilder Between(string column, string table, float lowBound, float hightBound) => Add(Factory.Between(column, table, lowBound, hightBound));
		public ConditionBuilder Between(string column, string table, double lowBound, double hightBound) => Add(Factory.Between(column, table, lowBound, hightBound));
		public ConditionBuilder Between(string column, string table, decimal lowBound, decimal hightBound) => Add(Factory.Between(column, table, lowBound, hightBound));
		public ConditionBuilder Between(string column, string table, DateTime lowBound, DateTime hightBound, string? format = null) => Add(Factory.Between(column, table, lowBound, hightBound, format));
		public ConditionBuilder Between(string column, string table, string lowBound, string hightBound) => Add(Factory.Between(column, table, lowBound, hightBound));
		public ConditionBuilder Between(string column, string table, IExpression lowBound, IExpression hightBound) => Add(Factory.Between(column, table, lowBound, hightBound));
		public ConditionBuilder Between(string column, string table, Func<ExpressionFactory, IExpression> lowBoundFunction, Func<ExpressionFactory, IExpression> hightBoundFunction) => Add(Factory.Between(column, table, lowBoundFunction, hightBoundFunction));

		public ConditionBuilder Between(string column, ISource source, sbyte lowBound, sbyte hightBound) => Add(Factory.Between(column, source, lowBound, hightBound));
		public ConditionBuilder Between(string column, ISource source, short lowBound, short hightBound) => Add(Factory.Between(column, source, lowBound, hightBound));
		public ConditionBuilder Between(string column, ISource source, int lowBound, int hightBound) => Add(Factory.Between(column, source, lowBound, hightBound));
		public ConditionBuilder Between(string column, ISource source, long lowBound, long hightBound) => Add(Factory.Between(column, source, lowBound, hightBound));
		public ConditionBuilder Between(string column, ISource source, float lowBound, float hightBound) => Add(Factory.Between(column, source, lowBound, hightBound));
		public ConditionBuilder Between(string column, ISource source, double lowBound, double hightBound) => Add(Factory.Between(column, source, lowBound, hightBound));
		public ConditionBuilder Between(string column, ISource source, decimal lowBound, decimal hightBound) => Add(Factory.Between(column, source, lowBound, hightBound));
		public ConditionBuilder Between(string column, ISource source, DateTime lowBound, DateTime hightBound, string? format = null) => Add(Factory.Between(column, source, lowBound, hightBound, format));
		public ConditionBuilder Between(string column, ISource source, string lowBound, string hightBound) => Add(Factory.Between(column, source, lowBound, hightBound));
		public ConditionBuilder Between(string column, ISource source, IExpression lowBound, IExpression hightBound) => Add(Factory.Between(column, source, lowBound, hightBound));
		public ConditionBuilder Between(string column, ISource source, Func<ExpressionFactory, IExpression> lowBoundFunction, Func<ExpressionFactory, IExpression> hightBoundFunction) => Add(Factory.Between(column, source, lowBoundFunction, hightBoundFunction));

		#endregion BetweenCondition factory methods

		#region Condition methods

		public ConditionBuilder Condition(ICondition condition) => Add(condition);

		#endregion Condition methods

		public ICondition Build() => BuildAnd();

		internal ICondition BuildAnd()
		{
			Validator.ThrowIfArgumentIsEmpty(Conditions, nameof(Conditions));

			ICondition condition = Conditions.Count == 1 ? Conditions[0] : new AndCondition(Conditions);

			return condition;
		}

		internal ICondition BuildOr()
		{
			Validator.ThrowIfArgumentIsEmpty(Conditions, nameof(Conditions));

			ICondition condition = Conditions.Count == 1 ? Conditions[0] : new OrCondition(Conditions);

			return condition;
		}

		private ConditionBuilder Add(ICondition condition)
		{
			Conditions.Add(condition);

			return this;
		}
	}
}
