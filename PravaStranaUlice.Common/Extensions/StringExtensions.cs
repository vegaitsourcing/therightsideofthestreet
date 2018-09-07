using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace PravaStranaUlice.Common.Extensions
{
	/// <summary>
	/// <see cref="string"/> extension methods.
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Checks if <paramref name="source"/> string is null or empty.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <returns><c>true</c> if <paramref name="source"/> string is null or empty, otherwise <c>false</c>.</returns>
		public static bool IsNullOrEmpty(this string source)
			=> string.IsNullOrEmpty(source);

		/// <summary>
		/// Checks if <paramref name="source"/> string is null, empty or contains only whitespace.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <returns><c>true</c> if <paramref name="source"/> string is null, empty or contains only whitespace, otherwise <c>false</c>.</returns>
		public static bool IsNullOrWhiteSpace(this string source)
			=> string.IsNullOrWhiteSpace(source);

		/// <summary>
		/// Returns empty string if <paramref name="source"/> string is null.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <returns>Empty string if <paramref name="source"/> is null, otherwise <paramref name="source"/> string.</returns>
		public static string EmptyIfNull(this string source)
			=> source ?? string.Empty;

		/// <summary>
		/// Checks if <paramref name="source"/> string is equal to specified integer value.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <param name="i">The integer value.</param>
		/// <returns><c>true</c> if <paramref name="source"/> string is equal to specified integer value, otherwise <c>false</c>.</returns>
		public static bool EqualsInt(this string source, int i) // Can't simply be named Equals as extension resolution mechanism will always prefer string.Equals(obj) overload
			=> string.Equals(source, i.ToString());

		/// <summary>
		/// Returns <paramref name="source"/> string with the first character uppercased.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <returns><paramref name="source"/> string with the first character uppercased.</returns>
		public static string UppercaseFirst(this string source)
			=> source.IsNullOrWhiteSpace() ? source : $"{char.ToUpper(source[0])}{(source.Length > 1 ? source.Substring(1) : string.Empty)}";

		/// <summary>
		/// Compresses multiple repeating whitespace from the <paramref name="source"/> string, replacing them with specified <paramref name="replacement"/> string.
		/// If <paramref name="replacement"/> is not specified, first whitespace char will be used as replacement.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <param name="replacement">The replacement for multiple repeating whitespace.</param>
		/// <returns><paramref name="source"/> string without multiple repeating whitespace.</returns>
		public static string CompressWhiteSpace(this string source, string replacement = null)
			=> Regex.Replace(source, @"(\s)\s+", replacement ?? "$1");

		/// <summary>
		/// Removes all instances of the <paramref name="trimString"/> string from the start of the <paramref name="source"/> string.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <param name="trimString">String to trim from the <paramref name="source"/>.</param>
		/// <param name="comparisonType">Determines how <paramref name="source"/> and <paramref name="trimString"/> strings are compared to each other.</param>
		/// <returns><paramref name="source"/> string without <paramref name="trimString"/> at the start.</returns>
		public static string TrimStart(this string source, string trimString, StringComparison comparisonType = StringComparison.CurrentCulture)
		{
			if (trimString.IsNullOrEmpty()) return source;

			while (source.StartsWith(trimString, comparisonType))
			{
				source = source.Remove(0, trimString.Length);
			}

			return source;
		}

		/// <summary>
		/// Removes all instances of the <paramref name="trimString"/> string from the end of the <paramref name="source"/> string.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <param name="trimString">String to trim from the <paramref name="source"/>.</param>
		/// <param name="comparisonType">Determines how <paramref name="source"/> and <paramref name="trimString"/> strings are compared to each other.</param>
		/// <returns><paramref name="source"/> string without <paramref name="trimString"/> at the end.</returns>
		public static string TrimEnd(this string source, string trimString, StringComparison comparisonType = StringComparison.CurrentCulture)
		{
			if (trimString.IsNullOrEmpty()) return source;

			while (source.EndsWith(trimString, comparisonType))
			{
				source = source.Remove(source.Length - trimString.Length);
			}

			return source;
		}

		/// <summary>
		/// Removes (at most one instance of) the <paramref name="removeString"/> string from the start of the <paramref name="source"/> string.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <param name="removeString">String to remove from the <paramref name="source"/>.</param>
		/// <param name="comparisonType">Determines how <paramref name="source"/> and <paramref name="removeString"/> strings are compared to each other.</param>
		/// <returns><paramref name="source"/> string without <paramref name="removeString"/> at the start.</returns>
		public static string RemovePrefix(this string source, string removeString, StringComparison comparisonType = StringComparison.CurrentCulture)
		{
			if (removeString.IsNullOrEmpty()) return source;

			if (source.StartsWith(removeString, comparisonType))
			{
				source = source.Remove(0, removeString.Length);
			}

			return source;
		}

		/// <summary>
		/// Removes (at most one instance of) the <paramref name="removeString"/> string from the end of the <paramref name="source"/> string.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <param name="removeString">String to remove from the <paramref name="source"/>.</param>
		/// <param name="comparisonType">Determines how <paramref name="source"/> and <paramref name="removeString"/> strings are compared to each other.</param>
		/// <returns><paramref name="source"/> string without <paramref name="removeString"/> at the end.</returns>
		public static string RemoveSuffix(this string source, string removeString, StringComparison comparisonType = StringComparison.CurrentCulture)
		{
			if (removeString.IsNullOrEmpty()) return source;

			if (source.EndsWith(removeString, comparisonType))
			{
				source = source.Remove(source.Length - removeString.Length);
			}

			return source;
		}

		/// <summary>
		/// Returns substring from <paramref name="source"/> starting after <paramref name="openingMarker"/> and ending before <paramref name="closingMarker"/>.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <param name="openingMarker">Start marker.</param>
		/// <param name="closingMarker">End marker.</param>
		/// <returns>Substring starting after <paramref name="openingMarker"/> and ending before <paramref name="closingMarker"/>.</returns>
		public static string Substring(this string source, string openingMarker, string closingMarker)
		{
			int start = !openingMarker.IsNullOrEmpty() ? source.IndexOf(openingMarker, StringComparison.Ordinal) : 0;
			int end = !closingMarker.IsNullOrEmpty() ? source.LastIndexOf(closingMarker, StringComparison.Ordinal) : source.Length;
			if (start < 0 || end < 0 || start >= end) return null;

			start += openingMarker.Length;
			return source.Substring(start, end - start);
		}

		/// <summary>
		/// Replaces new lines in the <paramref name="source"/> string with specified <paramref name="replacement"/> string.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <param name="replacement">The replacement.</param>
		/// <returns><paramref name="source"/> string with new lines replaced with specified <paramref name="replacement"/> string.</returns>
		public static string ReplaceNewLines(this string source, string replacement)
			=> Regex.Replace(source, "(\r\n|\r|\n)", replacement);

		/// <summary>
		/// Strips new lines from the <paramref name="source"/> string.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <returns><paramref name="source"/> string without new lines.</returns>
		public static string StripNewLines(this string source)
			=> source.ReplaceNewLines(string.Empty);

		/// <summary>
		/// Truncates <paramref name="source"/> string to specified chars <paramref name="count"/>.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <param name="count">The number of chars to truncate to.</param>
		/// <param name="roundLastWord">If set to <c>true</c> rounds last word.</param>
		/// <param name="ellipses">Ellipses that will be added to the end of the string if truncate occurs.</param>
		/// <returns>Truncated <paramref name="source"/> string if string length is greater that <paramref name="count"/>, otherwise whole string.</returns>
		public static string Truncate(this string source, int count, bool roundLastWord = true, string ellipses = null)
		{
			if (string.IsNullOrEmpty(source) || source.Length <= count) return source;

			source = source.Substring(0, count);

			if (roundLastWord)
			{
				int lastSpaceIndex = source.LastIndexOf(' ');
				if (lastSpaceIndex != -1)
				{
					source = source.Substring(0, lastSpaceIndex);
				}
			}

			return $"{source}{ellipses}";
		}

		/// <summary>
		/// Splits <paramref name="source"/> string on specified <paramref name="separators"/>, with null check.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <param name="separators">The separator(s).</param>
		/// <returns>Array of <paramref name="source"/> segments delimited by specified <paramref name="separators"/>.</returns>
		public static string[] SplitWithNullCheck(this string source, params char[] separators)
			=> source.EmptyIfNull().Split(separators);

		/// <summary>
		/// Checks if <paramref name="path"/> string contains given <paramref name="value"/>.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <param name="value">The integer value.</param>
		/// <returns><c>true</c> if <paramref name="path"/> string contains given <paramref name="value"/>, otherwise <c>false</c>.</returns>
		public static bool ContainsValue(this string path, int value, char separator = ',')
			=> Array.Exists(path.SplitWithNullCheck(separator), segment => segment.Trim().EqualsInt(value));

		/// <summary>
		/// Returns the stream corresponding to the given <paramref name="source"/> string.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <param name="encoding">The encoding used to convert content of <paramref name="source"/> string.</param>
		/// <returns>Stream corresponding to the given <paramref name="source"/> string.</returns>
		public static Stream ToStream(this string source, Encoding encoding = null)
			=> new MemoryStream((encoding ?? Encoding.UTF8).GetBytes(source ?? string.Empty));
	}
}
