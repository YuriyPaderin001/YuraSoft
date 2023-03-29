using System;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Expressions
{
	public class PlusExpressionTests
	{
		public void Constructor_TwoExpressions_Success()
		{
			// Arrange
			IExpression expression1 = new Mock<IExpression>().Object;
			IExpression expression2 = new Mock<IExpression>().Object;

			IEnumerable<IExpression> expressions = new[] { expression1, expression2 };

			// Act
			PlusExpression plusExpression = new PlusExpression(expressions);

			// Assert
			Assert.NotNull(plusExpression.Expressions);
			Assert.Equal(2, plusExpression.Expressions.Count);
			Assert.Equal(expression1, plusExpression.Expressions[0]);
			Assert.Equal(expression2, plusExpression.Expressions[1]);
		}

		public void Constructor_MoreThanTwoExpressions_Success()
		{
			// Arrange
			IExpression expression1 = new Mock<IExpression>().Object;
			IExpression expression2 = new Mock<IExpression>().Object;
			IExpression expression3 = new Mock<IExpression>().Object;

			IEnumerable<IExpression> expressions = new[] { expression1, expression2, expression3 };

			// Act
			PlusExpression plusExpression = new PlusExpression(expressions);

			// Assert
			Assert.NotNull(plusExpression.Expressions);
			Assert.Equal(3, plusExpression.Expressions.Count);
			Assert.Equal(expression1, plusExpression.Expressions[0]);
			Assert.Equal(expression2, plusExpression.Expressions[1]);
			Assert.Equal(expression3, plusExpression.Expressions[2]);
		}

		public void Constructor_OneExpression_ThrowsArgumentOutOfRangeException()
		{
			// Arrange
			IExpression expression = new Mock<IExpression>().Object;

			IEnumerable<IExpression> expressions = new[] { expression };

			// Act
			Action action = () => new PlusExpression(expressions);

			// Assert
			Assert.Throws<ArgumentOutOfRangeException>(action);
		}
	}
}
