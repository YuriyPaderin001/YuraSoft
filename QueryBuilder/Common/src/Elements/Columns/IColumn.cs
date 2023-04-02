using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public interface IColumn : IIdentificator, IExpression
	{
		public void RenderColumn(IRenderer renderer, StringBuilder sql);
	}
}
