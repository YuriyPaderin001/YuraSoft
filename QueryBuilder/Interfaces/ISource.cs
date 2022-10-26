using System.Text;

using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface ISource : IIdentificator
	{
		public void RenderSource(IRenderer renderer, StringBuilder query);
	}
}
