using System;
using System.Collections.Generic;
using System.Text;

using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;
using YuraSoft.QueryBuilder.Validation;

namespace YuraSoft.QueryBuilder
{
	public class GeneralCaseExpression : IExpression
	{
		private List<Tuple<ICondition, IExpression>> _whenThens;

		public GeneralCaseExpression(IEnumerable<Tuple<ICondition, IExpression>> whenThens, IExpression? @else = null)
		{
			_whenThens = new List<Tuple<ICondition, IExpression>>(Validator.ThrowIfArgumentIsNullOrEmpty(whenThens, nameof(whenThens)));
			Else = @else;
		}

		public List<Tuple<ICondition, IExpression>> WhenThens
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
