using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class Table : ISource
	{
		private string _name;
		private string? _alias;
		private string? _schema;

		public Table(string name, string? alias = null, string? schema = null)
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

		public string RenderSource(IRenderer renderer)
		{
			StringBuilder sql = new StringBuilder();
			RenderSource(renderer, sql);

			return sql.ToString();
		}

		public virtual void RenderSource(IRenderer renderer, StringBuilder sql) => renderer.RenderSource(this, sql);
		
		public string RenderIdentificator(IRenderer renderer)
		{
			StringBuilder sql = new StringBuilder();
			RenderIdentificator(renderer, sql);

			return sql.ToString();
		}
		
		public virtual void RenderIdentificator(IRenderer renderer, StringBuilder sql) => renderer.RenderIdentificator(this, sql);
	}
}
