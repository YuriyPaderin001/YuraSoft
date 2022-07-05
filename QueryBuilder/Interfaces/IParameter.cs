using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface IParameter : IValue
	{
		public string RenderParameter(IRenderer renderer);
	}
}
