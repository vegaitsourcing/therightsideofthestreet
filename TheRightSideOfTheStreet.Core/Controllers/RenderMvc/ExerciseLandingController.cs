using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Models;
using Umbraco.Web.Mvc;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class ExerciseLandingController : BasePageController<ExerciseLanding>
	{
		public ActionResult ExerciseLanding(ExerciseLanding model)
		{
			var levelPage = model.Children.FirstOrDefault();
			if (levelPage == null) throw new HttpException(404, "Page not found");

			return new RedirectToUmbracoPageResult(levelPage);
		}
	}
}
