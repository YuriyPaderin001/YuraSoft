using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
    public class NotLikeCondition : PatternCondition
    {
        public NotLikeCondition(IExpression expression, string pattern) : base(expression, pattern)
        {
        }

        public override void RenderCondition(IRenderer renderer, StringBuilder sql) => renderer.RenderCondition(this, sql);
    }
}
