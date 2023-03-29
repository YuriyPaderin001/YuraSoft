using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface IExpression
	{
		public void RenderExpression(IRenderer renderer, StringBuilder sql);
	}
}
