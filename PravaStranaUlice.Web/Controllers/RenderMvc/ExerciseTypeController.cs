using PravaStranaUlice.Models;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace PravaStranaUlice.Web.Controllers.RenderMvc
{
	public class ExerciseTypeController : RenderMvcController
	{
		public ActionResult Index(ExerciseType model)
		{
			return CurrentTemplate(model);
		}
	}
}