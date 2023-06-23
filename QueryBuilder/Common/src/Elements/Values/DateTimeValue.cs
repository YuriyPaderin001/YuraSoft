using System;
using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public class DateTimeValue : DataValue<DateTime>
	{
		public DateTimeValue(DateTime value, string? format = null) : base(value) => 
			Format = string.IsNullOrEmpty(format) ? "o" : format;

		public static implicit operator DateTimeValue(DateTime value) => new DateTimeValue(value);

		public readonly string Format;

		public override void RenderValue(IRenderer renderer, StringBuilder sql) => renderer.RenderValue(this, sql);
	}
}
