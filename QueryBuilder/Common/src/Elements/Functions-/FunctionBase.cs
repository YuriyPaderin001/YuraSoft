using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public abstract class FunctionBase : IFunction
	{
		public string RenderExpression(IRenderer renderer)
		{
			StringBuilder query = new StringBuilder();
			RenderExpression(renderer, query);

			return query.ToString();
		}

		public virtual void RenderExpression(IRenderer renderer, StringBuilder query) => RenderFunction(renderer, query);
		
		public string RenderFunction(IRenderer renderer)
		{
			StringBuilder query = new StringBuilder();
			RenderFunction(renderer, query);

			return query.ToString();
		}

		public abstract void RenderFunction(IRenderer renderer, StringBuilder query);
	}
}
