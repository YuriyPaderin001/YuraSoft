using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class CrossJoin : IJoin
	{
		private ISource _source;

		public CrossJoin(ISource source)
		{
			_source = source ?? throw new ArgumentShouldNotBeNullException(nameof(source));
		}

		public ISource Source 
		{ 
			get => _source; 
			set => _source = value ?? throw new ArgumentShouldNotBeNullException(nameof(Source));
		}

		public string RenderJoin(IRenderer renderer) => renderer.RenderJoin(this);
	}
}
