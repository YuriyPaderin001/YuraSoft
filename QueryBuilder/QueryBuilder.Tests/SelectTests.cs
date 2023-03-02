using Xunit;

namespace YuraSoft.QueryBuilder.Tests
{
	public class SelectTests
	{
		[Fact]
		public void Create_NotSetDistinct_DistinctValueIsNull()
		{
			// Act
			Select select = new Select(c => c.Column("column"));

			// Assert
			Assert.Null(select.DistinctValue);
		}

		[Fact]
		public void CallDistinct_WithoutParameters_SetDistinctToDistinctValue()
		{
			// Arrange
			Select select = new Select(c => c.Column("column"));

			// Act
			select.Distinct();

			// Assert
			Assert.NotNull(select.DistinctValue);
			Assert.IsType<Distinct>(select.DistinctValue);
		}

		[Fact]
		public void CallDistinct_WithDistinct_SetDistinctToDistinctValue()
		{
			// Arrange
			Distinct distinct = new Distinct();
			Select select = new Select(c => c.Column("column"));

			// Act
			select.Distinct(distinct);

			// Assert
			Assert.NotNull(select.DistinctValue);
			Assert.Equal(distinct, select.DistinctValue);
		}

		[Fact]
		public void CallDistinct_WithNullDistinct_DistinctValueIsNull()
		{
			// Act
			Select select = new Select(c => c.Column("column"))
			  .Distinct(distinct: null);

			// Assert
			Assert.Null(select.DistinctValue);
		}

		[Fact]
		public void CallDistinct_ResetDistinctToNull_DistinctValueIsNull()
		{
			// Assert
			Select select = new Select(c => c.Column("column"))
			  .Distinct();

			// Act
			select.Distinct(distinct: null);

			// Assert
			Assert.Null(select.DistinctValue);
		}

		[Fact]
		public void SetDistinctValue_Distinct_SetDistinctToDistinctValue()
		{
			// Assert
			Distinct distinct = new Distinct();
			Select select = new Select(c => c.Column("column"));

			// Act
			select.DistinctValue = distinct;

			// Assert
			Assert.NotNull(select.DistinctValue);
			Assert.Equal(distinct, select.DistinctValue);
		}

		[Fact]
		public void SetDistinctValue_Null_DistinctValueIsNull()
		{
			// Assert
			Select select = new Select(c => c.Column("column"));

			// Act
			select.DistinctValue = null;

			// Assert
			Assert.Null(select.DistinctValue);
		}

		[Fact]
		public void ResetDistinctValue_Null_DistinctValueIsNull()
		{
			// Assert
			Select select = new Select(c => c.Column("column"))
			  .Distinct();

			// Act
			select.DistinctValue = null;

			// Assert
			Assert.Null(select.DistinctValue);
		}
	}
}
