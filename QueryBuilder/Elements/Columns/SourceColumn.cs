using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class SourceColumn : IColumn
	{
		private string _name;
		
		public SourceColumn(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentShouldNotBeNullOrEmptyException(nameof(name));
			}

			_name = name;
		}

		public SourceColumn(string name, string alias) : this(name)
		{
			if (string.IsNullOrEmpty(alias))
			{
				throw new ArgumentShouldNotBeNullOrEmptyException(nameof(alias));
			}

			Alias = alias;
		}

		public SourceColumn(string name, ISource source) : this(name)
		{
			Source = source ?? throw new ArgumentShouldNotBeNullException(nameof(source));
		}

		public SourceColumn(string name, string alias, ISource source) : this(name, alias)
		{
			Source = source ?? throw new ArgumentShouldNotBeNullException(nameof(source));
		}

		public string Name
		{
			get => _name;
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentShouldNotBeNullOrEmptyException(nameof(Name));
				}

				_name = value;
			}
		}

		public string? Alias { get; set; }
		public ISource? Source { get; set; }

		public string RenderColumn(IRenderer renderer) => renderer.RenderColumn(this);
		public string RenderIdentificator(IRenderer renderer) => renderer.RenderIdentificator(this);
		public string RenderExpression(IRenderer renderer) => renderer.RenderIdentificator(this);
	}
}
