using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class AndCondition : LogicalCondition
	{
		public AndCondition(IEnumerable<ICondition> conditions) : base(conditions)
		{
		}

		public override void RenderCondition(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderCondition(this, stringBuilder);
	}
}
