using YuraSoft.QueryBuilder.Common;

namespace YuraSoft.QueryBuilder.PostgreSql
{
    public static class IQueryExtensions
    {
        private static readonly IRenderer _renderer = new PostgreSqlRenderer();

        public static string GetSql(this IQuery query) => query.RenderQuery(_renderer);
    }
}
