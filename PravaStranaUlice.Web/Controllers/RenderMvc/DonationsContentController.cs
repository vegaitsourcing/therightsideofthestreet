using PravaStranaUlice.Models;
using PravaStranaUlice.Web.ViewModels;
using System.Web.Mvc;

namespace PravaStranaUlice.Web.Controllers.RenderMvc
{
	public class DonationsContentController : BasePageController<DonationsContent>
	{
		public ActionResult DonationsContent(DonationsContent model) => CurrentTemplate(new DonationsContentViewModel(CreatePageContext(model)));
	}
}