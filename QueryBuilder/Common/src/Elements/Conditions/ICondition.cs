using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface ICondition : IExpression
	{
		public string RenderCondition(IRenderer renderer);
		public void RenderCondition(IRenderer renderer, StringBuilder sql);
	}
}
