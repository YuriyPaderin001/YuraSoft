using System.Collections.Generic;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
    public abstract class CollectionCondition : UnaryCondition
    {
        public CollectionCondition(IExpression expression, IEnumerable<IExpression> values) : base(expression) =>
            Values = new List<IExpression>(Guard.ThrowIfNullOrEmpty(values, nameof(values)));

        public readonly List<IExpression> Values;
    }
}
