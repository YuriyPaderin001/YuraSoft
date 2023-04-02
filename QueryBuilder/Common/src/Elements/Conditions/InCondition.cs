using System.Collections.Generic;
using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
    public class InCondition : CollectionCondition
    {
        public InCondition(IExpression expression, IEnumerable<IExpression> values) : base(expression, values)
        {
        }

        public override void RenderCondition(IRenderer renderer, StringBuilder sql) => renderer.RenderCondition(this, sql);
    }
}
