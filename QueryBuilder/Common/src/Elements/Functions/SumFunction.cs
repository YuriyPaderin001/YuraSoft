using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public class SumFunction : ExpressionFunction
	{
		public SumFunction(IExpression expression) : base(expression)
		{
		}

		public override void RenderFunction(IRenderer renderer, StringBuilder sql) => renderer.RenderFunction(this, sql);
	}
}
