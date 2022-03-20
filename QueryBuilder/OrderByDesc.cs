using YuraSoft.QueryBuilder.Interfaces;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class OrderByDesc : OrderBy
	{
		public OrderByDesc(IColumn column) : base(column, OrderDirection.Desc)
		{
		}

		public new readonly OrderDirection Direction; 
	}
}
