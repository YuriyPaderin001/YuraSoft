using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class Function : FunctionBase
	{
		private string _name;

		public Function(string name, IEnumerable<IExpression>? parameters)
		{
			_name = Validator.ThrowIfArgumentIsNullOrEmpty(name, nameof(name));
			Parameters = parameters != null ? new List<IExpression>(parameters) : null;
		}

		public string Name
		{
			get => _name;
			set => _name = Validator.ThrowIfArgumentIsNullOrEmpty(value, nameof(Name));
		}

		public List<IExpression>? Parameters { get; set; }

		public override void RenderFunction(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderFunction(this, stringBuilder);
	}
}
