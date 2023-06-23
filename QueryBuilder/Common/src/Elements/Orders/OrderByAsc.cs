namespace YuraSoft.QueryBuilder.Common
{
	public class OrderByAsc : OrderBy
	{
		public OrderByAsc(IColumn column) : base(column, OrderDirection.Asc)
		{
		}
	}
}
