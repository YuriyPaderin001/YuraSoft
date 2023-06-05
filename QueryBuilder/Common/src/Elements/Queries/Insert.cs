using System;
using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class Insert : Query
	{
		private static readonly ExpressionFactory _factory = ExpressionFactory.Instance;

		public Insert(string tableName) : this(tableName, tableAlias: null, tableSchema: null)
		{
		}

		public Insert(string tableName, string? tableSchema) : this(tableName, tableAlias: null, tableSchema)
		{
		}

		public Insert(string tableName, string? tableAlias, string? tableSchema)
		{
			Guard.ThrowIfNullOrEmpty(tableName, nameof(tableName));

			Source = new Table(tableName, tableAlias, tableSchema);
		}

		public Insert(Table table)
		{
			Source = Guard.ThrowIfNull(table, nameof(table));
		}

		public readonly ISource Source;
		public readonly List<IColumn> ColumnCollection = new List<IColumn>();
		public readonly List<IExpression> ValueCollection = new List<IExpression>();
		public readonly List<IColumn> ReturningColumnCollection = new List<IColumn>();

		public Insert Columns(Action<ColumnBuilder> columnAction) =>
			Columns(_factory.Columns(columnAction));

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

		public Insert Values(Action<ExpressionBuilder> valueAction) =>
			Values(_factory.Expressions(valueAction));
        
        public Insert Values(params IExpression[] values) => 
			Values((IEnumerable<IExpression>)values);

		public virtual Insert Values(IEnumerable<IExpression> values)
		{
			Guard.ThrowIfNullOrContainsNullElements(values, nameof(values));

            ValueCollection.AddRange(values);

			return this;
		}

        public Insert Returning(Action<ColumnBuilder> columnAction) =>
            Returning(_factory.Columns(columnAction));

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
