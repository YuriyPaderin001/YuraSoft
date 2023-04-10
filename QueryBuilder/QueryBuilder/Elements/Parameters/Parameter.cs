using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public class Parameter : IParameter
	{
		private string _name;

		public Parameter(string name)
		{
			_name = Validator.ThrowIfArgumentIsNullOrEmpty(name, nameof(name));
		}

		public string Name
		{
			get => _name;
			set => _name = Validator.ThrowIfArgumentIsNullOrEmpty(value, nameof(Name));
		}

		public string RenderValue(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderValue(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public virtual void RenderValue(IRenderer renderer, StringBuilder stringBuilder) => RenderParameter(renderer, stringBuilder);

		public string RenderExpression(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderExpression(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public virtual void RenderExpression(IRenderer renderer, StringBuilder stringBuilder) => RenderParameter(renderer, stringBuilder);

		public string RenderParameter(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderParameter(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public virtual void RenderParameter(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderParameter(this, stringBuilder);
	}
}
