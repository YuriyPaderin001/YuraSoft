using System;
using System.Collections.Generic;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public class SimpleCaseBuilder
	{
		private IExpression _expression;
		private List<Tuple<IExpression, IExpression>> _whenThens = new List<Tuple<IExpression, IExpression>>();
		private IExpression? _else;

		public SimpleCaseBuilder(string column)
		{
			Validator.ThrowIfArgumentIsNullOrEmpty(column, nameof(column));

			_expression = new SourceColumn(column);
		}

		public SimpleCaseBuilder(string column, string table)
		{
			Validator.ThrowIfArgumentIsNullOrEmpty(column, nameof(column));
			Validator.ThrowIfArgumentIsNullOrEmpty(table, nameof(table));

			_expression = new SourceColumn(column, new Table(table));
		}

		public SimpleCaseBuilder(string column, ISource source)
		{
			Validator.ThrowIfArgumentIsNullOrEmpty(column, nameof(column));
			Validator.ThrowIfArgumentIsNull(source, nameof(source));

			_expression = new SourceColumn(column, source);
		}

		public SimpleCaseBuilder(IExpression expression)
		{
			_expression = Validator.ThrowIfArgumentIsNull(expression, nameof(expression));
		}

		public SimpleCaseBuilder WhenThen(string firstColumn, string secondColumn) => WhenThen(new SourceColumn(firstColumn), new SourceColumn(secondColumn));
		public SimpleCaseBuilder WhenThen(string firstColumn, string firstTable, string secondColumn) => WhenThen(new SourceColumn(firstColumn, new Table(firstTable)), new SourceColumn(secondColumn));
		public SimpleCaseBuilder WhenThen(string firstColumn, ISource firstSource, string secondColumn) => WhenThen(new SourceColumn(firstColumn, firstSource), new SourceColumn(secondColumn));
		public SimpleCaseBuilder WhenThen(string firstColumn, string secondColumn, ISource secondSource) => WhenThen(new SourceColumn(firstColumn), new SourceColumn(secondColumn, secondSource));
		public SimpleCaseBuilder WhenThen(string firstColumn, string firstTable, string secondColumn, string secondTable) => WhenThen(new SourceColumn(firstColumn, new Table(firstTable)), new SourceColumn(secondColumn, new Table(secondTable)));
		public SimpleCaseBuilder WhenThen(string firstColumn, ISource firstSource, string secondColumn, string secondTable) => WhenThen(new SourceColumn(firstColumn, firstSource), new SourceColumn(secondColumn, new Table(secondTable)));
		public SimpleCaseBuilder WhenThen(string firstColumn, string firstTable, string secondColumn, ISource secondSource) => WhenThen(new SourceColumn(firstColumn, new Table(firstTable)), new SourceColumn(secondColumn, secondSource));
		public SimpleCaseBuilder WhenThen(string firstColumn, ISource firstSource, string secondColumn, ISource secondSource) => WhenThen(new SourceColumn(firstColumn, firstSource), new SourceColumn(secondColumn, secondSource));

		public SimpleCaseBuilder WhenThen(IExpression condition, IExpression expression)
		{
			_whenThens.Add(Tuple.Create(condition, expression));

			return this;
		}

		public void Else(string column) => _else = new SourceColumn(column);
		public void Else(string column, string table) => _else = new SourceColumn(column, new Table(table));
		public void Else(string column, ISource source) => _else = new SourceColumn(column, source);
		public void Else(IExpression expression) => _else = expression;

		public SimpleCaseExpression Build()
		{
			Validator.ThrowIfArgumentIsEmpty(_whenThens, nameof(_whenThens));

			SimpleCaseExpression caseExpression = new SimpleCaseExpression(_expression, _whenThens, _else);

			return caseExpression;
		}
	}
}
