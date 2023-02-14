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

		#region Rendering methods

		public string RenderExpression(IRenderer renderer)
		{
			StringBuilder query = new StringBuilder();
			RenderExpression(renderer, query);

			return query.ToString();
		}

		public virtual void RenderExpression(IRenderer renderer, StringBuilder query) => RenderCondition(renderer, query);

		public string RenderCondition(IRenderer renderer)
		{
			StringBuilder query = new StringBuilder();
			RenderCondition(renderer, query);

			return query.ToString();
		}

		public abstract void RenderCondition(IRenderer renderer, StringBuilder query);

		#endregion Rendering methods
	}
}
