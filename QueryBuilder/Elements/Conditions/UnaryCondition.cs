using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public abstract class UnaryCondition : ICondition
	{
		private IExpression _expression;

		public UnaryCondition(IExpression expression)
		{
			_expression = Validator.ThrowIfArgumentIsNull(expression, nameof(expression));
		}

		public IExpression Expression 
		{ 
			get => _expression; 
			set => _expression = Validator.ThrowIfArgumentIsNull(value, nameof(Expression));
		}

		public string RenderCondition(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderCondition(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public abstract void RenderCondition(IRenderer renderer, StringBuilder stringBuilder);
	}
}
