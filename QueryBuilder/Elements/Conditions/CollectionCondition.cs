using System.Collections.Generic;
using System.Linq;

using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;

namespace YuraSoft.QueryBuilder
{
	public abstract class CollectionCondition : UnaryCondition
	{
		private IEnumerable<IExpression> _values;

		public CollectionCondition(IExpression expression, IEnumerable<IExpression> values) : base(expression)
		{
			Validate(values, nameof(values));

			_values = values;
		}

		public IEnumerable<IExpression> Values
		{
			get => _values;
			set
			{
				Validate(value, nameof(Values));

				_values = value;
			}
		}

		private void Validate(IEnumerable<IExpression> values, string parameterName)
		{
			if (values == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(values));
			}
			else if (!values.Any())
			{
				throw new CollectionShouldNotBeEmptyException(nameof(values));
			}
		}
	}
}
