﻿using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Web.Contexts;
using PravaStranaUlice.Web.ViewModels.Partials.Layout;
using Umbraco.Web;

namespace PravaStranaUlice.Web.ViewModels
{
    public class PageViewModel
    {
        public PageViewModel(IPageContext<IPage> context)
        {
            Title = context.Page.Title;
            Language = context.Page.GetCulture().TwoLetterISOLanguageName;
            MetaTags = new MetaTagsViewModel(context);
			Header = new HeaderViewModel(context);
			Footer = new FooterViewModel(context);
            GoogleAnalytics = new GoogleAnalyticsViewModel(context);
           
           
        }
        public string Title { get; set; }
        public string Language { get; }
        public MetaTagsViewModel MetaTags { get; }
		public HeaderViewModel Header { get; }
		public FooterViewModel Footer { get; }
        public GoogleAnalyticsViewModel GoogleAnalytics { get; }
        
    }
}