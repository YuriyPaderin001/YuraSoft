using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;

#nullable enable

namespace YuraSoft.QueryBuilder.Renderers
{
	public class PostgreSqlRenderer : IRenderer
	{
		public void RenderColumn(SourceColumn column, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNull(column, nameof(column));
			Validator.ThrowIfArgumentIsNull(stringBuilder, nameof(stringBuilder));

			if (column.Source != null)
			{
				column.Source.RenderIdentificator(this, stringBuilder);
				stringBuilder.Append('.');
			}

			RenderIdentificator(column.Name, stringBuilder);

			if (!string.IsNullOrEmpty(column.Alias))
			{
				stringBuilder.Append(' ');
				RenderIdentificator(column.Alias, stringBuilder);
			}
		}

		public void RenderColumn(ExpressionColumn column, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNull(column, nameof(column));
			
			column.Expression.RenderExpression(this, stringBuilder);

			if (!string.IsNullOrEmpty(column.Name))
			{
				stringBuilder.Append(' ');
				RenderIdentificator(column.Name, stringBuilder);
			}
		}

		#region Render condition methods

		public void RenderCondition(EqualCondition condition, StringBuilder stringBuilder) => RenderBinaryCondition(condition, "=", stringBuilder);
		public void RenderCondition(NotEqualCondition condition, StringBuilder stringBuilder) => RenderBinaryCondition(condition, "<>", stringBuilder);
		public void RenderCondition(LessCondition condition, StringBuilder stringBuilder) => RenderBinaryCondition(condition, "<", stringBuilder);
		public void RenderCondition(LessOrEqualCondition condition, StringBuilder stringBuilder) => RenderBinaryCondition(condition, "<=", stringBuilder);
		public void RenderCondition(GreaterCondition condition, StringBuilder stringBuilder) => RenderBinaryCondition(condition, ">", stringBuilder);
		public void RenderCondition(GreaterOrEqualCondition condition, StringBuilder stringBuilder) => RenderBinaryCondition(condition, ">=", stringBuilder);
		public void RenderCondition(IsNullCondition condition, StringBuilder stringBuilder) => RenderUnaryCondition(condition, "is null", stringBuilder);
		public void RenderCondition(IsNotNullCondition condition, StringBuilder stringBuilder) => RenderUnaryCondition(condition, "is not null", stringBuilder);
		public void RenderCondition(InCondition condition, StringBuilder stringBuilder) => RenderCondition(condition, "in", stringBuilder);
		public void RenderCondition(NotInCondition condition, StringBuilder stringBuilder) => RenderCondition(condition, "not in", stringBuilder);
		public void RenderCondition(LikeCondition condition, StringBuilder stringBuilder) => RenderPatternCondition(condition, "ilike", stringBuilder);
		public void RenderCondition(NotLikeCondition condition, StringBuilder stringBuilder) => RenderPatternCondition(condition, "not ilike", stringBuilder);
		public void RenderCondition(AndCondition condition, StringBuilder stringBuilder) => RenderLogicalCondition(condition, "and", stringBuilder);
		public void RenderCondition(OrCondition condition, StringBuilder stringBuilder) => RenderLogicalCondition(condition, "or", stringBuilder);
		
		public void RenderCondition(BetweenCondition condition, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNull(condition, nameof(condition));

			condition.Expression.RenderExpression(this, stringBuilder);
			
			stringBuilder.Append(" between ");
			
			condition.LessExpression.RenderExpression(this, stringBuilder);
			
			stringBuilder.Append(" and ");
			
			condition.HightExpression.RenderExpression(this, stringBuilder);
		}

		private void RenderCondition(CollectionCondition condition, string conditionType, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNull(condition, nameof(condition));

			condition.Expression.RenderExpression(this, stringBuilder);
			stringBuilder.Append(' ');
			stringBuilder.Append(conditionType);
			stringBuilder.Append(" (");

			if (condition.Values.Count > 0)
			{
				condition.Values[0].RenderExpression(this, stringBuilder);
				for (int i = 1; i < condition.Values.Count; i++)
				{
					stringBuilder.Append(", ");
					condition.Values[i].RenderExpression(this, stringBuilder);
				}
			}

			stringBuilder.Append(')');
		}

