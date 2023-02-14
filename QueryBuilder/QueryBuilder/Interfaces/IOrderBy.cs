using System.Text;

using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface IOrderBy
	{
		public void RenderOrderBy(IRenderer renderer, StringBuilder stringBuilder);
	}
}
