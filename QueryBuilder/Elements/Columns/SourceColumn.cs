using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class SourceColumn : IColumn
	{
		private string _name;
		
		public SourceColumn(string name)
		{
			_name = Validator.ThrowIfArgumentIsNullOrEmpty(name, nameof(name));
		}

		public SourceColumn(string name, string alias) : this(name)
		{
			Alias = Validator.ThrowIfArgumentIsNullOrEmpty(alias, nameof(alias));
		}

		public SourceColumn(string name, ISource source) : this(name)
		{
			Source = Validator.ThrowIfArgumentIsNull(source, nameof(source));
		}

		public SourceColumn(string name, string alias, ISource source) : this(name, alias)
		{
			Source = Validator.ThrowIfArgumentIsNull(source, nameof(source));
		}

		public string Name
		{
			get => _name;
			set => _name = Validator.ThrowIfArgumentIsNullOrEmpty(value, nameof(Name));
		}

		public string? Alias { get; set; }
		public ISource? Source { get; set; }

		public string RenderExpression(IRenderer renderer) => RenderIdentificator(renderer);

		public void RenderExpression(IRenderer renderer, StringBuilder stringBuilder) => RenderIdentificator(renderer, stringBuilder);

		public string RenderIdentificator(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderIdentificator(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public void RenderIdentificator(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderIdentificator(this, stringBuilder);

		public string RenderColumn(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderColumn(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public void RenderColumn(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderColumn(this, stringBuilder);
	}
}
