using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class NotEqualCondition : BinaryCondition
	{
		public NotEqualCondition(IExpression leftExpression, IExpression rightExpression) : base(leftExpression, rightExpression)
		{
		}

		public override string RenderCondition(IRenderer renderer) => renderer.RenderCondition(this);
	}
}
