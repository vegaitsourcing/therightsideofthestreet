using Umbraco.Core.Models;

namespace PravaStranaUlice.Models.DocumentTypes
{
	/// <summary>
	/// Marks document type model classes that represent site nodes.
	/// </summary>
	/// <remarks>
	/// Navigation node doesn't necessarily have a template but nonetheless can be featured in site navigation or sitemap.
	/// Also, pure navigation node can be used as a Hub, to group related nodes/pages.
	/// </remarks>
	public interface INavigationNode : IPublishedContent
	{
		string Title { get; }

		bool HideFromSiteNavigation { get; }
		bool HideFromSitemap { get; }
	}
}
