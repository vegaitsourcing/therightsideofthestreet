using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.EmailSender;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Forms
{
	public class WorkoutParksFormController : BaseSurfaceController
	{
		[ChildActionOnly]
		public ActionResult WorkoutParksForm()
		{
			return PartialView(new WorkoutParksFormViewModel());
		}

		public ActionResult SubmitForm(WorkoutParksFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return CurrentUmbracoPage();
			}

			Settings settings = Umbraco.GetSettings(CurrentPage.Site().Id);
			EmailHandler emailSender = new EmailHandler();
			string Url = model.Url;

			bool sentMail = emailSender.WorkoutParksRequest(model, settings.AdminEmailAddress, Url);

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
