using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRightSideOfTheStreet.Common.Extensions;
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
			Crews = context.Repository.Descendants<Crew>().AsViewModel<CrewViewModel>().ToList();
		}

		public IList<CrewViewModel> Crews { get;}
	}
}
