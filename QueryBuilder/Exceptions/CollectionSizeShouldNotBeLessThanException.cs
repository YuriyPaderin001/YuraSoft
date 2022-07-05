using System;

using YuraSoft.QueryBuilder.Resources;

#nullable enable

namespace YuraSoft.QueryBuilder.Exceptions
{
	public class CollectionShouldNotBeLessThanException : ArgumentOutOfRangeException
	{
		public CollectionShouldNotBeLessThanException(string collectionName, int minLength) : base(collectionName, minLength, Shared.Err_CollectionSizeShouldNotBeLessThan)
		{
		}
	}
}
