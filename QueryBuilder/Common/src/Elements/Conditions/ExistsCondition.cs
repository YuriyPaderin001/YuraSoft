using System.Text;
using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
    public class ExistsCondition : Condition
    {
        private Select _select;

        public ExistsCondition(Select select)
        {
            _select = Guard.ThrowIfNull(select, nameof(select));
        }

        public Select Select
        {
            get => _select;
            set => _select = Guard.ThrowIfNull(value, nameof(Select));
        }

        public override void RenderCondition(IRenderer renderer, StringBuilder sql) =>
            renderer.RenderCondition(this, sql);
    }
}
