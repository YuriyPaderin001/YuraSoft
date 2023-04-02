using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public abstract class ExpressionFunction : FunctionBase
	{
		private IExpression _expression;

		public ExpressionFunction(IExpression expression)
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
