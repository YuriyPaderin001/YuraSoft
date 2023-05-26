using System.Collections.Generic;

using YuraSoft.QueryBuilder.Common;
using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.PostgreSql
{
    public abstract class WindowFunction : Function
    {
        public WindowFunction(ICondition? filter = null, IEnumerable<IColumn>? partitionBy = null, IEnumerable<IOrderBy>? orderBy = null)
        {
            Filter = filter;
            PartitionBy = partitionBy == null
                ? new List<IColumn>()
                : new List<IColumn>(Guard.ThrowIfContainsNullElements(partitionBy, nameof(partitionBy)));
            OrderBy = orderBy == null
                ? new List<IOrderBy>()
                : new List<IOrderBy>(Guard.ThrowIfContainsNullElements(orderBy, nameof(orderBy)));
        }

        public readonly ICondition? Filter;
        public readonly List<IColumn> PartitionBy;
        public readonly List<IOrderBy> OrderBy;
    }
}
