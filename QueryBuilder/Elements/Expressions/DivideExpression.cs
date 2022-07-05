using System.Collections.Generic;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class DivideExpression : ArithmeticExpression
	{
		public DivideExpression(IEnumerable<IExpression> expressions) : base(expressions)
		{ 
		}

		public override string RenderExpression(IRenderer renderer) => renderer.RenderExpression(this);
	}
}
