using System.Collections.Generic;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.EmailSender;
using TheRightSideOfTheStreet.Core.ViewModels.Partials;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Forms
{
	public class LeaguesFormController : BaseSurfaceController
	{
		[ChildActionOnly]
		public ActionResult LeaguesForm(IList<CrewViewModel> crews)
		{
			return PartialView(new LeaguesFormViewModel() { Crews = crews });
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SubmitForm(LeaguesFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return CurrentUmbracoPage();
			}

			Crew crew = Umbraco.TypedContent(model.Crew)?.OfType<Crew>();

			if (crew != null)
			{
				model.City = crew.Ancestor<City>().Name;
				
			}

			Settings settings = Umbraco.GetSettings(CurrentPage.Site().Id);
			EmailHandler emailSender = new EmailHandler();

			bool sentMail = emailSender.CompetitionRequest(model, settings.AdminEmailAddress);

			if (!sentMail)
			{
				TempData[Constants.Constants.TempDataFail] = "fail";
				return CurrentUmbracoPage();
			}
			TempData[Constants.Constants.TempDataSuccess] = "success";

			return RedirectToCurrentUmbracoPage();

		}
	}
}
