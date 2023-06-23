using System;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Orders
{
	public class OrderByDescTests : TestsBase
	{
		[Fact]
		public void Constructor_IColumn_Success()
		{
			// Arrange
			IColumn column = NewColumn();

			// Act
			OrderByDesc orderByDesc = new OrderByDesc(column);

			// Assert
			Assert.Equal(column, orderByDesc.Column);
			Assert.Equal(OrderDirection.Desc, orderByDesc.Direction);
		}

		[Fact]
		public void Constructor_NullIColumn_ArgumentNullException()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new OrderByDesc(column: null!));
		}

		[Fact]
		public void RenderOrderByDesc_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			OrderByDesc orderByDesc = new OrderByDesc(NewColumn());

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderOrderBy(It.IsAny<OrderBy>(), It.IsAny<StringBuilder>())).Callback((OrderBy value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			orderByDesc.RenderOrderBy(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderOrderByDesc_Renderer_ReturnsSql()
		{
			// Arrange
			OrderByDesc orderByDesc = new OrderByDesc(NewColumn());

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderOrderBy(It.IsAny<OrderBy>(), It.IsAny<StringBuilder>())).Callback((OrderBy value, StringBuilder sql) => sql.Append(expectedSql));
			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = orderByDesc.RenderOrderBy(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}
	}
}
