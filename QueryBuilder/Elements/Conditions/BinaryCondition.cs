using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder.Abstractions
{
	public abstract class BinaryCondition : ICondition
	{
		private IExpression _leftExpression;
		private IExpression _rightExpression;

		public BinaryCondition(IExpression leftExpression, IExpression rightExpression)
		{
			_leftExpression = Validator.ThrowIfArgumentIsNull(leftExpression, nameof(leftExpression));
			_rightExpression = Validator.ThrowIfArgumentIsNull(rightExpression, nameof(rightExpression));
		}

		public IExpression LeftExpression 
		{ 
			get => _leftExpression; 
			set => _leftExpression = Validator.ThrowIfArgumentIsNull(value, nameof(LeftExpression));
		}

		public IExpression RightExpression 
		{ 
			get => _rightExpression; 
			set => _rightExpression = Validator.ThrowIfArgumentIsNull(value, nameof(RightExpression));
		}

		#region Rendering methods

		public string RenderExpression(IRenderer renderer)
		{
			StringBuilder query = new StringBuilder();
			RenderExpression(renderer, query);

			return query.ToString();
		}

		public virtual void RenderExpression(IRenderer renderer, StringBuilder query) => RenderCondition(renderer, query);

    public string RenderCondition(IRenderer renderer)
		{
			StringBuilder query = new StringBuilder();
			RenderCondition(renderer, query);

			return query.ToString();
		}

		public abstract void RenderCondition(IRenderer renderer, StringBuilder query);

    #endregion Rendering methods
  }
}
