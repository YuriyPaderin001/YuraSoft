using System;
using System.Collections.Generic;

using YuraSoft.QueryBuilder.Interfaces;

namespace YuraSoft.QueryBuilder
{
	public class ColumnBuilder
	{
		public static ExpressionFactory Factory = ExpressionFactory.Instance;

		public readonly List<IColumn> Columns = new List<IColumn>();

		#region Column methods

		public ColumnBuilder Column(IColumn column) => Add(column);
		
		public ColumnBuilder Column(IExpression expression, string? name = null) => Add(Factory.Column(expression, name));
		public ColumnBuilder Column(Func<ExpressionFactory, IExpression> expressionFunction, string? name = null) => Add(Factory.Column(expressionFunction, name));

		public ColumnBuilder Column(string name) => Add(Factory.Column(name));
		public ColumnBuilder Column(string name, string? alias) => Add(Factory.Column(name, alias));
		public ColumnBuilder Column(string name, string? alias, string? table) => Add(Factory.Column(name, alias, table));
		public ColumnBuilder Column(string name, ISource? source) => Add(Factory.Column(name, source));
		public ColumnBuilder Column(string name, string? alias, ISource? source) => Add(Factory.Column(name, alias, source));

		#endregion Column methods

		#region Case methods

		public ColumnBuilder Case(Action<GeneralCaseBuilder> caseBuildMethod, string? name = null) => Add(Factory.Column(Factory.Case(caseBuildMethod), name));

		public ColumnBuilder Case(string column, Action<SimpleCaseBuilder> caseBuildMethod, string? name = null) => Add(Factory.Column(Factory.Case(column, caseBuildMethod), name));
		public ColumnBuilder Case(string column, string table, Action<SimpleCaseBuilder> caseBuildMethod, string? name = null) => Add(Factory.Column(Factory.Case(column, table, caseBuildMethod), name));
		public ColumnBuilder Case(string column, ISource source, Action<SimpleCaseBuilder> caseBuildMethod, string? name = null) => Add(Factory.Column(Factory.Case(column, source, caseBuildMethod), name));
		public ColumnBuilder Case(IExpression expression, Action<SimpleCaseBuilder> caseBuildMethod, string? name = null) => Add(Factory.Column(Factory.Case(expression, caseBuildMethod), name));
		public ColumnBuilder Case(Func<ExpressionBuilder, IExpression> expressionFunction, Action<SimpleCaseBuilder> caseBuildMethod) => Add(Factory.Column(Factory.Case(expressionFunction, caseBuildMethod)));

		#endregion Case methods

		#region Plus methods

		public ColumnBuilder Plus(string? name, params IExpression[] expressions) => Add(Factory.Column(Factory.Plus(expressions), name));
		public ColumnBuilder Plus(Action<ExpressionBuilder> action, string? name = null) => Add(Factory.Column(Factory.Plus(action), name));
		public ColumnBuilder Plus(IEnumerable<IExpression> expressions, string? name = null) => Add(Factory.Column(Factory.Plus(expressions), name));

		#endregion Plus methods

		#region Minus methods

		public ColumnBuilder Minus(string? name, params IExpression[] expressions) => Add(Factory.Column(Factory.Minus(expressions), name));
		public ColumnBuilder Minus(Action<ExpressionBuilder> action, string? name = null) => Add(Factory.Column(Factory.Minus(action), name));
		public ColumnBuilder Minus(IEnumerable<IExpression> expressions, string? name = null) => Add(Factory.Column(Factory.Minus(expressions), name));

		#endregion Minus methods

		#region Multiply methods

		public ColumnBuilder Multiply(string? name, params IExpression[] expressions) => Add(Factory.Column(Factory.Multiply(expressions), name));
		public ColumnBuilder Multiply(Action<ExpressionBuilder> action, string? name = null) => Add(Factory.Column(Factory.Multiply(action), name));
		public ColumnBuilder Multiply(IEnumerable<IExpression> expressions, string? name = null) => Add(Factory.Column(Factory.Multiply(expressions), name));

