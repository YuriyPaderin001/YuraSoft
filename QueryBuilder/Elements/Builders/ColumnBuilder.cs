using System;
using System.Collections.Generic;

using YuraSoft.QueryBuilder.Interfaces;

namespace YuraSoft.QueryBuilder
{
	public class ColumnBuilder
	{
		private readonly List<IColumn> _columns = new List<IColumn>();

		public ColumnBuilder Column(IExpression expression, string? name = null) => AddColumn(new ExpressionColumn(expression, name));
		public ColumnBuilder Column(string name) => AddColumn(new SourceColumn(name));
		public ColumnBuilder Column(string name, string alias) => AddColumn(new SourceColumn(name, alias));
		public ColumnBuilder Column(string name, string alias, string tableName) => AddColumn(new SourceColumn(name, alias, new Table(tableName)));
		public ColumnBuilder Column(string name, ISource source) => AddColumn(new SourceColumn(name, source));
		public ColumnBuilder Column(string name, string alias, ISource source) => AddColumn(new SourceColumn(name, alias, source));
		// public ColumnBuilder Case(Action<SimpleCaseBuilder> buildCaseMethod)

		public List<IColumn> Build() => _columns;

		private ColumnBuilder AddColumn(IColumn column)
		{
			_columns.Add(column);

			return this;
		}
	}
}
