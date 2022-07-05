using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class Int64Value : Value<long>
	{
		public Int64Value(long value) : base(value)
		{
		}

		public static implicit operator Int64Value(long value) => new Int64Value(value);

		public override string RenderValue(IRenderer renderer) => renderer.RenderValue(this);
	}
}
