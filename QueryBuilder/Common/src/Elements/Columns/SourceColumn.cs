using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class SourceColumn : IColumn
	{
		private string _name;
		private string? _alias;
		
		public SourceColumn(string name)
		{
			_name = Guard.ThrowIfNullOrEmpty(name, nameof(name));
		}

		public SourceColumn(string name, ISource? source)
		{
			_name = Guard.ThrowIfNullOrEmpty(name, nameof(name));
			Source = source;
		}

		public SourceColumn(string name, string? alias, ISource? source = null)
		{
			_name = Guard.ThrowIfNullOrEmpty(name, nameof(name));
			Alias = alias == string.Empty ? null : alias;
			Source = source;
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

		public ISource? Source { get; set; }

		public string RenderExpression(IRenderer renderer)
		{
			StringBuilder sql = new StringBuilder();
			RenderExpression(renderer, sql);

			return sql.ToString();
		}

		public void RenderExpression(IRenderer renderer, StringBuilder sql) => RenderIdentificator(renderer, sql);

		public string RenderIdentificator(IRenderer renderer)
		{
			StringBuilder sql = new StringBuilder();
			RenderIdentificator(renderer, sql);

			return sql.ToString();
		}

		public void RenderIdentificator(IRenderer renderer, StringBuilder sql) => renderer.RenderIdentificator(this, sql);

		public string RenderColumn(IRenderer renderer)
		{
			StringBuilder sql = new StringBuilder();
			RenderColumn(renderer, sql);

			return sql.ToString();
		}

		public void RenderColumn(IRenderer renderer, StringBuilder sql) => renderer.RenderColumn(this, sql);
	}
}
