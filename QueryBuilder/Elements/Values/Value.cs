using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

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
			set
			{
				Validate(value, nameof(Data));

				_data = value;
			}
		}

		protected virtual void Validate(TValue value, string parameterName)
		{
		}

		public abstract string RenderValue(IRenderer renderer);
		public virtual string RenderExpression(IRenderer renderer) => RenderValue(renderer);
	}
}
