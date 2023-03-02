using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public class Subquery : ISource
	{
		private Select _select;
		private string _name;

		public Subquery(Select select, string name)
		{
			_select = Validator.ThrowIfArgumentIsNull(select, nameof(select));
			_name = Validator.ThrowIfArgumentIsNullOrEmpty(name, nameof(name));
		}

		public Select Select
		{
			get => _select;
			set => _select = Validator.ThrowIfArgumentIsNull(value, nameof(Select));
		}

		public string Name
		{
			get => _name;
			set => _name = Validator.ThrowIfArgumentIsNullOrEmpty(value, nameof(Name));
		}

		public string RenderSource(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderSource(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public virtual void RenderSource(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderSource(this, stringBuilder);
		
		public string RenderIdentificator(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderIdentificator(renderer, stringBuilder);

			return stringBuilder.ToString();
		}
		
		public virtual void RenderIdentificator(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderIdentificator(this, stringBuilder);
	}
}
