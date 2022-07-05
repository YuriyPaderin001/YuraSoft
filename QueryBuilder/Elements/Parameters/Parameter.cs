using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class Parameter : IParameter
	{
		private string _name;

		public Parameter(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentShouldNotBeNullOrEmptyException(nameof(name));
			}

			_name = name;
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

		public string RenderValue(IRenderer renderer) => RenderParameter(renderer);
		public string RenderExpression(IRenderer renderer) => RenderParameter(renderer);
		public string RenderParameter(IRenderer renderer) => renderer.RenderParameter(this);
	}
}
