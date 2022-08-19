using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class SumFunction : ColumnFunction
	{
		public SumFunction(IColumn column) : base(column)
		{
		}

		public override void RenderFunction(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderFunction(this, stringBuilder);
	}
}
