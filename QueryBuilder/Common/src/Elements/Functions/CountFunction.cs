using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public class CountFunction : ExpressionFunction
	{
		public CountFunction(IExpression expression) : base(expression)
		{
		}

		public override void RenderFunction(IRenderer renderer, StringBuilder sql) => renderer.RenderFunction(this, sql);
	}
}
