using System;
using System.Collections.Generic;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public class GeneralCaseBuilder
	{
		public ExpressionFactory Factory = ExpressionFactory.Instance;

		private List<Tuple<ICondition, IExpression>> _whenThens = new List<Tuple<ICondition, IExpression>>();
		private IExpression? _else;

		public GeneralCaseBuilder WhenThen(ICondition condition, string column) => WhenThen(condition, new SourceColumn(column));
		public GeneralCaseBuilder WhenThen(ICondition condition, string column, string table) => WhenThen(condition, new SourceColumn(column, new Table(table)));
		public GeneralCaseBuilder WhenThen(ICondition condition, string column, ISource source) => WhenThen(condition, new SourceColumn(column, source));
		public GeneralCaseBuilder WhenThen(ICondition condition, IExpression expression) => WhenThen(Tuple.Create(condition, expression));

		public GeneralCaseBuilder WhenThen(ICondition condition, Func<ExpressionFactory, IExpression> expressionFunction)
		{
			IExpression expression = expressionFunction.Invoke(Factory);

			return WhenThen(condition, expression);
		}

		public GeneralCaseBuilder WhenThen(Action<ConditionBuilder> conditionBuildMethod, string column) => WhenThen(conditionBuildMethod, new SourceColumn(column));
		public GeneralCaseBuilder WhenThen(Action<ConditionBuilder> conditionBuildMethod, string column, string table) => WhenThen(conditionBuildMethod, new SourceColumn(column, new Table(table)));
		public GeneralCaseBuilder WhenThen(Action<ConditionBuilder> conditionBuildMethod, string column, ISource source) => WhenThen(conditionBuildMethod, new SourceColumn(column, source));
		public GeneralCaseBuilder WhenThen(Action<ConditionBuilder> conditionBuildMethod, IExpression expression) => WhenThen(Factory.Condition(conditionBuildMethod), expression);
		public GeneralCaseBuilder WhenThen(Action<ConditionBuilder> conditionBuildMethod, Func<ExpressionFactory, IExpression> expressionFunction) => WhenThen(Factory.Condition(conditionBuildMethod), Factory.Expression(expressionFunction));
		
		public GeneralCaseBuilder WhenThen(Tuple<ICondition, IExpression> whenThen)
		{
			_whenThens.Add(whenThen);

			return this;
		}

		public void Else(string column) => _else = new SourceColumn(column);
		public void Else(string column, string table) => _else = new SourceColumn(column, new Table(table));
		public void Else(string column, ISource source) => _else = new SourceColumn(column, source);
		public void Else(IExpression expression) => _else = expression;
		public void Else(Func<ExpressionFactory, IExpression> expressionFunction) => _else = Factory.Expression(expressionFunction);

		public GeneralCaseExpression Build()
		{
			Validator.ThrowIfArgumentIsEmpty(_whenThens, nameof(_whenThens));

			GeneralCaseExpression caseExpression = new GeneralCaseExpression(_whenThens, _else);

			return caseExpression;
		}
	}
}
