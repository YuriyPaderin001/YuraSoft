using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
	public class Int32Value : DataValue<int>
	{
		public Int32Value(int value) : base(value)
		{
		}

		public static implicit operator Int32Value(int value) => new Int32Value(value);

		public override void RenderValue(IRenderer renderer, StringBuilder sql) => renderer.RenderValue(this, sql);
	}
}
