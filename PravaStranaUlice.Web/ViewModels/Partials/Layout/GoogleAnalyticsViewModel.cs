using PravaStranaUlice.Web.Contexts;
using System;
using System.Web;
using System.Web.Mvc;

namespace PravaStranaUlice.Web.ViewModels.Partials.Layout
{
    public class GoogleAnalyticsViewModel
    {
        public GoogleAnalyticsViewModel(ISiteContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            GoogleAnalytics = new MvcHtmlString(context.Settings.GoogleAnalytics);
        }

        public IHtmlString GoogleAnalytics { get; }
    }
}