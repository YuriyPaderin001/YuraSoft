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

		[Theory]
		[InlineData("table_name", null, null)]
		[InlineData("table_name", null, "")]
		[InlineData("table_name", null, "table_schema")]
		[InlineData("table_name", "", null)]
		[InlineData("table_name", "", "")]
		[InlineData("table_name", "", "table_schema")]
		[InlineData("table_name", "table_alias", null)]
		[InlineData("table_name", "table_alias", "")]
		[InlineData("table_name", "table_alias", "table_schema")]
		public void Equals_SameObject_ReturnsTrue(string name, string? alias, string? schema)
		{
			// Arrange
			Table table = new Table(name, alias, schema);

			// Act
			bool isEquals = table.Equals((object)table);

			// Assert
			Assert.True(isEquals);
		}

		[Theory]
		[InlineData("same_name", null, null, "same_name", null, null)]
		[InlineData("same_name", null, null, "same_name", null, "")]
		[InlineData("same_name", null, null, "same_name", "", null)]
		[InlineData("same_name", null, null, "same_name", "", "")]
		[InlineData("same_name", null, "", "same_name", null, null)]
		[InlineData("same_name", null, "", "same_name", null, "")]
		[InlineData("same_name", null, "", "same_name", "", null)]
		[InlineData("same_name", null, "", "same_name", "", "")]
		[InlineData("same_name", null, "same_schema", "same_name", null, "same_schema")]
		[InlineData("same_name", null, "same_schema", "same_name", "", "same_schema")]
		[InlineData("same_name", "", null, "same_name", null, null)]
		[InlineData("same_name", "", null, "same_name", null, "")]
		[InlineData("same_name", "", null, "same_name", "", null)]
		[InlineData("same_name", "", null, "same_name", "", "")]
		[InlineData("same_name", "", "", "same_name", null, null)]
		[InlineData("same_name", "", "", "same_name", null, "")]
		[InlineData("same_name", "", "", "same_name", "", null)]
		[InlineData("same_name", "", "", "same_name", "", "")]
		[InlineData("same_name", "", "same_schema", "same_name", null, "same_schema")]
		[InlineData("same_name", "", "same_schema", "same_name", "", "same_schema")]
		[InlineData("same_name", "same_alias", null, "same_name", "same_alias", null)]
		[InlineData("same_name", "same_alias", null, "same_name", "same_alias", "")]
		[InlineData("same_name", "same_alias", "", "same_name", "same_alias", null)]
		[InlineData("same_name", "same_alias", "", "same_name", "same_alias", "")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "same_alias", "same_schema")]
		public void Equals_EquivalentObject_ReturnsTrue(
			string firstName, string? firstAlias, string? firstSchema,
			string secondName, string? secondAlias, string? secondSchema)
		{
			// Arrange
			Table firstTable = new Table(firstName, firstAlias, firstSchema);
			Table secondTable = new Table(secondName, secondAlias, secondSchema);

			// Act
			bool isEquals = firstTable.Equals((object)secondTable);

			// Assert
			Assert.True(isEquals);
		}

		[Theory]
		[InlineData("table_name", null, null)]
		[InlineData("table_name", null, "")]
		[InlineData("table_name", null, "table_schema")]
		[InlineData("table_name", "", null)]
		[InlineData("table_name", "", "")]
		[InlineData("table_name", "", "table_schema")]
		[InlineData("table_name", "table_alias", null)]
		[InlineData("table_name", "table_alias", "")]
		[InlineData("table_name", "table_alias", "table_schema")]
		public void Equals_NullObject_ReturnsFalse(string name, string? alias, string? schema)
		{
			// Arrange
			Table table = new Table(name, alias, schema);

			// Act
			bool isEquals = table.Equals((object?)null);

			// Assert
			Assert.False(isEquals);
		}

		[Theory]
		[InlineData("same_name", null, null, "same_name", null, "different_schema")]
		[InlineData("same_name", null, null, "same_name", "", "different_schema")]
		[InlineData("same_name", null, null, "same_name", "different_alias", null)]
		[InlineData("same_name", null, null, "same_name", "different_alias", "")]
		[InlineData("same_name", null, null, "same_name", "different_alias", "different_schema")]
		[InlineData("same_name", null, null, "different_name", null, "different_schema")]
		[InlineData("same_name", null, null, "different_name", "", "different_schema")]
		[InlineData("same_name", null, null, "different_name", "different_alias", null)]
		[InlineData("same_name", null, null, "different_name", "different_alias", "")]
		[InlineData("same_name", null, null, "different_name", "different_alias", "different_schema")]
		[InlineData("same_name", null, "", "same_name", null, "different_schema")]
		[InlineData("same_name", null, "", "same_name", "", "different_schema")]
		[InlineData("same_name", null, "", "same_name", "different_alias", null)]
		[InlineData("same_name", null, "", "same_name", "different_alias", "")]
		[InlineData("same_name", null, "", "same_name", "different_alias", "different_schema")]
		[InlineData("same_name", null, "", "different_name", null, null)]
		[InlineData("same_name", null, "", "different_name", null, "")]
		[InlineData("same_name", null, "", "different_name", null, "different_schema")]
		[InlineData("same_name", null, "", "different_name", "", null)]
		[InlineData("same_name", null, "", "different_name", "", "")]
		[InlineData("same_name", null, "", "different_name", "", "different_schema")]
		[InlineData("same_name", null, "", "different_name", "different_alias", null)]
		[InlineData("same_name", null, "", "different_name", "different_alias", "")]
		[InlineData("same_name", null, "", "different_name", "different_alias", "different_schema")]
		[InlineData("same_name", null, "same_schema", "same_name", null, null)]
		[InlineData("same_name", null, "same_schema", "same_name", null, "")]
		[InlineData("same_name", null, "same_schema", "same_name", null, "different_schema")]
		[InlineData("same_name", null, "same_schema", "same_name", "", null)]
		[InlineData("same_name", null, "same_schema", "same_name", "", "")]
		[InlineData("same_name", null, "same_schema", "same_name", "", "different_schema")]
		[InlineData("same_name", null, "same_schema", "same_name", "different_alias", null)]
		[InlineData("same_name", null, "same_schema", "same_name", "different_alias", "")]
		[InlineData("same_name", null, "same_schema", "same_name", "different_alias", "same_schema")]
		[InlineData("same_name", null, "same_schema", "same_name", "different_alias", "different_schema")]
		[InlineData("same_name", null, "same_schema", "different_name", null, null)]
		[InlineData("same_name", null, "same_schema", "different_name", null, "")]
		[InlineData("same_name", null, "same_schema", "different_name", null, "same_schema")]
		[InlineData("same_name", null, "same_schema", "different_name", null, "different_schema")]
		[InlineData("same_name", null, "same_schema", "different_name", "", null)]
		[InlineData("same_name", null, "same_schema", "different_name", "", "")]
		[InlineData("same_name", null, "same_schema", "different_name", "", "same_schema")]
		[InlineData("same_name", null, "same_schema", "different_name", "", "different_schema")]
		[InlineData("same_name", null, "same_schema", "different_name", "different_alias", null)]
		[InlineData("same_name", null, "same_schema", "different_name", "different_alias", "")]
		[InlineData("same_name", null, "same_schema", "different_name", "different_alias", "same_schema")]
		[InlineData("same_name", null, "same_schema", "different_name", "different_alias", "different_schema")]
		[InlineData("same_name", "", null, "same_name", null, "different_schema")]
		[InlineData("same_name", "", null, "same_name", "", "different_schema")]
		[InlineData("same_name", "", null, "same_name", "different_alias", null)]
		[InlineData("same_name", "", null, "same_name", "different_alias", "")]
		[InlineData("same_name", "", null, "same_name", "different_alias", "different_schema")]
		[InlineData("same_name", "", null, "different_name", null, null)]
		[InlineData("same_name", "", null, "different_name", null, "")]
		[InlineData("same_name", "", null, "different_name", null, "different_schema")]
		[InlineData("same_name", "", null, "different_name", "", null)]
		[InlineData("same_name", "", null, "different_name", "", "")]
		[InlineData("same_name", "", null, "different_name", "", "different_schema")]
		[InlineData("same_name", "", null, "different_name", "different_alias", null)]
		[InlineData("same_name", "", null, "different_name", "different_alias", "")]
		[InlineData("same_name", "", null, "different_name", "different_alias", "different_schema")]
		[InlineData("same_name", "", "", "same_name", null, "different_schema")]
		[InlineData("same_name", "", "", "same_name", "", "different_schema")]
		[InlineData("same_name", "", "", "same_name", "different_alias", null)]
		[InlineData("same_name", "", "", "same_name", "different_alias", "")]
		[InlineData("same_name", "", "", "same_name", "different_alias", "different_schema")]
		[InlineData("same_name", "", "", "different_name", null, null)]
		[InlineData("same_name", "", "", "different_name", null, "")]
		[InlineData("same_name", "", "", "different_name", null, "different_schema")]
		[InlineData("same_name", "", "", "different_name", "", null)]
		[InlineData("same_name", "", "", "different_name", "", "")]
		[InlineData("same_name", "", "", "different_name", "", "different_schema")]
		[InlineData("same_name", "", "", "different_name", "different_alias", null)]
		[InlineData("same_name", "", "", "different_name", "different_alias", "")]
		[InlineData("same_name", "", "", "different_name", "different_alias", "different_schema")]
		[InlineData("same_name", "", "same_schema", "same_name", null, null)]
		[InlineData("same_name", "", "same_schema", "same_name", null, "")]
		[InlineData("same_name", "", "same_schema", "same_name", null, "different_schema")]
		[InlineData("same_name", "", "same_schema", "same_name", "", null)]
		[InlineData("same_name", "", "same_schema", "same_name", "", "")]
		[InlineData("same_name", "", "same_schema", "same_name", "", "different_schema")]
		[InlineData("same_name", "", "same_schema", "same_name", "different_alias", null)]
		[InlineData("same_name", "", "same_schema", "same_name", "different_alias", "")]
		[InlineData("same_name", "", "same_schema", "same_name", "different_alias", "same_schema")]
		[InlineData("same_name", "", "same_schema", "same_name", "different_alias", "different_schema")]
		[InlineData("same_name", "", "same_schema", "different_name", null, null)]
		[InlineData("same_name", "", "same_schema", "different_name", null, "")]
		[InlineData("same_name", "", "same_schema", "different_name", null, "different_schema")]
		[InlineData("same_name", "", "same_schema", "different_name", "", null)]
		[InlineData("same_name", "", "same_schema", "different_name", "", "")]
		[InlineData("same_name", "", "same_schema", "different_name", "", "different_schema")]
		[InlineData("same_name", "", "same_schema", "different_name", "different_alias", null)]
		[InlineData("same_name", "", "same_schema", "different_name", "different_alias", "")]
		[InlineData("same_name", "", "same_schema", "different_name", "different_alias", "same_schema")]
		[InlineData("same_name", "", "same_schema", "different_name", "different_alias", "different_schema")]
		[InlineData("same_name", "same_alias", null, "same_name", null, null)]
		[InlineData("same_name", "same_alias", null, "same_name", null, "")]
		[InlineData("same_name", "same_alias", null, "same_name", null, "different_schema")]
		[InlineData("same_name", "same_alias", null, "same_name", "", null)]
		[InlineData("same_name", "same_alias", null, "same_name", "", "")]
		[InlineData("same_name", "same_alias", null, "same_name", "", "different_schema")]
		[InlineData("same_name", "same_alias", null, "same_name", "same_alias", "different_schema")]
		[InlineData("same_name", "same_alias", null, "same_name", "different_alias", null)]
		[InlineData("same_name", "same_alias", null, "same_name", "different_alias", "")]
		[InlineData("same_name", "same_alias", null, "same_name", "different_alias", "different_schema")]
		[InlineData("same_name", "same_alias", null, "different_name", null, null)]
		[InlineData("same_name", "same_alias", null, "different_name", null, "")]
		[InlineData("same_name", "same_alias", null, "different_name", null, "different_schema")]
		[InlineData("same_name", "same_alias", null, "different_name", "", null)]
		[InlineData("same_name", "same_alias", null, "different_name", "", "")]
		[InlineData("same_name", "same_alias", null, "different_name", "", "different_schema")]
		[InlineData("same_name", "same_alias", null, "different_name", "same_alias", "different_schema")]
		[InlineData("same_name", "same_alias", null, "different_name", "different_alias", null)]
		[InlineData("same_name", "same_alias", null, "different_name", "different_alias", "")]
		[InlineData("same_name", "same_alias", null, "different_name", "different_alias", "different_schema")]
		[InlineData("same_name", "same_alias", "", "same_name", null, null)]
		[InlineData("same_name", "same_alias", "", "same_name", null, "")]
		[InlineData("same_name", "same_alias", "", "same_name", null, "different_schema")]
		[InlineData("same_name", "same_alias", "", "same_name", "", null)]
		[InlineData("same_name", "same_alias", "", "same_name", "", "")]
		[InlineData("same_name", "same_alias", "", "same_name", "", "different_schema")]
		[InlineData("same_name", "same_alias", "", "same_name", "same_alias", "different_schema")]
		[InlineData("same_name", "same_alias", "", "same_name", "different_alias", null)]
		[InlineData("same_name", "same_alias", "", "same_name", "different_alias", "")]
		[InlineData("same_name", "same_alias", "", "same_name", "different_alias", "different_schema")]
		[InlineData("same_name", "same_alias", "", "different_name", null, null)]
		[InlineData("same_name", "same_alias", "", "different_name", null, "")]
		[InlineData("same_name", "same_alias", "", "different_name", null, "different_schema")]
		[InlineData("same_name", "same_alias", "", "different_name", "", null)]
		[InlineData("same_name", "same_alias", "", "different_name", "", "")]
		[InlineData("same_name", "same_alias", "", "different_name", "", "different_schema")]
		[InlineData("same_name", "same_alias", "", "different_name", "same_alias", null)]
		[InlineData("same_name", "same_alias", "", "different_name", "same_alias", "")]
		[InlineData("same_name", "same_alias", "", "different_name", "same_alias", "different_schema")]
		[InlineData("same_name", "same_alias", "", "different_name", "different_alias", null)]
		[InlineData("same_name", "same_alias", "", "different_name", "different_alias", "")]
		[InlineData("same_name", "same_alias", "", "different_name", "different_alias", "different_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", null, null)]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", null, "")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", null, "same_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", null, "different_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "", null)]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "", "")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "", "same_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "", "different_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "same_alias", null)]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "same_alias", "")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "same_alias", "different_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "different_alias", null)]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "different_alias", "")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "different_alias", "same_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "different_alias", "different_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", null, null)]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", null, "")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", null, "same_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", null, "different_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "", null)]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "", "")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "", "same_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "", "different_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "same_alias", null)]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "same_alias", "")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "same_alias", "same_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "same_alias", "different_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "different_alias", null)]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "different_alias", "")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "different_alias", "same_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "different_alias", "different_schema")]
		public void Equals_DifferentObject_ReturnsFalse(
			string firstName, string? firstAlias, string? firstSchema,
			string secondName, string? secondAlias, string? secondSchema)
		{
			// Arrange
			Table firstTable = new Table(firstName, firstAlias, firstSchema);
			Table secondTable = new Table(secondName, secondAlias, secondSchema);

			// Act
			bool isEquals = firstTable.Equals((object)secondTable);

			// Assert
			Assert.False(isEquals);
		}

		[Theory]
		[InlineData("table_name", null, null)]
		[InlineData("table_name", null, "")]
		[InlineData("table_name", null, "table_schema")]
		[InlineData("table_name", "", null)]
		[InlineData("table_name", "", "")]
		[InlineData("table_name", "", "table_schema")]
		[InlineData("table_name", "table_alias", null)]
		[InlineData("table_name", "table_alias", "")]
		[InlineData("table_name", "table_alias", "table_schema")]
		public void Equals_SameTable_ReturnsTrue(string name, string? alias, string? schema)
		{
			// Arrange
			Table table = new Table(name, alias, schema);

			// Act
			bool isEquals = table.Equals(table);

			// Assert
			Assert.True(isEquals);
		}

		[Theory]
		[InlineData("same_name", null, null, "same_name", null, null)]
		[InlineData("same_name", null, null, "same_name", null, "")]
		[InlineData("same_name", null, null, "same_name", "", null)]
		[InlineData("same_name", null, null, "same_name", "", "")]
		[InlineData("same_name", null, "", "same_name", null, null)]
		[InlineData("same_name", null, "", "same_name", null, "")]
		[InlineData("same_name", null, "", "same_name", "", null)]
		[InlineData("same_name", null, "", "same_name", "", "")]
		[InlineData("same_name", null, "same_schema", "same_name", null, "same_schema")]
		[InlineData("same_name", null, "same_schema", "same_name", "", "same_schema")]
		[InlineData("same_name", "", null, "same_name", null, null)]
		[InlineData("same_name", "", null, "same_name", null, "")]
		[InlineData("same_name", "", null, "same_name", "", null)]
		[InlineData("same_name", "", null, "same_name", "", "")]
		[InlineData("same_name", "", "", "same_name", null, null)]
		[InlineData("same_name", "", "", "same_name", null, "")]
		[InlineData("same_name", "", "", "same_name", "", null)]
		[InlineData("same_name", "", "", "same_name", "", "")]
		[InlineData("same_name", "", "same_schema", "same_name", null, "same_schema")]
		[InlineData("same_name", "", "same_schema", "same_name", "", "same_schema")]
		[InlineData("same_name", "same_alias", null, "same_name", "same_alias", null)]
		[InlineData("same_name", "same_alias", null, "same_name", "same_alias", "")]
		[InlineData("same_name", "same_alias", "", "same_name", "same_alias", null)]
		[InlineData("same_name", "same_alias", "", "same_name", "same_alias", "")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "same_alias", "same_schema")]
		public void Equals_EquivalentTable_ReturnsTrue(
			string firstName, string? firstAlias, string? firstSchema,
			string secondName, string? secondAlias, string? secondSchema)
		{
			// Arrange
			Table firstTable = new Table(firstName, firstAlias, firstSchema);
			Table secondTable = new Table(secondName, secondAlias, secondSchema);

			// Act
			bool isEquals = firstTable.Equals(secondTable);

			// Assert
			Assert.True(isEquals);
		}

		[Theory]
		[InlineData("table_name", null, null)]
		[InlineData("table_name", null, "")]
		[InlineData("table_name", null, "table_schema")]
		[InlineData("table_name", "", null)]
		[InlineData("table_name", "", "")]
		[InlineData("table_name", "", "table_schema")]
		[InlineData("table_name", "table_alias", null)]
		[InlineData("table_name", "table_alias", "")]
		[InlineData("table_name", "table_alias", "table_schema")]
		public void Equals_NullTable_ReturnsFalse(string name, string? alias, string? schema)
		{
			// Arrange
			Table table = new Table(name, alias, schema);

			// Act
			bool isEquals = table.Equals(null);

			// Assert
			Assert.False(isEquals);
		}

		[Theory]
		[InlineData("same_name", null, null, "same_name", null, "different_schema")]
		[InlineData("same_name", null, null, "same_name", "", "different_schema")]
		[InlineData("same_name", null, null, "same_name", "different_alias", null)]
		[InlineData("same_name", null, null, "same_name", "different_alias", "")]
		[InlineData("same_name", null, null, "same_name", "different_alias", "different_schema")]
		[InlineData("same_name", null, null, "different_name", null, "different_schema")]
		[InlineData("same_name", null, null, "different_name", "", "different_schema")]
		[InlineData("same_name", null, null, "different_name", "different_alias", null)]
		[InlineData("same_name", null, null, "different_name", "different_alias", "")]
		[InlineData("same_name", null, null, "different_name", "different_alias", "different_schema")]
		[InlineData("same_name", null, "", "same_name", null, "different_schema")]
		[InlineData("same_name", null, "", "same_name", "", "different_schema")]
		[InlineData("same_name", null, "", "same_name", "different_alias", null)]
		[InlineData("same_name", null, "", "same_name", "different_alias", "")]
		[InlineData("same_name", null, "", "same_name", "different_alias", "different_schema")]
		[InlineData("same_name", null, "", "different_name", null, null)]
		[InlineData("same_name", null, "", "different_name", null, "")]
		[InlineData("same_name", null, "", "different_name", null, "different_schema")]
		[InlineData("same_name", null, "", "different_name", "", null)]
		[InlineData("same_name", null, "", "different_name", "", "")]
		[InlineData("same_name", null, "", "different_name", "", "different_schema")]
		[InlineData("same_name", null, "", "different_name", "different_alias", null)]
		[InlineData("same_name", null, "", "different_name", "different_alias", "")]
		[InlineData("same_name", null, "", "different_name", "different_alias", "different_schema")]
		[InlineData("same_name", null, "same_schema", "same_name", null, null)]
		[InlineData("same_name", null, "same_schema", "same_name", null, "")]
		[InlineData("same_name", null, "same_schema", "same_name", null, "different_schema")]
		[InlineData("same_name", null, "same_schema", "same_name", "", null)]
		[InlineData("same_name", null, "same_schema", "same_name", "", "")]
		[InlineData("same_name", null, "same_schema", "same_name", "", "different_schema")]
		[InlineData("same_name", null, "same_schema", "same_name", "different_alias", null)]
		[InlineData("same_name", null, "same_schema", "same_name", "different_alias", "")]
		[InlineData("same_name", null, "same_schema", "same_name", "different_alias", "same_schema")]
		[InlineData("same_name", null, "same_schema", "same_name", "different_alias", "different_schema")]
		[InlineData("same_name", null, "same_schema", "different_name", null, null)]
		[InlineData("same_name", null, "same_schema", "different_name", null, "")]
		[InlineData("same_name", null, "same_schema", "different_name", null, "same_schema")]
		[InlineData("same_name", null, "same_schema", "different_name", null, "different_schema")]
		[InlineData("same_name", null, "same_schema", "different_name", "", null)]
		[InlineData("same_name", null, "same_schema", "different_name", "", "")]
		[InlineData("same_name", null, "same_schema", "different_name", "", "same_schema")]
		[InlineData("same_name", null, "same_schema", "different_name", "", "different_schema")]
		[InlineData("same_name", null, "same_schema", "different_name", "different_alias", null)]
		[InlineData("same_name", null, "same_schema", "different_name", "different_alias", "")]
		[InlineData("same_name", null, "same_schema", "different_name", "different_alias", "same_schema")]
		[InlineData("same_name", null, "same_schema", "different_name", "different_alias", "different_schema")]
		[InlineData("same_name", "", null, "same_name", null, "different_schema")]
		[InlineData("same_name", "", null, "same_name", "", "different_schema")]
		[InlineData("same_name", "", null, "same_name", "different_alias", null)]
		[InlineData("same_name", "", null, "same_name", "different_alias", "")]
		[InlineData("same_name", "", null, "same_name", "different_alias", "different_schema")]
		[InlineData("same_name", "", null, "different_name", null, null)]
		[InlineData("same_name", "", null, "different_name", null, "")]
		[InlineData("same_name", "", null, "different_name", null, "different_schema")]
		[InlineData("same_name", "", null, "different_name", "", null)]
		[InlineData("same_name", "", null, "different_name", "", "")]
		[InlineData("same_name", "", null, "different_name", "", "different_schema")]
		[InlineData("same_name", "", null, "different_name", "different_alias", null)]
		[InlineData("same_name", "", null, "different_name", "different_alias", "")]
		[InlineData("same_name", "", null, "different_name", "different_alias", "different_schema")]
		[InlineData("same_name", "", "", "same_name", null, "different_schema")]
		[InlineData("same_name", "", "", "same_name", "", "different_schema")]
		[InlineData("same_name", "", "", "same_name", "different_alias", null)]
		[InlineData("same_name", "", "", "same_name", "different_alias", "")]
		[InlineData("same_name", "", "", "same_name", "different_alias", "different_schema")]
		[InlineData("same_name", "", "", "different_name", null, null)]
		[InlineData("same_name", "", "", "different_name", null, "")]
		[InlineData("same_name", "", "", "different_name", null, "different_schema")]
		[InlineData("same_name", "", "", "different_name", "", null)]
		[InlineData("same_name", "", "", "different_name", "", "")]
		[InlineData("same_name", "", "", "different_name", "", "different_schema")]
		[InlineData("same_name", "", "", "different_name", "different_alias", null)]
		[InlineData("same_name", "", "", "different_name", "different_alias", "")]
		[InlineData("same_name", "", "", "different_name", "different_alias", "different_schema")]
		[InlineData("same_name", "", "same_schema", "same_name", null, null)]
		[InlineData("same_name", "", "same_schema", "same_name", null, "")]
		[InlineData("same_name", "", "same_schema", "same_name", null, "different_schema")]
		[InlineData("same_name", "", "same_schema", "same_name", "", null)]
		[InlineData("same_name", "", "same_schema", "same_name", "", "")]
		[InlineData("same_name", "", "same_schema", "same_name", "", "different_schema")]
		[InlineData("same_name", "", "same_schema", "same_name", "different_alias", null)]
		[InlineData("same_name", "", "same_schema", "same_name", "different_alias", "")]
		[InlineData("same_name", "", "same_schema", "same_name", "different_alias", "same_schema")]
		[InlineData("same_name", "", "same_schema", "same_name", "different_alias", "different_schema")]
		[InlineData("same_name", "", "same_schema", "different_name", null, null)]
		[InlineData("same_name", "", "same_schema", "different_name", null, "")]
		[InlineData("same_name", "", "same_schema", "different_name", null, "different_schema")]
		[InlineData("same_name", "", "same_schema", "different_name", "", null)]
		[InlineData("same_name", "", "same_schema", "different_name", "", "")]
		[InlineData("same_name", "", "same_schema", "different_name", "", "different_schema")]
		[InlineData("same_name", "", "same_schema", "different_name", "different_alias", null)]
		[InlineData("same_name", "", "same_schema", "different_name", "different_alias", "")]
		[InlineData("same_name", "", "same_schema", "different_name", "different_alias", "same_schema")]
		[InlineData("same_name", "", "same_schema", "different_name", "different_alias", "different_schema")]
		[InlineData("same_name", "same_alias", null, "same_name", null, null)]
		[InlineData("same_name", "same_alias", null, "same_name", null, "")]
		[InlineData("same_name", "same_alias", null, "same_name", null, "different_schema")]
		[InlineData("same_name", "same_alias", null, "same_name", "", null)]
		[InlineData("same_name", "same_alias", null, "same_name", "", "")]
		[InlineData("same_name", "same_alias", null, "same_name", "", "different_schema")]
		[InlineData("same_name", "same_alias", null, "same_name", "same_alias", "different_schema")]
		[InlineData("same_name", "same_alias", null, "same_name", "different_alias", null)]
		[InlineData("same_name", "same_alias", null, "same_name", "different_alias", "")]
		[InlineData("same_name", "same_alias", null, "same_name", "different_alias", "different_schema")]
		[InlineData("same_name", "same_alias", null, "different_name", null, null)]
		[InlineData("same_name", "same_alias", null, "different_name", null, "")]
		[InlineData("same_name", "same_alias", null, "different_name", null, "different_schema")]
		[InlineData("same_name", "same_alias", null, "different_name", "", null)]
		[InlineData("same_name", "same_alias", null, "different_name", "", "")]
		[InlineData("same_name", "same_alias", null, "different_name", "", "different_schema")]
		[InlineData("same_name", "same_alias", null, "different_name", "same_alias", "different_schema")]
		[InlineData("same_name", "same_alias", null, "different_name", "different_alias", null)]
		[InlineData("same_name", "same_alias", null, "different_name", "different_alias", "")]
		[InlineData("same_name", "same_alias", null, "different_name", "different_alias", "different_schema")]
		[InlineData("same_name", "same_alias", "", "same_name", null, null)]
		[InlineData("same_name", "same_alias", "", "same_name", null, "")]
		[InlineData("same_name", "same_alias", "", "same_name", null, "different_schema")]
		[InlineData("same_name", "same_alias", "", "same_name", "", null)]
		[InlineData("same_name", "same_alias", "", "same_name", "", "")]
		[InlineData("same_name", "same_alias", "", "same_name", "", "different_schema")]
		[InlineData("same_name", "same_alias", "", "same_name", "same_alias", "different_schema")]
		[InlineData("same_name", "same_alias", "", "same_name", "different_alias", null)]
		[InlineData("same_name", "same_alias", "", "same_name", "different_alias", "")]
		[InlineData("same_name", "same_alias", "", "same_name", "different_alias", "different_schema")]
		[InlineData("same_name", "same_alias", "", "different_name", null, null)]
		[InlineData("same_name", "same_alias", "", "different_name", null, "")]
		[InlineData("same_name", "same_alias", "", "different_name", null, "different_schema")]
		[InlineData("same_name", "same_alias", "", "different_name", "", null)]
		[InlineData("same_name", "same_alias", "", "different_name", "", "")]
		[InlineData("same_name", "same_alias", "", "different_name", "", "different_schema")]
		[InlineData("same_name", "same_alias", "", "different_name", "same_alias", null)]
		[InlineData("same_name", "same_alias", "", "different_name", "same_alias", "")]
		[InlineData("same_name", "same_alias", "", "different_name", "same_alias", "different_schema")]
		[InlineData("same_name", "same_alias", "", "different_name", "different_alias", null)]
		[InlineData("same_name", "same_alias", "", "different_name", "different_alias", "")]
		[InlineData("same_name", "same_alias", "", "different_name", "different_alias", "different_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", null, null)]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", null, "")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", null, "same_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", null, "different_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "", null)]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "", "")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "", "same_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "", "different_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "same_alias", null)]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "same_alias", "")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "same_alias", "different_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "different_alias", null)]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "different_alias", "")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "different_alias", "same_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "same_name", "different_alias", "different_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", null, null)]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", null, "")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", null, "same_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", null, "different_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "", null)]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "", "")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "", "same_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "", "different_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "same_alias", null)]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "same_alias", "")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "same_alias", "same_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "same_alias", "different_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "different_alias", null)]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "different_alias", "")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "different_alias", "same_schema")]
		[InlineData("same_name", "same_alias", "same_schema", "different_name", "different_alias", "different_schema")]
		public void Equals_DifferentTable_ReturnsFalse(
			string firstName, string? firstAlias, string? firstSchema,
			string secondName, string? secondAlias, string? secondSchema)
		{
			// Arrange
			Table firstTable = new Table(firstName, firstAlias, firstSchema);
			Table secondTable = new Table(secondName, secondAlias, secondSchema);

			// Act
			bool isEquals = firstTable.Equals(secondTable);

			// Assert
			Assert.False(isEquals);
		}

		[Theory]
		[InlineData("table_name", null, null)]
		[InlineData("table_name", null, "")]
		[InlineData("table_name", null, "table_schema")]
		[InlineData("table_name", "", null)]
		[InlineData("table_name", "", "")]
		[InlineData("table_name", "", "table_schema")]
		[InlineData("table_name", "table_alias", null)]
		[InlineData("table_name", "table_alias", "")]
		[InlineData("table_name", "table_alias", "table_schema")]
		public void GetHashCode_ReturnsHashCode(string name, string? alias, string? schema)
		{
			// Arrange
			string? normalizedAlias = string.IsNullOrEmpty(alias) ? null : alias;
			string? normalizedSchema = string.IsNullOrEmpty(schema) ? null : schema;

			int expectedHashCode = HashCode.Combine(name, normalizedAlias, normalizedSchema);

			Table table = new Table(name, alias, schema);

			// Act
			int hashCode = table.GetHashCode();

			// Assert
			Assert.Equal(expectedHashCode, hashCode);
		}
	}
}
