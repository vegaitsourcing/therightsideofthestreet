using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class DonationsContentController : BasePageController<DonationsContent>
	{
		public ActionResult DonationsContent(DonationsContent model) => CurrentTemplate(new DonationsContentViewModel(CreatePageContext(model)));
	}
}