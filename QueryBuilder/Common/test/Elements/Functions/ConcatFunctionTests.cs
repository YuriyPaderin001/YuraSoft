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

		private ConcatFunction NewConcatFunction(List<IExpression>? values = null) => 
			new ConcatFunction(values ?? NewExpressionList(3));
	}
}
