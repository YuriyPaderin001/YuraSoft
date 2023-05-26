﻿using System;
using System.Text;
using Moq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Elements.Joins
{
	public class LeftJoinTests : TestsBase
	{
		[Fact]
		public void Constructor_ISourceAndICondition_Success()
		{
			// Arrange
			ISource source = NewSource();
			ICondition condition = NewCondition();

			// Act
			LeftJoin leftJoin = new LeftJoin(source, condition);

			// Assert
			Assert.Equal(source, leftJoin.Source);
			Assert.Equal(condition, leftJoin.Condition);
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
			LeftJoin leftJoin = new LeftJoin(NewSource(), NewCondition());

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderJoin(It.IsAny<LeftJoin>(), It.IsAny<StringBuilder>())).Callback((LeftJoin value, StringBuilder sql) =>
			{
				sql.Append(expectedSql);
			});

			IRenderer renderer = rendererMock.Object;
			StringBuilder sql = new StringBuilder();

			// Act
			leftJoin.RenderJoin(renderer, sql);

			// Assert
			Assert.Equal(expectedSql, sql.ToString());
		}

		[Fact]
		public void RenderJoin_Renderer_ReturnsSql()
		{
			// Arrange
			LeftJoin leftJoin = new LeftJoin(NewSource(), NewCondition());

			const string expectedSql = "test";

			Mock<IRenderer> rendererMock = new Mock<IRenderer>();
			rendererMock.Setup(ca => ca.RenderJoin(It.IsAny<LeftJoin>(), It.IsAny<StringBuilder>())).Callback((LeftJoin value, StringBuilder sql) => sql.Append(expectedSql));
			IRenderer renderer = rendererMock.Object;

			// Act
			string sql = leftJoin.RenderJoin(renderer);

			// Assert
			Assert.Equal(expectedSql, sql);
		}

		private void Constructor_ISourceAndICondition_ThrowsArgumentNullException(ISource? source, ICondition? condition)
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new LeftJoin(source!, condition!));
		}
	}
}
