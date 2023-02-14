using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder.Abstractions
{
	public abstract class Value<TValue> : IValue
	{
		private TValue _data;

		public Value(TValue value)
		{
			Validate(value, nameof(value));

			_data = value;
		}

		public virtual TValue Data
		{
			get => _data;
			set => _data = Validate(value, nameof(Data));
		}

		public string RenderValue(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderValue(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public abstract void RenderValue(IRenderer renderer, StringBuilder stringBuilder);

		public string RenderExpression(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderExpression(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public virtual void RenderExpression(IRenderer renderer, StringBuilder stringBuilder) => RenderValue(renderer, stringBuilder);

		protected virtual TValue Validate(TValue value, string parameterName) => value;
	}
}
