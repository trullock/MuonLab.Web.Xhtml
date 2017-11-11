using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MuonLab.Testing
{
	public static class CollectionExtensions
	{
		public static void ShouldBeEmpty(this IEnumerable collection)
		{
			Assert.Empty(collection);
		}

		public static bool ContainsAny<T>(this IEnumerable<T> collection, IEnumerable<T> values)
		{
			foreach (T item in values)
			{
				if (collection.Contains<T>(item))
				{
					return true;
				}
			}
			return false;
		}

		public static void ShouldContain<T>(this IEnumerable<T> actual, params T[] expected)
		{
			foreach (T item in expected)
				Assert.Contains(item, actual);
		}

		public static void ShouldContain(this IEnumerable actual, params object[] expected)
		{
			foreach (object item in expected)
				Assert.Contains(item, actual.Cast<object>());
		}

		public static void ShouldContainOnly<T>(this IEnumerable<T> actual, params T[] expected)
		{
			actual.ShouldContainOnly(new List<T>(expected));
		}

		public static void ShouldContainOnly<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
		{
			var actualList = new List<T>(actual);
			var remainingList = new List<T>(actualList);
			foreach (T item in expected)
			{
				Assert.Contains(item, actualList);
				remainingList.Remove(item);
			}
			Assert.Empty(remainingList);
		}

		public static void ShouldNotBeEmpty(this IEnumerable collection)
		{
			Assert.NotEmpty(collection);
		}

		public static void ShouldNotContain(this IEnumerable collection, object expected)
		{
			int i = 0;
			foreach (var item in collection)
			{
				if (item.Equals(expected))
					Assert.False(true, "Collection DOES contain item at position " + i);
				i++;
			}
		}
	}
}