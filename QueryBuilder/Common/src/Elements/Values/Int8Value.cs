using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public class Int8Value : DataValue<sbyte>
	{
		public Int8Value(sbyte value) : base(value)
		{
		}

		public static implicit operator Int8Value(sbyte value) => new Int8Value(value);

		public override void RenderValue(IRenderer renderer, StringBuilder sql) => renderer.RenderValue(this, sql);
	}
}
