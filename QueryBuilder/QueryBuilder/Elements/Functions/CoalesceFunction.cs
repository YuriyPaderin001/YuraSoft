using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public class CoalesceFunction : ExpressionFunction
	{
		private IExpression _defaultValue;

		public CoalesceFunction(IExpression expression, IExpression defaultValue) : base(expression)
		{
			_defaultValue = Validator.ThrowIfArgumentIsNull(defaultValue, nameof(defaultValue));
		}

		public IExpression DefaultValue
		{
			get => _defaultValue;
			set => _defaultValue = Validator.ThrowIfArgumentIsNull(value, nameof(DefaultValue));
		}

		public override void RenderFunction(IRenderer renderer, StringBuilder query) => renderer.RenderFunction(this, query);
	}
}
