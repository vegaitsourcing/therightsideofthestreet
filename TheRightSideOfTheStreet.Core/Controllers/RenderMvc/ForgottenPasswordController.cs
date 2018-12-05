using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class ForgottenPasswordController : BasePageController<ForgottenPassword>
	{
		public ActionResult ForgottenPassword(ForgottenPassword model)
		{
			return CurrentTemplate(new ForgottenPasswordViewModel(CreatePageContext(model)));
		}
	}
}
