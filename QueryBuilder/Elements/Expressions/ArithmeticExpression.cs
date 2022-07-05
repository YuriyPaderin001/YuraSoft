using System.Collections.Generic;
using System.Linq;

using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public abstract class ArithmeticExpression : IExpression
	{
		private List<IExpression> _expressions;

		public ArithmeticExpression(IEnumerable<IExpression> expressions)
		{
			if (expressions == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(expressions));
			}
			else if (expressions.Count() < 2)
			{
				throw new CollectionShouldNotBeLessThanException(nameof(expressions), 2);
			}

			_expressions = new List<IExpression>(expressions);
		}

		public List<IExpression> Expressions
		{
			get => _expressions;
			set
			{
				if (value == null)
				{
					throw new ArgumentShouldNotBeNullException(nameof(Expressions));
				}
				else if (value.Count() < 2)
				{
					throw new CollectionShouldNotBeLessThanException(nameof(Expressions), 2);
				}

				_expressions = value;
			}
		}

		public abstract string RenderExpression(IRenderer renderer);
	}
}
