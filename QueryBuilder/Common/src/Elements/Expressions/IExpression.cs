using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface IExpression
	{
		public string RenderExpression(IRenderer renderer);
		public void RenderExpression(IRenderer renderer, StringBuilder sql);
	}
}
