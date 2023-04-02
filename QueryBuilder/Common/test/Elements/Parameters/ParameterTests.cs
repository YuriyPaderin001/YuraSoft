using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Parameters
{
	public class ParameterTests
	{
		[Fact]
		public void Constructor_Name_Success()
		{
			// Arrange
			string name = "test_name";

			// Act
			Parameter parameter = new Parameter(name);

			// Assert
			Assert.Equal(name, parameter.Name);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Constructor_NullOrEmptyName_ThrowsArgumentException(string? name)
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new Parameter(name!));
		}

		[Fact]
		public void SetName_String_Success()
		{
			// Arrange
			Parameter parameter = NewParameter();
			const string name = "new_test_name";

			// Act
			parameter.Name = name;

			// Assert
			Assert.Equal(name, parameter.Name);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void SetName_NullOrEmptyString_ThrowsArgumentException(string? name)
		{
			// Arrange
			Parameter parameter = NewParameter();

			// Act & Assert
			Assert.Throws<ArgumentException>(() => parameter.Name = name!);
		}

		[Fact]
		public void RenderParameter_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			Parameter parameter = NewParameter();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderParameter(It.IsAny<Parameter>(), It.IsAny<StringBuilder>())).Callback((Parameter value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			parameter.RenderParameter(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderParameter_Renderer_ReturnsSql()
		{
			// Arrange
			Parameter parameter = NewParameter();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderParameter(It.IsAny<Parameter>(), It.IsAny<StringBuilder>())).Callback((Parameter value, StringBuilder sql) => sql.Append(expectedSql));
			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = parameter.RenderParameter(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			Parameter parameter = NewParameter();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderParameter(It.IsAny<Parameter>(), It.IsAny<StringBuilder>())).Callback((Parameter value, StringBuilder sql) => sql.Append(expectedSql));

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			parameter.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderExpression_Renderer_ReturnsSql()
		{
			// Arrange
			Parameter parameter = NewParameter();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderParameter(It.IsAny<Parameter>(), It.IsAny<StringBuilder>())).Callback((Parameter value, StringBuilder sql) => sql.Append(expectedSql));

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = parameter.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderValue_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			Parameter parameter = NewParameter();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderParameter(It.IsAny<Parameter>(), It.IsAny<StringBuilder>())).Callback((Parameter value, StringBuilder sql) => sql.Append(expectedSql));

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			parameter.RenderValue(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderValue_Renderer_ReturnsSql()
		{
			// Arrange
			Parameter parameter = NewParameter();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderParameter(It.IsAny<Parameter>(), It.IsAny<StringBuilder>())).Callback((Parameter value, StringBuilder sql) => sql.Append(expectedSql));

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = parameter.RenderValue(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private Parameter NewParameter(string name = "test_name") => new Parameter(name);
	}
}
