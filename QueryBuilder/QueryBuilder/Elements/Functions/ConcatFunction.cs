using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;
using YuraSoft.QueryBuilder.Renderers;

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

		public override void RenderFunction(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderFunction(this, stringBuilder);
	}
}
