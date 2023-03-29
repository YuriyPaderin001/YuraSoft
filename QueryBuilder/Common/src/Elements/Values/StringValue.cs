using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class StringValue : Value<string>
	{
		public StringValue(string value) : base(value)
		{
		}

		public static implicit operator StringValue(string value) => new StringValue(value);

		public override void RenderValue(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderValue(this, stringBuilder);

		protected override string Validate(string data, string parameterName) => Guard.ThrowIfNull(data, parameterName);
	}
}
