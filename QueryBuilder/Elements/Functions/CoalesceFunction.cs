using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class CoalesceFunction : ColumnFunction
	{
		private IExpression _defaultValue;

		public CoalesceFunction(IColumn column, IExpression defaultValue) : base(column)
		{
			_defaultValue = defaultValue ?? throw new ArgumentShouldNotBeNullException(nameof(defaultValue));
		}

		public IExpression DefaultValue 
		{ 
			get => _defaultValue;
			set => _defaultValue = value ?? throw new ArgumentShouldNotBeNullException(nameof(DefaultValue));
		}

		public override string RenderFunction(IRenderer renderer) => renderer.RenderFunction(this);
	}
}
