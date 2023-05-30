using System;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Joins
{
	public class FullJoinTests : TestsBase
	{
		[Fact]
		public void Constructor_ISourceAndICondition_Success()
		{
			// Arrange
			ISource source = NewSource();
			ICondition condition = NewCondition();

			// Act
			FullJoin join = new FullJoin(source, condition);

			// Assert
			Assert.Equal(source, join.Source);
			Assert.Equal(condition, join.Condition);
		}

		[Fact]
		public void Constructor_NullISourceAndICondition_ThrowsArgumentNullException() =>
			Constructor_ISourceAndICondition_ThrowsArgumentNullException(source: null, NewCondition());

		[Fact]
		public void Constructor_ISourceAndNullICondition_ThrowsArgumentNullException() =>
			Constructor_ISourceAndICondition_ThrowsArgumentNullException(NewSource(), condition: null);

		[Fact]
		public void Constructor_NullISourceAndNullICondition_ThrowsArgumentNullException() =>
			Constructor_ISourceAndICondition_ThrowsArgumentNullException(source: null, condition: null);

		[Fact]
		public void RenderJoin_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			FullJoin join = new FullJoin(NewSource(), NewCondition());

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderJoin(It.IsAny<FullJoin>(), It.IsAny<StringBuilder>())).Callback((FullJoin value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			join.RenderJoin(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderJoin_Renderer_ReturnsSql()
		{
			// Arrange
			FullJoin join = new FullJoin(NewSource(), NewCondition());

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderJoin(It.IsAny<FullJoin>(), It.IsAny<StringBuilder>())).Callback((FullJoin value, StringBuilder sql) => sql.Append(expectedSql));
			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = join.RenderJoin(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_ISourceAndICondition_ThrowsArgumentNullException(ISource? source, ICondition? condition)
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new FullJoin(source!, condition!));
		}
	}
}
