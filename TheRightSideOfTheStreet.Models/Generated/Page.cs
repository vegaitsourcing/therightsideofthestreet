using TheRightSideOfTheStreet.Common;
using TheRightSideOfTheStreet.Models.DocumentTypes;
using TheRightSideOfTheStreet.Models.Extensions;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Models
{
    /// <summary>
    /// Page document type model.
    /// </summary>
    /// <seealso cref="TheRightSideOfTheStreet.Models.DocumentTypes.IPage"/>
    public partial class Page : PublishedContentModel, IPage
	{
		public Page(IPublishedContent content) : base(content)
		{ }

		[ImplementPropertyType("title")]
		public string Title => this.GetPropertyWithDefaultValue(Content.Name);

		[ImplementPropertyType("alternatePages")]
		public IEnumerable<IPage> AlternatePages => this.GetPropertyValue<IEnumerable<IPublishedContent>>().Where(pc => pc != null).OfType<IPage>();

        ///<summary>
        /// Hide from Site Navigation: If selected, node will be hidden from site navigation.
        ///</summary>
        [ImplementPropertyType("umbracoNaviHide")]
        public bool HideFromSiteNavigation => !this.IsVisible() || !this.HasTemplate();

		///<summary>
		/// Hide from Search Engines: If selected, page will be hidden from search engines (such as Google, Bing, etc.) and consequently from the sitemap used by search engines.
		///</summary>
		/// <remarks>
		/// Page can be visible to search engines (and featured in sitemap XML) only if it has associated template.
		/// </remarks>
		[ImplementPropertyType("hideFromSearchEngines")]
		public bool HideFromSearchEngines => this.GetPropertyValue<bool>() || !this.HasTemplate() || AppSettings.HideAllPagesFromSearchEngines;

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
