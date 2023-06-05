using System.Text;

using YuraSoft.QueryBuilder.Common;

namespace YuraSoft.QueryBuilder.PostgreSql
{
    public static class IRendererExtensions
    {
        public static void RenderFunction(this IRenderer renderer, CountWindowFunction function, StringBuilder sql) =>
            ((PostgreSqlRenderer)renderer).RenderFunction(function, sql);

        public static void RenderFunction(this IRenderer renderer, MaxWindowFunction function, StringBuilder sql) =>
            ((PostgreSqlRenderer)renderer).RenderFunction(function, sql);

        public static void RenderFunction(this IRenderer renderer, MinWindowFunction function, StringBuilder sql) =>
            ((PostgreSqlRenderer)renderer).RenderFunction(function, sql);

        public static void RenderFunction(this IRenderer renderer, SumWindowFunction function, StringBuilder sql) =>
            ((PostgreSqlRenderer)renderer).RenderFunction(function, sql);

        public static void RenderValue(this IRenderer renderer, BoolValue value, StringBuilder sql) =>
            ((PostgreSqlRenderer)renderer).RenderValue(value, sql);
    }
}
