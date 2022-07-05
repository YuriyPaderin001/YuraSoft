using System.Collections.Generic;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class MultiplyExpression : ArithmeticExpression
	{
		public MultiplyExpression(IEnumerable<IExpression> expressions) : base(expressions)
		{ 
		}

		public override string RenderExpression(IRenderer renderer) => renderer.RenderExpression(this);
	}
}
