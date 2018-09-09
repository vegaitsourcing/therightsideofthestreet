using PravaStranaUlice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace PravaStranaUlice.Web.Controllers.RenderMvc
{
    public class BlogLandingController : RenderMvcController
    {
        // GET: BlogLanding
        public ActionResult Index(BlogLanding model)
        {
            return CurrentTemplate(model);
        }
    }
}