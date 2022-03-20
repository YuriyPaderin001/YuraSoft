using System.Collections.Generic;

using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class InCondition : ICondition
	{
		private IExpression _expression;
		private IEnumerable<IExpression> _valueExpressions;

		public InCondition(IExpression expression, IEnumerable<IExpression> valueExpressions)
		{
			_expression = expression ?? throw new ArgumentShouldNotBeNullException(nameof(expression));
			
			if (valueExpressions == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(valueExpressions));
			}
			else if (!valueExpressions.GetEnumerator().MoveNext())
			{
				throw new CollectionShouldNotBeEmptyException(nameof(valueExpressions));
			}

			_valueExpressions = valueExpressions;
		}

		public IExpression Expression 
		{ 
			get => _expression; 
			set => _expression = value ?? throw new ArgumentShouldNotBeNullException(nameof(Expression)); 
		}

		public IEnumerable<IExpression> ValueExpressions 
		{ 
			get => _valueExpressions;
			set
			{
				if (value == null)
				{
					throw new ArgumentShouldNotBeNullException(nameof(ValueExpressions));
				}
				else if (!value.GetEnumerator().MoveNext())
				{
					throw new CollectionShouldNotBeEmptyException(nameof(ValueExpressions));
				}

				_valueExpressions = value;
			}
		}

		public string RenderCondition(IRenderer renderer) => renderer.RenderCondition(this);
	}
}
