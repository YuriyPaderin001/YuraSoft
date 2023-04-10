namespace YuraSoft.QueryBuilder.Common
{
	public abstract class DataValue<TValue> : Value
	{
		private TValue _data;

		public DataValue(TValue value)
		{
			Validate(value, nameof(value));

			_data = value;
		}

		public virtual TValue Data
		{
			get => _data;
			set => _data = Validate(value, nameof(Data));
		}

		protected virtual TValue Validate(TValue value, string parameterName) => value;
	}
}
