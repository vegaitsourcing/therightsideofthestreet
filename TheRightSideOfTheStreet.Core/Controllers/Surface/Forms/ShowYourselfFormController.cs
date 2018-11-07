using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Common;
using TheRightSideOfTheStreet.Core.EmailSender;
using TheRightSideOfTheStreet.Core.ViewModels.Partials;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Forms
{
	public class ShowYourselfFormController : BaseSurfaceController
	{
		[ChildActionOnly]
		public ActionResult ShowYourselfForm(IList<CrewViewModel> crews)
		{
			return PartialView(new ShowYourselfFormViewModel() { Crews = crews});
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SubmitForm(ShowYourselfFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return CurrentUmbracoPage();
			}

			Crew crew = Umbraco.TypedContent(model.Crew)?.OfType<Crew>();

			if (crew != null)
			{
				model.City = crew.Ancestor<City>().Name;
				model.Country = crew.Ancestor<Country>().Name;
			}
			string memberName = $"{model.Name} {model.Surname}";
			var member = Services.MemberService.CreateMemberWithIdentity(model.Email, model.Email, memberName, AthleteMember.ModelTypeAlias);

			member.SetValue(nameof(AthleteMember.FullName), memberName);

			var profileImage = Services.MediaService.CreateMediaWithIdentity(model.ProfilePicture.FileName, AppSettings.AthleteMembersProfileFolderId, Image.ModelTypeAlias);
			profileImage.SetValue("umbracoFile", model.ProfilePicture.FileName, model.ProfilePicture.InputStream);
			Services.MediaService.Save(profileImage);

			member.SetValue(nameof(AthleteMember.ProfileImage), new GuidUdi("media", profileImage.Key).ToString());

			List<string> udiList = new List<string>();

			foreach (var image in model.Images)
			{
				var media = Services.MediaService.CreateMediaWithIdentity(image.FileName, AppSettings.AthleteMembersProfileFolderId, Image.ModelTypeAlias);
				media.SetValue("umbracoFile", image.FileName, image.InputStream);
				Services.MediaService.Save(media);

				GuidUdi mediaUdi = media.GetUdi();
				string mediaUdiAsString = mediaUdi.ToString();
				udiList.Add(mediaUdiAsString);
			}

			member.SetValue(nameof(AthleteMember.Images), string.Join(",", udiList));

			if (model.Crew != null)
			{
				member.SetValue(nameof(AthleteMember.Crew), new GuidUdi("document", model.Crew).ToString());
			}

			member.SetValue(nameof(AthleteMember.Biography), model.DescribeYourself);		
			member.SetValue(nameof(AthleteMember.Achievements), model.ImportantAchievements);
				
			if (!string.IsNullOrEmpty(model.VisionOfSport))
			{
				member.SetValue(nameof(AthleteMember.Vision), model.VisionOfSport);
			}
			member.SetValue(nameof(AthleteMember.Country), model.Country);
			member.SetValue(nameof(AthleteMember.City), model.City);

			if (!string.IsNullOrEmpty(model.FacebookProfile))
			{
				member.SetValue(nameof(AthleteMember.FacebookProfile), model.FacebookProfile);
			}

			if (!string.IsNullOrEmpty(model.InstagramProfile))
			{
				member.SetValue(nameof(AthleteMember.InstagramProfile), model.InstagramProfile);
			}

			if (!string.IsNullOrEmpty(model.YouTubeChannel))
			{
				member.SetValue(nameof(AthleteMember.YoutubeProfile), model.YouTubeChannel);
			}

			string protocol = Request.Url.Scheme;
			string domain = Request.Url.Host;

			string memberGuid = member.Key.ToString();

			string newAthleteMemberLink = string.Format(AppSettings.NewAthleteMemberLink, protocol, domain, memberGuid);

			member.IsApproved = false;

			Services.MemberService.Save(member);

			Settings settings = Umbraco.GetSettings(CurrentPage.Site().Id);
			EmailHandler emailSender = new EmailHandler();

			bool sentMail = emailSender.AthleteRegistrationRequest(model, settings.AdminEmailAddress, newAthleteMemberLink);

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
