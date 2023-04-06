using System;
using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class Delete : Query
	{
		private static readonly ExpressionFactory _factory = ExpressionFactory.Instance;

		private ISource _source;

		public Delete(string name) : this(name, alias: null, schema: null)
		{
		}

		public Delete(string name, string? schema) : this(name, alias: null, schema)
		{
		}

		public Delete(string name, string? alias, string? schema)
		{
			Guard.ThrowIfNullOrEmpty(name, nameof(name));

			_source = new Table(name, alias, schema);
		}

		public Delete(Table table)
		{
			_source = Guard.ThrowIfNull(table, nameof(table));
		}

		public ISource Source 
		{ 
			get => _source; 
			set => _source = Guard.ThrowIfNull(value, nameof(Source));
		}

		public ICondition? Condition { get; set; }

		public Delete Where(Action<ConditionBuilder> action) =>
			Where(_factory.Condition(action));

        public virtual Delete Where(ICondition? condition)
		{
			Condition = condition;

			return this;
		}

		public override void RenderQuery(IRenderer renderer, StringBuilder sql) =>
			renderer.RenderQuery(this, sql);
    }
}
