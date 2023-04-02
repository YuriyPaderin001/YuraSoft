using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public class RightJoin : ConditionalJoin
	{
		public RightJoin(ISource source, ICondition condition) : base(source, condition)
		{
		}

		public override void RenderJoin(IRenderer renderer, StringBuilder sql) => renderer.RenderJoin(this, sql);
	}
}
