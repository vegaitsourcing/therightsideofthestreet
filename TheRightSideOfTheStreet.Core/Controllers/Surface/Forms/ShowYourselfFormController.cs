using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Common;
using TheRightSideOfTheStreet.Core.EmailSender;
using TheRightSideOfTheStreet.Core.Helpers;
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
			return PartialView(new ShowYourselfFormViewModel() { Crews = crews });
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

			var memberService = Services.MemberService;

			if (memberService.GetByEmail(model.Email) != null)
			{
				ModelState.AddModelError("DuplicateEmail", UmbracoDictionaryHelper.UmbracoValidation.DuplicateEmailAddress);
				return CurrentUmbracoPage();
			}
			string memberName = $"{model.Name} {model.Surname}";
			IMember member = Services.MemberService.CreateMemberWithIdentity(model.Email, model.Email, memberName, AthleteMember.ModelTypeAlias);

			SetMemberFields(model, member, memberName);

			member.IsApproved = false;

			if (TrySaveMember(member))
			{
				HandleMailSend(member, model, string.Format(AppSettings.NewAthleteMemberLink, 
					Request.Url.Scheme, 
					Request.Url.Host, 
					member.Key.ToString()));
			}

			return RedirectToCurrentUmbracoPage();
		}

		private void SetMemberFields(ShowYourselfFormViewModel model, IMember member, string memberName)
		{
			Services.MemberService.AssignRole(member.Id, "Athletes Group");
			Services.MemberService.SavePassword(member, model.Password);

			member.SetValue(nameof(AthleteMember.FullName), memberName);

			var profileImage = Services.MediaService.CreateMediaWithIdentity(model.ProfilePicture.FileName, 
				AppSettings.AthleteMembersProfileFolderId, 
				Image.ModelTypeAlias);

			profileImage.SetValue("umbracoFile", model.ProfilePicture.FileName, model.ProfilePicture.InputStream);

			Services.MediaService.Save(profileImage);

			member.SetValue(nameof(AthleteMember.ProfileImage), new GuidUdi("media", profileImage.Key).ToString());

			member.SetValue(nameof(AthleteMember.Images), string.Join(",", CreateListOfImagesId(model)));

			if (model.Crew != null)
			{
				member.SetValue(nameof(AthleteMember.Crew), new GuidUdi("document", (Guid)model.Crew).ToString());
			}

			member.SetValue(nameof(AthleteMember.Biography), model.DescribeYourself);

			IEnumerable<string> achievements = model.ImportantAchievements.Split('|');

			member.SetValue(nameof(AthleteMember.Achievements), string.Join(Environment.NewLine, achievements));

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
		}

		private List<string> CreateListOfImagesId(ShowYourselfFormViewModel model)
		{
			List<string> udiList = new List<string>();

			foreach (var image in model.Images)
			{
				if (image != null)
				{
					var media = Services.MediaService.CreateMediaWithIdentity(image.FileName, AppSettings.AthleteMembersProfileFolderId, Image.ModelTypeAlias);
					media.SetValue("umbracoFile", image.FileName, image.InputStream);
					Services.MediaService.Save(media);

					udiList.Add(media.GetUdi().ToString());
				}
			}

			return udiList;
		}		

		private bool TrySaveMember(IMember member)
		{
			try
			{
				Services.MemberService.Save(member);
				return true;
			}
			catch (Exception ex)
			{
				Logger.Warn(typeof(ShowYourselfFormController), $"Something went wrong on member save: {ex}");
				return false;
			}
		}

		private void HandleMailSend(IMember member, ShowYourselfFormViewModel model, string memberLink)
		{
			Settings settings = Umbraco.GetSettings(CurrentPage.Site().Id);
			EmailHandler emailSender = new EmailHandler();

			bool sentMail = emailSender.AthleteRegistrationRequest(model, settings.AdminEmailAddress, memberLink);

			if (!sentMail)
			{
				Services.MemberService.Delete(member);
				TempData[Constants.Constants.TempDataFail] = "fail";
			}
			else
			{
				TempData[Constants.Constants.TempDataSuccess] = "success";
			}
		}
	}
}