using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface ISelect
	{
		public string RenderSelect(IRenderer renderer);
	}
}
