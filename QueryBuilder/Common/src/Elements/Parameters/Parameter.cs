using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class Parameter : Value, IParameter
	{
		private string _name;

		public Parameter(string name)
		{
			_name = Guard.ThrowIfNullOrEmpty(name, nameof(name));
		}

		public string Name
		{
			get => _name;
			set => _name = Guard.ThrowIfNullOrEmpty(value, nameof(Name));
		}

		public override void RenderValue(IRenderer renderer, StringBuilder sql) => 
			RenderParameter(renderer, sql);

        public override void RenderExpression(IRenderer renderer, StringBuilder sql) => 
			RenderParameter(renderer, sql);
		
		public string RenderParameter(IRenderer renderer)
		{
			StringBuilder sql = new StringBuilder();
			RenderParameter(renderer, sql);

			return sql.ToString();
		}

		public virtual void RenderParameter(IRenderer renderer, StringBuilder sql) => 
			renderer.RenderParameter(this, sql);
	}
}
