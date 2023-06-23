using System.Collections.Generic;

using YuraSoft.QueryBuilder.Common;
using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.PostgreSql
{
    public abstract class ExpressionWindowFunction : WindowFunction
    {
        public ExpressionWindowFunction(IExpression expression, ICondition? filter, IEnumerable<IColumn>? partitionBy, IEnumerable<IOrderBy>? orderBy)
            : base(filter, partitionBy, orderBy)
        {
            Expression = Guard.ThrowIfNull(expression, nameof(expression));
        }

        public readonly IExpression Expression;
    }
}
