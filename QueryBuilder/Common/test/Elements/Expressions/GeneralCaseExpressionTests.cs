using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Expressions
{
	public class GeneralCaseExpressionTests : TestsBase
	{
		[Theory]
		[InlineData(1)]
		[InlineData(3)]
		public void Constructor_WhenThens_Success(int length)
		{
			// Arrange
			List<Tuple<ICondition, IExpression>> whenThens = NewGeneralWhenThenList(length);

			// Act
			GeneralCaseExpression generalCaseExpression = new GeneralCaseExpression(whenThens);

			// Assert
			Assert.Equal(whenThens, generalCaseExpression.WhenThens);
			Assert.Null(generalCaseExpression.Else);
		}

		[Theory]
		[InlineData(1)]
		[InlineData(3)]
		public void Constructor_WhenThensAndElse_Success(int length) =>
		  Constructor_WhenThensAndElse_Success_Base(length, NewExpression());

		[Theory]
		[InlineData(1)]
		[InlineData(3)]
		public void Constructor_WhenThensAndNullElse_Success(int length) =>
		  Constructor_WhenThensAndElse_Success_Base(length, @else: null);

		[Fact]
		public void Constructor_EmptyWhenThens_ThrowsArgumentOutOfRangeException() =>
		  Constructor_WhenThens_ThrowsException<ArgumentOutOfRangeException>(NewGeneralEmptyWhenThenList());

		[Fact]
		public void Constructor_NullWhenThens_ThrowsArgumentNullException() =>
		  Constructor_WhenThens_ThrowsException<ArgumentNullException>(whenThens: null);

		[Fact]
		public void Constructor_EmptyWhenThensAndElse_ThrowsArgumentOutOfRangeException() =>
		  Constructor_WhenThensAndElse_ThrowsException<ArgumentOutOfRangeException>(NewGeneralEmptyWhenThenList(), NewExpression());

		[Fact]
		public void Constructor_EmptyWhenThensAndNullElse_ThrowsArgumentOutOfRangeException() =>
		  Constructor_WhenThensAndElse_ThrowsException<ArgumentOutOfRangeException>(NewGeneralEmptyWhenThenList(), @else: null);

		[Fact]
		public void Constructor_NullWhenThensAndElse_ThrowsArgumentNullException() =>
		  Constructor_WhenThensAndElse_ThrowsException<ArgumentNullException>(whenThens: null, NewExpression());

		[Fact]
		public void Constructor_NullWhenThensAndNullElse_ThrowsArgumentNullException() =>
		  Constructor_WhenThensAndElse_ThrowsException<ArgumentNullException>(whenThens: null, @else: null);

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			GeneralCaseExpression generalCaseExpression = new GeneralCaseExpression(NewGeneralWhenThenList(1), @else: NewExpression());

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock
			  .Setup(ca => ca.RenderExpression(It.IsAny<GeneralCaseExpression>(), It.IsAny<StringBuilder>()))
			  .Callback((GeneralCaseExpression expression, StringBuilder sql) =>
			  {
				  sql.Append(expectedSql);
			  });

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			generalCaseExpression.RenderExpression(renderer, sql);

			// Assert
			Assert.NotNull(sql);
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			GeneralCaseExpression generalCaseExpression = new GeneralCaseExpression(NewGeneralWhenThenList(1), @else: NewExpression());

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock
			  .Setup(ca => ca.RenderExpression(It.IsAny<GeneralCaseExpression>(), It.IsAny<StringBuilder>()))
			  .Callback((GeneralCaseExpression expression, StringBuilder sql) =>
			  {
				  sql.Append(expectedSql);
			  });

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = generalCaseExpression.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_WhenThensAndElse_Success_Base(int length, IExpression? @else)
		{
			// Arrange
			List<Tuple<ICondition, IExpression>> whenThens = NewGeneralWhenThenList(length);

			// Act
			GeneralCaseExpression generalCaseExpression = new GeneralCaseExpression(whenThens, @else);

			// Assert
			Assert.Equal(whenThens, generalCaseExpression.WhenThens);

			if (@else == null)
			{
				Assert.Null(generalCaseExpression.Else);
			}
			else
			{
				Assert.Equal(@else, generalCaseExpression.Else);
			}
		}

		private void Constructor_WhenThens_ThrowsException<TException>(List<Tuple<ICondition, IExpression>>? whenThens) where TException : Exception
		{
			// Act & Assert
			Assert.Throws<TException>(() => new GeneralCaseExpression(whenThens!));
		}

		private void Constructor_WhenThensAndElse_ThrowsException<TException>(List<Tuple<ICondition, IExpression>>? whenThens, IExpression? @else) where TException : Exception
		{
			// Act & Assert
			Assert.Throws<TException>(() => new GeneralCaseExpression(whenThens!, @else));
		}
	}
}
