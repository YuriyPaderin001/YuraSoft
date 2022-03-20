using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class Int16Value : UnaryValue<short>
	{
		public Int16Value(short value) : base(value)
		{
		}

		public override string RenderValue(IRenderer renderer) => renderer.RenderValue(this);
	}
}
