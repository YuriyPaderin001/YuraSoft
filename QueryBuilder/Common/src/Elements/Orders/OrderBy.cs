using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class OrderBy : IOrderBy
	{
		private IColumn _column;

		public OrderBy(IColumn column, OrderDirection direction)
		{
			_column = Guard.ThrowIfNull(column, nameof(column));
			Direction = direction;
		}

		public IColumn Column 
		{ 
			get => _column; 
			set => _column = Guard.ThrowIfNull(value, nameof(Column));
		}

		public virtual OrderDirection Direction { get; set; }

		public string RenderOrderBy(IRenderer renderer)
		{
			StringBuilder sql = new StringBuilder();
			RenderOrderBy(renderer, sql);

			return sql.ToString();
		}

		public void RenderOrderBy(IRenderer renderer, StringBuilder sql) => renderer.RenderOrderBy(this, sql);
	}
}
