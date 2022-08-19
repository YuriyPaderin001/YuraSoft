using System;

using YuraSoft.QueryBuilder;
using YuraSoft.QueryBuilder.Interfaces;
using YuraSoft.QueryBuilder.Renderers;

namespace QueryBuilderSandbox
{
	public class Program
	{
		public static void Main(string[] args)
		{
			IRenderer renderer = new PostgreSqlRenderer();

			Table table1 = new Table("user_group", "ug", "public");

			Select select1 = new Select(c => c.Column("id", table1))
				.From(table1)
				.Where(c => c
					.And(c => c
						.Equal("name", "group_name")
						.Equal("is_deleted", bool.FalseString)
						.In("id", 1, 2, 3 )));

			Table table2 = new Table("AspNetUsers", "anu", "auth_remote");

			Select select2 = new Select(c => c
				.Column("Id", table2)
				.Column("LastName", table2)
				.Column("FirstName", table2)
				.Column("MiddleName", table2))
				.From(table2)
				.LeftJoin(table1, c => c.Equal("Id", table2, "creator_sid", table1))
				.Where(c => c
					.Equal("Id", table2, "test_guid")
					.And(c => c
						.Equal("FirstName", table2, "Юра")
						.Equal("MiddleName", table2, "Падерин")
						.Between("BirthDate", table2, new DateTime(2022, 01, 01), new DateTime(2022, 01, 30))));

			Console.WriteLine(select2.RenderQuery(renderer));

			Table table3 = new Table("AspNetUsers", "anu", "auth_remote");

			Insert insert1 = new Insert(table3)
				.Columns(c => c
					.Column("Id")
					.Column("LastName")
					.Column("FirstName")
					.Column("MiddleName"))
				.Values(v => v
					.Int32(3)
					.String("last_name")
					.String("first_name")
					.String("middle_name"))
				.Values(
					new Int32Value(3),
					new StringValue("last_name"))
				.Values(
					new Int32Value(3),
					new StringValue("last_name"),
					new StringValue("first_name"),
					new StringValue("middle_name"))
				.Values(
					new Int32Value(3),
					new StringValue("last_name"));

			Console.WriteLine(insert1.RenderQuery(renderer));
		}
	}
}
