using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class AthleteLandingController : BasePageController<AthleteLanding>
	{

		public ActionResult Index(AthleteLanding model)
		{
			if (model.AthleteMember != null)
			{
				return View(nameof(AthleteMember), new AthleteMemberViewModel(CreatePageContext(model), model.AthleteMember));
			}

			if (model.Admin != null)
			{
				return View(nameof(Admin), new AdminViewModel(CreatePageContext(model), model.Admin));
			}

			var query = Request[Constants.Constants.RequestParameters.Query];
			var viewModel = new AthleteLandingViewModel(CreatePageContext(model), query);
			
			return CurrentTemplate(viewModel);
		}
	}
}
