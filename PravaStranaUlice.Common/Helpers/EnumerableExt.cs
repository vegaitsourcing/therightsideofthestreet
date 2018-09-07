using System;
using System.Collections.Generic;
using System.Linq;

namespace PravaStranaUlice.Common.Helpers
{
	/// <summary>
	/// Extended <see cref="Enumerable"/> class.
	/// </summary>
	public static class EnumerableExt
	{
		/// <summary>
		/// Returns sequence from provided <paramref name="items"/>.
		/// </summary>
		/// <typeparam name="T">Sequence elements type.</typeparam>
		/// <param name="items">Elements of the returned sequence.</param>
		/// <returns>Sequence of <paramref name="items"/>.</returns>
		public static IEnumerable<T> From<T>(params T[] items)
			=> items ?? Enumerable.Empty<T>();

		/// <summary>
		/// Returns sequence of <paramref name="count"/> elements whose values are created by provided <paramref name="valueFactory"/>.
		/// </summary>
		/// <typeparam name="T">Sequence elements type.</typeparam>
		/// <param name="count">Number of elements in the sequence.</param>
		/// <param name="valueFactory">The value factory.</param>
		/// <returns>Sequence of <paramref name="count"/> elements whose values are created by provided <paramref name="valueFactory"/>.</returns>
		public static IEnumerable<T> Range<T>(int count, Func<int, T> valueFactory)
		{
			for (int i = 0; i <= count - 1; ++i)
			{
				yield return valueFactory(i);
			}
		}
	}
}
