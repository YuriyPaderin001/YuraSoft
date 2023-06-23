using System.Collections.Generic;
using System.Text;
using YuraSoft.QueryBuilder.Common;
using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.PostgreSql
{
    public class AnyFunction : Function
    {
        public AnyFunction(IEnumerable<IExpression> expressions)
        {
            Expressions = new List<IExpression>(Guard.ThrowIfNullOrContainsNullElements(expressions, nameof(expressions)));
        }

        public readonly List<IExpression> Expressions;

        public override void RenderFunction(IRenderer renderer, StringBuilder sql) =>
            renderer.RenderFunction(this, sql);
    }
}
