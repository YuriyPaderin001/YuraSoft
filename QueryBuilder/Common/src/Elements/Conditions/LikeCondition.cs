﻿using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
    public class LikeCondition : UnaryCondition
    {
        public LikeCondition(IExpression expression, IExpression pattern) : base(expression)
        {
            Pattern = Guard.ThrowIfNull(pattern, nameof(pattern));
        }

        public readonly IExpression Pattern;

        public override void RenderCondition(IRenderer renderer, StringBuilder sql) => renderer.RenderCondition(this, sql);
    }
}
