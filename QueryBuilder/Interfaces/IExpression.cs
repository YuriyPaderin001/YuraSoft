using System.Text;

using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface IExpression
	{
		public void RenderExpression(IRenderer renderer, StringBuilder stringBuilder);
	}
}
