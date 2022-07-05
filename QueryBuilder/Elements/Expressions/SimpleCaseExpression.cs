using System;
using System.Collections.Generic;
using System.Linq;

using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

#nullable enable

namespace YuraSoft.QueryBuilder
{
	public class SimpleCaseExpression : IExpression
	{
		private IExpression _expression;
		private List<Tuple<IExpression, IExpression>> _whenThens;

		public SimpleCaseExpression(IExpression expression, IEnumerable<Tuple<IExpression, IExpression>> whenThens, IExpression? @else = null)
		{
			_expression = expression ?? throw new ArgumentShouldNotBeNullException(nameof(expression));
			
			if (whenThens == null)
			{
				throw new ArgumentShouldNotBeNullException(nameof(whenThens));
			} 
			else if (!whenThens.Any())
			{
				throw new CollectionShouldNotBeEmptyException(nameof(whenThens));
			}

			_whenThens = new List<Tuple<IExpression, IExpression>>(whenThens);
			Else = @else;
		}

		public IExpression Expression 
		{ 
			get => _expression; 
			set => _expression = value ?? throw new ArgumentShouldNotBeNullException(nameof(Expression)); 
		}

		public List<Tuple<IExpression, IExpression>> WhenThens 
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
