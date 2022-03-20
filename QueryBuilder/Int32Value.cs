using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class Int32Value : UnaryValue<int>
	{
		public Int32Value(int value) : base(value)
		{
		}

		public override string RenderValue(IRenderer renderer) => renderer.RenderValue(this);
	}
}
