using PravaStranaUlice.Models;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace PravaStranaUlice.Web.Controllers.RenderMvc
{
	public class DonationController : RenderMvcController
	{
		public ActionResult Index(Donation model)
		{
			return CurrentTemplate(model);
		}
	}
}