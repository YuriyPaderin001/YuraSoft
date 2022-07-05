using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class RightJoin : ConditionalJoin
	{
		public RightJoin(ISource source, ICondition condition) : base(source, condition)
		{
		}

		public override string RenderJoin(IRenderer renderer) => renderer.RenderJoin(this);
	}
}
