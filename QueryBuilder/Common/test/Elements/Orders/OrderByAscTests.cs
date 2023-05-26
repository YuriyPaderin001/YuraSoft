using System;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Orders
{
	public class OrderByAscTests : TestsBase
	{
		[Fact]
		public void Constructor_IColumnAndOrderDirection_Success()
		{
			// Arrange
			IColumn column = NewColumn();

			// Act
			OrderByAsc orderByAsc = new OrderByAsc(column);

			// Assert
			Assert.Equal(column, orderByAsc.Column);
			Assert.Equal(OrderDirection.Asc, orderByAsc.Direction);
		}

		[Fact]
		public void Constructor_NullIColumn_ArgumentNullException()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new OrderByAsc(column: null!));
		}

		[Fact]
		public void RenderOrderByAsc_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			OrderByAsc orderByAsc = new OrderByAsc(NewColumn());

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderOrderBy(It.IsAny<OrderBy>(), It.IsAny<StringBuilder>())).Callback((OrderBy value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			orderByAsc.RenderOrderBy(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderOrderByAsc_Renderer_ReturnsSql()
		{
			// Arrange
			OrderByAsc orderByAsc = new OrderByAsc(NewColumn());

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderOrderBy(It.IsAny<OrderBy>(), It.IsAny<StringBuilder>())).Callback((OrderBy value, StringBuilder sql) => sql.Append(expectedSql));
			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = orderByAsc.RenderOrderBy(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}
	}
}
