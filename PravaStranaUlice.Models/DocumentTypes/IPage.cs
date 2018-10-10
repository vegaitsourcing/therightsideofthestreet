using Umbraco.Core.Models;

namespace PravaStranaUlice.Models.DocumentTypes
{
	/// <summary>
	/// Marks document type model classes that represent site pages.
	/// </summary>
	public interface IPage : IPublishedContent
	{
        string Title { get; }
		string SeoTitle { get; }

        bool HideFromSiteNavigation { get; }
        bool HideFromSearchEngines { get; }
		string SitemapChangeFrequency { get; }
		string SitemapPriority { get; }
	}
}
