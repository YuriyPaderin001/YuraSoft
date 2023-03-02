using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
    public class Distinct : IDistinct
    {
        public void RenderDistinct(IRenderer renderer)
        {
            StringBuilder query = new StringBuilder();
            RenderDistinct(renderer, query);

            query.ToString();
        }

        public virtual void RenderDistinct(IRenderer renderer, StringBuilder query) =>
          renderer.RenderDistinct(this, query);
    }
}
