using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class NotLikeCondition : ICondition
	{
		private IExpression _expression;
		private string _pattern;

		public NotLikeCondition(IExpression expression, string pattern)
		{
			_expression = expression ?? throw new ArgumentShouldNotBeNullException(nameof(expression));

			if (string.IsNullOrEmpty(pattern))
			{
				throw new ArgumentShouldNotBeNullOrEmptyException(nameof(pattern));
			}

			_pattern = pattern;
		}

		public IExpression Expression
		{
			get => _expression;
			set => _expression = value ?? throw new ArgumentShouldNotBeNullException(nameof(Expression));
		}

		public string Pattern
		{
			get => _pattern;
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentShouldNotBeNullOrEmptyException(nameof(Pattern));
				}

				_pattern = value;
			}
		}

		public string RenderCondition(IRenderer renderer) => renderer.RenderCondition(this);
	}
}
