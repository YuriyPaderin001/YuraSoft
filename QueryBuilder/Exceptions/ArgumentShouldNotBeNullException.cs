using System;

using YuraSoft.QueryBuilder.Resources;

#nullable enable

namespace YuraSoft.QueryBuilder.Exceptions
{
	public class ArgumentShouldNotBeNullException : ArgumentNullException
	{
		public ArgumentShouldNotBeNullException(string argumentName) : base(argumentName, Errors.ArgumentShouldNotBeNullOrEmpty)
		{
		}
	}
}
