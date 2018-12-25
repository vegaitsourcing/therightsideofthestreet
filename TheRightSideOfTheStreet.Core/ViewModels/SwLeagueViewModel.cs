using MailChimp.Net.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class SwLeagueViewModel : PageViewModel
	{
		public SwLeagueViewModel(IPageContext<SWleague> context) : base(context)
		{
			IntroText = context.Page.IntroText;
			Link = context.Page.Link.AsViewModel();
			Competitors = context.Page.Competitors?.Select(ed => context.WithNestedContent(ed).AsViewModel<RankingTableViewModel>()).ToList();
			ScoringLeft = context.Page.ScoringLeft;
			ScoringRight = context.Page.ScoringRight;

		}
		public string IntroText { get; }
		public LinkViewModel Link { get; }
		public IHtmlString ScoringLeft { get; }
		public IHtmlString ScoringRight { get; }
		public IList<RankingTableViewModel> Competitors { get; }
	}
}
