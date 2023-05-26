using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public abstract class Join : IJoin
	{
		public Join(ISource source) =>
			Source = Guard.ThrowIfNull(source, nameof(source));

		public readonly ISource Source;

		public string RenderJoin(IRenderer renderer)
		{
			StringBuilder sql = new StringBuilder();
			RenderJoin(renderer, sql);

			return sql.ToString();
		}

		public abstract void RenderJoin(IRenderer renderer, StringBuilder sql);
	}
}
