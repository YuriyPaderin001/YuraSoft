using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public class Int64Value : Value<long>
	{
		public Int64Value(long value) : base(value)
		{
		}

		public static implicit operator Int64Value(long value) => new Int64Value(value);

		public override void RenderValue(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderValue(this, stringBuilder);
	}
}
