using System;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

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
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException("{0} can't be null or empty", nameof(name)); 
			}

			_name = name;
			_alias = alias;
			_schema = schema;
		}

		public string Name
		{
			get => _name;
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException("{0} can't be null or empty", nameof(Name));
				}

				_name = value;
			}
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

		public string RenderSource(IRenderer renderer) => renderer.RenderSource(this);
		public string RenderIdentificator(IRenderer renderer) => renderer.RenderIdentificator(this);
	}
}
