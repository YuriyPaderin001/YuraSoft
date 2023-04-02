using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class Function : FunctionBase
	{
		private string _name;

		public Function(string name, IEnumerable<IExpression>? parameters = null)
		{
			_name = Guard.ThrowIfNullOrEmpty(name, nameof(name));
			Parameters = parameters != null ? new List<IExpression>(parameters) : null;
		}

		public string Name
		{
			get => _name;
			set => _name = Guard.ThrowIfNullOrEmpty(value, nameof(Name));
		}

		public List<IExpression>? Parameters { get; set; }

		public override void RenderFunction(IRenderer renderer, StringBuilder sql) => renderer.RenderFunction(this, sql);
	}
}
