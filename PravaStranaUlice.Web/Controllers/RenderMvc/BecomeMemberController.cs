using PravaStranaUlice.Models;
using PravaStranaUlice.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PravaStranaUlice.Web.Controllers.RenderMvc
{
    public class BecomeMemberController : BasePageController<BecomeMember>
    {
        public ActionResult BecomeMember(BecomeMember model) => CurrentTemplate(new BecomeMemberViewModel(CreatePageContext(model)));

        public ActionResult BeMember()
        {
            return View();
        }
    }
}