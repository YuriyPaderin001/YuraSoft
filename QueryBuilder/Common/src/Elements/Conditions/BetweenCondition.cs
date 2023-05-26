using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
    public class BetweenCondition : UnaryCondition
    {
        public BetweenCondition(IExpression expression, IExpression lessExpression, IExpression hightExpression) : base(expression)
        {
            LessExpression = Guard.ThrowIfNull(lessExpression, nameof(lessExpression));
            HightExpression = Guard.ThrowIfNull(hightExpression, nameof(hightExpression));
        }

        public readonly IExpression LessExpression;
        public readonly IExpression HightExpression;

        public override void RenderCondition(IRenderer renderer, StringBuilder sql) => renderer.RenderCondition(this, sql);
    }
}
