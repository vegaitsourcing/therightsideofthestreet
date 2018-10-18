using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class WebsiteController : BasePageController<Website>
    {
        public ActionResult Index(Website model) => CurrentTemplate(new WebsiteViewModel(CreatePageContext(model)));
    }
}