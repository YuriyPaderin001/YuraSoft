using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class OrderBy : IOrderBy
	{
		public OrderBy(IColumn column, OrderDirection direction)
		{
			Column = Guard.ThrowIfNull(column, nameof(column));
			Direction = direction;
		}

		public readonly IColumn Column;

		public readonly OrderDirection Direction;

		public string RenderOrderBy(IRenderer renderer)
		{
			StringBuilder sql = new StringBuilder();
			RenderOrderBy(renderer, sql);

			return sql.ToString();
		}

		public void RenderOrderBy(IRenderer renderer, StringBuilder sql) => renderer.RenderOrderBy(this, sql);
	}
}
