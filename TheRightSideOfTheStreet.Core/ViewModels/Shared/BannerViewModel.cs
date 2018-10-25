using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Common.Extensions;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.Extensions;

namespace TheRightSideOfTheStreet.Core.ViewModels.Shared
{
	public class BannerViewModel
	{
		public BannerViewModel(ICompositionContext<IBanner> context)
		{
			BannerTitle = context.Composition.BannerTitle;
			BannerImage = context.Composition.GetBannerImage().AsViewModel();
			BannerLink = context.Composition.BannerLink.AsViewModel();
			SocialLinks = context.Home.SocialLinks?.Select(sl => context.WithNestedContent(sl).AsViewModel<SocialLinkViewModel>()).AsList();
		}

		public string BannerTitle { get; }
		public ImageViewModel BannerImage { get; }
		public LinkViewModel BannerLink { get; }
		public IList<SocialLinkViewModel> SocialLinks { get; }
	}
}
