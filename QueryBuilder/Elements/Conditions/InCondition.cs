using System.Collections.Generic;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class InCondition : CollectionCondition
	{
		public InCondition(IExpression expression, IEnumerable<IExpression> values) : base(expression, values)
		{
		}

		public override string RenderCondition(IRenderer renderer) => renderer.RenderCondition(this);
	}
}
