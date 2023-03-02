using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class MaxFunction : ExpressionFunction
	{
		public MaxFunction(IExpression expression) : base(column)
		{
		}

		public override void RenderFunction(IRenderer renderer, StringBuilder query) => renderer.RenderFunction(this, query);
	}
}
