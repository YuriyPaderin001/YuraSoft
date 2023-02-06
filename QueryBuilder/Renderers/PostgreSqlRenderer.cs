using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder.Renderers
{
	public class PostgreSqlRenderer : IRenderer
	{
		#region Column rendering methods

		public void RenderColumn(SourceColumn column, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(column, nameof(column));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			if (column.Source != null)
			{
				column.Source.RenderIdentificator(this, query);
				query.Append('.');
			}

			if (column.Name == "*")
			{
				query.Append(column.Name);
			}
			else
			{
				RenderIdentificator(column.Name, query);
			}

			if (!string.IsNullOrEmpty(column.Alias))
			{
				query.Append(" AS ");
				RenderIdentificator(column.Alias, query);
			}
		}

		public void RenderColumn(ExpressionColumn column, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(column, nameof(column));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			column.Expression.RenderExpression(this, query);

			if (!string.IsNullOrEmpty(column.Name))
			{
				query.Append(" AS ");
				RenderIdentificator(column.Name, query);
			}
		}

		#endregion Column rendering methods

		#region Condition rendeting methods

		public void RenderCondition(EqualCondition condition, StringBuilder query) => RenderBinaryCondition(condition, "=", query);
		public void RenderCondition(NotEqualCondition condition, StringBuilder query) => RenderBinaryCondition(condition, "<>", query);
		public void RenderCondition(LessCondition condition, StringBuilder query) => RenderBinaryCondition(condition, "<", query);
		public void RenderCondition(LessOrEqualCondition condition, StringBuilder query) => RenderBinaryCondition(condition, "<=", query);
		public void RenderCondition(GreaterCondition condition, StringBuilder query) => RenderBinaryCondition(condition, ">", query);
		public void RenderCondition(GreaterOrEqualCondition condition, StringBuilder query) => RenderBinaryCondition(condition, ">=", query);
		public void RenderCondition(IsNullCondition condition, StringBuilder query) => RenderUnaryCondition(condition, "IS NULL", query);
		public void RenderCondition(IsNotNullCondition condition, StringBuilder query) => RenderUnaryCondition(condition, "IS NOT NULL", query);
		public void RenderCondition(InCondition condition, StringBuilder query) => RenderCondition(condition, "IN", query);
		public void RenderCondition(NotInCondition condition, StringBuilder query) => RenderCondition(condition, "NOT IN", query);
		public void RenderCondition(LikeCondition condition, StringBuilder query) => RenderPatternCondition(condition, "ILIKE", query);
		public void RenderCondition(NotLikeCondition condition, StringBuilder query) => RenderPatternCondition(condition, "NOT ILIKE", query);
		public void RenderCondition(AndCondition condition, StringBuilder query) => RenderLogicalCondition(condition, "AND", query);
		public void RenderCondition(OrCondition condition, StringBuilder query) => RenderLogicalCondition(condition, "OR", query);

		public void RenderCondition(BetweenCondition condition, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(condition, nameof(condition));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			condition.Expression.RenderExpression(this, query);

			query.Append(" BETWEEN ");

			condition.LessExpression.RenderExpression(this, query);

			query.Append(" AND ");

			condition.HightExpression.RenderExpression(this, query);
		}

		private void RenderCondition(CollectionCondition condition, string conditionType, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(condition, nameof(condition));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			condition.Expression.RenderExpression(this, query);
			query.Append(' ');
			query.Append(conditionType);
			query.Append(" (");

			if (condition.Values.Count > 0)
			{
				condition.Values[0].RenderExpression(this, query);
				for (int i = 1; i < condition.Values.Count; i++)
				{
					query.Append(", ");
					condition.Values[i].RenderExpression(this, query);
				}
			}

			query.Append(')');
		}

		private void RenderLogicalCondition(LogicalCondition condition, string conditionType, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(condition, nameof(condition));
			Validator.ThrowIfArgumentIsNullOrEmpty(conditionType, nameof(conditionType));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			string conditionOperator = $" {conditionType} ";

			query.Append('(');

			condition.Conditions[0].RenderCondition(this, query);
			for (int i = 1; i < condition.Conditions.Count; i++)
			{
				query.Append(conditionOperator);
				condition.Conditions[i].RenderCondition(this, query);
			}

			query.Append(')');
		}

		private void RenderPatternCondition(PatternCondition condition, string conditionType, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(condition, nameof(condition));
			Validator.ThrowIfArgumentIsNullOrEmpty(conditionType, nameof(conditionType));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			condition.Expression.RenderExpression(this, query);
			query.Append(' ');
			query.Append(conditionType);
			query.Append(" '");
			query.Append(condition.Pattern);
			query.Append('\'');
		}

		private void RenderUnaryCondition(UnaryCondition condition, string operation, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(condition, nameof(condition));
			Validator.ThrowIfArgumentIsNullOrEmpty(operation, nameof(operation));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			condition.Expression.RenderExpression(this, query);
			query.Append(' ');
			query.Append(operation);
		}

		private void RenderBinaryCondition(BinaryCondition condition, string operation, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(condition, nameof(condition));
			Validator.ThrowIfArgumentIsNullOrEmpty(operation, nameof(operation));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			condition.LeftExpression.RenderExpression(this, query);
			query.Append(' ');
			query.Append(operation);
			query.Append(' ');
			condition.RightExpression.RenderExpression(this, query);
		}

		public void RenderCondition(ExistsCondition condition, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(condition, nameof(condition));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			condition.Expression.RenderExpression(this, query);

			query.Append(" EXISTS (");

			condition.Select.RenderQuery(this, query);

			query.Append(')');
		}

		public void RenderCondition(NotExistsCondition condition, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(condition, nameof(condition));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			condition.Expression.RenderExpression(this, query);

			query.Append(" NOT EXISTS (");

			condition.Select.RenderQuery(this, query);

			query.Append(')');
		}

		#endregion Condition rendeting methods

		#region Expression rendering methods

		public void RenderExpression(GeneralCaseExpression expression, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(expression, nameof(expression));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			query.Append("CASE");

			for (int i = 0; i < expression.WhenThens.Count; i++)
			{
				query.Append(" WHEN ");

				expression.WhenThens[i].Item1.RenderCondition(this, query);

				query.Append(" THEN ");

				expression.WhenThens[i].Item2.RenderExpression(this, query);
			}

			if (expression.Else != null)
			{
				query.Append(" ELSE ");
				expression.Else.RenderExpression(this, query);
			}

			query.Append(" END");
		}

		public void RenderExpression(SimpleCaseExpression expression, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(expression, nameof(expression));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			query.Append("CASE ");
			expression.Expression.RenderExpression(this, query);

			for (int i = 0; i < expression.WhenThens.Count; i++)
			{
				query.Append(" WHEN ");
				expression.WhenThens[i].Item1.RenderExpression(this, query);
				query.Append(" THEN ");
				expression.WhenThens[i].Item2.RenderExpression(this, query);
			}

			if (expression.Else != null)
			{
				query.Append(" ELSE ");
				expression.Else.RenderExpression(this, query);
			}

			query.Append(" END");
		}

		public void RenderExpression(MinusExpression expression, StringBuilder query) => RenderArithmeticExpression(expression, "-", query);
		public void RenderExpression(PlusExpression expression, StringBuilder query) => RenderArithmeticExpression(expression, "+", query);
		public void RenderExpression(MultiplyExpression expression, StringBuilder query) => RenderArithmeticExpression(expression, "*", query);
		public void RenderExpression(DivideExpression expression, StringBuilder query) => RenderArithmeticExpression(expression, "/", query);

		public void RenderExpression(Select select, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(select, nameof(select));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			query.Append('(');

			select.RenderQuery(this, query);

			query.Append(')');
		}

		private void RenderArithmeticExpression(ArithmeticExpression expression, string operation, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(expression, nameof(expression));
			Validator.ThrowIfArgumentIsNullOrEmpty(operation, nameof(operation));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			if (expression.Expressions.Count > 0)
			{
				if (expression.Expressions[0] is ArithmeticException)
				{
					query.Append('(');

					expression.Expressions[0].RenderExpression(this, query);

					query.Append(')');
				}
				else
				{
					expression.Expressions[0].RenderExpression(this, query);
				}

				for (int i = 1; i < expression.Expressions.Count; i++)
				{
					query.Append(' ');
					query.Append(operation);
					query.Append(' ');

					if (expression.Expressions[i] is ArithmeticException)
					{
						query.Append('(');
						expression.Expressions[i].RenderExpression(this, query);
						query.Append(')');
					}
					else
					{
						expression.Expressions[i].RenderExpression(this, query);
					}
				}
			}
		}

		#endregion Expression rendering methods

		#region Function rendering methods

		public void RenderFunction(Function function, StringBuilder query) => RenderFunction(function.Name, function, function.Parameters, query);
		public void RenderFunction(CountFunction function, StringBuilder query) => RenderColumnFunction("count", function, query);
		public void RenderFunction(SumFunction function, StringBuilder query) => RenderColumnFunction("sum", function, query);
		public void RenderFunction(MaxFunction function, StringBuilder query) => RenderColumnFunction("max", function, query);
		public void RenderFunction(MinFunction function, StringBuilder query) => RenderColumnFunction("min", function, query);
		public void RenderFunction(ConcatFunction function, StringBuilder query) => RenderFunction("concat", function, function.Values, query);
		public void RenderFunction(CoalesceFunction function, StringBuilder query) => RenderFunction("coalesce", function, query, function.Column, function.DefaultValue);

		private void RenderColumnFunction(string name, ColumnFunction function, StringBuilder query) => RenderFunction(name, function, query, function.Column);
		private void RenderFunction(string name, IFunction function, StringBuilder query, params IExpression[] parameters) => RenderFunction(name, function, parameters, query);

		private void RenderFunction(string name, IFunction function, IEnumerable<IExpression>? parameters, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNullOrEmpty(name, nameof(name));
			Validator.ThrowIfArgumentIsNull(function, nameof(function));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			query.Append(name);
			query.Append('(');

			if (parameters != null && parameters.Any())
			{
				IEnumerator<IExpression> enumerator = parameters.GetEnumerator();
				enumerator.MoveNext();
				enumerator.Current.RenderExpression(this, query);
				while (enumerator.MoveNext())
				{
					query.Append(", ");
					enumerator.Current.RenderExpression(this, query);
				}
			}

			query.Append(')');
		}

		#endregion Function rendering methods

		#region Identificator rendering methods

		public void RenderIdentificator(SourceColumn column, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(column, nameof(column));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			if (!string.IsNullOrEmpty(column.Alias))
			{
				RenderIdentificator(column.Alias, query);

				return;
			}

			if (column.Source != null)
			{
				column.Source.RenderIdentificator(this, query);
				query.Append('.');
			}

      if (column.Name == "*")
      {
        query.Append(column.Name);
      }
      else
      {
        RenderIdentificator(column.Name, query);
      }
    }

		public void RenderIdentificator(ExpressionColumn column, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(column, nameof(column));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			if (!string.IsNullOrEmpty(column.Name))
			{
				RenderIdentificator(column.Name, query);

				return;
			}

			column.Expression.RenderExpression(this, query);
		}

		public void RenderIdentificator(Table table, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(table, nameof(table));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			if (!string.IsNullOrEmpty(table.Alias))
			{
				RenderIdentificator(table.Alias, query);

				return;
			}

			if (!string.IsNullOrEmpty(table.Schema))
			{
				RenderIdentificator(table.Schema, query);
				query.Append('.');
			}

			RenderIdentificator(table.Name, query);
		}

		public virtual void RenderIdentificator(Subquery subquery, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(subquery, nameof(subquery));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			RenderIdentificator(subquery.Name, query);
		}

		public void RenderIdentificator(View view, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(view, nameof(view));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			if (!string.IsNullOrEmpty(view.Alias))
			{
				RenderIdentificator(view.Alias, query);

				return;
			}

			if (!string.IsNullOrEmpty(view.Schema))
			{
				RenderIdentificator(view.Schema, query);
				query.Append('.');
			}

			RenderIdentificator(view.Name, query);
		}

		public void RenderIdentificator(string identificator, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNullOrEmpty(identificator, nameof(identificator));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			query.Append('\"');
			query.Append(identificator);
			query.Append('\"');
		}

		#endregion Identificator rendering methods

		#region Join rendering methods

		public void RenderJoin(LeftJoin join, StringBuilder query) => RenderJoin("LEFT JOIN", join, join.Condition, query);
		public void RenderJoin(RightJoin join, StringBuilder query) => RenderJoin("RIGHT JOIN", join, join.Condition, query);
		public void RenderJoin(InnerJoin join, StringBuilder query) => RenderJoin("INNER JOIN", join, join.Condition, query);
		public void RenderJoin(CrossJoin join, StringBuilder query) => RenderJoin("CROSS JOIN", join, null, query);

		private void RenderJoin(string joinType, Join join, ICondition? condition, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNullOrEmpty(joinType, nameof(joinType));
			Validator.ThrowIfArgumentIsNull(join, nameof(join));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			query.Append(joinType);
			query.Append(' ');

			join.Source.RenderSource(this, query);
			
			if (condition != null)
			{
				query.Append(" ON ");

				condition.RenderCondition(this, query);
			}
		}

		#endregion Join rendering methods

		#region Order by rendering methods

		public void RenderOrderBy(OrderBy orderBy, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(orderBy, nameof(orderBy));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			orderBy.Column.RenderIdentificator(this, query);

			query.Append(orderBy.Direction == OrderDirection.Asc ? " ASC" : " DESC");
		}

		#endregion Order by rendering methods

		#region Parameter rendering methods

		public void RenderParameter(Parameter parameter, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(parameter, nameof(parameter));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			query.Append('@');
			query.Append(parameter.Name);
		}

		#endregion Parameter rendering methods

		#region Query rendering methods

		public void RenderQuery(Select select, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(select, nameof(select));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			query.Append("SELECT ");

			if (select.ColumnCollection.Count > 0)
			{
				select.ColumnCollection[0].RenderColumn(this, query);
				for (int i = 1; i < select.ColumnCollection.Count; i++)
				{
					query.Append(", ");
					select.ColumnCollection[i].RenderColumn(this, query);
				}
			}

			if (select.SourceCollection.Count > 0)
			{
				query.Append(" FROM ");

				select.SourceCollection[0].RenderSource(this, query);
				for (int i = 1; i < select.SourceCollection.Count; i++)
				{
					query.Append(", ");

					select.SourceCollection[i].RenderSource(this, query);
				}
			}

			foreach (IJoin join in select.JoinCollection)
			{
				query.Append(' ');
				join.RenderJoin(this, query);
			}

			if (select.WhereCondition != null)
			{
				query.Append(" WHERE ");
				select.WhereCondition.RenderCondition(this, query);
			}

			if (select.GroupByCollection.Count > 0)
			{
				query.Append(" GROUP BY ");

				select.GroupByCollection[0].RenderIdentificator(this, query);
				for (int i = 1; i < select.GroupByCollection.Count; i++)
				{
					query.Append(", ");
					select.GroupByCollection[i].RenderIdentificator(this, query);
				}
			}

			if (select.HavingCondition != null)
			{
				query.Append(" HAVING ");
				select.HavingCondition.RenderCondition(this, query);
			}

			if (select.OrderByCollection.Count > 0)
			{
				query.Append(" ORDER BY ");

				select.OrderByCollection[0].RenderOrderBy(this, query);
				for (int i = 1; i < select.OrderByCollection.Count; i++)
				{
					query.Append(", ");
					select.OrderByCollection[i].RenderOrderBy(this, query);
				}
			}

			if (select.OffsetValue.HasValue)
			{
				query.Append(" OFFSET ");
				query.Append(select.OffsetValue.Value);
			}

			if (select.LimitValue.HasValue)
			{
				query.Append(" LIMIT ");
				query.Append(select.LimitValue.Value);
			}
		}

		public void RenderQuery(Insert insert, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(insert, nameof(insert));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			query.Append("INSERT INTO ");

			insert.Source.RenderSource(this, query);
			
			query.Append(" (");

			insert.ColumnCollection[0].RenderColumn(this, query);
			for (int i = 1; i < insert.ColumnCollection.Count; i++)
			{
				query.Append(", ");
				insert.ColumnCollection[i].RenderColumn(this, query);
			}

			query.Append(") VALUES ");

			int step = insert.ColumnCollection.Count;
			for (int i = 0; i < insert.ValueCollection.Count; i += step)
			{
				if (i == 0)
				{
					query.Append('(');
				}
				else
				{
					query.Append(", (");
				}

				insert.ValueCollection[i].RenderExpression(this, query);

				int limit = i + step > insert.ValueCollection.Count ? insert.ValueCollection.Count : i + step;
				for (int j = i + 1; j < limit; j++)
				{
					query.Append(", ");
					insert.ValueCollection[j].RenderExpression(this, query);
				}

				query.Append(')');
			}

			if (insert.ReturningColumnCollection.Count > 0)
			{
				query.Append(" RETURNING ");

				insert.ReturningColumnCollection[0].RenderColumn(this, query);
				for (int i = 1; i < insert.ReturningColumnCollection.Count; i++)
				{
					query.Append(", ");
					insert.ReturningColumnCollection[i].RenderColumn(this, query);
				}
			}
		}

		public void RenderQuery(InsertSelect insertSelect, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(insertSelect, nameof(insertSelect));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			query.Append("INSERT INTO ");
			
			insertSelect.Source.RenderSource(this, query);

			query.Append(' ');

			insertSelect.SelectQuery.RenderQuery(this, query);

			if (insertSelect.ReturningColumnCollection.Count > 0)
			{
				query.Append(" RETURNING ");

				insertSelect.ReturningColumnCollection[0].RenderColumn(this, query);
				for (int i = 1; i < insertSelect.ReturningColumnCollection.Count; i++)
				{
					query.Append(", ");

					insertSelect.ReturningColumnCollection[i].RenderColumn(this, query);
				}
			}
		}

		public void RenderQuery(Update update, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(update, nameof(update));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			query.Append("UPDATE ");

			update.Source.RenderSource(this, query);

			query.Append(" SET ");

			update.SetCollection[0].Item1.RenderIdentificator(this, query);
			query.Append(" = ");
			update.SetCollection[0].Item2.RenderExpression(this, query);

			for (int i = 1; i < update.SetCollection.Count; i++)
			{
				query.Append(", ");
				update.SetCollection[i].Item1.RenderIdentificator(this, query);
				query.Append(" = ");
				update.SetCollection[i].Item2.RenderExpression(this, query);
			}

			if (update.Condition != null)
			{
				query.Append(" WHERE ");
				update.Condition.RenderCondition(this, query);
			}
		}

		public void RenderQuery(Delete delete, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(delete, nameof(delete));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			query.Append("DELETE FROM ");

			delete.Source.RenderSource(this, query);

			if (delete.Condition != null)
			{
				query.Append(" WHERE ");
				delete.Condition.RenderCondition(this, query);
			}
		}

		#endregion Query rendering methods

		#region Source rendering methods

		public void RenderSource(Table table, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(table, nameof(table));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			if (!string.IsNullOrEmpty(table.Schema))
			{
				RenderIdentificator(table.Schema, query);
				query.Append('.');
			}

			RenderIdentificator(table.Name, query);

			if (!string.IsNullOrEmpty(table.Alias))
			{
				query.Append(" AS ");
				RenderIdentificator(table.Alias, query);
			}
		}

		public void RenderSource(Subquery subquery, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(subquery, nameof(subquery));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			query.Append('(');

			subquery.Select.RenderQuery(this, query);

			query.Append(") AS ");

			RenderIdentificator(subquery.Name, query);
		}

		public void RenderSource(View view, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(view, nameof(view));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			if (!string.IsNullOrEmpty(view.Schema))
			{
				RenderIdentificator(view.Schema, query);
				query.Append('.');
			}

			RenderIdentificator(view.Name, query);

			if (!string.IsNullOrEmpty(view.Alias))
			{
				query.Append(" AS ");
				RenderIdentificator(view.Alias, query);
			}
		}

		#endregion Source rendering methods

		#region Value rendering methods

		public void RenderValue(Int8Value value, StringBuilder query) => RenderValue(value, value?.Data, query);
		public void RenderValue(Int16Value value, StringBuilder query) => RenderValue(value, value?.Data, query);
		public void RenderValue(Int32Value value, StringBuilder query) => RenderValue(value, value?.Data, query);
		public void RenderValue(Int64Value value, StringBuilder query) => RenderValue(value, value?.Data, query);
		public void RenderValue(FloatValue value, StringBuilder query) => RenderValue(value, value?.Data, query);
		public void RenderValue(DoubleValue value, StringBuilder query) => RenderValue(value, value?.Data, query);
		public void RenderValue(DecimalValue value, StringBuilder query) => RenderValue(value, value?.Data, query);
		public void RenderValue(DateTimeValue value, StringBuilder query) => RenderValue(value, $"'{value?.Data.ToString(value.Format)}'", query);
		public void RenderValue(StringValue value, StringBuilder query) => RenderValue(value, $"'{value?.Data}'", query);
		public void RenderValue(NullValue value, StringBuilder query) => RenderValue(value, "null", query);

		private void RenderValue(IValue value, object? data, StringBuilder query)
		{
			Validator.ThrowIfArgumentIsNull(value, nameof(value));
			Validator.ThrowIfArgumentIsNull(query, nameof(query));

			query.Append(data);
		}

		#endregion Value rendering methods
	}
}
