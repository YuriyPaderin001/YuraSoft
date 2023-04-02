﻿using System;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Columns
{
	public class ExpressionColumnTests : TestsBase
	{
		[Fact]
		public void Constructor_IExpression_Success()
		{
			// Arrange
			IExpression expression = NewExpression();

			// Act
			ExpressionColumn expressionColumn = new ExpressionColumn(expression);

			// Assert
			Assert.Equal(expression, expressionColumn.Expression);
			Assert.Null(expressionColumn.Name);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("test_name")]
		public void Constructor_IExpressionAndName_Success(string? name)
		{
			// Arrange
			IExpression expression = NewExpression();

			// Act
			ExpressionColumn expressionColumn = new ExpressionColumn(expression, name);

			// Assert
			Assert.Equal(expression, expressionColumn.Expression);

			if (string.IsNullOrEmpty(name))
			{
				Assert.Null(expressionColumn.Name);
			}
			else
			{
				Assert.Equal(name, expressionColumn.Name);
			}
		}

		[Fact]
		public void Constructor_NullIExpression_ThrowsArgumentNullException()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new ExpressionColumn(expression: null!));
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("test_name")]
		public void Constructor_NullIExpressionAndName_ThrowsArgumentNullException(string? name)
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new ExpressionColumn(expression: null!, name));
		}

		[Fact]
		public void SetExpression_IExpression_Success()
		{
			// Arrange
			const string name = "test_name";
			ExpressionColumn expressionColumn = new ExpressionColumn(NewExpression(), name);
			IExpression expression = NewExpression();

			// Act
			expressionColumn.Expression = expression;

			// Assert
			Assert.Equal(expression, expressionColumn.Expression);
			Assert.Equal(name, expressionColumn.Name);
		}

		[Fact]
		public void SetExpression_NullIExpression_ThrowsArgumentNullException()
		{
			// Arrange
			ExpressionColumn expressionColumn = new ExpressionColumn(NewExpression(), "test_name");

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => expressionColumn.Expression = null!);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("test_new_name")]
		public void SetName_String_Success(string? name)
		{
			// Arrange
			IExpression expression = NewExpression();
			ExpressionColumn expressionColumn = new ExpressionColumn(expression, "test_name");

			// Act
			expressionColumn.Name = name;

			// Assert
			Assert.Equal(expression, expressionColumn.Expression);

			if (string.IsNullOrEmpty(name))
			{
				Assert.Null(expressionColumn.Name);
			}
			else
			{
				Assert.Equal(name, expressionColumn.Name);
			}
		}

		[Fact]
		public void RenderColumn_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			ExpressionColumn expressionColumn = new ExpressionColumn(NewExpression(), "test_name");

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderColumn(It.IsAny<ExpressionColumn>(), It.IsAny<StringBuilder>())).Callback((ExpressionColumn value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			expressionColumn.RenderColumn(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderColumn_Renderer_ReturnsSql()
		{
			// Arrange
			ExpressionColumn expressionColumn = new ExpressionColumn(NewExpression(), "test_name");

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderColumn(It.IsAny<ExpressionColumn>(), It.IsAny<StringBuilder>())).Callback((ExpressionColumn value, StringBuilder sql) => sql.Append(expectedSql));
			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = expressionColumn.RenderColumn(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderIdentificator_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			ExpressionColumn expressionColumn = new ExpressionColumn(NewExpression(), "test_name");

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderIdentificator(It.IsAny<ExpressionColumn>(), It.IsAny<StringBuilder>())).Callback((ExpressionColumn value, StringBuilder sql) => sql.Append(expectedSql));

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			expressionColumn.RenderIdentificator(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderIdentificator_Renderer_ReturnsSql()
		{
			// Arrange
			ExpressionColumn expressionColumn = new ExpressionColumn(NewExpression(), "test_name");

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderIdentificator(It.IsAny<ExpressionColumn>(), It.IsAny<StringBuilder>())).Callback((ExpressionColumn value, StringBuilder sql) => sql.Append(expectedSql));

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = expressionColumn.RenderIdentificator(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			ExpressionColumn expressionColumn = new ExpressionColumn(NewExpression(), "test_name");

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderIdentificator(It.IsAny<ExpressionColumn>(), It.IsAny<StringBuilder>())).Callback((ExpressionColumn value, StringBuilder sql) => sql.Append(expectedSql));

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			expressionColumn.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderValue_Renderer_ReturnsSql()
		{
			// Arrange
			ExpressionColumn expressionColumn = new ExpressionColumn(NewExpression(), "test_name");

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderIdentificator(It.IsAny<ExpressionColumn>(), It.IsAny<StringBuilder>())).Callback((ExpressionColumn value, StringBuilder sql) => sql.Append(expectedSql));

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = expressionColumn.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}
	}
}
