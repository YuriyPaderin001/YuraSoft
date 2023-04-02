using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface IParameter : IValue
	{
		public void RenderParameter(IRenderer renderer, StringBuilder sql);
	}
}
