using System.Collections.Generic;
using System.Linq;

using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public abstract class LogicalCondition : ICondition 
	{
		private List<ICondition> _conditions;

		public LogicalCondition(IEnumerable<ICondition> conditions)
		{
			Validate(conditions, nameof(conditions));

			_conditions = new List<ICondition>(conditions);
		}

		public virtual List<ICondition> Conditions
		{
			get => _conditions;
			set
			{
				Validate(value, nameof(Conditions));

				_conditions = value;
			}
		}

		protected virtual void Validate(IEnumerable<ICondition> conditions, string parameterName)
		{
			if (conditions == null)
			{
				throw new ArgumentShouldNotBeNullException(parameterName);
			}

			if (!conditions.Any())
			{
				throw new CollectionShouldNotBeEmptyException(parameterName);
			}
		}

		public abstract string RenderCondition(IRenderer renderer);
	}
}
