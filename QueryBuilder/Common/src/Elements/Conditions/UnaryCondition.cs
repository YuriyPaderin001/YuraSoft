using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
    public abstract class UnaryCondition : Condition
    {
        private IExpression _expression;

        public UnaryCondition(IExpression expression)
        {
            _expression = Guard.ThrowIfNull(expression, nameof(expression));
        }

        public IExpression Expression
        {
            get => _expression;
            set => _expression = Guard.ThrowIfNull(value, nameof(Expression));
        }
    }
}
