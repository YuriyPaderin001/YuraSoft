using System;
using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class GeneralCaseExpression : IExpression
	{
		private List<Tuple<ICondition, IExpression>> _whenThens;

		public GeneralCaseExpression(IEnumerable<Tuple<ICondition, IExpression>> whenThens, IExpression? @else = null)
		{
			_whenThens = new List<Tuple<ICondition, IExpression>>(Guard.ThrowIfNullOrEmpty(whenThens, nameof(whenThens)));
			Else = @else;
		}

		public List<Tuple<ICondition, IExpression>> WhenThens
		{
			get => _whenThens;
			set => _whenThens = Guard.ThrowIfNullOrEmpty(value, nameof(WhenThens));
		}

		public IExpression? Else { get; set; }

		public string RenderExpression(IRenderer renderer)
		{
			StringBuilder sql = new StringBuilder();
			RenderExpression(renderer, sql);

			return sql.ToString();
		}

		public void RenderExpression(IRenderer renderer, StringBuilder sql) => renderer.RenderExpression(this, sql);
	}
}
