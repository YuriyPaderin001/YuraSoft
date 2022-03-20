using System;

using YuraSoft.QueryBuilder.Resources;

#nullable enable

namespace YuraSoft.QueryBuilder.Exceptions
{
	public class CollectionShouldNotContainsNullElementsException : ArgumentException
	{
		public CollectionShouldNotContainsNullElementsException(string collectionName) : base(Errors.CollectionShouldNotContainsNullElements, collectionName)
		{
		}
	}
}
