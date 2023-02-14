using System.Text;

using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface IParameter : IValue
	{
		public void RenderParameter(IRenderer renderer, StringBuilder stringBuilder);
	}
}
