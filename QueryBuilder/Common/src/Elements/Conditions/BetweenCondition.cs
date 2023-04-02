using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
    public class BetweenCondition : UnaryCondition
    {
        private IExpression _lessExpression;
        private IExpression _hightExpression;

        public BetweenCondition(IExpression expression, IExpression lessExpression, IExpression hightExpression) : base(expression)
        {
            _lessExpression = Guard.ThrowIfNull(lessExpression, nameof(lessExpression));
            _hightExpression = Guard.ThrowIfNull(hightExpression, nameof(hightExpression));
        }

        public IExpression LessExpression
        {
            get => _lessExpression;
            set => _lessExpression = Guard.ThrowIfNull(value, nameof(LessExpression));
        }

        public IExpression HightExpression
        {
            get => _hightExpression;
            set => _hightExpression = Guard.ThrowIfNull(value, nameof(HightExpression));
        }

        public override void RenderCondition(IRenderer renderer, StringBuilder sql) => renderer.RenderCondition(this, sql);
    }
}
