using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class NativeFunction : Function
	{
		public NativeFunction(string name, IEnumerable<IExpression>? parameters = null)
		{
			Name = Guard.ThrowIfNullOrEmpty(name, nameof(name));
			Parameters = parameters != null ? new List<IExpression>(parameters) : null;
		}

		public readonly string Name;
		public readonly List<IExpression>? Parameters;

		public override void RenderFunction(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderFunction(this, sql);
	}
}
