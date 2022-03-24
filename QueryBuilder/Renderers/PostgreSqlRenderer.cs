using System.Linq;
using System.Text;

using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Exceptions;

#nullable enable

namespace YuraSoft.QueryBuilder.Renderers
{
	public class PostgreSqlRenderer : IRenderer
	{
		public string RenderColumn(Column column)
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

		public string RenderCondition(EqualCondition condition) => RenderBinaryCondition(condition, "=");
		public string RenderCondition(NotEqualCondition condition) => RenderBinaryCondition(condition, "<>");

		public string RenderCondition(InCondition condition)
		{
			if (condition == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(condition));
			}

			StringBuilder sql = new StringBuilder();
			sql.Append(condition.Expression.RenderExpression(this));
			sql.Append(" in (");
			sql.AppendJoin(", ", condition.Values.Select(ve => ve.RenderExpression(this)));
			sql.Append(")");

			return sql.ToString();
		}

		public string RenderCondition(NotInCondition condition)
		{
			if (condition == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(condition));
			}

			StringBuilder sql = new StringBuilder();
			sql.Append(condition.Expression.RenderExpression(this));
			sql.Append(" not in (");
			sql.AppendJoin(", ", condition.Values.Select(ve => ve.RenderExpression(this)));
			sql.Append(")");

			return sql.ToString();
		}

		public string RenderCondition(IsNullCondition condition) => RenderUnaryCondition(condition, "is null");
		public string RenderCondition(IsNotNullCondition condition) => RenderUnaryCondition(condition, "is not null");
		public string RenderCondition(LessCondition condition) => RenderBinaryCondition(condition, "<");
		public string RenderCondition(LessOrEqualCondition condition) => RenderBinaryCondition(condition, "<=");
		public string RenderCondition(GreaterCondition condition) => RenderBinaryCondition(condition, ">");
		public string RenderCondition(GreaterOrEqualCondition condition) => RenderBinaryCondition(condition, ">=");

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

		public string RenderCondition(LikeCondition condition)
		{
			if (condition == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(condition));
			}

			StringBuilder sql = new StringBuilder();
			sql.Append(condition.Expression.RenderExpression(this));
			sql.Append(" ilike '");
			sql.Append(condition.Pattern);
			sql.Append("'");

			return sql.ToString();
		}

		public string RenderCondition(NotLikeCondition condition)
		{
			if (condition == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(condition));
			}

			StringBuilder sql = new StringBuilder();
			sql.Append(condition.Expression.RenderExpression(this));
			sql.Append(" not ilike '");
			sql.Append(condition.Pattern);
			sql.Append("'");

			return sql.ToString();
		}

		public string RenderCondition(AndCondition condition)
		{
			if (condition == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(condition));
			}

			StringBuilder sql = new StringBuilder();
			sql.Append("(");
			sql.AppendJoin(" and ", condition.Conditions.Select(c => c.RenderCondition(this)));
			sql.Append(")");

			return sql.ToString();
		}

		public string RenderCondition(OrCondition condition)
		{
			if (condition == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(condition));
			}

			StringBuilder sql = new StringBuilder();
			sql.Append("(");
			sql.AppendJoin(" or ", condition.Conditions.Select(c => c.RenderCondition(this)));
			sql.Append(")");

			return sql.ToString();
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

		public string RenderSource(Table table)
		{
			if (table == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(table));
			}

			StringBuilder sql = new StringBuilder();
			if (!string.IsNullOrEmpty(table.Namespace))
			{
				sql.Append(RenderIdentificator(table.Namespace));
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

		public string RenderJoin(LeftJoin join)
		{
			if (join == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(join));
			}

			string sql = $"left join {join.Source.RenderSource(this)} on {join.Condition.RenderCondition(this)}";

			return sql;
		}

		public string RenderJoin(RightJoin join)
		{
			if (join == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(join));
			}

			string sql = $"right join {join.Source.RenderSource(this)} on {join.Condition.RenderCondition(this)}";

			return sql;
		}

		public string RenderJoin(InnerJoin join)
		{
			if (join == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(join));
			}

			string sql = $"inner join {join.Source.RenderSource(this)} on {join.Condition.RenderCondition(this)}";

			return sql;
		}

		public string RenderJoin(CrossJoin join)
		{
			if (join == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(join));
			}

			string sql = $"cross join {join.Source.RenderSource(this)}";

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
			sql.AppendJoin(", ", select.SelectColumns.ConvertAll(sc => sc.RenderColumn(this)));

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

			if (select.WhereCondition != null)
			{
				sql.Append(" where ");
				sql.Append(select.WhereCondition.RenderCondition(this));
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

		public string RenderIdentificator(Column column)
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
			if (!string.IsNullOrEmpty(table.Namespace))
			{
				sql.Append(RenderIdentificator(table.Namespace));
				sql.Append('.');
			}

			sql.Append(RenderIdentificator(table.Name));

			return sql.ToString();
		}

		public string RenderIdentificator(string identificator) => $"\"{identificator}\"";

		public string RenderValue(Int8Value value)
		{
			if (value == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(value));
			}

			return value.Value.ToString();
		}

		public string RenderValue(Int16Value value)
		{
			if (value == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(value));
			}

			return value.Value.ToString();
		}

		public string RenderValue(Int32Value value)
		{
			if (value == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(value));
			}

			return value.Value.ToString();
		}

		public string RenderValue(Int64Value value)
		{
			if (value == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(value));
			}

			return value.Value.ToString();
		}

		public string RenderValue(FloatValue value)
		{
			if (value == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(value));
			}

			return value.Value.ToString();
		}

		public string RenderValue(DoubleValue value)
		{
			if (value == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(value));
			}

			return value.Value.ToString();
		}

		public string RenderValue(DecimalValue value)
		{
			if (value == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(value));
			}

			return value.Value.ToString();
		}

		public string RenderValue(DateTimeValue value)
		{
			if (value == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(value));
			}

			return value.Value.ToString(value.Format);
		}

		public string RenderValue(StringValue value)
		{
			if (value == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(value));
			}

			return $"'{value.Value}'";
		}
	}
}
