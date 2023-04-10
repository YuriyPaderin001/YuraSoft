using System.Collections.Generic;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
    public abstract class CollectionCondition : UnaryCondition
    {
        private List<IExpression> _values;

        public CollectionCondition(IExpression expression, IEnumerable<IExpression> values) : base(expression)
        {
            _values = new List<IExpression>(Guard.ThrowIfNullOrEmpty(values, nameof(values)));
        }

        public List<IExpression> Values
        {
            get => _values;
            set => _values = Guard.ThrowIfNullOrEmpty(value, nameof(Values));
        }
    }
}
