﻿using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class LeftJoin : ConditionalJoin
	{
		public LeftJoin(ISource source, ICondition condition) : base(source, condition)
		{
		}

		public override void RenderJoin(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderJoin(this, stringBuilder);
	}
}
