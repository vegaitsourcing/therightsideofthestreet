using PravaStranaUlice.Models;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace PravaStranaUlice.Web.Controllers.RenderMvc
{
    public class BlogLandingController : RenderMvcController
    {
        public ActionResult Index(BlogLanding model)
        {
            return CurrentTemplate(model);
        }
    }
}