using System.Web.Mvc;
using TheRightSideOfTheStreet.Models.DocumentTypes;
using Umbraco.Web.Mvc;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class XMLSitemapController : RenderMvcController
	{
		public ActionResult XMLSitemap(IDomainRoot model)
			=> CurrentTemplate(model);
	}
}
