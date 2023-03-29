using System;
using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class Delete : IQuery
	{
		#region Fields

		private ISource _source;

		#endregion Fields

		#region Constructors

		public Delete(string name) : this(name, alias: null, schema: null)
		{
		}

		public Delete(string name, string? schema) : this(name, alias: null, schema)
		{
		}

		public Delete(string name, string? alias, string? schema)
		{
			Validator.ThrowIfArgumentIsNullOrEmpty(name, nameof(name));

			_source = new Table(name, alias, schema);
		}

		public Delete(Table table)
		{
			_source = Validator.ThrowIfArgumentIsNull(table, nameof(table));
		}

		#endregion Constructors

		#region Properties

		public ISource Source 
		{ 
			get => _source; 
			set => _source = Validator.ThrowIfArgumentIsNull(value, nameof(Source));
		}

		public ICondition? Condition { get; set; }

		#endregion Properties

		#region Methods

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

		#endregion Methods
	}
}
