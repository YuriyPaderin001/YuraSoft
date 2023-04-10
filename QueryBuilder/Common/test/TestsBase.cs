using System;
using System.Collections.Generic;
using Moq;

namespace YuraSoft.QueryBuilder.Common.Tests
{
	public class TestsBase
	{
		protected List<IColumn> NewColumns(int length)
		{
			List<IColumn> columns = new List<IColumn>(length);
			for (int i = 0; i < length; i++)
			{
				columns.Add(NewColumn());
			}

			return columns;
		}

		protected IColumn NewColumn() => new Mock<IColumn>().Object;

		protected IDistinct NewDistinct() => new Mock<IDistinct>().Object;

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

		protected List<IJoin> NewJoins(int length)
		{
			List<IJoin> joins = new List<IJoin>(length);
			for (int i = 0; i < length; i++)
			{
				joins.Add(NewJoin());
			}

			return joins;
		}

		protected IJoin NewJoin() => new Mock<IJoin>().Object;

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

		protected List<IOrderBy> NewOrderBies(int length)
		{
			List<IOrderBy> orderBies = new List<IOrderBy>(length);
			for (int i = 0; i < length; i++)
			{
				orderBies.Add(NewOrderBy());
			}

			return orderBies;
		}

		protected IOrderBy NewOrderBy() => new Mock<IOrderBy>().Object;

		protected List<ISource> NewSources(int length)
		{
			List<ISource> sources = new List<ISource>(length);
			for (int i = 0; i < length; i++)
			{
				sources.Add(NewSource());
			}

			return sources;
		}

		protected ISource NewSource() => new Mock<ISource>().Object;
	}
}
