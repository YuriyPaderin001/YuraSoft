using System;
using System.Collections;
using System.Collections.Generic;

using YuraSoft.QueryBuilder.Resources;

namespace YuraSoft.QueryBuilder.Validation
{
	public static class Validator
	{
		public static T ThrowIfArgumentIsNullOrEmptyOrContainsNullElements<T>(T argument, string argumentName) where T : IEnumerable
		{
			ThrowIfArgumentIsNullOrEmpty(argument, argumentName);
			ThrowIfArgumentContainsNullElements(argument, argumentName);

			return argument;
		}

		public static T ThrowIfArgumentIsNullOrContainsNullElements<T>(T argument, string argumentName) where T : IEnumerable
		{
			ThrowIfArgumentIsNull(argument, argumentName);
			ThrowIfArgumentContainsNullElements(argument, argumentName);

			return argument;
		}

		public static T ThrowIfArgumentIsNullOrContainsNullOrEmptyElements<T>(T argument, string argumentName) where T : IEnumerable<string>
		{
			ThrowIfArgumentIsNull(argument, argumentName);
			ThrowIfArgumentContainsNullOrEmptyElements(argument, argumentName);

			return argument;
		}

		public static T ThrowIfArgumentIsNullOrArgumentSizeIsLessThan<T>(T argument, int minSize, string argumentName) where T : IEnumerable
		{
			ThrowIfArgumentIsNull(argument, argumentName);

			IEnumerator enumerator = argument.GetEnumerator();
			for (int i = 0; i < minSize; i++)
			{
				if (!enumerator.MoveNext())
				{
					throw new ArgumentOutOfRangeException(argumentName, Shared.Err_ArgumentSizeShouldNotBeLessThan);
				}
			}

			return argument;
		}

		public static T ThrowIfArgumentIsNull<T>(T argument, string argumentName)
		{
			if (argument == null)
			{
				throw new ArgumentNullException(argumentName, Shared.Err_ArgumentShouldNotBeNull);
			}

			return argument;
		}

		public static T ThrowIfArgumentIsEmpty<T>(T argument, string argumentName) where T: IEnumerable
		{
			if (!argument.GetEnumerator().MoveNext())
			{
				throw new ArgumentOutOfRangeException(argumentName, Shared.Err_ArgumentShouldNotBeEmpty);
			}

			return argument;
		}

		public static string ThrowIfArgumentIsNullOrEmpty(string argument, string argumentName)
		{
			if (string.IsNullOrEmpty(argument))
			{
				throw new ArgumentException(argumentName, Shared.Err_ArgumentShouldNotBeNullOrEmpty);
			}

			return argument;
		}

		public static T ThrowIfArgumentIsNullOrEmpty<T>(T argument, string argumentName) where T: IEnumerable
		{
			if (argument == null || !argument.GetEnumerator().MoveNext())
			{
				throw new ArgumentException(argumentName, Shared.Err_ArgumentShouldNotBeNullOrEmpty);
			}

			return argument;
		}

		public static int ThrowIfArgumentIsNegative(int argument, string argumentName)
		{
			if (argument < 0)
			{
				throw new ArgumentException(argumentName, Shared.Err_ArgumentShouldNotBeNegative);
			}

			return argument;
		}

		private static void ThrowIfArgumentContainsNullOrEmptyElements(IEnumerable<string> argument, string argumentName) 
		{
			foreach (string? item in argument)
			{
				if (string.IsNullOrEmpty(item))
				{
					throw new ArgumentException(argumentName, Shared.Err_ArgumentShouldNotContainsNullOrEmptyElements);
				}
			}
		}

		private static void ThrowIfArgumentContainsNullElements(IEnumerable argument, string argumentName)
		{
			foreach (object? item in argument)
			{
				if (item == null)
				{
					throw new ArgumentException(argumentName, Shared.Err_ArgumentShouldNotContainsNullElements);
				}
			}
		}
	}
}
