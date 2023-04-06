using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class ExpressionColumn : Column
	{
		private IExpression _expression;
		private string? _name;

		public ExpressionColumn(IExpression expression, string? name = null)
		{
			_expression = Guard.ThrowIfNull(expression, nameof(expression));
			_name = name == string.Empty ? null : name;
		}

		public IExpression Expression 
		{ 
			get => _expression;
			set => _expression = Guard.ThrowIfNull(value, nameof(Expression));
		}

		public string? Name
		{
			get => _name;
			set => _name = value == string.Empty ? null : value;
		}

		public override void RenderIdentificator(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderIdentificator(this, sql);
		
		public override void RenderColumn(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderColumn(this, sql);
	}
}
