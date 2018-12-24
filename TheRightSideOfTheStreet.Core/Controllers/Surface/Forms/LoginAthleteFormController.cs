using System;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Common;
using TheRightSideOfTheStreet.Core.EmailSender;
using TheRightSideOfTheStreet.Core.Helpers;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Forms
{
	public class LoginAthleteFormController : BaseSurfaceController
	{
		[ChildActionOnly]
		public ActionResult LoginAthleteForm(string registerForm, string forgottenPassword)
		{
			return PartialView(new LoginFormViewModel() { RegisterFormUrl = registerForm, ForgottenPasswordUrl = forgottenPassword });
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult MemberLogin(LoginFormViewModel model)
		{
			Settings settings = Umbraco.GetSettings(CurrentPage.Site().Id);
			var service = ApplicationContext.Current.Services.MemberService;

			if (!ModelState.IsValid)
			{

				return CurrentUmbracoPage();
			}

			var findMember = service.GetByEmail(model.Email);
			if (findMember.IsLockedOut)
			{
				try
				{
					string protocol = Request.Url.Scheme;
					string domain = Request.Url.Host;

					string memberGuid = findMember.Key.ToString();
					string AthleteMemberLink = string.Format(AppSettings.AthleteMemberLink, protocol, domain, memberGuid);

					string emailFrom = model.Email;
					string emailTo = settings.AdminEmailAddress;
					string fullName = findMember.Name;

					EmailHandler emailSender = new EmailHandler();
					emailSender.MemberLockedSendMail(model, emailFrom, emailTo, fullName, AthleteMemberLink);

					ModelState.AddModelError("", UmbracoDictionaryHelper.LoginForm.MemberLocked);

				}
				catch (Exception ex)
				{

					Logger.Error(typeof(LoginFormViewModel), "Failed to send mail", ex);
				}

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