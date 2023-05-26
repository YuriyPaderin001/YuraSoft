using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
    public class RoundFunction : ExpressionFunction
    {
        public RoundFunction(IExpression expression, int? precision = null) : base(expression) =>
            Precision = precision;

        public readonly int? Precision;

        public override void RenderFunction(IRenderer renderer, StringBuilder sql) =>
            renderer.RenderFunction(this, sql);
    }
}
