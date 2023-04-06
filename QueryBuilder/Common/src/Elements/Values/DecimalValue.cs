using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public class DecimalValue : DataValue<decimal>
	{
		public DecimalValue(decimal value) : base(value)
		{
		}

		public static implicit operator DecimalValue(decimal value) => new DecimalValue(value);

		public override void RenderValue(IRenderer renderer, StringBuilder sql) => renderer.RenderValue(this, sql);
	}
}
