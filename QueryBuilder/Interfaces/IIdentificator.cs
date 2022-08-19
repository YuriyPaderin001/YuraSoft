using System.Text;

using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface IIdentificator
	{
		public void RenderIdentificator(IRenderer renderer, StringBuilder stringBuilder);
	}
}
