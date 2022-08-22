using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class NullValue : IValue
	{
		public string RenderValue(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderValue(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public virtual void RenderValue(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderValue(this, stringBuilder);

		public string RenderExpression(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderExpression(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public virtual void RenderExpression(IRenderer renderer, StringBuilder stringBuilder) => RenderValue(renderer, stringBuilder);
	}
}
