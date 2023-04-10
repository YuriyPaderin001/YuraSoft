using System.Text;

namespace YuraSoft.QueryBuilder.Common
{
    public abstract class Column : Expression, IColumn, IIdentificator
    {
        public override void RenderExpression(IRenderer renderer, StringBuilder sql) =>
            RenderIdentificator(renderer, sql);

        public string RenderIdentificator(IRenderer renderer)
        {
            StringBuilder sql = new StringBuilder();
            RenderIdentificator(renderer, sql);

            return sql.ToString();
        }

        public abstract void RenderIdentificator(IRenderer renderer, StringBuilder sql);
        
        public string RenderColumn(IRenderer renderer)
        {
            StringBuilder sql = new StringBuilder();
            RenderColumn(renderer, sql);

            return sql.ToString();
        }
        
        public abstract void RenderColumn(IRenderer renderer, StringBuilder sql);
    }
}
