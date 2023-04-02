using System;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Joins
{
	public class InnerJoinTests : TestsBase
	{
		[Fact]
		public void Constructor_ISourceAndICondition_Success()
		{
			// Arrange
			ISource source = NewSource();
			ICondition condition = NewCondition();

			// Act
			InnerJoin innerJoin = new InnerJoin(source, condition);

			// Assert
			Assert.Equal(source, innerJoin.Source);
			Assert.Equal(condition, innerJoin.Condition);
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
			InnerJoin innerJoin = new InnerJoin(NewSource(), condition);
			ISource source = NewSource();

			// Act
			innerJoin.Source = source;

			// Assert
			Assert.Equal(source, innerJoin.Source);
			Assert.Equal(condition, innerJoin.Condition);
		}

		[Fact]
		public void SetSource_NullISource_ThrowsArgumentNullException()
		{
			// Arrange
			InnerJoin innerJoin = new InnerJoin(NewSource(), NewCondition());

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => innerJoin.Source = null!);
		}

		[Fact]
		public void SetCondition_ICondition_Success()
		{
			// Arrange
			ISource source = NewSource();
			InnerJoin innerJoin = new InnerJoin(source, NewCondition());
			ICondition condition = NewCondition();

			// Act
			innerJoin.Condition = condition;

			// Assert
			Assert.Equal(source, innerJoin.Source);
			Assert.Equal(condition, innerJoin.Condition);
		}

		[Fact]
		public void SetCondition_NullICondition_ThrowsArgumentNullException()
		{
			// Arrange
			InnerJoin innerJoin = new InnerJoin(NewSource(), NewCondition());

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => innerJoin.Condition = null!);
		}

		[Fact]
		public void RenderJoin_RendererAndStringBuilder_WritesSqlToStringBuilder()
		{
			// Arrange
			InnerJoin innerJoin = new InnerJoin(NewSource(), NewCondition());

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderJoin(It.IsAny<InnerJoin>(), It.IsAny<StringBuilder>())).Callback((InnerJoin value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			innerJoin.RenderJoin(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderJoin_Renderer_ReturnsSql()
		{
			// Arrange
			InnerJoin innerJoin = new InnerJoin(NewSource(), NewCondition());

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderJoin(It.IsAny<InnerJoin>(), It.IsAny<StringBuilder>())).Callback((InnerJoin value, StringBuilder sql) => sql.Append(expectedSql));
			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = innerJoin.RenderJoin(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_ISourceAndICondition_ThrowsArgumentNullException(ISource? source, ICondition? condition)
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new InnerJoin(source!, condition!));
		}
	}
}
