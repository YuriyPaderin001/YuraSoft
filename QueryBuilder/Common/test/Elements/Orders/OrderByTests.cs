using System;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Orders
{
	public class OrderByTests : TestsBase
	{
		[Theory]
		[InlineData(OrderDirection.Asc)]
		[InlineData(OrderDirection.Desc)]
		public void Constructor_IColumnAndOrderDirection_Success(OrderDirection direction)
		{
			// Arrange
			IColumn column = NewColumn();

			// Act
			OrderBy orderBy = new OrderBy(column, direction);

			// Assert
			Assert.Equal(column, orderBy.Column);
			Assert.Equal(direction, orderBy.Direction);
		}

		[Theory]
		[InlineData(OrderDirection.Asc)]
		[InlineData(OrderDirection.Desc)]
		public void Constructor_NullIColumnAndOrderDirection_ArgumentNullException(OrderDirection direction)
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new OrderBy(column: null!, direction));
		}

		[Fact]
		public void SetColumn_IColumn_Success()
		{
			// Arrange
			OrderDirection direction = OrderDirection.Desc;
			OrderBy orderBy = new OrderBy(NewColumn(), direction);
			IColumn column = NewColumn();

			// Act
			orderBy.Column = column;

			// Assert
			Assert.Equal(column, orderBy.Column);
			Assert.Equal(direction, orderBy.Direction);
		}

		[Theory]
		[InlineData(OrderDirection.Asc)]
		[InlineData(OrderDirection.Desc)]
		public void SetDirection_OrderDirection_Success(OrderDirection direction)
		{
			// Arrange
			IColumn column = NewColumn();
			OrderBy orderBy = new OrderBy(column, OrderDirection.Asc);

			// Act
			orderBy.Direction = direction;

			// Assert
			Assert.Equal(column, orderBy.Column);
			Assert.Equal(direction, orderBy.Direction);
		}

		[Fact]
		public void RenderOrderBy_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			OrderBy orderBy = new OrderBy(NewColumn(), OrderDirection.Asc);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderOrderBy(It.IsAny<OrderBy>(), It.IsAny<StringBuilder>())).Callback((OrderBy value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			orderBy.RenderOrderBy(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderOrderBy_Renderer_ReturnsSql()
		{
			// Arrange
			OrderBy orderBy = new OrderBy(NewColumn(), OrderDirection.Asc);

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderOrderBy(It.IsAny<OrderBy>(), It.IsAny<StringBuilder>())).Callback((OrderBy value, StringBuilder sql) => sql.Append(expectedSql));
			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = orderBy.RenderOrderBy(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}
	}
}
