using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface IFunction : IExpression
	{
		public void RenderFunction(IRenderer renderer, StringBuilder sql);
	}
}
