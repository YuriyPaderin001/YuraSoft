using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class CoalesceFunction : ColumnFunction
	{
		private IExpression _defaultValue;

		public CoalesceFunction(IColumn column, IExpression defaultValue) : base(column)
		{
			_defaultValue = Validator.ThrowIfArgumentIsNull(defaultValue, nameof(defaultValue));
		}

		public IExpression DefaultValue 
		{ 
			get => _defaultValue;
			set => _defaultValue = Validator.ThrowIfArgumentIsNull(value, nameof(DefaultValue));
		}

		public override void RenderFunction(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderFunction(this, stringBuilder);
	}
}
