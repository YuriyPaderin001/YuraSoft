using System.Collections.Generic;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public abstract class CollectionCondition : UnaryCondition
	{
		private List<IExpression> _values;

		public CollectionCondition(IExpression expression, IEnumerable<IExpression> values) : base(expression)
		{
			_values = new List<IExpression>(Validator.ThrowIfArgumentIsNullOrEmpty(values, nameof(values)));
		}

		public List<IExpression> Values
		{
			get => _values;
			set => _values = Validator.ThrowIfArgumentIsNullOrEmpty(value, nameof(Values));
		}
	}
}
