using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
    public class ExtractFunction : ExpressionFunction
    {
        public ExtractFunction(string part, IExpression expression) : base(expression) =>
            Part = Guard.ThrowIfNullOrEmpty(part, nameof(part));

        public readonly string Part;

        public override void RenderFunction(IRenderer renderer, StringBuilder sql) =>
            renderer.RenderFunction(this, sql);
    }
}
