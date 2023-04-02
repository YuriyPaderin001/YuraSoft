using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class ConcatFunction : FunctionBase
	{
		private List<IExpression> _values;

		public ConcatFunction(IEnumerable<IExpression> values) 
		{
			_values = new List<IExpression>(Guard.ThrowIfNullOrEmpty(values, nameof(values)));
		}

		public List<IExpression> Values 
		{ 
			get => _values;
			set => _values = new List<IExpression>(Guard.ThrowIfNullOrEmpty(value, nameof(Values)));
		}

		public override void RenderFunction(IRenderer renderer, StringBuilder sql) => renderer.RenderFunction(this, sql);
	}
}
