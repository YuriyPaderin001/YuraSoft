using System;
using System.Collections.Generic;
using Moq;

namespace YuraSoft.QueryBuilder.Common.Tests
{
	public class TestsBase
	{
		protected List<Tuple<ICondition, IExpression>> NewGeneralEmptyWhenThenList() => new List<Tuple<ICondition, IExpression>>();
		protected List<Tuple<ICondition, IExpression>> NewGeneralWhenThenList(int length)
		{
			List<Tuple<ICondition, IExpression>> whenThens = new List<Tuple<ICondition, IExpression>>(length);
			for (int i = 0; i < length; i++)
			{
				whenThens.Add(NewGeneralWhenThen());
			}

			return whenThens;
		}

		protected Tuple<ICondition, IExpression> NewGeneralWhenThen() => Tuple.Create(NewCondition(), NewExpression());

		protected List<Tuple<IExpression, IExpression>> NewSimpleEmptyWhenThenList() => new List<Tuple<IExpression, IExpression>>();
		protected List<Tuple<IExpression, IExpression>> NewSimpleWhenThenList(int length)
		{
			List<Tuple<IExpression, IExpression>> whenThens = new List<Tuple<IExpression, IExpression>>(length);
			for (int i = 0; i < length; i++)
			{
				whenThens.Add(NewSimpleWhenThen());
			}

			return whenThens;
		}

		protected Tuple<IExpression, IExpression> NewSimpleWhenThen() => Tuple.Create(NewExpression(), NewExpression());

		protected List<ICondition> NewEmptyConditionList() => new List<ICondition>();
		protected List<ICondition> NewConditionList(int length)
		{
			List<ICondition> conditions = new List<ICondition>(length);
			for (int i = 0; i < length; i++)
			{
				conditions.Add(NewCondition());
			}

			return conditions;
		}

		protected ICondition NewCondition() => new Mock<ICondition>().Object;

		protected List<IExpression> NewEmptyExpressionList() => new List<IExpression>();
		protected List<IExpression> NewExpressionList(int length)
		{
			List<IExpression> expressions = new List<IExpression>(length);
			for (int i = 0; i < length; i++)
			{
				expressions.Add(NewExpression());
			}

			return expressions;
		}

		protected IExpression NewExpression() => new Mock<IExpression>().Object;
	}
}