		private void RenderLogicalCondition(LogicalCondition condition, string conditionType, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNull(condition, nameof(condition));

			string conditionOperator = $" {conditionType} ";

			stringBuilder.Append('(');

			condition.Conditions[0].RenderCondition(this, stringBuilder);
			for (int i = 1; i < condition.Conditions.Count; i++)
			{
				stringBuilder.Append(conditionOperator);
				condition.Conditions[i].RenderCondition(this, stringBuilder);
			}
			
			stringBuilder.Append(')');
		}

		private void RenderPatternCondition(PatternCondition condition, string conditionType, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNull(condition, nameof(condition));

			condition.Expression.RenderExpression(this, stringBuilder);
			stringBuilder.Append(' ');
			stringBuilder.Append(conditionType);
			stringBuilder.Append(" '");
			stringBuilder.Append(condition.Pattern);
			stringBuilder.Append('\'');
		}

		#endregion Render condition methods

		#region Expression render methods

		public void RenderExpression(GeneralCaseExpression expression, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNull(expression, nameof(expression));

			stringBuilder.Append("case");

			for (int i = 0; i < expression.WhenThens.Count; i++)
			{
				stringBuilder.Append(" when ");

				expression.WhenThens[i].Item1.RenderCondition(this, stringBuilder);
				
				stringBuilder.Append(" then ");
				
				expression.WhenThens[i].Item2.RenderExpression(this, stringBuilder);
			}

			if (expression.Else != null)
			{
				stringBuilder.Append(' ');
				expression.Else.RenderExpression(this, stringBuilder);
			}
		}

		public void RenderExpression(SimpleCaseExpression expression, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNull(expression, nameof(expression));

			stringBuilder.Append("case ");
			expression.Expression.RenderExpression(this, stringBuilder);
			
			for (int i = 0; i < expression.WhenThens.Count; i++)
			{
				stringBuilder.Append(" when ");
				expression.WhenThens[i].Item1.RenderExpression(this, stringBuilder);
				stringBuilder.Append(" then ");
				expression.WhenThens[i].Item2.RenderExpression(this, stringBuilder);
			}

			if (expression.Else != null)
			{
				stringBuilder.Append(' ');
				expression.Else.RenderExpression(this, stringBuilder);
			}
		}

		public void RenderExpression(MinusExpression expression, StringBuilder stringBuilder) => RenderArithmeticExpression(expression, "-", stringBuilder);
		public void RenderExpression(PlusExpression expression, StringBuilder stringBuilder) => RenderArithmeticExpression(expression, "+", stringBuilder);
		public void RenderExpression(MultiplyExpression expression, StringBuilder stringBuilder) => RenderArithmeticExpression(expression, "*", stringBuilder);
		public void RenderExpression(DivideExpression expression, StringBuilder stringBuilder) => RenderArithmeticExpression(expression, "/", stringBuilder);

		private void RenderArithmeticExpression(ArithmeticExpression expression, string operation, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNull(expression, nameof(expression));

			if (expression.Expressions.Count > 0)
			{
				if (expression.Expressions[0] is ArithmeticException)
				{
					stringBuilder.Append('(');
					expression.Expressions[0].RenderExpression(this, stringBuilder);
					stringBuilder.Append(')');
				}
				else
				{
					expression.Expressions[0].RenderExpression(this, stringBuilder);
				}
				
				for (int i = 1; i < expression.Expressions.Count; i++)
				{
					if (expression.Expressions[i] is ArithmeticException)
					{
						stringBuilder.Append('(');
						expression.Expressions[i].RenderExpression(this, stringBuilder);
						stringBuilder.Append(')');
					}
					else
					{
						expression.Expressions[i].RenderExpression(this, stringBuilder);
					}
				}
			}
		}

