using System;
using System.Text;

namespace YuraSoft.QueryBuilder.Common.Tests
{
	public class NullRenderer : IRenderer
	{
		private string _expectedSql;

		public NullRenderer(string expectedSql)
		{
			if (string.IsNullOrEmpty(expectedSql))
			{
				throw new ArgumentException("Value can't be empty or null string", nameof(expectedSql));
			}

			_expectedSql = expectedSql;
		}

		public string ExpectedSql 
		{ 
			get => _expectedSql; 
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException("Value can't be empty or null string", nameof(ExpectedSql));
				}

				_expectedSql = value;
			}
		}

		public void RenderColumn(SourceColumn column, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderColumn(ExpressionColumn column, StringBuilder sql) => sql.Append(_expectedSql);

		public void RenderCondition(EqualCondition condition, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderCondition(NotEqualCondition condition, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderCondition(InCondition condition, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderCondition(NotInCondition condition, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderCondition(IsNullCondition condition, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderCondition(IsNotNullCondition condition, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderCondition(LessCondition condition, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderCondition(LessOrEqualCondition condition, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderCondition(GreaterCondition condition, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderCondition(GreaterOrEqualCondition condition, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderCondition(BetweenCondition condition, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderCondition(LikeCondition condition, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderCondition(NotLikeCondition condition, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderCondition(OrCondition condition, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderCondition(AndCondition condition, StringBuilder sql) => sql.Append(_expectedSql);
		
		public void RenderExpression(GeneralCaseExpression expression, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderExpression(SimpleCaseExpression expression, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderExpression(MinusExpression expression, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderExpression(PlusExpression expression, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderExpression(MultiplyExpression expression, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderExpression(DivideExpression expression, StringBuilder sql) => sql.Append(_expectedSql);
		
		public void RenderFunction(Function function, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderFunction(CastFunction function, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderFunction(CountFunction function, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderFunction(SumFunction function, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderFunction(MaxFunction function, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderFunction(MinFunction function, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderFunction(NowFunction function, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderFunction(ConcatFunction function, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderFunction(CoalesceFunction function, StringBuilder sql) => sql.Append(_expectedSql);

		public void RenderIdentificator(Table table, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderIdentificator(View view, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderIdentificator(SourceColumn column, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderIdentificator(ExpressionColumn column, StringBuilder sql) => sql.Append(_expectedSql);

		public void RenderJoin(LeftJoin join, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderJoin(RightJoin join, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderJoin(InnerJoin join, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderJoin(CrossJoin join, StringBuilder sql) => sql.Append(_expectedSql);

		public void RenderParameter(Parameter parameter, StringBuilder sql) => sql.Append(_expectedSql);

		public void RenderSource(Table table, StringBuilder sql) => sql.Append(_expectedSql);
		public void RenderSource(View view, StringBuilder sql) => sql.Append(_expectedSql);

		public void RenderValue(Int8Value value, StringBuilder sql) => sql.Append(_expectedSql); 
		public void RenderValue(Int16Value value, StringBuilder sql) => sql.Append(_expectedSql); 
		public void RenderValue(Int32Value value, StringBuilder sql) => sql.Append(_expectedSql); 
		public void RenderValue(Int64Value value, StringBuilder sql) => sql.Append(_expectedSql); 
		public void RenderValue(FloatValue value, StringBuilder sql) => sql.Append(_expectedSql); 
		public void RenderValue(DoubleValue value, StringBuilder sql) => sql.Append(_expectedSql); 
		public void RenderValue(DecimalValue value, StringBuilder sql) => sql.Append(_expectedSql); 
		public void RenderValue(DateTimeValue value, StringBuilder sql) => sql.Append(_expectedSql); 
		public void RenderValue(StringValue value, StringBuilder sql) => sql.Append(_expectedSql); 
		public void RenderValue(NullValue value, StringBuilder sql) => sql.Append(_expectedSql);
	}
}
