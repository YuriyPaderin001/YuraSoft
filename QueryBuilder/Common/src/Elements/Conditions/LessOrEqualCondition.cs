﻿using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
    public class LessOrEqualCondition : BinaryCondition
    {
        public LessOrEqualCondition(IExpression leftExpression, IExpression rightExpression) : base(leftExpression, rightExpression)
        {
        }

        public override void RenderCondition(IRenderer renderer, StringBuilder sql) => renderer.RenderCondition(this, sql);
    }
}
