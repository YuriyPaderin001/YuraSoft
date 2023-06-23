using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Common;

namespace YuraSoft.QueryBuilder.PostgreSql
{
	public class CountWindowFunction : ExpressionWindowFunction
	{
		public CountWindowFunction(IExpression expression, ICondition? filter, IEnumerable<IColumn>? partitionBy, IEnumerable<IOrderBy>? orderBy) 
			: base(expression, filter, partitionBy, orderBy)
		{
		}

		public override void RenderFunction(IRenderer renderer, StringBuilder sql) => renderer.RenderFunction(this, sql);
	}
}
