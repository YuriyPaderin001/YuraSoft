using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public abstract class FunctionBase : IFunction
	{
		public string RenderExpression(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderExpression(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public virtual void RenderExpression(IRenderer renderer, StringBuilder stringBuilder) => RenderFunction(renderer, stringBuilder);
		
		public string RenderFunction(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderFunction(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public abstract void RenderFunction(IRenderer renderer, StringBuilder stringBuilder);
	}
}
