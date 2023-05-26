using System;
using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class InsertSelect : Query
	{
		private static readonly ExpressionFactory _factory = ExpressionFactory.Instance;

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

			Source = new Table(name, alias, schema);
            SelectQuery = select;
		}

		public InsertSelect(Table table, Select select)
		{
			Source = Guard.ThrowIfNull(table, nameof(table));
            SelectQuery = Guard.ThrowIfNull(select, nameof(select));
		}

		public readonly ISource Source;
		public readonly List<IColumn> ColumnCollection = new List<IColumn>();
		public readonly Select SelectQuery;
		public readonly List<IColumn> ReturningColumnCollection = new List<IColumn>();

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

            ColumnCollection.AddRange(columns);

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

            ReturningColumnCollection.AddRange(columns);

			return this;
		}

		public override void RenderQuery(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderQuery(this, sql);
	}
}
