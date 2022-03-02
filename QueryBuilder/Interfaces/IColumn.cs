using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface IColumn
	{
		public string RenderColumn(IRenderer renderer);
	}
}
