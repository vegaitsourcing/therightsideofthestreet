using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRightSideOfTheStreet.Models;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Routing;


namespace TheRightSideOfTheStreet.Core.App_Start
{
	public class My404ContentFinder : IContentFinder
	{
		public bool TryFindContent(PublishedContentRequest contentRequest)
		{
			string requestUrl = contentRequest.DomainUri.Host;

			var services = ApplicationContext.Current.Services;
			var domainService = services.DomainService;
			var site = domainService.GetByName(requestUrl);
			var helper = new UmbracoHelper(UmbracoContext.Current);
			IPublishedContent siteRoot = helper.TypedContent(site.RootContentId);

			var error404 = siteRoot.DescendantOrSelf<Error404>();

			if (error404 != null)
			{
				contentRequest.PublishedContent = error404;
			}

			return contentRequest.PublishedContent != null;
		}
	}
}
