using System;
using System.Collections.Generic;
using System.Linq;

namespace PravaStranaUlice.Common.Extensions
{
	/// <summary>
	/// <see cref="IEnumerable{T}"/>  extension methods.
	/// </summary>
	public static class IEnumerableExtensions
	{
		/// <summary>
		/// Returns empty enumerable sequence if <paramref name="source"/> is null.
		/// </summary>
		/// <typeparam name="T">Sequence elements type.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <returns>Empty sequence if <paramref name="source"/> is null, otherwise <paramref name="source"/> sequence.</returns>
		public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source)
			=> source ?? Enumerable.Empty<T>();

		/// <summary>
		/// Returns type of <paramref name="source"/> sequence elements.
		/// </summary>
		/// <typeparam name="T">Sequence elements type.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <returns>Type of <paramref name="source"/> sequence elements.</returns>
		public static Type ElementType<T>(this IEnumerable<T> source)
			=> typeof(T);

		/// <summary>
		/// Returns enumerable sequence of single <paramref name="source"/> element.
		/// </summary>
		/// <typeparam name="T">Sequence element type.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <returns>Sequence of single <paramref name="source"/> element.</returns>
		public static IEnumerable<T> AsEnumerable<T>(this T source)
			=> Enumerable.Repeat(source, 1);

		/// <summary>
		/// Same as FirstOrDefault() but with the null-check.
		/// </summary>
		/// <typeparam name="T">Sequence element type.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <returns>First or default element from <paramref name="source"/>.</returns>
		public static T FirstOrDefaultWithNullCheck<T>(this IEnumerable<T> source)
			=> source != null ? source.FirstOrDefault() : default(T);

		/// <summary>
		/// Surround <paramref name="source"/> items with brackets.
		/// </summary>
		/// <param name="source">The source sequence.</param>
		/// <returns>String with <paramref name="source"/> items surrounded with brackets.</returns>
		public static string ToStringWithBrackets(this IEnumerable<string> source)
			=> "(" + string.Join(")(", source) + ")";

		/// <summary>
		/// Executes specified <paramref name="action"/> on each element of the <paramref name="source"/> sequence.
		/// </summary>
		/// <typeparam name="T">Sequence elements type.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="action">Action that will be executed on each element of the sequence.</param>
		/// <returns><paramref name="source"/> sequence.</returns>
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			foreach (T item in source)
			{
				action(item);
			}

			return source;
		}

        /// <summary>
        /// Returns items from <paramref name="source"/> sequence with their corresponding indexes.
        /// </summary>
        /// <typeparam name="T">Sequence elements type.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <returns>Sequence of <paramref name="source"/> items with their indexes.</returns>
        public static IEnumerable<Tuple<T,int>> Indexed<T>(this IEnumerable<T> source)
        {
            return source.Select((item, i) => new Tuple<T, int>(item,i));
        }

        /// <summary>
        /// Concatenates provided <paramref name="element"/> to the <paramref name="source"/> sequence.
        /// </summary>
        /// <typeparam name="T">Sequence elements type.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <param name="element">Element to concatenate to the <paramref name="source"/>.</param>
        /// <returns>New sequence containing <paramref name="source"/> sequence with provided <paramref name="element"/> concatenated at the end.</returns>
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, T element)
			=> source.Concat(Enumerable.Repeat<T>(element, 1));

		/// <summary>
		/// Returns sequence with distinct elements from the <paramref name="source"/> based on keys selected by provided <paramref name="keySelector"/>.
		/// </summary>
		/// <typeparam name="T">Sequence elements type.</typeparam>
		/// <typeparam name="TKey">Key type.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="selector">Key selector.</param>
		/// <returns>Sequence that contains only distinct elements from the <paramref name="source"/> based on keys selected by provided <paramref name="keySelector"/>.</returns>
		public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
			=> source.GroupBy(keySelector).Select(x => x.First());

		/// <summary>
		/// Splits <paramref name="source"/> sequence into groups of given <paramref name="groupSize"/>.
		/// </summary>
		/// <typeparam name="T">Sequence elements type.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="groupSize">The number of elements in each group.</param>
		/// <returns>Sequence of groups from <paramref name="source"/>.</returns>
		public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, int groupSize)
			=> source.Select((item, i) => new { Index = i, Value = item }).GroupBy(x => x.Index / groupSize).Select(x => x.Select(v => v.Value));

		/// <summary>
		/// Splits <paramref name="source"/> sequence into partitions of given <paramref name="partitionSize"/>.
		/// </summary>
		/// <remarks>This method won't work for unbounded sequences. In such case use Split().</remarks>
		/// <typeparam name="T">Sequence elements type.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="partitionSize">The size of each partition.</param>
		/// <returns>Sequence of <paramref name="source"/> partitions.</returns>
		public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> source, int partitionSize)
			=> Enumerable.Range(0, (source.Count() + partitionSize - 1) / partitionSize).Select(page => source.Skip(page * partitionSize).Take(partitionSize));

		/// <summary>
		/// Flattens <paramref name="source"/> tree hierarchy to linear sequence based on provided <paramref name="childSelector"/>.
		/// </summary>
		/// <typeparam name="T">Sequence elements type.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="childSelector">Child elements selector.</param>
		/// <returns>Whole <paramref name="source"/> tree hierarchy as linear sequence.</returns>
		public static IEnumerable<T> Flatten<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childSelector)
			=> source.SelectMany(c => childSelector(c).Flatten(childSelector)).Concat(source);
	}
}
