using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class OrderBy : IOrderBy
	{
		private IColumn _column;

		public OrderBy(IColumn column, OrderDirection direction)
		{
			_column = column ?? throw new ArgumentShouldNotBeNullException(nameof(column));
			Direction = direction;
		}

		public IColumn Column 
		{ 
			get => _column; 
			set => _column = value ?? throw new ArgumentShouldNotBeNullException(nameof(Column)); 
		}

		public virtual OrderDirection Direction { get; set; }

		public string RenderOrderBy(IRenderer renderer) => renderer.RenderOrderBy(this);
	}
}
