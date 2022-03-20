#nullable enable

namespace YuraSoft.QueryBuilder.Renderers
{
	public interface IRenderer
	{
		public string RenderSelect(Select select);

		public string RenderColumn(Column column);
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
		public string RenderSource(Table table);
		public string RenderIdentificator(Column column);
		public string RenderIdentificator(Table table);
		public string RenderJoin(LeftJoin join);
		public string RenderJoin(RightJoin join);
		public string RenderJoin(InnerJoin join);
		public string RenderJoin(CrossJoin join);
		public string RenderOrderBy(OrderBy join);
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
