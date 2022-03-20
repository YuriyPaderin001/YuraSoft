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
			ISource table1 = new Table("table1", "t1");
			ISource table2 = new Table("table2", null, "public");
			ISource table3 = new Table("table3");

			IColumn column1 = new Column("column1", "c1", "table1");
			IColumn column2 = new Column("column2", null, new Table("table1", "t1"));
			IColumn column3 = new Column("column3", null, new Table("table2", null, "public"));
			IColumn column4 = new Column("column4", "c4", table3);

			Select select = new Select(column1, column2, column3, column4)
				.From(table1, table2, table3)
				.Where(
					new AndCondition(
						new ICondition[] {
							new EqualCondition(column1, column2),
							new LikeCondition(column2, "%test%"),
							new BetweenCondition(column1, column2, new StringValue("Test")),
							new OrCondition(
								new ICondition[] {
									new NotEqualCondition(column3, column4),
									new IsNullCondition(column3)
								})
						}))
				.GroupBy("table1")
				.OrderByAsc("table1")
				.Offset(100)
				.Limit(100);

			IRenderer renderer = new PostgreSqlRenderer();

			Console.WriteLine(select.RenderSelect(renderer));
		}
	}
}
