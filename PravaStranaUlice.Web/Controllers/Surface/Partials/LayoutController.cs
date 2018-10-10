using PravaStranaUlice.Web.ViewModels.Partials.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PravaStranaUlice.Web.Controllers.Surface.Partials
{
	public class LayoutController : BasePartialController
	{
		[ChildActionOnly]
		public ActionResult MetaTags(MetaTagsViewModel viewModel)
		{
			return PartialView(viewModel);
		}
	}
}