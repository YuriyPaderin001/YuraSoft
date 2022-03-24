using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class Int8Value : UnaryValue<sbyte>
	{
		public Int8Value(sbyte value) : base(value)
		{
		}

		public static implicit operator Int8Value(sbyte value) => new Int8Value(value);

		public override string RenderValue(IRenderer renderer) => renderer.RenderValue(this);
	}
}
