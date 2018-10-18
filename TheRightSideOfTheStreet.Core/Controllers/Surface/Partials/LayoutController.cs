using System.Web.Mvc;
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
		public ActionResult Header(HeaderViewModel viewModel)
		{
			return PartialView(viewModel);
		}

		[ChildActionOnly]
		public ActionResult Footer(FooterViewModel viewModel)
		{
			return PartialView(viewModel);
		}
	}
}