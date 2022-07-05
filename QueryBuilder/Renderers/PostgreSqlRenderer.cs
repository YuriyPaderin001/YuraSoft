using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Exceptions;

#nullable enable

namespace YuraSoft.QueryBuilder.Renderers
{
	public class PostgreSqlRenderer : IRenderer
	{
		public string RenderColumn(SourceColumn column)
		{
			if (column == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(column));
			}

			StringBuilder sql = new StringBuilder();
			if (column.Source != null)
			{
				sql.Append(column.Source.RenderIdentificator(this));
				sql.Append('.');
			}

			sql.Append(RenderIdentificator(column.Name));

			if (!string.IsNullOrEmpty(column.Alias))
			{
				sql.Append(' ');
				sql.Append(RenderIdentificator(column.Alias));
			}

			return sql.ToString();
		}

		public string RenderColumn(ExpressionColumn column)
		{
			if (column == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(column));
			}

			StringBuilder sql = new StringBuilder();
			sql.Append(column.Expression.RenderExpression(this));

			if (!string.IsNullOrEmpty(column.Name))
			{
				sql.Append(' ');
				sql.Append(RenderIdentificator(column.Name));
			}

			return sql.ToString();
		}

		#region Render condition methods

		public string RenderCondition(EqualCondition condition) => RenderBinaryCondition(condition, "=");
		public string RenderCondition(NotEqualCondition condition) => RenderBinaryCondition(condition, "<>");
		public string RenderCondition(LessCondition condition) => RenderBinaryCondition(condition, "<");
		public string RenderCondition(LessOrEqualCondition condition) => RenderBinaryCondition(condition, "<=");
		public string RenderCondition(GreaterCondition condition) => RenderBinaryCondition(condition, ">");
		public string RenderCondition(GreaterOrEqualCondition condition) => RenderBinaryCondition(condition, ">=");
		public string RenderCondition(IsNullCondition condition) => RenderUnaryCondition(condition, "is null");
		public string RenderCondition(IsNotNullCondition condition) => RenderUnaryCondition(condition, "is not null");
		public string RenderCondition(InCondition condition) => RenderCondition(condition, "in");
		public string RenderCondition(NotInCondition condition) => RenderCondition(condition, "not in");
		public string RenderCondition(LikeCondition condition) => RenderPatternCondition(condition, "ilike");
		public string RenderCondition(NotLikeCondition condition) => RenderPatternCondition(condition, "not ilike");
		public string RenderCondition(AndCondition condition) => RenderLogicalCondition(condition, "and");
		public string RenderCondition(OrCondition condition) => RenderLogicalCondition(condition, "or");
		
		public string RenderCondition(BetweenCondition condition)
		{
			if (condition == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(condition));
			}

			StringBuilder sql = new StringBuilder();
			sql.Append(condition.Expression.RenderExpression(this));
			sql.Append(" between ");
			sql.Append(condition.LessExpression.RenderExpression(this));
			sql.Append(" and ");
			sql.Append(condition.HightExpression.RenderExpression(this));

			return sql.ToString();
		}

		private string RenderCondition(CollectionCondition condition, string conditionType)
		{
			if (condition == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(condition));
			}

			StringBuilder sql = new StringBuilder();
			sql.Append(condition.Expression.RenderExpression(this));
			sql.Append(' ');
			sql.Append(conditionType);
			sql.Append(" (");
			sql.AppendJoin(", ", condition.Values.Select(ve => ve.RenderExpression(this)));
			sql.Append(')');

			return sql.ToString();
		}

		private string RenderLogicalCondition(LogicalCondition condition, string conditionType)
		{
			if (condition == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(condition));
			}

			string conditionOperator = $" {conditionType} ";

			StringBuilder sql = new StringBuilder();
			sql.Append("(");
			sql.AppendJoin(conditionOperator, condition.Conditions.Select(c => c.RenderCondition(this)));
			sql.Append(")");

			return sql.ToString();
		}

		private string RenderPatternCondition(PatternCondition condition, string conditionType)
		{
			if (condition == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(condition));
			}

			StringBuilder sql = new StringBuilder();
			sql.Append(condition.Expression.RenderExpression(this));
			sql.Append(" ");
			sql.Append(conditionType);
			sql.Append(" '");
			sql.Append(condition.Pattern);
			sql.Append("'");

			return sql.ToString();
		}

		#endregion Render condition methods

		#region Expression render methods

		public string RenderExpression(GeneralCaseExpression expression)
		{
			if (expression == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(expression));
			}

			StringBuilder sql = new StringBuilder();
			sql.Append("case");

			foreach (Tuple<ICondition, IExpression> whenThen in expression.WhenThens)
			{
				sql.Append(" when ");
				sql.Append(whenThen.Item1.RenderCondition(this));
				sql.Append(" then ");
				sql.Append(whenThen.Item2.RenderExpression(this));
			}

			if (expression.Else != null)
			{
				sql.Append(" ");
				sql.Append(expression.Else.RenderExpression(this));
			}

			return sql.ToString();
		}

		public string RenderExpression(SimpleCaseExpression expression)
		{
			if (expression == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(expression));
			}

			StringBuilder sql = new StringBuilder();
			sql.Append("case ");
			sql.Append(expression.RenderExpression(this));
			
			foreach (Tuple<IExpression, IExpression> whenThen in expression.WhenThens)
			{
				sql.Append(" when ");
				sql.Append(whenThen.Item1.RenderExpression(this));
				sql.Append(" then ");
				sql.Append(whenThen.Item2.RenderExpression(this));
			}

			if (expression.Else != null)
			{
				sql.Append(" ");
				sql.Append(expression.Else.RenderExpression(this));
			}

			return sql.ToString();
		}

		public string RenderExpression(MinusExpression expression) => RenderArithmeticExpression(expression, "-");
		public string RenderExpression(PlusExpression expression) => RenderArithmeticExpression(expression, "+");
		public string RenderExpression(MultiplyExpression expression) => RenderArithmeticExpression(expression, "*");
		public string RenderExpression(DivideExpression expression) => RenderArithmeticExpression(expression, "/");

		private string RenderArithmeticExpression(ArithmeticExpression expression, string operation)
		{
			string sql = string.Join($" {operation} ", expression.Expressions.Select(e =>
			{
				if (e is ArithmeticExpression)
				{
					return $"({e.RenderExpression(this)})";
				}

				return e.RenderExpression(this);
			}));

			return sql;
		}

		#endregion Expression render methods

		public string RenderFunction(Function function) => RenderFunction(function.Name, function, function.Parameters);
		public string RenderFunction(CountFunction function) => RenderColumnFunction("count", function);
		public string RenderFunction(SumFunction function) => RenderColumnFunction("sum", function);
		public string RenderFunction(MaxFunction function) => RenderColumnFunction("max", function);
		public string RenderFunction(MinFunction function) => RenderColumnFunction("min", function);
		public string RenderFunction(ConcatFunction function) => RenderFunction("concat", function, function.Values);
		public string RenderFunction(CoalesceFunction function) => RenderFunction("coalesce", function, function.Column, function.DefaultValue);

		public string RenderSource(Table table)
		{
			if (table == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(table));
			}

			StringBuilder sql = new StringBuilder();
			if (!string.IsNullOrEmpty(table.Schema))
			{
				sql.Append(RenderIdentificator(table.Schema));
				sql.Append('.');
			}

			sql.Append(RenderIdentificator(table.Name));

			if (!string.IsNullOrEmpty(table.Alias))
			{
				sql.Append(' ');
				sql.Append(RenderIdentificator(table.Alias));
			}

			return sql.ToString();
		}

		public string RenderJoin(LeftJoin join) => RenderJoin("left join", join, join.Condition);
		public string RenderJoin(RightJoin join) => RenderJoin("right join", join, join.Condition);
		public string RenderJoin(InnerJoin join) => RenderJoin("inner join", join, join.Condition);
		public string RenderJoin(CrossJoin join) => RenderJoin("cross join", join, null);

		private string RenderJoin(string joinType, Join join, ICondition? condition)
		{
			if (join == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(join));
			}

			string sql = $"{joinType} {join.Source.RenderSource(this)}";
			if (condition != null)
			{
				sql += $" on {condition.RenderCondition(this)}";
			}

			return sql;
		}

		public string RenderOrderBy(OrderBy orderBy)
		{
			if (orderBy == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(orderBy));
			}

			string sortDirection = orderBy.Direction == OrderDirection.Asc ? "asc" : "desc";
			string sql = $"{orderBy.Column.RenderIdentificator(this)} {sortDirection}";

			return sql;
		}

		public string RenderSelect(Select select)
		{
			if (select == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(select));
			}

			StringBuilder sql = new StringBuilder();
			sql.Append("select ");
			sql.AppendJoin(", ", select.Columns.ConvertAll(sc => sc.RenderColumn(this)));

			if (select.Sources.Count > 0)
			{
				sql.Append(" from ");
				sql.AppendJoin(", ", select.Sources.ConvertAll(s => s.RenderSource(this)));
			}

			if (select.Joins.Count > 0)
			{
				sql.Append(" ");
				sql.AppendJoin(" ", select.Joins.ConvertAll(s => s.RenderJoin(this)));
			}

			if (select.Filter != null)
			{
				sql.Append(" where ");
				sql.Append(select.Filter.RenderCondition(this));
			}

			if (select.GroupByColumns.Count > 0)
			{
				sql.Append(" group by ");
				sql.AppendJoin(", ", select.GroupByColumns.ConvertAll(s => s.RenderIdentificator(this)));
			}

			if (select.HavingCondition != null)
			{
				sql.Append(" having ");
				sql.Append(select.HavingCondition.RenderCondition(this));
			}

			if (select.OrderByColumns.Count > 0)
			{
				sql.Append(" order by ");
				sql.AppendJoin(", ", select.OrderByColumns.ConvertAll(s => s.RenderOrderBy(this)));
			}

			if (select.OffsetValue.HasValue)
			{
				sql.Append(" offset ");
				sql.Append(select.OffsetValue.Value);
			}

			if (select.LimitValue.HasValue)
			{
				sql.Append(" limit ");
				sql.Append(select.LimitValue.Value);
			}

			return sql.ToString();
		}

		public string RenderIdentificator(SourceColumn column)
		{
			if (column == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(column));
			}

			if (!string.IsNullOrEmpty(column.Alias))
			{
				return RenderIdentificator(column.Alias);
			}

			StringBuilder sql = new StringBuilder();
			if (column.Source != null)
			{
				sql.Append(column.Source.RenderIdentificator(this));
				sql.Append('.');
			}

			sql.Append(RenderIdentificator(column.Name));

			return sql.ToString();
		}

		public string RenderIdentificator(ExpressionColumn column)
		{
			if (column == null)
			{
				throw new ArgumentShouldNotBeNegativeException(nameof(column));
			}

			if (!string.IsNullOrEmpty(column.Name))
			{
				return RenderIdentificator(column.Name);
			}

			return column.Expression.RenderExpression(this);
		}

		public string RenderIdentificator(Table table)
		{
			if (table == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(table));
			}

			if (!string.IsNullOrEmpty(table.Alias))
			{
				return RenderIdentificator(table.Alias);
			}

			StringBuilder sql = new StringBuilder();
			if (!string.IsNullOrEmpty(table.Schema))
			{
				sql.Append(RenderIdentificator(table.Schema));
				sql.Append('.');
			}

			sql.Append(RenderIdentificator(table.Name));

			return sql.ToString();
		}

		public string RenderIdentificator(string identificator) => $"\"{identificator}\"";

		public string RenderParameter(Parameter parameter)
		{
			if (parameter == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(parameter));
			}

			return $"@{parameter.Name}";
		}

		public string RenderValue(Int8Value value) => RenderValue(value, null);
		public string RenderValue(Int16Value value) => RenderValue(value, null);
		public string RenderValue(Int32Value value) => RenderValue(value, null);
		public string RenderValue(Int64Value value) => RenderValue(value, null);
		public string RenderValue(FloatValue value) => RenderValue(value, null);
		public string RenderValue(DoubleValue value) => RenderValue(value, null);
		public string RenderValue(DecimalValue value) => RenderValue(value, null);
		public string RenderValue(DateTimeValue value) => RenderValue(value, c => c.Data.ToString(c.Format));
		public string RenderValue(StringValue value) => RenderValue(value, c => $"'{c.Data}'");

		private string RenderValue<T>(T value, Func<T, string>? converter)
		{
			if (value == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(value));
			}

			return converter == null ? value.ToString()! : converter(value);
		}

		private string RenderUnaryCondition(UnaryCondition condition, string operation)
		{
			if (condition == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(condition));
			}

			StringBuilder sql = new StringBuilder();
			sql.Append(condition.Expression.RenderExpression(this));
			sql.Append(" ");
			sql.Append(operation);

			return sql.ToString();
		}

		private string RenderBinaryCondition(BinaryCondition condition, string operation)
		{
			if (condition == null)
			{
				throw new ArgumentShouldNotBeNegativeException(nameof(condition));
			}

			if (string.IsNullOrEmpty(operation))
			{
				throw new ArgumentShouldNotBeNullOrEmptyException(nameof(operation));
			}

			StringBuilder sql = new StringBuilder();
			sql.Append(condition.LeftExpression.RenderExpression(this));
			sql.Append(" ");
			sql.Append(operation);
			sql.Append(" ");
			sql.Append(condition.RightExpression.RenderExpression(this));

			return sql.ToString();
		}

		private string RenderColumnFunction(string name, ColumnFunction function) => RenderFunction(name, function, function.Column);
		private string RenderFunction(string name, IFunction function, params IExpression[] parameters) => RenderFunction(name, function, (IEnumerable<IExpression>)parameters);

		private string RenderFunction(string name, IFunction function, IEnumerable<IExpression>? parameters)
		{
			if (function == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(function));
			}

			StringBuilder sql = new StringBuilder();
			sql.Append(name);
			sql.Append('(');
			
			if (parameters != null && parameters.Any())
			{
				sql.AppendJoin(", ", parameters.Select(p => p.RenderExpression(this)));
			}

			sql.Append(')');

			return sql.ToString();
		}
	}
}
