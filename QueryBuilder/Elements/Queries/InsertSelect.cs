using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public class InsertSelect : IQuery
	{
		#region Fields

		private ISource _source;
		private Select _select;
		private List<IColumn> _returningColumns = new List<IColumn>();

		#endregion Fields

		#region Constructors

		public InsertSelect(string name, string? alias, string? schema, Select select)
		{
			Validator.ThrowIfArgumentIsNullOrEmpty(name, nameof(name));
			Validator.ThrowIfArgumentIsNull(select, nameof(select));

			_source = new Table(name, alias, schema);
			_select = select;
		}

		public InsertSelect(Table table, Select select)
		{
			_source = Validator.ThrowIfArgumentIsNull(table, nameof(table));
			_select = Validator.ThrowIfArgumentIsNull(select, nameof(select));
		}

		#endregion Constructors

		#region Properties

		public ISource Source
		{
			get => _source;
			set => _source = Validator.ThrowIfArgumentIsNull(value, nameof(Source));
		}

		public Select SelectQuery
		{
			get => _select;
			set => _select = Validator.ThrowIfArgumentIsNull(value, nameof(Select));
		}

		public List<IColumn> ReturningColumnCollection
		{
			get => _returningColumns;
			set => _returningColumns = Validator.ThrowIfArgumentIsNullOrContainsNullElements(value, nameof(ReturningColumnCollection));
		}

		#endregion Properties

		#region Methods

		public virtual InsertSelect Returning(params string[] columns) => Returning((IEnumerable<string>)columns);
		public virtual InsertSelect Returning(IEnumerable<string> columns)
		{
			Validator.ThrowIfArgumentIsNullOrContainsNullOrEmptyElements(columns, nameof(columns));

			_returningColumns.AddRange(columns.Select(c => new SourceColumn(c)));

			return this;
		}

		public virtual InsertSelect Returning(params IColumn[] columns) => Returning((IEnumerable<IColumn>)columns);
		public virtual InsertSelect Returning(IEnumerable<IColumn> columns)
		{
			Validator.ThrowIfArgumentIsNullOrContainsNullElements(columns, nameof(columns));

			_returningColumns.AddRange(columns);

			return this;
		}

		public virtual InsertSelect Returning(Action<ColumnBuilder> buildColumnAction)
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
