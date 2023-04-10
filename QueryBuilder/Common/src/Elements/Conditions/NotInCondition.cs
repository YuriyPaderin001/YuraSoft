using System.Collections.Generic;
using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
    public class NotInCondition : CollectionCondition
    {
        public NotInCondition(IExpression expression, IEnumerable<IExpression> values) : base(expression, values)
        {
        }

        public override void RenderCondition(IRenderer renderer, StringBuilder sql) => renderer.RenderCondition(this, sql);
    }
}
