using System;
using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.DocumentTypes;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.Contexts
{
	public class SiteContext : ISiteContext
    {
        public SiteContext(UmbracoHelper umbracoHelper)
        {
            UmbracoHelper = umbracoHelper ?? throw new ArgumentNullException(nameof(umbracoHelper));

            LazyCurrentPage = new Lazy<IPage>(() => UmbracoHelper.UmbracoContext?.PublishedContentRequest?.PublishedContent.OfType<IPage>());
            LazyHome = new Lazy<Website>(() => UmbracoHelper.GetHome<Website>());
            LazySettings = new Lazy<Settings>(() => UmbracoHelper.GetSettings(LazyHome.Value.Id));
            LazyRepository = new Lazy<Repository>(() => UmbracoHelper.GetRepository());
			LazyLanguages = new Lazy<IEnumerable<Website>>(() => UmbracoHelper.GetLanguages());
        }

        public IPage CurrentPage => LazyCurrentPage.Value;
        public Website Home => LazyHome.Value;
        public Settings Settings => LazySettings.Value;
        public Repository Repository => LazyRepository.Value;
        public IEnumerable<Website> Languages => LazyLanguages.Value;
		
		protected UmbracoHelper UmbracoHelper { get; }

        private Lazy<IPage> LazyCurrentPage { get; }
        private Lazy<Website> LazyHome { get; }
        private Lazy<Settings> LazySettings { get; }
        private Lazy<Repository> LazyRepository { get; }
		private Lazy<IEnumerable<Website>> LazyLanguages { get; }
    }
}