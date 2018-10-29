using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class ModularContentController : BasePageController<ModularContent>
	{
		public ActionResult ModularContent(ModularContent model) => CurrentTemplate(new ModularContentViewModel(CreatePageContext(model)));
	}
}
