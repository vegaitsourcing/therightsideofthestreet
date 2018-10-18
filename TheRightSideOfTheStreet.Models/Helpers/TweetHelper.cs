using System.Text.RegularExpressions;

namespace TheRightSideOfTheStreet.Models.Helpers
{
	/// <summary>
	/// Tweet helper class.
	/// </summary>
	public static class TweetHelper
	{
		/// <summary>
		/// Adds links to provided <paramref name="tweet"/> message.
		/// </summary>
		/// <param name="tweet">Tweet message.</param>
		/// <returns>Tweet message with added links.</returns>
		public static string AddLinksToTweet(string tweet)
		{
			string replacePattern1 = @"(http:\/\/[^ ]+)";
			tweet = Regex.Replace(tweet, replacePattern1, "<a href=\"$1\" target=\"_blank\">$1</a>", RegexOptions.Compiled);

			string replacePattern2 = @"@([a-z0-9_]+)";
			tweet = Regex.Replace(tweet, replacePattern2, "<a href=\"http://twitter.com/@$1\" target=\"_blank\">@$1</a>", RegexOptions.Compiled);

			string replacePattern3 = @"#([a-zA-Z0-9_]*)";
			tweet = Regex.Replace(tweet, replacePattern3, "<a href=\"http://search.twitter.com/search?q=%23$1\" target=\"_blank\">#$1</a>", RegexOptions.Compiled);

			return tweet;
		}
	}
}
