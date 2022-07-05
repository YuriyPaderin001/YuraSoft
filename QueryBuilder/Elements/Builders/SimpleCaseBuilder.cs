using System;
using System.Collections.Generic;

using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class SimpleCaseBuilder
	{
		private IExpression _expression;
		private List<Tuple<IExpression, IExpression>> _whenThens = new List<Tuple<IExpression, IExpression>>();
		private IExpression? _else;

		public SimpleCaseBuilder(IExpression expression)
		{
			if (expression == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(expression));
			}

			_expression = expression;
		}

		public SimpleCaseBuilder WhenThen(IExpression condition, IExpression expression)
		{
			_whenThens.Add(Tuple.Create(condition, expression));

			return this;
		}

		public void Else(IExpression expression) => _else = expression;

		public SimpleCaseExpression Build()
		{
			if (_whenThens.Count == 0)
			{
				throw new CollectionShouldNotBeEmptyException(nameof(_whenThens));
			}

			SimpleCaseExpression caseExpression = new SimpleCaseExpression(_expression, _whenThens, _else);

			return caseExpression;
		}
	}
}
