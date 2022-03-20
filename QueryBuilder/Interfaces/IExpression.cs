using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface IExpression
	{
		public string RenderExpression(IRenderer renderer);
	}
}
