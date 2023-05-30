using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class Select : Query, IExpression
	{
		private static readonly ExpressionFactory _factory = ExpressionFactory.Instance;

		public Select(string columnName, ISource? columnSource) : this(columnName, columnAlias: null, columnSource)
		{
		}

		public Select(string columnName, string? columnAlias, ISource? columnSource)
		{
			Guard.ThrowIfNullOrEmpty(columnName, nameof(columnName));

            ColumnCollection.Add(new SourceColumn(columnName, columnAlias, columnSource));
		}

        public Select(Action<ColumnBuilder> columnAction) : this(_factory.Columns(columnAction))
        {
        }

        public Select(params string[] columns) : this((IEnumerable<string>)columns)
		{
		}

		public Select(IEnumerable<string> columns) : this(_factory.Columns(columns))
		{
		}

		public Select(params IColumn[] columns) : this((IEnumerable<IColumn>)columns)
		{
		}

		public Select(IEnumerable<IColumn> columns)
		{
			Guard.ThrowIfNullOrContainsNullElements(columns, nameof(columns));

            ColumnCollection.AddRange(columns);
		}

		public IDistinct? DistinctValue { get; protected set; }
		public readonly List<IColumn> ColumnCollection = new List<IColumn>();
		public readonly List<ISource> SourceCollection = new List<ISource>();
		public ICondition? WhereCondition { get; protected set; }
		public readonly List<IJoin> JoinCollection = new List<IJoin>();
		public ICondition? HavingCondition { get; protected set; }
		public readonly List<IOrderBy> OrderByCollection = new List<IOrderBy>();
		public readonly List<IColumn> GroupByCollection = new List<IColumn>();
		public int? OffsetValue { get; protected set; }
		public int? LimitValue { get; protected set; }

		public virtual Select Distinct() => Distinct(new Distinct());

		public virtual Select Distinct(IDistinct? distinct)
		{
			DistinctValue = distinct;

			return this;
		}

		public Select From(string table) => From(new Table(name: table));
		public Select From(string table, string? schema) => From(new Table(name: table, schema: schema));
		public Select From(Select select, string alias) => From(new Subquery(select, alias));

        public virtual Select From(ISource source)
		{
			Guard.ThrowIfNull(source, nameof(source));

			SourceCollection.Add(source);

			return this;
		}

        public virtual Select From(params string[] tables) => 
			From((IEnumerable<string>)tables);

		public virtual Select From(IEnumerable<string> tables)
		{
			Guard.ThrowIfNullOrContainsNullOrEmptyElements(tables, nameof(tables));

			return From(tables.Select(t => new Table(t)));
		}

		public virtual Select From(params ISource[] sources) => 
			From((IEnumerable<ISource>)sources);

		public virtual Select From(IEnumerable<ISource> sources)
		{
			Guard.ThrowIfNullOrContainsNullElements(sources, nameof(sources));

			SourceCollection.AddRange(sources);

			return this;
		}

		public virtual Select Where(Action<ConditionBuilder> conditionAction) => 
			Where(_factory.Condition(conditionAction));
		
		public virtual Select Where(ICondition? condition)
		{
			WhereCondition = condition;

			return this;
		}

        public Select LeftJoin(string leftTable, string rightTable, Action<ConditionBuilder, ISource, ISource> joinAction) => LeftJoin(new Table(leftTable), new Table(rightTable), joinAction);
		public Select LeftJoin(string table, Action<ConditionBuilder> joinAction) => LeftJoin(table, _factory.Condition(joinAction));
        public Select LeftJoin(string table, ICondition condition) => LeftJoin(new Table(table), condition);

        public Select LeftJoin(ISource leftSource, ISource rightSource, Action<ConditionBuilder, ISource, ISource> joinAction) => LeftJoin(rightSource, _factory.Condition(leftSource, rightSource, joinAction));
        public Select LeftJoin(ISource source, Action<ConditionBuilder> joinAction) => LeftJoin(source, _factory.Condition(joinAction));
        public virtual Select LeftJoin(ISource source, ICondition condition) => AddJoin(new LeftJoin(source, condition));

        public Select RightJoin(string leftTable, string rightTable, Action<ConditionBuilder, ISource, ISource> joinAction) => RightJoin(new Table(leftTable), new Table(rightTable), joinAction);
        public Select RightJoin(string table, Action<ConditionBuilder> joinAction) => RightJoin(table, _factory.Condition(joinAction));
        public Select RightJoin(string table, ICondition condition) => RightJoin(new Table(table), condition);

        public Select RightJoin(ISource leftSource, ISource rightSource, Action<ConditionBuilder, ISource, ISource> joinAction) => RightJoin(rightSource, _factory.Condition(leftSource, rightSource, joinAction));
        public Select RightJoin(ISource source, Action<ConditionBuilder> joinAction) => RightJoin(source, _factory.Condition(joinAction));
        public virtual Select RightJoin(ISource source, ICondition condition) => AddJoin(new RightJoin(source, condition));

        public Select InnerJoin(string leftTable, string rightTable, Action<ConditionBuilder, ISource, ISource> joinAction) => InnerJoin(new Table(leftTable), new Table(rightTable), joinAction);
        public Select InnerJoin(string table, Action<ConditionBuilder> joinAction) => InnerJoin(table, _factory.Condition(joinAction));
        public Select InnerJoin(string table, ICondition condition) => InnerJoin(new Table(table), condition);

        public Select InnerJoin(ISource leftSource, ISource rightSource, Action<ConditionBuilder, ISource, ISource> joinAction) => InnerJoin(rightSource, _factory.Condition(leftSource, rightSource, joinAction));
        public Select InnerJoin(ISource source, Action<ConditionBuilder> joinAction) => InnerJoin(source, _factory.Condition(joinAction));
        public virtual Select InnerJoin(ISource source, ICondition condition) => AddJoin(new InnerJoin(source, condition));

        public Select FullJoin(string leftTable, string rightTable, Action<ConditionBuilder, ISource, ISource> joinAction) => FullJoin(new Table(leftTable), new Table(rightTable), joinAction);
        public Select FullJoin(string table, Action<ConditionBuilder> joinAction) => FullJoin(table, _factory.Condition(joinAction));
        public Select FullJoin(string table, ICondition condition) => FullJoin(new Table(table), condition);

        public Select FullJoin(ISource leftSource, ISource rightSource, Action<ConditionBuilder, ISource, ISource> joinAction) => FullJoin(rightSource, _factory.Condition(leftSource, rightSource, joinAction));
        public Select FullJoin(ISource source, Action<ConditionBuilder> joinAction) => FullJoin(source, _factory.Condition(joinAction));
        public virtual Select FullJoin(ISource source, ICondition condition) => AddJoin(new FullJoin(source, condition));

        public Select CrossJoin(string table) => CrossJoin(new Table(table));
		public virtual Select CrossJoin(ISource source) => AddJoin(new CrossJoin(source));

		public virtual Select Join(IJoin join) => AddJoin(join);

		public virtual Select Having(Action<ConditionBuilder> conditionAction) => 
			Having(_factory.Condition(conditionAction));

		public virtual Select Having(ICondition? condition)
		{
			HavingCondition = condition;

			return this;
		}

		public virtual Select OrderByAsc(string columnName, ISource? columnSource) => OrderBy(new OrderByAsc(new SourceColumn(columnName, columnSource)));
		public virtual Select OrderByAsc(string columnName, string? columnAlias, ISource? columnSource) => OrderBy(new OrderByAsc(new SourceColumn(columnName, columnAlias, columnSource)));
		public virtual Select OrderByAsc(params string[] columns) => OrderBy(columns.Select<string, IOrderBy>(c => new OrderByAsc(new SourceColumn(c))));
		public virtual Select OrderByAsc(IEnumerable<string> columns) => OrderBy(columns.Select<string, IOrderBy>(c => new OrderByAsc(new SourceColumn(c))));
		public virtual Select OrderByAsc(params IColumn[] columns) => OrderBy(columns.Select<IColumn, IOrderBy>(c => new OrderByAsc(c)));
		public virtual Select OrderByAsc(IEnumerable<IColumn> columns) => OrderBy(columns.Select<IColumn, IOrderBy>(c => new OrderByAsc(c)));
		public virtual Select OrderByAsc(Action<ColumnBuilder> action) => OrderByAsc(_factory.Columns(action));

		public virtual Select OrderByDesc(string columnName, ISource? columnSource) => OrderBy(new OrderByDesc(new SourceColumn(columnName, columnSource)));
		public virtual Select OrderByDesc(string columnName, string? columnAlias, ISource? columnSource) => OrderBy(new OrderByDesc(new SourceColumn(columnName, columnAlias, columnSource)));
		public virtual Select OrderByDesc(params string[] columns) => OrderBy(columns.Select<string, IOrderBy>(c => new OrderByDesc(new SourceColumn(c))));
		public virtual Select OrderByDesc(IEnumerable<string> columns) => OrderBy(columns.Select<string, IOrderBy>(c => new OrderByDesc(new SourceColumn(c))));
		public virtual Select OrderByDesc(params IColumn[] columns) => OrderBy(columns.Select<IColumn, IOrderBy>(c => new OrderByDesc(c)));
		public virtual Select OrderByDesc(IEnumerable<IColumn> columns) => OrderBy(columns.Select<IColumn, IOrderBy>(c => new OrderByDesc(c)));
		public virtual Select OrderByDesc(Action<ColumnBuilder> action) => OrderByDesc(_factory.Columns(action));
		
		public virtual Select OrderBy(params IOrderBy[] columns) => OrderBy((IEnumerable<IOrderBy>)columns);
		public virtual Select OrderBy(IEnumerable<IOrderBy> columns)
		{
			Guard.ThrowIfNullOrContainsNullElements(columns, nameof(columns));

			OrderByCollection.AddRange(columns);

			return this;
		}

		public virtual Select GroupBy(string columnName, ISource? sourceName) => GroupBy(new SourceColumn(columnName, sourceName));
		public virtual Select GroupBy(string columnName, string? columnAlias, ISource? sourceName) => GroupBy(new SourceColumn(columnName, columnAlias, sourceName));
		public virtual Select GroupBy(params string[] columns) => GroupBy(columns.Select<string, IColumn>(c => new SourceColumn(c)));
		public virtual Select GroupBy(IEnumerable<string> columns) => GroupBy(columns.Select<string, IColumn>(c => new SourceColumn(c)));
		public virtual Select GroupBy(params IColumn[] columns) => GroupBy(columns.AsEnumerable());
		public virtual Select GroupBy(Action<ColumnBuilder> action) => GroupBy(_factory.Columns(action));
		public virtual Select GroupBy(IEnumerable<IColumn> columns)
		{
			Guard.ThrowIfNullOrContainsNullElements(columns, nameof(columns));

			GroupByCollection.AddRange(columns);

			return this;
		}

		public virtual Select Offset(int? offset)
		{
			OffsetValue = offset.HasValue ? Guard.ThrowIfNegative(offset.Value, nameof(offset)) : offset;

			return this;
		}

		public virtual Select Limit(int? limit)
		{
			LimitValue = limit.HasValue ? Guard.ThrowIfNegative(limit.Value, nameof(limit)) : limit;

			return this;
		}

		public virtual Subquery ToSubquery(string alias) => new Subquery(this, alias);

		private Select AddJoin(IJoin join)
		{
			Guard.ThrowIfNull(join, nameof(join));

			JoinCollection.Add(join);

			return this;
		}

		public string RenderExpression(IRenderer renderer)
		{
			StringBuilder sql = new StringBuilder();
			RenderExpression(renderer, sql);

			return sql.ToString();
		}

		public virtual void RenderExpression(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderExpression(this, sql);

		public override void RenderQuery(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderQuery(this, sql);
	}
}
