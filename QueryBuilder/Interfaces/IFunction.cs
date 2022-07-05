using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface IFunction : IExpression
	{
		public string RenderFunction(IRenderer renderer);
	}
}
