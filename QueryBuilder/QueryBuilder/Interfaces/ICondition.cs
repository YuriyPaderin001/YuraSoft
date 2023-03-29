using System.Text;

using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface ICondition : IExpression
	{
		public void RenderCondition(IRenderer renderer, StringBuilder stringBuilder);
	}
}
