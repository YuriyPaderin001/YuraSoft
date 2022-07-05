using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;

namespace YuraSoft.QueryBuilder
{
	public abstract class ColumnFunction : FunctionBase
	{
		private IColumn _column;

		public ColumnFunction(IColumn column)
		{
			_column = column ?? throw new ArgumentShouldNotBeNullException(nameof(column));
		}

		public IColumn Column
		{
			get => _column;
			set => _column = value ?? throw new ArgumentShouldNotBeNullException(nameof(Column));
		}
	}
}
