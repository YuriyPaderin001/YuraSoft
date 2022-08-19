using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class BetweenCondition : UnaryCondition
	{
		private IExpression _lessExpression;
		private IExpression _hightExpression;

		public BetweenCondition(IExpression expression, IExpression lessExpression, IExpression hightExpression) : base(expression)
		{
			_lessExpression = Validator.ThrowIfArgumentIsNull(lessExpression, nameof(lessExpression));
			_hightExpression = Validator.ThrowIfArgumentIsNull(hightExpression, nameof(hightExpression));
		}

		public IExpression LessExpression
		{
			get => _lessExpression;
			set => _lessExpression = Validator.ThrowIfArgumentIsNull(value, nameof(LessExpression));
		}

		public IExpression HightExpression
		{
			get => _hightExpression;
			set => _hightExpression = Validator.ThrowIfArgumentIsNull(value, nameof(HightExpression));
		}

		public override void RenderCondition(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderCondition(this, stringBuilder);
	}
}
