using TheRightSideOfTheStreet.Common.Extensions;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.DocumentTypes;
using TheRightSideOfTheStreet.Models.Extensions;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.Layout
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
			Languages = GetLanguages(context.Languages, context.Page.AlternatePages.ToList()).AsList();
			SocialLinks = context.Home.SocialLinks?.Select(sl => context.WithNestedContent(sl).AsViewModel<SocialLinkViewModel>()).AsList();
		}

		public string HomepageUrl { get; }
		public ImageViewModel Logo { get; }
		public LinkViewModel TopNavigationLink { get; }
		public IList<PrimaryNavigationItemViewModel> NavigationItems { get; }
		public IList<LanguageLinkViewModel> Languages { get; }
		public IList<SocialLinkViewModel> SocialLinks { get; }

		private static IEnumerable<LanguageLinkViewModel> GetLanguages(IEnumerable<Website> websites, IList<IPage> alternatePages)
		{
			foreach (Website website in websites)
			{
				IPage page = alternatePages.FirstOrDefault(p => p.Site().Id == website.Id);

				yield return page.AsViewModel(website.Name) ?? website.AsViewModel(website.Name);
			}
		}
	}
}