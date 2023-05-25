using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class ExpressionColumn : Column
	{
		private IExpression _expression;
		private string? _alias;

		public ExpressionColumn(IExpression expression, string? alias = null)
		{
			_expression = Guard.ThrowIfNull(expression, nameof(expression));
			_alias = alias == string.Empty ? null : alias;
		}

		public IExpression Expression 
		{ 
			get => _expression;
			set => _expression = Guard.ThrowIfNull(value, nameof(Expression));
		}

		public string? Alias
		{
			get => _alias;
			set => _alias = value == string.Empty ? null : value;
		}

		public override void RenderIdentificator(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderIdentificator(this, sql);
		
		public override void RenderColumn(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderColumn(this, sql);
	}
}
