using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class LessOrEqualCondition : BinaryCondition
	{
		public LessOrEqualCondition(IExpression leftExpression, IExpression rightExpression) : base(leftExpression, rightExpression)
		{
		}

		public override string RenderCondition(IRenderer renderer) => renderer.RenderCondition(this);
	}
}
