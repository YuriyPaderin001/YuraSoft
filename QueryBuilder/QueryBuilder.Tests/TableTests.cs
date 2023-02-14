using System;
using Xunit;

namespace YuraSoft.QueryBuilder.Tests
{
	public class TableTests
	{
		[Fact]
		public void Create_WithAllParameters_SuccessCreate()
		{
			const string name = "table_name";
			const string alias = "table_alias";
			const string scheme = "table_namespace";

			Table table = new Table(name, alias, scheme);

			Assert.Equal(name, table.Name);
			Assert.Equal(alias, table.Alias);
			Assert.Equal(scheme, table.Schema);
		}

		[Theory]
		[InlineData("")]
		[InlineData(null)]
		public void Create_NameIsEmptyOrNull_ThrowException(string? name)
		{
			Assert.ThrowsAny<ArgumentException>(() => new Table(name!));
		}

		[Theory]
		[InlineData("")]
		[InlineData(null)]
		public void Create_AliasIsEmptyOrNull_AliasIsNull(string? alias)
		{
			const string name = "table_name";
			const string schema = "table_namespace";

			Table table = new Table(name, alias, schema);

			Assert.Equal(name, table.Name);
			Assert.Null(table.Alias);
			Assert.Equal(schema, table.Schema);
		}

		[Theory]
		[InlineData("")]
		[InlineData(null)]
		public void Create_SchemaIsEmptyOrNull_SchemaIsNull(string? schema)
		{
			const string name = "table_name";
			const string alias = "table_alias";

			Table table = new Table(name, alias, schema);

			Assert.Equal(name, table.Name);
			Assert.Equal(alias, table.Alias);
			Assert.Null(table.Schema);
		}

		[Theory]
		[InlineData("", "")]
		[InlineData("", null)]
		[InlineData(null, "")]
		[InlineData(null, null)]
		public void Create_AliasAndSchemaAreEmptyOrNull_AliasAndSchemaAreNull(string? alias, string? schema)
		{
			const string name = "table_name";

			Table table = new Table(name, alias, schema);

			Assert.Equal(name, table.Name);
			Assert.Null(table.Alias);
			Assert.Null(table.Schema);
		}
	}
}
