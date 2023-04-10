using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class CastFunction : ExpressionFunction
	{
		private string _type;

		public CastFunction(IExpression expression, string type) : base(expression) =>
			_type = Guard.ThrowIfNullOrEmpty(type, nameof(type));

		public string Type
		{
			get => _type;
			set => _type = Guard.ThrowIfNullOrEmpty(value, nameof(Type));
		}

		public override void RenderFunction(IRenderer renderer, StringBuilder sql) =>
			renderer.RenderFunction(this, sql);
	}
}
