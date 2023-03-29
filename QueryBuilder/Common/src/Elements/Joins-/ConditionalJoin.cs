using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public abstract class ConditionalJoin : Join
	{
		private ICondition _condition;

		public ConditionalJoin(ISource source, ICondition condition) : base(source)
		{
			_condition = Validator.ThrowIfArgumentIsNull(condition, nameof(condition));
		}

		public ICondition Condition
		{
			get => _condition;
			set => _condition = Validator.ThrowIfArgumentIsNull(value, nameof(Condition));
		}
	}
}
