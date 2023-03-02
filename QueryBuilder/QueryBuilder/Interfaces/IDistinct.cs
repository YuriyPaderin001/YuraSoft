using System.Text;

using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface IDistinct
	{
		public void RenderDistinct(IRenderer renderer, StringBuilder stringBuilder);
	}
}
