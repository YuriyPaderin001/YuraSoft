using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public abstract class ConditionalJoin : Join
	{
		private ICondition _condition;

		public ConditionalJoin(ISource source, ICondition condition) : base(source)
		{
			_condition = Guard.ThrowIfNull(condition, nameof(condition));
		}

		public ICondition Condition
		{
			get => _condition;
			set => _condition = Guard.ThrowIfNull(value, nameof(Condition));
		}
	}
}
