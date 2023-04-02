using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
    public class NotExistsCondition : Condition
    {
        private Select _select;

        public NotExistsCondition(Select select)
        {
            _select = Guard.ThrowIfNull(select, nameof(select));
        }

        public Select Select
        {
            get => _select;
            set => _select = Guard.ThrowIfNull(value, nameof(Select));
        }
    }
}
