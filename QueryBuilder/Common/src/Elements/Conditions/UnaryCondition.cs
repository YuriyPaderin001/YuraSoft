using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
    public abstract class UnaryCondition : Condition
    {
        public UnaryCondition(IExpression expression) =>
            Expression = Guard.ThrowIfNull(expression, nameof(expression));

        public readonly IExpression Expression;
    }
}
