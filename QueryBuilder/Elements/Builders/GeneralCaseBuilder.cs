using System;
using System.Collections.Generic;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public class GeneralCaseBuilder
	{
		private List<Tuple<ICondition, IExpression>> _whenThens = new List<Tuple<ICondition, IExpression>>();
		private IExpression? _else;

		public GeneralCaseBuilder WhenThen(ICondition condition, IExpression expression)
		{
			_whenThens.Add(Tuple.Create(condition, expression));

			return this;
		}

		public void Else(IExpression expression) => _else = expression;

		public GeneralCaseExpression Build()
		{
			Validator.ThrowIfArgumentIsEmpty(_whenThens, nameof(_whenThens));

			GeneralCaseExpression caseExpression = new GeneralCaseExpression(_whenThens, _else);

			return caseExpression;
		}
	}
}
