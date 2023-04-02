using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Distincts
{
	public class DistinctTests : TestsBase
	{
		[Fact]
		public void RenderDistinct_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			Distinct distinct = new Distinct();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderDistinct(It.IsAny<Distinct>(), It.IsAny<StringBuilder>())).Callback((Distinct value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			distinct.RenderDistinct(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderJoin_Renderer_ReturnsSql()
		{
			// Arrange
			Distinct distinct = new Distinct();

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderDistinct(It.IsAny<Distinct>(), It.IsAny<StringBuilder>())).Callback((Distinct value, StringBuilder sql) => sql.Append(expectedSql));
			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = distinct.RenderDistinct(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}
	}
}
