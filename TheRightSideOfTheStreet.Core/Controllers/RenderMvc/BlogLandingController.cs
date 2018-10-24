
using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class BlogLandingController : BasePageController<BlogLanding>
	{
		public ActionResult BlogLanding(BlogLanding model) => CurrentTemplate(new BlogLandingViewModel(CreatePageContext(model)));

	}

}
