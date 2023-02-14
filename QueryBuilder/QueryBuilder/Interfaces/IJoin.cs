using System.Text;

using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface IJoin
	{
		public void RenderJoin(IRenderer renderer, StringBuilder stringBuilder);
	}
}