		#endregion Expression render methods

		public void RenderFunction(Function function, StringBuilder stringBuilder) => RenderFunction(function.Name, function, function.Parameters, stringBuilder);
		public void RenderFunction(CountFunction function, StringBuilder stringBuilder) => RenderColumnFunction("count", function, stringBuilder);
		public void RenderFunction(SumFunction function, StringBuilder stringBuilder) => RenderColumnFunction("sum", function, stringBuilder);
		public void RenderFunction(MaxFunction function, StringBuilder stringBuilder) => RenderColumnFunction("max", function, stringBuilder);
		public void RenderFunction(MinFunction function, StringBuilder stringBuilder) => RenderColumnFunction("min", function, stringBuilder);
		public void RenderFunction(ConcatFunction function, StringBuilder stringBuilder) => RenderFunction("concat", function, function.Values, stringBuilder);
		public void RenderFunction(CoalesceFunction function, StringBuilder stringBuilder) => RenderFunction("coalesce", function, stringBuilder, function.Column, function.DefaultValue);

		public void RenderSource(Table table, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNull(table, nameof(table));
			
			if (!string.IsNullOrEmpty(table.Schema))
			{
				RenderIdentificator(table.Schema, stringBuilder);
				stringBuilder.Append('.');
			}

			RenderIdentificator(table.Name, stringBuilder);

			if (!string.IsNullOrEmpty(table.Alias))
			{
				stringBuilder.Append(' ');
				RenderIdentificator(table.Alias, stringBuilder);
			}
		}

		public void RenderJoin(LeftJoin join, StringBuilder stringBuilder) => RenderJoin("left join", join, join.Condition, stringBuilder);
		public void RenderJoin(RightJoin join, StringBuilder stringBuilder) => RenderJoin("right join", join, join.Condition, stringBuilder);
		public void RenderJoin(InnerJoin join, StringBuilder stringBuilder) => RenderJoin("inner join", join, join.Condition, stringBuilder);
		public void RenderJoin(CrossJoin join, StringBuilder stringBuilder) => RenderJoin("cross join", join, null, stringBuilder);

		private void RenderJoin(string joinType, Join join, ICondition? condition, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNull(join, nameof(join));

			stringBuilder.Append($"{joinType} {join.Source.RenderSource(this)}");
			if (condition != null)
			{
				stringBuilder.Append(" on ");

				condition.RenderCondition(this, stringBuilder);
			}
		}

		public void RenderOrderBy(OrderBy orderBy, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNull(orderBy, nameof(orderBy));

			orderBy.Column.RenderIdentificator(this, stringBuilder);
			stringBuilder.Append(orderBy.Direction == OrderDirection.Asc ? "asc" : "desc");
		}

