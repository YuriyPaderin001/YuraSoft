﻿using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public class DoubleValue : DataValue<double>
	{
		public DoubleValue(double value) : base(value)
		{
		}

		public static implicit operator DoubleValue(double value) => new DoubleValue(value);

		public override void RenderValue(IRenderer renderer, StringBuilder sql) => renderer.RenderValue(this, sql);
	}
}
