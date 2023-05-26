using System;
using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class Insert : Query
	{
		private static readonly ExpressionFactory _factory = ExpressionFactory.Instance;

		public Insert(string name) : this(name, alias: null, schema: null)
		{
		}

		public Insert(string name, string? schema) : this(name, alias: null, schema)
		{
		}

		public Insert(string name, string? alias, string? schema)
		{
			Guard.ThrowIfNullOrEmpty(name, nameof(name));

			Source = new Table(name, alias, schema);
		}

		public Insert(Table table)
		{
			Source = Guard.ThrowIfNull(table, nameof(table));
		}

		public readonly ISource Source;
		public readonly List<IColumn> ColumnCollection = new List<IColumn>();
		public List<IExpression> ValueCollection = new List<IExpression>();
		public List<IColumn> ReturningColumnCollection = new List<IColumn>();

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

            ColumnCollection.AddRange(columns);

			return this;
		}

		public Insert Values(Action<ExpressionBuilder> action) =>
			Values(_factory.Expressions(action));
        
        public Insert Values(params IExpression[] values) => 
			Values((IEnumerable<IExpression>)values);

		public virtual Insert Values(IEnumerable<IExpression> values)
		{
			Guard.ThrowIfNullOrContainsNullElements(values, nameof(values));

            ValueCollection.AddRange(values);

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

            ReturningColumnCollection.AddRange(columns);

			return this;
		}
		
		public override void RenderQuery(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderQuery(this, sql);
	}
}
