using System.Web.Routing;
using Umbraco.Web;
using TheRightSideOfTheStreet.Common;
using TheRightSideOfTheStreet.Core.Controllers.RenderMvc;
using TheRightSideOfTheStreet.Core.Extensions;

namespace TheRightSideOfTheStreet.Core
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			// Routes for the XML sitemap functionality
			routes.MapUmbracoRoute(
				"SitemapXML",
				AppSettings.XMLSitemapRouteUrl,
				new
				{
					controller = nameof(XMLSitemapController).RemoveControllerSuffix(),
					action = nameof(XMLSitemapController.XMLSitemap)
				},
				new DomainRootRouteHandler()
			);

			// TODO: Remove on single-language site.
			routes.MapUmbracoRoute(
				"LanguageSpecificSitemapXML",
				$"{{language}}/{AppSettings.XMLSitemapRouteUrl}",
				new
				{
					controller = nameof(XMLSitemapController).RemoveControllerSuffix(),
					action = nameof(XMLSitemapController.XMLSitemap)
				},
				new DomainRootRouteHandler(),
				new { language = new ExistingLanguagesRouteConstraint() }
			);
		}
	}
}
