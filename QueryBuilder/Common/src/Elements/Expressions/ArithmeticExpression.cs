using System.Collections.Generic;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public abstract class ArithmeticExpression : Expression
	{
		public ArithmeticExpression(IEnumerable<IExpression> expressions) =>
			Expressions = new List<IExpression>(Guard.ThrowIfNullOrSizeLessThan(expressions, 2, nameof(expressions)));

		public readonly List<IExpression> Expressions;
	}
}
