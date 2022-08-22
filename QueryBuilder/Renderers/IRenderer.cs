using System.Text;

namespace YuraSoft.QueryBuilder.Renderers
{
	public interface IRenderer
	{
		#region Column render methods

		public void RenderColumn(SourceColumn column, StringBuilder stringBuilder);
		public void RenderColumn(ExpressionColumn column, StringBuilder stringBuilder);

		#endregion Column render methods

		#region Condition render methods

		public void RenderCondition(EqualCondition condition, StringBuilder stringBuilder);
		public void RenderCondition(NotEqualCondition condition, StringBuilder stringBuilder);
		public void RenderCondition(InCondition condition, StringBuilder stringBuilder);
		public void RenderCondition(NotInCondition condition, StringBuilder stringBuilder);
		public void RenderCondition(IsNullCondition condition, StringBuilder stringBuilder);
		public void RenderCondition(IsNotNullCondition condition, StringBuilder stringBuilder);
		public void RenderCondition(LessCondition condition, StringBuilder stringBuilder);
		public void RenderCondition(LessOrEqualCondition condition, StringBuilder stringBuilder);
		public void RenderCondition(GreaterCondition condition, StringBuilder stringBuilder);
		public void RenderCondition(GreaterOrEqualCondition condition, StringBuilder stringBuilder);
		public void RenderCondition(BetweenCondition condition, StringBuilder stringBuilder);
		public void RenderCondition(LikeCondition condition, StringBuilder stringBuilder);
		public void RenderCondition(NotLikeCondition condition, StringBuilder stringBuilder);
		public void RenderCondition(OrCondition condition, StringBuilder stringBuilder);
		public void RenderCondition(AndCondition condition, StringBuilder stringBuilder);

		#endregion Condition render methods

		#region Expression render methods

		public void RenderExpression(GeneralCaseExpression expression, StringBuilder stringBuilder);
		public void RenderExpression(SimpleCaseExpression expression, StringBuilder stringBuilder);
		public void RenderExpression(MinusExpression expression, StringBuilder stringBuilder);
		public void RenderExpression(PlusExpression expression, StringBuilder stringBuilder);
		public void RenderExpression(MultiplyExpression expression, StringBuilder stringBuilder);
		public void RenderExpression(DivideExpression expression, StringBuilder stringBuilder);

		#endregion Expression render methods

		#region Function render methods

		public void RenderFunction(Function function, StringBuilder stringBuilder);
		public void RenderFunction(CountFunction function, StringBuilder stringBuilder);
		public void RenderFunction(SumFunction function, StringBuilder stringBuilder);
		public void RenderFunction(MaxFunction function, StringBuilder stringBuilder);
		public void RenderFunction(MinFunction function, StringBuilder stringBuilder);
		public void RenderFunction(ConcatFunction function, StringBuilder stringBuilder);
		public void RenderFunction(CoalesceFunction function, StringBuilder stringBuilder);

		#endregion Function render methods

		#region Identificator render methods

		public void RenderIdentificator(SourceColumn column, StringBuilder stringBuilder);
		public void RenderIdentificator(ExpressionColumn column, StringBuilder stringBuilder);
		public void RenderIdentificator(Table table, StringBuilder stringBuilder);

		#endregion Identificator render methods

		#region Join render methods

		public void RenderJoin(LeftJoin join, StringBuilder stringBuilder);
		public void RenderJoin(RightJoin join, StringBuilder stringBuilder);
		public void RenderJoin(InnerJoin join, StringBuilder stringBuilder);
		public void RenderJoin(CrossJoin join, StringBuilder stringBuilder);

		#endregion Join render methods

		#region OrderBy render methods

		public void RenderOrderBy(OrderBy join, StringBuilder stringBuilder);
		
		#endregion OrderBy render methods

		#region Parameter render methods

		public void RenderParameter(Parameter parameter, StringBuilder stringBuilder);
		
		#endregion Parameter render methods

		#region Query render methods

		public void RenderQuery(Select select, StringBuilder stringBuilder);
		public void RenderQuery(Insert insert, StringBuilder stringBuilder);
		public void RenderQuery(Update update, StringBuilder stringBuilder);
		public void RenderQuery(Delete delete, StringBuilder stringBuilder);

		#endregion Query render methods

		#region Source render methods

		public void RenderSource(Table table, StringBuilder stringBuilder);
		
		#endregion Source render methods

		#region Value render methods

		public void RenderValue(Int8Value value, StringBuilder stringBuilder);
		public void RenderValue(Int16Value value, StringBuilder stringBuilder);
		public void RenderValue(Int32Value value, StringBuilder stringBuilder);
		public void RenderValue(Int64Value value, StringBuilder stringBuilder);
		public void RenderValue(FloatValue value, StringBuilder stringBuilder);
		public void RenderValue(DoubleValue value, StringBuilder stringBuilder);
		public void RenderValue(DecimalValue value, StringBuilder stringBuilder);
		public void RenderValue(DateTimeValue value, StringBuilder stringBuilder);
		public void RenderValue(StringValue value, StringBuilder stringBuilder);
		public void RenderValue(NullValue value, StringBuilder stringBuilder);

		#endregion Value render methods
	}
}
