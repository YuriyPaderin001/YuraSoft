using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface IQuery
	{
		public void RenderQuery(IRenderer renderer, StringBuilder sql);
	}
}
