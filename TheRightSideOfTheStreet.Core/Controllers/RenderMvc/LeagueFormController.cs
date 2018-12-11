using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class LeagueFormController : BasePageController<LeagueForm>
	{
		public ActionResult Index(LeagueForm model) => CurrentTemplate(new LeagueFormViewModel(Umbraco.CreatePageContext(model)));
	}
}
