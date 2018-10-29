using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent.Modules;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models.DocumentTypes;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class WebsiteViewModel : PageViewModel
    {
        public WebsiteViewModel(IPageContext<IPage> context) : base(context)
        {
			Modules = context.Home.Modules?.Select(m => context.WithNestedContent(m).AsViewModel()).ToList();
			Banner = new BannerViewModel(context.WithComposition(context.Home));
		}

		public IList<IModulesNestedContentViewModel> Modules { get; }
		public BannerViewModel Banner { get; }
	}
}