using System.Text;

using YuraSoft.QueryBuilder.Common;

namespace YuraSoft.QueryBuilder.PostgreSql
{
    public static class IRendererExtensions
    {
        public static void RenderDistinct(this IRenderer renderer, DistinctOn distinct, StringBuilder sql) =>
            ((PostgreSqlRenderer)renderer).RenderDistinct(distinct, sql);

        public static void RenderFunction(this IRenderer renderer, AnyFunction function, StringBuilder sql) =>
            ((PostgreSqlRenderer)renderer).RenderFunction(function, sql);

        public static void RenderFunction(this IRenderer renderer, ArrayAggFunction function, StringBuilder sql) =>
            ((PostgreSqlRenderer)renderer).RenderFunction(function, sql);

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

        public static void RenderValue(this IRenderer renderer, IntervalValue value, StringBuilder sql) =>
            ((PostgreSqlRenderer)renderer).RenderValue(value, sql);
    }
}
