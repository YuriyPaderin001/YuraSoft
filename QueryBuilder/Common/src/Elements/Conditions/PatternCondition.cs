using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
    public abstract class PatternCondition : UnaryCondition
    {
        private string _pattern;

        public PatternCondition(IExpression expression, string pattern) : base(expression)
        {
            _pattern = Guard.ThrowIfNullOrEmpty(pattern, nameof(pattern));
        }

        public string Pattern
        {
            get => _pattern;
            set => _pattern = Guard.ThrowIfNullOrEmpty(value, nameof(Pattern));
        }
    }
}
