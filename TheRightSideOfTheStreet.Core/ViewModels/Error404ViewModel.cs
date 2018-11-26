using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class Error404ViewModel : PageViewModel
	{
		public Error404ViewModel(IPageContext<Error404> context) : base(context)
		{
			Banner = new BannerViewModel(context.WithComposition(context.Page));
		}

		public BannerViewModel Banner { get; }
	}
}