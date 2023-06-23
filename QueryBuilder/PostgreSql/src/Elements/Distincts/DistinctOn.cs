using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Common;
using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.PostgreSql
{
    public class DistinctOn : IDistinct
    {
        public DistinctOn(IEnumerable<IColumn> columns)
        {
            Columns = new List<IColumn>(Guard.ThrowIfNullOrEmptyOrContainsNullElements(columns, nameof(columns)));
        }

        public readonly List<IColumn> Columns;

        public string RenderDistinct(IRenderer renderer)
        {
            StringBuilder sql = new StringBuilder();
            RenderDistinct(renderer, sql);

            return sql.ToString();
        }

        public virtual void RenderDistinct(IRenderer renderer, StringBuilder sql) =>
            renderer.RenderDistinct(this, sql);
    }
}
