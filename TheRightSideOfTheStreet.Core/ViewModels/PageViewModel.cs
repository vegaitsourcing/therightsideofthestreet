using System;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.Layout;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models.DocumentTypes;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.ViewModels
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
			Partners = new PartnersSectionViewModel(context);
			GoogleAnalytics = new GoogleAnalyticsViewModel(context);
			OpenGraph = new OpenGraphViewModel(context);
			Cookies = new CookiesViewModel(context);
			PageKey = context.Page.GetKey();
			Url = context.Page.Url;		
		}

		public string Title { get; }
		public string Language { get; }
		public MetaTagsViewModel MetaTags { get; }
		public OpenGraphViewModel OpenGraph { get; }
		public HeaderViewModel Header { get; }
		public FooterViewModel Footer { get; }
		public PartnersSectionViewModel Partners { get; }
		public GoogleAnalyticsViewModel GoogleAnalytics { get; }
		public CookiesViewModel Cookies { get; }
		public Guid PageKey { get; }
		public string Url { get; }		
	}
}