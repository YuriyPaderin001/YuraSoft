using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class MinFunction : ExpressionFunction
	{
		public MinFunction(IExpression expression) : base(expression)
		{
		}

		public override void RenderFunction(IRenderer renderer, StringBuilder query) => renderer.RenderFunction(this, query);
	}
}
