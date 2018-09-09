using PravaStranaUlice.Models;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace PravaStranaUlice.Web.Controllers.RenderMvc
{
	public class ExerciseLandingPageController : RenderMvcController
	{
		public ActionResult Index(ExerciseLandingPage model)
		{
			return CurrentTemplate(model);
		}
	}
}