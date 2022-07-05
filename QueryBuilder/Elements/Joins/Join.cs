using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public abstract class Join : IJoin
	{
		private ISource _source;

		public Join(ISource source)
		{
			_source = source ?? throw new ArgumentShouldNotBeNullException(nameof(source));
		}

		public ISource Source
		{
			get => _source;
			set => _source = value ?? throw new ArgumentShouldNotBeNullException(nameof(Source));
		}

		public abstract string RenderJoin(IRenderer renderer);
	}
}
