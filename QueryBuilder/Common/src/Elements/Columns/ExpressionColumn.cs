using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class ExpressionColumn : Column
	{
		public ExpressionColumn(IExpression expression, string? alias = null)
		{
			Expression = Guard.ThrowIfNull(expression, nameof(expression));
			Alias = alias == string.Empty ? null : alias;
		}

		public readonly IExpression Expression;
		public readonly string? Alias;

		public override void RenderIdentificator(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderIdentificator(this, sql);
		
		public override void RenderColumn(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderColumn(this, sql);
	}
}
