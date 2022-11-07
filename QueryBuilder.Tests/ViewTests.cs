using System;
using Xunit;

namespace YuraSoft.QueryBuilder.Tests
{
	public class ViewTests
	{
		[Fact]
		public void Create_WithAllParameters_SuccessCreate()
		{
			const string name = "view_name";
			const string alias = "view_alias";
			const string scheme = "view_namespace";

			View view = new View(name, alias, scheme);

			Assert.Equal(name, view.Name);
			Assert.Equal(alias, view.Alias);
			Assert.Equal(scheme, view.Schema);
		}

		[Theory]
		[InlineData("")]
		[InlineData(null)]
		public void Create_NameIsEmptyOrNull_ThrowException(string? name)
		{
			Assert.ThrowsAny<ArgumentException>(() => new View(name!));
		}

		[Theory]
		[InlineData("")]
		[InlineData(null)]
		public void Create_AliasIsEmptyOrNull_AliasIsNull(string? alias)
		{
			const string name = "view_name";
			const string schema = "view_namespace";

			View view = new View(name, alias, schema);

			Assert.Equal(name, view.Name);
			Assert.Null(view.Alias);
			Assert.Equal(schema, view.Schema);
		}

		[Theory]
		[InlineData("")]
		[InlineData(null)]
		public void Create_SchemaIsEmptyOrNull_SchemaIsNull(string? schema)
		{
			const string name = "view_name";
			const string alias = "view_alias";

			View view = new View(name, alias, schema);

			Assert.Equal(name, view.Name);
			Assert.Equal(alias, view.Alias);
			Assert.Null(view.Schema);
		}

		[Theory]
		[InlineData("", "")]
		[InlineData("", null)]
		[InlineData(null, "")]
		[InlineData(null, null)]
		public void Create_AliasAndSchemaAreEmptyOrNull_AliasAndSchemaAreNull(string? alias, string? schema)
		{
			const string name = "View_name";

			View view = new View(name, alias, schema);

			Assert.Equal(name, view.Name);
			Assert.Null(view.Alias);
			Assert.Null(view.Schema);
		}
	}
}
