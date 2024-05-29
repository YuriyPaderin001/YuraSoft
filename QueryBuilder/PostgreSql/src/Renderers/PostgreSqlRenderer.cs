using System;
using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Common;
using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.PostgreSql
{
	public class PostgreSqlRenderer : IRenderer
	{
		#region Column rendering methods

		public void RenderColumn(SourceColumn column, StringBuilder sql)
		{
			Guard.ThrowIfNull(column, nameof(column));
			Guard.ThrowIfNull(sql, nameof(sql));

			if (column.Source != null)
			{
				column.Source.RenderIdentificator(this, sql);
				sql.Append('.');
			}

			if (column.Name == "*")
			{
				sql.Append(column.Name);
			}
			else
			{
				RenderIdentificator(column.Name, sql);
			}

			if (!string.IsNullOrEmpty(column.Alias))
			{
				sql.Append(" AS ");
				RenderIdentificator(column.Alias, sql);
			}
		}

		public void RenderColumn(ExpressionColumn column, StringBuilder sql)
		{
			Guard.ThrowIfNull(column, nameof(column));
			Guard.ThrowIfNull(sql, nameof(sql));

			column.Expression.RenderExpression(this, sql);

			if (!string.IsNullOrEmpty(column.Alias))
			{
				sql.Append(" AS ");
				RenderIdentificator(column.Alias, sql);
			}
		}

		#endregion Column rendering methods

		#region Condition rendeting methods

		public void RenderCondition(EqualCondition condition, StringBuilder sql) =>
			RenderBinaryExpression(condition.LeftExpression, condition.RightExpression, "=", sql);

		public void RenderCondition(NotEqualCondition condition, StringBuilder sql) => 
			RenderBinaryExpression(condition.LeftExpression, condition.RightExpression, "<>", sql);

		public void RenderCondition(LessCondition condition, StringBuilder sql) => 
			RenderBinaryExpression(condition.LeftExpression, condition.RightExpression, "<", sql);

		public void RenderCondition(LessOrEqualCondition condition, StringBuilder sql) => 
			RenderBinaryExpression(condition.LeftExpression, condition.RightExpression, "<=", sql);

		public void RenderCondition(GreaterCondition condition, StringBuilder sql) => 
			RenderBinaryExpression(condition.LeftExpression, condition.RightExpression, ">", sql);

		public void RenderCondition(GreaterOrEqualCondition condition, StringBuilder sql) => 
			RenderBinaryExpression(condition.LeftExpression, condition.RightExpression, ">=", sql);

		public void RenderCondition(IsNullCondition condition, StringBuilder sql) => RenderUnaryCondition(condition, "IS NULL", sql);
		public void RenderCondition(IsNotNullCondition condition, StringBuilder sql) => RenderUnaryCondition(condition, "IS NOT NULL", sql);
		public void RenderCondition(InCondition condition, StringBuilder sql) => RenderCondition(condition, "IN", sql);
		public void RenderCondition(NotInCondition condition, StringBuilder sql) => RenderCondition(condition, "NOT IN", sql);
		
		public void RenderCondition(LikeCondition condition, StringBuilder sql) => 
			RenderBinaryExpression(condition.Expression, condition.Pattern, "ILIKE", sql);

		public void RenderCondition(NotLikeCondition condition, StringBuilder sql) =>
			RenderBinaryExpression(condition.Expression, condition.Pattern, "NOT ILIKE", sql);

		public void RenderCondition(AndCondition condition, StringBuilder sql) => RenderLogicalCondition(condition, "AND", sql);
		public void RenderCondition(OrCondition condition, StringBuilder sql) => RenderLogicalCondition(condition, "OR", sql);

		public void RenderCondition(BetweenCondition condition, StringBuilder sql)
		{
			Guard.ThrowIfNull(condition, nameof(condition));
			Guard.ThrowIfNull(sql, nameof(sql));

			condition.Expression.RenderExpression(this, sql);

			sql.Append(" BETWEEN ");

			condition.LessExpression.RenderExpression(this, sql);

			sql.Append(" AND ");

			condition.HightExpression.RenderExpression(this, sql);
		}

		private void RenderCondition(CollectionCondition condition, string conditionType, StringBuilder sql)
		{
			Guard.ThrowIfNull(condition, nameof(condition));
			Guard.ThrowIfNull(sql, nameof(sql));

			condition.Expression.RenderExpression(this, sql);
			sql.Append(' ');
			sql.Append(conditionType);
			sql.Append(" (");

			RenderExpressionCollection(condition.Values, sql);

			sql.Append(')');
		}

		private void RenderLogicalCondition(LogicalCondition condition, string conditionType, StringBuilder sql)
		{
			Guard.ThrowIfNull(condition, nameof(condition));
			Guard.ThrowIfNullOrEmpty(conditionType, nameof(conditionType));
			Guard.ThrowIfNull(sql, nameof(sql));

			sql.Append('(');

			RenderConditionCollection(condition.Conditions, sql, delimiter: $" {conditionType} ");

			sql.Append(')');
		}

		private void RenderUnaryCondition(UnaryCondition condition, string operation, StringBuilder sql)
		{
			Guard.ThrowIfNull(condition, nameof(condition));
			Guard.ThrowIfNullOrEmpty(operation, nameof(operation));
			Guard.ThrowIfNull(sql, nameof(sql));

			condition.Expression.RenderExpression(this, sql);
			sql.Append(' ');
			sql.Append(operation);
		}

		public void RenderCondition(ExistsCondition condition, StringBuilder sql)
		{
			Guard.ThrowIfNull(condition, nameof(condition));
			Guard.ThrowIfNull(sql, nameof(sql));

			sql.Append("EXISTS ");

			condition.Select.RenderExpression(this, sql);
		}

		public void RenderCondition(NotExistsCondition condition, StringBuilder sql)
		{
			Guard.ThrowIfNull(condition, nameof(condition));
			Guard.ThrowIfNull(sql, nameof(sql));

			sql.Append("NOT EXISTS ");

			condition.Select.RenderExpression(this, sql);
		}

		#endregion Condition rendeting methods

		#region Distinct render methods

		public void RenderDistinct(Distinct distinct, StringBuilder sql)
		{
			Guard.ThrowIfNull(distinct, nameof(distinct));
			Guard.ThrowIfNull(sql, nameof(sql));

			sql.Append("DISTINCT");
		}

		public void RenderDistinct(DistinctOn distinct, StringBuilder sql)
		{
			Guard.ThrowIfNull(distinct, nameof(distinct));
			Guard.ThrowIfNull(sql, nameof(sql));

            sql.Append("DISTINCT ON (");

            distinct.Columns[0].RenderIdentificator(this, sql);
            for (int i = 1; i < distinct.Columns.Count; i++)
            {
                sql.Append(", ");

                distinct.Columns[i].RenderIdentificator(this, sql);
            }

            sql.Append(')');
        }

		#endregion Distinct render methods

		#region Expression rendering methods

		public void RenderExpression(GeneralCaseExpression expression, StringBuilder sql)
		{
			Guard.ThrowIfNull(expression, nameof(expression));
			Guard.ThrowIfNull(sql, nameof(sql));

			sql.Append("CASE");

			for (int i = 0; i < expression.WhenThens.Count; i++)
			{
				sql.Append(" WHEN ");

				expression.WhenThens[i].Item1.RenderCondition(this, sql);

				sql.Append(" THEN ");

				expression.WhenThens[i].Item2.RenderExpression(this, sql);
			}

			if (expression.Else != null)
			{
				sql.Append(" ELSE ");
				expression.Else.RenderExpression(this, sql);
			}

			sql.Append(" END");
		}

		public void RenderExpression(SimpleCaseExpression expression, StringBuilder sql)
		{
			Guard.ThrowIfNull(expression, nameof(expression));
			Guard.ThrowIfNull(sql, nameof(sql));

			sql.Append("CASE ");
			expression.Expression.RenderExpression(this, sql);

			for (int i = 0; i < expression.WhenThens.Count; i++)
			{
				sql.Append(" WHEN ");
				expression.WhenThens[i].Item1.RenderExpression(this, sql);
				sql.Append(" THEN ");
				expression.WhenThens[i].Item2.RenderExpression(this, sql);
			}

			if (expression.Else != null)
			{
				sql.Append(" ELSE ");
				expression.Else.RenderExpression(this, sql);
			}

			sql.Append(" END");
		}

		public void RenderExpression(MinusExpression expression, StringBuilder sql) => RenderArithmeticExpression(expression, "-", sql);
		public void RenderExpression(PlusExpression expression, StringBuilder sql) => RenderArithmeticExpression(expression, "+", sql);
		public void RenderExpression(MultiplyExpression expression, StringBuilder sql) => RenderArithmeticExpression(expression, "*", sql);
		public void RenderExpression(DivideExpression expression, StringBuilder sql) => RenderArithmeticExpression(expression, "/", sql);

		public void RenderExpression(Select select, StringBuilder sql)
		{
			Guard.ThrowIfNull(select, nameof(select));
			Guard.ThrowIfNull(sql, nameof(sql));

			sql.Append('(');

			select.RenderQuery(this, sql);

			sql.Append(')');
		}

		private void RenderArithmeticExpression(ArithmeticExpression expression, string operation, StringBuilder sql)
		{
			Guard.ThrowIfNull(expression, nameof(expression));
			Guard.ThrowIfNullOrEmpty(operation, nameof(operation));
			Guard.ThrowIfNull(sql, nameof(sql));

			if (expression.Expressions.Count > 0)
			{
				if (expression.Expressions[0] is ArithmeticException)
				{
					sql.Append('(');

					expression.Expressions[0].RenderExpression(this, sql);

					sql.Append(')');
				}
				else
				{
					expression.Expressions[0].RenderExpression(this, sql);
				}

				for (int i = 1; i < expression.Expressions.Count; i++)
				{
					sql.Append(' ');
					sql.Append(operation);
					sql.Append(' ');

					if (expression.Expressions[i] is ArithmeticException)
					{
						sql.Append('(');
						expression.Expressions[i].RenderExpression(this, sql);
						sql.Append(')');
					}
					else
					{
						expression.Expressions[i].RenderExpression(this, sql);
					}
				}
			}
		}

		#endregion Expression rendering methods

		#region Function rendering methods

		public void RenderFunction(NativeFunction function, StringBuilder sql) => RenderFunction(function.Name, function, function.Parameters, sql);
		public void RenderFunction(CastFunction function, StringBuilder sql)
		{
			Guard.ThrowIfNull(function, nameof(function));
			Guard.ThrowIfNull(sql, nameof(sql));

			function.Expression.RenderExpression(this, sql);
			sql.Append("::");
			sql.Append(function.Type);
		}

		public void RenderFunction(AnyFunction function, StringBuilder sql) => RenderFunction("any", function, function.Expressions, sql);
		public void RenderFunction(ArrayAggFunction function, StringBuilder sql) => RenderExpressionFunction("array_agg", function, sql);
		public void RenderFunction(CountFunction function, StringBuilder sql) => RenderExpressionFunction("count", function, sql);
		public void RenderFunction(SumFunction function, StringBuilder sql) => RenderExpressionFunction("sum", function, sql);
		public void RenderFunction(MaxFunction function, StringBuilder sql) => RenderExpressionFunction("max", function, sql);
		public void RenderFunction(MinFunction function, StringBuilder sql) => RenderExpressionFunction("min", function, sql);
		public void RenderFunction(NowFunction function, StringBuilder sql) => sql.Append("CURRENT_TIMESTAMP");
		public void RenderFunction(ConcatFunction function, StringBuilder sql) => RenderFunction("concat", function, function.Values, sql);
		public void RenderFunction(CoalesceFunction function, StringBuilder sql) => RenderFunction("coalesce", function, sql, function.Expression, function.DefaultExpression);
		public void RenderFunction(ExtractFunction function, StringBuilder sql)
		{
            Guard.ThrowIfNull(function, nameof(function));
            Guard.ThrowIfNull(sql, nameof(sql));

            sql.Append("extract(");
            sql.Append(function.Part);
            sql.Append(" FROM ");

            function.Expression.RenderExpression(this, sql);

            sql.Append(')');
        }

        public void RenderFunction(RoundFunction function, StringBuilder sql)
		{
			Guard.ThrowIfNull(function, nameof(function));
			Guard.ThrowIfNull(sql, nameof(sql));

			sql.Append("round(");

			function.Expression.RenderExpression(this, sql);

			if (function.Precision.HasValue)
			{
				sql.Append(", ");
				sql.Append(function.Precision.Value);
			}

			sql.Append(')');
		}

		public void RenderFunction(CountWindowFunction function, StringBuilder sql) => RenderExpressionWindowFunction("count", function, sql);
		public void RenderFunction(MaxWindowFunction function, StringBuilder sql) => RenderExpressionWindowFunction("max", function, sql);
		public void RenderFunction(MinWindowFunction function, StringBuilder sql) => RenderExpressionWindowFunction("min", function, sql);
		public void RenderFunction(SumWindowFunction function, StringBuilder sql) => RenderExpressionWindowFunction("sum", function, sql);

		private void RenderExpressionWindowFunction(string name, ExpressionWindowFunction function, StringBuilder sql)
		{
            Guard.ThrowIfNull(function, nameof(function));
            Guard.ThrowIfNull(sql, nameof(sql));

            RenderFunction(name, function, sql, function.Expression);
            RenderWindowFunctionFilterAndOver(function, sql);
        }

		private void RenderWindowFunctionFilterAndOver(WindowFunction function, StringBuilder sql)
		{
			if (function.Filter != null)
			{
				sql.Append(" FILTER (WHERE ");

				function.Filter.RenderCondition(this, sql);

				sql.Append(')');
			}

			sql.Append(" OVER (");

			bool hasPartitionBy = function.PartitionBy != null && function.PartitionBy.Count > 0;
            if (hasPartitionBy)
			{
				sql.Append("PARTITION BY ");

                RenderIdentificatorCollection(function.PartitionBy!, sql);
            }

			if (function.OrderBy != null && function.OrderBy.Count > 0)
			{
				if (hasPartitionBy)
				{
					sql.Append(' ');
				}

				sql.Append("ORDER BY ");

				RenderOrderByCollection(function.OrderBy, sql);
			}

			sql.Append(')');
		}

        private void RenderExpressionFunction(string name, ExpressionFunction function, StringBuilder sql) => RenderFunction(name, function, sql, function.Expression);
		private void RenderFunction(string name, IFunction function, StringBuilder sql, params IExpression[] parameters) => RenderFunction(name, function, parameters, sql);

		private void RenderFunction(string name, IFunction function, IEnumerable<IExpression>? parameters, StringBuilder sql)
		{
			Guard.ThrowIfNull(function, nameof(function));
			Guard.ThrowIfNull(sql, nameof(sql));

            sql.Append(name);
            sql.Append('(');

            if (parameters != null)
            {
                RenderExpressionCollection(parameters, sql);
            }

            sql.Append(')');
        }

		#endregion Function rendering methods

		#region Identificator rendering methods

		public void RenderIdentificator(SourceColumn column, StringBuilder sql)
		{
			Guard.ThrowIfNull(column, nameof(column));
			Guard.ThrowIfNull(sql, nameof(sql));

			if (!string.IsNullOrEmpty(column.Alias))
			{
				RenderIdentificator(column.Alias, sql);

				return;
			}

			if (column.Source != null)
			{
				column.Source.RenderIdentificator(this, sql);
				sql.Append('.');
			}

			if (column.Name == "*")
			{
				sql.Append(column.Name);
			}
			else
			{
				RenderIdentificator(column.Name, sql);
			}
		}

		public void RenderIdentificator(ExpressionColumn column, StringBuilder sql)
		{
			Guard.ThrowIfNull(column, nameof(column));
			Guard.ThrowIfNull(sql, nameof(sql));

			if (!string.IsNullOrEmpty(column.Alias))
			{
				RenderIdentificator(column.Alias, sql);

				return;
			}

			column.Expression.RenderExpression(this, sql);
		}

		public void RenderIdentificator(Table table, StringBuilder sql)
		{
			Guard.ThrowIfNull(table, nameof(table));
			Guard.ThrowIfNull(sql, nameof(sql));

			if (!string.IsNullOrEmpty(table.Alias))
			{
				RenderIdentificator(table.Alias, sql);

				return;
			}

			if (!string.IsNullOrEmpty(table.Schema))
			{
				RenderIdentificator(table.Schema, sql);
				sql.Append('.');
			}

			RenderIdentificator(table.Name, sql);
		}

		public virtual void RenderIdentificator(Subquery subquery, StringBuilder sql)
		{
			Guard.ThrowIfNull(subquery, nameof(subquery));
			Guard.ThrowIfNull(sql, nameof(sql));

			RenderIdentificator(subquery.Alias, sql);
		}

		public void RenderIdentificator(View view, StringBuilder sql)
		{
			Guard.ThrowIfNull(view, nameof(view));
			Guard.ThrowIfNull(sql, nameof(sql));

			if (!string.IsNullOrEmpty(view.Alias))
			{
				RenderIdentificator(view.Alias, sql);

				return;
			}

			if (!string.IsNullOrEmpty(view.Schema))
			{
				RenderIdentificator(view.Schema, sql);

				sql.Append('.');
			}

			RenderIdentificator(view.Name, sql);
		}

		public void RenderIdentificator(string identificator, StringBuilder sql)
		{
			Guard.ThrowIfNullOrEmpty(identificator, nameof(identificator));
			Guard.ThrowIfNull(sql, nameof(sql));

			sql.Append('\"');
			sql.Append(identificator);
			sql.Append('\"');
		}

		#endregion Identificator rendering methods

		#region Join rendering methods

		public void RenderJoin(LeftJoin join, StringBuilder sql) => RenderJoin("LEFT JOIN", join, join.Condition, sql);
		public void RenderJoin(RightJoin join, StringBuilder sql) => RenderJoin("RIGHT JOIN", join, join.Condition, sql);
		public void RenderJoin(InnerJoin join, StringBuilder sql) => RenderJoin("INNER JOIN", join, join.Condition, sql);
		public void RenderJoin(FullJoin join, StringBuilder sql) => RenderJoin("FULL JOIN", join, join.Condition, sql);
		public void RenderJoin(CrossJoin join, StringBuilder sql) => RenderJoin("CROSS JOIN", join, null, sql);

		private void RenderJoin(string joinType, Join join, ICondition? condition, StringBuilder sql)
		{
			Guard.ThrowIfNullOrEmpty(joinType, nameof(joinType));
			Guard.ThrowIfNull(join, nameof(join));
			Guard.ThrowIfNull(sql, nameof(sql));

			sql.Append(joinType);
			sql.Append(' ');

			join.Source.RenderSource(this, sql);

			if (condition != null)
			{
				sql.Append(" ON ");

				condition.RenderCondition(this, sql);
			}
		}

		#endregion Join rendering methods

		#region Order by rendering methods

		public void RenderOrderBy(OrderBy orderBy, StringBuilder sql)
		{
			Guard.ThrowIfNull(orderBy, nameof(orderBy));
			Guard.ThrowIfNull(sql, nameof(sql));

			orderBy.Column.RenderIdentificator(this, sql);

			sql.Append(orderBy.Direction == OrderDirection.Asc ? " ASC" : " DESC");
		}

		#endregion Order by rendering methods

		#region Parameter rendering methods

		public void RenderParameter(Parameter parameter, StringBuilder sql)
		{
			Guard.ThrowIfNull(parameter, nameof(parameter));
			Guard.ThrowIfNull(sql, nameof(sql));

			sql.Append('@');
			sql.Append(parameter.Name);
		}

		#endregion Parameter rendering methods

		#region Query rendering methods

		public void RenderQuery(Select select, StringBuilder sql)
		{
			Guard.ThrowIfNull(select, nameof(select));
			Guard.ThrowIfNull(sql, nameof(sql));

			sql.Append("SELECT");

			if (select.DistinctValue != null)
			{
				sql.Append(' ');

				select.DistinctValue.RenderDistinct(this, sql);
			}

			if (select.ColumnCollection.Count > 0)
			{
				sql.Append(' ');

				RenderColumnCollection(select.ColumnCollection, sql);
			}

			if (select.SourceCollection.Count > 0)
			{
				sql.Append(" FROM ");

				RenderSourceCollection(select.SourceCollection, sql);
			}

			foreach (IJoin join in select.JoinCollection)
			{
				sql.Append(' ');
				join.RenderJoin(this, sql);
			}

			if (select.WhereCondition != null)
			{
				sql.Append(" WHERE ");

				select.WhereCondition.RenderCondition(this, sql);
			}

			if (select.GroupByCollection.Count > 0)
			{
				sql.Append(" GROUP BY ");

				RenderIdentificatorCollection(select.GroupByCollection, sql);
			}

			if (select.HavingCondition != null)
			{
				sql.Append(" HAVING ");

				select.HavingCondition.RenderCondition(this, sql);
			}

			if (select.OrderByCollection.Count > 0)
			{
				sql.Append(" ORDER BY ");

				RenderOrderByCollection(select.OrderByCollection, sql);
			}

			if (select.OffsetValue.HasValue)
			{
				sql.Append(" OFFSET ");

				sql.Append(select.OffsetValue.Value);
			}

			if (select.LimitValue.HasValue)
			{
				sql.Append(" LIMIT ");

				sql.Append(select.LimitValue.Value);
			}
		}

		public void RenderQuery(Insert insert, StringBuilder sql)
		{
			Guard.ThrowIfNull(insert, nameof(insert));
			Guard.ThrowIfNull(sql, nameof(sql));

			sql.Append("INSERT INTO ");

			insert.Source.RenderSource(this, sql);

			int step;
			if (insert.ColumnCollection != null && insert.ColumnCollection.Count > 0)
			{
				sql.Append(" (");

				RenderColumnCollection(insert.ColumnCollection, sql);

				sql.Append(')');

				step = insert.ColumnCollection.Count;
			}
			else
			{
				step = int.MaxValue;
			}

			sql.Append(" VALUES ");

			for (int i = 0; i < insert.ValueCollection.Count; i += step)
			{
				if (i == 0)
				{
					sql.Append('(');
				}
				else
				{
					sql.Append(", (");
				}

				insert.ValueCollection[i].RenderExpression(this, sql);

				int limit = i + step > insert.ValueCollection.Count ? insert.ValueCollection.Count : i + step;
				for (int j = i + 1; j < limit; j++)
				{
					sql.Append(", ");
					insert.ValueCollection[j].RenderExpression(this, sql);
				}

				sql.Append(')');
			}

			if (insert.ReturningColumnCollection.Count > 0)
			{
				sql.Append(" RETURNING ");

				RenderColumnCollection(insert.ReturningColumnCollection, sql);
			}
		}

		public void RenderQuery(InsertSelect insertSelect, StringBuilder sql)
		{
			Guard.ThrowIfNull(insertSelect, nameof(insertSelect));
			Guard.ThrowIfNull(sql, nameof(sql));

			sql.Append("INSERT INTO ");

			insertSelect.Source.RenderSource(this, sql);

			sql.Append(' ');

			if (insertSelect.ColumnCollection != null && insertSelect.ColumnCollection.Count > 0)
			{
				sql.Append('(');

				RenderColumnCollection(insertSelect.ColumnCollection, sql);

				sql.Append(") ");
			}

			insertSelect.SelectQuery.RenderQuery(this, sql);

			if (insertSelect.ReturningColumnCollection.Count > 0)
			{
				sql.Append(" RETURNING ");

				RenderColumnCollection(insertSelect.ReturningColumnCollection, sql);
			}
		}

		public void RenderQuery(Update update, StringBuilder sql)
		{
			Guard.ThrowIfNull(update, nameof(update));
			Guard.ThrowIfNull(sql, nameof(sql));

			sql.Append("UPDATE ");

			update.Source.RenderSource(this, sql);

			sql.Append(" SET ");

			update.SetCollection[0].Item1.RenderIdentificator(this, sql);

			sql.Append(" = ");

			update.SetCollection[0].Item2.RenderExpression(this, sql);

			for (int i = 1; i < update.SetCollection.Count; i++)
			{
				sql.Append(", ");

				update.SetCollection[i].Item1.RenderIdentificator(this, sql);
				
				sql.Append(" = ");
				
				update.SetCollection[i].Item2.RenderExpression(this, sql);
			}

			if (update.Condition != null)
			{
				sql.Append(" WHERE ");
				
				update.Condition.RenderCondition(this, sql);
			}
		}

		public void RenderQuery(Delete delete, StringBuilder sql)
		{
			Guard.ThrowIfNull(delete, nameof(delete));
			Guard.ThrowIfNull(sql, nameof(sql));

			sql.Append("DELETE FROM ");

			delete.Source.RenderSource(this, sql);

			if (delete.Condition != null)
			{
				sql.Append(" WHERE ");
				
				delete.Condition.RenderCondition(this, sql);
			}
		}

		#endregion Query rendering methods

		#region Source rendering methods

		public void RenderSource(Table table, StringBuilder sql)
		{
			Guard.ThrowIfNull(table, nameof(table));
			Guard.ThrowIfNull(sql, nameof(sql));

			if (!string.IsNullOrEmpty(table.Schema))
			{
				RenderIdentificator(table.Schema, sql);
				sql.Append('.');
			}

			RenderIdentificator(table.Name, sql);

			if (!string.IsNullOrEmpty(table.Alias))
			{
				sql.Append(" AS ");
				RenderIdentificator(table.Alias, sql);
			}
		}

		public void RenderSource(Subquery subquery, StringBuilder sql)
		{
			Guard.ThrowIfNull(subquery, nameof(subquery));
			Guard.ThrowIfNull(sql, nameof(sql));

			sql.Append('(');

			subquery.Select.RenderQuery(this, sql);

			sql.Append(") AS ");

			RenderIdentificator(subquery.Alias, sql);
		}

		public void RenderSource(View view, StringBuilder sql)
		{
			Guard.ThrowIfNull(view, nameof(view));
			Guard.ThrowIfNull(sql, nameof(sql));

			if (!string.IsNullOrEmpty(view.Schema))
			{
				RenderIdentificator(view.Schema, sql);
				sql.Append('.');
			}

			RenderIdentificator(view.Name, sql);

			if (!string.IsNullOrEmpty(view.Alias))
			{
				sql.Append(" AS ");
				
				RenderIdentificator(view.Alias, sql);
			}
		}

		#endregion Source rendering methods

		#region Value rendering methods

		public void RenderValue(Int8Value value, StringBuilder sql) => RenderValue(value, value?.Data, sql);
		public void RenderValue(Int16Value value, StringBuilder sql) => RenderValue(value, value?.Data, sql);
		public void RenderValue(Int32Value value, StringBuilder sql) => RenderValue(value, value?.Data, sql);
		public void RenderValue(Int64Value value, StringBuilder sql) => RenderValue(value, value?.Data, sql);
		public void RenderValue(FloatValue value, StringBuilder sql) => RenderValue(value, value?.Data, sql);
		public void RenderValue(DoubleValue value, StringBuilder sql) => RenderValue(value, value?.Data, sql);
		public void RenderValue(DecimalValue value, StringBuilder sql) => RenderValue(value, value?.Data, sql);
		public void RenderValue(DateTimeValue value, StringBuilder sql) => RenderValue(value, $"'{value?.Data.ToString(value.Format)}'", sql);
		public void RenderValue(StringValue value, StringBuilder sql) => RenderValue(value, $"'{value?.Data}'", sql);
		public void RenderValue(NullValue value, StringBuilder sql) => RenderValue(value, "null", sql);
		public void RenderValue(BoolValue value, StringBuilder sql) => RenderValue(value, value?.Data == true ? "TRUE" : "FALSE", sql);
		public void RenderValue(IntervalValue value, StringBuilder sql)
		{
			Guard.ThrowIfNull(value, nameof(value));
			Guard.ThrowIfNull(sql, nameof(sql));

			sql.Append('\'');

			bool hasValue = false;
			if (value.Years != 0)
			{
                hasValue = true;

                sql.Append(value.Years);
				sql.Append(" years");
			}

			if (value.Months != 0)
			{
				if (hasValue)
				{
					sql.Append(' ');
				}
				else
				{
					hasValue = true;
				}

				sql.Append(value.Months);
				sql.Append(" months");
			}

			if (value.Days != 0)
			{
				if (hasValue)
				{
					sql.Append(' ');
				}
				else
				{
					hasValue = true;
				}

				sql.Append(value.Days);
				sql.Append(" days");
			}

			if (value.Hours != 0)
			{
				if (hasValue)
				{
					sql.Append(' ');
				}
				else
				{
					hasValue = true;
				}

				sql.Append(value.Hours);
				sql.Append(" hours");
			}

			if (value.Minutes != 0)
			{
				if (hasValue)
				{
					sql.Append(' ');
				}
				else
				{
					hasValue = true;
				}

				sql.Append(value.Minutes);
				sql.Append(" minutes");
			}

			if (value.Seconds != 0)
			{
				if (hasValue)
				{
					sql.Append(' ');
				}
				else
				{
					hasValue = true;
				}

				sql.Append(value.Seconds);
				sql.Append(" seconds");
			}

			if (value.Milliseconds != 0)
			{
				if (hasValue)
				{
					sql.Append(' ');
				}

				sql.Append(value.Milliseconds);
				sql.Append(" milliseconds");
			}

			sql.Append("\'::interval");
		}

		private void RenderValue(IValue value, object? data, StringBuilder sql) =>
			RenderValue(value, data?.ToString(), sql);

		private void RenderValue(IValue value, string? data, StringBuilder sql)
		{
			Guard.ThrowIfNull(value, nameof(value));
			Guard.ThrowIfNull(sql, nameof(sql));

			sql.Append(data);
		}

		#endregion Value rendering methods

		private void RenderColumnCollection<T>(IEnumerable<T> columns, StringBuilder sql, string delimiter = ", ") where T : IColumn =>
			RenderCollection(columns, sql, (T i, StringBuilder s) => i.RenderColumn(this, sql), delimiter);

		private void RenderSourceCollection<T>(IEnumerable<T> sources, StringBuilder sql, string delimiter = ", ") where T : ISource =>
			RenderCollection(sources, sql, (T i, StringBuilder s) => i.RenderSource(this, sql), delimiter);

		private void RenderExpressionCollection<T>(IEnumerable<T> expressions, StringBuilder sql, string delimiter = ", ") where T : IExpression =>
			RenderCollection(expressions, sql, (T o, StringBuilder s) => o.RenderExpression(this, sql), delimiter);

		private void RenderConditionCollection<T>(IEnumerable<T> conditions, StringBuilder sql, string delimiter = ", ") where T : ICondition =>
			RenderCollection(conditions, sql, (T i, StringBuilder s) => i.RenderCondition(this, sql), delimiter);

		private void RenderIdentificatorCollection<T>(IEnumerable<T> identificators, StringBuilder sql, string delimiter = ", ") where T : IIdentificator =>
			RenderCollection(identificators, sql, (T o, StringBuilder s) => o.RenderIdentificator(this, s), delimiter);

		private void RenderOrderByCollection<T>(IEnumerable<T> orderBy, StringBuilder sql, string delimiter = ", ") where T : IOrderBy =>
			RenderCollection(orderBy, sql, (T o, StringBuilder s) => o.RenderOrderBy(this, s), delimiter);

        private void RenderCollection<T>(IEnumerable<T> collection, StringBuilder sql, Action<T, StringBuilder> renderAction, string delimiter)
		{
			IEnumerator<T> enumerator = collection!.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				return;
			}

			renderAction.Invoke(enumerator.Current, sql);
			while (enumerator.MoveNext())
			{
				sql.Append(delimiter);

				renderAction.Invoke(enumerator.Current, sql);
			}
		}

		private void RenderBinaryExpression(IExpression leftExpression, IExpression rightExpression,
			string operation, StringBuilder sql)
		{
			Guard.ThrowIfNull(leftExpression, nameof(leftExpression));
			Guard.ThrowIfNull(rightExpression, nameof(rightExpression));
			Guard.ThrowIfNullOrEmpty(operation, nameof(operation));
			Guard.ThrowIfNull(sql, nameof(sql));

			leftExpression.RenderExpression(this, sql);

			sql.Append(' ');
			sql.Append(operation);
			sql.Append(' ');

			rightExpression.RenderExpression(this, sql);
		}
	}
}
