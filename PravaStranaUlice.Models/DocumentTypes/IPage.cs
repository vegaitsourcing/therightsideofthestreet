namespace PravaStranaUlice.Models.DocumentTypes
{
	/// <summary>
	/// Marks document type model classes that represent site pages.
	/// </summary>
	public interface IPage : INavigationNode
	{
		string SeoTitle { get; }

		bool HideFromSearchEngines { get; }
		string SitemapChangeFrequency { get; }
		string SitemapPriority { get; }
	}
}
