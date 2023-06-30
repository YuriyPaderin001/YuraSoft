using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface IJoin
	{
		public string RenderJoin(IRenderer renderer);
		public void RenderJoin(IRenderer renderer, StringBuilder sql);
	}
}
