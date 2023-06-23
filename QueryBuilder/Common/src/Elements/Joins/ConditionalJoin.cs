using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public abstract class ConditionalJoin : Join
	{
		public ConditionalJoin(ISource source, ICondition condition) : base(source) =>
			Condition = Guard.ThrowIfNull(condition, nameof(condition));

		public readonly ICondition Condition;
	}
}
