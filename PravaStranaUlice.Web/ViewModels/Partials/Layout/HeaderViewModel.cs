using PravaStranaUlice.Common.Extensions;
using PravaStranaUlice.Models;
using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Models.Extensions;
using PravaStranaUlice.Web.Contexts;
using PravaStranaUlice.Web.Extensions;
using PravaStranaUlice.Web.ViewModels.Partials.NestedContent;
using PravaStranaUlice.Web.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Web;

namespace PravaStranaUlice.Web.ViewModels.Partials.Layout
{
	public class HeaderViewModel
	{
		public HeaderViewModel(IPageContext<IPage> context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			HomepageUrl = context.Home.Url;
			Logo = context.Home.Logo.AsViewModel();
			TopNavigationLink = context.Home.TopNavigationLink.AsViewModel();
			NavigationItems = context.Home.GetNavigationItems<IPage>().AsNavigationViewModel().AsList();
			Languages = GetLanguages(context.Languages, context.Page.AlternatePages).AsList();
			SocialLinks = context.Home.SocialLinks?.Select(sl => context.WithNestedContent(sl).AsViewModel<SocialLinkViewModel>()).AsList();
		}

		public string HomepageUrl { get; }
		public ImageViewModel Logo { get; }
		public LinkViewModel TopNavigationLink { get; }
		public IList<PrimaryNavigationItemViewModel> NavigationItems { get; }
		public IList<LanguageLinkViewModel> Languages { get; }
		public IList<SocialLinkViewModel> SocialLinks { get; }

		private IEnumerable<LanguageLinkViewModel> GetLanguages(IEnumerable<Website> websites, IEnumerable<IPage> alternatePages)
		{
			foreach(Website website in websites)
			{
				IPage page = alternatePages.FirstOrDefault(p => p.Site().Id == website.Id);

				yield return page.AsViewModel(website.Name) ?? website.AsViewModel(website.Name);
			}
		}
	}
}