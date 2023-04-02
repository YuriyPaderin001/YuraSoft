using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Functions
{
	public class FunctionTests : TestsBase
	{
		[Fact]
		public void Constructor_Name_Success()
		{
			// Arrange
			string name = "test_function";

			// Act
			Function function = new Function(name);

			// Assert
			Assert.Equal(name, function.Name);
			Assert.Null(function.Parameters);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(1)]
		[InlineData(3)]
		public void Constructor_NameAndParameters_Success(int length) =>
			Constructor_NameAndParameters_Success_Base(name: "test_function", parameters: NewExpressionList(length));

		[Fact]
		public void Constructor_NameAndNullParameters_Success() =>
			Constructor_NameAndParameters_Success_Base(name: "test_function", parameters: null);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Constructor_NullOrEmptyNameAndParameters_ThrowsArgumentException(string? name) =>
			Constructor_NameAndParameters_ThrowsException<ArgumentException>(name, 3);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Constructor_NullOrEmptyNameAndNullParameters_ThrowsArgumentException(string? name)
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new Function(name!, parameters: null));
		}

		[Fact]
		public void SetName_String_Success()
		{
			// Arrange
			Function function = NewFunction();
			const string name = "new_test_name";

			// Act
			function.Name = name;

			// Assert
			Assert.Equal(name, function.Name);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void SetName_NullOrEmptyString_ThrowsArgumentException(string? name)
		{
			// Arrange
			Function function = NewFunction();

			// Act & Assert
			Assert.Throws<ArgumentException>(() => function.Name = name!);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(1)]
		[InlineData(3)]
		public void SetParameters_IExpressionList_Success(int length) =>
			SetParameters_IExpressionList_Success_Base(NewExpressionList(length));

		[Fact]
		public void SetParameters_NullIExpressionList_Success() =>
			SetParameters_IExpressionList_Success_Base(parameters: null);

		[Fact]
		public void RenderFunction_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			Function function = NewFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<Function>(), It.IsAny<StringBuilder>())).Callback((Function value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			function.RenderFunction(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderFunction_Renderer_ReturnsSql()
		{
			// Arrange
			Function function = NewFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<Function>(), It.IsAny<StringBuilder>())).Callback((Function value, StringBuilder sql) => sql.Append(expectedSql));
			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = function.RenderFunction(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			Function function = NewFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<Function>(), It.IsAny<StringBuilder>())).Callback((Function value, StringBuilder sql) => sql.Append(expectedSql));

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			function.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			Function function = NewFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<Function>(), It.IsAny<StringBuilder>())).Callback((Function value, StringBuilder sql) => sql.Append(expectedSql));

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = function.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_NameAndParameters_Success_Base(string name, List<IExpression>? parameters)
		{
			// Act
			Function function = new Function(name, parameters);

			// Assert
			Assert.Equal(name, function.Name);

			if (parameters == null)
			{
				Assert.Null(function.Parameters);
			}
			else
			{
				Assert.Equal(parameters, function.Parameters);
			}
		}

		private void Constructor_NameAndParameters_ThrowsException<TException>(string? name, int length) where TException : Exception
		{
			// Act & Assert
			Assert.Throws<TException>(() => new Function(name!, NewExpressionList(length)));
		}

		private void SetParameters_IExpressionList_Success_Base(List<IExpression>? parameters)
		{
			// Arrange
			Function function = NewFunction(parameters: NewExpressionList(3));

			// Act
			function.Parameters = parameters;

			// Assert
			if (parameters == null)
			{
				Assert.Null(function.Parameters);
			}
			else
			{
				Assert.Equal(parameters, function.Parameters);
			}
		}

		private Function NewFunction(string name = "test_function", List<IExpression>? parameters = null) => 
			new Function(name, parameters ?? NewExpressionList(3));
	}
}
