using System;

using YuraSoft.QueryBuilder.Resources;

#nullable enable

namespace YuraSoft.QueryBuilder.Exceptions
{
	public class CollectionShouldNotBeEmptyException : ArgumentException
	{
		public CollectionShouldNotBeEmptyException(string collectionName) : base(Shared.Err_CollectionShouldNotBeEmpty, collectionName)
		{
		}
	}
}
