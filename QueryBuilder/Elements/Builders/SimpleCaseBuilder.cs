using System;
using System.Collections.Generic;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public class SimpleCaseBuilder
	{
		private IExpression _expression;
		private List<Tuple<IExpression, IExpression>> _whenThens = new List<Tuple<IExpression, IExpression>>();
		private IExpression? _else;

		public SimpleCaseBuilder(IExpression expression)
		{
			_expression = Validator.ThrowIfArgumentIsNull(expression, nameof(expression));
		}

		public SimpleCaseBuilder WhenThen(IExpression condition, IExpression expression)
		{
			_whenThens.Add(Tuple.Create(condition, expression));

			return this;
		}

		public void Else(IExpression expression) => _else = expression;

		public SimpleCaseExpression Build()
		{
			Validator.ThrowIfArgumentIsEmpty(_whenThens, nameof(_whenThens));

			SimpleCaseExpression caseExpression = new SimpleCaseExpression(_expression, _whenThens, _else);

			return caseExpression;
		}
	}
}
