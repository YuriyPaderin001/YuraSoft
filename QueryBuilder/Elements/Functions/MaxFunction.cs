using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class MaxFunction : ColumnFunction
	{
		public MaxFunction(IColumn column) : base(column)
		{
		}

		public override string RenderFunction(IRenderer renderer) => renderer.RenderFunction(this);
	}
}
