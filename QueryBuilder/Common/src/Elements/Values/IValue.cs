using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface IValue : IExpression
	{
		public void RenderValue(IRenderer renderer, StringBuilder sql);
	}
}
