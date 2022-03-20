using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface IIdentificator
	{
		public string RenderIdentificator(IRenderer renderer);
	}
}
