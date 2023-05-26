using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class CoalesceFunction : ExpressionFunction
	{
		public CoalesceFunction(IExpression expression, IExpression defaultExpression) : base(expression) =>
			DefaultExpression = Guard.ThrowIfNull(defaultExpression, nameof(defaultExpression));

		public readonly IExpression DefaultExpression;

		public override void RenderFunction(IRenderer renderer, StringBuilder sql) => renderer.RenderFunction(this, sql);
	}
}
