using System;
using System.Collections.Generic;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class SimpleCaseBuilder
	{
		public static readonly ExpressionFactory Factory = ExpressionFactory.Instance;

		private readonly IExpression _expression;
		private readonly List<Tuple<IExpression, IExpression>> _whenThens = new List<Tuple<IExpression, IExpression>>();
		private IExpression? _else;

		public SimpleCaseBuilder(string column)
		{
			Guard.ThrowIfNullOrEmpty(column, nameof(column));

			_expression = new SourceColumn(column);
		}

		public SimpleCaseBuilder(string column, string? table)
		{
			Guard.ThrowIfNullOrEmpty(column, nameof(column));

			_expression = new SourceColumn(column, string.IsNullOrEmpty(table) ? null : new Table(table));
		}

		public SimpleCaseBuilder(string column, ISource? source)
		{
			Guard.ThrowIfNullOrEmpty(column, nameof(column));

			_expression = new SourceColumn(column, source);
		}

		public SimpleCaseBuilder(IExpression expression)
		{
			_expression = Guard.ThrowIfNull(expression, nameof(expression));
		}

		public SimpleCaseBuilder WhenThen(IExpression expression, string column) => WhenThen(expression, Factory.Column(column));
		public SimpleCaseBuilder WhenThen(IExpression expression, string column, string table) => WhenThen(expression, Factory.Column(column, alias: null, table));
		public SimpleCaseBuilder WhenThen(IExpression expression, string column, ISource source) => WhenThen(expression, Factory.Column(column, source));
		public SimpleCaseBuilder WhenThen(IExpression expression, Func<ExpressionFactory, IExpression> function) => WhenThen(expression, Factory.Expression(function));
		public SimpleCaseBuilder WhenThen(IExpression condition, IExpression expression) => WhenThen(Tuple.Create(condition, expression));

		public SimpleCaseBuilder WhenThen(string column1, string column2) => WhenThen(column1, Factory.Column(column2));
		public SimpleCaseBuilder WhenThen(string column1, string column2, ISource source2) => WhenThen(column1, Factory.Column(column2, source2));
		public SimpleCaseBuilder WhenThen(string column1, Func<ExpressionFactory, IExpression> function) => WhenThen(column1, Factory.Expression(function));
		public SimpleCaseBuilder WhenThen(string column1, IExpression expression) => WhenThen(Factory.Column(column1), expression);

		public SimpleCaseBuilder WhenThen(string column1, string table1, string column2) => WhenThen(column1, table1, Factory.Column(column2));
		public SimpleCaseBuilder WhenThen(string column1, string table1, string column2, string table2) => WhenThen(column1, table1, Factory.Column(column2, new Table(table2)));
		public SimpleCaseBuilder WhenThen(string column1, string table1, string column2, ISource source2) => WhenThen(column1, table1, Factory.Column(column2, source2));
		public SimpleCaseBuilder WhenThen(string column1, string table1, Func<ExpressionFactory, IExpression> function) => WhenThen(column1, table1, Factory.Expression(function));
		public SimpleCaseBuilder WhenThen(string column1, string table1, IExpression expression) => WhenThen(Factory.Column(column1, alias: null, table1), expression);

		public SimpleCaseBuilder WhenThen(string column1, ISource source1, string column2) => WhenThen(Factory.Column(column1, source1), Factory.Column(column2));
		public SimpleCaseBuilder WhenThen(string column1, ISource source1, string column2, string table2) => WhenThen(Factory.Column(column1, source1), Factory.Column(column2, alias: null, table2));
		public SimpleCaseBuilder WhenThen(string column1, ISource source1, string column2, ISource source2) => WhenThen(Factory.Column(column1, source1), Factory.Column(column2, source2));
		public SimpleCaseBuilder WhenThen(string column1, ISource source1, Func<ExpressionFactory, IExpression> function) => WhenThen(Factory.Column(column1, source1), Factory.Expression(function));
		public SimpleCaseBuilder WhenThen(string column1, ISource source1, IExpression expression) => WhenThen(Factory.Column(column1, source1), expression);

		public SimpleCaseBuilder WhenThen(Tuple<IExpression, IExpression> whenThen)
		{
			_whenThens.Add(whenThen);

			return this;
		}

		public void Else(string column) => _else = Factory.Column(column);
		public void Else(string column, string table) => _else = Factory.Column(column, alias: null, table);
		public void Else(string column, ISource source) => _else = Factory.Column(column, source);
		public void Else(Func<ExpressionFactory, IExpression> function) => _else = Factory.Expression(function);
		public void Else(IExpression expression) => _else = expression;

		public SimpleCaseExpression Build()
		{
			Guard.ThrowIfEmpty(_whenThens, nameof(_whenThens));

			SimpleCaseExpression caseExpression = new SimpleCaseExpression(_expression, _whenThens, _else);

			return caseExpression;
		}
	}
}
