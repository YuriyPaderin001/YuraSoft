using System.Collections.Generic;
using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
    public class AndCondition : LogicalCondition
    {
        public AndCondition(IEnumerable<ICondition> conditions) : base(conditions)
        {
        }

        public override void RenderCondition(IRenderer renderer, StringBuilder sql) => renderer.RenderCondition(this, sql);
    }
}
