using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class EqualCondition : BinaryCondition
	{
		public EqualCondition(IExpression leftExpression, IExpression rightExpression) : base(leftExpression, rightExpression)
		{
		}

		public override string RenderCondition(IRenderer renderer) => renderer.RenderCondition(this);
	}
}
