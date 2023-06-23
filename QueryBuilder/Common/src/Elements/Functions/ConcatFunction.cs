using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class ConcatFunction : Function
	{
		public ConcatFunction(IEnumerable<IExpression> values) =>
			Values = new List<IExpression>(Guard.ThrowIfNullOrEmpty(values, nameof(values)));

		public readonly List<IExpression> Values;

		public override void RenderFunction(IRenderer renderer, StringBuilder sql) => renderer.RenderFunction(this, sql);
	}
}
