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
				//UmbracoHelper uh = new UmbracoHelper(UmbracoContext.Current);
				AthleteMembersSearch am = new AthleteMembersSearch();
				IEnumerable<AthleteMember> athletes = am.GetAthletes().Where(m => m.FullName.Contains(searchQuery)).ToList();

				

				//IEnumerable<AthleteMemberPreviewViewModel> members = athletes.Select(at=>at.AsViewModel()); 

				//athletes.AsViewModel()
				//IList<AthleteMemberPreviewViewModel> ath = athletes.Where(m => m.FullName.Contains(searchQuery)).OfType<AthleteMemberPreviewViewModel>().ToList();

				//IList<AthleteMemberPreviewViewModel> AthleteMembers = am.GetAthletes().OfType<AthleteMemberPreviewViewModel>().Where(m => m.PreviewFullName.Contains(searchQuery)).ToList();
				

				//AthleteLandingViewModel model = Umbraco.TypedContent(pageKey)?

				//model.SearchQuery = Request[TempData[Constants.Constants.RequestParameters.Query].ToString()];
				//model.AthleteMembers = model.AthleteMembers.Where(m => m.PreviewFullName.Contains(searchQuery)).ToList();


				return RedirectToCurrentUmbracoPage();
			}

			return CurrentUmbracoPage();
		}
	}
}
