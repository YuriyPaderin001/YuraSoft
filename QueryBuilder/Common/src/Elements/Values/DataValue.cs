namespace YuraSoft.QueryBuilder.Common
{
	public abstract class DataValue<TValue> : Value
	{
		public DataValue(TValue value) => 
			Data = Validate(value, nameof(value));

		public readonly TValue Data;

		protected virtual TValue Validate(TValue value, string parameterName) => value;
	}
}
