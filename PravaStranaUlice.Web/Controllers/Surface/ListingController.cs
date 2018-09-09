using PravaStranaUlice.Models;
using PravaStranaUlice.Models.Extensions;
using PravaStranaUlice.Web.Controllers.Surface;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web;

namespace PravaStranaUlice.Web.Controllers.Surface
{
	public class ListingController : BaseSurfaceController
	{
		public static string ListExerciseStepsUrl = $"/umbraco/surface/{nameof(ListingController).RemoveControllerSuffix()}/{nameof(ListExerciseSteps)}";

		public ActionResult ListExerciseSteps(int currentPage)
		{
			ExerciseSubtype model = Umbraco.TypedContent(currentPage).OfType<ExerciseSubtype>();
			List<ExerciseStep> steps = model.ExerciseSteps.Cast<ExerciseStep>().ToList();

			return RenderActionResult(steps, () => PartialView(steps));
		}

		//public ActionResult Pagination(PaginationModel model)
		//{
		//	return RenderActionResult(model, () => PartialView(model));
		//}

		
		//[ChildActionOnly]
		//public ActionResult SearchPagination(PaginationModel model)
		//{
		//	return RenderActionResult(model, () => PartialView(model));
		//}
	}
}