		public void RenderQuery(Select select, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNull(select, nameof(select));
			Validator.ThrowIfArgumentIsNull(stringBuilder, nameof(stringBuilder));

			stringBuilder.Append("select ");

			if (select.ColumnCollection.Count > 0)
			{
				select.ColumnCollection[0].RenderColumn(this, stringBuilder);
				for (int i = 1; i < select.ColumnCollection.Count; i++)
				{
					stringBuilder.Append(", ");
					select.ColumnCollection[i].RenderColumn(this, stringBuilder);
				}
			}

			if (select.SourceCollection.Count > 0)
			{
				stringBuilder.Append(" from ");
				stringBuilder.AppendJoin(", ", select.SourceCollection.ConvertAll(s => s.RenderSource(this)));
			}

			foreach (IJoin join in select.JoinCollection)
			{
				stringBuilder.Append(' ');
				join.RenderJoin(this, stringBuilder);
			}

			if (select.WhereCondition != null)
			{
				stringBuilder.Append(" where ");
				select.WhereCondition.RenderCondition(this, stringBuilder);
			}

			if (select.GroupByCollection.Count > 0)
			{
				stringBuilder.Append(" group by ");
				
				select.GroupByCollection[0].RenderIdentificator(this, stringBuilder);
				for (int i = 1; i < select.GroupByCollection.Count; i++)
				{
					stringBuilder.Append(", ");
					select.GroupByCollection[i].RenderIdentificator(this, stringBuilder);
				}
			}

			if (select.HavingCondition != null)
			{
				stringBuilder.Append(" having ");
				select.HavingCondition.RenderCondition(this, stringBuilder);
			}

			if (select.OrderByCollection.Count > 0)
			{
				stringBuilder.Append(" order by ");

				select.OrderByCollection[0].RenderOrderBy(this, stringBuilder);
				for (int i = 1; i < select.OrderByCollection.Count; i++)
				{
					stringBuilder.Append(", ");
					select.OrderByCollection[i].RenderOrderBy(this, stringBuilder);
				}
			}

			if (select.OffsetValue.HasValue)
			{
				stringBuilder.Append(" offset ");
				stringBuilder.Append(select.OffsetValue.Value);
			}

			if (select.LimitValue.HasValue)
			{
				stringBuilder.Append(" limit ");
				stringBuilder.Append(select.LimitValue.Value);
			}
		}

		public void RenderQuery(Insert insert, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNull(insert, nameof(insert));
			Validator.ThrowIfArgumentIsNull(stringBuilder, nameof(stringBuilder));

			stringBuilder.Append("insert into ");
			stringBuilder.Append(insert.Source.RenderSource(this));
			stringBuilder.Append(" (");

			insert.ColumnCollection[0].RenderColumn(this, stringBuilder);
			for (int i = 1; i < insert.ColumnCollection.Count; i++)
			{
				stringBuilder.Append(", ");
				insert.ColumnCollection[i].RenderColumn(this, stringBuilder);
			}

			stringBuilder.Append(") values ");

			int step = insert.ColumnCollection.Count;
			for (int i = 0; i < insert.ValueCollection.Count; i += step)
			{
				if (i == 0)
				{
					stringBuilder.Append('(');
				}
				else
				{
					stringBuilder.Append(", (");
				}

				insert.ValueCollection[i].RenderExpression(this, stringBuilder);

				int limit = i + step > insert.ValueCollection.Count ? insert.ValueCollection.Count : i + step;
				for (int j = i + 1; j < limit; j++)
				{
					stringBuilder.Append(", ");
					insert.ValueCollection[j].RenderExpression(this, stringBuilder);
				}

				stringBuilder.Append(')');
			}

			if (insert.ReturningColumnCollection.Count > 0)
			{
				stringBuilder.Append(" returning ");

				insert.ReturningColumnCollection[0].RenderColumn(this, stringBuilder);
				for (int i = 1; i < insert.ReturningColumnCollection.Count; i++)
				{
					stringBuilder.Append(", ");
					insert.ReturningColumnCollection[i].RenderColumn(this, stringBuilder);
				}
			}
		}

		public void RenderIdentificator(SourceColumn column, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNull(column, nameof(column));
			
			if (!string.IsNullOrEmpty(column.Alias))
			{
				RenderIdentificator(column.Alias, stringBuilder);

				return;
			}

			if (column.Source != null)
			{
				column.Source.RenderIdentificator(this, stringBuilder);
				stringBuilder.Append('.');
			}

			RenderIdentificator(column.Name, stringBuilder);
		}

		public void RenderIdentificator(ExpressionColumn column, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNull(column, nameof(column));

			if (!string.IsNullOrEmpty(column.Name))
			{
				RenderIdentificator(column.Name, stringBuilder);

				return;
			}

			column.Expression.RenderExpression(this, stringBuilder);
		}

