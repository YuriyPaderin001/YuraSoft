using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public abstract class PatternCondition : UnaryCondition
	{
		private string _pattern;

		public PatternCondition(IExpression expression, string pattern) : base(expression)
		{
			_pattern = Validator.ThrowIfArgumentIsNullOrEmpty(pattern, nameof(pattern));
		}

		public string Pattern
		{
			get => _pattern;
			set => _pattern = Validator.ThrowIfArgumentIsNullOrEmpty(value, nameof(Pattern));
		}
	}
}
