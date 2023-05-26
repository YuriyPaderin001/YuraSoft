using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
    public class NotExistsCondition : Condition
    {
        public NotExistsCondition(Select select) =>
            Select = Guard.ThrowIfNull(select, nameof(select));

        public readonly Select Select;

        public override void RenderCondition(IRenderer renderer, StringBuilder sql) =>
            renderer.RenderCondition(this, sql);
    }
}
