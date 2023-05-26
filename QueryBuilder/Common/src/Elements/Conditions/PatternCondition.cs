using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
    public abstract class PatternCondition : UnaryCondition
    {
        public PatternCondition(IExpression expression, string pattern) : base(expression) =>
            Pattern = Guard.ThrowIfNullOrEmpty(pattern, nameof(pattern));

        public readonly string Pattern;
    }
}
