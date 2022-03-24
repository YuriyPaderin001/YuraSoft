using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class StringValue : IValue
	{
		private string _value;

		public StringValue(string value)
		{
			_value = value ?? throw new ArgumentShouldNotBeNullException(nameof(value));
		}

		public static implicit operator StringValue(string value) => new StringValue(value);

		public string Value 
		{ 
			get => _value; 
			set => _value = value ?? throw new ArgumentShouldNotBeNullException(nameof(Value)); 
		}

		public string RenderValue(IRenderer renderer) => renderer.RenderValue(this);
		public string RenderExpression(IRenderer renderer) => RenderValue(renderer);
	}
}
