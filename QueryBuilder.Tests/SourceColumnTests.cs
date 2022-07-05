using Xunit;

using YuraSoft.QueryBuilder.Exceptions;
using YuraSoft.QueryBuilder.Interfaces;

namespace YuraSoft.QueryBuilder.Tests
{
	public class SourceColumnTests
	{
		[Fact]
		public void Create_WithAllParameters_Success()
		{
			const string name = "column_name";
			const string alias = "column_alias";
			Table table = new Table("table_name");

			SourceColumn column = new SourceColumn(name, alias, table);

			Assert.Equal(name, column.Name);
			Assert.Equal(alias, column.Alias);
			Assert.NotNull(column.Source);
			Assert.IsType<Table>(column.Source);
			Assert.Equal(table, (Table)column.Source!);
		}

		[Fact]
		public void Create_WithoutAliasAndSourceParameters_Success()
		{
			const string name = "column_name";

			SourceColumn column = new SourceColumn(name);

			Assert.Equal(name, column.Name);
			Assert.Null(column.Alias);
			Assert.Null(column.Source);
		}

		[Fact]
		public void Create_WithoutAliasParameter_Success()
		{
			const string name = "column_name";
			ISource source = new Table("table_name");

			SourceColumn column = new SourceColumn(name, source);

			Assert.Equal(name, column.Name);
			Assert.Null(column.Alias);
			Assert.NotNull(column.Source);
			Assert.IsType<Table>(column.Source);
			Assert.Equal(source, column.Source!);
		}

		[Fact]
		public void Create_WithoutSourceParameter_Success()
		{
			const string name = "column_name";
			const string alias = "column_alias";

			SourceColumn column = new SourceColumn(name, alias);

			Assert.Equal(name, column.Name);
			Assert.Equal(alias, column.Alias);
			Assert.Null(column.Source);
		}

		[Theory]
		[InlineData("")]
		[InlineData(null)]
		public void Create_NameIsEmptyOrNull_ThrowArgumentShouldNotBeNullOrEmptyException(string? name)
		{
			Assert.Throws<ArgumentShouldNotBeNullOrEmptyException>(() => new SourceColumn(name!));
		}

		[Theory]
		[InlineData("")]
		[InlineData(null)]
		public void Create_AliasIsEmptyOrNull_ThrowArgumentShouldNotBeNullOrEmptyException(string? alias)
		{
			Assert.Throws<ArgumentShouldNotBeNullOrEmptyException>(() => new SourceColumn("column_name", alias!));
			Assert.Throws<ArgumentShouldNotBeNullOrEmptyException>(() => new SourceColumn("column_name", alias!, new Table("table_name")));
		}

		[Fact]
		public void Create_SourceIsNull_ThrowArgumentShouldNotBeNullException()
		{
			Assert.Throws<ArgumentShouldNotBeNullException>(() => new SourceColumn("column_name", (ISource)null!));
			Assert.Throws<ArgumentShouldNotBeNullException>(() => new SourceColumn("column_name", "column_alias", null!));
		}
	}
}
