using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public class FullJoin : ConditionalJoin
	{
		public FullJoin(ISource source, ICondition condition) : base(source, condition)
		{
		}

		public override void RenderJoin(IRenderer renderer, StringBuilder sql) => renderer.RenderJoin(this, sql);
	}
}
