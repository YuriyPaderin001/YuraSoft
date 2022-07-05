using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public abstract class UnaryCondition : ICondition
	{
		private IExpression _expression;

		public UnaryCondition(IExpression expression)
		{
			_expression = expression ?? throw new ArgumentShouldNotBeNullException(nameof(expression));
		}

		public IExpression Expression 
		{ 
			get => _expression; 
			set => _expression = value ?? throw new ArgumentShouldNotBeNullException(nameof(Expression)); 
		}

		public abstract string RenderCondition(IRenderer renderer);
	}
}
