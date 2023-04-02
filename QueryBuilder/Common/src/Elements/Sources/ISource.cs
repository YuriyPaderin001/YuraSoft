using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface ISource : IIdentificator
	{
		public void RenderSource(IRenderer renderer, StringBuilder sql);
	}
}
