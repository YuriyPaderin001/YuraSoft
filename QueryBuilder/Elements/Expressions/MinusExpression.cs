using System.Collections.Generic;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class MinusExpression : ArithmeticExpression
	{
		public MinusExpression(IEnumerable<IExpression> expressions) : base(expressions)
		{ 
		}

		public override string RenderExpression(IRenderer renderer) => renderer.RenderExpression(this);
	}
}
