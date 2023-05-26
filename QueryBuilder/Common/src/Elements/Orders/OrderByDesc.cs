﻿namespace YuraSoft.QueryBuilder.Common
{
	public class OrderByDesc : OrderBy
	{
		public OrderByDesc(IColumn column) : base(column, OrderDirection.Desc)
		{
		}
	}
}
