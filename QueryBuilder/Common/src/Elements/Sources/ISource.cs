using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface ISource
	{
		public void RenderSource(IRenderer renderer, StringBuilder sql);
	}
}
