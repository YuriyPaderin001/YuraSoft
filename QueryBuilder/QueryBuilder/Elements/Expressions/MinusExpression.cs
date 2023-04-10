using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class MinusExpression : ArithmeticExpression
	{
		public MinusExpression(IEnumerable<IExpression> expressions) : base(expressions)
		{
		}

		public override void RenderExpression(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderExpression(this, stringBuilder);
	}
}
