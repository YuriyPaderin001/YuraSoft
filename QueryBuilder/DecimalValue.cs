using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class DecimalValue : UnaryValue<decimal>
	{
		public DecimalValue(decimal value) : base(value)
		{
		}

		public static implicit operator DecimalValue(decimal value) => new DecimalValue(value);

		public override string RenderValue(IRenderer renderer) => renderer.RenderValue(this);
	}
}
