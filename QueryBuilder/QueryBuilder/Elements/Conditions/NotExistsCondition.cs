using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public class NotExistsCondition : UnaryCondition
	{
		private Select _select;

		public NotExistsCondition(IExpression expression, Select select) : base(expression)
		{
			_select = Validator.ThrowIfArgumentIsNull(select, nameof(select));
		}

		public Select Select
		{
			get => _select;
			set => _select = Validator.ThrowIfArgumentIsNull(value, nameof(Select));
		}

		public override void RenderCondition(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderCondition(this, stringBuilder);
	}
}
