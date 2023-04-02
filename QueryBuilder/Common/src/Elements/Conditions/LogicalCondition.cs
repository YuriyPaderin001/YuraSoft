using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
    public abstract class LogicalCondition : Condition
    {
        private List<ICondition> _conditions;

        public LogicalCondition(IEnumerable<ICondition> conditions)
        {
            _conditions = new List<ICondition>(Guard.ThrowIfNullOrEmpty(conditions, nameof(conditions)));
        }

        public virtual List<ICondition> Conditions
        {
            get => _conditions;
            set => _conditions = Guard.ThrowIfNullOrEmpty(value, nameof(Conditions));
        }
    }
}
