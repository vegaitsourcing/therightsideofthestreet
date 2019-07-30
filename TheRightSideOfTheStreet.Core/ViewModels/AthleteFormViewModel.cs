using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Partials;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class AthleteFormViewModel : PageViewModel
	{
		public AthleteFormViewModel(IPageContext<AthleteForm> context) : base(context)
		{
			Crews = context.Crews.AsViewModel<CrewViewModel>().ToList();
		}

		public IList<CrewViewModel> Crews { get;}

		public bool FromAthletePage { get; set; }
	}
}
