using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Umbraco.Core;

namespace TheRightSideOfTheStreet.Core
{
	public class ApplicationEventsHandler : ApplicationEventHandler
	{
		protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
			base.ApplicationStarting(umbracoApplication, applicationContext);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			ViewEngines.Engines.Add(new PartialViewEngine());
		}

		protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
			base.ApplicationStarted(umbracoApplication, applicationContext);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
		}
	}
}
