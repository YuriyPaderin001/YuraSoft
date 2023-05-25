using System.Text;

using YuraSoft.QueryBuilder.Common;

namespace YuraSoft.QueryBuilder.PostgreSql
{
    public static class IRendererExtensions
    {
        public static void RenderValue(this IRenderer renderer, BoolValue value, StringBuilder sql) =>
            ((PostgreSqlRenderer)renderer).RenderValue(value, sql);
    }
}
