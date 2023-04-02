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

		#region Condition render methods

		public void RenderCondition(EqualCondition condition, StringBuilder query);
		public void RenderCondition(NotEqualCondition condition, StringBuilder query);
		public void RenderCondition(InCondition condition, StringBuilder query);
		public void RenderCondition(NotInCondition condition, StringBuilder query);
		public void RenderCondition(IsNullCondition condition, StringBuilder query);
		public void RenderCondition(IsNotNullCondition condition, StringBuilder query);
		public void RenderCondition(LessCondition condition, StringBuilder query);
		public void RenderCondition(LessOrEqualCondition condition, StringBuilder query);
		public void RenderCondition(GreaterCondition condition, StringBuilder query);
		public void RenderCondition(GreaterOrEqualCondition condition, StringBuilder query);
		public void RenderCondition(BetweenCondition condition, StringBuilder query);
		public void RenderCondition(LikeCondition condition, StringBuilder query);
		public void RenderCondition(NotLikeCondition condition, StringBuilder query);
		public void RenderCondition(OrCondition condition, StringBuilder query);
		public void RenderCondition(AndCondition condition, StringBuilder query);
		public void RenderCondition(ExistsCondition condition, StringBuilder query);
		public void RenderCondition(NotExistsCondition condition, StringBuilder query);

		#endregion Condition render methods

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

		public void RenderFunction(Function function, StringBuilder query);
		public void RenderFunction(CastFunction function, StringBuilder query);
		public void RenderFunction(CountFunction function, StringBuilder query);
		public void RenderFunction(SumFunction function, StringBuilder query);
		public void RenderFunction(MaxFunction function, StringBuilder query);
		public void RenderFunction(MinFunction function, StringBuilder query);
		public void RenderFunction(NowFunction function, StringBuilder query);
		public void RenderFunction(ConcatFunction function, StringBuilder query);
		public void RenderFunction(CoalesceFunction function, StringBuilder query);

		#endregion Function render methods

		/*
		#region Identificator render methods

		public void RenderIdentificator(SourceColumn column, StringBuilder query);
		public void RenderIdentificator(ExpressionColumn column, StringBuilder query);
		public void RenderIdentificator(Table table, StringBuilder query);
		public void RenderIdentificator(Subquery subquery, StringBuilder query);
		public void RenderIdentificator(View view, StringBuilder query);

		#endregion Identificator render methods

		#region Join render methods

		public void RenderJoin(LeftJoin join, StringBuilder query);
		public void RenderJoin(RightJoin join, StringBuilder query);
		public void RenderJoin(InnerJoin join, StringBuilder query);
		public void RenderJoin(CrossJoin join, StringBuilder query);

		#endregion Join render methods

		#region OrderBy render methods

		public void RenderOrderBy(OrderBy join, StringBuilder query);

		#endregion OrderBy render methods

		#region Parameter render methods

		public void RenderParameter(Parameter parameter, StringBuilder query);

		#endregion Parameter render methods

		#region Query render methods

		public void RenderQuery(Select select, StringBuilder query);
		public void RenderQuery(Insert insert, StringBuilder query);
		public void RenderQuery(InsertSelect insertSelect, StringBuilder query);
		public void RenderQuery(Update update, StringBuilder query);
		public void RenderQuery(Delete delete, StringBuilder query);

		#endregion Query render methods

		#region Source render methods

		public void RenderSource(Table table, StringBuilder query);
		public void RenderSource(Subquery subquery, StringBuilder query);

		public void RenderSource(View view, StringBuilder query);

		#endregion Source render methods
		*/

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
