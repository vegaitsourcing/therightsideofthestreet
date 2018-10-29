using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent.Modules;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class ModularContentViewModel : PageViewModel
	{
		public ModularContentViewModel(IPageContext<ModularContent> context) : base(context)
		{
			Modules = context.Page.Modules?.Select(m => context.WithNestedContent(m).AsViewModel()).ToList();
			Banner = new BannerViewModel(context.WithComposition(context.Page));
		}

		public IList<IModulesNestedContentViewModel> Modules { get; }
		public BannerViewModel Banner { get; }

	}
}
