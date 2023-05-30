using System;
using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class Delete : Query
	{
		private static readonly ExpressionFactory _factory = ExpressionFactory.Instance;

		public Delete(string tableName) : this(tableName, tableAlias: null, tableSchema: null)
		{
		}

		public Delete(string tableName, string? tableSchema) : this(tableName, tableAlias: null, tableSchema)
		{
		}

		public Delete(string tableName, string? tableAlias, string? tableSchema)
		{
			Guard.ThrowIfNullOrEmpty(tableName, nameof(tableName));

			Source = new Table(tableName, tableAlias, tableSchema);
		}

		public Delete(Table table)
		{
			Source = Guard.ThrowIfNull(table, nameof(table));
		}

		public readonly ISource Source;
		public ICondition? Condition { get; protected set; }

		public Delete Where(Action<ConditionBuilder> conditionAction) =>
			Where(_factory.Condition(conditionAction));

        public virtual Delete Where(ICondition? condition)
		{
			Condition = condition;

			return this;
		}

		public override void RenderQuery(IRenderer renderer, StringBuilder sql) =>
			renderer.RenderQuery(this, sql);
    }
}
