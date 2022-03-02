using System;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class Column : IColumn
	{
		private string _name;
		private string? _alias;
		private string? _namespace;

		public Column(string name, string? alias = null, string? @namespace = null)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException("{0} can't be null or empty", nameof(name)); 
			}

			_name = name;
			_alias = alias;
			_namespace = @namespace;
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
			set => _alias = value;
		}

		public string? Namespace
		{
			get => _namespace;
			set => _namespace = value;
		}

		public string RenderColumn(IRenderer renderer) => renderer.RenderColumn(this);
	}
}
