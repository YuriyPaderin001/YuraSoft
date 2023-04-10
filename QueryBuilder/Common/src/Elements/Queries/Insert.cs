using System;
using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class Insert : Query
	{
		private static readonly ExpressionFactory _factory = ExpressionFactory.Instance;

		private ISource _source;
		private List<IColumn> _sourceColumns = new List<IColumn>();
		private List<IExpression> _values = new List<IExpression>();
		private List<IColumn> _returningColumns = new List<IColumn>();

		public Insert(string name) : this(name, alias: null, schema: null)
		{
		}

		public Insert(string name, string? schema) : this(name, alias: null, schema)
		{
		}

		public Insert(string name, string? alias, string? schema)
		{
			Guard.ThrowIfNullOrEmpty(name, nameof(name));

			_source = new Table(name, alias, schema);
		}

		public Insert(Table table)
		{
			_source = Guard.ThrowIfNull(table, nameof(table));
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

		public List<IExpression> ValueCollection
		{
			get => _values;
			set => _values = Guard.ThrowIfNullOrContainsNullElements(value, nameof(ValueCollection));
		}

		public List<IColumn> ReturningColumnCollection
		{
			get => _returningColumns;
			set => _returningColumns = Guard.ThrowIfNullOrContainsNullElements(value, nameof(ReturningColumnCollection));
		}

		public Insert Columns(Action<ColumnBuilder> action) =>
			Columns(_factory.Columns(action));

        public Insert Columns(params string[] columns) => 
			Columns((IEnumerable<string>)columns);

		public Insert Columns(IEnumerable<string> columns) =>
			Columns(_factory.Columns(columns));

        public Insert Columns(params IColumn[] columns) => 
			Columns((IEnumerable<IColumn>)columns);

		public virtual Insert Columns(IEnumerable<IColumn> columns)
		{
			Guard.ThrowIfNullOrContainsNullElements(columns, nameof(columns));
			
			_sourceColumns.AddRange(columns);

			return this;
		}

		public Insert Values(Action<ExpressionBuilder> action) =>
			Values(_factory.Expressions(action));
        
        public Insert Values(params IExpression[] values) => 
			Values((IEnumerable<IExpression>)values);

		public virtual Insert Values(IEnumerable<IExpression> values)
		{
			Guard.ThrowIfNullOrContainsNullElements(values, nameof(values));

			_values.AddRange(values);

			return this;
		}

        public Insert Returning(Action<ColumnBuilder> action) =>
            Returning(_factory.Columns(action));

        public Insert Returning(params string[] columns) =>
            Returning((IEnumerable<string>)columns);

		public Insert Returning(IEnumerable<string> columns) =>
			Returning(_factory.Columns(columns));

        public Insert Returning(params IColumn[] columns) =>
            Returning((IEnumerable<IColumn>)columns);

        public virtual Insert Returning(IEnumerable<IColumn> columns)
		{
			Guard.ThrowIfNullOrContainsNullElements(columns, nameof(columns));

			_returningColumns.AddRange(columns);

			return this;
		}
		
		public override void RenderQuery(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderQuery(this, sql);
	}
}
