using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
    public abstract class Expression : IExpression
    {
        public string RenderExpression(IRenderer renderer)
        {
            StringBuilder sql = new StringBuilder();
            RenderExpression(renderer, sql);

            return sql.ToString();
        }

        public abstract void RenderExpression(IRenderer renderer, StringBuilder sql);
    }
}
