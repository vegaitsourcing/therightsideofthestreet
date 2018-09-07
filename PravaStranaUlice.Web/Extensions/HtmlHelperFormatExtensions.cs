using System.Web;
using System.Web.Mvc;
using PravaStranaUlice.Common.Extensions;

namespace PravaStranaUlice.Web.Extensions
{
	/// <summary>
	/// <see cref="HtmlHelper"/> extension methods for string formatting.
	/// </summary>
	public static class HtmlHelperFormatExtensions
	{
		/// <summary>
		/// Replaces new lines in the <paramref name="input"/> string with HTML line breaks (<br />).
		/// </summary>
		/// <param name="helper">HTML helper.</param>
		/// <param name="input">The input string.</param>
		/// <returns>HTML encoded string with new lines replaced with HTML line breaks (<br />).</returns>
		public static IHtmlString NewLinesToHtmlLineBreaks(this HtmlHelper helper, string input)
			=> new MvcHtmlString(helper.Encode(input).ReplaceNewLinesWithHtmlLineBreaks());

		/// <summary>
		/// Replaces new lines in the <paramref name="input"/> string with HTML paragraphs (<p></p>).
		/// </summary>
		/// <param name="helper">HTML helper.</param>
		/// <param name="input">The input string.</param>
		/// <returns>HTML encoded string with new lines replaced with HTML paragraphs (<p></p>).</returns>
		public static IHtmlString NewLinesToHtmlParagraphs(this HtmlHelper helper, string input)
			=> new MvcHtmlString(helper.Encode(input).ReplaceNewLinesWithHtmlParagraphs());

		/// <summary>
		/// Replaces HTML line breaks (<br />) in the <paramref name="input"/> string with HTML paragraphs (<p></p>).
		/// </summary>
		/// <param name="helper">HTML helper.</param>
		/// <param name="input">The input string.</param>
		/// <returns>HTML encoded string with HTML line breaks (<br />) replaced with HTML paragraphs (<p></p>).</returns>
		public static IHtmlString HtmlLineBreaksToHtmlParagraphs(this HtmlHelper helper, string input)
			=> new MvcHtmlString(helper.Encode(input).ReplaceHtmlLineBreaksWithHtmlParagraphs());

		/// <summary>
		/// Highlights important segments of the <paramref name="input"/> string.
		/// </summary>
		/// <param name="helper">HTML helper.</param>
		/// <param name="input">The input string.</param>
		/// <param name="highlightMarker">Marker that is used to mark start and end of string segments that should be highlighted.</param>
		/// <param name="openingHighlightTag">Opening highlight tag.</param>
		/// <param name="closingHighlightTag">Closing highlight tag.</param>
		/// <returns>HTML encoded string where important parts are highlighted.</returns>
		public static IHtmlString Highlight(this HtmlHelper helper, string input,
											string highlightMarker = "**", string openingHighlightTag = "<strong>", string closingHighlightTag = "</strong>")
			=> new MvcHtmlString(helper.Encode(input).HighlightText(highlightMarker, openingHighlightTag, closingHighlightTag));
	}
}
