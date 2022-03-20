using System;

using YuraSoft.QueryBuilder.Resources;

#nullable enable

namespace YuraSoft.QueryBuilder.Exceptions
{
	public class ArgumentShouldNotBeNullOrEmptyException : ArgumentException
	{
		public ArgumentShouldNotBeNullOrEmptyException(string argumentName) : base(Errors.ArgumentShouldNotBeNullOrEmpty, argumentName)
		{
		}
	}
}
