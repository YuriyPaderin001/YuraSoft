using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
    public class IsNotNullCondition : UnaryCondition
    {
        public IsNotNullCondition(IExpression expression) : base(expression)
        {
        }

        public override void RenderCondition(IRenderer renderer, StringBuilder sql) => renderer.RenderCondition(this, sql);
    }
}
