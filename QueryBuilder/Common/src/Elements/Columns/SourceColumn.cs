using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class SourceColumn : Column
	{
		public SourceColumn(string name) : this(name, source: null, alias: null)
		{
		}

		public SourceColumn(string name, string? alias) : this(name, source: null, alias)
		{
		}

		public SourceColumn(string name, ISource? source, string? alias = null)
		{
			Name = Guard.ThrowIfNullOrEmpty(name, nameof(name));
            Source = source;
            Alias = alias == string.Empty ? null : alias;
        }

		public readonly string Name;
        public readonly ISource? Source;
        public readonly string? Alias;

		public override void RenderIdentificator(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderIdentificator(this, sql);

		public override void RenderColumn(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderColumn(this, sql);
	}
}
