using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
    public abstract class Source : ISource, IIdentificator
    {
        public string RenderIdentificator(IRenderer renderer)
        {
            StringBuilder sql = new StringBuilder();
            RenderIdentificator(renderer, sql);

            return sql.ToString();
        }

        public abstract void RenderIdentificator(IRenderer renderer, StringBuilder sql);

        public string RenderSource(IRenderer renderer)
        {
            StringBuilder sql = new StringBuilder();
            RenderSource(renderer, sql);

            return sql.ToString();
        }

        public abstract void RenderSource(IRenderer renderer, StringBuilder sql);
    }
}
