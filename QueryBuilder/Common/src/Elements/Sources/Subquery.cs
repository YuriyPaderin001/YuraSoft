using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class Subquery : Source
	{
		public Subquery(Select select, string name)
		{
			Select = Guard.ThrowIfNull(select, nameof(select));
			Alias = Guard.ThrowIfNullOrEmpty(name, nameof(name));
		}

		public readonly Select Select;
		public readonly string Alias;

		public override void RenderIdentificator(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderIdentificator(this, sql);

		public override void RenderSource(IRenderer renderer, StringBuilder sql) =>
			renderer.RenderSource(this, sql);
    }
}