		#endregion Multiply methods

		#region Divide methods

		public ColumnBuilder Divide(string? name, params IExpression[] expressions) => Add(Factory.Column(Factory.Divide(expressions), name));
		public ColumnBuilder Divide(Action<ExpressionBuilder> action, string? name = null) => Add(Factory.Column(Factory.Divide(action), name));
		public ColumnBuilder Divide(IEnumerable<IExpression> expressions, string? name = null) => Add(Factory.Column(Factory.Divide(expressions), name));

		#endregion Divide methods

		#region Functions methods

		#region Coalesce methods

		public ColumnBuilder Coalesce(string column, sbyte value) => Add(Factory.Column(Factory.Coalesce(column, value)));
		public ColumnBuilder Coalesce(string column, short value) => Add(Factory.Column(Factory.Coalesce(column, value)));
		public ColumnBuilder Coalesce(string column, int value) => Add(Factory.Column(Factory.Coalesce(column, value)));
		public ColumnBuilder Coalesce(string column, long value) => Add(Factory.Column(Factory.Coalesce(column, value)));
		public ColumnBuilder Coalesce(string column, float value) => Add(Factory.Column(Factory.Coalesce(column, value)));
		public ColumnBuilder Coalesce(string column, double value) => Add(Factory.Column(Factory.Coalesce(column, value)));
		public ColumnBuilder Coalesce(string column, DateTime value, string? format = null) => Add(Factory.Column(Factory.Coalesce(column, value, format)));
		public ColumnBuilder Coalesce(string column, string value) => Add(Factory.Column(Factory.Coalesce(column, value)));
		public ColumnBuilder Coalesce(string column, Func<ExpressionFactory, IExpression> function) => Add(Factory.Column(Factory.Coalesce(column, function)));
		public ColumnBuilder Coalesce(string column, IExpression defaultValue) => Add(Factory.Column(Factory.Coalesce(column, defaultValue)));

		public ColumnBuilder Coalesce(string column, string table, sbyte value) => Add(Factory.Column(Factory.Coalesce(column, table, value)));
		public ColumnBuilder Coalesce(string column, string table, short value) => Add(Factory.Column(Factory.Coalesce(column, table, value)));
		public ColumnBuilder Coalesce(string column, string table, int value) => Add(Factory.Column(Factory.Coalesce(column, table, value)));
		public ColumnBuilder Coalesce(string column, string table, long value) => Add(Factory.Column(Factory.Coalesce(column, table, value)));
		public ColumnBuilder Coalesce(string column, string table, float value) => Add(Factory.Column(Factory.Coalesce(column, table, value)));
		public ColumnBuilder Coalesce(string column, string table, double value) => Add(Factory.Column(Factory.Coalesce(column, table, value)));
		public ColumnBuilder Coalesce(string column, string table, DateTime value, string? format = null) => Add(Factory.Column(Factory.Coalesce(column, table, value, format)));
		public ColumnBuilder Coalesce(string column, string table, string value) => Add(Factory.Column(Factory.Coalesce(column, table, value)));
		public ColumnBuilder Coalesce(string column, string table, Func<ExpressionFactory, IExpression> function) => Add(Factory.Column(Factory.Coalesce(column, table, function)));
		public ColumnBuilder Coalesce(string column, string table, IExpression defaultValue) => Add(Factory.Column(Factory.Coalesce(column, table, defaultValue)));

