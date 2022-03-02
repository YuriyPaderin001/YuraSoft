using System;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class InnerJoin : IJoin
	{
		private ISource _source;
		private ICondition _condition;

		public InnerJoin(ISource source, ICondition condition)
		{
			_source = source ?? throw new ArgumentNullException(nameof(source), "{0} can't be null");
			_condition = condition ?? throw new ArgumentNullException(nameof(condition), "{0} can't be null");
		}

		public ISource Source 
		{ 
			get => _source; 
			set => _source = value ?? throw new ArgumentNullException(nameof(Source)); 
		}

		public ICondition Condition 
		{ 
			get => _condition; 
			set => _condition = value ?? throw new ArgumentNullException(nameof(Condition)); 
		}

		public string RenderJoin(IRenderer renderer) => renderer.RenderJoin(this);
	}
}
