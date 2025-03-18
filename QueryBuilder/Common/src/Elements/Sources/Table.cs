using System;
using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class Table : Source, IEquatable<Table>
	{
		public Table(string name, string? alias = null, string? schema = null)
		{
			Name = Guard.ThrowIfNullOrEmpty(name, nameof(name));
			Alias = alias == string.Empty ? null : alias;
			Schema = schema == string.Empty ? null : schema;
		}

		public readonly string Name;
		public readonly string? Alias;
		public readonly string? Schema;

		public override void RenderIdentificator(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderIdentificator(this, sql);

        public override void RenderSource(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderSource(this, sql);

		public override bool Equals(object? obj) =>
			Equals(obj as Table);

		public bool Equals(Table? table) =>
			table != null &&
			Name == table.Name &&
			Alias == table.Alias &&
			Schema == table.Schema;

		public override int GetHashCode() =>
			HashCode.Combine(Name, Alias, Schema);
	}
}
