using System.Text;

using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class NowFunction : FunctionBase
	{
		public NowFunction()
		{
		}

		public override void RenderFunction(IRenderer renderer, StringBuilder query) =>
			renderer.RenderFunction(this, query);
	}
}
