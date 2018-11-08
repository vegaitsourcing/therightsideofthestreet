using System;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Common;
using TheRightSideOfTheStreet.Core.EmailSender;
using TheRightSideOfTheStreet.Core.Helpers;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.WebApi;

namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Forms
{
	public class CommentFormController : BaseSurfaceController
	{
		[ChildActionOnly]
		public ActionResult CommentForm()
		{
			return PartialView(new CommentFormViewModel());
		}

		[MemberAuthorize]
		[HttpPost]
		public ActionResult SubmitForm(CommentFormViewModel model)
		{
			Settings settings = Umbraco.GetSettings(CurrentPage.Site().Id);

			if (!ModelState.IsValid) return CurrentUmbracoPage();

			try
			{
				int commentId = CreateBlogComment(model);

				string emailFrom = Members.CurrentUserName;
				string fullName = Members.GetCurrentMember().Name;
				string emailTo = settings.AdminEmailAddress;

				string protocol = Request.Url.Scheme;
				string domain = Request.Url.Host;

				string blogLink = string.Format(AppSettings.BlogUrl, protocol, domain, commentId);

				EmailHandler emailSender = new EmailHandler();
				emailSender.BlogComment(emailFrom, fullName, emailTo, blogLink);

				return RedirectToCurrentUmbracoPage();
			}
			catch (Exception ex)
			{
				Logger.Error(typeof(CommentFormController), "Failed to create blog comment.", ex);
			}


			ModelState.AddModelError("", UmbracoDictionaryHelper.BlogDetails.PostCommentFailed);
			return CurrentUmbracoPage();
		}

		private int CreateBlogComment(CommentFormViewModel model)
		{
			IContentService contentService = Services.ContentService;
			var pageName = CurrentPage.Name;
			var parentId = CurrentPage.Id;
			var member = Members.GetCurrentMember();

			var content = contentService.CreateContent($"{member.Name} - {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}", parentId, Comment.ModelTypeAlias);
			content.SetValue(nameof(Comment.Comments), model.Comment);
			content.SetValue(nameof(Comment.Member), new GuidUdi("member", member.GetKey()).ToString());

			contentService.Save(content);

			return content.Id;
		}


	}
}

