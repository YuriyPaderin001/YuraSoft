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

		public ColumnBuilder Case(Action<GeneralCaseBuilder> caseBuildMethod, string? alias = null) => Add(Factory.Column(Factory.Case(caseBuildMethod), alias));
		public ColumnBuilder Case(string column, Action<SimpleCaseBuilder> caseBuildMethod, string? alias = null) => Add(Factory.Column(Factory.Case(column, caseBuildMethod), alias));
		public ColumnBuilder Case(string column, string table, Action<SimpleCaseBuilder> caseBuildMethod, string? alias = null) => Add(Factory.Column(Factory.Case(column, table, caseBuildMethod), alias));
		public ColumnBuilder Case(string column, ISource source, Action<SimpleCaseBuilder> caseBuildMethod, string? alias = null) => Add(Factory.Column(Factory.Case(column, source, caseBuildMethod), alias));
		public ColumnBuilder Case(IExpression expression, Action<SimpleCaseBuilder> caseBuildMethod, string? alias = null) => Add(Factory.Column(Factory.Case(expression, caseBuildMethod), alias));
		public ColumnBuilder Case(Func<ExpressionBuilder, IExpression> expressionFunction, Action<SimpleCaseBuilder> caseBuildMethod, string? alias = null) => Add(Factory.Column(Factory.Case(expressionFunction, caseBuildMethod), alias));

		#endregion Case methods

		#region Plus methods

		public ColumnBuilder Plus(string? alias, params IExpression[] expressions) => Add(Factory.Column(Factory.Plus(expressions), alias));
		public ColumnBuilder Plus(Action<ExpressionBuilder> action, string? alias = null) => Add(Factory.Column(Factory.Plus(action), alias));
		public ColumnBuilder Plus(IEnumerable<IExpression> expressions, string? alias = null) => Add(Factory.Column(Factory.Plus(expressions), alias));

		#endregion Plus methods

		#region Minus methods

		public ColumnBuilder Minus(string? alias, params IExpression[] expressions) => Add(Factory.Column(Factory.Minus(expressions), alias));
		public ColumnBuilder Minus(Action<ExpressionBuilder> action, string? alias = null) => Add(Factory.Column(Factory.Minus(action), alias));
		public ColumnBuilder Minus(IEnumerable<IExpression> expressions, string? alias = null) => Add(Factory.Column(Factory.Minus(expressions), alias));

		#endregion Minus methods

		#region Multiply methods

		public ColumnBuilder Multiply(string? alias, params IExpression[] expressions) => Add(Factory.Column(Factory.Multiply(expressions), alias));
		public ColumnBuilder Multiply(Action<ExpressionBuilder> action, string? alias = null) => Add(Factory.Column(Factory.Multiply(action), alias));
		public ColumnBuilder Multiply(IEnumerable<IExpression> expressions, string? alias = null) => Add(Factory.Column(Factory.Multiply(expressions), alias));

		#endregion Multiply methods

		#region Divide methods

		public ColumnBuilder Divide(string? alias, params IExpression[] expressions) => Add(Factory.Column(Factory.Divide(expressions), alias));
		public ColumnBuilder Divide(Action<ExpressionBuilder> action, string? alias = null) => Add(Factory.Column(Factory.Divide(action), alias));
		public ColumnBuilder Divide(IEnumerable<IExpression> expressions, string? alias = null) => Add(Factory.Column(Factory.Divide(expressions), alias));

		#endregion Divide methods

		#region Functions methods

		#region CastFunction factory methods

		public ColumnBuilder Cast(string column, string type, string? alias = null) => Add(Factory.Column(Factory.Cast(column, type), alias));
		public ColumnBuilder Cast(string column, string table, string type, string? alias = null) => Add(Factory.Column(Factory.Cast(column, table, type), alias));
		public ColumnBuilder Cast(string column, ISource source, string type, string? alias = null) => Add(Factory.Column(Factory.Cast(column, source, type), alias));
		public ColumnBuilder Cast(Func<ExpressionFactory, IExpression> expressionFunction, string type, string? alias = null) => Add(Factory.Column(Factory.Cast(expressionFunction, type), alias));
		public ColumnBuilder Cast(IExpression expression, string type, string? alias = null) => Add(Factory.Column(Factory.Cast(expression, type), alias));

		#endregion CastFunction factory methods

		#region Coalesce methods

		public ColumnBuilder Coalesce(string column, sbyte value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, value), alias));
		public ColumnBuilder Coalesce(string column, short value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, value), alias));
		public ColumnBuilder Coalesce(string column, int value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, value), alias));
		public ColumnBuilder Coalesce(string column, long value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, value), alias));
		public ColumnBuilder Coalesce(string column, float value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, value), alias));
		public ColumnBuilder Coalesce(string column, double value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, value), alias));
		public ColumnBuilder Coalesce(string column, DateTime value, string? format = null, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, value, format), alias));
		public ColumnBuilder Coalesce(string column, string value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, value), alias));
		public ColumnBuilder Coalesce(string column, Func<ExpressionFactory, IExpression> function, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, function), alias));
		public ColumnBuilder Coalesce(string column, IExpression defaultValue, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, defaultValue), alias));
		public ColumnBuilder Coalesce(string column1, string column2, ISource column2Source, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column1, column2, column2Source), alias));

		public ColumnBuilder Coalesce(string column, string table, sbyte value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, table, value), alias));
		public ColumnBuilder Coalesce(string column, string table, short value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, table, value), alias));
		public ColumnBuilder Coalesce(string column, string table, int value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, table, value), alias));
		public ColumnBuilder Coalesce(string column, string table, long value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, table, value), alias));
		public ColumnBuilder Coalesce(string column, string table, float value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, table, value), alias));
		public ColumnBuilder Coalesce(string column, string table, double value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, table, value), alias));
		public ColumnBuilder Coalesce(string column, string table, DateTime value, string? alias) => Add(Factory.Column(Factory.Coalesce(column, table, value), alias));
		public ColumnBuilder Coalesce(string column, string table, DateTime value, string? format, string? alias) => Add(Factory.Column(Factory.Coalesce(column, table, value, format), alias));
		public ColumnBuilder Coalesce(string column, string table, string value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, table, value), alias));
		public ColumnBuilder Coalesce(string column, string table, Func<ExpressionFactory, IExpression> function, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, table, function), alias));
		public ColumnBuilder Coalesce(string column, string table, IExpression defaultValue, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, table, defaultValue), alias));
		public ColumnBuilder Coalesce(string column1, string column1Table, string column2, ISource column2Source, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column1, column1Table, column2, column2Source), alias));

		public ColumnBuilder Coalesce(string column, ISource source, sbyte value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, source, value), alias));
		public ColumnBuilder Coalesce(string column, ISource source, short value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, source, value), alias));
		public ColumnBuilder Coalesce(string column, ISource source, int value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, source, value), alias));
		public ColumnBuilder Coalesce(string column, ISource source, long value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, source, value), alias));
		public ColumnBuilder Coalesce(string column, ISource source, float value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, source, value), alias));
		public ColumnBuilder Coalesce(string column, ISource source, double value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, source, value), alias));
		public ColumnBuilder Coalesce(string column, ISource source, DateTime value, string? alias) => Add(Factory.Column(Factory.Coalesce(column, source, value), alias));
		public ColumnBuilder Coalesce(string column, ISource source, DateTime value, string? format, string? alias) => Add(Factory.Column(Factory.Coalesce(column, source, value, format), alias));
		public ColumnBuilder Coalesce(string column, ISource source, string value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, source, value), alias));
		public ColumnBuilder Coalesce(string column, ISource source, Func<ExpressionFactory, IExpression> function, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, source, function), alias));
		public ColumnBuilder Coalesce(string column, ISource source, IExpression defaultValue, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column, source, defaultValue), alias));
		public ColumnBuilder Coalesce(string column1, ISource column1Source, string column2, ISource column2Source, string? alias = null) => Add(Factory.Column(Factory.Coalesce(column1, column1Source, column2, column2Source), alias));

		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, sbyte value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(expressionFunction, value), alias));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, short value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(expressionFunction, value), alias));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, int value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(expressionFunction, value), alias));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, long value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(expressionFunction, value), alias));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, float value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(expressionFunction, value), alias));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, double value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(expressionFunction, value), alias));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, DateTime value, string? alias) => Add(Factory.Column(Factory.Coalesce(expressionFunction, value), alias));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, DateTime value, string? format, string? alias) => Add(Factory.Column(Factory.Coalesce(expressionFunction, value, format), alias));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, string value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(expressionFunction, value), alias));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, Func<ExpressionFactory, IExpression> function, string? alias = null) => Add(Factory.Column(Factory.Coalesce(expressionFunction, function), alias));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, IExpression defaultValue, string? alias = null) => Add(Factory.Column(Factory.Coalesce(expressionFunction, defaultValue), alias));
		public ColumnBuilder Coalesce(Func<ExpressionFactory, IExpression> expressionFunction, string column2, ISource column2Source, string? alias = null) => Add(Factory.Column(Factory.Coalesce(expressionFunction, column2, column2Source), alias));

		public ColumnBuilder Coalesce(IExpression expression, sbyte value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(expression, value), alias));
		public ColumnBuilder Coalesce(IExpression expression, short value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(expression, value), alias));
		public ColumnBuilder Coalesce(IExpression expression, int value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(expression, value), alias));
		public ColumnBuilder Coalesce(IExpression expression, long value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(expression, value), alias));
		public ColumnBuilder Coalesce(IExpression expression, float value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(expression, value), alias));
		public ColumnBuilder Coalesce(IExpression expression, double value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(expression, value), alias));
		public ColumnBuilder Coalesce(IExpression expression, DateTime value, string? alias) => Add(Factory.Column(Factory.Coalesce(expression, value), alias));
		public ColumnBuilder Coalesce(IExpression expression, DateTime value, string? format, string? alias) => Add(Factory.Column(Factory.Coalesce(expression, value, format), alias));
		public ColumnBuilder Coalesce(IExpression expression, string value, string? alias = null) => Add(Factory.Column(Factory.Coalesce(expression, value), alias));
		public ColumnBuilder Coalesce(IExpression expression, Func<ExpressionFactory, IExpression> function, string? alias = null) => Add(Factory.Column(Factory.Coalesce(expression, function), alias));
		public ColumnBuilder Coalesce(IExpression expression, IExpression defaultValue, string? alias = null) => Add(Factory.Column(Factory.Coalesce(expression, defaultValue), alias));
		public ColumnBuilder Coalesce(IExpression expression, string column2, ISource column2Source, string? alias = null) => Add(Factory.Column(Factory.Coalesce(expression, column2, column2Source), alias));

		#endregion Coalesce methods

		#region Concat methods

		public ColumnBuilder Concat(params IExpression[] expressions) => Add(Factory.Column(Factory.Concat(expressions)));
		public ColumnBuilder Concat(string? alias = null, params IExpression[] expressions) => Add(Factory.Column(Factory.Concat(expressions), alias));
		public ColumnBuilder Concat(Action<ExpressionBuilder> action, string? alias = null) => Add(Factory.Column(Factory.Concat(action), alias));
		public ColumnBuilder Concat(IEnumerable<IExpression> expressions, string? alias = null) => Add(Factory.Column(Factory.Concat(expressions), alias));

		#endregion Concat methods

		#region Count methods

		public ColumnBuilder Count(string column, string? alias = null) => Add(Factory.Column(Factory.Count(column), alias));
		public ColumnBuilder Count(string column, string table, string? alias = null) => Add(Factory.Column(Factory.Count(column, table), alias));
		public ColumnBuilder Count(string column, ISource source, string? alias = null) => Add(Factory.Column(Factory.Count(column, source), alias));
		public ColumnBuilder Count(Func<ExpressionFactory, IExpression> expressionFunction, string? alias = null) => Add(Factory.Column(Factory.Count(expressionFunction), alias));
		public ColumnBuilder Count(IExpression expression, string? alias = null) => Add(Factory.Column(Factory.Count(expression), alias));

		#endregion Count methods

		#region Function methods

		public ColumnBuilder Function(string functionName, string? alias = null) => Add(Factory.Column(Factory.Function(functionName), alias));
		public ColumnBuilder Function(string functionName, params IExpression[] parameters) => Add(Factory.Column(Factory.Function(functionName, parameters)));
		public ColumnBuilder Function(string functionName, string? alias = null, params IExpression[] parameters) => Add(Factory.Column(Factory.Function(functionName, parameters), alias));
		public ColumnBuilder Function(string functionName, IEnumerable<IExpression>? parameters, string? alias = null) => Add(Factory.Column(Factory.Function(functionName, parameters), alias));
		public ColumnBuilder Function(string functionName, Action<ExpressionBuilder> action, string? alias = null) => Add(Factory.Column(Factory.Function(functionName, action), alias));

		#endregion Function methods

		#region Max methods

		public ColumnBuilder Max(string column, string? alias = null) => Add(Factory.Column(Factory.Max(column), alias));
		public ColumnBuilder Max(string column, string table, string? alias = null) => Add(Factory.Column(Factory.Max(column, table), alias));
		public ColumnBuilder Max(string column, ISource source, string? alias = null) => Add(Factory.Column(Factory.Max(column, source), alias));
		public ColumnBuilder Max(Func<ExpressionFactory, IExpression> expressionFunction, string? alias = null) => Add(Factory.Column(Factory.Max(expressionFunction), alias));
		public ColumnBuilder Max(IExpression expression, string? alias = null) => Add(Factory.Column(Factory.Max(expression), alias));

		#endregion Max methods

		#region Min methods

		public ColumnBuilder Min(string column, string? alias = null) => Add(Factory.Column(Factory.Min(column), alias));
		public ColumnBuilder Min(string column, string table, string? alias = null) => Add(Factory.Column(Factory.Min(column, table), alias));
		public ColumnBuilder Min(string column, ISource source, string? alias = null) => Add(Factory.Column(Factory.Min(column, source), alias));
		public ColumnBuilder Min(Func<ExpressionFactory, IExpression> expressionFunction, string? alias = null) => Add(Factory.Column(Factory.Min(expressionFunction), alias));
		public ColumnBuilder Min(IExpression expression, string? alias = null) => Add(Factory.Column(Factory.Min(expression), alias));

		#endregion Min methods

		#region NowFunction factory methods

		public ColumnBuilder Now(string? alias = null) => Add(Factory.Column(Factory.Now(), alias));

		#endregion NowFunction factory methods

		#region Sum methods

		public ColumnBuilder Sum(string column, string? alias = null) => Add(Factory.Column(Factory.Sum(column), alias));
		public ColumnBuilder Sum(string column, string table, string? alias = null) => Add(Factory.Column(Factory.Sum(column, table), alias));
		public ColumnBuilder Sum(string column, ISource source, string? alias = null) => Add(Factory.Column(Factory.Sum(column, source), alias));
		public ColumnBuilder Sum(Func<ExpressionFactory, IExpression> expressionFunction, string? alias = null) => Add(Factory.Column(Factory.Sum(expressionFunction), alias));
		public ColumnBuilder Sum(IExpression expression, string? alias = null) => Add(Factory.Column(Factory.Sum(expression), alias));

        #endregion Sum methods

        #region Extract methods

        public ColumnBuilder Extract(string part, string column, string? alias = null) => Column(Factory.Extract(part, column), alias);
        public ColumnBuilder Extract(string part, string column, string table, string? alias = null) => Column(Factory.Extract(part, column, table), alias);
        public ColumnBuilder Extract(string part, string column, ISource source, string? alias = null) => Column(Factory.Extract(part, column, source), alias);
        public ColumnBuilder Extract(string part, Func<ExpressionFactory, IExpression> expressionFunction, string? alias = null) => Column(Factory.Extract(part, expressionFunction), alias);
        public ColumnBuilder Extract(string part, IExpression expression, string? alias = null) => Column(Factory.Extract(part, expression), alias);

        #endregion Extract methods

        #region RoundFunction methods

        public ColumnBuilder Round(string column, string? alias = null) => Column(Factory.Round(column), alias);
        public ColumnBuilder Round(string column, string table, string? alias = null) => Column(Factory.Round(column, table), alias);
        public ColumnBuilder Round(string column, ISource source, string? alias = null) => Column(Factory.Round(column, source), alias);
        public ColumnBuilder Round(Func<ExpressionFactory, IExpression> expressionFunction, string? alias = null) => Column(Factory.Round(expressionFunction), alias);
        public ColumnBuilder Round(IExpression expression, string? alias = null) => Column(Factory.Round(expression), alias);

        public ColumnBuilder Round(string column, int? precision, string? alias = null) => Column(Factory.Round(column, precision), alias);
        public ColumnBuilder Round(string column, string table, int? precision, string? alias = null) => Column(Factory.Round(column, table, precision), alias);
        public ColumnBuilder Round(string column, ISource source, int? precision, string? alias = null) => Column(Factory.Round(column, source, precision), alias);
        public ColumnBuilder Round(Func<ExpressionFactory, IExpression> expressionFunction, int? precision, string? alias = null) => Column(Factory.Round(expressionFunction, precision), alias);
        public ColumnBuilder Round(IExpression expression, int? precision, string? alias = null) => Column(Factory.Round(expression, precision), alias);

        #endregion RoundFunction methods

        #endregion Functions methods

        #region Parameter methods

        public ColumnBuilder Parameter(string parameterName, string? alias = null) => Add(Factory.Column(Factory.Parameter(parameterName), alias));

		#endregion Parameter methods

		#region Value methods

		#region Int8 methods

		public ColumnBuilder Int8(sbyte value, string? alias = null) => Add(Factory.Column(Factory.Int8(value), alias));
		public ColumnBuilder Int8(short value, string? alias = null) => Add(Factory.Column(Factory.Int8(value), alias));
		public ColumnBuilder Int8(int value, string? alias = null) => Add(Factory.Column(Factory.Int8(value), alias));
		public ColumnBuilder Int8(long value, string? alias = null) => Add(Factory.Column(Factory.Int8(value), alias));
		public ColumnBuilder Int8(float value, string? alias = null) => Add(Factory.Column(Factory.Int8(value), alias));
		public ColumnBuilder Int8(double value, string? alias = null) => Add(Factory.Column(Factory.Int8(value), alias));
		public ColumnBuilder Int8(decimal value, string? alias = null) => Add(Factory.Column(Factory.Int8(value), alias));
		public ColumnBuilder Int8(sbyte? value, string? alias = null) => Add(Factory.Column(Factory.Int8(value), alias));
		public ColumnBuilder Int8(short? value, string? alias = null) => Add(Factory.Column(Factory.Int8(value), alias));
		public ColumnBuilder Int8(int? value, string? alias = null) => Add(Factory.Column(Factory.Int8(value), alias));
		public ColumnBuilder Int8(long? value, string? alias = null) => Add(Factory.Column(Factory.Int8(value), alias));
		public ColumnBuilder Int8(float? value, string? alias = null) => Add(Factory.Column(Factory.Int8(value), alias));
		public ColumnBuilder Int8(double? value, string? alias = null) => Add(Factory.Column(Factory.Int8(value), alias));
		public ColumnBuilder Int8(decimal? value, string? alias = null) => Add(Factory.Column(Factory.Int8(value), alias));

		#endregion Int8 methods

		#region Int16 methods

		public ColumnBuilder Int16(short value, string? alias = null) => Add(Factory.Column(Factory.Int16(value), alias));
		public ColumnBuilder Int16(int value, string? alias = null) => Add(Factory.Column(Factory.Int16(value), alias));
		public ColumnBuilder Int16(long value, string? alias = null) => Add(Factory.Column(Factory.Int16(value), alias));
		public ColumnBuilder Int16(float value, string? alias = null) => Add(Factory.Column(Factory.Int16(value), alias));
		public ColumnBuilder Int16(double value, string? alias = null) => Add(Factory.Column(Factory.Int16(value), alias));
		public ColumnBuilder Int16(decimal value, string? alias = null) => Add(Factory.Column(Factory.Int16(value), alias));
		public ColumnBuilder Int16(short? value, string? alias = null) => Add(Factory.Column(Factory.Int16(value), alias));
		public ColumnBuilder Int16(int? value, string? alias = null) => Add(Factory.Column(Factory.Int16(value), alias));
		public ColumnBuilder Int16(long? value, string? alias = null) => Add(Factory.Column(Factory.Int16(value), alias));
		public ColumnBuilder Int16(float? value, string? alias = null) => Add(Factory.Column(Factory.Int16(value), alias));
		public ColumnBuilder Int16(double? value, string? alias = null) => Add(Factory.Column(Factory.Int16(value), alias));
		public ColumnBuilder Int16(decimal? value, string? alias = null) => Add(Factory.Column(Factory.Int16(value), alias));

		#endregion Int16 methods

		#region Int32 methods

		public ColumnBuilder Int32(int value, string? alias = null) => Add(Factory.Column(Factory.Int32(value), alias));
		public ColumnBuilder Int32(long value, string? alias = null) => Add(Factory.Column(Factory.Int32(value), alias));
		public ColumnBuilder Int32(float value, string? alias = null) => Add(Factory.Column(Factory.Int32(value), alias));
		public ColumnBuilder Int32(double value, string? alias = null) => Add(Factory.Column(Factory.Int32(value), alias));
		public ColumnBuilder Int32(decimal value, string? alias = null) => Add(Factory.Column(Factory.Int32(value), alias));
		public ColumnBuilder Int32(int? value, string? alias = null) => Add(Factory.Column(Factory.Int32(value), alias));
		public ColumnBuilder Int32(long? value, string? alias = null) => Add(Factory.Column(Factory.Int32(value), alias));
		public ColumnBuilder Int32(float? value, string? alias = null) => Add(Factory.Column(Factory.Int32(value), alias));
		public ColumnBuilder Int32(double? value, string? alias = null) => Add(Factory.Column(Factory.Int32(value), alias));
		public ColumnBuilder Int32(decimal? value, string? alias = null) => Add(Factory.Column(Factory.Int32(value), alias));

		#endregion Int32 methods

		#region Int64 methods

		public ColumnBuilder Int64(long value, string? alias = null) => Add(Factory.Column(Factory.Int64(value), alias));
		public ColumnBuilder Int64(float value, string? alias = null) => Add(Factory.Column(Factory.Int64(value), alias));
		public ColumnBuilder Int64(double value, string? alias = null) => Add(Factory.Column(Factory.Int64(value), alias));
		public ColumnBuilder Int64(decimal value, string? alias = null) => Add(Factory.Column(Factory.Int64(value), alias));
		public ColumnBuilder Int64(long? value, string? alias = null) => Add(Factory.Column(Factory.Int64(value), alias));
		public ColumnBuilder Int64(float? value, string? alias = null) => Add(Factory.Column(Factory.Int64(value), alias));
		public ColumnBuilder Int64(double? value, string? alias = null) => Add(Factory.Column(Factory.Int64(value), alias));
		public ColumnBuilder Int64(decimal? value, string? alias = null) => Add(Factory.Column(Factory.Int64(value), alias));

		#endregion Int64 methods

		#region Float methods

		public ColumnBuilder Float(float value, string? alias = null) => Add(Factory.Column(Factory.Float(value), alias));
		public ColumnBuilder Float(double value, string? alias = null) => Add(Factory.Column(Factory.Float(value), alias));
		public ColumnBuilder Float(decimal value, string? alias = null) => Add(Factory.Column(Factory.Float(value), alias));
		public ColumnBuilder Float(float? value, string? alias = null) => Add(Factory.Column(Factory.Float(value), alias));
		public ColumnBuilder Float(double? value, string? alias = null) => Add(Factory.Column(Factory.Float(value), alias));
		public ColumnBuilder Float(decimal? value, string? alias = null) => Add(Factory.Column(Factory.Float(value), alias));

		#endregion Float methods

		#region Double methods

		public ColumnBuilder Double(double value, string? alias = null) => Add(Factory.Column(Factory.Double(value), alias));
		public ColumnBuilder Double(decimal value, string? alias = null) => Add(Factory.Column(Factory.Double(value), alias));
		public ColumnBuilder Double(double? value, string? alias = null) => Add(Factory.Column(Factory.Double(value), alias));
		public ColumnBuilder Double(decimal? value, string? alias = null) => Add(Factory.Column(Factory.Double(value), alias));

		#endregion Double methods

		#region Decimal methods

		public ColumnBuilder Decimal(decimal value, string? alias = null) => Add(Factory.Column(Factory.Decimal(value), alias));
		public ColumnBuilder Decimal(decimal? value, string? alias = null) => Add(Factory.Column(Factory.Decimal(value), alias));

		#endregion Decimal methods

		#region DateTime methods

		public ColumnBuilder DateTime(DateTime value, string? alias = null) => Add(Factory.Column(Factory.DateTime(value), alias));
		public ColumnBuilder DateTime(DateTime value, string? format = null, string? alias = null) => Add(Factory.Column(Factory.DateTime(value, format), alias));
		public ColumnBuilder DateTime(DateTime? value, string? alias = null) => Add(Factory.Column(Factory.DateTime(value), alias));
		public ColumnBuilder DateTime(DateTime? value, string? format = null, string? alias = null) => Add(Factory.Column(Factory.DateTime(value, format), alias));

		#endregion DateTime methods

		#region String methods

		public ColumnBuilder String(string? value, string? alias = null) => Add(Factory.Column(Factory.String(value), alias));
		public ColumnBuilder String(object? value, string? alias = null) => Add(Factory.Column(Factory.String(value), alias));

		#endregion String methods

		#region Null methods

		public ColumnBuilder Null(string? alias = null) => Add(Factory.Column(Factory.Null(), alias));

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
