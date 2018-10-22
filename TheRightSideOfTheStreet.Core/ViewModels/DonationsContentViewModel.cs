using System.Linq;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class DonationsContentViewModel : PageViewModel
	{
		public DonationsContentViewModel(IPageContext<DonationsContent> context) : base(context)
		{
			IntroText = context.Page.IntroText;
			InnerTitle = context.Page.InnerTitle;
			Image = context.Page.Image.AsViewModel();
			CollectedFundsText = context.Page.CollectedFundsText;
			FundsGoalText = context.Page.FundsGoalText;
			DonatorsTitle = context.Page.DonatorsTitle;
			HasDonators = context.Page.Donators?.Any() ?? false;
		}

		public string IntroText { get; }
		public string InnerTitle { get; }
		public ImageViewModel Image { get; }
		public string CollectedFundsText { get; }
		public string FundsGoalText { get; }
		public string DonatorsTitle { get; }
		public bool HasDonators { get; }
	}
}