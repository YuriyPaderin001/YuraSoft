using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public abstract class ArithmeticExpression : IExpression
	{
		private List<IExpression> _expressions;

		public ArithmeticExpression(IEnumerable<IExpression> expressions)
		{
			_expressions = new List<IExpression>(Guard.ThrowIfNullOrSizeLessThan(expressions, 2, nameof(expressions)));
		}

		public List<IExpression> Expressions
		{
			get => _expressions;
			set => _expressions = Guard.ThrowIfNullOrSizeLessThan(value, 2, nameof(Expressions));
		}

		public string RenderExpression(IRenderer renderer)
		{
			StringBuilder sql = new StringBuilder();
			RenderExpression(renderer, sql);

			return sql.ToString();
		}

		public abstract void RenderExpression(IRenderer renderer, StringBuilder sql);
	}
}
