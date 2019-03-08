using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.Search;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Models;
using Umbraco.Web;


namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Forms
{
	public class SearchAthleteFormController : BaseSurfaceController
	{
		[ChildActionOnly]
		public ActionResult SearchAthleteForm(AthleteLandingViewModel model)
		{
			return PartialView(model);
		}

		[HttpGet]
		public ActionResult SearchAthlete(Guid pageKey, string searchQuery)
		{

			if (!string.IsNullOrEmpty(searchQuery))
			{
				AthleteMembersSearch am = new AthleteMembersSearch();
				IEnumerable<AthleteMember> athletes = am.GetAthletes().Where(m => m.FullName.Contains(searchQuery)).ToList();

				return RedirectToCurrentUmbracoPage();
			}

			return CurrentUmbracoPage();
		}
	}
}
