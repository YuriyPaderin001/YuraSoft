using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class IsNullCondition : UnaryCondition
	{
		public IsNullCondition(IExpression expression) : base(expression)
		{
		}

		public override void RenderCondition(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderCondition(this, stringBuilder);
	}
}
