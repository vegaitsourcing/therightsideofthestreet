using MailChimp.Net;
using MailChimp.Net.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Common;
using TheRightSideOfTheStreet.Core.Helpers;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms;

namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Forms
{
	public class NewsletterFormController : BaseSurfaceController
	{
		[ChildActionOnly]
		public ActionResult NewsletterForm()
		{
			return PartialView(new NewsletterFormViewModel());
		}

		[HttpPost]
		public async Task<string> SubmitForm(string emailAddress)
		{
			var memeber = new Member
			{
				EmailAddress = emailAddress,
				StatusIfNew = Status.Pending,
				EmailType = "html",
				IpSignup = Request.UserHostAddress,

				MergeFields = new Dictionary<string, object>
				{
					{"EMAILADDRESS", emailAddress }
				}
			};

			try
			{
				MailChimpManager Manager = new MailChimpManager(AppSettings.MailchimpKey);
				var result = await Manager.Members.AddOrUpdateAsync(AppSettings.MailchimpListId, memeber);

				TempData[Constants.Constants.SubmitMessageKey] = "Success";
			}
			catch (Exception ex)
			{
				Logger.Error(typeof(NewsletterFormController), "Failed to subscribe member.", ex);
				TempData[Constants.Constants.SubmitFail] = "Fail";
				ModelState.AddModelError("", UmbracoDictionaryHelper.NewsletterModule.Fail);
				return UmbracoDictionaryHelper.NewsletterModule.Fail;
			}
			return UmbracoDictionaryHelper.NewsletterModule.Success;

		}
	}
}
