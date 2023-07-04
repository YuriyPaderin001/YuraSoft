using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface IDistinct
	{
		public string RenderDistinct(IRenderer renderer);
		public void RenderDistinct(IRenderer renderer, StringBuilder sql);
	}
}
