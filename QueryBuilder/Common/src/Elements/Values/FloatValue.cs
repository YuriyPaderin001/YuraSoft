using System.Text;

using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
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
