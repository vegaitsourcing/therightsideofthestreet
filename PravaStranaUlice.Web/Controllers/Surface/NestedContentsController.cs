using PravaStranaUlice.Models;
using System.Web.Mvc;

namespace PravaStranaUlice.Web.Controllers.Surface
{
	public class NestedContentsController : BaseSurfaceController
	{
		[ChildActionOnly]
		public ActionResult ExerciseStep(ExerciseStep model)
		{
			return RenderActionResultBasedOnName(model);
		}

		[ChildActionOnly]
		public ActionResult FounderItem(FounderItem model)
		{
			return RenderActionResultBasedOnName(model);
		}

		[ChildActionOnly]
		public ActionResult DonatorItem(DonatorItem model)
		{
			return RenderActionResultBasedOnName(model);
		}

	}
}