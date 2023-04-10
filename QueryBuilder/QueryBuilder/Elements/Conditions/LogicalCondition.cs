using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public abstract class LogicalCondition : ICondition
	{
		private List<ICondition> _conditions;

		public LogicalCondition(IEnumerable<ICondition> conditions)
		{
			_conditions = new List<ICondition>(Validator.ThrowIfArgumentIsNullOrEmpty(conditions, nameof(conditions)));
		}

		public virtual List<ICondition> Conditions
		{
			get => _conditions;
			set => _conditions = Validator.ThrowIfArgumentIsNullOrEmpty(value, nameof(Conditions));
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
