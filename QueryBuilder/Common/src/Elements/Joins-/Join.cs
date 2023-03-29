using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public abstract class Join : IJoin
	{
		private ISource _source;

		public Join(ISource source)
		{
			_source = Validator.ThrowIfArgumentIsNull(source, nameof(source));
		}

		public ISource Source
		{
			get => _source;
			set => _source = Validator.ThrowIfArgumentIsNull(value, nameof(Source));
		}

		public string RenderJoin(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderJoin(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public abstract void RenderJoin(IRenderer renderer, StringBuilder stringBuilder);
	}
}
