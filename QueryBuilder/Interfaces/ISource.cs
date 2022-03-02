using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface ISource
	{
		public string RenderFrom(IRenderer renderer);
	}
}
