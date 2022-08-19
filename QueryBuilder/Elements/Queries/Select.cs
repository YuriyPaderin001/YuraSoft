using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class Select : IQuery
	{
		private List<IColumn> _columnCollection = new List<IColumn>();
		private List<ISource> _sourceCollection = new List<ISource>();
		private List<IJoin> _joinCollection = new List<IJoin>();
		private List<IOrderBy> _orderByCollection = new List<IOrderBy>();
		private List<IColumn> _groupByCollection = new List<IColumn>();
		private int? _offset;
		private int? _limit;

		public Select(params string[] columns) : this((IEnumerable<string>)columns)
		{	
		}
		
		public Select(IEnumerable<string> columns) 
		{
			Validator.ThrowIfArgumentIsNullOrContainsNullOrEmptyElements(columns, nameof(columns));

			_columnCollection = columns.Select(c => new SourceColumn(c)).ToList<IColumn>();
		}

		public Select(params IColumn[] columns) : this((IEnumerable<IColumn>)columns)
		{
		}

		public Select(IEnumerable<IColumn> columns)
		{
			Validator.ThrowIfArgumentIsNullOrContainsNullElements(columns, nameof(columns));

			_columnCollection = new List<IColumn>(columns);
		}

		public Select(Action<ColumnBuilder> buildColumnAction)
		{
			Validator.ThrowIfArgumentIsNull(buildColumnAction, nameof(buildColumnAction));

			ColumnBuilder builder = new ColumnBuilder();
			buildColumnAction(builder);

			_columnCollection = builder.Build();
		}

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

		public virtual Select From(params string[] tables) => From(tables.Select<string, ISource>(t => new Table(t)));
		public virtual Select From(IEnumerable<string> tables) => From(tables.Select<string, ISource>(t => new Table(t)));
		public virtual Select From(params ISource[] tables) => From((IEnumerable<ISource>)tables);

		public virtual Select From(IEnumerable<ISource> sources)
		{
			Validator.ThrowIfArgumentIsNullOrContainsNullElements(sources, nameof(sources));

			SourceCollection.AddRange(sources);

			return this;
		}

		public virtual Select Where(ICondition? condition)
		{
			WhereCondition = condition;

			return this;
		}

		public virtual Select Where(Action<ConditionBuilder> buildConditionMethod)
		{
			Validator.ThrowIfArgumentIsNull(buildConditionMethod, nameof(buildConditionMethod));

			ConditionBuilder builder = new ConditionBuilder();
			buildConditionMethod.Invoke(builder);

			WhereCondition = builder.Build();

			return this;
		}

		public virtual Select LeftJoin(string table, ICondition condition) => AddJoin(new LeftJoin(new Table(table), condition));
		public virtual Select LeftJoin(string table, Action<ConditionBuilder> buildConditionMethod) => LeftJoin(new Table(table), buildConditionMethod);
		public virtual Select LeftJoin(ISource source, ICondition condition) => AddJoin(new LeftJoin(source, condition));
		public virtual Select LeftJoin(ISource source, Action<ConditionBuilder> buildConditionMethod)
		{
			Validator.ThrowIfArgumentIsNull(buildConditionMethod, nameof(buildConditionMethod));

			ConditionBuilder builder = new ConditionBuilder();
			buildConditionMethod.Invoke(builder);

			ICondition condition = builder.Build();

			AddJoin(new LeftJoin(source, condition));

			return this;
		}

		public virtual Select RightJoin(string table, ICondition condition) => AddJoin(new RightJoin(new Table(table), condition));
		public virtual Select RightJoin(string table, Action<ConditionBuilder> buildConditionMethod) => RightJoin(new Table(table), buildConditionMethod);
		public virtual Select RightJoin(ISource source, ICondition condition) => AddJoin(new RightJoin(source, condition));
		public virtual Select RightJoin(ISource source, Action<ConditionBuilder> buildConditionMethod)
		{
			Validator.ThrowIfArgumentIsNull(buildConditionMethod, nameof(buildConditionMethod));

			ConditionBuilder builder = new ConditionBuilder();
			buildConditionMethod.Invoke(builder);

			ICondition condition = builder.Build();

			AddJoin(new RightJoin(source, condition));

			return this;
		}

		public virtual Select InnerJoin(string table, ICondition condition) => AddJoin(new InnerJoin(new Table(table), condition));
		public virtual Select InnerJoin(string table, Action<ConditionBuilder> buildConditionMethod) => InnerJoin(new Table(table), buildConditionMethod);
		public virtual Select InnerJoin(ISource source, ICondition condition) => AddJoin(new InnerJoin(source, condition));
		public virtual Select InnerJoin(ISource source, Action<ConditionBuilder> buildConditionMethod)
		{
			Validator.ThrowIfArgumentIsNull(buildConditionMethod, nameof(buildConditionMethod));

			ConditionBuilder builder = new ConditionBuilder();
			buildConditionMethod.Invoke(builder);

			ICondition condition = builder.Build();

			AddJoin(new RightJoin(source, condition));

			return this;
		}

		public virtual Select CrossJoin(string table) => AddJoin(new CrossJoin(new Table(table)));
		public virtual Select CrossJoin(ISource source) => AddJoin(new CrossJoin(source));

		public virtual Select Join(IJoin join) => AddJoin(join);

		public virtual Select Having(ICondition? condition)
		{
			HavingCondition = condition;

			return this;
		}

		public virtual Select OrderByAsc(params string[] columns) => OrderBy(columns.Select<string, IOrderBy>(c => new OrderByAsc(new SourceColumn(c))));
		public virtual Select OrderByAsc(IEnumerable<string> columns) => OrderBy(columns.Select<string, IOrderBy>(c => new OrderByAsc(new SourceColumn(c))));
		public virtual Select OrderByAsc(params IColumn[] columns) => OrderBy(columns.Select<IColumn, IOrderBy>(c => new OrderByAsc(c)));
		public virtual Select OrderByAsc(IEnumerable<IColumn> columns) => OrderBy(columns.Select<IColumn, IOrderBy>(c => new OrderByAsc(c)));
		public virtual Select OrderByDesc(params string[] columns) => OrderBy(columns.Select<string, IOrderBy>(c => new OrderByDesc(new SourceColumn(c))));
		public virtual Select OrderByDesc(IEnumerable<string> columns) => OrderBy(columns.Select<string, IOrderBy>(c => new OrderByDesc(new SourceColumn(c))));
		public virtual Select OrderByDesc(params IColumn[] columns) => OrderBy(columns.Select<IColumn, IOrderBy>(c => new OrderByDesc(c)));
		public virtual Select OrderByDesc(IEnumerable<IColumn> columns) => OrderBy(columns.Select<IColumn, IOrderBy>(c => new OrderByDesc(c)));
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

		public virtual string RenderQuery(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderQuery(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public virtual void RenderQuery(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderQuery(this, stringBuilder);

		private Select AddJoin(IJoin join)
		{
			Validator.ThrowIfArgumentIsNull(join, nameof(join));

			JoinCollection.Add(join);

			return this;
		}
	}
}
