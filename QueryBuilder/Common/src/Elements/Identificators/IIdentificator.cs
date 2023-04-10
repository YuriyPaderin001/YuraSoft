using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface IIdentificator
	{
		public void RenderIdentificator(IRenderer renderer, StringBuilder sql);
	}
}
