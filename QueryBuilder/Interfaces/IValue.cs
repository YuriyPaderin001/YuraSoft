using System.Text;

using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder.Interfaces
{
	public interface IValue : IExpression
	{
		public void RenderValue(IRenderer renderer, StringBuilder stringBuilder);
	}
}
