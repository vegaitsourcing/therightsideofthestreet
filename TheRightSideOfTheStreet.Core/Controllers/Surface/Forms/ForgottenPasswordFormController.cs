using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.EmailSender;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Forms
{
	public class ForgottenPasswordFormController : BaseSurfaceController
	{

		public ActionResult ForgottenPasswordForm()
		{
			return PartialView(new ForgottenPasswordFormViewModel());
		}

		public ActionResult SendEmail(ForgottenPasswordFormViewModel model)
		{
			UmbracoHelper uh = new UmbracoHelper(UmbracoContext.Current);
			Settings settings = Umbraco.GetSettings(CurrentPage.Site().Id);
			var service = ApplicationContext.Current.Services.MemberService;

			if (!ModelState.IsValid) return CurrentUmbracoPage();

			var findMember = service.GetByEmail(model.Email);

			if (findMember != null)

				try
				{
					string emailTo = model.Email;
					string emailFrom = settings.AdminEmailAddress;
					string baseUrl = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, string.Empty);
					string resetLink = baseUrl + UmbracoHelperExtensions.GetPage<ResetPasswordForm>(uh, CurrentPage.Site().Id).Url;
						/*"/reset-password"*/;
					//UmbracoHelperExtensions.GetPage<ResetPasswordForm>(uh, CurrentPage.Site().Id).Url

					EmailHandler emailSender = new EmailHandler();
					emailSender.SendResetPasswordEmail(emailFrom, emailTo, resetLink);

					return RedirectToCurrentUmbracoPage();
				}
				catch
				{

				}

			return CurrentUmbracoPage();
		}
	}
}
