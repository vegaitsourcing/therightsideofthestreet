using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PravaStranaUlice.Models;
using Umbraco.Web.Mvc;

namespace PravaStranaUlice.Web.Controllers.RenderMvc
{
    public class BecomeAMemberController : RenderMvcController
    {
        public ActionResult Index(BecomeAmember model)
        {
            return CurrentTemplate(model);
        }
    }
}