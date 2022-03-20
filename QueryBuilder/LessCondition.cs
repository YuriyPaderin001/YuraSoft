using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class LessCondition : BinaryCondition
	{
		public LessCondition(IExpression leftExpression, IExpression rightExpression) : base(leftExpression, rightExpression)
		{
		}

		public override string RenderCondition(IRenderer renderer) => renderer.RenderCondition(this);
	}
}
