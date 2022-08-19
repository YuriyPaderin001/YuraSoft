using System.Text;

using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface IQuery
	{
		public void RenderQuery(IRenderer renderer, StringBuilder stringBuilder);
	}
}
