using System;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Joins
{
	public class RightJoinTests : TestsBase
	{
		[Fact]
		public void Constructor_ISourceAndICondition_Success()
		{
			// Arrange
			ISource source = NewSource();
			ICondition condition = NewCondition();

			// Act
			RightJoin rightJoin = new RightJoin(source, condition);

			// Assert
			Assert.Equal(source, rightJoin.Source);
			Assert.Equal(condition, rightJoin.Condition);
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
		public void SetSource_ISource_Success()
		{
			// Arrange
			ICondition condition = NewCondition();
			RightJoin rightJoin = new RightJoin(NewSource(), condition);
			ISource source = NewSource();

			// Act
			rightJoin.Source = source;

			// Assert
			Assert.Equal(source, rightJoin.Source);
			Assert.Equal(condition, rightJoin.Condition);
		}

		[Fact]
		public void SetSource_NullISource_ThrowsArgumentNullException()
		{
			// Arrange
			RightJoin rightJoin = new RightJoin(NewSource(), NewCondition());

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => rightJoin.Source = null!);
		}

		[Fact]
		public void SetCondition_ICondition_Success()
		{
			// Arrange
			ISource source = NewSource();
			RightJoin rightJoin = new RightJoin(source, NewCondition());
			ICondition condition = NewCondition();

			// Act
			rightJoin.Condition = condition;

			// Assert
			Assert.Equal(source, rightJoin.Source);
			Assert.Equal(condition, rightJoin.Condition);
		}

		[Fact]
		public void SetCondition_NullICondition_ThrowsArgumentNullException()
		{
			// Arrange
			RightJoin rightJoin = new RightJoin(NewSource(), NewCondition());

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => rightJoin.Condition = null!);
		}

		[Fact]
		public void RenderJoin_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			RightJoin rightJoin = new RightJoin(NewSource(), NewCondition());

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderJoin(It.IsAny<RightJoin>(), It.IsAny<StringBuilder>())).Callback((RightJoin value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			rightJoin.RenderJoin(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderJoin_Renderer_ReturnsSql()
		{
			// Arrange
			RightJoin rightJoin = new RightJoin(NewSource(), NewCondition());

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderJoin(It.IsAny<RightJoin>(), It.IsAny<StringBuilder>())).Callback((RightJoin value, StringBuilder sql) => sql.Append(expectedSql));
			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = rightJoin.RenderJoin(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_ISourceAndICondition_ThrowsArgumentNullException(ISource? source, ICondition? condition)
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new RightJoin(source!, condition!));
		}
	}
}
