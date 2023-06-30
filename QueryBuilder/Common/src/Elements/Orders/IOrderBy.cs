using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface IOrderBy
	{
		public string RenderOrderBy(IRenderer renderer);
		public void RenderOrderBy(IRenderer renderer, StringBuilder sql);
	}
}
