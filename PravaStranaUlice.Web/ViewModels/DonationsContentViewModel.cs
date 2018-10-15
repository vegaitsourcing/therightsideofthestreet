using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Web.Contexts;
using PravaStranaUlice.Web.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PravaStranaUlice.Web.ViewModels
{
	public class DonationsContentViewModel : PageViewModel
	{
		public DonationsContentViewModel(IPageContext<IPage> context) : base(context)
		{
			Title = context.CurrentPage.Title;
		}

		public string Title { get; }
		public string IntroText { get; }
		public string InnerTitle { get; }
		public ImageViewModel Image { get; }
		public string CollectedFundsText { get; }
		public string FundsGoalText { get; }
		public string DonatorsTitle { get; }
		//public IList<DonatorsViewModel> Donators { get; }


	}
}