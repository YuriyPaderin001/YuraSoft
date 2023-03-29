using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public class CastFunction : ExpressionFunction
	{
		private string _type;

		public CastFunction(IExpression expression, string type) : base(expression) =>
			_type = Validator.ThrowIfArgumentIsNullOrEmpty(type, nameof(type));

		public string Type
		{
			get => _type;
			set => _type = Validator.ThrowIfArgumentIsNullOrEmpty(value, nameof(Type));
		}

		public override void RenderFunction(IRenderer renderer, StringBuilder query) =>
			renderer.RenderFunction(this, query);
	}
}
