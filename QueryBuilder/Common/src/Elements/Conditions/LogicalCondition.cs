using System.Collections.Generic;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
    public abstract class LogicalCondition : Condition
    {
        public LogicalCondition(IEnumerable<ICondition> conditions) =>
            Conditions = new List<ICondition>(Guard.ThrowIfNullOrEmpty(conditions, nameof(conditions)));

        public readonly List<ICondition> Conditions;
    }
}
