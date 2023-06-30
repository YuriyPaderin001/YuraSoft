using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface ISource : IIdentificator
	{
		public string RenderSource(IRenderer renderer);
		public void RenderSource(IRenderer renderer, StringBuilder sql);
	}
}
