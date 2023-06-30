using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface IColumn : IIdentificator, IExpression
	{
		public string RenderColumn(IRenderer renderer);
		public void RenderColumn(IRenderer renderer, StringBuilder sql);
	}
}
