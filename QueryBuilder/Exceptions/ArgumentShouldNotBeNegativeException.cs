using System;

using YuraSoft.QueryBuilder.Resources;

#nullable enable

namespace YuraSoft.QueryBuilder.Exceptions
{
	public class ArgumentShouldNotBeNegativeException : ArgumentNullException
	{
		public ArgumentShouldNotBeNegativeException(string argumentName) : base(argumentName, Shared.Err_ArgumentShouldNotBeNegative)
		{
		}
	}
}
