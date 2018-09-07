using System.Web.Mvc;
using Umbraco.Web.Mvc;
using PravaStranaUlice.Models.DocumentTypes;

namespace PravaStranaUlice.Web.Controllers.RenderMvc
{
	public class XMLSitemapController : RenderMvcController
	{
		public ActionResult XMLSitemap(IDomainRoot model)
			=> CurrentTemplate(model);
	}
}
