using System;

using YuraSoft.QueryBuilder.Resources;

#nullable enable

namespace YuraSoft.QueryBuilder.Exceptions
{
	public class CollectionShouldNotContainsNullOrEmptyElementsException : ArgumentException
	{
		public CollectionShouldNotContainsNullOrEmptyElementsException(string collectionName) : base(Shared.Err_CollectionShouldNotContainsNullOrEmptyElements, collectionName)
		{
		}
	}
}
