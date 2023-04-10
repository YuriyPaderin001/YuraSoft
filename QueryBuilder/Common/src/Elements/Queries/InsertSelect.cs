using System;
using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class InsertSelect : Query
	{
		private static readonly ExpressionFactory _factory = ExpressionFactory.Instance;

		private ISource _source;
		private List<IColumn> _sourceColumns = new List<IColumn>();
		private Select _select;
		private List<IColumn> _returningColumns = new List<IColumn>();

		public InsertSelect(string name, Select select) : this(name, alias: null, schema: null, select)
		{
		}

		public InsertSelect(string name, string? schema, Select select) : this(name, alias: null, schema, select)
		{
		}

		public InsertSelect(string name, string? alias, string? schema, Select select)
		{
			Guard.ThrowIfNullOrEmpty(name, nameof(name));
			Guard.ThrowIfNull(select, nameof(select));

			_source = new Table(name, alias, schema);
			_select = select;
		}

		public InsertSelect(Table table, Select select)
		{
			_source = Guard.ThrowIfNull(table, nameof(table));
			_select = Guard.ThrowIfNull(select, nameof(select));
		}

		public ISource Source
		{
			get => _source;
			set => _source = Guard.ThrowIfNull(value, nameof(Source));
		}

		public List<IColumn> ColumnCollection
		{
			get => _sourceColumns;
			set => _sourceColumns = Guard.ThrowIfNullOrContainsNullElements(value, nameof(ColumnCollection));
		}

		public Select SelectQuery
		{
			get => _select;
			set => _select = Guard.ThrowIfNull(value, nameof(Select));
		}

		public List<IColumn> ReturningColumnCollection
		{
			get => _returningColumns;
			set => _returningColumns = Guard.ThrowIfNullOrContainsNullElements(value, nameof(ReturningColumnCollection));
		}

		public InsertSelect Columns(Action<ColumnBuilder> action) =>
			Columns(_factory.Columns(action));
    
        public InsertSelect Columns(params string[] columns) => 
			Columns((IEnumerable<string>)columns);

		public InsertSelect Columns(IEnumerable<string> columns) =>
			Columns(_factory.Columns(columns));
	
		public InsertSelect Columns(params IColumn[] columns) => 
			Columns((IEnumerable<IColumn>)columns);

		public virtual InsertSelect Columns(IEnumerable<IColumn> columns)
		{
			Guard.ThrowIfNullOrContainsNullElements(columns, nameof(columns));

			_sourceColumns.AddRange(columns);

			return this;
		}

		public InsertSelect Returning(Action<ColumnBuilder> action) =>
			Returning(_factory.Columns(action));

        public InsertSelect Returning(params string[] columns) =>
            Returning((IEnumerable<string>)columns);

		public InsertSelect Returning(IEnumerable<string> columns) =>
			Returning(_factory.Columns(columns));

        public virtual InsertSelect Returning(params IColumn[] columns) =>
            Returning((IEnumerable<IColumn>)columns);

        public virtual InsertSelect Returning(IEnumerable<IColumn> columns)
		{
			Guard.ThrowIfNullOrContainsNullElements(columns, nameof(columns));

			_returningColumns.AddRange(columns);

			return this;
		}

		public override void RenderQuery(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderQuery(this, sql);
	}
}
