using PravaStranaUlice.Common.Extensions;
using PravaStranaUlice.Models;
using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Models.Extensions;
using PravaStranaUlice.Web.Contexts;
using PravaStranaUlice.Web.Extensions;
using PravaStranaUlice.Web.ViewModels.Partials.NestedContent;
using PravaStranaUlice.Web.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Web;

namespace PravaStranaUlice.Web.ViewModels
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
			Donators = context.Page.Donators?.Select(don => context.WithNestedContent(don).AsViewModel<DonatorsViewModel>()).AsList();
		}
				
		public string IntroText { get; }
		public string InnerTitle { get; }
		public ImageViewModel Image { get; }
		public string CollectedFundsText { get; }
		public string FundsGoalText { get; }
		public string DonatorsTitle { get; }
		public IList<DonatorsViewModel> Donators { get; }


	}
}