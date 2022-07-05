using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class StringValue : Value<string>
	{
		public StringValue(string value) : base(value)
		{
		}

		public static implicit operator StringValue(string value) => new StringValue(value);

		protected override void Validate(string data, string parameterName)
		{
			if (data == null)
			{
				throw new ArgumentShouldNotBeNullException(parameterName);
			}
		}

		public override string RenderValue(IRenderer renderer) => renderer.RenderValue(this);
	}
}
