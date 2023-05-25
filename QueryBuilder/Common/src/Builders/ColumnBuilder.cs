using System;
using System.Collections.Generic;

namespace YuraSoft.QueryBuilder.Common
{
	public class ColumnBuilder
	{
		public readonly ExpressionFactory Factory = ExpressionFactory.Instance;

		public readonly List<IColumn> Columns = new List<IColumn>();

		#region Column methods

		public ColumnBuilder Column(IColumn column) => Add(column);

		public ColumnBuilder Column(IExpression expression, string? alias = null) => Add(Factory.Column(expression, alias));
		public ColumnBuilder Column(Func<ExpressionFactory, IExpression> expressionFunction, string? alias = null) => Add(Factory.Column(expressionFunction, alias));

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

		#region CastFunction factory methods

		public ColumnBuilder Cast(string column, string type, string? name = null) => Add(Factory.Column(Factory.Cast(column, type), name));
		public ColumnBuilder Cast(string column, string table, string type, string? name = null) => Add(Factory.Column(Factory.Cast(column, table, type), name));
		public ColumnBuilder Cast(string column, ISource source, string type, string? name = null) => Add(Factory.Column(Factory.Cast(column, source, type), name));
		public ColumnBuilder Cast(Func<ExpressionFactory, IExpression> expressionFunction, string type, string? name = null) => Add(Factory.Column(Factory.Cast(expressionFunction, type), name));
		public ColumnBuilder Cast(IExpression expression, string type, string? name = null) => Add(Factory.Column(Factory.Cast(expression, type), name));

		#endregion CastFunction factory methods

		#region Coalesce methods

