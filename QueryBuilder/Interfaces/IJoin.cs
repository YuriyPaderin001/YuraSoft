using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface IJoin
	{
		public string RenderJoin(IRenderer renderer);
	}
}