		public ColumnBuilder Coalesce(string column, ISource source, sbyte value) => Add(Factory.Column(Factory.Coalesce(column, source, value)));
		public ColumnBuilder Coalesce(string column, ISource source, short value) => Add(Factory.Column(Factory.Coalesce(column, source, value)));
		public ColumnBuilder Coalesce(string column, ISource source, int value) => Add(Factory.Column(Factory.Coalesce(column, source, value)));
		public ColumnBuilder Coalesce(string column, ISource source, long value) => Add(Factory.Column(Factory.Coalesce(column, source, value)));
		public ColumnBuilder Coalesce(string column, ISource source, float value) => Add(Factory.Column(Factory.Coalesce(column, source, value)));
		public ColumnBuilder Coalesce(string column, ISource source, double value) => Add(Factory.Column(Factory.Coalesce(column, source, value)));
		public ColumnBuilder Coalesce(string column, ISource source, DateTime value, string? format = null) => Add(Factory.Column(Factory.Coalesce(column, source, value, format)));
		public ColumnBuilder Coalesce(string column, ISource source, string value) => Add(Factory.Column(Factory.Coalesce(column, source, value)));
		public ColumnBuilder Coalesce(string column, ISource source, Func<ExpressionFactory, IExpression> function) => Add(Factory.Column(Factory.Coalesce(column, source, function)));
		public ColumnBuilder Coalesce(string column, ISource source, IExpression defaultValue) => Add(Factory.Column(Factory.Coalesce(column, source, defaultValue)));

