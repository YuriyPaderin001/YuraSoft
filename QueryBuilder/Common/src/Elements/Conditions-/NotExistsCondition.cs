using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public class NotExistsCondition : ICondition
	{
		private Select _select;

		public NotExistsCondition(Select select)
		{
			_select = Validator.ThrowIfArgumentIsNull(select, nameof(select));
		}

		public Select Select
		{
			get => _select;
			set => _select = Validator.ThrowIfArgumentIsNull(value, nameof(Select));
		}

		#region Rendering methods

		public string RenderExpression(IRenderer renderer)
		{
			StringBuilder query = new StringBuilder();
			RenderExpression(renderer, query);

			return query.ToString();
		}

		public virtual void RenderExpression(IRenderer renderer, StringBuilder query) => 
			RenderCondition(renderer, query);

		public string RenderCondition(IRenderer renderer)
		{
			StringBuilder query = new StringBuilder();
			RenderCondition(renderer, query);

			return query.ToString();
		}

		public virtual void RenderCondition(IRenderer renderer, StringBuilder stringBuilder) => 
			renderer.RenderCondition(this, stringBuilder);

		#endregion Rendering methods
	}
}
