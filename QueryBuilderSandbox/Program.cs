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
					.Int32(1)
					.String("last_name_1")
					.String("first_name_1")
					.Null())
				.Values(v => v
					.Int32(2)
					.String("last_name_2")
					.String("first_name_2")
					.String("middle_name_2"))
				.Values(v => v
					.Int32(3)
					.String("last_name_3")
					.String("first_name_3")
					.String("middle_name_3"))
				.Returning(rc => rc
					.Column("Id"));

			Console.WriteLine(insert1.RenderQuery(renderer));

			Console.WriteLine();

			Update update1 = new Update(table1)
				.Set("test_column1", 10)
				.Set("test_column2", "test_value_1")
				.Set("test_column3", "test_value_2")
				.SetNull("test_column4")
				.Where(c => c
					.Equal("test_column1", table1, 9)
					.Equal("test_column2", table1, "9999")
					.Between("test_column4", table1, new DateTime(1999, 01, 01), new DateTime(2000, 01, 01)));

			Console.WriteLine(update1.RenderQuery(renderer));

			Console.WriteLine();

			Delete delete1 = new Delete(table2)
				.Where(c => c
					.Equal("FirstName", table2, "Юра")
					.Equal("MiddleName", table2, "Падерин")
					.Between("BirthDate", table2, new DateTime(1999, 01, 01), new DateTime(2000, 01, 01)));

			Console.WriteLine(delete1.RenderQuery(renderer));
		}
	}
}
