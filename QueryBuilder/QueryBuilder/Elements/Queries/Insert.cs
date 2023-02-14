using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class Insert : IQuery
	{
		#region Fields

		private ISource _source;
		private List<IColumn> _sourceColumns = new List<IColumn>();
		private List<IExpression> _values = new List<IExpression>();
		private List<IColumn> _returningColumns = new List<IColumn>();

		#endregion Fields

		#region Constructors

		public Insert(string name, string? alias = null, string? schema = null)
		{
			Validator.ThrowIfArgumentIsNullOrEmpty(name, nameof(name));

			_source = new Table(name, alias, schema);
		}

		public Insert(Table table)
		{
			_source = Validator.ThrowIfArgumentIsNull(table, nameof(table));
		}

		#endregion Constructors

		#region Properties

		public ISource Source 
		{ 
			get => _source; 
			set => _source = Validator.ThrowIfArgumentIsNull(value, nameof(Source));
		}

		public List<IColumn> ColumnCollection
		{
			get => _sourceColumns;
			set => _sourceColumns = Validator.ThrowIfArgumentIsNullOrContainsNullElements(value, nameof(ColumnCollection));
		}

		public List<IExpression> ValueCollection
		{
			get => _values;
			set => _values = Validator.ThrowIfArgumentIsNullOrContainsNullElements(value, nameof(ValueCollection));
		}

		public List<IColumn> ReturningColumnCollection
		{
			get => _returningColumns;
			set => _returningColumns = Validator.ThrowIfArgumentIsNullOrContainsNullElements(value, nameof(ReturningColumnCollection));
		}

		#endregion Properties

		#region Methods

		public virtual Insert Columns(params string[] columns) => Columns((IEnumerable<string>)columns);
		public virtual Insert Columns(IEnumerable<string> columns)
		{
			Validator.ThrowIfArgumentIsNullOrContainsNullOrEmptyElements(columns, nameof(columns));
			
			_sourceColumns.AddRange(columns.Select(c => new SourceColumn(c)));

			return this;
		}

		public virtual Insert Columns(params IColumn[] columns) => Columns((IEnumerable<IColumn>)columns);
		public virtual Insert Columns(IEnumerable<IColumn> columns)
		{
			Validator.ThrowIfArgumentIsNullOrContainsNullElements(columns, nameof(columns));
			
			_sourceColumns.AddRange(columns);

			return this;
		}

		public virtual Insert Columns(Action<ColumnBuilder> buildColumnAction)
		{
			Validator.ThrowIfArgumentIsNull(buildColumnAction, nameof(buildColumnAction));

			ColumnBuilder builder = new ColumnBuilder();
			buildColumnAction(builder);

			_sourceColumns.AddRange(builder.Build());

			return this;
		}

		public virtual Insert Values(params IExpression[] values) => Values((IEnumerable<IExpression>)values);
		public virtual Insert Values(IEnumerable<IExpression> values)
		{
			Validator.ThrowIfArgumentIsNullOrContainsNullElements(values, nameof(values));

			_values.AddRange(values);

			return this;
		}

		public virtual Insert Values(Action<ExpressionBuilder> buildValuesAction)
		{
			Validator.ThrowIfArgumentIsNull(buildValuesAction, nameof(buildValuesAction));

			ExpressionBuilder builder = new ExpressionBuilder();
			buildValuesAction(builder);

			_values.AddRange(builder.Build());

			return this;
		}

		public virtual Insert Returning(params string[] columns) => Returning((IEnumerable<string>)columns);
		public virtual Insert Returning(IEnumerable<string> columns)
		{
			Validator.ThrowIfArgumentIsNullOrContainsNullOrEmptyElements(columns, nameof(columns));

			_returningColumns.AddRange(columns.Select(c => new SourceColumn(c)));

			return this;
		}

		public virtual Insert Returning(params IColumn[] columns) => Returning((IEnumerable<IColumn>)columns);
		public virtual Insert Returning(IEnumerable<IColumn> columns)
		{
			Validator.ThrowIfArgumentIsNullOrContainsNullElements(columns, nameof(columns));

			_returningColumns.AddRange(columns);

			return this;
		}

		public virtual Insert Returning(Action<ColumnBuilder> buildColumnAction)
		{
			Validator.ThrowIfArgumentIsNull(buildColumnAction, nameof(buildColumnAction));

			ColumnBuilder builder = new ColumnBuilder();
			buildColumnAction(builder);

			_returningColumns.AddRange(builder.Build());

			return this;
		}

		public string RenderQuery(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderQuery(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public virtual void RenderQuery(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderQuery(this, stringBuilder);

		#endregion Methods
	}
}
