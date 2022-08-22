using System;
using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;
using YuraSoft.QueryBuilder.Renderers;

namespace YuraSoft.QueryBuilder
{
	public class Delete : IQuery
	{
		private ISource _source;
		private ICondition? _condition;

		public Delete(string name, string? alias = null, string? schema = null)
		{
			Validator.ThrowIfArgumentIsNullOrEmpty(name, nameof(name));

			_source = new Table(name, alias, schema);
		}

		public Delete(Table table)
		{
			_source = Validator.ThrowIfArgumentIsNull(table, nameof(table));
		}

		public ISource Source 
		{ 
			get => _source; 
			set => _source = Validator.ThrowIfArgumentIsNull(value, nameof(Source));
		}

		public ICondition? Condition
		{
			get => _condition;
			set => _condition = value;
		}

		public virtual Delete Where(ICondition? condition)
		{
			Condition = condition;

			return this;
		}

		public virtual Delete Where(Action<ConditionBuilder> buildConditionMethod)
		{
			Validator.ThrowIfArgumentIsNull(buildConditionMethod, nameof(buildConditionMethod));

			ConditionBuilder builder = new ConditionBuilder();
			buildConditionMethod.Invoke(builder);

			Condition = builder.Build();

			return this;
		}

		public string RenderQuery(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderQuery(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public virtual void RenderQuery(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderQuery(this, stringBuilder);
	}
}
