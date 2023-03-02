using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class Select : IQuery, IExpression
	{
		private static ExpressionFactory _factory = ExpressionFactory.Instance;

		#region Fields

		private List<IColumn> _columnCollection = new List<IColumn>();
		private List<ISource> _sourceCollection = new List<ISource>();
		private List<IJoin> _joinCollection = new List<IJoin>();
		private List<IOrderBy> _orderByCollection = new List<IOrderBy>();
		private List<IColumn> _groupByCollection = new List<IColumn>();
		private int? _offset;
		private int? _limit;

		#endregion Fields

		#region Constructors

		public Select(params string[] columns) : this((IEnumerable<string>)columns)
		{
		}

		public Select(IEnumerable<string> columns)
		{
			Validator.ThrowIfArgumentIsNullOrContainsNullOrEmptyElements(columns, nameof(columns));

			_columnCollection.AddRange(columns.Select(c => new SourceColumn(c)));
		}

		public Select(params IColumn[] columns) : this((IEnumerable<IColumn>)columns)
		{
		}

		public Select(IEnumerable<IColumn> columns)
		{
			Validator.ThrowIfArgumentIsNullOrContainsNullElements(columns, nameof(columns));

			_columnCollection.AddRange(columns);
		}

		public Select(Action<ColumnBuilder> buildColumnAction)
		{
			Validator.ThrowIfArgumentIsNull(buildColumnAction, nameof(buildColumnAction));

			ColumnBuilder builder = new ColumnBuilder();
			buildColumnAction(builder);

			_columnCollection.AddRange(builder.Build());
		}

		#endregion Constructors

		#region Properties

		public IDistinct? DistinctValue { get; set; }

		public List<IColumn> ColumnCollection
		{
			get => _columnCollection;
			set => _columnCollection = Validator.ThrowIfArgumentIsNullOrContainsNullElements(value, nameof(ColumnCollection));
		}

		public List<ISource> SourceCollection
		{
			get => _sourceCollection;
			set => _sourceCollection = Validator.ThrowIfArgumentIsNullOrContainsNullElements(value, nameof(SourceCollection));
		}

		public ICondition? WhereCondition { get; set; }

		public List<IJoin> JoinCollection
		{
			get => _joinCollection;
			set => _joinCollection = Validator.ThrowIfArgumentIsNullOrContainsNullElements(value, nameof(JoinCollection));
		}

		public ICondition? HavingCondition { get; set; }

		public List<IOrderBy> OrderByCollection
		{
			get => _orderByCollection;
			set => _orderByCollection = Validator.ThrowIfArgumentIsNullOrContainsNullElements(value, nameof(OrderByCollection));
		}

		public List<IColumn> GroupByCollection
		{
			get => _groupByCollection;
			set => _groupByCollection = Validator.ThrowIfArgumentIsNullOrContainsNullElements(value, nameof(GroupByCollection));
		}

		public int? OffsetValue
		{
			get => _offset;
			set => _offset = value.HasValue ? Validator.ThrowIfArgumentIsNegative(value.Value, nameof(OffsetValue)) : value;
		}

		public int? LimitValue
		{
			get => _limit;
			set => _limit = value.HasValue ? Validator.ThrowIfArgumentIsNegative(value.Value, nameof(OffsetValue)) : value;
		}

		#endregion Properties

		#region Methods

		public virtual Select Distinct() => Distinct(new Distinct());

		public virtual Select Distinct(IDistinct? distinct)
		{
			DistinctValue = distinct;

			return this;
		}

		public virtual Select From(params string[] tables) => From(tables.Select<string, ISource>(t => new Table(t)));
		public virtual Select From(IEnumerable<string> tables) => From(tables.Select<string, ISource>(t => new Table(t)));
		public virtual Select From(params ISource[] sources) => From((IEnumerable<ISource>)sources);

		public virtual Select From(IEnumerable<ISource> sources)
		{
			Validator.ThrowIfArgumentIsNullOrContainsNullElements(sources, nameof(sources));

			SourceCollection.AddRange(sources);

			return this;
		}

		public virtual Select Where(Action<ConditionBuilder> buildConditionMethod) => Where(_factory.Condition(buildConditionMethod));
		public virtual Select Where(ICondition? condition)
		{
			WhereCondition = condition;

			return this;
		}

		public virtual Select LeftJoin(string table, ICondition condition) => AddJoin(new LeftJoin(new Table(table), condition));
		public virtual Select LeftJoin(string table, Action<ConditionBuilder> buildConditionMethod) => LeftJoin(new Table(table), buildConditionMethod);
		public virtual Select LeftJoin(string leftTable, string rightTable, Action<ConditionBuilder, ISource, ISource> buildConditionMethod) => LeftJoin(new Table(leftTable), new Table(rightTable), buildConditionMethod);
	
		public virtual Select LeftJoin(ISource source, ICondition condition) => AddJoin(new LeftJoin(source, condition));
		public virtual Select LeftJoin(ISource source, Action<ConditionBuilder> buildConditionMethod) => AddJoin(new LeftJoin(source, _factory.Condition(buildConditionMethod)));
		public virtual Select LeftJoin(ISource leftSource, ISource rightSource, Action<ConditionBuilder, ISource, ISource> buildConditionMethod) => AddJoin(new LeftJoin(rightSource, _factory.Condition(leftSource, rightSource, buildConditionMethod)));

		public virtual Select RightJoin(string table, ICondition condition) => AddJoin(new RightJoin(new Table(table), condition));
		public virtual Select RightJoin(string table, Action<ConditionBuilder> buildConditionMethod) => RightJoin(new Table(table), buildConditionMethod);
		public virtual Select RightJoin(string leftTable, string rightTable, Action<ConditionBuilder, ISource, ISource> buildConditionMethod) => RightJoin(new Table(leftTable), new Table(rightTable), buildConditionMethod);

		public virtual Select RightJoin(ISource source, ICondition condition) => AddJoin(new RightJoin(source, condition));
		public virtual Select RightJoin(ISource source, Action<ConditionBuilder> buildConditionMethod) => AddJoin(new RightJoin(source, _factory.Condition(buildConditionMethod)));
		public virtual Select RightJoin(ISource leftSource, ISource rightSource, Action<ConditionBuilder, ISource, ISource> buildConditionMethod) => AddJoin(new RightJoin(rightSource, _factory.Condition(leftSource, rightSource, buildConditionMethod)));

		public virtual Select InnerJoin(string table, ICondition condition) => AddJoin(new InnerJoin(new Table(table), condition));
		public virtual Select InnerJoin(string table, Action<ConditionBuilder> buildConditionMethod) => AddJoin(new InnerJoin(new Table(table), _factory.Condition(buildConditionMethod)));
		public virtual Select InnerJoin(string leftTable, string rightTable, Action<ConditionBuilder, ISource, ISource> buildConditionMethod) => InnerJoin(new Table(leftTable), new Table(rightTable), buildConditionMethod);

		public virtual Select InnerJoin(ISource source, ICondition condition) => AddJoin(new InnerJoin(source, condition));
		public virtual Select InnerJoin(ISource source, Action<ConditionBuilder> buildConditionMethod) => AddJoin(new InnerJoin(source, _factory.Condition(buildConditionMethod)));
		public virtual Select InnerJoin(ISource leftSource, ISource rightSource, Action<ConditionBuilder, ISource, ISource> buildConditionMethod) => AddJoin(new InnerJoin(rightSource, _factory.Condition(leftSource, rightSource, buildConditionMethod)));

		public virtual Select CrossJoin(string table) => AddJoin(new CrossJoin(new Table(table)));
		public virtual Select CrossJoin(ISource source) => AddJoin(new CrossJoin(source));

		public virtual Select Join(IJoin join) => AddJoin(join);

		public virtual Select Having(Action<ConditionBuilder> buildConditionMethod) => Having(_factory.Condition(buildConditionMethod));
		public virtual Select Having(ICondition? condition)
		{
			HavingCondition = condition;

			return this;
		}

		public virtual Select OrderByAsc(params string[] columns) => OrderBy(columns.Select<string, IOrderBy>(c => new OrderByAsc(new SourceColumn(c))));
		public virtual Select OrderByAsc(IEnumerable<string> columns) => OrderBy(columns.Select<string, IOrderBy>(c => new OrderByAsc(new SourceColumn(c))));
		public virtual Select OrderByAsc(params IColumn[] columns) => OrderBy(columns.Select<IColumn, IOrderBy>(c => new OrderByAsc(c)));
		public virtual Select OrderByAsc(IEnumerable<IColumn> columns) => OrderBy(columns.Select<IColumn, IOrderBy>(c => new OrderByAsc(c)));
		public virtual Select OrderByAsc(Action<ColumnBuilder> action) => OrderByAsc(_factory.Columns(action));

		public virtual Select OrderByDesc(params string[] columns) => OrderBy(columns.Select<string, IOrderBy>(c => new OrderByDesc(new SourceColumn(c))));
		public virtual Select OrderByDesc(IEnumerable<string> columns) => OrderBy(columns.Select<string, IOrderBy>(c => new OrderByDesc(new SourceColumn(c))));
		public virtual Select OrderByDesc(params IColumn[] columns) => OrderBy(columns.Select<IColumn, IOrderBy>(c => new OrderByDesc(c)));
		public virtual Select OrderByDesc(IEnumerable<IColumn> columns) => OrderBy(columns.Select<IColumn, IOrderBy>(c => new OrderByDesc(c)));
		public virtual Select OrderByDesc(Action<ColumnBuilder> action) => OrderByDesc(_factory.Columns(action));
		
		public virtual Select OrderBy(params IOrderBy[] columns) => OrderBy((IEnumerable<IOrderBy>)columns);
		public virtual Select OrderBy(IEnumerable<IOrderBy> columns)
		{
			Validator.ThrowIfArgumentIsNullOrContainsNullElements(columns, nameof(columns));

			OrderByCollection.AddRange(columns);

			return this;
		}

		public virtual Select GroupBy(params string[] columns) => GroupBy(columns.Select<string, IColumn>(c => new SourceColumn(c)));
		public virtual Select GroupBy(IEnumerable<string> columns) => GroupBy(columns.Select<string, IColumn>(c => new SourceColumn(c)));
		public virtual Select GroupBy(params IColumn[] columns) => GroupBy(columns.AsEnumerable());
		public virtual Select GroupBy(Action<ColumnBuilder> action) => GroupBy(_factory.Columns(action));
		public virtual Select GroupBy(IEnumerable<IColumn> columns)
		{
			Validator.ThrowIfArgumentIsNullOrContainsNullElements(columns, nameof(columns));

			GroupByCollection.AddRange(columns);

			return this;
		}

		public virtual Select Offset(int? offset)
		{
			_offset = offset.HasValue ? Validator.ThrowIfArgumentIsNegative(offset.Value, nameof(offset)) : offset;

			return this;
		}

		public virtual Select Limit(int? limit)
		{
			_limit = limit.HasValue ? Validator.ThrowIfArgumentIsNegative(limit.Value, nameof(limit)) : limit;

			return this;
		}

		private Select AddJoin(IJoin join)
		{
			Validator.ThrowIfArgumentIsNull(join, nameof(join));

			JoinCollection.Add(join);

			return this;
		}

		#region Rendering methods

		public string RenderExpression(IRenderer renderer)
		{
			StringBuilder query = new StringBuilder();
			RenderExpression(renderer, query);

			return query.ToString();
		}

		public virtual void RenderExpression(IRenderer renderer, StringBuilder query) => renderer.RenderExpression(this, query);

		public virtual string RenderQuery(IRenderer renderer)
		{
			StringBuilder query = new StringBuilder();
			RenderQuery(renderer, query);

			return query.ToString();
		}

		public virtual void RenderQuery(IRenderer renderer, StringBuilder query) => renderer.RenderQuery(this, query);

		#endregion Rendering methods

		#endregion Methods
	}
}
