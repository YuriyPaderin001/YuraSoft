using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface IQuery
	{
		public string RenderQuery(IRenderer renderer);
		public void RenderQuery(IRenderer renderer, StringBuilder sql);
	}
}
