using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class ExerciseLevelController : BasePageController<ExerciseLevel>
	{
		public ActionResult ExerciseLevel(ExerciseLevel model)
		{
			return CurrentTemplate(new ExerciseLevelViewModel(new ExerciseLevelContext(CreatePageContext(model))));
		}
	}
}