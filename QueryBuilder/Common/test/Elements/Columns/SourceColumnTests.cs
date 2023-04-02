using System;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Columns
{
	public class SourceColumnTests : TestsBase
	{
		[Fact]
		public void Constructor_String_Success()
		{
			// Arrange
			const string name = "test_name";

			// Act
			SourceColumn sourceColumn = new SourceColumn(name);

			// Assert
			Assert.Equal(name, sourceColumn.Name);
			Assert.Null(sourceColumn.Alias);
			Assert.Null(sourceColumn.Source);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Constructor_NullOrEmptyString_ThrowsArgumentException(string? name)
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new SourceColumn(name!));
		}

		[Fact]
		public void Constructor_StringAndISource_Success()
		{
			// Arrange
			string name = "test_name";
			ISource source = NewSource();

			// Act
			SourceColumn sourceColumn = new SourceColumn(name, source);

			// Assert
			Assert.Equal(name, sourceColumn.Name);
			Assert.Null(sourceColumn.Alias);
			Assert.Equal(source, sourceColumn.Source);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Constructor_NullOrEmptyStringAndISource_ThrowsArgumentException(string? name) =>
			Constructor_StringAndISource_ThrowsArgumentException(name, NewSource());

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Constructor_NullOrEmptyStringAndNullISource_ThrowsArgumentException(string? name) =>
			Constructor_StringAndISource_ThrowsArgumentException(name, source: null);

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("test_alias")]
		public void Constructor_StringAndString_Success(string? alias)
		{
			// Arrange
			string name = "test_name";

			// Act
			SourceColumn sourceColumn = new SourceColumn(name, alias);

			// Assert
			Assert.Equal(name, sourceColumn.Name);

			if (string.IsNullOrEmpty(alias))
			{
				Assert.Null(sourceColumn.Alias);
			}
			else
			{
				Assert.Equal(alias, sourceColumn.Alias);
			}

			Assert.Null(sourceColumn.Source);
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "test_alias")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "test_alias")]
		public void Constructor_NullOrEmptyStringAndString_ThrowsArgumentException(string? name, string? alias)
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new SourceColumn(name!, alias));
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("test_alias")]
		public void Constructor_StringAndStringAndISource_Success(string? alias)
		{
			// Arrange
			string name = "test_name";
			ISource source = NewSource();

			// Act
			SourceColumn sourceColumn = new SourceColumn(name, alias, source);

			// Assert
			Assert.Equal(name, sourceColumn.Name);

			if (string.IsNullOrEmpty(alias))
			{
				Assert.Null(sourceColumn.Alias);
			}
			else
			{
				Assert.Equal(alias, sourceColumn.Alias);
			}

			Assert.Equal(source, sourceColumn.Source);
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "test_alias")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "test_alias")]
		public void Constructor_NullOrEmptyStringAndStringAndISource_ThrowsArgumentException(string? name, string? alias) =>
			Constructor_StringAndStringAndISource_ThrowsArgumentException(name, alias, NewSource());

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "test_alias")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "test_alias")]
		public void Constructor_NullOrEmptyStringAndStringAndNullISource_ThrowsArgumentException(string? name, string? alias) =>
			Constructor_StringAndStringAndISource_ThrowsArgumentException(name, alias, source: null);

		[Fact]
		public void SetName_String_Success()
		{
			// Arrange
			string alias = "test_alias";
			ISource source = NewSource();
			SourceColumn sourceColumn = new SourceColumn("test_name", alias, source);
			string name = "test_new_name";

			// Act
			sourceColumn.Name = name;

			// Assert
			Assert.Equal(name, sourceColumn.Name);
			Assert.Equal(alias, sourceColumn.Alias);
			Assert.Equal(source, sourceColumn.Source);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void SetName_NullOrEmptyString_ThrowsArgumentException(string? name)
		{
			// Arrange
			SourceColumn sourceColumn = new SourceColumn("test_name");

			// Act & Assert
			Assert.Throws<ArgumentException>(() => sourceColumn.Name = name!);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void SetAlias_String_Success(string? alias)
		{
			// Arrange
			string name = "test_name";
			ISource source = NewSource();
			SourceColumn sourceColumn = new SourceColumn(name, "test_alias", source);

			// Act
			sourceColumn.Alias = alias;

			// Assert
			Assert.Equal(name, sourceColumn.Name);
			
			if (string.IsNullOrEmpty(alias))
			{
				Assert.Null(sourceColumn.Alias);
			}
			else
			{
				Assert.Equal(alias, sourceColumn.Alias);
			}

			Assert.Equal(source, sourceColumn.Source);
		}

		[Fact]
		public void SetSource_ISource_Success()
		{
			// Arrange
			string name = "test_name";
			string alias = "test_alias";
			SourceColumn sourceColumn = new SourceColumn(name, alias, NewSource());
			ISource source = NewSource();

			// Act
			sourceColumn.Source = source;

			// Assert
			Assert.Equal(name, sourceColumn.Name);
			Assert.Equal(alias, sourceColumn.Alias);
			Assert.Equal(source, sourceColumn.Source);
		}

		[Fact]
		public void SetSource_NullISource_Success()
		{
			// Arrange
			string name = "test_name";
			string alias = "test_alias";
			SourceColumn sourceColumn = new SourceColumn(name, alias, NewSource());

			// Act
			sourceColumn.Source = null;

			// Assert
			Assert.Equal(name, sourceColumn.Name);
			Assert.Equal(alias, sourceColumn.Alias);
			Assert.Null(sourceColumn.Source);
		}

		[Fact]
		public void RenderColumn_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			SourceColumn sourceColumn = new SourceColumn("test_name", "test_alias", NewSource());

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderColumn(It.IsAny<SourceColumn>(), It.IsAny<StringBuilder>())).Callback((SourceColumn value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			sourceColumn.RenderColumn(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderColumn_Renderer_ReturnsSql()
		{
			// Arrange
			SourceColumn sourceColumn = new SourceColumn("test_name", "test_alias", NewSource());

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderColumn(It.IsAny<SourceColumn>(), It.IsAny<StringBuilder>())).Callback((SourceColumn value, StringBuilder sql) => sql.Append(expectedSql));
			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = sourceColumn.RenderColumn(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderIdentificator_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			SourceColumn sourceColumn = new SourceColumn("test_name", "test_alias", NewSource());

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderIdentificator(It.IsAny<SourceColumn>(), It.IsAny<StringBuilder>())).Callback((SourceColumn value, StringBuilder sql) => sql.Append(expectedSql));

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			sourceColumn.RenderIdentificator(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderIdentificator_Renderer_ReturnsSql()
		{
			// Arrange
			SourceColumn sourceColumn = new SourceColumn("test_name", "test_alias", NewSource());

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderIdentificator(It.IsAny<SourceColumn>(), It.IsAny<StringBuilder>())).Callback((SourceColumn value, StringBuilder sql) => sql.Append(expectedSql));

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = sourceColumn.RenderIdentificator(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderExpression_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			SourceColumn sourceColumn = new SourceColumn("test_name", "test_alias", NewSource());

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderIdentificator(It.IsAny<SourceColumn>(), It.IsAny<StringBuilder>())).Callback((SourceColumn value, StringBuilder sql) => sql.Append(expectedSql));

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			sourceColumn.RenderExpression(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderValue_Renderer_ReturnsSql()
		{
			// Arrange
			SourceColumn sourceColumn = new SourceColumn("test_name", "test_alias", NewSource());

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderIdentificator(It.IsAny<SourceColumn>(), It.IsAny<StringBuilder>())).Callback((SourceColumn value, StringBuilder sql) => sql.Append(expectedSql));

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = sourceColumn.RenderExpression(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_StringAndISource_ThrowsArgumentException(string? name, ISource? source)
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new SourceColumn(name!, source));
		}

		private void Constructor_StringAndStringAndISource_ThrowsArgumentException(string? name, string? alias, ISource? source)
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new SourceColumn(name!, alias, source));
		}
	}
}
