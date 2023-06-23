using System.Text;

using YuraSoft.QueryBuilder.Common;

namespace YuraSoft.QueryBuilder.PostgreSql
{
    public static class IQueryExtensions
    {
        private static readonly IRenderer _renderer = new PostgreSqlRenderer();

        public static string GetSql(this IQuery query)
        {
            StringBuilder sql = new StringBuilder();
            query.RenderQuery(_renderer, sql);

            return sql.ToString();
        }
    }
}
