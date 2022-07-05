using System;
using System.Collections.Generic;
using System.Linq;

using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class GeneralCaseExpression : IExpression
	{
		private List<Tuple<ICondition, IExpression>> _whenThens;

		public GeneralCaseExpression(IEnumerable<Tuple<ICondition, IExpression>> whenThens, IExpression? @else = null)
		{
			if (whenThens == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(whenThens));
			} 
			else if (!whenThens.Any())
			{
				throw new CollectionShouldNotBeEmptyException(nameof(whenThens));
			}

			_whenThens = new List<Tuple<ICondition, IExpression>>(whenThens);
			Else = @else;
		}

		public List<Tuple<ICondition, IExpression>> WhenThens 
		{ 
			get => _whenThens; 
			set
			{
				if (value == null)
				{
					throw new ArgumentShouldNotBeNullException(nameof(WhenThens));
				}
				else if (!value.Any())
				{
					throw new CollectionShouldNotBeEmptyException(nameof(WhenThens));
				}

				_whenThens = value;
			} 
		}

		public IExpression? Else { get; set; }

		public string RenderExpression(IRenderer renderer) => renderer.RenderExpression(this);
	}
}
