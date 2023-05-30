using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Functions
{
	public class NativeFunctionTests : TestsBase
	{
		[Fact]
		public void Constructor_Name_Success()
		{
			// Arrange
			const string name = "test_name";

			// Act
			NativeFunction function = new NativeFunction(name);

			// Assert
			Assert.Equal(name, function.Name);
			Assert.Null(function.Parameters);
		}

		[Fact]
		public void Constructor_NameAndNullParameters_Success()
		{
			// Arrange
			const string name = "test_name";

			// Act
			NativeFunction function = new NativeFunction(name, parameters: null);

			// Assert
			Assert.Equal(name, function.Name);
			Assert.Null(function.Parameters);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(1)]
		[InlineData(3)]
		public void Constructor_NameAndParameters_Success(int parametersCount)
		{
			// Arrange
			const string name = "test_name";
			List<IExpression> parameters = NewExpressionList(parametersCount);

			// Act
			NativeFunction function = new NativeFunction(name, parameters);

			// Assert
			Assert.Equal(name, function.Name);
			Assert.Equal(parameters, function.Parameters);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Constructor_NullOrEmptyName_ThrowArgumentException(string functionName) =>
			Assert.Throws<ArgumentException>(() => new NativeFunction(functionName));

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Constructor_NullOrEmptyNameAndNullParameters_ThrowArgumentException(string functionName) =>
			Assert.Throws<ArgumentException>(() => new NativeFunction(functionName));

		[Theory]
		[InlineData(null, 0)]
		[InlineData(null, 1)]
		[InlineData(null, 3)]
        [InlineData("", 0)]
        [InlineData("", 1)]
        [InlineData("", 3)]
        public void Constructor_NullOrEmptyNameAndParameters_ThrowArgumentException(string functionName, int parametersCount) =>
			Assert.Throws<ArgumentException>(() => new NativeFunction(functionName, parameters: NewExpressionList(parametersCount)));

		[Fact]
		public void RenderFunction_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			NativeFunction function = NewNativeFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<NativeFunction>(), It.IsAny<StringBuilder>())).Callback((NativeFunction value, StringBuilder sql) =>
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
			NativeFunction function = NewNativeFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<NativeFunction>(), It.IsAny<StringBuilder>())).Callback((NativeFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

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
			NativeFunction function = NewNativeFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<NativeFunction>(), It.IsAny<StringBuilder>())).Callback((NativeFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

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
			NativeFunction function = NewNativeFunction();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderFunction(It.IsAny<NativeFunction>(), It.IsAny<StringBuilder>())).Callback((NativeFunction value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = function.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private NativeFunction NewNativeFunction(string functionName = "test_name", List<IExpression>? parameters = null) => 
			new NativeFunction(functionName, parameters ?? NewExpressionList(3));
	}
}
