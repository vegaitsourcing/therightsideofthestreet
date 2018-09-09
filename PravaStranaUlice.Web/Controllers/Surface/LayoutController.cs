using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PravaStranaUlice.Models.Extensions;
using Umbraco.Web;
using PravaStranaUlice.Web.ViewModels;

namespace PravaStranaUlice.Web.Controllers.Surface
{
    public class LayoutController : BaseSurfaceController
    {
        public LayoutController()
        {
            UmbracoHelper = new UmbracoHelper(UmbracoContext.Current);
        }

        public UmbracoHelper UmbracoHelper { get; }

        [ChildActionOnly]
        public ActionResult Header()
        {
            HeaderViewModel viewModel = new HeaderViewModel(UmbracoHelper.GetSettings(), UmbracoHelper.GetHome());
            return PartialView("_Header", viewModel);
        }
        
    }
}