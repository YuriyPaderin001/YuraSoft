using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class CrossJoin : Join
	{
		public CrossJoin(ISource source) : base(source)
		{
		}

		public override string RenderJoin(IRenderer renderer) => renderer.RenderJoin(this);
	}
}
