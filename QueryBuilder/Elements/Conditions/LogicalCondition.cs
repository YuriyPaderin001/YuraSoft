using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;
using YuraSoft.QueryBuilder.Renderers;

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

		public string RenderCondition(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderCondition(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public abstract void RenderCondition(IRenderer renderer, StringBuilder stringBuilder);
	}
}
