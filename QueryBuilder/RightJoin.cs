using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class RightJoin : IJoin
	{
		private ISource _source;
		private ICondition _condition;

		public RightJoin(ISource source, ICondition condition)
		{
			_source = source ?? throw new ArgumentShouldNotBeNullException(nameof(source));
			_condition = condition ?? throw new ArgumentShouldNotBeNullException(nameof(condition));
		}

		public ISource Source 
		{ 
			get => _source; 
			set => _source = value ?? throw new ArgumentShouldNotBeNullException(nameof(Source));
		}

		public ICondition Condition 
		{ 
			get => _condition; 
			set => _condition = value ?? throw new ArgumentShouldNotBeNullException(nameof(Condition));
		}

		public string RenderJoin(IRenderer renderer) => renderer.RenderJoin(this);
	}
}
