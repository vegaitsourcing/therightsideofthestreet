using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.EmailSender;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Forms
{
	public class IntroduceCrewFormController : BaseSurfaceController
	{
		[ChildActionOnly]
		public ActionResult IntroduceCrewForm()
		{
			return PartialView(new IntroduceCrewFormViewModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SubmitForm(IntroduceCrewFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return CurrentUmbracoPage();
			}

			HandleMailSend(model);

			return RedirectToCurrentUmbracoPage();
		}

		private void HandleMailSend(IntroduceCrewFormViewModel model)
		{
			Settings settings = Umbraco.GetSettings(CurrentPage.Site().Id);
			EmailHandler emailSender = new EmailHandler();

			bool sentMail = emailSender.CrewIntroduceRequest(model, settings.AdminEmailAddress);

			if (!sentMail)
			{
				TempData[Constants.Constants.TempDataFail] = "fail";
			}
			else
			{
				TempData[Constants.Constants.TempDataSuccess] = "success";
			}
		}
	}
}
