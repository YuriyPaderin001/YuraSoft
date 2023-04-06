using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public class NullValue : Value
	{
		public override void RenderValue(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderValue(this, sql);
	}
}
