using System.Collections.Generic;
using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public class DivideExpression : ArithmeticExpression
	{
		public DivideExpression(IEnumerable<IExpression> expressions) : base(expressions)
		{ 
		}

		public override void RenderExpression(IRenderer renderer, StringBuilder sql) => renderer.RenderExpression(this, sql);
	}
}
