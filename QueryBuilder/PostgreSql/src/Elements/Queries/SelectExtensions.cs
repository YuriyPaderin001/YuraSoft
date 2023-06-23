using System;
using System.Collections.Generic;

using YuraSoft.QueryBuilder.Common;

namespace YuraSoft.QueryBuilder.PostgreSql
{
    public static class SelectExtensions
    {
        private static readonly ExpressionFactory _factory = ExpressionFactory.Instance;

        public static Select DistinctOn(this Select query, string columnName, ISource columnSource) =>
            DistinctOn(query, new[] { _factory.Column(columnName, columnSource) });

        public static Select DistinctOn(this Select query, string columnName, string? columnAlias, ISource? columnSource) =>
            DistinctOn(query, new[] { _factory.Column(columnName, columnAlias, columnSource) });

        public static Select DistinctOn(this Select query, params string[] columnNames) =>
            DistinctOn(query, _factory.Columns(columnNames));

        public static Select DistinctOn(this Select query, IEnumerable<string> columnNames) =>
            DistinctOn(query, _factory.Columns(columnNames));

        public static Select DistinctOn(this Select query, Action<ColumnBuilder> columnAction) =>
            DistinctOn(query, _factory.Columns(columnAction));

        public static Select DistinctOn(this Select query, params IColumn[] columns) =>
            DistinctOn(query, (IEnumerable<IColumn>)columns);

        public static Select DistinctOn(this Select query, IEnumerable<IColumn> columns) =>
            query.Distinct(new DistinctOn(columns));
    }
}
