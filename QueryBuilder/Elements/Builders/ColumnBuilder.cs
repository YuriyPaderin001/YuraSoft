using System;
using System.Collections.Generic;

using YuraSoft.QueryBuilder.Interfaces;

namespace YuraSoft.QueryBuilder
{
	public class ColumnBuilder
	{
		private readonly List<IColumn> _columns = new List<IColumn>();

		public ColumnBuilder Case(Action<GeneralCaseBuilder> caseBuildMethod, string? name = null)
		{
			GeneralCaseBuilder caseBuilder = new GeneralCaseBuilder();
			caseBuildMethod.Invoke(caseBuilder);

			return AddColumn(new ExpressionColumn(caseBuilder.Build(), name));
		}

		public ColumnBuilder Case(string column, Action<SimpleCaseBuilder> caseBuildMethod, string? name = null) => Case(new SourceColumn(column), caseBuildMethod, name);
		public ColumnBuilder Case(string column, string table, Action<SimpleCaseBuilder> caseBuildMethod, string? name = null) => Case(new SourceColumn(column, new Table(table)), caseBuildMethod, name);
		public ColumnBuilder Case(string column, ISource source, Action<SimpleCaseBuilder> caseBuildMethod, string? name = null) => Case(new SourceColumn(column, source), caseBuildMethod, name);

		public ColumnBuilder Case(IExpression expression, Action<SimpleCaseBuilder> caseBuildMethod, string? name = null)
		{
			SimpleCaseBuilder caseBuilder = new SimpleCaseBuilder(expression);
			caseBuildMethod.Invoke(caseBuilder);

			return AddColumn(new ExpressionColumn(caseBuilder.Build(), name));
		}

		public ColumnBuilder Column(IColumn column) => AddColumn(column);
		public ColumnBuilder Column(IExpression expression, string? name = null) => AddColumn(new ExpressionColumn(expression, name));
		public ColumnBuilder Column(string name) => AddColumn(new SourceColumn(name));
		public ColumnBuilder Column(string name, string alias) => AddColumn(new SourceColumn(name, alias));
		public ColumnBuilder Column(string name, string alias, string table) => AddColumn(new SourceColumn(name, alias, new Table(table)));
		public ColumnBuilder Column(string name, ISource source) => AddColumn(new SourceColumn(name, source));
		public ColumnBuilder Column(string name, string alias, ISource source) => AddColumn(new SourceColumn(name, alias, source));

		public ColumnBuilder Value(IValue value, string? name = null) => AddColumn(new ExpressionColumn(value, name));
		public ColumnBuilder Value(sbyte value, string? name = null) => AddColumn(new ExpressionColumn(new Int8Value(value), name));
		public ColumnBuilder Value(short value, string? name = null) => AddColumn(new ExpressionColumn(new Int16Value(value), name));
		public ColumnBuilder Value(int value, string? name = null) => AddColumn(new ExpressionColumn(new Int32Value(value), name));
		public ColumnBuilder Value(long value, string? name = null) => AddColumn(new ExpressionColumn(new Int64Value(value), name));
		public ColumnBuilder Value(float value, string? name = null) => AddColumn(new ExpressionColumn(new FloatValue(value), name));
		public ColumnBuilder Value(double value, string? name = null) => AddColumn(new ExpressionColumn(new DoubleValue(value), name));
		public ColumnBuilder Value(decimal value, string? name = null) => AddColumn(new ExpressionColumn(new DecimalValue(value), name));
		public ColumnBuilder Value(DateTime value, string? name = null) => AddColumn(new ExpressionColumn(new DateTimeValue(value), name));
		public ColumnBuilder Value(string value, string? name = null) => AddColumn(new ExpressionColumn(new StringValue(value), name));
		
		public ColumnBuilder Null(string? name = null) => AddColumn(new ExpressionColumn(new NullValue(), name));

		public List<IColumn> Build() => _columns;

		private ColumnBuilder AddColumn(IColumn column)
		{
			_columns.Add(column);

			return this;
		}
	}
}
