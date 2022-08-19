using System.Text;

using YuraSoft.QueryBuilder.Abstractions;
using YuraSoft.QueryBuilder.Renderers;
using YuraSoft.QueryBuilder.Validation;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class StringValue : Value<string>
	{
		public StringValue(string value) : base(value)
		{
		}

		public static implicit operator StringValue(string value) => new StringValue(value);

		public override void RenderValue(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderValue(this, stringBuilder);

		protected override string Validate(string data, string parameterName) => Validator.ThrowIfArgumentIsNull(data, parameterName);
	}
}
