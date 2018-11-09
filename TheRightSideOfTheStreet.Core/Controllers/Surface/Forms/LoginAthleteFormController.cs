using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.Helpers;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Forms
{
	public class LoginAthleteFormController : BaseSurfaceController
	{
		[ChildActionOnly]
		public ActionResult LoginAthleteForm()
		{
			return PartialView(new LoginFormViewModel());
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult MemberLogin(LoginFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return CurrentUmbracoPage();
			}

			if (Members.Login(model.Email, model.Password))
			{
				return RedirectToUmbracoPage(CurrentPage.Site());
			}

			TempData[Constants.Constants.TempDataFail] = "fail";
			ModelState.AddModelError("", UmbracoDictionaryHelper.LoginForm.LoginFailed);

			return CurrentUmbracoPage();
		}

		[HttpGet]
		public ActionResult MemberLogout()
		{
			Members.Logout();
			var loginPage = Umbraco.GetPage<LoginForm>(CurrentPage.Site().Id);
			return RedirectToUmbracoPage(loginPage);
		}

	}
}