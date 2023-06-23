using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public abstract class ExpressionFunction : Function
	{
		public ExpressionFunction(IExpression expression) =>
			Expression = Guard.ThrowIfNull(expression, nameof(expression));

		public readonly IExpression Expression;
	}
}
