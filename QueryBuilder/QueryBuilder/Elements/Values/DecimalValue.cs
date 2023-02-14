using System.Text;

using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class DecimalValue : Value<decimal>
	{
		public DecimalValue(decimal value) : base(value)
		{
		}

		public static implicit operator DecimalValue(decimal value) => new DecimalValue(value);

		public override void RenderValue(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderValue(this, stringBuilder);
	}
}
