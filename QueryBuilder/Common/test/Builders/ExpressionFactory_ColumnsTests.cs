using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace YuraSoft.QueryBuilder.Common.Tests.Builders
{
	public partial class ExpressionFactoryTests : TestsBase
	{
		#region + Columns(action: Action<ColumnBuilder>): IEnumerable<IColumn>

		[Theory]
		[InlineData(0)]
		[InlineData(1)]
		[InlineData(3)]
		public void Columns_ActionColumnBuilder_Success(int columnsCount)
		{
			// Arrange
			IEnumerable<IColumn> expectedColumns = NewColumns(columnsCount);

			Action<ColumnBuilder> action = (builder) => builder.Columns.AddRange(expectedColumns);

			// Act
			IEnumerable<IColumn> columns = ExpressionFactory.Columns(action);

			// Assert
			Assert.NotNull(columns);
			Assert.Equal(expectedColumns, columns);
		}

		[Fact]
		public void Columns_NullActionColumnBuilder_ThrowsArgumentNullException() =>
			Columns_ThrowsException<ArgumentNullException>(factory => factory.Columns(action: null!));

		#endregion + Columns(action: Action<ColumnBuilder>): IEnumerable<IColumn>

		#region + Columns(columns: IEnumerable<string>): IEnumerable<IColumn>

		[Fact]
		public void Columns_IEnumerableString_Success()
		{
			// Arrange
			IEnumerable<string> columnNames = new[] { "column_1", "column_2" };

			// Act
			IEnumerable<IColumn> columns = ExpressionFactory.Columns(columnNames);

			// Assert
			Assert.NotNull(columns);
			Assert.Equal(columnNames.Count(), columns.Count());

			IEnumerator<string> columnNamesEnumerator = columnNames.GetEnumerator();
			IEnumerator<IColumn> columnsEnumerator = columns.GetEnumerator();
			while (columnNamesEnumerator.MoveNext() && columnsEnumerator.MoveNext())
			{
				IColumn column = columnsEnumerator.Current;

				Assert.NotNull(column);

				SourceColumn sourceColumn = Assert.IsType<SourceColumn>(column);

				Assert.Equal(columnNamesEnumerator.Current, sourceColumn.Name);
				Assert.Null(sourceColumn.Alias);
				Assert.Null(sourceColumn.Source);
			}
		}

		[Fact]
		public void Columns_EmptyIEnumerableString_Success()
		{
			// Arrange
			IEnumerable<string> columnNames = Enumerable.Empty<string>();

			// Act
			IEnumerable<IColumn> columns = ExpressionFactory.Columns(columnNames);

			// Assert
			Assert.NotNull(columns);
			Assert.Empty(columns);
		}

		[Fact]
		public void Columns_NullIEnumerableString_ThrowsArgumentNullException() =>
			Columns_ThrowsException<ArgumentNullException>(factory => factory.Columns(columns: null!));

		#endregion + Columns(columns: IEnumerable<string>): IEnumerable<IColumn>

		private void Columns_ThrowsException<TException>(Func<ExpressionFactory, IEnumerable<IColumn>> columnsFunction) where TException : Exception
		{
			// Arrange & Act & Assert
			Assert.Throws<TException>(() => columnsFunction.Invoke(ExpressionFactory));
		}
	}
}
