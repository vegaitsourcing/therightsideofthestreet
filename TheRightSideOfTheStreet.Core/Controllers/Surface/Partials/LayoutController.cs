using System;
using System.Web;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Common;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.Layout;

namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Partials
{
	public class LayoutController : BasePartialController
	{
		[ChildActionOnly]
		public ActionResult MetaTags(MetaTagsViewModel viewModel)
		{
			return PartialView(viewModel);
		}

		[ChildActionOnly]
		public ActionResult OpenGraph(OpenGraphViewModel viewModel)
		{
			return PartialView(viewModel);
		}

		[ChildActionOnly]
		public ActionResult Header(HeaderViewModel viewModel)
		{
			return PartialView(viewModel);
		}

		[ChildActionOnly]
		public ActionResult Footer(FooterViewModel viewModel)
		{
			return PartialView(viewModel);
		}
		[ChildActionOnly]
		public ActionResult Partners(PartnersSectionViewModel viewModel)
		{
			return PartialView(viewModel);
		}

		[ChildActionOnly]
		public ActionResult Cookies(CookiesViewModel model)
		{
			if (Request.Cookies[AppSettings.CookieName] != null) return new EmptyResult();

			return PartialView(model);
		}
	}
}