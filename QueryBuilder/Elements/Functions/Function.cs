using System.Collections.Generic;

using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class Function : FunctionBase
	{
		private string _name;

		public Function(string name, IEnumerable<IExpression>? parameters)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentShouldNotBeNullOrEmptyException(nameof(name));
			}

			_name = name;

			Parameters = parameters != null ? new List<IExpression>(parameters) : null;
		}

		public string Name
		{
			get => _name;
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentShouldNotBeNullOrEmptyException(nameof(Name));
				}

				_name = value;
			}
		}

		public List<IExpression>? Parameters { get; set; }

		public override string RenderFunction(IRenderer renderer) => renderer.RenderFunction(this);
	}
}
