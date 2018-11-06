using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class ExerciseGroupController : BasePageController<ExerciseGroup>
	{
		public ActionResult ExerciseGroup(ExerciseGroup model) => CurrentTemplate(new ExerciseGroupViewModel(CreatePageContext(model)));
	}
}
