using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public class FloatValue : Value<float>
	{
		public FloatValue(float value) : base(value)
		{
		}

		public static implicit operator FloatValue(float value) => new FloatValue(value);

		public override void RenderValue(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderValue(this, stringBuilder);
	}
}
