using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;
using YuraSoft.QueryBuilder.Validation;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class Table : ISource
	{
		private string _name;
		private string? _alias;
		private string? _schema;

		public Table(string name, string? alias = null, string? schema = null)
		{
			_name = Validator.ThrowIfArgumentIsNullOrEmpty(name, nameof(name));
			_alias = alias == string.Empty ? null : alias;
			_schema = schema == string.Empty ? null : schema;
		}

		public string Name
		{
			get => _name;
			set => _name = Validator.ThrowIfArgumentIsNullOrEmpty(value, nameof(Name));
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
			StringBuilder stringBuilder = new StringBuilder();
			RenderSource(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public virtual void RenderSource(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderSource(this, stringBuilder);
		
		public string RenderIdentificator(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderIdentificator(renderer, stringBuilder);

			return stringBuilder.ToString();
		}
		
		public virtual void RenderIdentificator(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderIdentificator(this, stringBuilder);
	}
}
