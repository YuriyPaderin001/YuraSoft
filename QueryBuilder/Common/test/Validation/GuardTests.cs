using System;
using Xunit;

using YuraSoft.QueryBuilder.Common.Validation;

namespace YuraSoft.QueryBuilder.Common.Tests.Validation
{
	public class GuardTests
	{
		[Fact]
		public void ThrowIfNullOrEmptyOrContainsNullElements_Valid_ReturnsValue()
		{
			// Arrange
			int[] value = new int[] { 1, 2, 3 };

			// Act
			int[] returnedValue = Guard.ThrowIfNullOrEmptyOrContainsNullElements<int[]>(value, nameof(value));

			// Assert
			Assert.Equal(value, returnedValue);
		}

		[Fact]
		public void ThrowIfNullOrEmptyOrContainsNullElements_Null_ThrowsArgumentException()
		{
			// Arrange
			int[]? value = null;

			// Act
			Action action = () => Guard.ThrowIfNullOrEmptyOrContainsNullElements<int[]>(value!, nameof(value));

			// Assert
			Assert.ThrowsAny<ArgumentException>(action);
		}

		[Fact]
		public void ThrowIfNullOrEmptyOrContainsNullElements_Empty_ThrowsArgumentException()
		{
			// Arrange
			int[] value = Array.Empty<int>();

			// Act
			Action action = () => Guard.ThrowIfNullOrEmptyOrContainsNullElements<int[]>(value!, nameof(value));

			// Assert
			Assert.ThrowsAny<ArgumentException>(action);
		}

		[Fact]
		public void ThrowIfNullOrEmptyOrContainsNullElements_WithNullElements_ThrowsArgumentException()
		{
			// Arrange
			int?[] value = new int?[] { 1, null, 2, 3 };

			// Act
			Action action = () => Guard.ThrowIfNullOrEmptyOrContainsNullElements<int?[]>(value, nameof(value));

			// Assert
			Assert.ThrowsAny<ArgumentException>(action);
		}

		[Fact]
		public void ThrowIfNullOrContainsNullElements_Valid_ReturnsValue()
		{
			// Arrange
			int[] value = new int[] { 1, 2, 3 };

			// Act
			int[] returnedValue = Guard.ThrowIfNullOrContainsNullElements<int[]>(value, nameof(value));

			// Assert
			Assert.Equal(value, returnedValue);
		}

		[Fact]
		public void ThrowIfNullOrContainsNullElmenets_Null_ThrowsArgumentException()
		{
			// Arrange
			int[]? value = null;

			// Act
			Action action = () => Guard.ThrowIfNullOrContainsNullElements<int[]>(value!, nameof(value));

			// Assert
			Assert.ThrowsAny<ArgumentException>(action);
		}

		[Fact]
		public void ThrowIfNullOrContainsNullElements_WithNullElements_ThrowsArgumentException()
		{
			// Arrange
			int?[] value = new int?[] { 1, 2, null, 3 };

			// Act
			Action action = () => Guard.ThrowIfNullOrContainsNullElements<int?[]>(value, nameof(value));

			// Assert
			Assert.ThrowsAny<ArgumentException>(action);
		}

		[Fact]
		public void ThrowIfNullOrContainsNullOrEmptyElements_Valid_ReturnsValue()
		{
			// Arrange
			string[] value = new string[] { "test1", "test2", "test3" };

			// Act
			string[] returnedValue = Guard.ThrowIfNullOrContainsNullOrEmptyElements<string[]>(value, nameof(value));

			// Assert
			Assert.Equal(value, returnedValue);
		}

		[Fact]
		public void ThrowIfNullOrContainsNullOrEmptyElements_Null_ThrowsArgumentException()
		{
			// Arrange
			string[]? value = null;

			// Act
			Action action = () => Guard.ThrowIfNullOrContainsNullOrEmptyElements<string[]>(value!, nameof(value));

			// Assert
			Assert.ThrowsAny<ArgumentException>(action);
		}

		[Fact]
		public void ThrowIfNullOrContainsNullOrEmptyElements_WithNullElements_ThrowsArgumentException()
		{
			// Arrange
			string?[] value = new string?[] { "test1", "test2", null };

			// Act
			Action action = () => Guard.ThrowIfNullOrContainsNullOrEmptyElements<string[]>(value!, nameof(value));

			// Assert
			Assert.ThrowsAny<ArgumentException>(action);
		}

		[Fact]
		public void ThrowIfNullOrContainsNullOrEmptyElements_WithEmptyElements_ThrowsArgumentException()
		{
			// Arrange
			string[] value = new string[] { "test1", "", "test3" };

			// Act
			Action action = () => Guard.ThrowIfNullOrContainsNullOrEmptyElements<string[]>(value, nameof(value));

			// Assert
			Assert.ThrowsAny<ArgumentException>(action);
		}

