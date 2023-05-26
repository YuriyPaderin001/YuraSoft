using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class CastFunction : ExpressionFunction
	{
		public CastFunction(IExpression expression, string type) : base(expression) =>
			Type = Guard.ThrowIfNullOrEmpty(type, nameof(type));

		public readonly string Type;

		public override void RenderFunction(IRenderer renderer, StringBuilder sql) =>
			renderer.RenderFunction(this, sql);
	}
}
