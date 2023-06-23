using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class SourceColumn : Column
	{
		public SourceColumn(string name)
		{
			Name = Guard.ThrowIfNullOrEmpty(name, nameof(name));
		}

		public SourceColumn(string name, ISource? source)
		{
			Name = Guard.ThrowIfNullOrEmpty(name, nameof(name));
			Source = source;
		}

		public SourceColumn(string name, string? alias, ISource? source = null)
		{
			Name = Guard.ThrowIfNullOrEmpty(name, nameof(name));
			Alias = alias == string.Empty ? null : alias;
			Source = source;
		}

		public readonly string Name;
		public readonly string? Alias;
		public readonly ISource? Source;

		public override void RenderIdentificator(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderIdentificator(this, sql);

		public override void RenderColumn(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderColumn(this, sql);
	}
}
