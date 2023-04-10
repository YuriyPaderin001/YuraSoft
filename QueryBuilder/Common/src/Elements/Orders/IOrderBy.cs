using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface IOrderBy
	{
		public void RenderOrderBy(IRenderer renderer, StringBuilder sql);
	}
}
