using System.Collections.Generic;

using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class NotInCondition : ICondition
	{
		private IExpression _expression;
		private IEnumerable<IExpression> _values;

		public NotInCondition(IExpression expression, IEnumerable<IExpression> values)
		{
			_expression = expression ?? throw new ArgumentShouldNotBeNullException(nameof(expression));
			
			if (values == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(values));
			}
			else if (!values.GetEnumerator().MoveNext())
			{
				throw new CollectionShouldNotBeEmptyException(nameof(values));
			}

			_values = values;
		}

		public IExpression Expression 
		{ 
			get => _expression; 
			set => _expression = value ?? throw new ArgumentShouldNotBeNullException(nameof(Expression)); 
		}

		public IEnumerable<IExpression> Values 
		{ 
			get => _values;
			set
			{
				if (value == null)
				{
					throw new ArgumentShouldNotBeNullException(nameof(Values));
				}
				else if (!value.GetEnumerator().MoveNext())
				{
					throw new CollectionShouldNotBeEmptyException(nameof(Values));
				}

				_values = value;
			}
		}

		public string RenderCondition(IRenderer renderer) => renderer.RenderCondition(this);
	}
}
