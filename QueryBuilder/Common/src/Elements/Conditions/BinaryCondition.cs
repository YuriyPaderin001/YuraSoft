using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
    public abstract class BinaryCondition : Condition
    {
        public BinaryCondition(IExpression leftExpression, IExpression rightExpression)
        {
            LeftExpression = Guard.ThrowIfNull(leftExpression, nameof(leftExpression));
            RightExpression = Guard.ThrowIfNull(rightExpression, nameof(rightExpression));
        }

        public readonly IExpression LeftExpression;
        public readonly IExpression RightExpression;
    }
}
