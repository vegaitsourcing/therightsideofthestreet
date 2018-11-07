using System;
using System.Linq;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class ExerciseLandingController : BasePageController<ExerciseLanding>
	{
		public ActionResult ExerciseLanding(ExerciseLanding model)
		{
			var levelPage = model.Children.FirstOrDefault();
			if (levelPage == null) throw new Exception("Page not found");

			return new RedirectToUmbracoPageResult(levelPage);
		}
	}
}
