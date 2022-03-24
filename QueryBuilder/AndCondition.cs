using System.Collections.Generic;

using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class AndCondition : ICondition
	{
		private List<ICondition> _conditions;

		public AndCondition(IEnumerable<ICondition> conditions)
		{
			if (conditions == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(conditions));
			}

			if (!conditions.GetEnumerator().MoveNext())
			{
				throw new CollectionShouldNotBeEmptyException(nameof(conditions));
			}

			_conditions = new List<ICondition>(conditions);
		}

		public List<ICondition> Conditions
		{
			get => _conditions;
			set
			{
				if (value == null)
				{
					throw new ArgumentShouldNotBeNullException(nameof(Conditions));
				}

				if (!value.GetEnumerator().MoveNext())
				{
					throw new CollectionShouldNotBeEmptyException(nameof(Conditions));
				}

				_conditions = value;
			}
		}

		public string RenderCondition(IRenderer renderer) => renderer.RenderCondition(this);
	}
}
