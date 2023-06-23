using Moq;
using System;
using System.Text;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Sources
{
	public class TableTests
	{
		[Fact]
		public void Constructor_Name_Success()
		{
			// Arrange
			string name = "test_name";

			// Act
			Table table = new Table(name);

			// Assert
			Assert.Equal(name, table.Name);
			Assert.Null(table.Alias);
			Assert.Null(table.Schema);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("test_alias")]
		public void Constructor_NameAndAlias_Success(string? alias)
		{
			// Arrange
			string name = "test_name";

			// Act
			Table table = new Table(name, alias);

			// Assert
			Assert.Equal(name, table.Name);

			if (string.IsNullOrEmpty(alias))
			{
				Assert.Null(table.Alias);
			}
			else
			{
				Assert.Equal(alias, table.Alias);
			}

			Assert.Null(table.Schema);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("test_schema")]
		public void Constructor_NameAndSchema_Success(string? schema)
		{
			// Arrange
			string name = "test_name";

			// Act
			Table table = new Table(name, schema: schema);

			// Assert
			Assert.Equal(name, table.Name);
			Assert.Null(table.Alias);

			if (string.IsNullOrEmpty(schema))
			{
				Assert.Null(table.Schema);
			}
			else
			{
				Assert.Equal(schema, table.Schema);
			}
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "test_schema")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "test_schema")]
		[InlineData("test_alias", null)]
		[InlineData("test_alias", "")]
		[InlineData("test_alias", "test_schema")]
		public void Constructor_NameAndAliasAndSchema_Success(string? alias, string? schema)
		{
			// Arrange
			string name = "test_name";

			// Act
			Table table = new Table(name, alias, schema);

			// Assert
			Assert.Equal(name, table.Name);

			if (string.IsNullOrEmpty(alias))
			{
				Assert.Null(table.Alias);
			}
			else
			{
				Assert.Equal(alias, table.Alias);
			}

			if (string.IsNullOrEmpty(schema))
			{
				Assert.Null(table.Schema);
			}
			else
			{
				Assert.Equal(schema, table.Schema);
			}
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Constructor_NullOrEmptyName_ThrowsArgumentException(string? name)
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new Table(name!));
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "test_alias")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "test_alias")]
		public void Constructor_NullOrEmptyNameAndAlias_ThrowsArgumentException(string? name, string? alias)
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new Table(name!, alias));
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "test_schema")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "test_schema")]
		public void Constructor_NullOrEmptyNameAndSchema_ThrowsArgumentException(string? name, string? schema)
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new Table(name!, schema: schema));
		}

		[Theory]
		[InlineData(null, null, null)]
		[InlineData(null, null, "")]
		[InlineData(null, null, "test_schema")]
		[InlineData(null, "", null)]
		[InlineData(null, "", "")]
		[InlineData(null, "", "test_schema")]
		[InlineData(null, "test_alias", null)]
		[InlineData(null, "test_alias", "")]
		[InlineData(null, "test_alias", "test_schema")]
		[InlineData("", null, null)]
		[InlineData("", null, "")]
		[InlineData("", null, "test_schema")]
		[InlineData("", "", null)]
		[InlineData("", "", "")]
		[InlineData("", "", "test_schema")]
		[InlineData("", "test_alias", null)]
		[InlineData("", "test_alias", "")]
		[InlineData("", "test_alias", "test_schema")]
		public void Constructor_NullOrEmptyNameAndAliasAndSchema_ThrowsArgumentException(string? name, string? alias, string? schema)
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new Table(name!, alias, schema));
		}

		[Fact]
		public void RenderSource_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			Table table = new Table("test_name", "test_alias", "test_schema");

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderSource(It.IsAny<Table>(), It.IsAny<StringBuilder>())).Callback((Table value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			table.RenderSource(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderSource_Renderer_ReturnsSql()
		{
			// Arrange
			Table table = new Table("test_name", "test_alias", "test_schema");

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderSource(It.IsAny<Table>(), It.IsAny<StringBuilder>())).Callback((Table value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = table.RenderSource(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderIdentificator_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			Table table = new Table("test_name", "test_alias", "test_schema");

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderIdentificator(It.IsAny<Table>(), It.IsAny<StringBuilder>())).Callback((Table value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			table.RenderIdentificator(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderIdentificator_Renderer_ReturnsSql()
		{
			// Arrange
			Table table = new Table("test_name", "test_alias", "test_schema");

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderIdentificator(It.IsAny<Table>(), It.IsAny<StringBuilder>())).Callback((Table value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = table.RenderIdentificator(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}
	}
}
