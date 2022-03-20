using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface ISource : IIdentificator
	{
		public string RenderSource(IRenderer renderer);
	}
}
