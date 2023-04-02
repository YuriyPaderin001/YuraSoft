using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
    public abstract class BinaryCondition : Condition
    {
        private IExpression _leftExpression;
        private IExpression _rightExpression;

        public BinaryCondition(IExpression leftExpression, IExpression rightExpression)
        {
            _leftExpression = Guard.ThrowIfNull(leftExpression, nameof(leftExpression));
            _rightExpression = Guard.ThrowIfNull(rightExpression, nameof(rightExpression));
        }

        public IExpression LeftExpression
        {
            get => _leftExpression;
            set => _leftExpression = Guard.ThrowIfNull(value, nameof(LeftExpression));
        }

        public IExpression RightExpression
        {
            get => _rightExpression;
            set => _rightExpression = Guard.ThrowIfNull(value, nameof(RightExpression));
        }
    }
}