		public ColumnBuilder Coalesce(Func<ExpressionFactory, IColumn> columnFunction, sbyte value) => Add(Factory.Column(Factory.Coalesce(columnFunction, value)));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IColumn> columnFunction, short value) => Add(Factory.Column(Factory.Coalesce(columnFunction, value)));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IColumn> columnFunction, int value) => Add(Factory.Column(Factory.Coalesce(columnFunction, value)));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IColumn> columnFunction, long value) => Add(Factory.Column(Factory.Coalesce(columnFunction, value)));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IColumn> columnFunction, float value) => Add(Factory.Column(Factory.Coalesce(columnFunction, value)));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IColumn> columnFunction, double value) => Add(Factory.Column(Factory.Coalesce(columnFunction, value)));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IColumn> columnFunction, DateTime value, string? format = null) => Add(Factory.Column(Factory.Coalesce(columnFunction, value, format)));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IColumn> columnFunction, string value) => Add(Factory.Column(Factory.Coalesce(columnFunction, value)));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IColumn> columnFunction, Func<ExpressionFactory, IExpression> function) => Add(Factory.Column(Factory.Coalesce(columnFunction, function)));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IColumn> columnFunction, IExpression defaultValue) => Add(Factory.Column(Factory.Coalesce(columnFunction, defaultValue)));

		public ColumnBuilder Coalesce(IColumn column, sbyte value) => Add(Factory.Column(Factory.Coalesce(column, value)));
		public ColumnBuilder Coalesce(IColumn column, short value) => Add(Factory.Column(Factory.Coalesce(column, value)));
		public ColumnBuilder Coalesce(IColumn column, int value) => Add(Factory.Column(Factory.Coalesce(column, value)));
		public ColumnBuilder Coalesce(IColumn column, long value) => Add(Factory.Column(Factory.Coalesce(column, value)));
		public ColumnBuilder Coalesce(IColumn column, float value) => Add(Factory.Column(Factory.Coalesce(column, value)));
		public ColumnBuilder Coalesce(IColumn column, double value) => Add(Factory.Column(Factory.Coalesce(column, value)));
		public ColumnBuilder Coalesce(IColumn column, DateTime value, string? format = null) => Add(Factory.Column(Factory.Coalesce(column, value, format)));
		public ColumnBuilder Coalesce(IColumn column, string value) => Add(Factory.Column(Factory.Coalesce(column, value)));
		public ColumnBuilder Coalesce(IColumn column, Func<ExpressionFactory, IExpression> function) => Add(Factory.Column(Factory.Coalesce(column, function)));
		public ColumnBuilder Coalesce(IColumn column, IExpression defaultValue) => Add(Factory.Column(Factory.Coalesce(column, defaultValue)));

		#endregion Coalesce methods

		#region Concat methods

		public ColumnBuilder Concat(params IExpression[] expressions)=> Add(Factory.Column(Factory.Concat(expressions)));
		public ColumnBuilder Concat(Action<ExpressionBuilder> action)=> Add(Factory.Column(Factory.Concat(action)));
		public ColumnBuilder Concat(IEnumerable<IExpression> expressions)=> Add(Factory.Column(Factory.Concat(expressions)));

		#endregion Concat methods

		#region Count methods

		public ColumnBuilder Count(string column) => Add(Factory.Column(Factory.Count(column)));
		public ColumnBuilder Count(string column, string table) => Add(Factory.Column(Factory.Count(column, table)));
		public ColumnBuilder Count(string column, ISource source) => Add(Factory.Column(Factory.Count(column, source)));
		public ColumnBuilder Count(Func<ExpressionFactory, IColumn> function) => Add(Factory.Column(Factory.Count(function)));
		public ColumnBuilder Count(IColumn column) => Add(Factory.Column(Factory.Count(column)));

		#endregion Count methods

		#region Function methods

		public ColumnBuilder Function(string name) => Add(Factory.Column(Factory.Function(name)));
		public ColumnBuilder Function(string name, params IExpression[] parameters) => Add(Factory.Column(Factory.Function(name, parameters)));
		public ColumnBuilder Function(string name, IEnumerable<IExpression>? parameters) => Add(Factory.Column(Factory.Function(name, parameters)));
		public ColumnBuilder Function(string name, Action<ExpressionBuilder> action) => Add(Factory.Column(Factory.Function(name, action)));

		#endregion Function methods

		#region Max methods

		public ColumnBuilder Max(string column) => Add(Factory.Column(Factory.Max(column)));
		public ColumnBuilder Max(string column, string table) => Add(Factory.Column(Factory.Max(column, table)));
		public ColumnBuilder Max(string column, ISource source) => Add(Factory.Column(Factory.Max(column, source)));
		public ColumnBuilder Max(Func<ExpressionFactory, IColumn> function) => Add(Factory.Column(Factory.Max(function)));
		public ColumnBuilder Max(IColumn column) => Add(Factory.Column(Factory.Max(column)));

		#endregion Max methods

		#region Min methods

		public ColumnBuilder Min(string column) => Add(Factory.Column(Factory.Min(column)));
		public ColumnBuilder Min(string column, string table) => Add(Factory.Column(Factory.Min(column, table)));
		public ColumnBuilder Min(string column, ISource source) => Add(Factory.Column(Factory.Min(column, source)));
		public ColumnBuilder Min(Func<ExpressionFactory, IColumn> function) => Add(Factory.Column(Factory.Min(function)));
		public ColumnBuilder Min(IColumn column) => Add(Factory.Column(Factory.Min(column)));

		#endregion Min methods

		#region Sum methods

		public ColumnBuilder Sum(string column) => Add(Factory.Column(Factory.Sum(column)));
		public ColumnBuilder Sum(string column, string table) => Add(Factory.Column(Factory.Sum(column, table)));
		public ColumnBuilder Sum(string column, ISource source) => Add(Factory.Column(Factory.Sum(column, source)));
		public ColumnBuilder Sum(Func<ExpressionFactory, IColumn> function) => Add(Factory.Column(Factory.Sum(function)));
		public ColumnBuilder Sum(IColumn column) => Add(Factory.Column(Factory.Sum(column)));

		#endregion Sum methods

		#endregion Functions methods

		#region Parameter methods

		public ColumnBuilder Parameter(string parameterName, string? name = null) => Add(Factory.Column(Factory.Parameter(parameterName), name));

		#endregion Parameter methods

		#region Value methods

		#region Int8 methods

		public ColumnBuilder Int8(sbyte value, string? name = null) => Add(Factory.Column(Factory.Int8(value), name));
		public ColumnBuilder Int8(short value, string? name = null) => Add(Factory.Column(Factory.Int8(value), name));
		public ColumnBuilder Int8(int value, string? name = null) => Add(Factory.Column(Factory.Int8(value), name));
		public ColumnBuilder Int8(long value, string? name = null) => Add(Factory.Column(Factory.Int8(value), name));
		public ColumnBuilder Int8(float value, string? name = null) => Add(Factory.Column(Factory.Int8(value), name));
		public ColumnBuilder Int8(double value, string? name = null) => Add(Factory.Column(Factory.Int8(value), name));
		public ColumnBuilder Int8(decimal value, string? name = null) => Add(Factory.Column(Factory.Int8(value), name));
		public ColumnBuilder Int8(sbyte? value, string? name = null) => Add(Factory.Column(Factory.Int8(value), name));
		public ColumnBuilder Int8(short? value, string? name = null) => Add(Factory.Column(Factory.Int8(value), name));
		public ColumnBuilder Int8(int? value, string? name = null) => Add(Factory.Column(Factory.Int8(value), name));
		public ColumnBuilder Int8(long? value, string? name = null) => Add(Factory.Column(Factory.Int8(value), name));
		public ColumnBuilder Int8(float? value, string? name = null) => Add(Factory.Column(Factory.Int8(value), name));
		public ColumnBuilder Int8(double? value, string? name = null) => Add(Factory.Column(Factory.Int8(value), name));
		public ColumnBuilder Int8(decimal? value, string? name = null) => Add(Factory.Column(Factory.Int8(value), name));

		#endregion Int8 methods

		#region Int16 methods

		public ColumnBuilder Int16(short value, string? name = null) => Add(Factory.Column(Factory.Int16(value), name));
		public ColumnBuilder Int16(int value, string? name = null) => Add(Factory.Column(Factory.Int16(value), name));
		public ColumnBuilder Int16(long value, string? name = null) => Add(Factory.Column(Factory.Int16(value), name));
		public ColumnBuilder Int16(float value, string? name = null) => Add(Factory.Column(Factory.Int16(value), name));
		public ColumnBuilder Int16(double value, string? name = null) => Add(Factory.Column(Factory.Int16(value), name));
		public ColumnBuilder Int16(decimal value, string? name = null) => Add(Factory.Column(Factory.Int16(value), name));
		public ColumnBuilder Int16(short? value, string? name = null) => Add(Factory.Column(Factory.Int16(value), name));
		public ColumnBuilder Int16(int? value, string? name = null) => Add(Factory.Column(Factory.Int16(value), name));
		public ColumnBuilder Int16(long? value, string? name = null) => Add(Factory.Column(Factory.Int16(value), name));
		public ColumnBuilder Int16(float? value, string? name = null) => Add(Factory.Column(Factory.Int16(value), name));
		public ColumnBuilder Int16(double? value, string? name = null) => Add(Factory.Column(Factory.Int16(value), name));
		public ColumnBuilder Int16(decimal? value, string? name = null) => Add(Factory.Column(Factory.Int16(value), name));

		#endregion Int16 methods

		#region Int32 methods

		public ColumnBuilder Int32(int value, string? name = null) => Add(Factory.Column(Factory.Int32(value), name));
		public ColumnBuilder Int32(long value, string? name = null) => Add(Factory.Column(Factory.Int32(value), name));
		public ColumnBuilder Int32(float value, string? name = null) => Add(Factory.Column(Factory.Int32(value), name));
		public ColumnBuilder Int32(double value, string? name = null) => Add(Factory.Column(Factory.Int32(value), name));
		public ColumnBuilder Int32(decimal value, string? name = null) => Add(Factory.Column(Factory.Int32(value), name));
		public ColumnBuilder Int32(int? value, string? name = null) => Add(Factory.Column(Factory.Int32(value), name));
		public ColumnBuilder Int32(long? value, string? name = null) => Add(Factory.Column(Factory.Int32(value), name));
		public ColumnBuilder Int32(float? value, string? name = null) => Add(Factory.Column(Factory.Int32(value), name));
		public ColumnBuilder Int32(double? value, string? name = null) => Add(Factory.Column(Factory.Int32(value), name));
		public ColumnBuilder Int32(decimal? value, string? name = null) => Add(Factory.Column(Factory.Int32(value), name));

		#endregion Int32 methods

		#region Int64 methods

		public ColumnBuilder Int64(long value, string? name = null) => Add(Factory.Column(Factory.Int64(value), name));
		public ColumnBuilder Int64(float value, string? name = null) => Add(Factory.Column(Factory.Int64(value), name));
		public ColumnBuilder Int64(double value, string? name = null) => Add(Factory.Column(Factory.Int64(value), name));
		public ColumnBuilder Int64(decimal value, string? name = null) => Add(Factory.Column(Factory.Int64(value), name));
		public ColumnBuilder Int64(long? value, string? name = null) => Add(Factory.Column(Factory.Int64(value), name));
		public ColumnBuilder Int64(float? value, string? name = null) => Add(Factory.Column(Factory.Int64(value), name));
		public ColumnBuilder Int64(double? value, string? name = null) => Add(Factory.Column(Factory.Int64(value), name));
		public ColumnBuilder Int64(decimal? value, string? name = null) => Add(Factory.Column(Factory.Int64(value), name));

		#endregion Int64 methods

		#region Float methods

		public ColumnBuilder Float(float value, string? name = null) => Add(Factory.Column(Factory.Float(value), name));
		public ColumnBuilder Float(double value, string? name = null) => Add(Factory.Column(Factory.Float(value), name));
		public ColumnBuilder Float(decimal value, string? name = null) => Add(Factory.Column(Factory.Float(value), name));
		public ColumnBuilder Float(float? value, string? name = null) => Add(Factory.Column(Factory.Float(value), name));
		public ColumnBuilder Float(double? value, string? name = null) => Add(Factory.Column(Factory.Float(value), name));
		public ColumnBuilder Float(decimal? value, string? name = null) => Add(Factory.Column(Factory.Float(value), name));

		#endregion Float methods

		#region Double methods

		public ColumnBuilder Double(double value, string? name = null) => Add(Factory.Column(Factory.Double(value), name));
		public ColumnBuilder Double(decimal value, string? name = null) => Add(Factory.Column(Factory.Double(value), name));
		public ColumnBuilder Double(double? value, string? name = null) => Add(Factory.Column(Factory.Double(value), name));
		public ColumnBuilder Double(decimal? value, string? name = null) => Add(Factory.Column(Factory.Double(value), name));

		#endregion Double methods

		#region Decimal methods

		public ColumnBuilder Decimal(decimal value, string? name = null) => Add(Factory.Column(Factory.Decimal(value), name));
		public ColumnBuilder Decimal(decimal? value, string? name = null) => Add(Factory.Column(Factory.Decimal(value), name));

		#endregion Decimal methods

		#region DateTime methods

		public ColumnBuilder DateTime(DateTime value, string? name = null) => Add(Factory.Column(Factory.DateTime(value), name));
		public ColumnBuilder DateTime(DateTime value, string? format = null, string? name = null) => Add(Factory.Column(Factory.DateTime(value, format), name));
		public ColumnBuilder DateTime(DateTime? value, string? name = null) => Add(Factory.Column(Factory.DateTime(value), name));
		public ColumnBuilder DateTime(DateTime? value, string? format = null, string? name = null) => Add(Factory.Column(Factory.DateTime(value, format), name));

		#endregion DateTime methods

		#region String methods

		public ColumnBuilder String(string? value, string? name = null) => Add(Factory.Column(Factory.String(value), name));
		public ColumnBuilder String(object? value, string? name = null) => Add(Factory.Column(Factory.String(value), name));

		#endregion String methods

		#region Null methods

		public ColumnBuilder Null(string? name = null) => Add(Factory.Column(Factory.Null(), name));

		#endregion Null methods

		#endregion Value methods

		public List<IColumn> Build() => Columns;

		private ColumnBuilder Add(IColumn column)
		{
			Columns.Add(column);

			return this;
		}
	}
}
