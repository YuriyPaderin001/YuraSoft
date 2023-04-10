using System;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Joins
{
	public class CrossJoinTests : TestsBase
	{
		[Fact]
		public void Constructor_ISource_Success()
		{
			// Arrange
			ISource source = NewSource();

			// Act
			CrossJoin crossJoin = new CrossJoin(source);

			// Assert
			Assert.Equal(source, crossJoin.Source);
		}

		[Fact]
		public void Constructor_NullISource_ThrowsArgumentNullException()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new CrossJoin(source: null!));
		}


		[Fact]
		public void SetSource_ISource_Success()
		{
			// Arrange
			CrossJoin crossJoin = new CrossJoin(NewSource());
			ISource source = NewSource();

			// Act
			crossJoin.Source = source;

			// Assert
			Assert.Equal(source, crossJoin.Source);
		}

		[Fact]
		public void SetSource_NullISource_ThrowsArgumentNullException()
		{
			// Arrange
			CrossJoin crossJoin = new CrossJoin(NewSource());
			ISource source = NewSource();

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => crossJoin.Source = null!);
		}

		[Fact]
		public void RenderJoin_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			CrossJoin crossJoin = new CrossJoin(NewSource());

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderJoin(It.IsAny<CrossJoin>(), It.IsAny<StringBuilder>())).Callback((CrossJoin value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			crossJoin.RenderJoin(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderJoin_Renderer_ReturnsSql()
		{
			// Arrange
			CrossJoin crossJoin = new CrossJoin(NewSource());

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderJoin(It.IsAny<CrossJoin>(), It.IsAny<StringBuilder>())).Callback((CrossJoin value, StringBuilder sql) => sql.Append(expectedSql));
			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = crossJoin.RenderJoin(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}
	}
}
