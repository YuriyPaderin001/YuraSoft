using System.Text;

namespace YuraSoft.QueryBuilder.Common
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
			StringBuilder sql = new StringBuilder();
			RenderValue(renderer, sql);

			return sql.ToString();
		}

		public abstract void RenderValue(IRenderer renderer, StringBuilder sql);

		public string RenderExpression(IRenderer renderer)
		{
			StringBuilder sql = new StringBuilder();
			RenderExpression(renderer, sql);

			return sql.ToString();
		}

		public virtual void RenderExpression(IRenderer renderer, StringBuilder sql) => RenderValue(renderer, sql);

		protected virtual TValue Validate(TValue value, string parameterName) => value;
	}
}
