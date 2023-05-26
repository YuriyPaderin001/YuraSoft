using System;
using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class GeneralCaseExpression : Expression
	{
		public GeneralCaseExpression(IEnumerable<Tuple<ICondition, IExpression>> whenThens, IExpression? @else = null)
		{
			WhenThens = new List<Tuple<ICondition, IExpression>>(Guard.ThrowIfNullOrEmpty(whenThens, nameof(whenThens)));
			Else = @else;
		}

		public readonly List<Tuple<ICondition, IExpression>> WhenThens;
		public readonly IExpression? Else;

		public override void RenderExpression(IRenderer renderer, StringBuilder sql) => renderer.RenderExpression(this, sql);
	}
}
