using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface IDistinct
	{
		public void RenderDistinct(IRenderer renderer, StringBuilder sql);
	}
}
