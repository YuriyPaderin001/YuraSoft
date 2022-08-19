using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public abstract class ColumnFunction : FunctionBase
	{
		private IColumn _column;

		public ColumnFunction(IColumn column)
		{
			_column = Validator.ThrowIfArgumentIsNull(column, nameof(column));
		}

		public IColumn Column
		{
			get => _column;
			set => _column = Validator.ThrowIfArgumentIsNull(value, nameof(Column));
		}
	}
}
