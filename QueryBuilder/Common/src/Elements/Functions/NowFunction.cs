using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public class NowFunction : Function
	{
		public NowFunction()
		{
		}

		public override void RenderFunction(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderFunction(this, sql);
	}
}
