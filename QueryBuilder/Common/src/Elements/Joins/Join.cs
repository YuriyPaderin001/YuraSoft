using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public abstract class Join : IJoin
	{
		private ISource _source;

		public Join(ISource source)
		{
			_source = Guard.ThrowIfNull(source, nameof(source));
		}

		public ISource Source
		{
			get => _source;
			set => _source = Guard.ThrowIfNull(value, nameof(Source));
		}

		public string RenderJoin(IRenderer renderer)
		{
			StringBuilder sql = new StringBuilder();
			RenderJoin(renderer, sql);

			return sql.ToString();
		}

		public abstract void RenderJoin(IRenderer renderer, StringBuilder sql);
	}
}
