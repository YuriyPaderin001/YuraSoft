using System.Text;
using YuraSoft.QueryBuilder.Common;

namespace YuraSoft.QueryBuilder.PostgreSql
{
    public class ArrayAggFunction : ExpressionFunction
    {
        public ArrayAggFunction(IExpression expression) : base(expression)
        {
        }

        public override void RenderFunction(IRenderer renderer, StringBuilder sql) =>
            renderer.RenderFunction(this, sql);
    }
}
