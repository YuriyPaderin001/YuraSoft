﻿using YuraSoft.QueryBuilder.Interfaces;

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
