using System;
using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common
{
	public class SimpleCaseExpression : IExpression
	{
		private IExpression _expression;
		private List<Tuple<IExpression, IExpression>> _whenThens;

		public SimpleCaseExpression(IExpression expression, IEnumerable<Tuple<IExpression, IExpression>> whenThens, IExpression? @else = null)
		{
			_expression = Guard.ThrowIfNull(expression, nameof(expression));
			_whenThens = new List<Tuple<IExpression, IExpression>>(Guard.ThrowIfNullOrEmpty(whenThens, nameof(whenThens)));
			Else = @else;
		}

		public IExpression Expression
		{
			get => _expression;
			set => _expression = Guard.ThrowIfNull(value, nameof(Expression));
		}

		public List<Tuple<IExpression, IExpression>> WhenThens
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
