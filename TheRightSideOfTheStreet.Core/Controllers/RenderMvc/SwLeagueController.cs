using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class SwLeagueController : BasePageController<SWleague>
	{
		public ActionResult Index(SWleague model) => CurrentTemplate(new SwLeagueViewModel(Umbraco.CreatePageContext(model)));
	}
}
