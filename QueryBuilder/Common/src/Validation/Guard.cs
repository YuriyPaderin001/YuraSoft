using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace YuraSoft.QueryBuilder.Common.Validation
{
	public static partial class Guard
	{
		/// <summary>
		/// Throws <see cref="ArgumentNullException"/> if <paramref name="argument"/> is <see langword="null"/> or 
		/// <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument"/> is empty enumerable or 
		/// <see cref="ArgumentException"/> if <paramref name="argument"/> contains <see langword="null"/> elements 
		/// </summary>
		/// <typeparam name="T"><see cref="Type"/> of argument</typeparam>
		/// <param name="argument">Enumerable</param>
		/// <param name="argumentName">Argument name</param>
		/// <returns>Returns <paramref name="argument"/></returns>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public static T ThrowIfNullOrEmptyOrContainsNullElements<T>([NotNull] T argument, string argumentName) where T : IEnumerable
		{
			ThrowIfNullOrEmpty(argument, argumentName);
			ThrowIfContainsNullElements(argument, argumentName);

			return argument;
		}

		/// <summary>
		/// Throws <see cref="ArgumentNullException"/> if <paramref name="argument"/> is <see langword="null"/> or 
		/// <see cref="ArgumentException"/> if <paramref name="argument"/> contains <see langword="null"/> elements
		/// </summary>
		/// <typeparam name="T"><see cref="Type"/> of argument</typeparam>
		/// <param name="argument">Enumerable</param>
		/// <param name="argumentName">Argument name</param>
		/// <returns>Returns <paramref name="argument"/></returns>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		public static T ThrowIfNullOrContainsNullElements<T>([NotNull] T argument, string argumentName) where T : IEnumerable
		{
			ThrowIfNull(argument, argumentName);
			ThrowIfContainsNullElements(argument, argumentName);

			return argument;
		}

		/// <summary>
		/// Throws <see cref="ArgumentNullException"/> if <paramref name="argument"/> is <see langword="null"/> or
		/// <see cref="ArgumentException"/> if <paramref name="argument"/> contains <see langword="null"/> or empty string elements
		/// </summary>
		/// <typeparam name="T"><see cref="Type"/> of argument</typeparam>
		/// <param name="argument">String enumerable</param>
		/// <param name="argumentName">Argument name</param>
		/// <returns>Returns <paramref name="argument"/></returns>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		public static T ThrowIfNullOrContainsNullOrEmptyElements<T>([NotNull] T argument, string argumentName) where T : IEnumerable<string>
		{
			ThrowIfNull(argument, argumentName);
			ThrowIfContainsNullOrEmptyElements(argument, argumentName);

			return argument;
		}

		/// <summary>
		/// Throws <see cref="ArgumentNullException"/> if <paramref name="argument"/> is <see langword="null"/> or 
		/// <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument"/> size less than <paramref name="minSize"/>
		/// </summary>
		/// <typeparam name="T"><see cref="Type"/> of argument</typeparam>
		/// <param name="argument">Enumerable</param>
		/// <param name="minSize">Minimal <paramref name="argument"/> size</param>
		/// <param name="argumentName">Argument name</param>
		/// <returns>Returns <paramref name="argument"/></returns>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public static T ThrowIfNullOrSizeLessThan<T>([NotNull] T argument, int minSize, string argumentName) where T : IEnumerable
		{
			ThrowIfNull(argument, argumentName);

			IEnumerator enumerator = argument.GetEnumerator();
			for (int i = 0; i < minSize; i++)
			{
				if (!enumerator.MoveNext())
				{
					throw new ArgumentOutOfRangeException(argumentName, ErrorMessages.ArgumentSizeShouldNotBeLessThan);
				}
			}

			return argument;
		}

		/// <summary>
		/// Throws <see cref="ArgumentNullException"/> if <paramref name="argument"/> is <see langword="null"/>
		/// </summary>
		/// <typeparam name="T"><see cref="Type"/> of argument</typeparam>
		/// <param name="argument">Object</param>
		/// <param name="argumentName">Argument name</param>
		/// <returns>Returns <paramref name="argument"/></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static T ThrowIfNull<T>([NotNull] T argument, string argumentName)
		{
			if (argument == null)
			{
				throw new ArgumentNullException(argumentName, ErrorMessages.ArgumentShouldNotBeNull);
			}

			return argument;
		}

		/// <summary>
		/// Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument"/> is empty
		/// </summary>
		/// <typeparam name="T"><see cref="Type"/> of argument</typeparam>
		/// <param name="argument">Enumerable</param>
		/// <param name="argumentName">Argument name</param>
		/// <returns>Returns <paramref name="argument"/></returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public static T ThrowIfEmpty<T>(T argument, string argumentName) where T : IEnumerable
		{
			if (argument != null && !argument.GetEnumerator().MoveNext())
			{
				throw new ArgumentOutOfRangeException(argumentName, ErrorMessages.ArgumentShouldNotBeEmpty);
			}

			return argument!;
		}

		/// <summary>
		/// Throws <see cref="ArgumentException"/> if <paramref name="argument"/> is <see langword="null"/> or empty string
		/// </summary>
		/// <param name="argument">String</param>
		/// <param name="argumentName">Argument name</param>
		/// <returns>Returns <paramref name="argument"/></returns>
		/// <exception cref="ArgumentException"></exception>
		public static string ThrowIfNullOrEmpty([NotNull] string? argument, string argumentName)
		{
			if (string.IsNullOrEmpty(argument))
			{
				throw new ArgumentException(argumentName, ErrorMessages.ArgumentShouldNotBeNullOrEmpty);
			}

			return argument;
		}

		/// <summary>
		/// Throws <see cref="ArgumentNullException"/> if <paramref name="argument"/> is <see langword="null"/> or 
		/// <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument"/> is empty enumerable
		/// </summary>
		/// <typeparam name="T"><see cref="Type"/> of argument</typeparam>
		/// <param name="argument">Enumerable</param>
		/// <param name="argumentName">Argument name</param>
		/// <returns>Returns <paramref name="argument"/></returns>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public static T ThrowIfNullOrEmpty<T>([NotNull] T argument, string argumentName) where T : IEnumerable
		{
			ThrowIfNull(argument, argumentName);
			ThrowIfEmpty(argument, argumentName);

			return argument;
		}

		/// <summary>
		/// Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument"/> is negative number
		/// </summary>
		/// <param name="argument">Number</param>
		/// <param name="argumentName">Argument name</param>
		/// <returns>Returns <paramref name="argument"/></returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public static int ThrowIfNegative(int argument, string argumentName)
		{
			if (argument < 0)
			{
				throw new ArgumentOutOfRangeException(argumentName, ErrorMessages.ArgumentShouldNotBeNegative);
			}

			return argument;
		}

		/// <summary>
		/// Throws <see cref="ArgumentException"/> if <paramref name="argument"/> contains <see langword="null"/> or empty string elements
		/// </summary>
		/// <param name="argument">String enumerable</param>
		/// <param name="argumentName">Argument name</param>
		/// <exception cref="ArgumentException"></exception>
		private static void ThrowIfContainsNullOrEmptyElements(IEnumerable<string> argument, string argumentName)
		{
			foreach (string? item in argument)
			{
				if (string.IsNullOrEmpty(item))
				{
					throw new ArgumentException(argumentName, ErrorMessages.ArgumentShouldNotContainsNullOrEmptyElements);
				}
			}
		}

		/// <summary>
		/// Throws <see cref="ArgumentException"/> if <paramref name="argument"/> contains <see langword="null"/> elements
		/// </summary>
		/// <param name="argument">Enumerable</param>
		/// <param name="argumentName">Argument name</param>
		/// <exception cref="ArgumentException"></exception>
		private static void ThrowIfContainsNullElements(IEnumerable argument, string argumentName)
		{
			foreach (object? item in argument)
			{
				if (item == null)
				{
					throw new ArgumentException(argumentName, ErrorMessages.ArgumentShouldNotContainsNullElements);
				}
			}
		}
	}
}
