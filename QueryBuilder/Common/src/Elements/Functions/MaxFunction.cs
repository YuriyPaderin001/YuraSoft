using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public class MaxFunction : ExpressionFunction
	{
		public MaxFunction(IExpression expression) : base(expression)
		{
		}

		public override void RenderFunction(IRenderer renderer, StringBuilder sql) => renderer.RenderFunction(this, sql);
	}
}
