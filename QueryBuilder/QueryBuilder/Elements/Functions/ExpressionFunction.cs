using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public abstract class ExpressionFunction : FunctionBase
	{
		private IExpression _expression;

		public ExpressionFunction(IExpression expression)
		{
			_expression = Validator.ThrowIfArgumentIsNull(expression, nameof(expression));
		}

		public IExpression Expression
		{
			get => _expression;
			set => _expression = Validator.ThrowIfArgumentIsNull(value, nameof(Expression));
		}
	}
}
