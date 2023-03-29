using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public class ConcatFunction : FunctionBase
	{
		private List<IExpression> _values;

		public ConcatFunction(IEnumerable<IExpression> values)
		{
			_values = new List<IExpression>(Validator.ThrowIfArgumentIsNullOrEmpty(values, nameof(values)));
		}

		public List<IExpression> Values
		{
			get => _values;
			set => _values = new List<IExpression>(Validator.ThrowIfArgumentIsNullOrEmpty(value, nameof(Values)));
		}

		public override void RenderFunction(IRenderer renderer, StringBuilder query) => renderer.RenderFunction(this, query);
	}
}
