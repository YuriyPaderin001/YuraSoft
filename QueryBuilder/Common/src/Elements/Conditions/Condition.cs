using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public abstract class Condition : Expression, ICondition
	{
		public override void RenderExpression(IRenderer renderer, StringBuilder sql) => 
			RenderCondition(renderer, sql);

		public string RenderCondition(IRenderer renderer)
		{
			StringBuilder sql = new StringBuilder();
			RenderCondition(renderer, sql);

			return sql.ToString();
		}

		public abstract void RenderCondition(IRenderer renderer, StringBuilder sql);
	}
}
