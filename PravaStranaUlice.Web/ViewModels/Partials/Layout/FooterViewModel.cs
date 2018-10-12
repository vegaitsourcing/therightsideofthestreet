using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Web.Contexts;
using PravaStranaUlice.Web.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PravaStranaUlice.Web.Extensions;

namespace PravaStranaUlice.Web.ViewModels.Partials.Layout
{
    public class FooterViewModel
    {
        public FooterViewModel(IPageContext<IPage> context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            
            InfoImage = context.Home.InfoImage.AsViewModel();
            TopNavigationLink = context.Home.TopNavigationLink.AsViewModel();
            NavigationItems = context.Home.GetNavigationItems<IPage>().AsNavigationViewModel().AsList();
            Languages = GetLanguages(context.Languages, context.Page.AlternatePages).AsList();
            SocialLinks = context.Home.SocialLinks?.Select(sl => context.WithNestedContent(sl).AsViewModel<SocialLinkViewModel>()).AsList();
        }

        public string HomepageUrl { get; }
        public ImageViewModel InfoImage { get; }
        public LinkViewModel TopNavigationLink { get; }
        public IList<PrimaryNavigationItemViewModel> NavigationItems { get; }
        public IList<LanguageLinkViewModel> Languages { get; }
        public IList<SocialLinkViewModel> SocialLinks { get; }
    }
}