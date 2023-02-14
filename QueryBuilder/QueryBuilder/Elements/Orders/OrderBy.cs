using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class OrderBy : IOrderBy
	{
		private IColumn _column;

		public OrderBy(IColumn column, OrderDirection direction)
		{
			_column = Validator.ThrowIfArgumentIsNull(column, nameof(column));
			Direction = direction;
		}

		public IColumn Column 
		{ 
			get => _column; 
			set => _column = Validator.ThrowIfArgumentIsNull(value, nameof(Column));
		}

		public virtual OrderDirection Direction { get; set; }

		public string RenderOrderBy(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderOrderBy(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public void RenderOrderBy(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderOrderBy(this, stringBuilder);
	}
}
