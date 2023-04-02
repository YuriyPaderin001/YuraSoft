using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class CoalesceFunction : ExpressionFunction
	{
		private IExpression _defaultExpression;

		public CoalesceFunction(IExpression expression, IExpression defaultExpression) : base(expression)
		{
			_defaultExpression = Guard.ThrowIfNull(defaultExpression, nameof(defaultExpression));
		}

		public IExpression DefaultExpression 
		{ 
			get => _defaultExpression;
			set => _defaultExpression = Guard.ThrowIfNull(value, nameof(DefaultExpression));
		}

		public override void RenderFunction(IRenderer renderer, StringBuilder sql) => renderer.RenderFunction(this, sql);
	}
}
