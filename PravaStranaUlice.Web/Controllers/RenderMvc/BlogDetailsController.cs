using PravaStranaUlice.Models;
using PravaStranaUlice.Web.ViewModels;
using System.Web.Mvc;

namespace PravaStranaUlice.Web.Controllers.RenderMvc
{
    public class BlogDetailsController : BlogPageController<BlogDetails>
    {
         public ActionResult BlogDetails(BlogDetails model) => CurrentTemplate(new BlogDetailsViewModel(CreateBlogPageContext(model)));
    }
}