		public ColumnBuilder Coalesce(string column, sbyte value, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, value), name));
		public ColumnBuilder Coalesce(string column, short value, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, value), name));
		public ColumnBuilder Coalesce(string column, int value, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, value), name));
		public ColumnBuilder Coalesce(string column, long value, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, value), name));
		public ColumnBuilder Coalesce(string column, float value, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, value), name));
		public ColumnBuilder Coalesce(string column, double value, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, value), name));
		public ColumnBuilder Coalesce(string column, DateTime value, string? format = null, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, value, format), name));
		public ColumnBuilder Coalesce(string column, string value, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, value), name));
		public ColumnBuilder Coalesce(string column, Func<ExpressionFactory, IExpression> function, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, function), name));
		public ColumnBuilder Coalesce(string column, IExpression defaultValue, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, defaultValue), name));
		public ColumnBuilder Coalesce(string column1, string column2, ISource column2Source, string? name = null) => Add(Factory.Column(Factory.Coalesce(column1, column2, column2Source), name));

		public ColumnBuilder Coalesce(string column, string table, sbyte value, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, table, value), name));
		public ColumnBuilder Coalesce(string column, string table, short value, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, table, value), name));
		public ColumnBuilder Coalesce(string column, string table, int value, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, table, value), name));
		public ColumnBuilder Coalesce(string column, string table, long value, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, table, value), name));
		public ColumnBuilder Coalesce(string column, string table, float value, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, table, value), name));
		public ColumnBuilder Coalesce(string column, string table, double value, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, table, value), name));
		public ColumnBuilder Coalesce(string column, string table, DateTime value, string? name) => Add(Factory.Column(Factory.Coalesce(column, table, value), name));
		public ColumnBuilder Coalesce(string column, string table, DateTime value, string? format, string? name) => Add(Factory.Column(Factory.Coalesce(column, table, value, format), name));
		public ColumnBuilder Coalesce(string column, string table, string value, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, table, value), name));
		public ColumnBuilder Coalesce(string column, string table, Func<ExpressionFactory, IExpression> function, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, table, function), name));
		public ColumnBuilder Coalesce(string column, string table, IExpression defaultValue, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, table, defaultValue), name));
		public ColumnBuilder Coalesce(string column1, string column1Table, string column2, ISource column2Source, string? name = null) => Add(Factory.Column(Factory.Coalesce(column1, column1Table, column2, column2Source), name));

		public ColumnBuilder Coalesce(string column, ISource source, sbyte value, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, source, value), name));
		public ColumnBuilder Coalesce(string column, ISource source, short value, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, source, value), name));
		public ColumnBuilder Coalesce(string column, ISource source, int value, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, source, value), name));
		public ColumnBuilder Coalesce(string column, ISource source, long value, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, source, value), name));
		public ColumnBuilder Coalesce(string column, ISource source, float value, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, source, value), name));
		public ColumnBuilder Coalesce(string column, ISource source, double value, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, source, value), name));
		public ColumnBuilder Coalesce(string column, ISource source, DateTime value, string? name) => Add(Factory.Column(Factory.Coalesce(column, source, value), name));
		public ColumnBuilder Coalesce(string column, ISource source, DateTime value, string? format, string? name) => Add(Factory.Column(Factory.Coalesce(column, source, value, format), name));
		public ColumnBuilder Coalesce(string column, ISource source, string value, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, source, value), name));
		public ColumnBuilder Coalesce(string column, ISource source, Func<ExpressionFactory, IExpression> function, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, source, function), name));
		public ColumnBuilder Coalesce(string column, ISource source, IExpression defaultValue, string? name = null) => Add(Factory.Column(Factory.Coalesce(column, source, defaultValue), name));
		public ColumnBuilder Coalesce(string column1, ISource column1Source, string column2, ISource column2Source, string? name = null) => Add(Factory.Column(Factory.Coalesce(column1, column1Source, column2, column2Source), name));

		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, sbyte value, string? name = null) => Add(Factory.Column(Factory.Coalesce(expressionFunction, value), name));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, short value, string? name = null) => Add(Factory.Column(Factory.Coalesce(expressionFunction, value), name));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, int value, string? name = null) => Add(Factory.Column(Factory.Coalesce(expressionFunction, value), name));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, long value, string? name = null) => Add(Factory.Column(Factory.Coalesce(expressionFunction, value), name));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, float value, string? name = null) => Add(Factory.Column(Factory.Coalesce(expressionFunction, value), name));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, double value, string? name = null) => Add(Factory.Column(Factory.Coalesce(expressionFunction, value), name));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, DateTime value, string? name) => Add(Factory.Column(Factory.Coalesce(expressionFunction, value), name));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, DateTime value, string? format, string? name) => Add(Factory.Column(Factory.Coalesce(expressionFunction, value, format), name));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, string value, string? name = null) => Add(Factory.Column(Factory.Coalesce(expressionFunction, value), name));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, Func<ExpressionFactory, IExpression> function, string? name = null) => Add(Factory.Column(Factory.Coalesce(expressionFunction, function), name));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, IExpression defaultValue, string? name = null) => Add(Factory.Column(Factory.Coalesce(expressionFunction, defaultValue), name));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, string column2, ISource column2Source, string? name = null) => Add(Factory.Column(Factory.Coalesce(expressionFunction, column2, column2Source), name));

		public ColumnBuilder Coalesce(IExpression expression, sbyte value, string? name = null) => Add(Factory.Column(Factory.Coalesce(expression, value), name));
		public ColumnBuilder Coalesce(IExpression expression, short value, string? name = null) => Add(Factory.Column(Factory.Coalesce(expression, value), name));
		public ColumnBuilder Coalesce(IExpression expression, int value, string? name = null) => Add(Factory.Column(Factory.Coalesce(expression, value), name));
		public ColumnBuilder Coalesce(IExpression expression, long value, string? name = null) => Add(Factory.Column(Factory.Coalesce(expression, value), name));
		public ColumnBuilder Coalesce(IExpression expression, float value, string? name = null) => Add(Factory.Column(Factory.Coalesce(expression, value), name));
		public ColumnBuilder Coalesce(IExpression expression, double value, string? name = null) => Add(Factory.Column(Factory.Coalesce(expression, value), name));
		public ColumnBuilder Coalesce(IExpression expression, DateTime value, string? name) => Add(Factory.Column(Factory.Coalesce(expression, value), name));
		public ColumnBuilder Coalesce(IExpression expression, DateTime value, string? format, string? name) => Add(Factory.Column(Factory.Coalesce(expression, value, format), name));
		public ColumnBuilder Coalesce(IExpression expression, string value, string? name = null) => Add(Factory.Column(Factory.Coalesce(expression, value), name));
		public ColumnBuilder Coalesce(IExpression expression, Func<ExpressionFactory, IExpression> function, string? name = null) => Add(Factory.Column(Factory.Coalesce(expression, function), name));
		public ColumnBuilder Coalesce(IExpression expression, IExpression defaultValue, string? name = null) => Add(Factory.Column(Factory.Coalesce(expression, defaultValue), name));
		public ColumnBuilder Coalesce(IExpression expression, string column2, ISource column2Source, string? name = null) => Add(Factory.Column(Factory.Coalesce(expression, column2, column2Source), name));

		#endregion Coalesce methods

		#region Concat methods

		public ColumnBuilder Concat(params IExpression[] expressions) => Add(Factory.Column(Factory.Concat(expressions)));
		public ColumnBuilder Concat(string? name = null, params IExpression[] expressions) => Add(Factory.Column(Factory.Concat(expressions), name));
		public ColumnBuilder Concat(Action<ExpressionBuilder> action, string? name = null) => Add(Factory.Column(Factory.Concat(action), name));
		public ColumnBuilder Concat(IEnumerable<IExpression> expressions, string? name = null) => Add(Factory.Column(Factory.Concat(expressions), name));

		#endregion Concat methods

		#region Count methods

		public ColumnBuilder Count(string column, string? name = null) => Add(Factory.Column(Factory.Count(column), name));
		public ColumnBuilder Count(string column, string table, string? name = null) => Add(Factory.Column(Factory.Count(column, table), name));
		public ColumnBuilder Count(string column, ISource source, string? name = null) => Add(Factory.Column(Factory.Count(column, source), name));
		public ColumnBuilder Count(Func<ExpressionFactory, IExpression> expressionFunction, string? name = null) => Add(Factory.Column(Factory.Count(expressionFunction), name));
		public ColumnBuilder Count(IExpression expression, string? name = null) => Add(Factory.Column(Factory.Count(expression), name));

		#endregion Count methods

		#region Function methods

		public ColumnBuilder Function(string functionName, string? name = null) => Add(Factory.Column(Factory.Function(functionName), name));
		public ColumnBuilder Function(string functionName, params IExpression[] parameters) => Add(Factory.Column(Factory.Function(functionName, parameters)));
		public ColumnBuilder Function(string functionName, string? name = null, params IExpression[] parameters) => Add(Factory.Column(Factory.Function(functionName, parameters), name));
		public ColumnBuilder Function(string functionName, IEnumerable<IExpression>? parameters, string? name = null) => Add(Factory.Column(Factory.Function(functionName, parameters), name));
		public ColumnBuilder Function(string functionName, Action<ExpressionBuilder> action, string? name = null) => Add(Factory.Column(Factory.Function(functionName, action), name));

		#endregion Function methods

		#region Max methods

		public ColumnBuilder Max(string column, string? name = null) => Add(Factory.Column(Factory.Max(column), name));
		public ColumnBuilder Max(string column, string table, string? name = null) => Add(Factory.Column(Factory.Max(column, table), name));
		public ColumnBuilder Max(string column, ISource source, string? name = null) => Add(Factory.Column(Factory.Max(column, source), name));
		public ColumnBuilder Max(Func<ExpressionFactory, IExpression> expressionFunction, string? name = null) => Add(Factory.Column(Factory.Max(expressionFunction), name));
		public ColumnBuilder Max(IExpression expression, string? name = null) => Add(Factory.Column(Factory.Max(expression), name));

		#endregion Max methods

		#region Min methods

		public ColumnBuilder Min(string column, string? name = null) => Add(Factory.Column(Factory.Min(column), name));
		public ColumnBuilder Min(string column, string table, string? name = null) => Add(Factory.Column(Factory.Min(column, table), name));
		public ColumnBuilder Min(string column, ISource source, string? name = null) => Add(Factory.Column(Factory.Min(column, source), name));
		public ColumnBuilder Min(Func<ExpressionFactory, IExpression> expressionFunction, string? name = null) => Add(Factory.Column(Factory.Min(expressionFunction), name));
		public ColumnBuilder Min(IExpression expression, string? name = null) => Add(Factory.Column(Factory.Min(expression), name));

		#endregion Min methods

		#region NowFunction factory methods

		public ColumnBuilder Now(string? name = null) => Add(Factory.Column(Factory.Now(), name));

		#endregion NowFunction factory methods

		#region Sum methods

		public ColumnBuilder Sum(string column, string? name = null) => Add(Factory.Column(Factory.Sum(column), name));
		public ColumnBuilder Sum(string column, string table, string? name = null) => Add(Factory.Column(Factory.Sum(column, table), name));
		public ColumnBuilder Sum(string column, ISource source, string? name = null) => Add(Factory.Column(Factory.Sum(column, source), name));
		public ColumnBuilder Sum(Func<ExpressionFactory, IExpression> expressionFunction, string? name = null) => Add(Factory.Column(Factory.Sum(expressionFunction), name));
		public ColumnBuilder Sum(IExpression expression, string? name = null) => Add(Factory.Column(Factory.Sum(expression), name));

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
