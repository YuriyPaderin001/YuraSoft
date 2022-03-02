using System;
using System.Collections.Generic;
using System.Linq;

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
			Columns = columns.Select(c => new Column(c)).ToList<IColumn>();
		}

		public Select(params IColumn[] columns)
		{
			Columns = new List<IColumn>(columns);
		}

		public List<IColumn> Columns { get; set; } = new List<IColumn>();
		public List<ISource> Sources { get; set; } = new List<ISource>();
		public ICondition? Condition { get; set; }
		public List<IJoin> Joins { get; set; } = new List<IJoin>();
		
		public int? OffsetValue 
		{ 
			get => _offset; 
			set => _offset = value ?? throw new ArgumentException("{0} can't be negative", nameof(OffsetValue)); 
		}
		
		public int? LimitValue 
		{ 
			get => _limit; 
			set => _limit = value ?? throw new ArgumentException("{0} can't be negative", nameof(LimitValue));  
		}

		public Select From(params Table[] tables)
		{
			Sources = new List<ISource>(tables);

			return this;
		}

		public Select Where(ICondition condition)
		{
			Condition = condition;

			return this;
		}

		public Select LeftJoin(string table, ICondition condition) => AddJoin(new LeftJoin(new Table(table), condition));
		public Select LeftJoin(ISource source, ICondition condition) => AddJoin(new LeftJoin(source, condition));
		public Select LeftJoin(LeftJoin join) => AddJoin(join);

		public Select RightJoin(string table, ICondition condition) => AddJoin(new RightJoin(new Table(table), condition));
		public Select RightJoin(ISource source, ICondition condition) => AddJoin(new RightJoin(source, condition));
		public Select RightJoin(RightJoin join) => AddJoin(join);

		public Select InnerJoin(string table, ICondition condition) => AddJoin(new InnerJoin(new Table(table), condition));
		public Select InnerJoin(ISource source, ICondition condition) => AddJoin(new InnerJoin(source, condition));
		public Select InnerJoin(InnerJoin join) => AddJoin(join);

		public Select Offset(int? offset)
		{
			if (offset.HasValue && offset.Value < 0)
			{
				throw new ArgumentException("{0} can't be negative", nameof(offset));
			}

			_offset = offset;

			return this;
		}

		public Select Limit(int? limit)
		{
			if (limit.HasValue && limit.Value < 0)
			{
				throw new ArgumentException("{0} can't be negative", nameof(limit));
			}

			_limit = limit;

			return this;
		}

		public string RenderSelect(IRenderer renderer) => renderer.RenderSelect(this);

		private Select AddJoin(IJoin join)
		{
			if (join == null)
			{
				throw new ArgumentNullException(nameof(join), "{0} can't be null");
			}

			Joins.Add(join);

			return this;
		}
	}
}
