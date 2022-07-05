using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public abstract class FunctionBase : IFunction
	{
		public virtual string RenderExpression(IRenderer renderer) => RenderFunction(renderer);
		public abstract string RenderFunction(IRenderer renderer);
	}
}
