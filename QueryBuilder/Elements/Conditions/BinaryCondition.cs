using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder.Abstractions
{
	public abstract class BinaryCondition : ICondition
	{
		private IExpression _leftExpression;
		private IExpression _rightExpression;

		public BinaryCondition(IExpression leftExpression, IExpression rightExpression)
		{
			_leftExpression = leftExpression ?? throw new ArgumentShouldNotBeNullException(nameof(leftExpression));
			_rightExpression = rightExpression ?? throw new ArgumentShouldNotBeNullException(nameof(rightExpression));
		}

		public IExpression LeftExpression 
		{ 
			get => _leftExpression; 
			set => _leftExpression = value ?? throw new ArgumentShouldNotBeNullException(nameof(LeftExpression)); 
		}

		public IExpression RightExpression 
		{ 
			get => _rightExpression; 
			set => _rightExpression = value ?? throw new ArgumentShouldNotBeNullException(nameof(RightExpression)); 
		}

		public abstract string RenderCondition(IRenderer renderer);
	}
}
