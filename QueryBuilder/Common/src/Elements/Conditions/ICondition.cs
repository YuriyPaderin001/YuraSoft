using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface ICondition : IExpression
	{
		public void RenderCondition(IRenderer renderer, StringBuilder sql);
	}
}
