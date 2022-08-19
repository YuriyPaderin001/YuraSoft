using YuraSoft.QueryBuilder.Interfaces;

namespace YuraSoft.QueryBuilder
{
	public class OrderByAsc : OrderBy
	{
		public OrderByAsc(IColumn column) : base(column, OrderDirection.Asc)
		{
		}

		public new readonly OrderDirection Direction = OrderDirection.Asc; 
	}
}
