using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface IValue : IExpression
	{
		public string RenderValue(IRenderer renderer);
		public void RenderValue(IRenderer renderer, StringBuilder sql);
	}
}
