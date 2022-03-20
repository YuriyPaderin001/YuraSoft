using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder.Abstractions
{
	public abstract class UnaryValue<TValue> : IValue
	{
		public UnaryValue(TValue value)
		{
			Value = value;
		}

		public virtual TValue Value { get; set; }

		public abstract string RenderValue(IRenderer renderer);
		public virtual string RenderExpression(IRenderer renderer) => RenderValue(renderer);
	}
}
