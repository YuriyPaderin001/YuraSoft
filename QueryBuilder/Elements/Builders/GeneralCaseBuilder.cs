using System;
using System.Collections.Generic;

using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;

#nullable enable

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
			if (_whenThens.Count == 0)
			{
				throw new CollectionShouldNotBeEmptyException(nameof(_whenThens));
			}

			GeneralCaseExpression caseExpression = new GeneralCaseExpression(_whenThens, _else);

			return caseExpression;
		}
	}
}
