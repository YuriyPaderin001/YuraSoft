using System;
using System.Collections.Generic;
using System.Linq;

using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class Select : ISelect
	{
		private int? _offset;
		private int? _limit;

		public Select(params string[] columns)
		{
			SelectColumns = columns.Select(c => new Column(c)).ToList<IColumn>();
		}

		public Select(IEnumerable<string> columns)
		{
			SelectColumns = columns.Select(c => new Column(c)).ToList<IColumn>();
		}

		public Select(params IColumn[] columns)
		{
			SelectColumns = new List<IColumn>(columns);
		}

		public Select(IEnumerable<IColumn> columns)
		{
			SelectColumns = new List<IColumn>(columns);
		}

		public List<IColumn> SelectColumns { get; set; } = new List<IColumn>();
		public List<ISource> Sources { get; set; } = new List<ISource>();
		public ICondition? WhereCondition { get; set; }
		public List<IJoin> Joins { get; set; } = new List<IJoin>();
		public ICondition? HavingCondition { get; set; }
		public List<IOrderBy> OrderByColumns { get; set; } = new List<IOrderBy>();
		public List<IColumn> GroupByColumns { get; set; } = new List<IColumn>();
		
		public int? OffsetValue 
		{ 
			get => _offset;
			set => _offset = value ?? throw new ArgumentShouldNotBeNegativeException(nameof(OffsetValue));
		}
		
		public int? LimitValue 
		{ 
			get => _limit;
			set => _limit = value ?? throw new ArgumentShouldNotBeNegativeException(nameof(LimitValue));
		}

		public Select From(params string[] tables) => From(tables.Select<string, ISource>(t => new Table(t)));
		public Select From(IEnumerable<string> tables) => From(tables.Select<string, ISource>(t => new Table(t)));
		public Select From(params ISource[] tables) => From(tables.AsEnumerable());

		public Select From(IEnumerable<ISource> sources)
		{
			if (sources == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(sources));
			}

			foreach (ISource source in sources)
			{
				if (source == null)
				{
					throw new CollectionShouldNotContainsNullElementsException(nameof(sources));
				}

				Sources.Add(source);
			}

			return this;
		}

		public Select Where(ICondition condition)
		{
			WhereCondition = condition;

			return this;
		}

		public Select Where(Action<ConditionBuilder> buildConditionMethod)
		{
			ConditionBuilder builder = new ConditionBuilder();
			buildConditionMethod.Invoke(builder);

			WhereCondition = builder.Build();

			return this;
		}

		public Select LeftJoin(string table, ICondition condition) => AddJoin(new LeftJoin(new Table(table), condition));
		public Select LeftJoin(string table, Action<ConditionBuilder> buildConditionMethod) => LeftJoin(new Table(table), buildConditionMethod);
		public Select LeftJoin(ISource source, ICondition condition) => AddJoin(new LeftJoin(source, condition));
		public Select LeftJoin(ISource source, Action<ConditionBuilder> buildConditionMethod)
		{
			ConditionBuilder builder = new ConditionBuilder();
			buildConditionMethod.Invoke(builder);

			ICondition condition = builder.Build();

			AddJoin(new LeftJoin(source, condition));

			return this;
		}

		public Select RightJoin(string table, ICondition condition) => AddJoin(new RightJoin(new Table(table), condition));
		public Select RightJoin(string table, Action<ConditionBuilder> buildConditionMethod) => RightJoin(new Table(table), buildConditionMethod);
		public Select RightJoin(ISource source, ICondition condition) => AddJoin(new RightJoin(source, condition));
		public Select RightJoin(ISource source, Action<ConditionBuilder> buildConditionMethod)
		{
			ConditionBuilder builder = new ConditionBuilder();
			buildConditionMethod.Invoke(builder);

			ICondition condition = builder.Build();

			AddJoin(new RightJoin(source, condition));

			return this;
		}

		public Select InnerJoin(string table, ICondition condition) => AddJoin(new InnerJoin(new Table(table), condition));
		public Select InnerJoin(string table, Action<ConditionBuilder> buildConditionMethod) => InnerJoin(new Table(table), buildConditionMethod);
		public Select InnerJoin(ISource source, ICondition condition) => AddJoin(new InnerJoin(source, condition));
		public Select InnerJoin(ISource source, Action<ConditionBuilder> buildConditionMethod)
		{
			ConditionBuilder builder = new ConditionBuilder();
			buildConditionMethod.Invoke(builder);

			ICondition condition = builder.Build();

			AddJoin(new RightJoin(source, condition));

			return this;
		}

		public Select CrossJoin(string table) => AddJoin(new CrossJoin(new Table(table)));
		public Select CrossJoin(ISource source) => AddJoin(new CrossJoin(source));

		public Select Join(IJoin join) => AddJoin(join);

		public Select Having(ICondition condition)
		{
			HavingCondition = condition;

			return this;
		}

		public Select OrderByAsc(params string[] columns) => OrderBy(columns.Select<string, IOrderBy>(c => new OrderByAsc(new Column(c))));
		public Select OrderByAsc(IEnumerable<string> columns) => OrderBy(columns.Select<string, IOrderBy>(c => new OrderByAsc(new Column(c))));
		public Select OrderByAsc(params IColumn[] columns) => OrderBy(columns.Select<IColumn, IOrderBy>(c => new OrderByAsc(c)));
		public Select OrderByAsc(IEnumerable<IColumn> columns) => OrderBy(columns.Select<IColumn, IOrderBy>(c => new OrderByAsc(c)));
		public Select OrderByDesc(params string[] columns) => OrderBy(columns.Select<string, IOrderBy>(c => new OrderByDesc(new Column(c))));
		public Select OrderByDesc(IEnumerable<string> columns) => OrderBy(columns.Select<string, IOrderBy>(c => new OrderByDesc(new Column(c))));
		public Select OrderByDesc(params IColumn[] columns) => OrderBy(columns.Select<IColumn, IOrderBy>(c => new OrderByDesc(c)));
		public Select OrderByDesc(IEnumerable<IColumn> columns) => OrderBy(columns.Select<IColumn, IOrderBy>(c => new OrderByDesc(c)));
		public Select OrderBy(params IOrderBy[] columns) => OrderBy(columns.AsEnumerable());

		public Select OrderBy(IEnumerable<IOrderBy> columns)
		{
			if (columns == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(columns));
			}

			foreach (IOrderBy column in columns)
			{
				if (column == null)
				{
					throw new CollectionShouldNotContainsNullElementsException(nameof(columns));
				}

				OrderByColumns.Add(column);
			}

			return this;
		}

		public Select GroupBy(params string[] columns) => GroupBy(columns.Select<string, IColumn>(c => new Column(c)));
		public Select GroupBy(IEnumerable<string> columns) => GroupBy(columns.Select<string, IColumn>(c => new Column(c)));
		public Select GroupBy(params IColumn[] columns) => GroupBy(columns.AsEnumerable());
		
		public Select GroupBy(IEnumerable<IColumn> columns)
		{
			if (columns == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(columns));
			}

			foreach (IColumn column in columns)
			{
				if (column == null)
				{
					throw new CollectionShouldNotContainsNullElementsException(nameof(columns));
				}

				GroupByColumns.Add(column);
			}

			return this;
		}

		public Select Offset(int? offset)
		{
			if (offset.HasValue && offset.Value < 0)
			{
				throw new ArgumentShouldNotBeNegativeException(nameof(offset));
			}

			_offset = offset;

			return this;
		}

		public Select Limit(int? limit)
		{
			if (limit.HasValue && limit.Value < 0)
			{
				throw new ArgumentShouldNotBeNegativeException(nameof(limit));
			}

			_limit = limit;

			return this;
		}

		public string RenderSelect(IRenderer renderer) => renderer.RenderSelect(this);

		private Select AddJoin(IJoin join)
		{
			if (join == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(join));
			}

			Joins.Add(join);

			return this;
		}
	}
}
