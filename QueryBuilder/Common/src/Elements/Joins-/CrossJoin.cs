using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class CrossJoin : Join
	{
		public CrossJoin(ISource source) : base(source)
		{
		}

		public override void RenderJoin(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderJoin(this, stringBuilder);
	}
}
