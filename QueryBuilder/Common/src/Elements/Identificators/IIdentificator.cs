using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface IIdentificator
	{
		public string RenderIdentificator(IRenderer renderer);
		public void RenderIdentificator(IRenderer renderer, StringBuilder sql);
	}
}
