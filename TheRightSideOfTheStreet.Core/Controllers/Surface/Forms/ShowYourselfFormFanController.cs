using System.Web.Mvc;
using TheRightSideOfTheStreet.Common;
using TheRightSideOfTheStreet.Core.EmailSender;
using TheRightSideOfTheStreet.Core.Helpers;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Forms
{
	public class ShowYourselfFormFanController : BaseSurfaceController
	{
		[ChildActionOnly]
		public ActionResult ShowYourselfFormFan()
		{
			return PartialView(new ShowYourselfFormFanViewModel());
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SubmitFormFan(ShowYourselfFormFanViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return CurrentUmbracoPage();
			}


			string memberName = $"{model.Name} {model.Surname}";

			var memberService = Services.MemberService;

			if (memberService.GetByEmail(model.Email) != null)
			{
				ModelState.AddModelError("DuplicateEmail", UmbracoDictionaryHelper.UmbracoValidation.DuplicateEmailAddress);
				return CurrentUmbracoPage();
			}

			var member = Services.MemberService.CreateMemberWithIdentity(model.Email, model.Email, memberName, Fan.ModelTypeAlias);
			Services.MemberService.AssignRole(member.Id, "Fan Group");
			Services.MemberService.SavePassword(member, model.Password);
			member.SetValue(nameof(Fan.FullName), memberName);

			var profileImage = Services.MediaService.CreateMediaWithIdentity(model.ProfilePicture.FileName, AppSettings.AthleteMembersProfileFolderId, Image.ModelTypeAlias);
			profileImage.SetValue("umbracoFile", model.ProfilePicture.FileName, model.ProfilePicture.InputStream);
			Services.MediaService.Save(profileImage);

			member.SetValue(nameof(Fan.ProfileImage), new GuidUdi("media", profileImage.Key).ToString());

			string protocol = Request.Url.Scheme;
			string domain = Request.Url.Host;

			string memberGuid = member.Key.ToString();

			string newAthleteMemberLink = string.Format(AppSettings.NewAthleteMemberLink, protocol, domain, memberGuid);

			member.IsApproved = false;

			Services.MemberService.Save(member);

			Settings settings = Umbraco.GetSettings(CurrentPage.Site().Id);
			EmailHandler emailSender = new EmailHandler();

			bool sentMail = emailSender.FanRegistrationRequest(model, settings.AdminEmailAddress, newAthleteMemberLink);

			if (!sentMail)
			{
				memberService.Delete(member);
				TempData[Constants.Constants.TempDataFailFan] = "failFan";
				return CurrentUmbracoPage();
			}
			TempData[Constants.Constants.TempDataSuccessFan] = "successFan";

			return RedirectToCurrentUmbracoPage();
		}

	}
}
