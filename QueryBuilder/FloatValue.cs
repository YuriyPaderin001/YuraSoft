using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class FloatValue : UnaryValue<float>
	{
		public FloatValue(float value) : base(value)
		{
		}

		public static implicit operator FloatValue(float value) => new FloatValue(value);

		public override string RenderValue(IRenderer renderer) => renderer.RenderValue(this);
	}
}
