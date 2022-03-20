using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class Column : IColumn
	{
		private string _name;

		public Column(string name, string? alias = null)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentShouldNotBeNullOrEmptyException(nameof(name));
			}

			_name = name;

			Alias = alias;
			Source = null;
		}

		public Column(string name, string? alias, string table)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentShouldNotBeNullOrEmptyException(nameof(name));
			}

			if (string.IsNullOrEmpty(table))
			{
				throw new ArgumentShouldNotBeNullOrEmptyException(nameof(table));
			}

			_name = name;

			Alias = alias;
			Source = new Table(table);
		}

		public Column(string name, string? alias, ISource source)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentShouldNotBeNullOrEmptyException(nameof(name));
			}

			_name = name;

			Alias = alias;
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
