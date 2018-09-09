using PravaStranaUlice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace PravaStranaUlice.Web.Controllers
{
    public class AthletesLandingPageController : RenderMvcController
    {
        // GET: BlogLanding
        public ActionResult Index(AthleteLandingPage model)
        {
            return CurrentTemplate(model);
        }
    }
}