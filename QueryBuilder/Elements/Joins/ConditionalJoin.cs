using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;

namespace YuraSoft.QueryBuilder
{
	public abstract class ConditionalJoin : Join
	{
		private ICondition _condition;

		public ConditionalJoin(ISource source, ICondition condition) : base(source)
		{
			_condition = condition ?? throw new ArgumentShouldNotBeNullException(nameof(condition));
		}

		public ICondition Condition
		{
			get => _condition;
			set => _condition = value ?? throw new ArgumentShouldNotBeNullException(nameof(Condition));
		}
	}
}
