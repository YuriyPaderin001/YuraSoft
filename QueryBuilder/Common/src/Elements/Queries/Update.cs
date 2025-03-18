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

		public virtual Update SetNull(string columnName) => Set(columnName, _factory.Null());

		public virtual Update Set(string columnName, sbyte value) => Set(columnName, _factory.Int8(value));
		public virtual Update Set(string columnName, short value) => Set(columnName, _factory.Int16(value));
		public virtual Update Set(string columnName, int value) => Set(columnName, _factory.Int32(value));
		public virtual Update Set(string columnName, long value) => Set(columnName, _factory.Int64(value));
		public virtual Update Set(string columnName, float value) => Set(columnName, _factory.Float(value));
		public virtual Update Set(string columnName, double value) => Set(columnName, _factory.Double(value));
		public virtual Update Set(string columnName, decimal value) => Set(columnName, _factory.Decimal(value));
		public virtual Update Set(string columnName, DateTime value, string? format = null) => Set(columnName, _factory.DateTime(value, format));

		public virtual Update Set(string columnName, sbyte? value) => Set(columnName, _factory.Int8(value));
		public virtual Update Set(string columnName, short? value) => Set(columnName, _factory.Int16(value));
		public virtual Update Set(string columnName, int? value) => Set(columnName, _factory.Int32(value));
		public virtual Update Set(string columnName, long? value) => Set(columnName, _factory.Int64(value));
		public virtual Update Set(string columnName, float? value) => Set(columnName, _factory.Float(value));
		public virtual Update Set(string columnName, double? value) => Set(columnName, _factory.Double(value));
		public virtual Update Set(string columnName, decimal? value) => Set(columnName, _factory.Decimal(value));
		public virtual Update Set(string columnName, DateTime? value, string? format = null) => Set(columnName, _factory.DateTime(value, format));
		public virtual Update Set(string columnName, string? value) => Set(columnName, _factory.String(value));
		
		public virtual Update Set(string columnName, Func<ExpressionFactory, IExpression> expressionFunction) => Set(columnName, _factory.Expression(expressionFunction));
		public virtual Update Set(string columnName, IExpression value) => Set(_factory.Column(columnName), value);

		public virtual Update SetNull(string columnName, string? tableName) => Set(columnName, tableName, _factory.Null());

		public virtual Update Set(string columnName, string? tableName, sbyte value) => Set(columnName, tableName, _factory.Int8(value));
		public virtual Update Set(string columnName, string? tableName, short value) => Set(columnName, tableName, _factory.Int16(value));
		public virtual Update Set(string columnName, string? tableName, int value) => Set(columnName, tableName, _factory.Int32(value));
		public virtual Update Set(string columnName, string? tableName, long value) => Set(columnName, tableName, _factory.Int64(value));
		public virtual Update Set(string columnName, string? tableName, float value) => Set(columnName, tableName, _factory.Float(value));
		public virtual Update Set(string columnName, string? tableName, double value) => Set(columnName, tableName, _factory.Double(value));
		public virtual Update Set(string columnName, string? tableName, decimal value) => Set(columnName, tableName, _factory.Decimal(value));
		public virtual Update Set(string columnName, string? tableName, DateTime value, string? format = null) => Set(columnName, tableName, _factory.DateTime(value, format));

		public virtual Update Set(string columnName, string? tableName, sbyte? value) => Set(columnName, tableName, _factory.Int8(value));
		public virtual Update Set(string columnName, string? tableName, short? value) => Set(columnName, tableName, _factory.Int16(value));
		public virtual Update Set(string columnName, string? tableName, int? value) => Set(columnName, tableName, _factory.Int32(value));
		public virtual Update Set(string columnName, string? tableName, long? value) => Set(columnName, tableName, _factory.Int64(value));
		public virtual Update Set(string columnName, string? tableName, float? value) => Set(columnName, tableName, _factory.Float(value));
		public virtual Update Set(string columnName, string? tableName, double? value) => Set(columnName, tableName, _factory.Double(value));
		public virtual Update Set(string columnName, string? tableName, decimal? value) => Set(columnName, tableName, _factory.Decimal(value));
		public virtual Update Set(string columnName, string? tableName, DateTime? value, string? format = null) => Set(columnName, tableName, _factory.DateTime(value, format));
		public virtual Update Set(string columnName, string? tableName, string? value) => Set(columnName, tableName, _factory.String(value));

		public virtual Update Set(string columnName, string? tableName, Func<ExpressionFactory, IExpression> expressionFunction) => Set(columnName, tableName, _factory.Expression(expressionFunction));
		public virtual Update Set(string columnName, string? tableName, IExpression value) => Set(_factory.Column(columnName, alias: null, tableName), value);

		public virtual Update SetNull(string columnName, ISource? columnSource) => Set(new SourceColumn(columnName, columnSource), new NullValue());

		public virtual Update Set(string columnName, ISource? columnSource, sbyte value) => Set(columnName, columnSource, _factory.Int8(value));
		public virtual Update Set(string columnName, ISource? columnSource, short value) => Set(columnName, columnSource, _factory.Int16(value));
		public virtual Update Set(string columnName, ISource? columnSource, int value) => Set(columnName, columnSource, _factory.Int32(value));
		public virtual Update Set(string columnName, ISource? columnSource, long value) => Set(columnName, columnSource, _factory.Int64(value));
		public virtual Update Set(string columnName, ISource? columnSource, float value) => Set(columnName, columnSource, _factory.Float(value));
		public virtual Update Set(string columnName, ISource? columnSource, double value) => Set(columnName, columnSource, _factory.Double(value));
		public virtual Update Set(string columnName, ISource? columnSource, decimal value) => Set(columnName, columnSource, _factory.Decimal(value));
		public virtual Update Set(string columnName, ISource? columnSource, DateTime value, string? format = null) => Set(columnName, columnSource, _factory.DateTime(value, format));

		public virtual Update Set(string columnName, ISource? columnSource, sbyte? value) => Set(columnName, columnSource, _factory.Int8(value));
		public virtual Update Set(string columnName, ISource? columnSource, short? value) => Set(columnName, columnSource, _factory.Int16(value));
		public virtual Update Set(string columnName, ISource? columnSource, int? value) => Set(columnName, columnSource, _factory.Int32(value));
		public virtual Update Set(string columnName, ISource? columnSource, long? value) => Set(columnName, columnSource, _factory.Int64(value));
		public virtual Update Set(string columnName, ISource? columnSource, float? value) => Set(columnName, columnSource, _factory.Float(value));
		public virtual Update Set(string columnName, ISource? columnSource, double? value) => Set(columnName, columnSource, _factory.Double(value));
		public virtual Update Set(string columnName, ISource? columnSource, decimal? value) => Set(columnName, columnSource, _factory.Decimal(value));
		public virtual Update Set(string columnName, ISource? columnSource, DateTime? value, string? format = null) => Set(columnName, columnSource, _factory.DateTime(value, format));
		public virtual Update Set(string columnName, ISource? columnSource, string? value) => Set(columnName, columnSource, _factory.String(value));
		
		public virtual Update Set(string columnName, ISource? columnSource, Func<ExpressionFactory, IExpression> expressionFunction) => Set(columnName, columnSource, _factory.Expression(expressionFunction));
		public virtual Update Set(string columnName, ISource? columnSource, IExpression value) => Set(_factory.Column(columnName, columnSource), value);

		public virtual Update SetNull(IColumn column) => Set(column, _factory.Null());

		public virtual Update Set(IColumn column, sbyte value) => Set(column, _factory.Int8(value));
		public virtual Update Set(IColumn column, short value) => Set(column, _factory.Int16(value));
		public virtual Update Set(IColumn column, int value) => Set(column, _factory.Int32(value));
		public virtual Update Set(IColumn column, long value) => Set(column, _factory.Int64(value));
		public virtual Update Set(IColumn column, float value) => Set(column, _factory.Float(value));
		public virtual Update Set(IColumn column, double value) => Set(column, _factory.Double(value));
		public virtual Update Set(IColumn column, decimal value) => Set(column, _factory.Decimal(value));
		public virtual Update Set(IColumn column, DateTime value, string? format = null) => Set(column, _factory.DateTime(value, format));

		public virtual Update Set(IColumn column, sbyte? value) => Set(column, _factory.Int8(value));
		public virtual Update Set(IColumn column, short? value) => Set(column, _factory.Int16(value));
		public virtual Update Set(IColumn column, int? value) => Set(column, _factory.Int32(value));
		public virtual Update Set(IColumn column, long? value) => Set(column, _factory.Int64(value));
		public virtual Update Set(IColumn column, float? value) => Set(column, _factory.Float(value));
		public virtual Update Set(IColumn column, double? value) => Set(column, _factory.Double(value));
		public virtual Update Set(IColumn column, decimal? value) => Set(column, _factory.Decimal(value));
		public virtual Update Set(IColumn column, DateTime? value, string? format = null) => Set(column, _factory.DateTime(value, format));
		public virtual Update Set(IColumn column, string? value) => Set(column, _factory.String(value));

		public virtual Update Set(IColumn column, Func<ExpressionFactory, IExpression> expressionFunction) =>
			Set(column, _factory.Expression(expressionFunction));

		public virtual Update Set(IColumn column, IExpression value)
		{
			Guard.ThrowIfNull(column, nameof(column));
			Guard.ThrowIfNull(value, nameof(value));

			SetCollection.Add(Tuple.Create(column, value));

			return this;
		}

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
