using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface IJoin
	{
		public void RenderJoin(IRenderer renderer, StringBuilder sql);
	}
}
