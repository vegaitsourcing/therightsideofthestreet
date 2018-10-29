using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Models;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class AthleteLandingController : BasePageController<AthleteLanding>
	{

		public ActionResult Index(AthleteLanding model)
		{
			if(model.AthleteMember != null)
			{
				return View(nameof(AthleteMember), new AthleteMemberViewModel(CreatePageContext(model), model.AthleteMember));
			}
			return CurrentTemplate(new AthleteLandingViewModel(CreatePageContext(model)));
		}
	}
}
