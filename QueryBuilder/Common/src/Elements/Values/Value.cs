using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public abstract class Value : Expression, IValue
	{
		public override void RenderExpression(IRenderer renderer, StringBuilder sql) => 
            RenderValue(renderer, sql);

        public string RenderValue(IRenderer renderer)
        {
            StringBuilder sql = new StringBuilder();
            RenderValue(renderer, sql);

            return sql.ToString();
        }

        public abstract void RenderValue(IRenderer renderer, StringBuilder sql);
	}
}
