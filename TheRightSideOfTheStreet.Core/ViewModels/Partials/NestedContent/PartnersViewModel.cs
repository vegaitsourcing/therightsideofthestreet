using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.DocumentTypes;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent
{
	public class PartnersViewModel : INestedContentViewModel
	{
		public PartnersViewModel(INestedContentContext<Partners> context)
		{
			PartnersLogo = context.NestedContent.PartnersLogo.AsViewModel();
			PartnersLink = context.NestedContent.PartnersLink.AsViewModel();
			
		}

		public ImageViewModel PartnersLogo { get; }
		public LinkViewModel PartnersLink { get; }
	}
}
