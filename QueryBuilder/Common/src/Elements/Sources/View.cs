using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class View : Source
	{
		private string _name;
		private string? _alias;
		private string? _schema;

		public View(string name, string? alias = null, string? schema = null)
		{
			_name = Guard.ThrowIfNullOrEmpty(name, nameof(name));
			_alias = alias == string.Empty ? null : alias;
			_schema = schema == string.Empty ? null : schema;
		}

		public string Name
		{
			get => _name;
			set => _name = Guard.ThrowIfNullOrEmpty(value, nameof(Name));
		}

		public string? Alias
		{
			get => _alias;
			set => _alias = value == string.Empty ? null : value;
		}

		public string? Schema
		{
			get => _schema;
			set => _schema = value == string.Empty ? null : value;
		}
		
		public override void RenderIdentificator(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderIdentificator(this, sql);

        public override void RenderSource(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderSource(this, sql);
    }
}
