using System;
using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class Delete : Query
	{
		private static readonly ExpressionFactory _factory = ExpressionFactory.Instance;

		public Delete(string name) : this(name, alias: null, schema: null)
		{
		}

		public Delete(string name, string? schema) : this(name, alias: null, schema)
		{
		}

		public Delete(string name, string? alias, string? schema)
		{
			Guard.ThrowIfNullOrEmpty(name, nameof(name));

			Source = new Table(name, alias, schema);
		}

		public Delete(Table table)
		{
			Source = Guard.ThrowIfNull(table, nameof(table));
		}

		public readonly ISource Source;
		public ICondition? Condition { get; protected set; }

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
