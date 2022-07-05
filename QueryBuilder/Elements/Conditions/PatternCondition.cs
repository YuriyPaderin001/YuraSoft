using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;

namespace YuraSoft.QueryBuilder
{
	public abstract class PatternCondition : UnaryCondition
	{
		private string _pattern;

		public PatternCondition(IExpression expression, string pattern) : base(expression)
		{
			Validate(pattern, nameof(pattern));

			_pattern = pattern;
		}

		public string Pattern
		{
			get => _pattern;
			set
			{
				Validate(value, nameof(Pattern));

				_pattern = value;
			}
		}

		private void Validate(string pattern, string parameterName)
		{
			if (string.IsNullOrEmpty(pattern))
			{
				throw new ArgumentShouldNotBeNullOrEmptyException(nameof(pattern));
			}
		}
	}
}
