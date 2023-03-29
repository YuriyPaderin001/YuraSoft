using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public class ExpressionColumn : IColumn
	{
		private IExpression _expression;
		private string? _name;

		public ExpressionColumn(IExpression expression, string? name = null)
		{
			_expression = Validator.ThrowIfArgumentIsNull(expression, nameof(expression));
			_name = name == string.Empty ? null : name;
		}

		public IExpression Expression
		{
			get => _expression;
			set => _expression = Validator.ThrowIfArgumentIsNull(value, nameof(Expression));
		}

		public string? Name
		{
			get => _name;
			set => _name = value == string.Empty ? null : value;
		}

		public string RenderExpression(IRenderer renderer) => RenderIdentificator(renderer);

		public void RenderExpression(IRenderer renderer, StringBuilder stringBuilder) => RenderIdentificator(renderer, stringBuilder);

		public string RenderIdentificator(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderIdentificator(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public void RenderIdentificator(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderIdentificator(this, stringBuilder);

		public string RenderColumn(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderColumn(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public void RenderColumn(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderColumn(this, stringBuilder);
	}
}
