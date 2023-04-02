using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public class CrossJoin : Join
	{
		public CrossJoin(ISource source) : base(source)
		{
		}

		public override void RenderJoin(IRenderer renderer, StringBuilder sql) => renderer.RenderJoin(this, sql);
	}
}
