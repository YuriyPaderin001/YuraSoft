using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;
using YuraSoft.QueryBuilder.Validation;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class Subquery : ISource
	{
		private string _name;
		private Select _select;

		public Subquery(string name, Select select)
		{
			_name = Validator.ThrowIfArgumentIsNullOrEmpty(name, nameof(name));
			_select = Validator.ThrowIfArgumentIsNull(select, nameof(select));
		}

		public string Name
		{
			get => _name;
			set => _name = Validator.ThrowIfArgumentIsNullOrEmpty(value, nameof(Name));
		}

		public Select Select
		{
			get => _select;
			set => _select = Validator.ThrowIfArgumentIsNull(value, nameof(Select));
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
