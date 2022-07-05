using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class Int16Value : Value<short>
	{
		public Int16Value(short value) : base(value)
		{
		}

		public static implicit operator Int16Value(short value) => new Int16Value(value);

		public override string RenderValue(IRenderer renderer) => renderer.RenderValue(this);
	}
}
