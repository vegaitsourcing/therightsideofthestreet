using PravaStranaUlice.Models;
using PravaStranaUlice.Web.ViewModels;
using System.Web.Mvc;

namespace PravaStranaUlice.Web.Controllers.RenderMvc
{
    public class WebsiteController : BasePageController<Website>
    {
        public ActionResult Index(Website model) => CurrentTemplate(new WebsiteViewModel(CreatePageContext(model)));
    }
}