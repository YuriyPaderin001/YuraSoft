using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class Subquery : Source
	{
		private Select _select;
		private string _name;

		public Subquery(Select select, string name)
		{
			_select = Guard.ThrowIfNull(select, nameof(select));
			_name = Guard.ThrowIfNullOrEmpty(name, nameof(name));
		}

		public Select Select
		{
			get => _select;
			set => _select = Guard.ThrowIfNull(value, nameof(Select));
		}

		public string Name
		{
			get => _name;
			set => _name = Guard.ThrowIfNullOrEmpty(value, nameof(Name));
		}

		public override void RenderIdentificator(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderIdentificator(this, sql);

		public override void RenderSource(IRenderer renderer, StringBuilder sql) =>
			renderer.RenderSource(this, sql);
    }
}
