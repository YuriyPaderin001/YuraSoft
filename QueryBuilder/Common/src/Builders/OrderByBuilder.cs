using System;
using System.Collections.Generic;
using System.Linq;

namespace YuraSoft.QueryBuilder.Common
{
    public class OrderByBuilder
    {
        public static readonly ExpressionFactory Factory = ExpressionFactory.Instance;

        public readonly List<IOrderBy> OrderBies = new List<IOrderBy>();

        public OrderByBuilder Asc(string column) => OrderBy(column, OrderDirection.Asc);
        public OrderByBuilder Asc(string column, string columnSource) => OrderBy(column, columnSource, OrderDirection.Asc);
        public OrderByBuilder Asc(string column, ISource columnSource) => OrderBy(column, columnSource, OrderDirection.Asc);
        public OrderByBuilder Asc(IColumn column) => OrderBy(column, OrderDirection.Asc);

        public OrderByBuilder Desc(string column) => OrderBy(column, OrderDirection.Desc);
        public OrderByBuilder Desc(string column, string columnSource) => OrderBy(column, columnSource, OrderDirection.Desc);
        public OrderByBuilder Desc(string column, ISource columnSource) => OrderBy(column, columnSource, OrderDirection.Desc);
        public OrderByBuilder Desc(IColumn column) => OrderBy(column, OrderDirection.Desc);

        public OrderByBuilder OrderBy(string column, OrderDirection direction) => OrderBy(Factory.Column(column), direction);
        public OrderByBuilder OrderBy(string column, string columnSource, OrderDirection direction) => OrderBy(Factory.Column(column, alias: null, columnSource), direction);
        public OrderByBuilder OrderBy(string column, ISource columnSource, OrderDirection direction) => OrderBy(Factory.Column(column, columnSource), direction);
        public OrderByBuilder OrderBy(IColumn column, OrderDirection direction) => OrderBy(new OrderBy(column, direction));

        public OrderByBuilder OrderBy(IOrderBy orderBy)
        {
            OrderBies.Add(orderBy);

            return this;
        }

        public OrderByBuilder Asc(params string[] columns) => OrderBy(columns, OrderDirection.Asc);
        public OrderByBuilder Asc(IEnumerable<string> columns) => OrderBy(columns, OrderDirection.Asc);
        public OrderByBuilder Asc(Action<ColumnBuilder> columnAction) => OrderBy(columnAction, OrderDirection.Asc);
        public OrderByBuilder Asc(params IColumn[] columns) => OrderBy(columns, OrderDirection.Asc);
        public OrderByBuilder Asc(IEnumerable<IColumn> columns) => OrderBy(columns, OrderDirection.Asc);

        public OrderByBuilder Desc(params string[] columns) => OrderBy(columns, OrderDirection.Desc);
        public OrderByBuilder Desc(IEnumerable<string> columns) => OrderBy(columns, OrderDirection.Desc);
        public OrderByBuilder Desc(Action<ColumnBuilder> columnAction) => OrderBy(columnAction, OrderDirection.Desc);
        public OrderByBuilder Desc(params IColumn[] columns) => OrderBy(columns, OrderDirection.Desc);
        public OrderByBuilder Desc(IEnumerable<IColumn> columns) => OrderBy(columns, OrderDirection.Desc);

        public OrderByBuilder OrderBy(IEnumerable<string> columns, OrderDirection direction) =>
            OrderBy(columns.Select(col => Factory.Column(col)), direction);

        public OrderByBuilder OrderBy(Action<ColumnBuilder> columnAction, OrderDirection direction) =>
            OrderBy(Factory.Columns(columnAction), direction);

        public OrderByBuilder OrderBy(IEnumerable<IColumn> columns, OrderDirection direction) => 
            OrderBy(columns.Select(col => new OrderBy(col, direction)));

        public OrderByBuilder OrderBy(params IOrderBy[] orderBies) => OrderBy(orderBies);

        public OrderByBuilder OrderBy(IEnumerable<IOrderBy> orderBies)
        {
            OrderBies.AddRange(orderBies);

            return this;
        }

        public List<IOrderBy> Build() => OrderBies;
    }
}
