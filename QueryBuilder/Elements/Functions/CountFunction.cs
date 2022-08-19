﻿using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class CountFunction : ColumnFunction
	{
		public CountFunction(IColumn column) : base(column)
		{
		}

		public override void RenderFunction(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderFunction(this, stringBuilder);
	}
}
