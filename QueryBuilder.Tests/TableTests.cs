using Xunit;

using YuraSoft.QueryBuilder;

namespace QueryBuilder.Tests
{
	public class TableTests
	{
		[Fact]
		public void CreateTableWithFullParametersTest()
		{
			const string name = "table_name";
			const string alias = "table_alias";
			const string @namespace = "table_namespace";

			Table table = new Table(name, alias, @namespace);

			Assert.Equal(name, table.Name);
			Assert.Equal(alias, table.Alias);
			Assert.Equal(@namespace, table.Schema);
		}

		[Fact]
		public void CreateTableWithNullNamespaceTest()
		{
			const string name = "table_name";
			const string alias = "table_alias";
			const string @namespace = null;

			Table table = new Table(name, alias, @namespace);

			Assert.Equal(name, table.Name);
			Assert.Equal(alias, table.Alias);
			Assert.Null(table.Schema);
		}

		[Fact]
		public void CreateTableWithEmptyNamespaceTest()
		{
			const string name = "table_name";
			const string alias = "table_alias";
			const string @namespace = "";

			Table table = new Table(name, alias, @namespace);

			Assert.Equal(name, table.Name);
			Assert.Equal(alias, table.Alias);
			Assert.Null(table.Schema);
		}

		[Fact]
		public void CreateTableWithoutNamespaceTest()
		{
			const string name = "table_name";
			const string alias = "table_alias";

			Table table = new Table(name, alias);

			Assert.Equal(name, table.Name);
			Assert.Equal(alias, table.Alias);
			Assert.Null(table.Schema);
		}

		[Fact]
		public void CreateTableWithNullAliasTest()
		{
			const string name = "table_name";
			const string alias = null;
			const string @namespace = "table_namespace";

			Table table = new Table(name, alias, @namespace);

			Assert.Equal(name, table.Name);
			Assert.Null(table.Alias);
			Assert.Equal(@namespace, table.Schema);
		}

		[Fact]
		public void CreateTableWithEmptyAliasTest()
		{
			const string name = "table_name";
			const string alias = "";
			const string @namespace = "table_namespace";

			Table table = new Table(name, alias, @namespace);

			Assert.Equal(name, table.Name);
			Assert.Null(table.Alias);
			Assert.Equal(@namespace, table.Schema);
		}
	}
}
