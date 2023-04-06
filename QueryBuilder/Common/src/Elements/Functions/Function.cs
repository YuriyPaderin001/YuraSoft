using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public abstract class Function : Expression, IFunction
	{
		public override void RenderExpression(IRenderer renderer, StringBuilder sql) => 
			RenderFunction(renderer, sql);
		
		public string RenderFunction(IRenderer renderer)
		{
			StringBuilder sql = new StringBuilder();
			RenderFunction(renderer, sql);

			return sql.ToString();
		}

		public abstract void RenderFunction(IRenderer renderer, StringBuilder sql);
	}
}
