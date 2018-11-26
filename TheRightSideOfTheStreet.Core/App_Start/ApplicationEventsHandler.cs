using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TheRightSideOfTheStreet.Core.App_Start;
using Umbraco.Core;
using Umbraco.Web.Routing;

namespace TheRightSideOfTheStreet.Core
{
	public class ApplicationEventsHandler : ApplicationEventHandler
	{
		protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
			base.ApplicationStarting(umbracoApplication, applicationContext);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			ViewEngines.Engines.Add(new PartialViewEngine());
			ContentLastChanceFinderResolver.Current.SetFinder(new My404ContentFinder());
			ContentFinderResolver.Current.InsertType<AthleteMemberContentFinder>();			
		}

		protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
			base.ApplicationStarted(umbracoApplication, applicationContext);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);			
		}
	}
}
