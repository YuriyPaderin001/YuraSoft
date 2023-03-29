using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public class NullValue : IValue
	{
		public string RenderValue(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderValue(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public virtual void RenderValue(IRenderer renderer, StringBuilder sql) => renderer.RenderValue(this, sql);

		public string RenderExpression(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderExpression(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public virtual void RenderExpression(IRenderer renderer, StringBuilder sql) => RenderValue(renderer, sql);
	}
}
