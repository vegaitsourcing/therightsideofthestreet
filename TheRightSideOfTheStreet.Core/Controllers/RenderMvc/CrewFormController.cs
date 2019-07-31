using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class CrewFormController : BasePageController<CrewForm>
	{
		public ActionResult Index(CrewForm model) => CurrentTemplate(new CrewFormViewModel(Umbraco.CreatePageContext(model)));
	}
}
