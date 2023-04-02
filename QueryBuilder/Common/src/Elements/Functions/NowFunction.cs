using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public class NowFunction : FunctionBase
	{
		public NowFunction()
		{
		}

		public override void RenderFunction(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderFunction(this, sql);
	}
}
