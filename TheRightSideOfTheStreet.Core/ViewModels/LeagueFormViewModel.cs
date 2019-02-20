using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Partials;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.DocumentTypes;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class LeagueFormViewModel : PageViewModel
	{
		public LeagueFormViewModel(IPageContext<LeagueForm> context) : base(context)
		{
			Crews = context.Crews.AsViewModel<CrewViewModel>().ToList();
		}

		public IList<CrewViewModel> Crews { get; }
	}
}
