using PravaStranaUlice.Models;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace PravaStranaUlice.Web.Controllers.RenderMvc
{
	public class DonationsAndMembershipController : RenderMvcController
	{
		public ActionResult Index(DonationsAndMembership model)
		{
			return CurrentTemplate(model);
		}
	}
}