		[Theory]
		[InlineData(3)]
		[InlineData(2)]
		[InlineData(0)]
		public void ThrowIfNullOrSizeLessThan_Valid_ReturnsValue(int minSize)
		{
			// Arrange
			int[] value = new int[] { 1, 2, 3 };

			// Act
			int[] returnedValue = Guard.ThrowIfNullOrSizeLessThan(value, minSize, nameof(value));

			// Assert
			Assert.Equal(value, returnedValue);
		}

		[Fact]
		public void ThrowIfNullOrSizeLessThan_Null_ThrowsArgumentException()
		{
			// Arrange
			int[]? value = null;

			// Act
			Action action = () => Guard.ThrowIfNullOrSizeLessThan<int[]>(value!, minSize: 5, nameof(value));

			// Assert
			Assert.ThrowsAny<ArgumentException>(action);
		}

		[Fact]
		public void ThrowIfNullOrSizeLessThan_SizeLess_ThrowsArgumentException()
		{
			// Arrange
			const int minSize = 5;
			int[] value = new int[] { 1, 2, 3 };

			// Act
			Action action = () => Guard.ThrowIfNullOrSizeLessThan(value, minSize, nameof(value));

			// Assert
			Assert.ThrowsAny<ArgumentException>(action);
		}

		[Theory]
		[InlineData("")]
		[InlineData("test")]
		public void ThrowIfNull_Valid_ReturnsValue(string value)
		{
			// Act
			string returnedValue = Guard.ThrowIfNull<string>(value, nameof(value));

			// Assert
			Assert.Equal(value, returnedValue);
		}

		[Fact]
		public void ThrowIfNull_Null_ThrowsArgumentNullException()
		{
			// Arrange
			string? value = null;

			// Act
			Action action = () => Guard.ThrowIfNull(value, nameof(value));

			// Assert
			Assert.Throws<ArgumentNullException>(action);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("test")]
		public void ThrowIfEmpty_Valid_ReturnsValue(string? value)
		{
			// Act
			string returnedValue = Guard.ThrowIfEmpty<string>(value!, nameof(value));

			// Assert
			Assert.Equal(value, returnedValue);
		}

		[Fact]
		public void ThrowIfEmpty_Empty_ThrowsArgumentOutOfRangeException()
		{
			// Arrange
			string value = string.Empty;

			// Act
			Action action = () => Guard.ThrowIfEmpty<string>(value, nameof(value));

			// Assert
			Assert.Throws<ArgumentOutOfRangeException>(action);
		}

		[Fact]
		public void ThrowIfNullOrEmpty_ValidString_ReturnsValue()
		{
			// Arrange
			string value = "test";

			// Act
			string returnedValue = Guard.ThrowIfNullOrEmpty(value, nameof(value));

			// Assert
			Assert.Equal(value, returnedValue);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void ThrowIfNullOrEmpty_NullOrEmptyString_ThrowArgumentException(string? value)
		{
			// Act
			Action action = () => Guard.ThrowIfNullOrEmpty(value, nameof(value));

			// Assert
			Assert.Throws<ArgumentException>(action);
		}

		[Fact]
		public void ThrowIfNullOrEmpty_ValidEnumerable_ReturnsValue()
		{
			// Arrange
			int[] value = new int[] { 1, 2, 3 };

			// Act
			int[] returnedValue = Guard.ThrowIfNullOrEmpty<int[]>(value, nameof(value));

			// Assert
			Assert.Equal(value, returnedValue);
		}

		[Fact]
		public void ThrowIfNullOrEmpty_NullEnumerable_ThrowsArgumentNullException()
		{
			// Arrange
			int[]? value = null;

			// Act
			Action action = () => Guard.ThrowIfNullOrEmpty<int[]>(value!, nameof(value));

			// Assert
			Assert.Throws<ArgumentNullException>(action);
		}

		[Fact]
		public void ThrowIfNullOrEmpty_EmptyEnumerable_ThrowsArgumentOutOfRangeException()
		{
			// Arrange
			int[] value = Array.Empty<int>();

			// Act
			Action action = () => Guard.ThrowIfNullOrEmpty<int[]>(value, nameof(value));

			// Assert
			Assert.Throws<ArgumentOutOfRangeException>(action);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(5)]
		public void ThrowIfNegative_ZeroOrPositive_ReturnsValue(int value)
		{
			// Act
			int returnedValue = Guard.ThrowIfNegative(value, nameof(value));

			// Assert
			Assert.Equal(value, returnedValue);
		}

		[Fact]
		public void ThrowIfNegative_Negative_ThrowsArgumentOutOfRangeException()
		{
			// Arrange
			int value = -5;

			// Act
			Action action = () => Guard.ThrowIfNegative(value, nameof(value));

			// Assert
			Assert.Throws<ArgumentOutOfRangeException>(action);
		}
	}
}
