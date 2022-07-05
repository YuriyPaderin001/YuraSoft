using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class Int32Value : Value<int>
	{
		public Int32Value(int value) : base(value)
		{
		}

		public static implicit operator Int32Value(int value) => new Int32Value(value);

		public override string RenderValue(IRenderer renderer) => renderer.RenderValue(this);
	}
}
