using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
    public class Distinct : IDistinct
    {
        public string RenderDistinct(IRenderer renderer)
        {
            StringBuilder sql = new StringBuilder();
            RenderDistinct(renderer, sql);

            return sql.ToString();
        }

        public virtual void RenderDistinct(IRenderer renderer, StringBuilder sql) =>
          renderer.RenderDistinct(this, sql);
    }
}
