using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface IOrderBy
	{
		public string RenderOrderBy(IRenderer renderer);
	}
}
