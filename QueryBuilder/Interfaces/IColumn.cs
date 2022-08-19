using System.Text;

using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface IColumn : IIdentificator, IExpression
	{
		public void RenderColumn(IRenderer renderer, StringBuilder stringBuilder);
	}
}
