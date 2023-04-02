using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface IRenderer
	{
		/*
		#region Column render methods

		public void RenderColumn(SourceColumn column, StringBuilder query);
		public void RenderColumn(ExpressionColumn column, StringBuilder query);

		#endregion Column render methods
		*/

		#region Condition render methods

		public void RenderCondition(EqualCondition condition, StringBuilder sql);
		public void RenderCondition(NotEqualCondition condition, StringBuilder sql);
		public void RenderCondition(InCondition condition, StringBuilder sql);
		public void RenderCondition(NotInCondition condition, StringBuilder sql);
		public void RenderCondition(IsNullCondition condition, StringBuilder sql);
		public void RenderCondition(IsNotNullCondition condition, StringBuilder sql);
		public void RenderCondition(LessCondition condition, StringBuilder sql);
		public void RenderCondition(LessOrEqualCondition condition, StringBuilder sql);
		public void RenderCondition(GreaterCondition condition, StringBuilder sql);
		public void RenderCondition(GreaterOrEqualCondition condition, StringBuilder sql);
		public void RenderCondition(BetweenCondition condition, StringBuilder sql);
		public void RenderCondition(LikeCondition condition, StringBuilder sql);
		public void RenderCondition(NotLikeCondition condition, StringBuilder sql);
		public void RenderCondition(OrCondition condition, StringBuilder sql);
		public void RenderCondition(AndCondition condition, StringBuilder sql);
		// public void RenderCondition(ExistsCondition condition, StringBuilder sql);
		// public void RenderCondition(NotExistsCondition condition, StringBuilder sql);

		#endregion Condition render methods

		/*
		#region Distinct render methods

		public void RenderDistinct(Distinct distinct, StringBuilder query);

		#endregion Distinct render methods
		*/

		#region Expression render methods

		public void RenderExpression(GeneralCaseExpression expression, StringBuilder sql);
		public void RenderExpression(SimpleCaseExpression expression, StringBuilder sql);
		public void RenderExpression(MinusExpression expression, StringBuilder sql);
		public void RenderExpression(PlusExpression expression, StringBuilder sql);
		public void RenderExpression(MultiplyExpression expression, StringBuilder sql);
		public void RenderExpression(DivideExpression expression, StringBuilder sql);
		// public void RenderExpression(Select select, StringBuilder query);

		#endregion Expression render methods

		#region Function render methods

		public void RenderFunction(Function function, StringBuilder sql);
		public void RenderFunction(CastFunction function, StringBuilder sql);
		public void RenderFunction(CountFunction function, StringBuilder sql);
		public void RenderFunction(SumFunction function, StringBuilder sql);
		public void RenderFunction(MaxFunction function, StringBuilder sql);
		public void RenderFunction(MinFunction function, StringBuilder sql);
		public void RenderFunction(NowFunction function, StringBuilder sql);
		public void RenderFunction(ConcatFunction function, StringBuilder sql);
		public void RenderFunction(CoalesceFunction function, StringBuilder sql);

		#endregion Function render methods

		#region Identificator render methods

		// public void RenderIdentificator(SourceColumn column, StringBuilder sql);
		// public void RenderIdentificator(ExpressionColumn column, StringBuilder sql);
		public void RenderIdentificator(Table table, StringBuilder sql);
		// public void RenderIdentificator(Subquery subquery, StringBuilder sql);
		public void RenderIdentificator(View view, StringBuilder sql);

		#endregion Identificator render methods

		/*
		#region Join render methods

		public void RenderJoin(LeftJoin join, StringBuilder query);
		public void RenderJoin(RightJoin join, StringBuilder query);
		public void RenderJoin(InnerJoin join, StringBuilder query);
		public void RenderJoin(CrossJoin join, StringBuilder query);

		#endregion Join render methods

		#region OrderBy render methods

		public void RenderOrderBy(OrderBy join, StringBuilder query);

		#endregion OrderBy render methods
		*/

		#region Parameter render methods

		public void RenderParameter(Parameter parameter, StringBuilder sql);

		#endregion Parameter render methods

		/*
		#region Query render methods

		public void RenderQuery(Select select, StringBuilder query);
		public void RenderQuery(Insert insert, StringBuilder query);
		public void RenderQuery(InsertSelect insertSelect, StringBuilder query);
		public void RenderQuery(Update update, StringBuilder query);
		public void RenderQuery(Delete delete, StringBuilder query);

		#endregion Query render methods
		*/

		#region Source render methods

		public void RenderSource(Table table, StringBuilder sql);
		public void RenderSource(View view, StringBuilder sql);
		// public void RenderSource(Subquery subquery, StringBuilder sql);

		#endregion Source render methods

		#region Value render methods

		public void RenderValue(Int8Value value, StringBuilder sql);
		public void RenderValue(Int16Value value, StringBuilder sql);
		public void RenderValue(Int32Value value, StringBuilder sql);
		public void RenderValue(Int64Value value, StringBuilder sql);
		public void RenderValue(FloatValue value, StringBuilder sql);
		public void RenderValue(DoubleValue value, StringBuilder sql);
		public void RenderValue(DecimalValue value, StringBuilder sql);
		public void RenderValue(DateTimeValue value, StringBuilder sql);
		public void RenderValue(StringValue value, StringBuilder sql);
		public void RenderValue(NullValue value, StringBuilder sql);

		#endregion Value render methods
	}
}
