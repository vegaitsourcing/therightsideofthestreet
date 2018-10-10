using PravaStranaUlice.Models;
using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Models.Extensions;
using System;
using System.Linq;
using Umbraco.Web;

namespace PravaStranaUlice.Web.Contexts
{
    public class SiteContext : ISiteContext
    {
        public SiteContext(UmbracoHelper umbracoHelper)
        {
            UmbracoHelper = umbracoHelper ?? throw new ArgumentNullException(nameof(umbracoHelper));

            LazyCurrentPage = new Lazy<IPage>(() => UmbracoHelper.UmbracoContext?.PublishedContentRequest?.PublishedContent.OfType<IPage>());
            LazyHome = new Lazy<Website>(() => UmbracoHelper.GetHome<Website>());
            LazySettings = new Lazy<Settings>(() => UmbracoHelper.GetSettings());
            LazyRepository = new Lazy<Repository>(() => UmbracoHelper.GetRepository());
        }

        public IPage CurrentPage => LazyCurrentPage.Value;
        public Website Home => LazyHome.Value;
        public Settings Settings => LazySettings.Value;
        public Repository Repository => LazyRepository.Value;

        protected UmbracoHelper UmbracoHelper { get; }

        private Lazy<IPage> LazyCurrentPage { get; }
        private Lazy<Website> LazyHome { get; }
        private Lazy<Settings> LazySettings { get; }
        private Lazy<Repository> LazyRepository { get; }
    }
}