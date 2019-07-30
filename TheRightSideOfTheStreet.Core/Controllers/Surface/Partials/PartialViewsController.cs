using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.ViewModels;

namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Partials
{
	public class PartialViewsController : BasePartialController
	{
		public ActionResult BlogEntry(BlogDetailsViewModel blogEntry)
		{
			return PartialView(blogEntry);
		}

		public ActionResult CommentsSection(BlogDetailsViewModel commentsSection)
		{
			return PartialView(commentsSection);
		}

		public ActionResult Comments(CommentViewModel comments)
		{
			return PartialView(comments);
		}

		public ActionResult BlogPreview(BlogDetailsPreviewViewModel blogPreview)
		{
			return PartialView(blogPreview);
		}
	}
}
