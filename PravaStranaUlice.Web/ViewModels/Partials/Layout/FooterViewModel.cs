using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Web.Contexts;
using PravaStranaUlice.Web.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PravaStranaUlice.Web.Extensions;
using PravaStranaUlice.Models.Extensions;
using PravaStranaUlice.Common.Extensions;
using PravaStranaUlice.Web.ViewModels.Partials.NestedContent;

namespace PravaStranaUlice.Web.ViewModels.Partials.Layout
{
    public class FooterViewModel
    {
        public FooterViewModel(IPageContext<IPage> context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            
            InfoImage = context.Home.InfoImage.AsViewModel();
			InfoTitle = context.Home.InfoTitle;
			InfoText = context.Home.InfoText;
			HygieneLinksGroup = context.Home.GetNavigationItems<IPage>().AsNavigationViewModel().ToList();
			ContactEmail = context.Home.ContactEmail;
            SocialLinks = context.Home.SocialLinks?.Select(sl => context.WithNestedContent(sl).AsViewModel<SocialLinkViewModel>()).AsList();
        }

        public ImageViewModel InfoImage { get; }
		public string InfoTitle { get; }
		public string InfoText { get; }
		public List<PrimaryNavigationItemViewModel> HygieneLinksGroup { get; } 
		public string ContactEmail { get; }
        public IList<SocialLinkViewModel> SocialLinks { get; }
	}
}