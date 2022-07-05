#nullable enable

namespace YuraSoft.QueryBuilder.Renderers
{
	public interface IRenderer
	{
		public string RenderSelect(Select select);

		#region Column render methods

		public string RenderColumn(SourceColumn column);
		public string RenderColumn(ExpressionColumn column);

		#endregion Column render methods

		#region Condition render methods

		public string RenderCondition(EqualCondition condition);
		public string RenderCondition(NotEqualCondition condition);
		public string RenderCondition(InCondition condition);
		public string RenderCondition(NotInCondition condition);
		public string RenderCondition(IsNullCondition condition);
		public string RenderCondition(IsNotNullCondition condition);
		public string RenderCondition(LessCondition condition);
		public string RenderCondition(LessOrEqualCondition condition);
		public string RenderCondition(GreaterCondition condition);
		public string RenderCondition(GreaterOrEqualCondition condition);
		public string RenderCondition(BetweenCondition condition);
		public string RenderCondition(LikeCondition condition);
		public string RenderCondition(NotLikeCondition condition);
		public string RenderCondition(AndCondition condition);
		public string RenderCondition(OrCondition condition);

		#endregion Condition render methods

		#region Expression render methods

		public string RenderExpression(GeneralCaseExpression expression);
		public string RenderExpression(SimpleCaseExpression expression);
		public string RenderExpression(MinusExpression expression);
		public string RenderExpression(PlusExpression expression);
		public string RenderExpression(MultiplyExpression expression);
		public string RenderExpression(DivideExpression expression);

		#endregion Expression render methods

		#region Function render methods

		public string RenderFunction(Function function);
		public string RenderFunction(CountFunction function);
		public string RenderFunction(SumFunction function);
		public string RenderFunction(MaxFunction function);
		public string RenderFunction(MinFunction function);
		public string RenderFunction(ConcatFunction function);
		public string RenderFunction(CoalesceFunction function);

		#endregion Function render methods

		public string RenderSource(Table table);
		public string RenderIdentificator(SourceColumn column);
		public string RenderIdentificator(ExpressionColumn column);
		public string RenderIdentificator(Table table);
		public string RenderJoin(LeftJoin join);
		public string RenderJoin(RightJoin join);
		public string RenderJoin(InnerJoin join);
		public string RenderJoin(CrossJoin join);
		public string RenderOrderBy(OrderBy join);
		public string RenderParameter(Parameter parameter);
		public string RenderValue(Int8Value value);
		public string RenderValue(Int16Value value);
		public string RenderValue(Int32Value value);
		public string RenderValue(Int64Value value);
		public string RenderValue(FloatValue value);
		public string RenderValue(DoubleValue value);
		public string RenderValue(DecimalValue value);
		public string RenderValue(DateTimeValue value);
		public string RenderValue(StringValue value);
	}
}
