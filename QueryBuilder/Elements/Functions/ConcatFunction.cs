using System.Collections.Generic;
using System.Linq;

using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class ConcatFunction : FunctionBase
	{
		private List<IExpression> _values;

		public ConcatFunction(IEnumerable<IExpression> values) 
		{
			if (values == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(values));
			}
			else if (!values.Any())
			{
				throw new CollectionShouldNotBeEmptyException(nameof(values));
			}

			_values = new List<IExpression>(values);
		}

		public List<IExpression> Values 
		{ 
			get => _values;
			set
			{
				if (value == null)
				{
					throw new ArgumentShouldNotBeNullException(nameof(Values));
				}
				else if (!value.Any())
				{
					throw new CollectionShouldNotBeEmptyException(nameof(Values));
				}

				_values = value;
			} 
		}

		public override string RenderFunction(IRenderer renderer) => renderer.RenderFunction(this);
	}
}
