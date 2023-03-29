using System;
using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;
using YuraSoft.QueryBuilder.Validation;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class SimpleCaseExpression : IExpression
	{
		private IExpression _expression;
		private List<Tuple<IExpression, IExpression>> _whenThens;

		public SimpleCaseExpression(IExpression expression, IEnumerable<Tuple<IExpression, IExpression>> whenThens, IExpression? @else = null)
		{
			_expression = Validator.ThrowIfArgumentIsNull(expression, nameof(expression));
			_whenThens = new List<Tuple<IExpression, IExpression>>(Validator.ThrowIfArgumentIsNullOrEmpty(whenThens, nameof(whenThens)));
			Else = @else;
		}

		public IExpression Expression
		{
			get => _expression;
			set => _expression = Validator.ThrowIfArgumentIsNull(value, nameof(Expression));
		}

		public List<Tuple<IExpression, IExpression>> WhenThens
		{
			get => _whenThens;
			set => _whenThens = Validator.ThrowIfArgumentIsNullOrEmpty(value, nameof(WhenThens));
		}

		public IExpression? Else { get; set; }

		public string RenderExpression(IRenderer renderer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RenderExpression(renderer, stringBuilder);

			return stringBuilder.ToString();
		}

		public void RenderExpression(IRenderer renderer, StringBuilder stringBuilder) => renderer.RenderExpression(this, stringBuilder);
	}
}
