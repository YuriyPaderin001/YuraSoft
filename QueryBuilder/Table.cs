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
		private string? _namespace;

		public Table(string name, string? alias = null, string? @namespace = null)
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

		public string RenderFrom(IRenderer renderer) => renderer.RenderFrom(this);
	}
}
