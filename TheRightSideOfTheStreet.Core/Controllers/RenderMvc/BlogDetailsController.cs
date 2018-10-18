using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class BlogDetailsController : BlogPageController<BlogDetails>
    {
         public ActionResult BlogDetails(BlogDetails model) => CurrentTemplate(new BlogDetailsViewModel(CreateBlogPageContext(model)));
    }
}

