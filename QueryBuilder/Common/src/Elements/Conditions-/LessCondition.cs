﻿using System.Text;

using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class LessCondition : BinaryCondition
	{
		public LessCondition(IExpression leftExpression, IExpression rightExpression) : base(leftExpression, rightExpression)
		{
		}

		public override void RenderCondition(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderCondition(this, stringBuilder);
	}
}
