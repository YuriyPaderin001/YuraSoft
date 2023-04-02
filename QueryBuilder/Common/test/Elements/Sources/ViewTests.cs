using Moq;
using System;
using System.Text;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Sources
{
	public class ViewTests
	{
		[Fact]
		public void Constructor_Name_Success()
		{
			// Arrange
			string name = "test_name";

			// Act
			View view = new View(name);

			// Assert
			Assert.Equal(name, view.Name);
			Assert.Null(view.Alias);
			Assert.Null(view.Schema);
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
			View view = new View(name, alias);

			// Assert
			Assert.Equal(name, view.Name);

			if (string.IsNullOrEmpty(alias))
			{
				Assert.Null(view.Alias);
			}
			else
			{
				Assert.Equal(alias, view.Alias);
			}

			Assert.Null(view.Schema);
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
			View view = new View(name, schema: schema);

			// Assert
			Assert.Equal(name, view.Name);
			Assert.Null(view.Alias);

			if (string.IsNullOrEmpty(schema))
			{
				Assert.Null(view.Schema);
			}
			else
			{
				Assert.Equal(schema, view.Schema);
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
			View view = new View(name, alias, schema);

			// Assert
			Assert.Equal(name, view.Name);

			if (string.IsNullOrEmpty(alias))
			{
				Assert.Null(view.Alias);
			}
			else
			{
				Assert.Equal(alias, view.Alias);
			}

			if (string.IsNullOrEmpty(schema))
			{
				Assert.Null(view.Schema);
			}
			else
			{
				Assert.Equal(schema, view.Schema);
			}
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Constructor_NullOrEmptyName_ThrowsArgumentException(string? name)
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new View(name!));
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
			Assert.Throws<ArgumentException>(() => new View(name!, alias));
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
			Assert.Throws<ArgumentException>(() => new View(name!, schema: schema));
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
			Assert.Throws<ArgumentException>(() => new View(name!, alias, schema));
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
		public void SetName_String_Success(string? alias, string? schema)
		{
			// Arrange
			View view = new View(name: "test_name", alias, schema);
			string name = "new_test_name";

			// Act
			view.Name = name;

			// Assert
			Assert.Equal(name, view.Name);

			if (string.IsNullOrEmpty(alias))
			{
				Assert.Null(view.Alias);
			}
			else
			{
				Assert.Equal(alias, view.Alias);
			}

			if (string.IsNullOrEmpty(schema))
			{
				Assert.Null(view.Schema);
			}
			else
			{
				Assert.Equal(schema, view.Schema);
			}
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void SetName_NullOrEmptyString_ThrowsArgumentException(string? name)
		{
			// Arrange
			View view = new View(name: "test_name");

			// Act & Assert
			Assert.Throws<ArgumentException>(() => view.Name = name!);
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "test_schema")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "test_schema")]
		[InlineData("new_test_alias", null)]
		[InlineData("new_test_alias", "")]
		[InlineData("new_test_alias", "test_schema")]
		public void SetAlias_Success(string? alias, string? schema)
		{
			// Arrange
			const string name = "test_name";
			View view = new View(name, "test_alias", schema);

			// Act
			view.Alias = alias;

			// Assert
			Assert.Equal(name, view.Name);

			if (string.IsNullOrEmpty(alias))
			{
				Assert.Null(view.Alias);
			}
			else
			{
				Assert.Equal(alias, view.Alias);
			}

			if (string.IsNullOrEmpty(schema))
			{
				Assert.Null(view.Schema);
			}
			else
			{
				Assert.Equal(schema, view.Schema);
			}
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "")]
		[InlineData(null, "new_test_schema")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "new_test_schema")]
		[InlineData("test_alias", null)]
		[InlineData("test_alias", "")]
		[InlineData("test_alias", "new_test_schema")]
		public void SetSchema_Success(string? alias, string? schema)
		{
			// Arrange
			const string name = "test_name";
			View view = new View(name, alias, "test_schema");

			// Act
			view.Schema = schema;

			// Assert
			Assert.Equal(name, view.Name);

			if (string.IsNullOrEmpty(alias))
			{
				Assert.Null(view.Alias);
			}
			else
			{
				Assert.Equal(alias, view.Alias);
			}

			if (string.IsNullOrEmpty(schema))
			{
				Assert.Null(view.Schema);
			}
			else
			{
				Assert.Equal(schema, view.Schema);
			}
		}

		[Fact]
		public void RenderSource_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			View view = new View("test_name", "test_alias", "test_schema");

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderSource(It.IsAny<View>(), It.IsAny<StringBuilder>())).Callback((View value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			view.RenderSource(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderSource_Renderer_ReturnsSql()
		{
			// Arrange
			View view = new View("test_name", "test_alias", "test_schema");

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderSource(It.IsAny<View>(), It.IsAny<StringBuilder>())).Callback((View value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = view.RenderSource(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		[Fact]
		public void RenderIdentificator_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			View view = new View("test_name", "test_alias", "test_schema");

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderIdentificator(It.IsAny<View>(), It.IsAny<StringBuilder>())).Callback((View value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			view.RenderIdentificator(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderIdentificator_Renderer_ReturnsSql()
		{
			// Arrange
			View view = new View("test_name", "test_alias", "test_schema");

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderIdentificator(It.IsAny<View>(), It.IsAny<StringBuilder>())).Callback((View value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = view.RenderIdentificator(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}
	}
}
