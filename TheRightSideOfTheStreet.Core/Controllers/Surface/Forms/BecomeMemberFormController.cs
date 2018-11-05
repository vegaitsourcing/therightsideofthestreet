using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.EmailSender;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Forms
{
	public class BecomeMemberFormController : BaseSurfaceController
	{
		[ChildActionOnly]
		public ActionResult BecomeMemberForm(string status)
		{
			return PartialView(new BecomeMemberFormViewModel() { Status = status});
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SubmitForm(BecomeMemberFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return CurrentUmbracoPage();
			}

			Settings settings = Umbraco.GetSettings(CurrentPage.Site().Id);
			EmailHandler emailSender = new EmailHandler();



			bool sentMail = emailSender.BecomeMemberContactUsRequest(model, settings.AdminEmailAddress);

			if (!sentMail) {
				TempData[Constants.Constants.TempDataFail] = "fail";
				return CurrentUmbracoPage();
			}

			TempData[Constants.Constants.TempDataSuccess] = "success";
			return RedirectToCurrentUmbracoPage();
		}
		
	}
}
