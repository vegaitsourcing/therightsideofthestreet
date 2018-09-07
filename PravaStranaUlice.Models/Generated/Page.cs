using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;
using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Models.Extensions;

namespace PravaStranaUlice.Models
{
	/// <summary>
	/// Page document type model.
	/// </summary>
	/// <seealso cref="PravaStranaUlice.Models.DocumentTypes.IPage"/>
	public partial class Page : NavigationNode, IPage
	{
		public Page(IPublishedContent content) : base(content)
		{ }

		/// <remarks>
		/// Page can be featured in site navigation only if it has associated template.
		/// </remarks>
		public override bool HideFromSiteNavigation => base.HideFromSiteNavigation || !this.HasTemplate();

		/// <remarks>
		/// Page can be featured in sitemap only if it has associated template.
		/// </remarks>
		public override bool HideFromSitemap => base.HideFromSitemap || !this.HasTemplate();

		///<summary>
		/// Hide from Search Engines: If selected, page will be hidden from search engines (such as Google, Bing, etc.) and consequently from the sitemap used by search engines.
		///</summary>
		/// <remarks>
		/// Page can be visible to search engines (and featured in sitemap XML) only if it has associated template.
		/// </remarks>
		[ImplementPropertyType("hideFromSearchEngines")]
		public bool HideFromSearchEngines => this.GetPropertyValue<bool>() || !this.HasTemplate();

		///<summary>
		/// Search Engine Sitemap Change Frequency: The expected change frequency of the page, associated with the sitemap used by search engines.
		///</summary>
		[ImplementPropertyType("sitemapChangeFrequency")]
		public string SitemapChangeFrequency => this.GetPropertyValue<string>();

		///<summary>
		/// Search Engine Sitemap Priority: Priority of the page, associated with the sitemap used by search engines.
		///</summary>
		[ImplementPropertyType("sitemapPriority")]
		public string SitemapPriority => this.GetPropertyValue<string>();
	}
}
