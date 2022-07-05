using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class BetweenCondition : UnaryCondition
	{
		private IExpression _lessExpression;
		private IExpression _hightExpression;

		public BetweenCondition(IExpression expression, IExpression lessExpression, IExpression hightExpression) : base(expression)
		{
			_lessExpression = lessExpression ?? throw new ArgumentShouldNotBeNullException(nameof(lessExpression));
			_hightExpression = hightExpression ?? throw new ArgumentShouldNotBeNullException(nameof(hightExpression));
		}

		public IExpression LessExpression
		{
			get => _lessExpression;
			set => _lessExpression = value ?? throw new ArgumentShouldNotBeNullException(nameof(LessExpression));
		}

		public IExpression HightExpression
		{
			get => _hightExpression;
			set => _hightExpression = value ?? throw new ArgumentShouldNotBeNullException(nameof(HightExpression));
		}

		public override string RenderCondition(IRenderer renderer) => renderer.RenderCondition(this);
	}
}
