using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Common;

namespace YuraSoft.QueryBuilder.PostgreSql
{
	public class MaxWindowFunction : ExpressionWindowFunction
    {
		public MaxWindowFunction(IExpression expression, ICondition? filter, List<IColumn>? partitionBy, List<IOrderBy>? orderBy) 
			: base(expression, filter, partitionBy, orderBy)
		{
		}

		public override void RenderFunction(IRenderer renderer, StringBuilder sql) => renderer.RenderFunction(this, sql);
	}
}
