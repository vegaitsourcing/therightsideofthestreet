using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.Helpers;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Forms
{
	public class LoginAthleteFormController : BaseSurfaceController
	{
		[ChildActionOnly]
		public ActionResult LoginAthleteForm( string registerForm, string forgottenPassword)
		{
			return PartialView(new LoginFormViewModel() { RegisterFormUrl = registerForm, ForgottenPasswordUrl = forgottenPassword});
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

		[HttpPost]
		public ActionResult MemberLogout()
		{
			Members.Logout();
			return RedirectToUmbracoPage(CurrentPage.Site());
		}

	}
}