		public void RenderIdentificator(Table table, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNull(table, nameof(table));
			Validator.ThrowIfArgumentIsNull(stringBuilder, nameof(stringBuilder));

			if (!string.IsNullOrEmpty(table.Alias))
			{
				RenderIdentificator(table.Alias, stringBuilder);

				return;
			}

			if (!string.IsNullOrEmpty(table.Schema))
			{
				RenderIdentificator(table.Schema, stringBuilder);
				stringBuilder.Append('.');
			}

			RenderIdentificator(table.Name, stringBuilder);
		}

		public void RenderIdentificator(string identificator, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNullOrEmpty(identificator, nameof(identificator));

			stringBuilder.Append('\"');
			stringBuilder.Append(identificator);
			stringBuilder.Append('\"');
		}

		public void RenderParameter(Parameter parameter, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNull(parameter, nameof(parameter));

			stringBuilder.Append('@');
			stringBuilder.Append(parameter.Name);
		}

		public void RenderValue(Int8Value value, StringBuilder stringBuilder) => RenderValue((object)value.Data, stringBuilder);
		public void RenderValue(Int16Value value, StringBuilder stringBuilder) => RenderValue((object)value.Data, stringBuilder);
		public void RenderValue(Int32Value value, StringBuilder stringBuilder) => RenderValue((object)value.Data, stringBuilder);
		public void RenderValue(Int64Value value, StringBuilder stringBuilder) => RenderValue((object)value.Data, stringBuilder);
		public void RenderValue(FloatValue value, StringBuilder stringBuilder) => RenderValue((object)value.Data, stringBuilder);
		public void RenderValue(DoubleValue value, StringBuilder stringBuilder) => RenderValue((object)value.Data, stringBuilder);
		public void RenderValue(DecimalValue value, StringBuilder stringBuilder) => RenderValue((object)value.Data, stringBuilder);
		public void RenderValue(DateTimeValue value, StringBuilder stringBuilder) => RenderValue((object)value.Data, stringBuilder);
		public void RenderValue(StringValue value, StringBuilder stringBuilder) => RenderValue((object)$"'{value.Data}'", stringBuilder);

		private void RenderValue(object value, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNull(value, nameof(value));

			stringBuilder.Append(value);
		}

		private void RenderUnaryCondition(UnaryCondition condition, string operation, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNull(condition, nameof(condition));
			Validator.ThrowIfArgumentIsNullOrEmpty(operation, nameof(operation));

			condition.Expression.RenderExpression(this, stringBuilder);
			stringBuilder.Append(' ');
			stringBuilder.Append(operation);
		}

		private void RenderBinaryCondition(BinaryCondition condition, string operation, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNull(condition, nameof(condition));
			Validator.ThrowIfArgumentIsNullOrEmpty(operation, nameof(operation));

			condition.LeftExpression.RenderExpression(this, stringBuilder);
			stringBuilder.Append(' ');
			stringBuilder.Append(operation);
			stringBuilder.Append(' ');
			condition.RightExpression.RenderExpression(this, stringBuilder);
		}

		private void RenderColumnFunction(string name, ColumnFunction function, StringBuilder stringBuilder) => RenderFunction(name, function, stringBuilder, function.Column);
		private void RenderFunction(string name, IFunction function, StringBuilder stringBuilder, params IExpression[] parameters) => RenderFunction(name, function, parameters, stringBuilder);

		private void RenderFunction(string name, IFunction function, IEnumerable<IExpression>? parameters, StringBuilder stringBuilder)
		{
			Validator.ThrowIfArgumentIsNull(function, nameof(function));

			stringBuilder.Append(name);
			stringBuilder.Append('(');
			
			if (parameters != null && parameters.Any())
			{
				IEnumerator<IExpression> enumerator = parameters.GetEnumerator();
				enumerator.MoveNext();
				enumerator.Current.RenderExpression(this, stringBuilder);
				while (enumerator.MoveNext())
				{
					stringBuilder.Append(", ");
					enumerator.Current.RenderExpression(this, stringBuilder);
				}
			}

			stringBuilder.Append(')');
		}
	}
}
