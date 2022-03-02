using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface ICondition
	{
		public string RenderCondition(IRenderer renderer); 
	}
}
