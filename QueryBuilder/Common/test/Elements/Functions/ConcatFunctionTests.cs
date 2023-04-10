using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Functions
{
	public class ConcatFunctionTests : TestsBase
	{
		[Theory]
		[InlineData(1)]
		[InlineData(3)]
		public void Constructor_Values_Success(int length)
		{
			// Arrange
			List<IExpression> expressions = NewExpressionList(length);

			// Act
			ConcatFunction concatFunction = new ConcatFunction(expressions);

			// Assert
			Assert.Equal(expressions, concatFunction.Values);
		}

		[Fact]
		public void Constructor_EmptyValues_ThrowsArgumentOutOfRangeException() =>
			Constructor_Values_ThrowsException<ArgumentOutOfRangeException>(values: NewEmptyExpressionList());

		[Fact]
		public void Constructor_NullValues_ThrowsArgumentNullException() =>
			Constructor_Values_ThrowsException<ArgumentNullException>(values: null);

		[Theory]
		[InlineData(1)]
		[InlineData(3)]
		public void SetValues_ExpressionList_Success(int length)
		{
			// Arrange
			ConcatFunction concatFunction = NewConcatFunction();
			List<IExpression> expressions = NewExpressionList(length);

			// Act
			concatFunction.Values = expressions;

			// Assert
			Assert.Equal(expressions, concatFunction.Values);
		}

		[Fact]
		public void SetValues_EmptyExpressionList_ThrowsArgumentOutOfRangeException() =>
			SetValues_ExpressionList_ThrowsException<ArgumentOutOfRangeException>(values: NewEmptyExpressionList());

		[Fact]
		public void SetExpression_NullExpression_ThrowsArgumentNullException() =>
			SetValues_ExpressionList_ThrowsException<ArgumentNullException>(values: null);

		[Fact]
		public void RenderFunction_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			ConcatFunction concatFunction = NewConcatFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<ConcatFunction>(), It.IsAny<StringBuilder>())).Callback((ConcatFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			concatFunction.RenderFunction(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderFunction_Renderer_ReturnsSql()
		{
			// Arrange
			ConcatFunction concatFunction = NewConcatFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<ConcatFunction>(), It.IsAny<StringBuilder>())).Callback((ConcatFunction value, StringBuilder sql) => sql.Append(expectedSql));
			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = concatFunction.RenderFunction(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			ConcatFunction concatFunction = NewConcatFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<ConcatFunction>(), It.IsAny<StringBuilder>())).Callback((ConcatFunction value, StringBuilder sql) => sql.Append(expectedSql));

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			concatFunction.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			ConcatFunction concatFunction = NewConcatFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<ConcatFunction>(), It.IsAny<StringBuilder>())).Callback((ConcatFunction value, StringBuilder sql) => sql.Append(expectedSql));

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = concatFunction.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_Values_ThrowsException<TException>(List<IExpression>? values) where TException: Exception
		{
			// Act & Assert
			Assert.Throws<TException>(() => new ConcatFunction(values!));
		}

		private void SetValues_ExpressionList_ThrowsException<TException>(List<IExpression>? values) where TException: Exception
		{
			// Arrange
			ConcatFunction concatFunction = NewConcatFunction();

			// Act & Assert
			Assert.Throws<TException>(() => concatFunction.Values = values!);
		}

		private ConcatFunction NewConcatFunction(List<IExpression>? values = null) => 
			new ConcatFunction(values ?? NewExpressionList(3));
	}
}
