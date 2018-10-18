using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TheRightSideOfTheStreet.Common.Extensions
{
	/// <summary>
	/// <see cref="string"/> extension methods for HTML text manipulations.
	/// </summary>
	public static class StringHtmlExtensions
	{
		/// <summary>
		/// Strips HTML tags from the <paramref name="source"/> string.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <returns><paramref name="source"/> string without HTML tags.</returns>
		public static string StripHtml(this string source)
			=> Regex.Replace(source, @"<(.|\n)*?>", string.Empty);

		/// <summary>
		/// Converts the <paramref name="source"/> string to HTML.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <returns>HTML representation of <paramref name="source"/> string.</returns>
		public static string ToHtml(this string source)
		{
			if (source.IsNullOrEmpty()) return source;

			StringBuilder builder = new StringBuilder();
			bool previousWasASpace = false;

			foreach (char c in source)
			{
				if (c == ' ')
				{
					if (previousWasASpace)
					{
						builder.Append("&nbsp;");
						previousWasASpace = false;
						continue;
					}

					previousWasASpace = true;
				}
				else
				{
					previousWasASpace = false;
				}

				switch (c)
				{
					case '<':
						builder.Append("&lt;");
						break;

					case '>':
						builder.Append("&gt;");
						break;

					case '&':
						builder.Append("&amp;");
						break;

					case '"':
						builder.Append("&quot;");
						break;

					case '\n':
						builder.Append("<br />");
						break;

					case '\t':  // We need Tab support here, because we print StackTraces as HTML.
						builder.Append("&nbsp; &nbsp; &nbsp;");
						break;

					default:
						if (c < 128)
						{
							builder.Append(c);
						}
						else
						{
							builder.Append("&#").Append((int)c).Append(";");
						}
						break;
				}
			}

			return builder.ToString();
		}

		/// <summary>
		/// Replaces new lines in the <paramref name="source"/> string with HTML line breaks (<br />).
		/// </summary>
		/// <remarks>This method should be used only on already HTML encoded string.</remarks>
		/// <param name="source">The source string.</param>
		/// <returns><paramref name="source"/> string with new lines replaced with HTML line breaks (<br />).</returns>
		public static string ReplaceNewLinesWithHtmlLineBreaks(this string source)
			=> source.ReplaceNewLines("<br />");

		/// <summary>
		/// Replaces new lines in the <paramref name="source"/> string with HTML paragraphs (<p></p>).
		/// </summary>
		/// <remarks>This method should be used only on already HTML encoded string.</remarks>
		/// <param name="source">The source string.</param>
		/// <returns><paramref name="source"/> string with new lines replaced with HTML paragraphs (<p></p>).</returns>
		public static string ReplaceNewLinesWithHtmlParagraphs(this string source)
			=> $"<p>{source.ReplaceNewLines("</p><p>")}</p>";

		/// <summary>
		/// Replaces HTML line breaks (<br />) in the <paramref name="source"/> string with HTML paragraphs (<p></p>).
		/// </summary>
		/// <remarks>This method should be used only on already HTML encoded string.</remarks>
		/// <param name="source">The source string.</param>
		/// <returns><paramref name="source"/> string with HTML line breaks (<br />) replaced with HTML paragraphs (<p></p>).</returns>
		public static string ReplaceHtmlLineBreaksWithHtmlParagraphs(this string source)
			=> $"<p>{source.Replace("<br />", "</p><p>")}</p>";

		/// <summary>
		/// Removes enclosing HTML paragraph tags from <paramref name="source"/> string.
		/// </summary>
		/// <remarks>
		/// It is possible that the result won't be properly formed HTML if enclosing paragraph tags belong to separate, independent paragraphs.
		/// In such case <see cref="SplitHtmlParagraphs"/> may be used.
		/// </remarks>
		/// <param name="source">The source string.</param>
		/// <returns><paramref name="source"/> string without enclosing HTML paragraph tags.</returns>
		public static string StripHtmlParagraphs(this string source)
		{
			while (source.StartsWith("<p>") && source.EndsWith("</p>"))
			{
				source = source.RemovePrefix("<p>").RemoveSuffix("</p>");
			}

			return source;
		}

		/// <summary>
		/// Splits <paramref name="source"/> string into HTML paragraphs.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <returns>Array of HTML paragraphs from <paramref name="source"/> string.</returns>
		public static string[] SplitHtmlParagraphs(this string source)
			=> source.Split(new[] { "<p>", "</p>" }, StringSplitOptions.RemoveEmptyEntries);

		/// <summary>
		/// Highlights segments of <paramref name="source"/> string placed between <paramref name="highlightMarker"/> marker.
		/// Text between <paramref name="highlightMarker"/> markers is enclosed with <paramref name="openingHighlightTag"/> and <paramref name="closingHighlightTag"/> tags.
		/// </summary>
		/// <remarks>This method should be used only on already HTML encoded string.</remarks>
		/// <param name="source">The source string.</param>
		/// <param name="highlightMarker">Marker that is used to mark start and end of string segments that should be highlighted.</param>
		/// <param name="openingHighlightTag">Opening highlight tag.</param>
		/// <param name="closingHighlightTag">Closing highlight tag.</param>
		/// <returns>Highlighted <paramref name="source"/> string.</returns>
		public static string HighlightText(this string source, string highlightMarker = "**", string openingHighlightTag = "<strong>", string closingHighlightTag = "</strong>")
		{
			if (highlightMarker.IsNullOrEmpty()) return source;

			int firstIndex = source.IndexOf(highlightMarker, StringComparison.Ordinal);
			if (firstIndex < 0) return source;

			string afterMarker = source.Substring(firstIndex + highlightMarker.Length);
			int secondIndex = afterMarker.IndexOf(highlightMarker, StringComparison.Ordinal);
			if (secondIndex < 0) return source;

			StringBuilder builder = new StringBuilder();
			builder.Append(source.Substring(0, firstIndex));
			builder.Append(openingHighlightTag);
			builder.Append(afterMarker.Substring(0, secondIndex));
			builder.Append(closingHighlightTag);
			builder.Append(afterMarker.Substring(secondIndex + highlightMarker.Length));

			return HighlightText(builder.ToString(), highlightMarker, openingHighlightTag, closingHighlightTag);
		}

		/// <summary>
		/// Extracts source value from given <paramref name="iframe"/>.
		/// </summary>
		/// <param name="iframe">Iframe tag.</param>
		/// <returns>Source value extracted from given <paramref name="iframe"/>.</returns>
		public static string GetIframeSource(string iframe)
		{
			const string srcAttribute = "src=";
			string src = iframe.Replace("\"", "");

			int indexOfSrc = src.IndexOf(srcAttribute, StringComparison.Ordinal);
			if (indexOfSrc <= 0)
			{
				return string.Empty;
			}

			return src.Substring(indexOfSrc + srcAttribute.Length, src.Substring(indexOfSrc + srcAttribute.Length).IndexOf(" ", StringComparison.Ordinal));
		}
	}
}
