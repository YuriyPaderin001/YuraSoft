using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public abstract class Condition : ICondition
	{
		public string RenderExpression(IRenderer renderer)
		{
			StringBuilder sql = new StringBuilder();
			RenderExpression(renderer, sql);

			return sql.ToString();
		}

		public virtual void RenderExpression(IRenderer renderer, StringBuilder sql) => RenderCondition(renderer, sql);

		public string RenderCondition(IRenderer renderer)
		{
			StringBuilder sql = new StringBuilder();
			RenderCondition(renderer, sql);

			return sql.ToString();
		}

		public abstract void RenderCondition(IRenderer renderer, StringBuilder sql);
	}
}
