using System.Web;
using Umbraco.Core;
using Umbraco.Core.Configuration;
using Umbraco.Web;
using Umbraco.Web.Routing;
using Umbraco.Web.Security;

namespace TheRightSideOfTheStreet.Core.Extensions
{
	/// <summary>
	/// <see cref="HttpContextBase"/> extension methods.
	/// </summary>
	public static class HttpContextExtensions
	{
		/// <summary>
		/// Converts <paramref name="context"/> to <see cref="HttpContextBase"/> type.
		/// </summary>
		/// <param name="context">HTTP context.</param>
		/// <returns><see cref="HttpContextBase"/> instance created from <paramref name="context"/>.</returns>
		public static HttpContextBase ToBase(this HttpContext context)
			=> new HttpContextWrapper(context);

		/// <summary>
		/// Returns current <see cref="UmbracoContext"/> or creates new one based on given <paramref name="context"/> if necessary.
		/// </summary>
		/// <param name="context">HTTP context.</param>
		/// <returns><see cref="UmbracoContext"/>.</returns>
		public static UmbracoContext EnsureUmbracoContext(this HttpContextBase context)
		{
			if (UmbracoContext.Current != null)
			{
				return UmbracoContext.Current;
			}

			return UmbracoContext.EnsureContext(
						context,
						ApplicationContext.Current,
						new WebSecurity(context, ApplicationContext.Current),
						UmbracoConfig.For.UmbracoSettings(),
						UrlProviderResolver.Current.Providers,
						true);
		}
	}
}
