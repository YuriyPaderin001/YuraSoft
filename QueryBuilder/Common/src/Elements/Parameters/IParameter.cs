using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface IParameter : IValue
	{
		public string RenderParameter(IRenderer renderer);
		public void RenderParameter(IRenderer renderer, StringBuilder sql);
	}
}
