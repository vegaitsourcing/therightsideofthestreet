using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Web.Contexts;
using PravaStranaUlice.Web.ViewModels.Partials.Layout;
using Umbraco.Web;

namespace PravaStranaUlice.Web.ViewModels
{
    public class PageViewModel
    {
        public PageViewModel(IPageContext<IPage> context)
        {
            Language = context.Page.GetCulture().TwoLetterISOLanguageName;
            MetaTags = new MetaTagsViewModel(context);
			Header = new HeaderViewModel(context);
            GoogleAnalytics = new GoogleAnalyticsViewModel(context);
        }

        public string Language { get; }
        public MetaTagsViewModel MetaTags { get; }
		public HeaderViewModel Header { get; }
        public GoogleAnalyticsViewModel GoogleAnalytics { get; }
    }
}