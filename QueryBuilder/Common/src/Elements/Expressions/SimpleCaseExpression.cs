using System;
using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class SimpleCaseExpression : Expression
	{
		public SimpleCaseExpression(IExpression expression, IEnumerable<Tuple<IExpression, IExpression>> whenThens, IExpression? @else = null)
		{
			Expression = Guard.ThrowIfNull(expression, nameof(expression));
			WhenThens = new List<Tuple<IExpression, IExpression>>(Guard.ThrowIfNullOrEmpty(whenThens, nameof(whenThens)));
			Else = @else;
		}

		public readonly IExpression Expression;
		public readonly List<Tuple<IExpression, IExpression>> WhenThens;
		public readonly IExpression? Else;

		public override void RenderExpression(IRenderer renderer, StringBuilder sql) => renderer.RenderExpression(this, sql);
	}
}
