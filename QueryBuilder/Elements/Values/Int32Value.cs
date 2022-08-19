using System.Text;

using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class Int32Value : Value<int>
	{
		public static implicit operator int(Int32Value value) => value.Data;

		public Int32Value(int value) : base(value)
		{
		}

		public static implicit operator Int32Value(int value) => new Int32Value(value);

		public override void RenderValue(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderValue(this, stringBuilder);
	}
}
