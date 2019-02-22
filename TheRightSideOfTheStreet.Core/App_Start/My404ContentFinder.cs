using TheRightSideOfTheStreet.Models;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Routing;


namespace TheRightSideOfTheStreet.Core.App_Start
{
	public class My404ContentFinder : IContentFinder
	{
		public bool TryFindContent(PublishedContentRequest contentRequest)
		{
			int? rootNodeId = contentRequest.UmbracoDomain.RootContentId;
		
			var helper = new UmbracoHelper(UmbracoContext.Current);
			IPublishedContent siteRoot = helper.TypedContent(rootNodeId);

			var error404 = siteRoot.DescendantOrSelf<Error404>();

			if (error404 != null)
			{
				contentRequest.PublishedContent = error404;
			}

			return contentRequest.PublishedContent != null;
		}
	}
}
