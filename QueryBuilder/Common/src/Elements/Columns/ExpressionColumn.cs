using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class ExpressionColumn : IColumn
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

		public string RenderExpression(IRenderer renderer)
		{
			StringBuilder sql = new StringBuilder();
			RenderExpression(renderer, sql);

			return sql.ToString();
		}

		public void RenderExpression(IRenderer renderer, StringBuilder sql) => RenderIdentificator(renderer, sql);

		public string RenderIdentificator(IRenderer renderer)
		{
			StringBuilder sql = new StringBuilder();
			RenderIdentificator(renderer, sql);

			return sql.ToString();
		}

		public void RenderIdentificator(IRenderer renderer, StringBuilder sql) => renderer.RenderIdentificator(this, sql);
		
		public string RenderColumn(IRenderer renderer)
		{
			StringBuilder sql = new StringBuilder();
			RenderColumn(renderer, sql);

			return sql.ToString();
		}
		
		public void RenderColumn(IRenderer renderer, StringBuilder sql) => renderer.RenderColumn(this, sql);
	}
}
