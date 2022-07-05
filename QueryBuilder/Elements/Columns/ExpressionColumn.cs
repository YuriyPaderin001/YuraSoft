using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class ExpressionColumn : IColumn
	{
		private IExpression _expression;
		private string? _name;

		public ExpressionColumn(IExpression expression, string? name = null)
		{
			_expression = expression ?? throw new ArgumentShouldNotBeNullException(nameof(expression));
			_name = name == string.Empty ? null : name;
		}

		public IExpression Expression 
		{ 
			get => _expression;
			set => _expression = value ?? throw new ArgumentShouldNotBeNullException(nameof(Expression));
		}

		public string? Name
		{
			get => _name;
			set => _name = value == string.Empty ? null : value;
		}

		public string RenderExpression(IRenderer renderer) => RenderIdentificator(renderer);
		public string RenderIdentificator(IRenderer renderer) => renderer.RenderIdentificator(this);
		public string RenderColumn(IRenderer renderer) => renderer.RenderColumn(this);
	}
}
