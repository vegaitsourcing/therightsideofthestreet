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
			Crews = umbracoHelper.TypedContentAtRoot().Where(x => x.ContentType.Alias.Equals("workoutCrewsContainer")).FirstOrDefault().Descendants(4).AsViewModel<CrewViewModel>().ToList();
		}

		public IList<CrewViewModel> Crews { get;}
		public readonly UmbracoHelper umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
	}
}
