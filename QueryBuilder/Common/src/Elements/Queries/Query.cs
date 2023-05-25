using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
    public abstract class Query : IQuery
    {
        public string RenderQuery(IRenderer renderer)
        {
            StringBuilder sql = new StringBuilder();
            RenderQuery(renderer, sql);

            return sql.ToString();
        }

        public abstract void RenderQuery(IRenderer renderer, StringBuilder sql);
    }
}
