using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface IFunction : IExpression
	{
		public string RenderFunction(IRenderer renderer);
		public void RenderFunction(IRenderer renderer, StringBuilder sql);
	}
}
