using System.Text;

using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface IFunction : IExpression
	{
		public void RenderFunction(IRenderer renderer, StringBuilder stringBuilder);
	}
}
