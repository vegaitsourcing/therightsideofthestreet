using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.Helpers;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms;
using Umbraco.Core;
using Umbraco.Web;
using TheRightSideOfTheStreet.Models.Extensions;


namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Forms
{
	public class ResetMemberPasswordFormController : BaseSurfaceController
	{
		[ChildActionOnly]
		public ActionResult ResetMemberPasswordForm()
		{
			return PartialView(new ResetPasswordFormViewModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ResetPassword(ResetPasswordFormViewModel model)
		{
			UmbracoHelper uh = new UmbracoHelper(UmbracoContext.Current);
			var service = ApplicationContext.Current.Services.MemberService;

			if (!ModelState.IsValid)
			{

				return CurrentUmbracoPage();
			}

			var resetMember = service.GetByEmail(model.Email);

			if (resetMember != null)
			{
				if (model.NewPassword == model.ConfirmNewPassword)
				{
					service.SavePassword(resetMember, model.NewPassword);
					service.Save(resetMember);

					int siteId = CurrentPage.Site().Id;
					return RedirectToUmbracoPage(UmbracoHelperExtensions.GetLoginPage(uh, siteId));
				}
			}

			ModelState.AddModelError("", UmbracoDictionaryHelper.LoginForm.ResetPasswordFailed);
			return CurrentUmbracoPage();
		}
	}
}
