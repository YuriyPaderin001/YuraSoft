using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class MultiplyExpression : ArithmeticExpression
	{
		public MultiplyExpression(IEnumerable<IExpression> expressions) : base(expressions)
		{
		}

		public override void RenderExpression(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderExpression(this, stringBuilder);
	}
}
