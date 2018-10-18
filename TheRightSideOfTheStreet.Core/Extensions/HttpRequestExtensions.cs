using System.Linq;
using System.Web;
using TheRightSideOfTheStreet.Common.Extensions;

namespace TheRightSideOfTheStreet.Core.Extensions
{
	/// <summary>
	/// <see cref="HttpRequestBase"/> extension methods.
	/// </summary>
	public static class HttpRequestExtensions
	{
		/// <summary>
		/// Converts <paramref name="request"/> to <see cref="HttpRequestBase"/> type.
		/// </summary>
		/// <param name="request">HTTP request.</param>
		/// <returns><see cref="HttpRequestBase"/> instance created from <paramref name="request"/>.</returns>
		public static HttpRequestBase ToBase(this HttpRequest request)
			=> new HttpRequestWrapper(request);

		/// <summary>
		/// Checks if specified <paramref name="request"/> originates from search crawler.
		/// </summary>
		/// <param name="request">HTTP request.</param>
		/// <returns><c>true</c> if specified <paramref name="request"/> originates from search crawler, otherwise <c>false</c>.</returns>
		public static bool IsSearchCrawler(this HttpRequestBase request)
		{
			string userAgent = request.UserAgent?.ToLower();
			return !userAgent.IsNullOrWhiteSpace() ? crawlers.Any(c => userAgent.Contains(c)) : false;
		}

		private static string[] crawlers = new[]
		{
			"googlebot","bingbot","yandexbot","ahrefsbot","msnbot","linkedinbot","exabot","compspybot",
			"yesupbot","paperlibot","tweetmemebot","semrushbot","gigabot","voilabot","adsbot-google",
			"botlink","alkalinebot","araybot","undrip bot","borg-bot","boxseabot","yodaobot","admedia bot",
			"ezooms.bot","confuzzledbot","coolbot","internet cruiser robot","yolinkbot","diibot","musobot",
			"dragonbot","elfinbot","wikiobot","twitterbot","contextad bot","hambot","iajabot","news bot",
			"irobot","socialradarbot","ko_yappo_robot","skimbot","psbot","rixbot","seznambot","careerbot",
			"simbot","solbot","mail.ru_bot","spiderbot","blekkobot","bitlybot","techbot","void-bot",
			"vwbot_k","diffbot","friendfeedbot","archive.org_bot","woriobot","crystalsemanticsbot","wepbot",
			"spbot","tweetedtimes bot","mj12bot","who.is bot","psbot","robot","jbot","bbot","bot",
			"baiduspider", "yandeximages", "vagabondo", "ia_archiver", "acoonbot", "yahoo! slurp"
		};
	}
}
