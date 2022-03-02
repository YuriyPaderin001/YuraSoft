namespace YuraSoft.QueryBuilder.Renderers
{
	public interface IRenderer
	{
		public string RenderSelect(Select select);
		public string RenderColumn(Column column);
		public string RenderFrom(Table table);
		public string RenderJoin(LeftJoin join);
		public string RenderJoin(RightJoin join);
		public string RenderJoin(InnerJoin join);
	}
}
