using System;
using System.Web;

namespace TheRightSideOfTheStreet.Models.Extensions
{
	/// <summary>
	/// <see cref="HttpRequestBase"/> extension methods.
	/// </summary>
	public static class HttpRequestExtensions
	{
		/// <summary>
		/// Creates absolute URL for given <paramref name="relativeUrl"/> based on provided <paramref name="request"/>.
		/// </summary>
		/// <param name="request">Request to create absolute URL for.</param>
		/// <param name="relativeUrl">Relative URL to translate to absolute one.</param>
		/// <returns>Absolute URL for given <paramref name="relativeUrl"/> and provided <paramref name="request"/></returns>
		public static string GetAbsoluteUrl(this HttpRequestBase request, string relativeUrl)
			=> new Uri(new Uri(request.Url.GetLeftPart(UriPartial.Authority)), relativeUrl).ToString();
	}
}
