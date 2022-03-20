using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class DoubleValue : UnaryValue<double>
	{
		public DoubleValue(double value) : base(value)
		{
		}

		public override string RenderValue(IRenderer renderer) => renderer.RenderValue(this);
	}
}
