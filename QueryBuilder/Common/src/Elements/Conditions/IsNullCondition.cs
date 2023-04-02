using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
    public class IsNullCondition : UnaryCondition
    {
        public IsNullCondition(IExpression expression) : base(expression)
        {
        }

        public override void RenderCondition(IRenderer renderer, StringBuilder sql) => renderer.RenderCondition(this, sql);
    }
}
