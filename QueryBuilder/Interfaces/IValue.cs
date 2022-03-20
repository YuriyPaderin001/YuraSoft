using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface IValue : IExpression
	{
		public string RenderValue(IRenderer renderer);
	}
}
