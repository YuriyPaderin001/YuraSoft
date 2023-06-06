using System;
using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class Update : Query
	{
		private static readonly ExpressionFactory _factory = ExpressionFactory.Instance;

		public Update(string sourceName) : this(sourceName, sourceAlias: null, sourceSchema: null)
		{
		}

		public Update(string sourceName, string? sourceSchema) : this(sourceName, sourceAlias: null, sourceSchema)
		{
		}

		public Update(string sourceName, string? sourceAlias, string? sourceSchema)
		{
			Guard.ThrowIfNullOrEmpty(sourceName, nameof(sourceName));

			Source = new Table(sourceName, sourceAlias, sourceSchema);
		}

		public Update(Table table)
		{
			Source = Guard.ThrowIfNull(table, nameof(table));
		}

		public readonly ISource Source;
		public readonly List<Tuple<IColumn, IExpression>> SetCollection = new List<Tuple<IColumn, IExpression>>();
		public ICondition? Condition { get; protected set; }

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

		public virtual Update Set(string columnName, string tableName, sbyte value) => Set(new SourceColumn(columnName, new Table(tableName)), new Int8Value(value));
		public virtual Update Set(string columnName, string tableName, short value) => Set(new SourceColumn(columnName, new Table(tableName)), new Int16Value(value));
		public virtual Update Set(string columnName, string tableName, int value) => Set(new SourceColumn(columnName, new Table(tableName)), new Int32Value(value));
		public virtual Update Set(string columnName, string tableName, long value) => Set(new SourceColumn(columnName, new Table(tableName)), new Int64Value(value));
		public virtual Update Set(string columnName, string tableName, float value) => Set(new SourceColumn(columnName, new Table(tableName)), new FloatValue(value));
		public virtual Update Set(string columnName, string tableName, double value) => Set(new SourceColumn(columnName, new Table(tableName)), new DoubleValue(value));
		public virtual Update Set(string columnName, string tableName, decimal value) => Set(new SourceColumn(columnName, new Table(tableName)), new DecimalValue(value));
		public virtual Update Set(string columnName, string tableName, DateTime value, string? format = null) => Set(new SourceColumn(columnName, new Table(tableName)), new DateTimeValue(value, format));
		public virtual Update Set(string columnName, string tableName, string value) => Set(new SourceColumn(columnName, new Table(tableName)), new StringValue(value));
		public virtual Update Set(string columnName, string tableName, IExpression value) => Set(new SourceColumn(columnName, new Table(tableName)), value);
		public virtual Update SetNull(string columnName, string tableName) => Set(new SourceColumn(columnName, new Table(tableName)), new NullValue());

		public virtual Update Set(string columnName, ISource? columnSource, sbyte value) => Set(new SourceColumn(columnName, columnSource), new Int8Value(value));
		public virtual Update Set(string columnName, ISource? columnSource, short value) => Set(new SourceColumn(columnName, columnSource), new Int16Value(value));
		public virtual Update Set(string columnName, ISource? columnSource, int value) => Set(new SourceColumn(columnName, columnSource), new Int32Value(value));
		public virtual Update Set(string columnName, ISource? columnSource, long value) => Set(new SourceColumn(columnName, columnSource), new Int64Value(value));
		public virtual Update Set(string columnName, ISource? columnSource, float value) => Set(new SourceColumn(columnName, columnSource), new FloatValue(value));
		public virtual Update Set(string columnName, ISource? columnSource, double value) => Set(new SourceColumn(columnName, columnSource), new DoubleValue(value));
		public virtual Update Set(string columnName, ISource? columnSource, decimal value) => Set(new SourceColumn(columnName, columnSource), new DecimalValue(value));
		public virtual Update Set(string columnName, ISource? columnSource, DateTime value, string? format = null) => Set(new SourceColumn(columnName, columnSource), new DateTimeValue(value, format));
		public virtual Update Set(string columnName, ISource? columnSource, string value) => Set(new SourceColumn(columnName, columnSource), new StringValue(value));
		public virtual Update Set(string columnName, ISource? columnSource, IExpression value) => Set(new SourceColumn(columnName, columnSource), value);
		public virtual Update SetNull(string columnName, ISource? columnSource) => Set(new SourceColumn(columnName, columnSource), new NullValue());

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
			Guard.ThrowIfNull(column, nameof(column));
			Guard.ThrowIfNull(value, nameof(value));

			SetCollection.Add(Tuple.Create(column, value));

			return this;
		}
		public virtual Update SetNull(IColumn column) => Set(column, new NullValue());

		public Update Set(params Tuple<IColumn, IExpression>[] values) => Set((IEnumerable<Tuple<IColumn, IExpression>>)values);

		public virtual Update Set(IEnumerable<Tuple<IColumn, IExpression>> values)
		{
			SetCollection.AddRange(values);

			return this;
		}

		public Update Where(Action<ConditionBuilder> action) => 
			Where(_factory.Condition(action));

		public virtual Update Where(ICondition? condition)
		{
			Condition = condition;

			return this;
		}

		public override void RenderQuery(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderQuery(this, sql);
	}
}
