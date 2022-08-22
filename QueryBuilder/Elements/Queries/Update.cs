using System;
using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class Update : IQuery
	{
		private ISource _source;
		private List<Tuple<IColumn, IExpression>> _setCollection = new List<Tuple<IColumn, IExpression>>();
		private ICondition? _condition;

		public Update(string name, string? alias = null, string? schema = null)
		{
			Validator.ThrowIfArgumentIsNullOrEmpty(name, nameof(name));

			_source = new Table(name, alias, schema);
		}

		public Update(Table table)
		{
			_source = Validator.ThrowIfArgumentIsNull(table, nameof(table));
		}

		public ISource Source 
		{ 
			get => _source; 
			set => _source = Validator.ThrowIfArgumentIsNull(value, nameof(Source));
		}

		public List<Tuple<IColumn, IExpression>> SetCollection
		{
			get => _setCollection;
			set => _setCollection = Validator.ThrowIfArgumentIsNullOrEmptyOrContainsNullElements(value, nameof(SetCollection));
		}

		public ICondition? Condition
		{
			get => _condition;
			set => _condition = value;
		}

		public virtual Update Set(string columnName, sbyte value) => Set(new SourceColumn(columnName), new Int8Value(value));
		public virtual Update Set(string columnName, short value) => Set(new SourceColumn(columnName), new Int16Value(value));
		public virtual Update Set(string columnName, int value) => Set(new SourceColumn(columnName), new Int32Value(value));
		public virtual Update Set(string columnName, long value) => Set(new SourceColumn(columnName), new Int64Value(value));
		public virtual Update Set(string columnName, float value) => Set(new SourceColumn(columnName), new FloatValue(value));
		public virtual Update Set(string columnName, double value) => Set(new SourceColumn(columnName), new DoubleValue(value));
		public virtual Update Set(string columnName, decimal value) => Set(new SourceColumn(columnName), new DecimalValue(value));
		public virtual Update Set(string columnName, DateTime value, string? format = null) => Set(new SourceColumn(columnName), new DateTimeValue(value, format));
		public virtual Update Set(string columnName, string value) => Set(new SourceColumn(columnName), new StringValue(value));
		public virtual Update Set(string columnName, IExpression value) => Set(new SourceColumn(columnName), value);
		public virtual Update SetNull(string columnName) => Set(new SourceColumn(columnName), new NullValue());

		public virtual Update Set(string columnName, string columnSource, sbyte value) => Set(new SourceColumn(columnName, columnSource), new Int8Value(value));
		public virtual Update Set(string columnName, string columnSource, short value) => Set(new SourceColumn(columnName, columnSource), new Int16Value(value));
		public virtual Update Set(string columnName, string columnSource, int value) => Set(new SourceColumn(columnName, columnSource), new Int32Value(value));
		public virtual Update Set(string columnName, string columnSource, long value) => Set(new SourceColumn(columnName, columnSource), new Int64Value(value));
		public virtual Update Set(string columnName, string columnSource, float value) => Set(new SourceColumn(columnName, columnSource), new FloatValue(value));
		public virtual Update Set(string columnName, string columnSource, double value) => Set(new SourceColumn(columnName, columnSource), new DoubleValue(value));
		public virtual Update Set(string columnName, string columnSource, decimal value) => Set(new SourceColumn(columnName, columnSource), new DecimalValue(value));
		public virtual Update Set(string columnName, string columnSource, DateTime value, string? format = null) => Set(new SourceColumn(columnName, columnSource), new DateTimeValue(value, format));
		public virtual Update Set(string columnName, string columnSource, string value) => Set(new SourceColumn(columnName, columnSource), new StringValue(value));
		public virtual Update Set(string columnName, string columnSource, IExpression value) => Set(new SourceColumn(columnName, columnSource), value);
		public virtual Update SetNull(string columnName, string columnSource) => Set(new SourceColumn(columnName, columnSource), new NullValue());

		public virtual Update Set(string columnName, ISource source, sbyte value) => Set(new SourceColumn(columnName, source), new Int8Value(value));
		public virtual Update Set(string columnName, ISource source, short value) => Set(new SourceColumn(columnName, source), new Int16Value(value));
		public virtual Update Set(string columnName, ISource source, int value) => Set(new SourceColumn(columnName, source), new Int32Value(value));
		public virtual Update Set(string columnName, ISource source, long value) => Set(new SourceColumn(columnName, source), new Int64Value(value));
		public virtual Update Set(string columnName, ISource source, float value) => Set(new SourceColumn(columnName, source), new FloatValue(value));
		public virtual Update Set(string columnName, ISource source, double value) => Set(new SourceColumn(columnName, source), new DoubleValue(value));
		public virtual Update Set(string columnName, ISource source, decimal value) => Set(new SourceColumn(columnName, source), new DecimalValue(value));
		public virtual Update Set(string columnName, ISource source, DateTime value, string? format = null) => Set(new SourceColumn(columnName, source), new DateTimeValue(value, format));
		public virtual Update Set(string columnName, ISource source, string value) => Set(new SourceColumn(columnName, source), new StringValue(value));
		public virtual Update Set(string columnName, ISource source, IExpression value) => Set(new SourceColumn(columnName, source), value);
		public virtual Update SetNull(string columnName, ISource source) => Set(new SourceColumn(columnName, source), new NullValue());

		public virtual Update Set(IColumn column, sbyte value) => Set(column, new Int8Value(value));
		public virtual Update Set(IColumn column, short value) => Set(column, new Int16Value(value));
		public virtual Update Set(IColumn column, int value) => Set(column, new Int32Value(value));
		public virtual Update Set(IColumn column, long value) => Set(column, new Int64Value(value));
		public virtual Update Set(IColumn column, float value) => Set(column, new FloatValue(value));
		public virtual Update Set(IColumn column, double value) => Set(column, new DoubleValue(value));
		public virtual Update Set(IColumn column, decimal value) => Set(column, new DecimalValue(value));
		public virtual Update Set(IColumn column, DateTime value, string? format = null) => Set(column, new DateTimeValue(value, format));
		public virtual Update Set(IColumn column, string value) => Set(column, new StringValue(value));
		public virtual Update Set(IColumn column, IExpression value)
		{
			_setCollection.Add(Tuple.Create(column, value));

			return this;
		}
		public virtual Update SetNull(IColumn column) => Set(column, new NullValue());

		public Update Set(params Tuple<IColumn, IExpression>[] values) => Set((IEnumerable<Tuple<IColumn, IExpression>>)values);

		public virtual Update Set(IEnumerable<Tuple<IColumn, IExpression>> values)
		{
			_setCollection.AddRange(values);

			return this;
		}

		public virtual Update Where(ICondition? condition)
		{
			Condition = condition;

			return this;
		}

		public virtual Update Where(Action<ConditionBuilder> buildConditionMethod)
		{
			Validator.ThrowIfArgumentIsNull(buildConditionMethod, nameof(buildConditionMethod));

			ConditionBuilder builder = new ConditionBuilder();
			buildConditionMethod.Invoke(builder);

			Condition = builder.Build();

			return this;
		}

		public string RenderQuery(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderQuery(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public virtual void RenderQuery(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderQuery(this, stringBuilder);
	}
}
