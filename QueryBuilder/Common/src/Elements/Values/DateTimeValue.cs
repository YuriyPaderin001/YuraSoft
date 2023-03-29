using System;
using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public class DateTimeValue : Value<DateTime>
	{
		private string _format;

		public DateTimeValue(DateTime value, string? format = null) : base(value)
		{
			_format = string.IsNullOrEmpty(format) ? "o" : format;
		}

		public static implicit operator DateTimeValue(DateTime value) => new DateTimeValue(value);

		public string Format
		{
			get => _format;
			set => _format = string.IsNullOrEmpty(value) ? "o" : value;
		}

		public override void RenderValue(IRenderer renderer, StringBuilder sql) => renderer.RenderValue(this, sql);
	}
}
