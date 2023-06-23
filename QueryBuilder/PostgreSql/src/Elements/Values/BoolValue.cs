using System.Text;
using YuraSoft.QueryBuilder.Common;

namespace YuraSoft.QueryBuilder.PostgreSql
{
    public class BoolValue : DataValue<bool>
    {
        public BoolValue(bool value) : base(value)
        {
        }

        public override void RenderValue(IRenderer renderer, StringBuilder sql) =>
            renderer.RenderValue(this, sql);
    }
}
