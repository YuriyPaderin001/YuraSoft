using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public abstract class ArithmeticExpression : IExpression
	{
		private List<IExpression> _expressions;

		public ArithmeticExpression(IEnumerable<IExpression> expressions)
		{
			_expressions = new List<IExpression>(Validator.ThrowIfArgumentIsNullOrArgumentSizeIsLessThan(expressions, 2, nameof(expressions)));
		}

		public List<IExpression> Expressions
		{
			get => _expressions;
			set => _expressions = Validator.ThrowIfArgumentIsNullOrArgumentSizeIsLessThan(value, 2, nameof(Expressions));
		}

		public string RenderExpression(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderExpression(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public abstract void RenderExpression(IRenderer renderer, StringBuilder stringBuilder);
	}
}
