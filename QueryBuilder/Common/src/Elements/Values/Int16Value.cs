using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public class Int16Value : Value<short>
	{
		public Int16Value(short value) : base(value)
		{
		}

		public static implicit operator Int16Value(short value) => new Int16Value(value);

		public override void RenderValue(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderValue(this, stringBuilder);
	}
}
